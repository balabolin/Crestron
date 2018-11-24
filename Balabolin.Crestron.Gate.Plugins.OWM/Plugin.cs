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

        private TimeSpan SunRise;
        private TimeSpan SunSet;

        private ushort IconToCrestronVT(string sIcon, DateTime dt)
        {
            int itemp = Convert.ToUInt16(sIcon.TrimEnd('n', 'd'));
            if (itemp ==50)
            {
                itemp = 9;
            } else if (itemp == 13)
            {
                itemp = 8;
            } else if (itemp >= 9)
            {
                itemp = itemp - 4;
            }
            var t = dt.TimeOfDay;
            if (!(t > SunRise && t < SunSet)) itemp = itemp + 9;
            return (ushort)itemp;
        }

        private void SendForecast(ForecastTime fr, int num)
        {
            ushort tempJoin = (ushort)(1+num-1);
            ushort weatherJoin = (ushort)(2 + num - 1);
            ushort iconJoin = (ushort)(5 + num - 1);
            ushort timeJoin = (ushort)(5 + num - 1);
            ushort tempSJoin = (ushort)(9 + num);
            OnAnalog?.Invoke(tempJoin, (ushort)(fr.Temperature.Value * 10));
            OnSerial?.Invoke(weatherJoin, fr.Symbol.Name);
            OnAnalog?.Invoke(iconJoin, IconToCrestronVT(fr.Symbol.Var,fr.To));
            string sTime = fr.To.ToString("t") + (fr.To.Day == DateTime.Now.Day ? "" : " (+1)");
            OnSerial?.Invoke(timeJoin, sTime);
            OnSerial?.Invoke(tempSJoin, Math.Round(fr.Temperature.Value,1).ToString() + "°");
        }

        private async void GetForecast()
        {
            OnDigital?.Invoke(1, false);
            try
            {
                var cw = await owmClient.CurrentWeather.GetByName(Settings.City, MetricSystem.Metric, OpenWeatherMapLanguage.RU);
                var fw = await owmClient.Forecast.GetByName(Settings.City, false, MetricSystem.Metric, OpenWeatherMapLanguage.RU);

                SunRise = fw.Sun.Rise.ToLocalTime().TimeOfDay;
                SunSet = fw.Sun.Set.ToLocalTime().TimeOfDay;

                OnAnalog?.Invoke(4, IconToCrestronVT(cw.Weather.Icon, DateTime.Now));
                OnSerial?.Invoke(1, cw.Weather.Value);
                OnSerial?.Invoke(8, SunRise.ToString(@"h\:mm"));
                OnSerial?.Invoke(9, SunSet.ToString(@"h\:mm"));

                OnAnalog?.Invoke(8, (ushort)cw.Humidity.Value);
                OnAnalog?.Invoke(9, (ushort)cw.Wind.Speed.Value);

                DateTime fr1;
                DateTime fr2;
                DateTime fr3;

                DateTime curr = DateTime.Now;

                int hr = curr.Hour;
                if (hr<5)
                {
                    fr1 = new DateTime(curr.Year, curr.Month, curr.Day, 6, 0, 0);
                    fr2 = new DateTime(curr.Year, curr.Month, curr.Day, 12, 0, 0);
                    fr3 = new DateTime(curr.Year, curr.Month, curr.Day, 18, 0, 0);
                } else if (hr<8)
                {
                    fr1 = new DateTime(curr.Year, curr.Month, curr.Day, 9, 0, 0);
                    fr2 = new DateTime(curr.Year, curr.Month, curr.Day, 12, 0, 0);
                    fr3 = new DateTime(curr.Year, curr.Month, curr.Day, 18, 0, 0);
                }
                else if (hr < 11)
                {
                    fr1 = new DateTime(curr.Year, curr.Month, curr.Day, 12, 0, 0);
                    fr2 = new DateTime(curr.Year, curr.Month, curr.Day, 15, 0, 0);
                    fr3 = new DateTime(curr.Year, curr.Month, curr.Day, 18, 0, 0);
                }
                else if (hr < 14)
                {
                    fr1 = new DateTime(curr.Year, curr.Month, curr.Day, 15, 0, 0);
                    fr2 = new DateTime(curr.Year, curr.Month, curr.Day, 18, 0, 0);
                    fr3 = new DateTime(curr.Year, curr.Month, curr.Day, 21, 0, 0);
                }
                else if (hr < 17)
                {
                    fr1 = new DateTime(curr.Year, curr.Month, curr.Day, 18, 0, 0);
                    fr2 = new DateTime(curr.Year, curr.Month, curr.Day, 21, 0, 0);
                    fr3 = (new DateTime(curr.Year, curr.Month, curr.Day, 0, 0, 0)).AddDays(1);
                }
                else if (hr < 20)
                {
                    fr1 = new DateTime(curr.Year, curr.Month, curr.Day, 21, 0, 0);
                    fr2 = (new DateTime(curr.Year, curr.Month, curr.Day, 9, 0, 0)).AddDays(1);
                    fr3 = (new DateTime(curr.Year, curr.Month, curr.Day, 12, 0, 0)).AddDays(1);
                }
                else 
                {
                    fr1 = (new DateTime(curr.Year, curr.Month, curr.Day, 9, 0, 0)).AddDays(1);
                    fr2 = (new DateTime(curr.Year, curr.Month, curr.Day, 12, 0, 0)).AddDays(1);
                    fr3 = (new DateTime(curr.Year, curr.Month, curr.Day, 18, 0, 0)).AddDays(1);
                }
                var fw1 = fw.Forecast.FirstOrDefault(o => o.To == fr1);
                var fw2 = fw.Forecast.FirstOrDefault(o => o.To == fr2);
                var fw3 = fw.Forecast.FirstOrDefault(o => o.To == fr3);
                SendForecast(fw1, 1);
                SendForecast(fw2, 2);
                SendForecast(fw3, 3);
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

            OutAnalogs.Add("Forecast temperature 1");           //1
            OutAnalogs.Add("Forecast temperature 2");           //2
            OutAnalogs.Add("Forecast temperature 3");           //3
            OutAnalogs.Add("Current icon");                     //4
            OutAnalogs.Add("Forecast icon 1");                  //5
            OutAnalogs.Add("Forecast icon 2");                  //6
            OutAnalogs.Add("Forecast icon 3");                  //7

            OutAnalogs.Add("Humidity");                         //8
            OutAnalogs.Add("Wind speed");                       //9

            OutSerials.Add("Current weather description");      //1
            OutSerials.Add("Forecast weather description 1");   //2
            OutSerials.Add("Forecast weather description 2");   //3
            OutSerials.Add("Forecast weather description 3");   //4

            OutSerials.Add("Forecast time 1");   //5
            OutSerials.Add("Forecast time 2");   //6
            OutSerials.Add("Forecast time 3");   //7

            OutSerials.Add("Sun rise time");   //8
            OutSerials.Add("Sun set time");   //9

            OutSerials.Add("Forecast temperature String 1");           //10
            OutSerials.Add("Forecast temperature String 2");           //11
            OutSerials.Add("Forecast temperature String 3");           //12

            LoadSettings();

            ReloadClient();

            GetForecast();
        }
    }
}

