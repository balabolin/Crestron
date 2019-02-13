using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balabolin.Crestron.Gate.Plugins.KODI
{
    public partial class PluginForm : Form
    {
        public Plugin plugin;

        public PluginForm()
        {
            InitializeComponent();
        }

        private void PluginForm_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = plugin.Settings;
        }
    }
}
