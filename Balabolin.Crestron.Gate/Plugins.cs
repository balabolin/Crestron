using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Balabolin.Crestron;
using Balabolin.Utils;

namespace Balabolin.Crestron.Gate.Plugins
{
    public delegate void PluginConnectionHandler(Plugin plugin);
    public delegate void PluginDebugEventHandler(Plugin plugin, string debugText);


    public class Plugin
    {
        #region Properties
        private DateTime _AssemblyDateTime;
        private IPlugin _plugin;
        public string Name => _plugin.Name;
        public string Version => _plugin.Version;
        public Bitmap Logo => _plugin.Logo;

        public List<Signal> InDigitals { get; }
        public List<Signal> InAnalogs { get; }
        public List<Signal> InSerials { get; }

        public List<Signal> OutDigitals { get; }
        public List<Signal> OutAnalogs { get; }
        public List<Signal> OutSerials { get; }
        public DateTime AssemblyDateTime
        {
            get
            {
                return _AssemblyDateTime;
            }
        }

        private bool _autoreconnect = false;
        public bool AutoReconnect {
            get {
                return _autoreconnect;
            }
            set
            {
                if (value)
                {
                    if (!ConnectedToCrestron && HexPID!="") StartReconnectTimer();
                } else
                {
                    StopReconnectTimer();
                }
                _autoreconnect = value;
            }
          }

        public CIPClient Crestron;

        public List<PluginLogItem> PluginLog = new List<PluginLogItem>();

        public string AssemblyFileName { get; }

        public PluginManager Manager { get; }
        public bool ConnectedToCrestron
        {
            get
            {
                return (Crestron != null) && (Crestron.Connected);
            }
        }

        public byte PID
        {
            get
            {
                return ((HexPID == "") ? (byte)0 : ((byte)Convert.ToInt32(HexPID, 16)));
            }
        }
        public string HexPID { get; set; }

        #endregion

        #region Events
        public event ChangeHandler OnSignalDataChange;
        public event PluginConnectionHandler OnPluginConnectedToCrestron;
        public event PluginConnectionHandler OnPluginDisconnectedFromCrestron;
        public event PluginDebugEventHandler OnPluginDebugEvent;
        #endregion

        #region Event handlers
        public void SignalDataChange(Signal signal,bool toLog)
        {
            OnSignalDataChange?.Invoke(signal,toLog);
        }
        public void OnCrestronConnect()
        {
            OnPluginConnectedToCrestron?.Invoke(this);
        }

        public void OnCrestronDisonnect()
        {
            OnPluginDisconnectedFromCrestron?.Invoke(this);
            if (AutoReconnect) StartReconnectTimer();
        }

        public void OnDebug(object sender, StringEventArgs e)
        {
            WriteToLog(sender is CIPClient ? LogItemType.Crestron : LogItemType.Internal, e.val);
        }

        private void WriteToLog(LogItemType lit, string s)
        {
            PluginLogItem pli = new PluginLogItem(lit,s);
            PluginLog.Add(pli);
            OnPluginDebugEvent?.Invoke(this, pli.ToLongLogString());
        }

        #region Crestron event handlers
        public void OnCrestronDigitalEventHandler(ushort usJoin, bool bValue)
        {
            if (usJoin <= InDigitals.Count)
            {
                InDigitals[usJoin - 1].SystemSetData(bValue);
            }
            else
            {
                WriteToLog(LogItemType.Internal, String.Format("Invalid digital join ({0}) received", usJoin.ToString()));
            }
        }

        public void OnCrestronAnalogEventHandler(ushort usJoin, ushort usValue)
        {
            if (usJoin <= InAnalogs.Count)
            {
                InAnalogs[usJoin - 1].SystemSetData(usValue);
            }
            else
            {
                WriteToLog(LogItemType.Internal, String.Format("Invalid analog join ({0}) received", usJoin.ToString()));
            }
        }

        public void OnCrestronSerialEventHandler(ushort usJoin, string sValue)
        {
            if (usJoin <= InSerials.Count)
            {
                InSerials[usJoin - 1].SystemSetData(sValue);
            }
            else
            {
                WriteToLog(LogItemType.Internal, String.Format("Invalid serial join ({0}) received", usJoin.ToString()));
            }
        }
        #endregion
        #endregion

        #region Crestron event handlers
        public void OnPluginDigitalEventHandler(ushort usJoin, bool bValue)
        {
            if (usJoin <= OutDigitals.Count)
            {
                OutDigitals[usJoin - 1].SystemSetData(bValue);
            }
            else
            {
                WriteToLog(LogItemType.Internal, String.Format("Undefined digital join ({0}) send", usJoin.ToString()));
            }
        }

        public void OnPluginAnalogEventHandler(ushort usJoin, ushort usValue)
        {
            if (usJoin <= OutAnalogs.Count)
            {
                OutAnalogs[usJoin - 1].SystemSetData(usValue);
            }
            else
            {
                WriteToLog(LogItemType.Internal, String.Format("Undefined analog join ({0}) send", usJoin.ToString()));
            }
        }

