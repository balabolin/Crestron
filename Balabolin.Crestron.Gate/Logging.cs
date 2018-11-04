using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balabolin.Crestron.Gate.Plugins
{
    public class LogItem
    {
        public DateTime RaisedDateTime { get; }
        public virtual string ToShortLogString()
        {
            return ToString();
        }

        public virtual string ToLongLogString()
        {
            return ToString();
        }

        public LogItem()
        {
            RaisedDateTime = DateTime.Now;
        }
    }

    public class SignalLogItem:LogItem
    {
        public Signal RaisedBySignal { get; }
        public SignalChangeType ChangeType { get; }
        public object LoggedData { get; }


        public override string ToShortLogString()
        {
            return (String.Format("{0} {1} set to {2}",
                RaisedDateTime.ToString(),
                ChangeType == SignalChangeType.Manual ? "manually set" : "",
                RaisedBySignal.SignalType == SignalTypeEnum.Digital ? ((bool)LoggedData ? "ON" : "OFF") : LoggedData.ToString()));
        }

        public override string ToLongLogString()
        {
            return (String.Format("{0} {1} join {2} ({3}) {4} set to {5}",
                RaisedDateTime.ToString(),
                RaisedBySignal.SignalDirection == SignalDirectionEnum.Input ? "Input" : "Output",
                RaisedBySignal.Join.ToString(),
                RaisedBySignal.Name,
                ChangeType == SignalChangeType.Manual ? "manually set" : "",
                RaisedBySignal.SignalType == SignalTypeEnum.Digital ? ((bool)LoggedData ? "ON" : "OFF") : LoggedData.ToString()));
        }

        public SignalLogItem(Signal raisedSignal, SignalChangeType changeType, object data):base()
        {
            RaisedBySignal = raisedSignal;
            ChangeType = changeType;
            LoggedData = data;            
        }

    }

    public class PluginLogItem:LogItem
    {
        public string Text { get; }

        public PluginLogItem(string text):base()
        {
            Text = text;
        }

        public override string ToLongLogString()
        {
            return String.Format("{0} {1}", RaisedDateTime.ToString(), Text);
        }
    }

}
