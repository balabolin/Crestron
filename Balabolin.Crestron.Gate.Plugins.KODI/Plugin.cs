using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Balabolin.Crestron.Gate;
using Balabolin.Utils;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace Balabolin.Crestron.Gate.Plugins.KODI
{
    enum KODIApi
    {
        Player_GetActivePlayers = 2,
        Player_GetItem,
        AudioLibrary_GetSongDetails,
        VideoLibrary_GetMovieDetails,
        Input_ExecuteAction,
        Player_PlayPause,
        Player_GetProperties,
        Player_Stop
    }

    enum PlayerState
    {
        Stopped,
        Played,
        Paused,
        Unknown
    }
    public class Plugin : IPlugin
    {
        #region Interface

        public string Name
        {
            get
            {
                return "KODI Remote";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }

        public Bitmap Logo
        {
            get
            {
                return Resource1.KodiLogo;
            }
        }

        public List<string> InDigitals { get; }
        public List<string> InAnalogs { get; }
        public List<string> InSerials { get; }

        public List<string> OutDigitals { get; }
        public List<string> OutAnalogs { get; }
        public List<string> OutSerials { get; }


        public event DigitalEventHandler OnDigital;
        public event AnalogueEventHandler OnAnalog;
        public event SerialEventHandler OnSerial;
        public event EventHandler<StringEventArgs> OnDebugEvent;

        public void ProcessAnaloglEvent(int iJoin, int Data)
        {
            throw new NotImplementedException();
        }

        public void ProcessDigitalEvent(int iJoin, bool Data)
        {
            if (Data)
            {
                switch (iJoin)
                {
                    case 1:
                        SendKeyCMD("up");
                        break;
                    case 2:
                        SendKeyCMD("down");
                        break;
                    case 3:
                        SendKeyCMD("left");
                        break;
                    case 4:
                        SendKeyCMD("right");
                        break;
                    case 5:
                        SendKeyCMD("select");
                        break;
                    case 6:
                        SendKeyCMD("back");
                        break;
                    case 7:
                        PlayPause();
                        break;
                    case 8:
                        KodiNext();
                        break;
                    case 9:
                        KodiPrev();
                        break;
                    case 10:
                        KodiStop();
                        break;
                }
            }
        }

        public void ProcessSerialEvent(int iJoin, string Data)
        {
            throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {
            string oldUrl = Settings.ToString();
            PluginForm pf = new PluginForm();
            pf.plugin = this;
            pf.ShowDialog();
            SaveSettings();
            if (oldUrl != Settings.ToString()) ConnectToKodi();
        }
        public void Start()
        {
            ConnectToKodi();
        }

        public void Stop()
        {
            DisconnectFromKodi();
        }

        #endregion

        #region Settings

        public KodiSettings Settings;

        private void LoadSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(KodiSettings));
            try
            {
                using (FileStream fs = new FileStream("Balabolin.Crestron.Gate.Plugins.KODI.xml", FileMode.OpenOrCreate))
                {
                    Settings = (KodiSettings)formatter.Deserialize(fs);
                    if (Settings == null)
                        Settings = new KodiSettings();
                }
            }
            catch
            {
                Settings = new KodiSettings();
            }
        }

        private void SaveSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(KodiSettings));
            using (FileStream fs = new FileStream("Balabolin.Crestron.Gate.Plugins.KODI.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Settings);
            }
        }


        #endregion
        
        #region Logging
        private void WLog(string str, params object[] list)
        {
            OnDebugEvent?.Invoke(this, new StringEventArgs(String.Format(str, list)));
        }


        #endregion

        #region KODI System
        private WebSocket kodi;
        private long CurrentPlayerID = -2;
        private PlayerState CurrentState = PlayerState.Unknown;

        private string MakeTime(JObject time)
        {
            string res = "";
            if (time["hours"].Value<string>() != "0")
                res = time["hours"].Value<string>() + ":";
            if (time["minutes"].Value<int>() < 10)
                res = res + "0";
            res = res + time["minutes"].Value<string>() + ":";
            if (time["seconds"].Value<int>() < 10)
                res = res + "0";
            res = res + time["seconds"].Value<string>();
            return res;
        }

        private void ConnectToKodi()
        {
            if (kodi?.ReadyState != WebSocketState.Closed) DisconnectFromKodi();
            kodi = new WebSocket(Settings.ToString());
            kodi.OnMessage += Kodi_OnMessage;
            kodi.OnOpen += Kodi_OnOpen;
            kodi.OnClose += Kodi_OnClose;
            kodi.OnError += Kodi_OnError;
            kodi.Connect();
        }

        private void DisconnectFromKodi()
        {
            if (kodi != null)
            {
                kodi.OnOpen -= Kodi_OnOpen;
                kodi.OnClose -= Kodi_OnClose;
                kodi.OnError -= Kodi_OnError;
                kodi.Close();
            }
        }

        private void SendJSON(KODIApi cmd, params object[] content)
        {
            string method = "";
            switch (cmd)
            {
                case KODIApi.Player_GetActivePlayers:
                    method = "Player.GetActivePlayers";
                    break;
                case KODIApi.Player_GetItem:
                    method = "Player.GetItem";
                    break;
                case KODIApi.AudioLibrary_GetSongDetails:
                    method = "AudioLibrary.GetSongDetails";
                    break;
                case KODIApi.Input_ExecuteAction:
                    method = "Input.ExecuteAction";
                    break;
                case KODIApi.VideoLibrary_GetMovieDetails:
                    method = "VideoLibrary.GetMovieDetails";
                    break;
                case KODIApi.Player_PlayPause:
                    method = "Player.PlayPause";
                    break;
                case KODIApi.Player_GetProperties:
                    method = "Player.GetProperties";
                    break;
                case KODIApi.Player_Stop:
                    method = "Player.Stop";
                    break;
            }
            JObject jCmd;
            if (content.Length > 0)
                jCmd = new JObject(new JProperty("jsonrpc", "2.0"), new JProperty("method", method), new JProperty("params", new JObject(content)), new JProperty("id", cmd));
            else
                jCmd = new JObject(new JProperty("jsonrpc", "2.0"), new JProperty("method", method), new JProperty("id", cmd));
            kodi?.Send(jCmd.ToString());
        }


        #endregion

        #region KODI event handlers
        private void Kodi_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            WLog("WebSocket error: {0}", e.Message);
        }

        private void Kodi_OnClose(object sender, CloseEventArgs e)
        {
            OnDigital?.Invoke(1, false);
            WLog("KODI disconnected from {0}", kodi.Url.ToString());
        }

        private void Kodi_OnOpen(object sender, EventArgs e)
        {
            GetActivePlayers();
            OnDigital?.Invoke(1, true);
            WLog("KODI connected to {0}", kodi.Url.ToString());
        }

        private void Kodi_OnMessage(object sender, MessageEventArgs e)
        {
            var jq = JObject.Parse(e.Data);
            //WLog("{0}", jq.ToString());
            string method = jq["method"]?.Value<string>();
            var result = jq["result"];
            if (result != null)
            {
                long id = (long)jq.Property("id").Value;
                KODIApi qid = (KODIApi)id;
                switch (qid)
                {
                    case KODIApi.Player_GetActivePlayers:
                        var players = result.Value<JArray>();
                        if (players.Count > 0)
                        {
                            var first = players[0].Value<JObject>();
                            var pid = first["playerid"].Value<long>();
                            SetCurrentPlayer(pid);
                        }
                        else SetCurrentPlayer(-1);
                        break;
                    case KODIApi.Player_GetItem:
                        var jRes = result.SelectToken("item").Value<JObject>();
                        SetMediaInfo(jRes);
                        break;
                    case KODIApi.AudioLibrary_GetSongDetails:
                        var jSong = result.SelectToken("songdetails").Value<JObject>();
                        SetSongInfo(jSong);
                        break;
                    case KODIApi.Input_ExecuteAction:
                        break;
                    case KODIApi.VideoLibrary_GetMovieDetails:
                        var jMovie = result.SelectToken("moviedetails").Value<JObject>();
                        SetMovieInfo(jMovie);
                        break;
                    case KODIApi.Player_PlayPause:
                        break;
                    case KODIApi.Player_GetProperties:
                        SetPlayerProps(result);
                        break;
                }
            }
            else
            {
                if (method == "Player.OnPlay")
                {
                    //GetActivePlayers();
                    long pid = jq["params"]["data"]["player"]["playerid"].Value<long>();
                    SetCurrentPlayer(pid);
                    var notifyData = jq["params"]["data"]["item"].Value<JObject>();
                    SetMediaInfo(notifyData);
                }
                else if (method == "Player.OnPause")
                {
                    SetPlayerState(PlayerState.Paused);
                    long pid = jq["params"]["data"]["player"]["playerid"].Value<long>();
                    SetCurrentPlayer(pid);
                    var notifyData = jq["params"]["data"]["item"].Value<JObject>();
                    SetMediaInfo(notifyData);
                }
                else if (method == "Player.OnResume")
                {
                    SetPlayerState(PlayerState.Played);
                    long pid = jq["params"]["data"]["player"]["playerid"].Value<long>();
                    SetCurrentPlayer(pid);
                    var notifyData = jq["params"]["data"]["item"].Value<JObject>();
                    SetMediaInfo(notifyData);
                }
                else if (method == "Player.OnStop")
                {
                    SetCurrentPlayer(-1);
                }
            }
        }


        #endregion

        #region KODI API Commands

        private void SendKeyCMD(string Key)
        {
            SendJSON(KODIApi.Input_ExecuteAction, new JProperty("action", Key));
        }

        private void PlayPause()
        {
            if (CurrentPlayerID != -1)
                SendJSON(KODIApi.Player_PlayPause, new JProperty("playerid", CurrentPlayerID));
        }

        private void GetActivePlayers()
        {
            SendJSON(KODIApi.Player_GetActivePlayers);
        }
        private void GetPlayerDetails()
        {
            if (CurrentPlayerID != -1)
                SendJSON(KODIApi.Player_GetProperties, new JProperty("playerid", CurrentPlayerID), new JProperty("properties", new JArray("speed", "percentage", "time", "totaltime", "type")));
        }

        private void GetPlayerItem()
        {
            if (CurrentPlayerID != -1)
                SendJSON(KODIApi.Player_GetItem, new JProperty("playerid", CurrentPlayerID));
        }

        private void GetSongDetails(long id)
        {
            SendJSON(KODIApi.AudioLibrary_GetSongDetails, new JProperty("songid", id), new JProperty("properties", new JArray("title", "artist", "album", "year", "file")));
        }

        private void GetMovieDetails(long id)
        {
            SendJSON(KODIApi.VideoLibrary_GetMovieDetails, new JProperty("movieid", id), new JProperty("properties", new JArray("title", "year", "genre", "file")));
        }

        private void KodiStop()
        {
            if (CurrentPlayerID!=-1)
                SendJSON(KODIApi.Player_Stop,new JProperty("playerid",CurrentPlayerID));
        }

        private void KodiPrev()
        {
            SendKeyCMD("skipprevious");
        }

        private void KodiNext()
        {
            SendKeyCMD("skipnext");
        }

        #endregion

        #region KODI Logic

        private void SetPlayerProps(JToken result)
        {
            string t = result["type"].Value<string>();
            if (t == "video") OnAnalog?.Invoke(2, 2);
            else if (t == "audio") OnAnalog?.Invoke(2, 1);
            else if (t == "picture") OnAnalog?.Invoke(2, 4);

            int speed = result["speed"].Value<int>();

            var jTime = result["time"].Value<JObject>();
            var jTotalTime = result["totaltime"].Value<JObject>();

            string time = MakeTime(jTime);
            string totalTime = MakeTime(jTotalTime);

            if (speed == 0)
                SetPlayerState(PlayerState.Paused);
            else
                SetPlayerState(PlayerState.Played);
            float percentage = result["percentage"].Value<float>();

            OnAnalog?.Invoke(3, (ushort)percentage);

            OnSerial?.Invoke(4, time);
            OnSerial?.Invoke(5, totalTime);
        }


        private void ClearOuts()
        {
            OnSerial?.Invoke(1, "");
            OnSerial?.Invoke(2, "");
            OnSerial?.Invoke(3, "");
            OnSerial?.Invoke(4, "");
            OnSerial?.Invoke(5, "");
            OnAnalog?.Invoke(1, 0);
            OnAnalog?.Invoke(2, 0);
            OnAnalog?.Invoke(3, 0);
        }

        private void SetMediaInfo(JObject info)
        {
            if (info!=null)
            {
                var jid = info["id"];             
                if (jid != null)
                {
                    long id = jid.Value<long>();
                    string c_type = info["type"].Value<string>();
                    if (c_type == "song")
                    {
                        GetSongDetails(id);
                    }
                    else if (c_type == "movie")
                    {
                        GetMovieDetails(id);
                    }
                }
                else
                {
                    string j = "";
                    if (info["label"]!=null) j = info["label"].Value<string>();
                    if (info["title"] != null) j = info["title"].Value<string>();
                    OnSerial?.Invoke(1, j);
                    OnSerial?.Invoke(2, "");
                    OnSerial?.Invoke(3, "");
                }
            }
        }


        private void SetSongInfo(JObject jSong)
        {
            if (jSong != null)
            {
                OnSerial?.Invoke(1, jSong["title"].Value<string>());
                if (jSong["artist"].Value<JArray>().Count > 0)
                    OnSerial?.Invoke(2, jSong["artist"].Value<JArray>()[0].Value<string>());
                else
                    OnSerial?.Invoke(2, "");
                OnSerial?.Invoke(3, jSong["album"].Value<string>());
            }
        }

        private void SetMovieInfo(JObject jMovie)
        {
            if (jMovie != null)
            {
                OnSerial?.Invoke(1, jMovie["title"].Value<string>());
                OnSerial?.Invoke(2, jMovie["year"].Value<string>());
                string genres = "";
                foreach (string genre in jMovie["genre"].Value<JArray>() )
                {
                    if (genres != "") genres = genres + ", ";
                    genres = genres + genre;
                }
                OnSerial?.Invoke(3, genres);
            }
        }



        private void SetCurrentPlayer(long player_id)
        {
            if (CurrentPlayerID != player_id)
            {
                CurrentPlayerID = player_id;
                if (CurrentPlayerID != -1)
                {
                    GetPlayerDetails();
                    GetPlayerItem();
                }
                else
                {
                    SetPlayerState(PlayerState.Stopped);
                }
            }
        }

        private void SetPlayerState(PlayerState state)
        {
            if (CurrentState != state)
            {
                CurrentState = state;
                OnAnalog?.Invoke(1, (ushort)state);
                OnDigital?.Invoke(2, (state != PlayerState.Stopped));
                if (state == PlayerState.Played)
                    StartPlayTimer();
                else
                    StopPlayTimer();
                if (state == PlayerState.Stopped) ClearOuts();
            }
        }

        #endregion

        #region Playing timer
        private System.Threading.Timer timer;
        private System.Threading.AutoResetEvent timerEvent = new System.Threading.AutoResetEvent(false)s;

        private void StartPlayTimer()
        {
            timer = new System.Threading.Timer(OnPlayTimer, timerEvent, 0, 1000);
        }
        private void StopPlayTimer()
        {
            timer?.Dispose();
        }

        private void OnPlayTimer(Object stateInfo)
        {
            GetPlayerDetails();
        }

        #endregion
        public Plugin()
        {
            InDigitals = new List<string>();
            InAnalogs = new List<string>();
            InSerials = new List<string>();

            OutDigitals = new List<string>();
            OutAnalogs = new List<string>();
            OutSerials = new List<string>();

            InDigitals.Add("Up");                       //1
            InDigitals.Add("Down");                     //2
            InDigitals.Add("Left");                     //3
            InDigitals.Add("Right");                    //4
            InDigitals.Add("Enter");                    //5
            InDigitals.Add("Back");                     //6

            InDigitals.Add("PlayPause");                //7
            InDigitals.Add("Next");                     //8
            InDigitals.Add("Prev");                     //9
            InDigitals.Add("Stop");                     //10

            OutDigitals.Add("Online");                  //1
            OutDigitals.Add("Playing");                 //2

            OutAnalogs.Add("Play status");              //1
            OutAnalogs.Add("Content type");             //2
            OutAnalogs.Add("Position, %");              //3


            OutSerials.Add("Title");                    //1
            OutSerials.Add("Artist");                   //2
            OutSerials.Add("Album");                    //3
            OutSerials.Add("Played time");              //4
            OutSerials.Add("Total time");               //5
            LoadSettings();

        }
    }
}
