using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Balabolin.Crestron.Gate.Plugins.Broadlink
{
    [Serializable]
    public class BlasterInfo
    {
        public string Name { get; set; }
        public string IP { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public bool Online { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class BroadlinkGateSettings
    {
        [Browsable(true)]
        [Description("Имя Wi-Fi сети")]
        [DisplayName("SSID")]
        [Category("WiFi")]
        public string SSID { get; set; }

        [Browsable(true)]
        [Description("Пароль Wi-Fi сети")]
        [DisplayName("Passphrase")]
        [Category("WiFi")]
        public string Passphrase { get; set; }

        private List<BlasterInfo> privBlasters = new List<BlasterInfo>();

        private BindingList<IRCode> pIRCodes = new BindingList<IRCode>();

        [Browsable(true)]
        [Description("IR бластеры Broadlink")]
        [DisplayName("Blasters")]
        [Category("Broadlink")]
        [TypeConverter(typeof(CollectionTypeConverter))]
        public List<BlasterInfo> Blasters { get { return privBlasters; } set { privBlasters = value; } }

        public BindingList<IRCode> IRCodes { get { return pIRCodes; } set { pIRCodes = value; } }
    }

    class CollectionTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return "< Список... >";
        }
    }

}
