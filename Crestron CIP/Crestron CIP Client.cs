
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

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
        public delegate void BasicHandler();
        public delegate void DigitalEventHandler(ushort usJoin, bool bValue);
        public delegate void AnalogueEventHandler(ushort usJoin, ushort usValue);
        public delegate void SerialEventHandler(ushort usJoin, string sValue);

        public event BasicHandler OnDisconnect;
        public event DigitalEventHandler OnDigital;
        public event AnalogueEventHandler OnAnalogue;
        public event SerialEventHandler OnSerial;

        public event EventHandler<StringEventArgs> Debug;
        #endregion

        #region Base methods
        public CIPClient(string sIP, byte bPID)
        {
            PID = bPID;
            IP = sIP;
        }

        private Task ts = null;

        public bool Connected
        {
            get
            {
                return (client == null) ? false : client.Connected; 
            }
        }

        private Cancellation​Token​Source tokenSource = new CancellationTokenSource();
        private CancellationToken cancelToken;

        public async void ConnectToServer()
        {
            OnDebug(eDebugEventType.Info, "Try to connect...");
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(IP, PORT_CIP);
                nstream = client.GetStream();
                cancelToken = tokenSource.Token;
                ts = Task.Run(BeginRead,cancelToken);                
                OnDebug(eDebugEventType.Info, "connect succesfull");
            }
            catch(Exception e)
            {
                FreeResources();
                OnDebug(eDebugEventType.Error, "Failed to connect ({0})", e.ToString());
            }
        }
        private void FreeResources()
        {
            StopHeartBeatTimer();
            tokenSource.Cancel();
            //ts?.Dispose();
            nstream?.Dispose();
            client?.Close();
        }
        private void DisconnectFromServer()
        {
            FreeResources();
            OnDebug(eDebugEventType.Warn, "Disconnected from server");
            OnDisconnect?.Invoke();
        }

        #endregion

        #region Transmit joins
        public void UpdateRequest()
        {
            Send("\x05\x00\x05\x00\x00\x02\x03\00");
        }


        public void SendDigital(ushort usJoin,bool bVal)
        {
            ushort NewIdx = (ushort)StringHelper.SetBit(usJoin - 1, 15, !bVal);
            byte[] b = { (byte)(NewIdx % 0x100), (byte)(NewIdx / 0x100) };
            string str = "\x05\x00\x06\x00\x00\x03\x00" + StringHelper.GetString(b);
            Send(str);
        }

        public void SendAnalogue(ushort usJoin, ushort val)
        {
            byte idxLowByte = (byte)((usJoin - 1) % 0x100);
            byte idxHighByte = (byte)((usJoin - 1) / 0x100);
            byte LevelLowByte = (byte)(val % 0x100);
            byte LevelHighByte = (byte)(val / 0x100);
            byte[] b = { idxHighByte, idxLowByte, LevelHighByte, LevelLowByte };
            string s = StringHelper.GetString(b);
            string str = "\x05\x00\x08\x00\x00\x05\x14" + s;
            Send(str);
        }

        public void SendSerial(ushort usJoin,string sVal)
        {
            ushort NewIdx = (ushort)(usJoin - 1);
            byte[] baPart = { (byte)(sVal.Length+2), 0x12, (byte)NewIdx };

            string sPayload = "\x00\x00" + StringHelper.GetString(baPart) + sVal;

            byte[] baLen = { (byte)(sPayload.Length) };
            string str = "\x05\x00" + StringHelper.GetString(baLen)+sPayload;

            Send(str);
        }
        #endregion

        #region Read/write methods

        private void Send(byte[] baData)
        {
            try
            {
                nstream.Write(baData, 0, baData.Length);
            }
            catch (Exception e)
            {
                OnDebug(eDebugEventType.Error, "Send error {0}", e.ToString());
                DisconnectFromServer();
            }
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
                OnDebug(eDebugEventType.Info,"Begin read error: {0}", e.ToString());
                DisconnectFromServer();
            }
        }

        async Task<byte[]> ReadFromStreamAsync(NetworkStream s, int nbytes)
        {
            try
            {
                var buf = new byte[nbytes];
                var readpos = 0;
                while (readpos < nbytes)
                    readpos += await s.ReadAsync(buf, readpos, nbytes - readpos);
                return buf;
            }
            catch (Exception e)
            {
                OnDebug(eDebugEventType.Info, "ReadFromStreamAsync error: {0}", e.ToString());
                DisconnectFromServer();
                return null;
            }
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
            OnDigital?.Invoke(idx, val);
        }

        private void AnalogEvent(byte[] baPayload)
        {
            byte bType = baPayload[2];
            ushort idx = 0;
            ushort val = 0;
            bool bReceived = true;
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
                    bReceived = false;
                    OnDebug(eDebugEventType.Info, "Unknown analogue data type {0}", bType.ToString());
                    break;
            }
            if (bReceived) OnAnalogue?.Invoke(idx, val);
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
            OnSerial?.Invoke(idx, val);
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
            timer?.Dispose();
        }

        #endregion

        #region Debug
        public void OnDebug(eDebugEventType eventType, string str, params object[] list)
        {
            Debug?.Invoke(this, new StringEventArgs(String.Format(str, list)));
            //parent.Invoke(parent.Debug, new Object[] { str });
        }
        #endregion
    }
}
