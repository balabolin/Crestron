using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balabolin.Crestron
{
    public class CIPClient
    {
        private WatsonTcp.WatsonTcpClient client;

        const int PORT_CIP = 41794;
        private byte PID;
        private string IP;
        public event EventHandler<StringEventArgs> Debug;

        public CIPClient(string sIP, byte bPID)
        {
            PID = bPID;
            IP = sIP;
            client = new WatsonTcp.WatsonTcpClient(IP, PORT_CIP, ServerConnected,ServerDisconnected,OnReceive,false);
            OnDebug(eDebugEventType.Info, "CIP Client created");
        }

        private bool ServerConnected()
        {
            OnDebug(eDebugEventType.Info, "Connected to server {1}:{2}", IP,PID.ToString());
            return true;
        }

        private bool ServerDisconnected()
        {
            OnDebug(eDebugEventType.Info, "Disconnected from server");
            return true;
        }

        bool OnReceive(byte[] baMessage)
        {
            if (baMessage.Length >= 3)
            {
                byte bCMD = baMessage[0];
                int iLen = (baMessage[1] << 8) + baMessage[2];
                string sPayload = Encoding.ASCII.GetString(baMessage, 3, baMessage.Length - 3);
                ProcessCIPCommand(bCMD, iLen, sPayload);
            }
            return true;
        }

        private void ProcessCIPCommand(byte bCMD, int iLen, string sPayload)
        {
            switch (bCMD)
            {
                case 0x0F:
                    {
                        // Processor response
                        if ((iLen == 1) & (sPayload == "\x02"))
                        {
                            SendReponse();
                        };

                        break;
                    };

            }

        }

        private void SendReponse()
        {
            byte[] bb = new byte[1];
            OnDebug(eDebugEventType.Info, "Send response");
            bb[0] = PID;
            string sMsg = "\x01\x00\x07\x7F\x00\x00\x01\x00" + StringHelper.GetString(bb) + "\x40";
            client.Send(Encoding.ASCII.GetBytes(sMsg);
        }

        public void OnDebug(eDebugEventType eventType, string str, params object[] list)
        {
            if (Debug != null)
                Debug(this, new StringEventArgs(String.Format(str, list)));
            //parent.Invoke(parent.Debug, new Object[] { str });
        }
    }
}