        public void OnPluginSerialEventHandler(ushort usJoin, string sValue)
        {
            if (usJoin <= OutSerials.Count)
            {
                OutSerials[usJoin - 1].SystemSetData(sValue);
            }
            else
            {
                WriteToLog(LogItemType.Internal, String.Format("Undefined serial join ({0}) send", usJoin.ToString()));
            }
        }
        #endregion

        #region Load/unload functions
        private void LoadDefinitions()
        {
            foreach (Signal signal in InDigitals)
                signal.OnDataChange -= SignalDataChange;
            foreach (Signal signal in InAnalogs)
                signal.OnDataChange -= SignalDataChange;
            foreach (Signal signal in InSerials)
                signal.OnDataChange -= SignalDataChange;
            foreach (Signal signal in OutDigitals)
                signal.OnDataChange -= SignalDataChange;
            foreach (Signal signal in OutAnalogs)
                signal.OnDataChange -= SignalDataChange;
            foreach (Signal signal in OutSerials)
                signal.OnDataChange -= SignalDataChange;

            InDigitals.Clear();
            InAnalogs.Clear();
            InSerials.Clear();
            OutAnalogs.Clear();
            OutDigitals.Clear();
            OutSerials.Clear();

            ushort i = 1;
            if (_plugin.InDigitals != null)
            {
                foreach (string s in _plugin.InDigitals)
                {
                    Signal ss = new Signal(this, i, s, SignalTypeEnum.Digital, SignalDirectionEnum.Input);
                    ss.OnDataChange += SignalDataChange;
                    InDigitals.Add(ss);
                    i++;
                }
            }
            i = 1;
            if (_plugin.InAnalogs != null)
            {
                foreach (string s in _plugin.InAnalogs)
                {
                    Signal ss = new Signal(this, i, s, SignalTypeEnum.Analog, SignalDirectionEnum.Input);
                    ss.OnDataChange += SignalDataChange;
                    InAnalogs.Add(ss);
                    i++;
                }
            }
            i = 1;
            if (_plugin.InSerials != null)
            {
                foreach (string s in _plugin.InSerials)
                {
                    Signal ss = new Signal(this, i, s, SignalTypeEnum.Serial, SignalDirectionEnum.Input);
                    ss.OnDataChange += SignalDataChange;
                    InSerials.Add(ss);
                    i++;
                }
            }
            i = 1;
            if (_plugin.OutDigitals != null)
            {
                foreach (string s in _plugin.OutDigitals)
                {
                    Signal ss = new Signal(this, i, s, SignalTypeEnum.Digital, SignalDirectionEnum.Output);
                    ss.OnDataChange += SignalDataChange;
                    OutDigitals.Add(ss);                    
                    i++;
                }
            }
            i = 1;
            if (_plugin.OutAnalogs != null)
            {
                foreach (string s in _plugin.OutAnalogs)
                {
                    Signal ss = new Signal(this, i, s, SignalTypeEnum.Analog, SignalDirectionEnum.Output);
                    ss.OnDataChange += SignalDataChange;
                    OutAnalogs.Add(ss);
                    i++;
                }
            }
            i = 1;
            if (_plugin.InSerials != null)
            {
                foreach (string s in _plugin.OutSerials)
                {
                    Signal ss = new Signal(this, i, s, SignalTypeEnum.Serial, SignalDirectionEnum.Output);
                    ss.OnDataChange += SignalDataChange;
                    OutSerials.Add(ss);
                    i++;
                }
            }
        }
        public void LoadPlugin()
        {
            //Assembly pluginAss = Assembly.LoadFrom(AssemblyFileName);
            Assembly pluginAss = Assembly.Load(File.ReadAllBytes(AssemblyFileName));

            if (pluginAss != null)
            {
                try
                {
                    foreach (var type in pluginAss.GetTypes())
                    {
                        var i = type.GetInterface("IPlugin");
                        if (i != null)
                        {
                            _plugin = (IPlugin)pluginAss.CreateInstance(type.FullName);
                            _plugin.OnDebugEvent += OnDebug;
                            _plugin.OnAnalog += OnPluginAnalogEventHandler;
                            _plugin.OnDigital += OnPluginDigitalEventHandler;
                            _plugin.OnSerial += OnPluginSerialEventHandler;
                            _AssemblyDateTime = File.GetLastWriteTime(AssemblyFileName);
                            LoadDefinitions();
                            _plugin.Start();
                        }
                    }
                }
                catch (Exception e)
                {
                    WriteToLog(LogItemType.Internal, e.Message);
                }
            }
        }
        public void Reload()
        {
            Unload();
            LoadPlugin();
        }

        public void Unload()
        {
            Stop();
            DisconnectFromCrestron();
            _plugin = null;
        }

        #endregion

        #region Connect/disconnect crestron
        public void DisconnectFromCrestron()
        {
            Crestron?.DisconnectFromServer();
        }

        public void ConnectToCrestron()
        {
            if (PID != 0)
                Crestron.ConnectToServer(Manager.gateSettings.CrestronIP, PID);
        }
        #endregion

        #region Start/stop
        public void Start()
        {
            _plugin.Start();
        }

