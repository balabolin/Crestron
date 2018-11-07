using SharpBroadlink.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balabolin.Crestron.Gate.Plugins.Broadlink
{
    public partial class PluginForm : Form
    {
        public Plugin plugin { get; set; }
        public PluginForm()
        {
            InitializeComponent();
        }

        private void SetupGrid()
        {
            foreach (IRCode irc in plugin.PluginSettings.IRCodes)
            {
                if (plugin.GetBlasterByName(irc.Blaster) == null)
                {
                    BlasterInfo newBI = new BlasterInfo() { IP = "", Name = irc.Blaster, Online = false };
                    plugin.PluginSettings.Blasters.Add(newBI);
                }
            }
            /*
            IRCodes.AllowNew = true;
            IRCodes.AllowEdit = true;
            IRCodes.AllowRemove = true;
            */
            dgvIRCodes.Columns.Clear();
            dgvIRCodes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn dgvc1 = new DataGridViewTextBoxColumn();
            dgvc1.Name = "Name";
            dgvc1.DataPropertyName = "Name";
            dgvc1.Width = 300;
            dgvIRCodes.Columns.Add(dgvc1);

            Dictionary<IRCodeType, string> dctCodeTypes = new Dictionary<IRCodeType, string>();
            dctCodeTypes.Add(IRCodeType.RAW, "RAW");
            dctCodeTypes.Add(IRCodeType.PRONTO, "Pronto");

            DataGridViewComboBoxColumn dgvc2 = new DataGridViewComboBoxColumn();
            dgvc2.Name = "CodeType";
            dgvc2.DataPropertyName = "CodeType";
            dgvc2.ValueMember = "key";
            dgvc2.DisplayMember = "value";
            dgvc2.Width = 100;
            dgvc2.DataSource = new BindingSource() { DataSource = dctCodeTypes };

            dgvIRCodes.Columns.Add(dgvc2);

            DataGridViewTextBoxColumn dgvc3 = new DataGridViewTextBoxColumn();
            dgvc3.Name = "Command";
            dgvc3.DataPropertyName = "Command";
            dgvc3.Width = 400;
            dgvIRCodes.Columns.Add(dgvc3);

            //Dictionary<BlasterInfo, string> dctBlasters = new Dictionary<BlasterInfo, string>();
            List<string> lib = new List<string>();
            foreach (BlasterInfo bi in plugin.PluginSettings.Blasters)
            {
                lib.Add(bi.ToString());
            }

            DataGridViewComboBoxColumn dgvc4 = new DataGridViewComboBoxColumn();
            dgvc4.Name = "Blaster";
            dgvc4.DataPropertyName = "Blaster";
            dgvc4.Width = 200;
            dgvc4.DataSource = new BindingSource() { DataSource = lib };

            dgvIRCodes.Columns.Add(dgvc4);

            dgvIRCodes.DataSource = plugin.PluginSettings.IRCodes;

            dgvIRCodes.Invalidate();

        }

        private async void StartLearningAsync()
        {
            var irCode = ((IRCode)dgvIRCodes.CurrentRow.DataBoundItem);
            if (irCode != null)
            {
                plugin.LearnIRCodeAsync(irCode);


                dgvIRCodes.Refresh();
            }
        }

        private async void SendIRAsync()
        {
            var irCode = ((IRCode)dgvIRCodes.CurrentRow.DataBoundItem);
            if (irCode != null)
            {
                plugin.SendSignalAsync(irCode);
                dgvIRCodes.Refresh();
            }
        }

        private void PluginForm_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = plugin.PluginSettings;
            SetupGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartLearningAsync();
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            plugin.InitBlasters();
        }

        private void dgvIRCodes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dgvIRCodes.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dgvIRCodes.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
