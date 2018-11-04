using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balabolin.Crestron.Gate;
using Balabolin.Utils;

namespace Balabolin.Crestron.Gate.Plugins.Broadlink
{
    public class Plugin : IPlugin
    {
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
        public event EventHandler<StringEventArgs> OnDebug;

        public void ProcessAnaloglEvent(int iJoin, int Data)
        {
            //throw new NotImplementedException();
        }

        public void ProcessDigitalEvent(int iJoin, bool Data)
        {
            //throw new NotImplementedException();
        }

        public void ProcessSerialEvent(int iJoin, string Data)
        {
            //throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {
            PluginForm pf = new PluginForm();
            pf.ShowDialog();
        }

        public void Start()
        {
        }

        public void Stop()
        {

        }

        public Plugin()
        {
            InDigitals = new List<string>();
            InAnalogs = new List<string>();
            InSerials = new List<string>();

            OutDigitals = new List<string>();
            OutAnalogs = new List<string>();
            OutSerials = new List<string>();
            InDigitals.Add("DVD Power Switch");
            InDigitals.Add("DVD Volume -");
            InDigitals.Add("DVD Volume +");
            InDigitals.Add("Key up");
            InDigitals.Add("Key down");
            InDigitals.Add("Key left");
            InDigitals.Add("Key right");
            InDigitals.Add("Key OK");
        }
    }
}
