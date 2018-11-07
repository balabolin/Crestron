using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balabolin.Crestron.Gate.Plugins.Broadlink
{
    public enum IRCodeType
    {
        RAW = 0,
        PRONTO = 1,
    }

    [Serializable]
    public class IRCode
    {
        public string Name { get; set; }
        public IRCodeType CodeType { get; set; }
        public string Command { get; set; }
        public string Blaster { get; set; }
    }
}
