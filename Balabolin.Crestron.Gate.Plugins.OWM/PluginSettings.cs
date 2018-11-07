using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balabolin.Crestron.Gate.Plugins.OWM
{
    [Serializable]
    public class OWMSettings
    {
        [Browsable(true)]
        [Description("OpenWeatherMap API key")]
        [DisplayName("API key")]
        [Category("OWM")]
        public string APIKey { get; set; }

        [Browsable(true)]
        [Description("City name")]
        [DisplayName("City")]
        [Category("OWM")]
        public string City { get; set; }
    }

}
