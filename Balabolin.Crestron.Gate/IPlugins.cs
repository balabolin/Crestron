using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balabolin.Crestron;
using Balabolin.Utils;

namespace Balabolin.Crestron.Gate.Plugins
{
    public class JoinDescription
    {
        public string InputName { get; set; }
        public string OutputName { get; set; }
    }



    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        Bitmap Logo { get; }
        List<JoinDescription> Digitals { get; }
        List<JoinDescription> Analogs { get; }
        List<JoinDescription> Serials { get; }

        event DigitalEventHandler OnDigital;
        event AnalogueEventHandler OnAnalog;
        event SerialEventHandler OnSerial;

        void ShowMainWindow();

        void ProcessDigitalEvent(int iJoin, bool Data);
        void ProcessAnaloglEvent(int iJoin, int Data);
        void ProcessSerialEvent(int iJoin, string Data);

        event EventHandler<StringEventArgs> OnDebug;
    }
}
