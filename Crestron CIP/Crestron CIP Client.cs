
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Balabolin.Crestron
{
    public class CIPClient
    {
        private TcpClient client;
        private NetworkStream nstream;

        const int PORT_CIP = 41794;
        private byte PID;
        private string IP;
        public event EventHandler<StringEventArgs> Debug;

        public CIPClient(string sIP, byte bPID)
        {
            PID = bPID;
            IP = sIP;
            client = new TcpClient();
        }


        public async void ConnectToServer()
        {
            OnDebug(eDebugEventType.Info, "Try to connect...");
            try
            {
                await client.ConnectAsync(IP, PORT_CIP);
                nstream = client.GetStream();
                Task ts = Task.Run(BeginRead);
                OnDebug(eDebugEventType.Info, "connect succesfull");
            }
            catch(Exception e)
            {
                OnDebug(eDebugEventType.Error, "Failed to connect ({0})", e.ToString());
            }
        }


        private void Send(byte[] baData)
        {
            nstream.Write(baData, 0, baData.Length);
        }

        async Task BeginRead()
        {
            while (true)
            {
                byte[] baBuf = await ReadFromStreamAsync(nstream, 3);
                byte bCMD = baBuf[0];
                int iLen = (baBuf[1] << 8) + baBuf[2];
                byte[] baPayload = await ReadFromStreamAsync(nstream, iLen);
                string sPayload = Encoding.ASCII.GetString(baPayload);
                ProcessCIPCommand(bCMD, iLen, sPayload);
            }
        }

        async Task<byte[]> ReadFromStreamAsync(NetworkStream s, int nbytes)
        {
            var buf = new byte[nbytes];
            var readpos = 0;
            while (readpos < nbytes)
                readpos += await s.ReadAsync(buf, readpos, nbytes - readpos);
            return buf;
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
            Send(Encoding.ASCII.GetBytes(sMsg));
        }

        public void OnDebug(eDebugEventType eventType, string str, params object[] list)
        {
            if (Debug != null)
                Debug(this, new StringEventArgs(String.Format(str, list)));
            //parent.Invoke(parent.Debug, new Object[] { str });
        }
    }
}
