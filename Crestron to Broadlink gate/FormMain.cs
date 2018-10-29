using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using SharpBroadlink;
using SharpBroadlink.Devices;
using Balabolin.Utils;
namespace Balabolin.Crestron.Gates.BroadlinkGate
{
    public partial class FormMain : Form
    {
        BroadlinkGateSettings gs = new BroadlinkGateSettings();
        BindingList<IRCode> IRCodes;
        Dictionary<string, Rm> Blasters = new Dictionary<string, Rm>();

        CIPClient cipClient = null;

        bool realExit = false;

        #region Logging
        private void WLog(string str, params object[] list)
        {
            UpdateMainTextbox(String.Format(str, list));
        }

        void UpdateMainTextbox(string s)
        {
            if (richTextBox1.InvokeRequired)
                richTextBox1.BeginInvoke(new Action<string>(UpdateMainTextbox), new object[] { s });
            else
                richTextBox1.AppendText(s + "\n");
        }

        #endregion

        #region Blaster collection related functions
        private BlasterInfo GetBlasterByIP(string ip)
        {
            try
            {
                return gs.Blasters.First(d => d.IP == ip);
            }
            catch
            {
                return null;
            }            
        }
        private BlasterInfo GetBlasterByName(string name)
        {
            try
            {
                return gs.Blasters.First(d => d.Name == name);
            }
            catch
            {
                return null;
            }
        }

        private Rm GetRMBlasterByName(string name)
        {
            return Blasters[name];
        }

        #endregion

        #region Blaster functions
        private async void InitBlasters()
        {
            WLog("Scanning blasters...");
            Blasters.Clear();
            var devices = await Broadlink.Discover(5);
            WLog("Found: {0} online blasters", devices.Length.ToString());
            foreach(BlasterInfo bi in gs.Blasters)
            {
                bi.Online = false;
            }
            foreach (Rm Discovered in devices)
            {
                var Registered = GetBlasterByIP(Discovered.Host.Address.ToString());
                if (Registered != null)
                {
                    Blasters.Add(Registered.Name, Discovered);
                    WLog("Blaster '{0}' [{1}] online",Registered.Name,Registered.IP);
                } else
                {
                    WLog("Found new blaster [{0}]. Added to collection", Discovered.Host.Address.ToString());
                    BlasterInfo biNew = new BlasterInfo() { IP = Discovered.Host.Address.ToString(), Name = Discovered.Host.Address.ToString() };
                    gs.Blasters.Add(biNew);
                    Registered = GetBlasterByIP(Discovered.Host.Address.ToString());
                    Blasters.Add(Registered.Name, Discovered);
                }
                Registered.Online = true;
            }
            // check for offline
            foreach (BlasterInfo bi in gs.Blasters)
            {
                if (!bi.Online)
                {
                    WLog("! Blaster '{0}' [{1}] offline", bi.Name, bi.IP); 
                }
            }
        }

        private async void StartLearningAsync()
        {
            var DevName = ((IRCode)dgvIRCodes.CurrentRow.DataBoundItem).Blaster;
            Rm RMBlaster = GetRMBlasterByName(DevName);
            WLog("Enter learning mode on {0}", DevName);
            var x = await RMBlaster.Auth();
            if (x)
            {
                x = await RMBlaster.EnterLearning();
                if (x)
                {
                    MessageBox.Show(" Point the remote control to be learned to RM Pro, and press the button. Hit OK finally", "Learning...", MessageBoxButtons.OK);
                    var data = await RMBlaster.CheckData();
                    if (data.Length > 0)
                    {
                        string code = StringHelper.CreateHexPrintableString(data);
                        WLog("Code={0}", code);
                        ((IRCode)dgvIRCodes.CurrentRow.DataBoundItem).Command = code;
                        dgvIRCodes.Refresh();
                    }
                }
                else
                {
                    WLog("! Blaster [{0}] not respond", DevName);
                }
            } else
            {
                WLog("! Blaster [{0}] not respond", DevName);
            }
        }
        private async void TestSendAsync()
        {
            SendSignalAsync(dgvIRCodes.CurrentRow.Index);
        }

        private async void SendSignalAsync(int join)
        {
            Rm RMBlaster = GetRMBlasterByName(IRCodes[join].Blaster);
            WLog("Send {0} via {1}", IRCodes[join].Name, IRCodes[join].Blaster);
            var x = await RMBlaster.Auth();
            if (x)
            {
                var data = StringHelper.CreateBytesFromHexString(IRCodes[join].Command);
                x = await RMBlaster.SendData(data);
                if (x)
                {
                    WLog("OK");
                }
                else
                { WLog("! Blaster [{0}] not respond", IRCodes[join].Blaster); }
            }
            else
            { WLog("! Blaster [{0}] not respond", IRCodes[join].Blaster); }

        }

        #endregion

