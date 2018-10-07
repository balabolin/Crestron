using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crestron_Gate
{
    public  class GateSettings: ApplicationSettingsBase
    {
        [Browsable(true)]
        [Description("IP адрес контроллера Crestron (xxx.xxx.xxx.xxx)")]
        [DisplayName("Crestron IP")]
        [Category("Crestron")]
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("192.168.100.100")]
        public string CrestronIP
        {
            get { return (String)this["CrestronIP"]; }
            set { this["CrestronIP"] = value; }
        }

        [Browsable(true)]
        [Description("Идентификатор e-Control")]
        [DisplayName("PID")]
        [Category("Crestron")]
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0x12")]
        public string CrestronPID
        {
            get { return (String)this["CrestronPID"]; }
            set { this["CrestronPID"] = value; }
        }


    }
}
