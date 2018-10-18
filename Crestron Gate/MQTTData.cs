using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crestron_Gate
{
    [Serializable]
    public class JoinToMQTT
    {
        public string TopicIn { get; set; }
        public string TopicOut { get; set; }
        [XmlIgnore]
        public string LastIn { get; set; }
        [XmlIgnore]
        public string LastOut { get; set; }
    }
}
