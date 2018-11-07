using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Balabolin.Crestron.Gate;
using Balabolin.Utils;
using SharpBroadlink.Devices;

namespace Balabolin.Crestron.Gate.Plugins.Broadlink
{
    public class Plugin : IPlugin
    {
        #region IPlugin
        public string Name
        {
            get
            {
                return "Broadlink IR blaster";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.1";
            }
        }

        public Bitmap Logo
        {
            get
            {
                return Resource1.Broadlink;
            }
        }

        public List<string> InDigitals { get; }
        public List<string> InAnalogs { get; }
        public List<string> InSerials { get; }

        public List<string> OutDigitals { get; }
        public List<string> OutAnalogs { get; }
        public List<string> OutSerials { get; }


        public event DigitalEventHandler OnDigital;
        public event AnalogueEventHandler OnAnalog;
        public event SerialEventHandler OnSerial;
        public event EventHandler<StringEventArgs> OnDebugEvent;

        public void ProcessAnaloglEvent(int iJoin, int Data)
        {
            //throw new NotImplementedException();
        }

        public void ProcessDigitalEvent(int iJoin, bool Data)
        {
            //throw new NotImplementedException();
            if (Data)
            {
                IRCode irc = PluginSettings.IRCodes[iJoin - 1];
                SendSignalAsync(irc,irc.Blaster);
            }
        }

        public void ProcessSerialEvent(int iJoin, string Data)
        {
            //throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {
            PluginForm pf = new PluginForm();
            pf.plugin = this;
            pf.ShowDialog();
            SaveSettings();
            LoadJoins();
        }

        public void Start()
        {
          InitBlasters();
        }

        public void Stop()
        {

        }
        #endregion

        #region Settings

        public BroadlinkGateSettings PluginSettings;

        private void LoadSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BroadlinkGateSettings));
            try
            {
                using (FileStream fs = new FileStream("Balabolin.Crestron.Gate.Plugins.Broadlink.xml", FileMode.OpenOrCreate))
                {
                    PluginSettings = (BroadlinkGateSettings)formatter.Deserialize(fs);
                    if (PluginSettings == null)
                        PluginSettings = new BroadlinkGateSettings();
                }
            }
            catch
            {
                PluginSettings = new BroadlinkGateSettings();
            }
        }

        private void SaveSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BroadlinkGateSettings));
            using (FileStream fs = new FileStream("Balabolin.Crestron.Gate.Plugins.Broadlink.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, PluginSettings);
            }
        }

        #endregion

        #region Logging
        private void WLog(string str, params object[] list)
        {
            OnDebugEvent?.Invoke(this, new StringEventArgs(String.Format(str, list)));
        }


        #endregion

        #region Blaster collection related functions

        Dictionary<string, Rm> RmBlasters = new Dictionary<string, Rm>();

        private BlasterInfo GetBlasterByIP(string ip)
        {
            try
            {
                return PluginSettings.Blasters.First(d => d.IP == ip);
            }
            catch
            {
                return null;
            }
        }
        public BlasterInfo GetBlasterByName(string name)
        {
            try
            {
                return PluginSettings.Blasters.First(d => d.Name == name);
            }
            catch
            {
                return null;
            }
        }

        private Rm GetRMBlasterByName(string name)
        {
            return RmBlasters[name];
        }

        #endregion

        #region Blaster functions
        public async void InitBlasters()
        {
            WLog("Scanning blasters...");
            RmBlasters.Clear();
            var devices = await SharpBroadlink.Broadlink.Discover(5);
            WLog("Found: {0} online blasters", devices.Length.ToString());
            foreach (BlasterInfo bi in PluginSettings.Blasters)
            {
                bi.Online = false;
            }
            foreach (Rm Discovered in devices)
            {
                var Registered = GetBlasterByIP(Discovered.Host.Address.ToString());
                if (Registered != null)
                {
                    RmBlasters.Add(Registered.Name, Discovered);
                    WLog("Blaster '{0}' [{1}] online", Registered.Name, Registered.IP);
                }
                else
                {
                    WLog("Found new blaster [{0}]. Added to collection", Discovered.Host.Address.ToString());
                    BlasterInfo biNew = new BlasterInfo() { IP = Discovered.Host.Address.ToString(), Name = Discovered.Host.Address.ToString() };
                    PluginSettings.Blasters.Add(biNew);
                    Registered = GetBlasterByIP(Discovered.Host.Address.ToString());
                    RmBlasters.Add(Registered.Name, Discovered);
                }
                Registered.Online = true;
            }
            // check for offline
            foreach (BlasterInfo bi in PluginSettings.Blasters)
            {
                if (!bi.Online)
                {
                    WLog("! Blaster '{0}' [{1}] offline", bi.Name, bi.IP);
                }
            }
        }
        public  async void LearnIRCodeAsync(IRCode irCode,string BlasterName)
        {
            Rm RMBlaster = GetRMBlasterByName(BlasterName);
            WLog("Enter learning mode on {0}", BlasterName);
            var x = await RMBlaster.Auth();
            if (x)
            {
                x = await RMBlaster.EnterLearning();
                if (x)
                {
                    MessageBox.Show(" Point the remote control to be learned to RM Pro, and press the button. Hit OK finally", "Learning...", MessageBoxButtons.OK);
                    var data = await RMBlaster.CheckData();
                    if (data.Length > 0)
                    {
                        string code = StringHelper.CreateHexPrintableString(data);
                        WLog("Code={0}", code);
                        irCode.Command = code;
                    }
                }
                else
                {
                    WLog("! Blaster [{0}] not respond", BlasterName);
                }
            }
            else
            {
                WLog("! Blaster [{0}] not respond", BlasterName);
            }
        }


        public async void SendSignalAsync(IRCode iRCode, string BlasterName)
        {
            if (iRCode.Command!=null && iRCode.Command != "")
            {
                Rm RMBlaster = GetRMBlasterByName(BlasterName);
                WLog("Send {0} via {1}", iRCode.Name, BlasterName);
                var x = await RMBlaster.Auth();
                if (x)
                {
                    var data = StringHelper.CreateBytesFromHexString(iRCode.Command);
                    x = await RMBlaster.SendData(data);
                    if (x)
                    {
                        WLog("OK");
                    }
                    else
                    { WLog("! Blaster [{0}] not respond", BlasterName); }
                }
                else
                { WLog("! Blaster [{0}] not respond", BlasterName); }
            }
        }

        #endregion

        public void LoadJoins()
        {
            InDigitals.Clear();
            foreach (IRCode irc in PluginSettings.IRCodes)
            {
                InDigitals.Add(irc.Name);
            }
        }

        public Plugin()
        {
            InDigitals = new List<string>();
            InAnalogs = new List<string>();
            InSerials = new List<string>();

            OutDigitals = new List<string>();
            OutAnalogs = new List<string>();
            OutSerials = new List<string>();

            LoadSettings();

            LoadJoins();
            /*
            InDigitals.Add("DVD Power Switch");
            InDigitals.Add("DVD Volume -");
            InDigitals.Add("DVD Volume +");
            InDigitals.Add("Key up");
            InDigitals.Add("Key down");
            InDigitals.Add("Key left");
            InDigitals.Add("Key right");
            InDigitals.Add("Key OK"); 
            */
        }
    }
}
