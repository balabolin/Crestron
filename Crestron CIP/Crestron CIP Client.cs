
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Balabolin.Crestron
{
    public class CIPClient
    {
        #region Declarations
        private TcpClient client;
        private NetworkStream nstream;

        const int PORT_CIP = 41794;
        private byte PID;
        private string IP;
        #endregion

        #region Events
        public event EventHandler<StringEventArgs> Debug;
        #endregion

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

        private void DisconnectFromServer()
        {

        }

        #endregion

        #region Read/write methods

        private void Send(byte[] baData)
        {
            nstream.Write(baData, 0, baData.Length);
        }

        private void Send(string sMsg)
        {
            Send(StringHelper.GetBytes(sMsg));
        }


        async Task BeginRead()
        {
            try
            {


                while (true)
                {
                    byte[] baBuf = await ReadFromStreamAsync(nstream, 3);
                    byte bCMD = baBuf[0];
                    int iLen = (baBuf[1] << 8) + baBuf[2];
                    byte[] baPayload = await ReadFromStreamAsync(nstream, iLen);
                    string sPayload = StringHelper.GetString(baPayload);
                    ProcessCIPCommand(bCMD, iLen, sPayload);
                }
            }
            catch (Exception e)
            {
                OnDebug(eDebugEventType.Info, e.ToString());
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

        #region Packet processing

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
                    byte[] baPayload = StringHelper.GetBytes(sPayload);
                    byte bDataType = baPayload[3];
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
            byte[] baPayload = StringHelper.GetBytes(sPayload);
            switch (bDataType)
            {
                case 0x00:
                    // Digitall
                    DigitalEvent(baPayload);
                    break;
                case 0x01:
                    // Analog
                    AnalogEvent(baPayload);
                    break;
                case 0x02:
                    // Serial
                    SerialEvent(baPayload);
                    break;
                case 0x38:
                    // Smart graph
                    break;
                default:
                    OnDebug(eDebugEventType.Info, "Unknown data type {0}", bDataType.ToString());
                    break;
            }
        }
        private void UnknownCMD(byte bCMD, int iLen, string sPayload)
        {
            OnDebug(eDebugEventType.Warn, "Unknown cmd: {0}, Payload ({1}): {2}", bCMD.ToString(), iLen.ToString(), sPayload);
        }

        #endregion

        #region System events
        private void RegisterSuccess()
        {
            OnDebug(eDebugEventType.Info, "Register success");
            StartHeartBeatTimer();
        }

        private void HeartbeatReceived()
        {
            //OnDebug(eDebugEventType.Info, "Ping ok");
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
            //OnDebug(eDebugEventType.Info, "Send ping");
            Send("\x0d\x00\x02\x00\x00");
        }

        #endregion

        #region Incoming Join Events
        private void DigitalEvent(byte[] baPayload)
        {
            ushort idx = (ushort)((baPayload[5] & 0x7F) * 0x100 + baPayload[4] + 1);
            bool val = !StringHelper.GetBit(baPayload[5], 7);
            OnDebug(eDebugEventType.Info, "Digital event on join={0}  to {1}", idx.ToString(), val.ToString());
        }

        private void AnalogEvent(byte[] baPayload)
        {
            byte bType = baPayload[2];
            ushort idx = 0;
            ushort val = 0;
            switch (bType)
            {
                case 4:
                    idx = (ushort)(baPayload[4] + 1);
                    val = (ushort)((baPayload[5]*0x100) + baPayload[6]);
                    break;
                case 5:
                    idx = (ushort)(baPayload[4] * 0x100 + baPayload[5] + 1);
                    val = (ushort)(baPayload[6] * 0x100 + baPayload[7]);
                    break;
                default:
                    OnDebug(eDebugEventType.Info, "Unknown analogue data type {0}", bType.ToString());
                    break;
            }
            OnDebug(eDebugEventType.Info, "Analog event on join={0}  to {1}", idx.ToString(), val.ToString());
        }

        private void SerialEvent(byte[] baPayload)
        {
            //byte bType = baPayload[0];
            string sPayload = StringHelper.GetString(baPayload);
            int iStartIndex = sPayload.IndexOf("#"); //4
            int iEndIndex = sPayload.IndexOf(","); //6
            string sJoin = sPayload.Substring(iStartIndex+1, iEndIndex - iStartIndex-1); //4,1 - 3
            ushort idx = Convert.ToUInt16(sJoin);
            ushort iStartV = (ushort)(iEndIndex + (iEndIndex - iStartIndex) + 3); //11
            ushort ilen = (ushort)(baPayload.Length-iStartV-1);   //1
            string val = sPayload.Substring(iStartV,ilen);
            OnDebug(eDebugEventType.Info, "Serial event on join={0}  to {1}", idx.ToString(), val.ToString());
        }

        #endregion

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

        #region Debug
        public void OnDebug(eDebugEventType eventType, string str, params object[] list)
        {
            if (Debug != null)
                Debug(this, new StringEventArgs(String.Format(str, list)));
            //parent.Invoke(parent.Debug, new Object[] { str });
        }
        #endregion
    }
}
