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
    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        Bitmap Logo { get; }
        List<string> InDigitals { get; }
        List<string> InAnalogs { get; }
        List<string> InSerials { get; }

        List<string> OutDigitals { get; }
        List<string> OutAnalogs { get; }
        List<string> OutSerials { get; }

        event DigitalEventHandler OnDigital;
        event AnalogueEventHandler OnAnalog;
        event SerialEventHandler OnSerial;

        event EventHandler<StringEventArgs> OnDebugEvent;

        void ShowMainWindow();

        void ProcessDigitalEvent(int iJoin, bool Data);
        void ProcessAnaloglEvent(int iJoin, int Data);
        void ProcessSerialEvent(int iJoin, string Data);

        void Start();
        void Stop();
    }
}
