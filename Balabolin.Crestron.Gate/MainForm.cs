using Balabolin.Crestron.Gate.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Balabolin.Crestron.Gate
{
    delegate void RichTextBoxDelegate(RichTextBox rtb, string s);
    delegate void ListViewItemDelegate(Signal signal);
    delegate void ControlSetSignalDelegate(Control ctrl, Signal signal);

    public partial class MainForm : Form
    {
        #region properties and fields
        PluginManager Manager;
        private Plugin SelectedPlugin;
        private Signal SelectedDigitalSignal;
        private Signal SelectedAnalogSignal;
        private Signal SelectedSerialSignal;

        #endregion

        #region Forms event handlers
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manager = new PluginManager(Application.StartupPath + "\\Plugins\\");
            Manager.LoadGateSettings();
            RefreshPluginList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedPlugin != null)
            {
                if (SelectedPlugin.ConnectedToCrestron)
                {
                    SelectedPlugin.AutoReconnect = false;
                    SelectedPlugin.DisconnectFromCrestron();
                }
                else
                {
                    if (lblPID.Text != comboBoxPID.Text)
                    {
                        Manager.ChangePluginPID(SelectedPlugin, comboBoxPID.Text);
                        lblPID.Text = comboBoxPID.Text;
                    }
                    SelectedPlugin.ConnectToCrestron();
                    SelectedPlugin.AutoReconnect = true;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lvPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvPlugins.SelectedItems.Count > 0)
                SetActivePlugin((Plugin)lvPlugins.SelectedItems[0].Tag);
        }

        private void lvPlugins_ItemActivate(object sender, EventArgs e)
        {
        }

        private void buttonReloadPlugins_Click(object sender, EventArgs e)
        {
            RefreshPluginList();
        }

        private void buttonPluginSettings_Click(object sender, EventArgs e)
        {
            if (SelectedPlugin != null)
            {
                SelectedPlugin.ShowPluginWindow();
                SetActivePlugin(SelectedPlugin);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listViewDigitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveDigital(listViewDigitals.SelectedItems.Count > 0 ? (Signal)listViewDigitals.SelectedItems[0].Tag : null);
        }

        private void listViewSerials_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveSerial(listViewSerials.SelectedItems.Count > 0 ? (Signal)listViewSerials.SelectedItems[0].Tag : null);
        }

        private void buttonTO_ON_Click(object sender, EventArgs e)
        {
            SelectedDigitalSignal?.ManualSetData(true);
        }

        private void buttonTO_OFF_Click(object sender, EventArgs e)
        {
            SelectedDigitalSignal?.ManualSetData(false);
        }

        private void buttonPulse_On_Click(object sender, EventArgs e)
        {
            SelectedDigitalSignal?.ManualSetData(true);
            SelectedDigitalSignal?.ManualSetData(false);
        }

        private void buttonPulse_Off_Click(object sender, EventArgs e)
        {
            SelectedDigitalSignal?.ManualSetData(false);
            SelectedDigitalSignal?.ManualSetData(true);
        }

        private void buttonDig_Sw_Click(object sender, EventArgs e)
        {
            if (SelectedDigitalSignal != null)
                if (SelectedDigitalSignal.Data != null)
                    SelectedDigitalSignal.ManualSetData(!(bool)SelectedDigitalSignal.Data);
        }

        private void buttonGlobalSettings_Click(object sender, EventArgs e)
        {
            CrestronConfig configForm = new CrestronConfig();
            GateSettings gsNew = new GateSettings(Manager.gateSettings);
            configForm.SetSettings(gsNew);
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                if (gsNew.SettingsChanged(Manager.gateSettings))
                {
                    Manager.gateSettings = gsNew;
                    Manager.SaveGlobalSettings();
                }
            }
        }

        #endregion

        #region Plugins events handlers
        public void OnCrestronConnected(Plugin plugin)
        {
            SetConnectionState();
        }
        public void OnCrestronDisconnected(Plugin plugin)
        {
            SetConnectionState();
        }

        public void OnSignalDataEvent(Signal signal, bool toLog)
        {
            switch (signal.SignalType)
            {
                case SignalTypeEnum.Analog:
                    if (SelectedAnalogSignal == signal)
                    {
                        ControlSetSignal(numericUpDownAnalogData, signal);
                        if (signal.Data != null && toLog)
                            AppendLog(richTextBoxAnalogLog, signal.Log.Last().ToShortLogString());
                    }
                    break;
                case SignalTypeEnum.Digital:
                    if (SelectedDigitalSignal == signal)
                    {
                        ControlSetSignal(pictureBoxDigitlSignal, signal);
                        if (signal.Data != null && toLog)
                            AppendLog(richTextBoxDigitalLog, signal.Log.Last().ToShortLogString());
                    }
                    break;
                case SignalTypeEnum.Serial:
                    if (SelectedSerialSignal == signal)
                    {
                        ControlSetSignal(richTextBoxSerialData, signal);
                        if (signal.Data != null && toLog)
                            AppendLog(richTextBoxSerialLog, signal.Log.Last().ToShortLogString());
                    }
                    break;
            }
            if (signal.LinkedListViewItem != null)
            {
                SetSubitemData(signal);
            }
            if (toLog && checkBoxIncludeSignals.Checked)
            {
                AppendLog(richTextBoxPluginLog, signal.Log.Last().ToLongLogString());
            }

        }

        private void ControlSetSignal(Control ctrl, Signal signal)
        {
            if (ctrl.InvokeRequired)
                ctrl.BeginInvoke(new ControlSetSignalDelegate(ControlSetSignal), ctrl, signal);
            else
            {
                switch (signal.SignalType)
                {
                    case SignalTypeEnum.Analog:
                        (ctrl as NumericUpDown).Value = (signal.Data != null) ? (ushort)signal.Data : 0;
                        break;
                    case SignalTypeEnum.Digital:
                        (ctrl as PictureBox).Image = signal.Data == null ? Resource1.D_Unknown : ((bool)signal.Data ? Resource1.D_ON : Resource1.D_OFF);
                        break;
                    case SignalTypeEnum.Serial:
                        (ctrl as RichTextBox).Text = (signal.Data != null) ? signal.Data.ToString() : "";
                        break;
                }
            }
        }

        private void SetSubitemData(Signal signal)
        {
            if (signal.LinkedListViewItem.ListView.InvokeRequired)
                signal.LinkedListViewItem.ListView.BeginInvoke(new ListViewItemDelegate(SetSubitemData), signal);
            else
            {
                if (signal.Data != null)
                {
                    switch (signal.SignalType)
                    {
                        case SignalTypeEnum.Analog:
                            signal.LinkedListViewItem.SubItems[2].Text = signal.Data.ToString();
                            signal.LinkedListViewItem.SubItems[2].ForeColor = Color.Black;
                            break;
                        case SignalTypeEnum.Digital:
                            signal.LinkedListViewItem.SubItems[2].Text = (bool)signal.Data ? "ON" : "OFF";
                            signal.LinkedListViewItem.SubItems[2].ForeColor = ((bool)signal.Data) ? Color.DarkGreen : Color.Black;
                            break;
                        case SignalTypeEnum.Serial:
                            signal.LinkedListViewItem.SubItems[2].Text = signal.Data.ToString();
                            signal.LinkedListViewItem.SubItems[2].ForeColor = Color.Black;
                            break;
                    }
                }
                else
                {
                    signal.LinkedListViewItem.SubItems[2].Text = "";
                    signal.LinkedListViewItem.SubItems[2].ForeColor = Color.Black;
                }
            }
        }

        #endregion

        #region Logging
        public void OnPluginDebug(Plugin plugin, string debugText)
        {
            AppendLog(richTextBoxPluginLog, debugText);
        }

        private void AppendLog(RichTextBox rtb, string s)
        {
            if (rtb.InvokeRequired)
                rtb.BeginInvoke(new RichTextBoxDelegate(AppendLog), rtb, s);
            else
            {
                rtb.Text = s + "\n" + (rtb.Text.Length<=100000 ? rtb.Text : rtb.Text.Substring(0,100000));
            }
        }

        private void LoadSignalLog(RichTextBox rtb, Signal sig)
        {
            rtb.Clear();
            string s = "";
            foreach (SignalLogItem li in sig.Log)
            {
                s = li.ToShortLogString() + "\n" + s;                
            }
            rtb.Text = s;
        }

        private void LoadPluginLog(Plugin plugin)
        {
            List<LogItem> GlobalLog = new List<LogItem>();
            if (checkBoxIncludeSignals.Checked)
            {
                foreach (Signal sig in plugin.InAnalogs)
                {
                    GlobalLog.AddRange(sig.Log);
                }
                foreach (Signal sig in plugin.InDigitals)
                {
                    GlobalLog.AddRange(sig.Log);
                }
                foreach (Signal sig in plugin.InSerials)
                {
                    GlobalLog.AddRange(sig.Log);
                }
                foreach (Signal sig in plugin.OutAnalogs)
                {
                    GlobalLog.AddRange(sig.Log);
                }
                foreach (Signal sig in plugin.OutDigitals)
                {
                    GlobalLog.AddRange(sig.Log);
                }
                foreach (Signal sig in plugin.OutSerials)
                {
                    GlobalLog.AddRange(sig.Log);
                }
            }
            GlobalLog.AddRange(plugin.PluginLog);
            List<LogItem> FullLog = GlobalLog.OrderByDescending(o => o.RaisedDateTime).ToList();
            richTextBoxPluginLog.Clear();
            //richTextBoxPluginLog.
            string s = "";

            foreach (LogItem li in FullLog)
            {
                s += li.ToLongLogString() + "\n";
            }
            richTextBoxPluginLog.Text = s;
        }

        #endregion

        #region Listview functions
        private void ClearListView(ListView lv)
        {
            foreach (ListViewItem lvi in lv.Items)
            {
                ((Signal)lvi.Tag).LinkedListViewItem = null;
            }
            lv.Items.Clear();
        }

        private void LoadListView(ListView lv, List<Signal> signals)
        {
            foreach (Signal sig in signals)
            {
                ListViewItem lvi = new ListViewItem(sig.Join.ToString());
                lvi.UseItemStyleForSubItems = false;
                lvi.Group = lv.Groups[sig.SignalDirection == SignalDirectionEnum.Input ? 0 : 1];
                sig.LinkedListViewItem = lvi;

                lvi.SubItems.Clear();
                lvi.Text = sig.Join.ToString();
                lvi.Tag = sig;
                lvi.SubItems.Add(sig.Name);
                if (sig.Data != null)
                {
                    if (sig.SignalType == SignalTypeEnum.Digital)
                    {
                        ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add((bool)sig.Data ? "ON" : "OFF");
                        lvsi.ForeColor = ((bool)sig.Data) ? Color.DarkGreen : Color.Black;
                    }
                    else
                    {
                        lvi.SubItems.Add(sig.Data.ToString());
                    }
                }
                else
                {
                    lvi.SubItems.Add("");
                }
                lv.Items.Add(lvi);
            }
        }
        private void LoadSignalDefinitions(Plugin plugin)
        {
            ClearListView(listViewDigitals);
            ClearListView(listViewAnalogs);
            ClearListView(listViewSerials);
            LoadListView(listViewDigitals, plugin.InDigitals);
            LoadListView(listViewDigitals, plugin.OutDigitals);
            LoadListView(listViewAnalogs, plugin.InAnalogs);
            LoadListView(listViewAnalogs, plugin.OutAnalogs);
            LoadListView(listViewSerials, plugin.InSerials);
            LoadListView(listViewSerials, plugin.OutSerials);
        }
        private void RefreshPluginList()
        {
            Manager.Rescan();
            lvPlugins.Items.Clear();
            foreach (Plugin plugin in Manager.Plugins)
            {
                var lv = lvPlugins.Items.Add(plugin.Name);
                lv.Tag = plugin;
            }
            lvPlugins.Items[0].Selected = true;
        }


        #endregion

        #region Active change handlers

        private void SetActivePlugin(Plugin plugin)
        {
            if (SelectedPlugin != null)
            {
                SelectedPlugin.OnSignalDataChange -= OnSignalDataEvent;
                SelectedPlugin.OnPluginConnectedToCrestron -= OnCrestronConnected;
                SelectedPlugin.OnPluginDisconnectedFromCrestron -= OnCrestronDisconnected;
                SelectedPlugin.OmPluginDebugEvent -= OnPluginDebug;
            }

            SetActiveDigital(null);
            SetActiveAnalog(null);
            SetActiveSerial(null);

            SelectedPlugin = plugin;

            pbLogo.Image = plugin.Logo;
            lblPluginName.Text = plugin.Name;
            lblPluginVersion.Text = plugin.Version;
            lblPID.Text = plugin.HexPID;
            comboBoxPID.Text = lblPID.Text;
            SetConnectionState();
            LoadSignalDefinitions(plugin);
            LoadPluginLog(plugin);
            SelectedPlugin.OnSignalDataChange += OnSignalDataEvent;
            SelectedPlugin.OnPluginConnectedToCrestron += OnCrestronConnected;
            SelectedPlugin.OnPluginDisconnectedFromCrestron += OnCrestronDisconnected;
            SelectedPlugin.OmPluginDebugEvent += OnPluginDebug;
        }

        private void SetConnectionState()
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new BasicHandler(SetConnectionState));
            else
            {
                if (SelectedPlugin != null)
                {
                    lblPID.Visible = SelectedPlugin.ConnectedToCrestron;
                    comboBoxPID.Visible = !SelectedPlugin.ConnectedToCrestron;
                    buttonCrestronReconnect.Text = SelectedPlugin.ConnectedToCrestron ? "Disconnect" : "Connect";
                    pbCrestronConnection.Image = SelectedPlugin.ConnectedToCrestron ? Resource1.Crestron_connected_png : Resource1.Crestron_disconnected_png;
                }
            }
        }


        private void SetActiveDigital(Signal signal)
        {
            SelectedDigitalSignal = signal;
            if (SelectedDigitalSignal != null)
            {
                labelSignalDirection_D.Text = signal.SignalDirection == SignalDirectionEnum.Input ? "Input" : "Output";
                labelSignalName_D.Text = signal.Name;
                LoadSignalLog(richTextBoxDigitalLog, signal);
                OnSignalDataEvent(signal, false);
            }
            else
            {
                labelSignalDirection_D.Text = "Signal";
                labelSignalName_D.Text = "Not selected";
                pictureBoxDigitlSignal.Image = Resource1.D_Unknown;
                richTextBoxDigitalLog.Clear();
            }
        }

        private void SetActiveAnalog(Signal signal)
        {
            SelectedAnalogSignal = signal;
            if (SelectedAnalogSignal != null)
            {
                labelSignalDirection_A.Text = signal.SignalDirection == SignalDirectionEnum.Input ? "Input" : "Output";
                labelSignalName_A.Text = signal.Name;
                LoadSignalLog(richTextBoxAnalogLog, signal);
                OnSignalDataEvent(signal, false);
            }
            else
            {
                labelSignalDirection_A.Text = "Signal";
                labelSignalName_A.Text = "Not selected";
                richTextBoxAnalogLog.Clear();
            }
        }
        private void SetActiveSerial(Signal signal)
        {
            SelectedSerialSignal = signal;
            if (SelectedSerialSignal != null)
            {
                labelSignalDirection_S.Text = signal.SignalDirection == SignalDirectionEnum.Input ? "Input" : "Output";
                labelSignalName_S.Text = signal.Name;
                LoadSignalLog(richTextBoxSerialLog, signal);
                OnSignalDataEvent(signal, false);
            }
            else
            {
                labelSignalDirection_S.Text = "Signal";
                labelSignalName_S.Text = "Not selected";
                richTextBoxSerialLog.Clear();
            }
        }


        #endregion

        private void comboBoxPID_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxIncludeSignals_CheckedChanged(object sender, EventArgs e)
        {
            LoadPluginLog(SelectedPlugin);
        }

        #region Hide/Show

        bool realExit = false;
        private void ForceExit()
        {
            realExit = true;
            this.Close();
        }

        private void HideMainForm()
        {
            Hide();
            showToolStripMenuItem.Text = "Show";
        }

        private void ShowMainForm()
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            showToolStripMenuItem.Text = "Hide";
        }

        private void SwitchFormVisible()
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

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !realExit;
            if (!realExit) HideMainForm();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SwitchFormVisible();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchFormVisible();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceExit();
        }

        private void buttonExitGate_Click(object sender, EventArgs e)
        {
            ForceExit();
        }
    }
}
