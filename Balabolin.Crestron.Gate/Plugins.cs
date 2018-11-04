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
        public event PluginDebugEventHandler OmPluginDebugEvent;
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
        }

        public void OnDebug(object sender, StringEventArgs e)
        {
            WriteToLog(e.val);
        }

        private void WriteToLog(string s)
        {
            PluginLogItem pli = new PluginLogItem(s);
            PluginLog.Add(pli);
            OmPluginDebugEvent?.Invoke(this, pli.ToLongLogString());
        }

        public void OnDigitalEventHandler(ushort usJoin, bool bValue)
        {
            if (usJoin <= InDigitals.Count)
            {
                InDigitals[usJoin - 1].SystemSetData(bValue);
            }
            else
            {
                WriteToLog(String.Format("Invalid digital join ({0}) received", usJoin.ToString()));
            }
        }

        public void OnAnalogEventHandler(ushort usJoin, ushort usValue)
        {
            if (usJoin <= InAnalogs.Count)
            {
                InAnalogs[usJoin - 1].SystemSetData(usValue);
            }
            else
            {
                WriteToLog(String.Format("Invalid analog join ({0}) received", usJoin.ToString()));
            }
        }

        public void OnSerialEventHandler(ushort usJoin, string sValue)
        {
            if (usJoin <= InSerials.Count)
            {
                InSerials[usJoin - 1].SystemSetData(sValue);
            }
            else
            {
                WriteToLog(String.Format("Invalid serial join ({0}) received", usJoin.ToString()));
            }
        }

        #endregion

        #region Load/unload functions
        private void LoadDefinitions()
        {
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
                foreach (var type in pluginAss.GetTypes())
                {
                    var i = type.GetInterface("IPlugin");
                    if (i != null)
                    {
                        _plugin = (IPlugin)pluginAss.CreateInstance(type.FullName);
                        _AssemblyDateTime = File.GetLastWriteTime(AssemblyFileName);
                        LoadDefinitions();
                        _plugin.Start();
                    }
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


        public void ShowPluginWindow()
        {
            _plugin.ShowMainWindow();
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
            Crestron.OnDigital += OnDigitalEventHandler;
            Crestron.OnAnalogue += OnAnalogEventHandler;
            Crestron.OnSerial += OnSerialEventHandler;
            Crestron.Debug += OnDebug;
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