using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Xml.Serialization;

namespace Balabolin.Crestron.Gates.BroadlinkGate
{
    [Serializable]
    public class BlasterInfo
    {
        public string Name { get; set; }
        public string IP{ get; set; }

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

        [Browsable(true)]
        [Description("IP адрес контроллера Crestron (xxx.xxx.xxx.xxx)")]
        [DisplayName("Crestron IP")]
        [Category("Crestron")]
        public string CrestronIP { get; set; }

        [Browsable(true)]
        [Description("Идентификатор e-Control")]
        [DisplayName("PID")]
        [Category("Crestron")]
        public string CrestronPID { get; set; }

        private List<BlasterInfo> privBlasters = new List<BlasterInfo>();

        [Browsable(true)]
        [Description("IR бластеры Broadlink")]
        [DisplayName("Blasters")]
        [Category("Broadlink")]
        [TypeConverter(typeof(CollectionTypeConverter))]
        public List<BlasterInfo> Blasters { get { return privBlasters; } set { privBlasters = value; } }
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
