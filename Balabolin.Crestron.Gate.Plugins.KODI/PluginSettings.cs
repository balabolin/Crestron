using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balabolin.Crestron.Gate.Plugins.KODI
{
    [Serializable]
    public class KodiSettings
    {
        [Browsable(true)]
        [Description("KODI Instance Address")]
        [DisplayName("IP Address")]
        [Category("KODI")]
        public string IP { get; set; }

        [Browsable(true)]
        [Description("WebSockets Port")]
        [DisplayName("Port")]
        [Category("KODI")]
        public string Port { get; set; }

        [Browsable(true)]
        [Description("User name")]
        [DisplayName("User name")]
        [Category("KODI")]
        public string UserName{ get; set; }

        [Browsable(true)]
        [Description("Password")]
        [DisplayName("Password")]
        [Category("KODI")]
        public string Password { get; set; }

        [Browsable(false)]
        public new string ToString()
        {
            return ("ws://" + IP + ":" + Port + "/jsonrpc");
        }
    }

}
