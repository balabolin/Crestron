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

        public List<JoinDescription> Digitals => throw new NotImplementedException();

        public List<JoinDescription> Analogs => throw new NotImplementedException();

        public List<JoinDescription> Serials => throw new NotImplementedException();

        public event DigitalEventHandler OnDigital;
        public event AnalogueEventHandler OnAnalog;
        public event SerialEventHandler OnSerial;
        public event EventHandler<StringEventArgs> OnDebug;

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
    }
}
