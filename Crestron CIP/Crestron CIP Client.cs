
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

        #region Base methods
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

        #endregion

        #region Read/write methods

        private void Send(byte[] baData)
        {
            nstream.Write(baData, 0, baData.Length);
        }

        private void Send(string sMsg)
        {
            Send(Encoding.ASCII.GetBytes(sMsg));
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

        #endregion

        private void ProcessCIPCommand(byte bCMD, int iLen, string sPayload)
        {
            switch (bCMD)
            {
                case 0x02:
                    if (iLen == 4)
                    {
                        // IP ID registry Success
                        RegisterSuccess();
                    }
                    break;
           
                case 0x05:
                    // Data
                    byte[] bbbb = Encoding.ASCII.GetBytes(sPayload);
                    byte bDataType = bbbb[3];
                    ProcessDataEvent(bDataType, sPayload);
                    break;
                case 0x0D:
                    // Heartbeat timeout
                    SendHeartBeat();
                    break;

                case 0x0E:
                    // Heartbeat received
                    HeartbeatReceived();
                    break;

                case 0x0F:
                    // Processor response
                    if ((iLen == 1) & (sPayload == "\x02"))
                    {
                        SendConnectReponse();
                    }
                    else UnknownCMD(bCMD, iLen, sPayload);
                    break;

                default:
                    UnknownCMD(bCMD, iLen, sPayload);
                    break;
            }

        }

        private void ProcessDataEvent(byte bDataType, string sPayload)
        {
            OnDebug(eDebugEventType.Info, "Data event {0}", bDataType.ToString());
            switch (bDataType)
            {
                case 0x00:
                    break;
            }
        }

        private void UnknownCMD(byte bCMD, int iLen, string sPayload)
        {
            OnDebug(eDebugEventType.Warn, "Unknown cmd: {0}, Payload ({1}): {2}", bCMD.ToString(),iLen.ToString(), sPayload);
        }

        private void RegisterSuccess()
        {
            OnDebug(eDebugEventType.Info, "Register success");
            StartHeartBeatTimer();
        }

        private void HeartbeatReceived()
        {
            OnDebug(eDebugEventType.Info, "Ping ok");
        }



        private void SendConnectReponse()
        {
            byte[] bb = new byte[1];
            OnDebug(eDebugEventType.Info, "Send response");
            bb[0] = PID;
            string sMsg = "\x01\x00\x07\x7F\x00\x00\x01\x00" + StringHelper.GetString(bb) + "\x40";
            Send(sMsg);
        }

        private void SendHeartBeat()
        {
            OnDebug(eDebugEventType.Info, "Send ping");
            Send("\x0d\x00\x02\x00\x00");
        }

        #region Heartbeat timer

        private void OnTHeartimer(Object stateInfo)
        {
            SendHeartBeat();
        }

        private System.Threading.Timer timer;
        private System.Threading.AutoResetEvent timerEvent = new System.Threading.AutoResetEvent(false);
        private void StartHeartBeatTimer()
        {
            timer = new System.Threading.Timer(OnTHeartimer, timerEvent, 0, 5000);
        }
        private void StopHeartBeatTimer()
        {
            timer.Dispose();
        }

        #endregion


        public void OnDebug(eDebugEventType eventType, string str, params object[] list)
        {
            if (Debug != null)
                Debug(this, new StringEventArgs(String.Format(str, list)));
            //parent.Invoke(parent.Debug, new Object[] { str });
        }
    }
}
