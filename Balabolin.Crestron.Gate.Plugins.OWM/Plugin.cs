using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balabolin.Crestron.Gate;
using Balabolin.Utils;

namespace Balabolin.Crestron.Gate.Plugins.OWM
{
    public class Plugin : IPlugin
    {
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
            throw new NotImplementedException();
        }

        public void ProcessSerialEvent(int iJoin, string Data)
        {
            throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {
            throw new NotImplementedException();
        }
        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}

