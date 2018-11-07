using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Balabolin.Crestron.Gate;
using Balabolin.Utils;
using OpenWeatherMap;
namespace Balabolin.Crestron.Gate.Plugins.OWM
{
    public class Plugin : IPlugin
    {
        #region Interface

        public string Name
        {
            get
            {
                return "OpenWeatherMap";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }

        public Bitmap Logo
        {
            get
            {
                return Resource1.OWM_logo;
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
            throw new NotImplementedException();
        }

        public void ProcessDigitalEvent(int iJoin, bool Data)
        {
            if (iJoin == 1 && Data) GetForecast();
        }

        public void ProcessSerialEvent(int iJoin, string Data)
        {
            throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {
            string oldAPI = Settings.APIKey;
            PluginForm pf = new PluginForm();
            pf.plugin = this;
            pf.ShowDialog();
            SaveSettings();

            if (oldAPI != Settings.APIKey) ReloadClient();
        }
        public void Start()
        {

        }

        public void Stop()
        {

        }

        #endregion

        #region Settings

        public OWMSettings Settings;

        private void LoadSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(OWMSettings));
            try
            {
                using (FileStream fs = new FileStream("Balabolin.Crestron.Gate.Plugins.OWM.xml", FileMode.OpenOrCreate))
                {
                    Settings = (OWMSettings)formatter.Deserialize(fs);
                    if (Settings == null)
                        Settings = new OWMSettings();
                }
            }
            catch
            {
                Settings = new OWMSettings();
            }
        }

        private void SaveSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(OWMSettings));
            using (FileStream fs = new FileStream("Balabolin.Crestron.Gate.Plugins.OWM.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Settings);
            }
        }


        #endregion
        #region OWM Logic
        private OpenWeatherMapClient owmClient;
        private void ReloadClient()
        {
            owmClient = new OpenWeatherMapClient(Settings.APIKey);
        }

        private async void GetForecast()
        {
            OnDigital?.Invoke(1, false);
            try
            {
                var cw = await owmClient.CurrentWeather.GetByName(Settings.City, MetricSystem.Metric, OpenWeatherMapLanguage.RU);
                var fw = await owmClient.Forecast.GetByName(Settings.City, false, MetricSystem.Metric, OpenWeatherMapLanguage.RU);
                ushort CurrentTemp = (ushort)(cw.Temperature.Value * 10);

                OnAnalog?.Invoke(1, CurrentTemp);
            }
            catch
            {
                OnDigital?.Invoke(1, true);
            }
        }

        #endregion
        public Plugin()
        {
            InDigitals = new List<string>();
            InAnalogs = new List<string>();
            InSerials = new List<string>();

            OutDigitals = new List<string>();
            OutAnalogs = new List<string>();
            OutSerials = new List<string>();

            InDigitals.Add("Refresh");                          //1

            OutDigitals.Add("Update error");                    //1

            OutAnalogs.Add("Current temperature");              //1
            OutAnalogs.Add("Forecast temperature 1");           //2
            OutAnalogs.Add("Forecast temperature 2");           //3
            OutAnalogs.Add("Forecast temperature 3");           //4
            OutAnalogs.Add("Current icon");                     //5
            OutAnalogs.Add("Forecast icon 1");                  //6
            OutAnalogs.Add("Forecast icon 2");                  //7
            OutAnalogs.Add("Forecast icon 3");                  //8

            OutSerials.Add("Current weather description");      //1
            OutSerials.Add("Forecast weather description 1");   //2
            OutSerials.Add("Forecast weather description 2");   //3
            OutSerials.Add("Forecast weather description 3");   //4

            LoadSettings();

            ReloadClient();

            GetForecast();
        }
    }
}

