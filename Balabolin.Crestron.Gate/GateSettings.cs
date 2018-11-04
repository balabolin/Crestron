using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Serialization;


namespace Balabolin.Crestron.Gate
{
    [Serializable]
    public class GateSettings
    {
        [Browsable(true)]
        [Description("Crestron IP address (xxx.xxx.xxx.xxx)")]
        [DisplayName("Crestron IP")]
        [Category("Crestron")]
        public string CrestronIP { get; set; }

        [Browsable(true)]
        [Description("Plugins (active and old)")]
        [DisplayName("Plugins")]
        [Category("Plugins")]
        [TypeConverter(typeof(CollectionTypeConverter))]
        public List<PluginSetting> PluginsSettings { get; set; }


        public GateSettings()
        {
            PluginsSettings = new List<PluginSetting>();
        }

        public GateSettings(GateSettings gs)
        {
            CrestronIP = gs.CrestronIP;
            PluginsSettings = new List<PluginSetting>(gs.PluginsSettings);
        }

        public bool SettingsChanged(GateSettings oldGS)
        {
            return (CrestronIP != oldGS.CrestronIP);
        }
    }

    [Serializable]
    public class PluginSetting
    {
        public string Name { get; set; }
        public string PID { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    class CollectionTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            return destType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return "< list... >";
        }
    }


}