        public void Stop()
        {
            _plugin.Stop();
        }
        #endregion

        #region Processing events

        public void ProcessDigitalEvent(int iJoin, bool Data)
        {
            _plugin.ProcessDigitalEvent(iJoin, Data);
        }
        public void ProcessAnaloglEvent(int iJoin, int Data)
        {
            _plugin.ProcessAnaloglEvent(iJoin, Data);
        }

        public void ProcessSerialEvent(int iJoin, string Data)
        {
            _plugin.ProcessSerialEvent(iJoin, Data);
        }

        #endregion

        #region Reconnect logic
        private System.Threading.Timer timer;
        private System.Threading.AutoResetEvent timerEvent = new System.Threading.AutoResetEvent(false);


        private void OnReconnectTimer(Object stateInfo)
        {
            if (!ConnectedToCrestron)
            {
                ConnectToCrestron();
            }
            else
            {
                StopReconnectTimer();
            }
        }

        private void StartReconnectTimer()
        {
            timer = new System.Threading.Timer(OnReconnectTimer, timerEvent, 0, 5000);
        }
        private void StopReconnectTimer()
        {
            timer?.Dispose();
        }

        #endregion

        public void ShowPluginWindow()
        {
            _plugin.ShowMainWindow();
            LoadDefinitions();
        }

        public Plugin(string assemblyFileName, PluginManager manager)
        {
            AssemblyFileName = assemblyFileName;
            Manager = manager;
            InDigitals = new List<Signal>();
            InAnalogs = new List<Signal>();
            InSerials = new List<Signal>();

            OutDigitals = new List<Signal>();
            OutAnalogs = new List<Signal>();
            OutSerials = new List<Signal>();

            Crestron = new CIPClient();
            Crestron.OnСonnect += OnCrestronConnect;
            Crestron.OnDisconnect += OnCrestronDisonnect;
            Crestron.OnDigital += OnCrestronDigitalEventHandler;
            Crestron.OnAnalogue += OnCrestronAnalogEventHandler;
            Crestron.OnSerial += OnCrestronSerialEventHandler;
            Crestron.Debug += OnDebug;
            //Debu
        }
    }

    public class PluginManager
    {
        public string PluginDir { get; }

        public List<Plugin> Plugins;

        public GateSettings gateSettings { get; set; }
        public void Rescan()
        {
            string[] pluginFiles = Directory.GetFiles(PluginDir, "*.dll");
            List<string> filesList = new List<string>();
            foreach (string fn in pluginFiles) filesList.Add(fn);

            // Проверяем на удаленные и обновления
            List<Plugin> PluginsToRemove = new List<Plugin>();
            foreach (Plugin plug in Plugins)
            {
                try
                {
                    if (filesList.First(d => d == plug.AssemblyFileName) != null)
                    {
                        filesList.Remove(plug.AssemblyFileName);
                        // проверяем обновление
                        if (File.GetLastWriteTime(plug.AssemblyFileName) != plug.AssemblyDateTime)
                        {
                            plug.Reload();
                        }
                    }
                }
                catch
                {
                    PluginsToRemove.Add(plug);
                    plug.Unload();
                }
            }
            foreach(Plugin plug in PluginsToRemove)
            {
                Plugins.Remove(plug);
            }
            PluginsToRemove = null;
            // Добовляем новые
            foreach (string pluginFile in filesList)
            {
                Plugin plugin = new Plugin(pluginFile,this);
                plugin.LoadPlugin();
                Plugins.Add(plugin);
                PluginSetting ps = GetSettngForPlugin(plugin);
                if (ps == null)
                {
                    ps = new PluginSetting() { Name = plugin.Name, PID = "" };
                    gateSettings.PluginsSettings.Add(ps);
                    SaveGlobalSettings();
                    plugin.HexPID = "";
                }
                else
                {
                    plugin.HexPID = ps.PID;
                    if (ps.PID != "")
                    {
                        plugin.AutoReconnect = true;
                        plugin.ConnectToCrestron();
                    } 
                }
            }
        }

        public void ChangePluginPID(Plugin plugin,string PID)
        {
            plugin.HexPID = PID;
            GetSettngForPlugin(plugin).PID = PID;
            SaveGlobalSettings();
        }


        public PluginManager(string pluginDir)
        {
            PluginDir = pluginDir;
            Plugins = new List<Plugin>();
        }

        #region Settings load/save
        private PluginSetting GetSettngForPlugin(Plugin plugin)
        {
            try
            {
                return gateSettings.PluginsSettings.First(o => o.Name == plugin.Name);
            }
            catch
            {
                return null;
            }
        }

        public void LoadGateSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GateSettings));
            try
            {
                using (FileStream fs = new FileStream("GateSettings.xml", FileMode.OpenOrCreate))
                {
                    gateSettings = (GateSettings)formatter.Deserialize(fs);
                }
            }
            catch
            {
                gateSettings = new GateSettings();
            }
        }

        public void SaveGlobalSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GateSettings));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("GateSettings.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gateSettings);
            }
        }
        #endregion
    }
}