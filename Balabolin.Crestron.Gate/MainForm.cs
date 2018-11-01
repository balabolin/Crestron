using Balabolin.Crestron.Gate.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balabolin.Crestron.Gate
{
    public partial class MainForm : Form
    {
        PluginManager Manager;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manager = new PluginManager(Application.StartupPath + "\\Plugins\\");
            Manager.Rescan();
            lvPlugins.Items.Clear();
            foreach (Plugin plugin in Manager.Plugins)
            {
                var lv = lvPlugins.Items.Add(plugin.Name);
                lv.Tag = plugin;
            }
            lvPlugins.Items[0].Selected = true;
        }

        private void SetActivePlugin(Plugin plugin)
        {
            pbLogo.Image = plugin.Logo;
            lblPluginName.Text = plugin.Name;
            lblPluginVersion.Text = plugin.Version;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lvPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPlugins.SelectedItems.Count > 0)
            {
                SetActivePlugin((Plugin)lvPlugins.SelectedItems[0].Tag);
            }
        }

        private void lvPlugins_ItemActivate(object sender, EventArgs e)
        {
        }
    }
}
