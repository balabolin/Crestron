using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balabolin.Crestron.Gate.Plugins
{
    #region Enums
    public enum SignalTypeEnum
    {
        Analog,
        Digital,
        Serial
    }

    public enum SignalDirectionEnum
    {
        Input,
        Output
    }

    public enum SignalChangeType
    {
        System,
        Manual
    }
    #endregion

    public delegate void ChangeHandler(Signal sig, bool toLog);

    public class Signal
    {
        #region members
        private object data;
        public ushort Join { get; set; }
        public string Name { get; set; }

        private ListViewItem linkedListViewItem;

        public SignalTypeEnum SignalType { get; set; }
        public SignalDirectionEnum SignalDirection { get; set; }
        public Plugin Plug { get; set; }
        public List<SignalLogItem> Log { get; }

        #endregion

        #region Events
        public event ChangeHandler OnDataChange;

        #endregion
        private void ProcessDataChange()
        {
            switch (SignalType)
            {
                case SignalTypeEnum.Analog:
                    if (SignalDirection == SignalDirectionEnum.Input)
                        Plug.ProcessAnaloglEvent(Join, (int)Data);
                    else
                        Plug.Crestron?.SendAnalogue(Join, (ushort)Data);
                    break;
                case SignalTypeEnum.Digital:
                    if (SignalDirection == SignalDirectionEnum.Input)
                        Plug.ProcessDigitalEvent(Join, (bool)Data);
                    else
                        Plug.Crestron?.SendDigital(Join, (bool)Data);
                    break;
                case SignalTypeEnum.Serial:
                    if (SignalDirection == SignalDirectionEnum.Input)
                        Plug.ProcessSerialEvent(Join, Data.ToString());
                    else
                        Plug.Crestron?.SendSerial(Join, Data.ToString());
                    break;
            }
        }
        private void SetData(object value, SignalChangeType changeType)
        {
            data = value;
            if (Data != null)
            {
                SignalLogItem logItem = new SignalLogItem(this, changeType, Data);
                Log.Add(logItem);
                if (Log.Count > 1000)
                {
                    Log.RemoveAt(0);
                }
                ProcessDataChange();
                OnDataChange?.Invoke(this, true);
            }
        }
        public object Data
        {
            get
            {
                return data;
            }
        }


        public void ManualSetData(object value)
        {
            SetData(value, SignalChangeType.Manual);
        }

        public void SystemSetData(object value)
        {
            SetData(value, SignalChangeType.System);
        }

        public ListViewItem LinkedListViewItem
        {
            get
            {
                return linkedListViewItem;
            }
            set
            {
                linkedListViewItem = value;
            }
        }


        public Signal(Plugin plug, ushort join, string name, SignalTypeEnum signalType, SignalDirectionEnum signalDirection)
        {
            Plug = plug;
            Join = join;
            Name = name;
            SignalType = signalType;
            SignalDirection = signalDirection;
            Log = new List<SignalLogItem>();
        }
    }
}
