using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpBroadlink;
using SharpBroadlink.Devices;

namespace Crestron_power_gate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            notifyIcon1.Icon = Resource1.Crestron_disconnected;
            notifyIcon1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Broadlink.Setup("AbahabaMix","olympusmedia261180", Broadlink.WifiSecurityMode.WPA2);
            TestAsync();
        }

        private async Task TestAsync()
        {
            var devices = await Broadlink.Discover(5);
            
            var device = (SharpBroadlink.Devices.Rm)devices.First(d => d.Host.Address.ToString()  == "192.168.100.44");

            await device.Auth();

            //device.

            // Enter Learning mode
            //await device.EnterLearning();

            //var signal = await device.CheckData();

            // Test signal
            var pronto = "0000 006d 0000 0022 00aa 00aa 0015 0040 0015 0015 0015 0040 0015 0015 0015 0015 0015 0015 0015 0015 0015 0015 0015 0040 0015 0015 0015 0040 0015 0015 0015 0015 0015 0015 0015 0015 0015 0015 0015 0040 0015 0015 0015 0040 0015 0015 0015 0040 0015 0015 0015 0040 0015 0015 0015 0015 0015 0040 0015 0015 0015 0040 0015 0015 0015 0040 0015 0015 0015 0040 0015 0737";
            var bytes = Signals.String2ProntoBytes(pronto);

            await device.SendPronto(bytes);
        }
    }
}