        #region (De)Serialization
        private void LoadSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BroadlinkGateSettings));
            try
            {
                using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
                {
                    gs = (BroadlinkGateSettings)formatter.Deserialize(fs);
                }
            }
            catch 
            {
                gs = new BroadlinkGateSettings();
            }
            propertyGrid1.SelectedObject = gs;
        }

        private void SaveSettings()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BroadlinkGateSettings));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gs);

                Console.WriteLine("Settings сериализованы");
            }
        }

        private void LoadIRCodes()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BindingList<IRCode>));
            try
            {
                using (FileStream fs = new FileStream("IRCodes.xml", FileMode.OpenOrCreate))
                {
                    IRCodes = (BindingList<IRCode>)formatter.Deserialize(fs);
                }
            }
            catch 
            {
                IRCodes = new BindingList<IRCode>();
            }
            //bsIRCodes.DataSource = IRCodes;
        }

        private void SaveIRCodes()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BindingList<IRCode>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("IRCodes.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, IRCodes);

                Console.WriteLine("IRCodes сериализованы");
            }
        }
        #endregion

        #region UI Logic
        private void SetupGrid()
        {
            foreach (IRCode irc in IRCodes)
            {
                if (GetBlasterByName(irc.Blaster)==null)
                {
                    BlasterInfo newBI = new BlasterInfo() { IP = "", Name = irc.Blaster, Online = false };
                    gs.Blasters.Add(newBI);
                }
            }
            IRCodes.AllowNew = true;
            IRCodes.AllowEdit = true;
            IRCodes.AllowRemove = true;
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
            foreach (BlasterInfo bi in gs.Blasters)
            {
                lib.Add(bi.ToString());
            }

            DataGridViewComboBoxColumn dgvc4 = new DataGridViewComboBoxColumn();
            dgvc4.Name = "Blaster";
            dgvc4.DataPropertyName = "Blaster";
            dgvc4.Width = 200;
            dgvc4.DataSource = new BindingSource() { DataSource = lib};

            dgvIRCodes.Columns.Add(dgvc4);

            dgvIRCodes.DataSource = IRCodes;

            dgvIRCodes.Invalidate();

        }

        private void UpdateControls()
        {
            if (dgvIRCodes.CurrentRow != null)
            {
                if (dgvIRCodes.CurrentRow.DataBoundItem != null)
                {
                    IRCode sel = (IRCode)dgvIRCodes.CurrentRow.DataBoundItem;
                    btnStartLearning.Enabled = (sel.CodeType == IRCodeType.RAW);
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnTest.Enabled = true;
                }
            }
            else
            {
                btnStartLearning.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnTest.Enabled = false;
            }
        }

        private void MoveRowBy(int offset)
        {
            DataGridViewRow row = dgvIRCodes.CurrentRow;

            if (row.Index == 0 && offset == -1 || ((row.Index == dgvIRCodes.NewRowIndex - 1) && offset == 1 || row.Index == dgvIRCodes.NewRowIndex))
                return; // Ничего делать не надо => выходим
                        // Получаем текущий индекс строки
            int currentIndex = row.Index;
            // Удаляем ее из коллекции
            IRCode irc = (IRCode)row.DataBoundItem;
            IRCodes.Remove(irc);
            // А теперь добавляем со смещением
            IRCodes.Insert(currentIndex + offset, irc);
        }
        #endregion

        #region Crestron
        private void InitCrestron()
        {
            if (gs.CrestronIP!="")
            {
                cipClient = new CIPClient(gs.CrestronIP, (byte)Convert.ToInt32(gs.CrestronPID, 16));
                cipClient.OnСonnect += OnConnect;
                cipClient.OnDisconnect += OnDisconnect;
                cipClient.Debug += On_Crestron_Debug;
                cipClient.OnDigital += CipClient_OnDigital;
                cipClient.ConnectToServer();
            }
        }

        private void CipClient_OnDigital(ushort usJoin, bool bValue)
        {
            if (bValue) SendSignalAsync(usJoin-1);
        }

        void On_Crestron_Debug(object sender, StringEventArgs e)
        {
            WLog(e.val);
        }
        private void OnConnect()
        {
            pictureBox1.Image = Resource1.Crestron_connected_png;
        }

        private void OnDisconnect()
        {
            pictureBox1.Image = Resource1.Crestron_disconnected_png;
        }

        #endregion

        #region Offline/online
        private void GoOffline(string blasterName)
        {

        }

        private void GoOnline(string blasterName)
        {

        }
        #endregion
        private void InitData()
        {
            LoadSettings();
            InitCrestron();
            LoadIRCodes();
            SetupGrid();
            InitBlasters();
        }


        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveRowBy(1);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
            SaveIRCodes();
        }

        private void dgvIRCodes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dgvIRCodes.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dgvIRCodes.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        }

        private void btnPairing_Click(object sender, EventArgs e)
        {
            Broadlink.Setup(gs.SSID, gs.Passphrase, Broadlink.WifiSecurityMode.WPA2);
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            InitBlasters();
        }

        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabConfig)
            {
                SaveSettings();
                SetupGrid();
            }
        }

        private void dgvIRCodes_SelectionChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void dgvIRCodes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateControls();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveRowBy(-1);
        }

        private void btnStartLearning_Click(object sender, EventArgs e)
        {
            StartLearningAsync();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestSendAsync();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceExit();
        }

        private void ShowMainForm()
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            showToolStripMenuItem.Text = "Hide";
        }

        private void HideMainForm()
        {
            Hide();
            showToolStripMenuItem.Text = "Show";
        }
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainForm();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showToolStripMenuItem.Text == "Hide")
            {
                HideMainForm();                
            }
            else
            {
                ShowMainForm();
            }

        }

        private void ForceExit()
        {
            realExit = true;
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !realExit;
            if (!realExit) HideMainForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
