namespace Balabolin.Crestron.Gate
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Inputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Outputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Inputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Outputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Inputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Outputs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("OpenWeatherMap gate");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Broadlink IR blaster");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDig_Sw = new System.Windows.Forms.Button();
            this.buttonPulse_Off = new System.Windows.Forms.Button();
            this.buttonPulse_On = new System.Windows.Forms.Button();
            this.buttonTO_OFF = new System.Windows.Forms.Button();
            this.buttonTO_ON = new System.Windows.Forms.Button();
            this.pictureBoxDigitlSignal = new System.Windows.Forms.PictureBox();
            this.labelSignalDirection_D = new System.Windows.Forms.Label();
            this.labelSignalName_D = new System.Windows.Forms.Label();
            this.richTextBoxDigitalLog = new System.Windows.Forms.RichTextBox();
            this.listViewDigitals = new System.Windows.Forms.ListView();
            this.columnHeaderDIJoin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDIName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDIData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonAnalogSend = new System.Windows.Forms.Button();
            this.numericUpDownAnalogData = new System.Windows.Forms.NumericUpDown();
            this.labelSignalDirection_A = new System.Windows.Forms.Label();
            this.labelSignalName_A = new System.Windows.Forms.Label();
            this.richTextBoxAnalogLog = new System.Windows.Forms.RichTextBox();
            this.listViewAnalogs = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonSerialSend = new System.Windows.Forms.Button();
            this.richTextBoxSerialData = new System.Windows.Forms.RichTextBox();
            this.labelSignalDirection_S = new System.Windows.Forms.Label();
            this.labelSignalName_S = new System.Windows.Forms.Label();
            this.richTextBoxSerialLog = new System.Windows.Forms.RichTextBox();
            this.listViewSerials = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkBoxInternl = new System.Windows.Forms.CheckBox();
            this.checkBoxCrestron = new System.Windows.Forms.CheckBox();
            this.checkBoxIncludeSignals = new System.Windows.Forms.CheckBox();
            this.richTextBoxPluginLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExitGate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReloadPlugins = new System.Windows.Forms.Button();
            this.buttonGlobalSettings = new System.Windows.Forms.Button();
            this.lvPlugins = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPluginName = new System.Windows.Forms.Label();
            this.buttonCrestronReconnect = new System.Windows.Forms.Button();
            this.lblPluginVersion = new System.Windows.Forms.Label();
            this.comboBoxPID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPID = new System.Windows.Forms.Label();
            this.buttonPluginSettings = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbCrestronConnection = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDigitlSignal)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnalogData)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrestronConnection)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(247, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1030, 509);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDig_Sw);
            this.tabPage1.Controls.Add(this.buttonPulse_Off);
            this.tabPage1.Controls.Add(this.buttonPulse_On);
            this.tabPage1.Controls.Add(this.buttonTO_OFF);
            this.tabPage1.Controls.Add(this.buttonTO_ON);
            this.tabPage1.Controls.Add(this.pictureBoxDigitlSignal);
            this.tabPage1.Controls.Add(this.labelSignalDirection_D);
            this.tabPage1.Controls.Add(this.labelSignalName_D);
            this.tabPage1.Controls.Add(this.richTextBoxDigitalLog);
            this.tabPage1.Controls.Add(this.listViewDigitals);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Digital";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDig_Sw
            // 
            this.buttonDig_Sw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDig_Sw.FlatAppearance.BorderSize = 0;
            this.buttonDig_Sw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDig_Sw.Image = global::Balabolin.Crestron.Gate.Resource1.dig_sw;
            this.buttonDig_Sw.Location = new System.Drawing.Point(961, 67);
            this.buttonDig_Sw.Name = "buttonDig_Sw";
            this.buttonDig_Sw.Size = new System.Drawing.Size(44, 30);
            this.buttonDig_Sw.TabIndex = 21;
            this.buttonDig_Sw.UseVisualStyleBackColor = true;
            this.buttonDig_Sw.Click += new System.EventHandler(this.buttonDig_Sw_Click);
            // 
            // buttonPulse_Off
            // 
            this.buttonPulse_Off.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPulse_Off.FlatAppearance.BorderSize = 0;
            this.buttonPulse_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPulse_Off.Image = global::Balabolin.Crestron.Gate.Resource1.off_pulse;
            this.buttonPulse_Off.Location = new System.Drawing.Point(911, 68);
            this.buttonPulse_Off.Name = "buttonPulse_Off";
            this.buttonPulse_Off.Size = new System.Drawing.Size(44, 30);
            this.buttonPulse_Off.TabIndex = 20;
            this.buttonPulse_Off.UseVisualStyleBackColor = true;
            this.buttonPulse_Off.Click += new System.EventHandler(this.buttonPulse_Off_Click);
            // 
            // buttonPulse_On
            // 
            this.buttonPulse_On.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPulse_On.FlatAppearance.BorderSize = 0;
            this.buttonPulse_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPulse_On.Image = global::Balabolin.Crestron.Gate.Resource1.on_pulse;
            this.buttonPulse_On.Location = new System.Drawing.Point(861, 68);
            this.buttonPulse_On.Name = "buttonPulse_On";
            this.buttonPulse_On.Size = new System.Drawing.Size(44, 30);
            this.buttonPulse_On.TabIndex = 19;
            this.buttonPulse_On.UseVisualStyleBackColor = true;
            this.buttonPulse_On.Click += new System.EventHandler(this.buttonPulse_On_Click);
            // 
            // buttonTO_OFF
            // 
            this.buttonTO_OFF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTO_OFF.FlatAppearance.BorderSize = 0;
            this.buttonTO_OFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTO_OFF.Image = global::Balabolin.Crestron.Gate.Resource1.to_off;
            this.buttonTO_OFF.Location = new System.Drawing.Point(811, 68);
            this.buttonTO_OFF.Name = "buttonTO_OFF";
            this.buttonTO_OFF.Size = new System.Drawing.Size(44, 30);
            this.buttonTO_OFF.TabIndex = 18;
            this.buttonTO_OFF.UseVisualStyleBackColor = true;
            this.buttonTO_OFF.Click += new System.EventHandler(this.buttonTO_OFF_Click);
            // 
            // buttonTO_ON
            // 
            this.buttonTO_ON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTO_ON.FlatAppearance.BorderSize = 0;
            this.buttonTO_ON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTO_ON.Image = global::Balabolin.Crestron.Gate.Resource1.to_on;
            this.buttonTO_ON.Location = new System.Drawing.Point(761, 68);
            this.buttonTO_ON.Name = "buttonTO_ON";
            this.buttonTO_ON.Size = new System.Drawing.Size(44, 30);
            this.buttonTO_ON.TabIndex = 17;
            this.buttonTO_ON.UseVisualStyleBackColor = true;
            this.buttonTO_ON.Click += new System.EventHandler(this.buttonTO_ON_Click);
            // 
            // pictureBoxDigitlSignal
            // 
            this.pictureBoxDigitlSignal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDigitlSignal.Image = global::Balabolin.Crestron.Gate.Resource1.D_Unknown;
            this.pictureBoxDigitlSignal.Location = new System.Drawing.Point(717, 73);
            this.pictureBoxDigitlSignal.Name = "pictureBoxDigitlSignal";
            this.pictureBoxDigitlSignal.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxDigitlSignal.TabIndex = 16;
            this.pictureBoxDigitlSignal.TabStop = false;
            this.pictureBoxDigitlSignal.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelSignalDirection_D
            // 
            this.labelSignalDirection_D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignalDirection_D.AutoSize = true;
            this.labelSignalDirection_D.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignalDirection_D.Location = new System.Drawing.Point(713, 13);
            this.labelSignalDirection_D.Name = "labelSignalDirection_D";
            this.labelSignalDirection_D.Size = new System.Drawing.Size(51, 21);
            this.labelSignalDirection_D.TabIndex = 15;
            this.labelSignalDirection_D.Text = "signal";
            // 
            // labelSignalName_D
            // 
            this.labelSignalName_D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignalName_D.AutoSize = true;
            this.labelSignalName_D.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignalName_D.Location = new System.Drawing.Point(712, 34);
            this.labelSignalName_D.Name = "labelSignalName_D";
            this.labelSignalName_D.Size = new System.Drawing.Size(130, 30);
            this.labelSignalName_D.TabIndex = 14;
            this.labelSignalName_D.Text = "not selected";
            // 
            // richTextBoxDigitalLog
            // 
            this.richTextBoxDigitalLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDigitalLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxDigitalLog.Location = new System.Drawing.Point(714, 115);
            this.richTextBoxDigitalLog.Name = "richTextBoxDigitalLog";
            this.richTextBoxDigitalLog.Size = new System.Drawing.Size(297, 353);
            this.richTextBoxDigitalLog.TabIndex = 12;
            this.richTextBoxDigitalLog.Text = "";
            // 
            // listViewDigitals
            // 
            this.listViewDigitals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDigitals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewDigitals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDIJoin,
            this.columnHeaderDIName,
            this.columnHeaderDIData});
            this.listViewDigitals.FullRowSelect = true;
            listViewGroup1.Header = "Inputs";
            listViewGroup1.Name = "listViewGroupInput_D";
            listViewGroup2.Header = "Outputs";
            listViewGroup2.Name = "listViewGroupOutput_D";
            this.listViewDigitals.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listViewDigitals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDigitals.HideSelection = false;
            this.listViewDigitals.Location = new System.Drawing.Point(10, 7);
            this.listViewDigitals.MultiSelect = false;
            this.listViewDigitals.Name = "listViewDigitals";
            this.listViewDigitals.Size = new System.Drawing.Size(690, 461);
            this.listViewDigitals.TabIndex = 0;
            this.listViewDigitals.UseCompatibleStateImageBehavior = false;
            this.listViewDigitals.View = System.Windows.Forms.View.Details;
            this.listViewDigitals.SelectedIndexChanged += new System.EventHandler(this.listViewDigitals_SelectedIndexChanged);
            // 
            // columnHeaderDIJoin
            // 
            this.columnHeaderDIJoin.Text = "Join";
            // 
            // columnHeaderDIName
            // 
            this.columnHeaderDIName.Text = "Name";
            this.columnHeaderDIName.Width = 208;
            // 
            // columnHeaderDIData
            // 
            this.columnHeaderDIData.Text = "Data";
            this.columnHeaderDIData.Width = 360;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonAnalogSend);
            this.tabPage2.Controls.Add(this.numericUpDownAnalogData);
            this.tabPage2.Controls.Add(this.labelSignalDirection_A);
            this.tabPage2.Controls.Add(this.labelSignalName_A);
            this.tabPage2.Controls.Add(this.richTextBoxAnalogLog);
            this.tabPage2.Controls.Add(this.listViewAnalogs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1022, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analog";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonAnalogSend
            // 
            this.buttonAnalogSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalogSend.FlatAppearance.BorderSize = 0;
            this.buttonAnalogSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalogSend.Image = global::Balabolin.Crestron.Gate.Resource1.send;
            this.buttonAnalogSend.Location = new System.Drawing.Point(844, 70);
            this.buttonAnalogSend.Name = "buttonAnalogSend";
            this.buttonAnalogSend.Size = new System.Drawing.Size(44, 30);
            this.buttonAnalogSend.TabIndex = 21;
            this.buttonAnalogSend.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAnalogData
            // 
            this.numericUpDownAnalogData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAnalogData.Location = new System.Drawing.Point(718, 77);
            this.numericUpDownAnalogData.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownAnalogData.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numericUpDownAnalogData.Name = "numericUpDownAnalogData";
            this.numericUpDownAnalogData.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAnalogData.TabIndex = 20;
            // 
            // labelSignalDirection_A
            // 
            this.labelSignalDirection_A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignalDirection_A.AutoSize = true;
            this.labelSignalDirection_A.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignalDirection_A.Location = new System.Drawing.Point(714, 11);
            this.labelSignalDirection_A.Name = "labelSignalDirection_A";
            this.labelSignalDirection_A.Size = new System.Drawing.Size(91, 21);
            this.labelSignalDirection_A.TabIndex = 19;
            this.labelSignalDirection_A.Text = "Input signal";
            // 
            // labelSignalName_A
            // 
            this.labelSignalName_A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignalName_A.AutoSize = true;
            this.labelSignalName_A.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignalName_A.Location = new System.Drawing.Point(712, 32);
            this.labelSignalName_A.Name = "labelSignalName_A";
            this.labelSignalName_A.Size = new System.Drawing.Size(189, 30);
            this.labelSignalName_A.TabIndex = 18;
            this.labelSignalName_A.Text = "DVD Power Switch";
            // 
            // richTextBoxAnalogLog
            // 
            this.richTextBoxAnalogLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAnalogLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxAnalogLog.Location = new System.Drawing.Point(715, 113);
            this.richTextBoxAnalogLog.Name = "richTextBoxAnalogLog";
            this.richTextBoxAnalogLog.Size = new System.Drawing.Size(297, 359);
            this.richTextBoxAnalogLog.TabIndex = 17;
            this.richTextBoxAnalogLog.Text = "";
            // 
            // listViewAnalogs
            // 
            this.listViewAnalogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAnalogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewAnalogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewAnalogs.FullRowSelect = true;
            listViewGroup3.Header = "Inputs";
            listViewGroup3.Name = "listViewGroupD_Input";
            listViewGroup4.Header = "Outputs";
            listViewGroup4.Name = "listViewGroupOutput_D";
            this.listViewAnalogs.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.listViewAnalogs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAnalogs.HideSelection = false;
            this.listViewAnalogs.Location = new System.Drawing.Point(11, 11);
            this.listViewAnalogs.MultiSelect = false;
            this.listViewAnalogs.Name = "listViewAnalogs";
            this.listViewAnalogs.Size = new System.Drawing.Size(690, 461);
            this.listViewAnalogs.TabIndex = 16;
            this.listViewAnalogs.UseCompatibleStateImageBehavior = false;
            this.listViewAnalogs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Join";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 208;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data";
            this.columnHeader4.Width = 360;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonSerialSend);
            this.tabPage3.Controls.Add(this.richTextBoxSerialData);
            this.tabPage3.Controls.Add(this.labelSignalDirection_S);
            this.tabPage3.Controls.Add(this.labelSignalName_S);
            this.tabPage3.Controls.Add(this.richTextBoxSerialLog);
            this.tabPage3.Controls.Add(this.listViewSerials);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1022, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Serial";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonSerialSend
            // 
            this.buttonSerialSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSerialSend.FlatAppearance.BorderSize = 0;
            this.buttonSerialSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSerialSend.Image = global::Balabolin.Crestron.Gate.Resource1.send;
            this.buttonSerialSend.Location = new System.Drawing.Point(975, 75);
            this.buttonSerialSend.Name = "buttonSerialSend";
            this.buttonSerialSend.Size = new System.Drawing.Size(44, 30);
            this.buttonSerialSend.TabIndex = 27;
            this.buttonSerialSend.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSerialData
            // 
            this.richTextBoxSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxSerialData.Location = new System.Drawing.Point(715, 75);
            this.richTextBoxSerialData.Name = "richTextBoxSerialData";
            this.richTextBoxSerialData.Size = new System.Drawing.Size(262, 75);
            this.richTextBoxSerialData.TabIndex = 28;
            this.richTextBoxSerialData.Text = "";
            // 
            // labelSignalDirection_S
            // 
            this.labelSignalDirection_S.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignalDirection_S.AutoSize = true;
            this.labelSignalDirection_S.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignalDirection_S.Location = new System.Drawing.Point(714, 11);
            this.labelSignalDirection_S.Name = "labelSignalDirection_S";
            this.labelSignalDirection_S.Size = new System.Drawing.Size(91, 21);
            this.labelSignalDirection_S.TabIndex = 25;
            this.labelSignalDirection_S.Text = "Input signal";
            // 
            // labelSignalName_S
            // 
            this.labelSignalName_S.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSignalName_S.AutoSize = true;
            this.labelSignalName_S.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSignalName_S.Location = new System.Drawing.Point(713, 32);
            this.labelSignalName_S.Name = "labelSignalName_S";
            this.labelSignalName_S.Size = new System.Drawing.Size(189, 30);
            this.labelSignalName_S.TabIndex = 24;
            this.labelSignalName_S.Text = "DVD Power Switch";
            // 
            // richTextBoxSerialLog
            // 
            this.richTextBoxSerialLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxSerialLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxSerialLog.Location = new System.Drawing.Point(715, 170);
            this.richTextBoxSerialLog.Name = "richTextBoxSerialLog";
            this.richTextBoxSerialLog.Size = new System.Drawing.Size(297, 302);
            this.richTextBoxSerialLog.TabIndex = 23;
            this.richTextBoxSerialLog.Text = "";
            // 
            // listViewSerials
            // 
            this.listViewSerials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSerials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSerials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            listViewGroup5.Header = "Inputs";
            listViewGroup5.Name = "listViewGroupD_Input";
            listViewGroup6.Header = "Outputs";
            listViewGroup6.Name = "listViewGroupOutput_D";
            this.listViewSerials.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6});
            this.listViewSerials.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSerials.HideSelection = false;
            this.listViewSerials.Location = new System.Drawing.Point(11, 11);
            this.listViewSerials.MultiSelect = false;
            this.listViewSerials.Name = "listViewSerials";
            this.listViewSerials.Size = new System.Drawing.Size(690, 461);
            this.listViewSerials.TabIndex = 22;
            this.listViewSerials.UseCompatibleStateImageBehavior = false;
            this.listViewSerials.View = System.Windows.Forms.View.Details;
            this.listViewSerials.SelectedIndexChanged += new System.EventHandler(this.listViewSerials_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Join";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 208;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Data";
            this.columnHeader7.Width = 360;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBoxInternl);
            this.tabPage4.Controls.Add(this.checkBoxCrestron);
            this.tabPage4.Controls.Add(this.checkBoxIncludeSignals);
            this.tabPage4.Controls.Add(this.richTextBoxPluginLog);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1022, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // checkBoxInternl
            // 
            this.checkBoxInternl.AutoSize = true;
            this.checkBoxInternl.Checked = true;
            this.checkBoxInternl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInternl.Location = new System.Drawing.Point(210, 11);
            this.checkBoxInternl.Name = "checkBoxInternl";
            this.checkBoxInternl.Size = new System.Drawing.Size(55, 17);
            this.checkBoxInternl.TabIndex = 27;
            this.checkBoxInternl.Text = "Plugin";
            this.checkBoxInternl.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrestron
            // 
            this.checkBoxCrestron.AutoSize = true;
            this.checkBoxCrestron.Checked = true;
            this.checkBoxCrestron.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrestron.Location = new System.Drawing.Point(108, 11);
            this.checkBoxCrestron.Name = "checkBoxCrestron";
            this.checkBoxCrestron.Size = new System.Drawing.Size(65, 17);
            this.checkBoxCrestron.TabIndex = 26;
            this.checkBoxCrestron.Text = "Crestron";
            this.checkBoxCrestron.UseVisualStyleBackColor = true;
            // 
            // checkBoxIncludeSignals
            // 
            this.checkBoxIncludeSignals.AutoSize = true;
            this.checkBoxIncludeSignals.Checked = true;
            this.checkBoxIncludeSignals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeSignals.Location = new System.Drawing.Point(11, 11);
            this.checkBoxIncludeSignals.Name = "checkBoxIncludeSignals";
            this.checkBoxIncludeSignals.Size = new System.Drawing.Size(60, 17);
            this.checkBoxIncludeSignals.TabIndex = 25;
            this.checkBoxIncludeSignals.Text = "Signals";
            this.checkBoxIncludeSignals.UseVisualStyleBackColor = true;
            this.checkBoxIncludeSignals.CheckedChanged += new System.EventHandler(this.checkBoxIncludeSignals_CheckedChanged);
            // 
            // richTextBoxPluginLog
            // 
            this.richTextBoxPluginLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxPluginLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxPluginLog.Location = new System.Drawing.Point(11, 34);
            this.richTextBoxPluginLog.Name = "richTextBoxPluginLog";
            this.richTextBoxPluginLog.Size = new System.Drawing.Size(1000, 440);
            this.richTextBoxPluginLog.TabIndex = 24;
            this.richTextBoxPluginLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.buttonExitGate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonReloadPlugins);
            this.panel1.Controls.Add(this.buttonGlobalSettings);
            this.panel1.Controls.Add(this.lvPlugins);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 601);
            this.panel1.TabIndex = 2;
            // 
            // buttonExitGate
            // 
            this.buttonExitGate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExitGate.FlatAppearance.BorderSize = 0;
            this.buttonExitGate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExitGate.Image = global::Balabolin.Crestron.Gate.Resource1.Exit;
            this.buttonExitGate.Location = new System.Drawing.Point(166, 552);
            this.buttonExitGate.Name = "buttonExitGate";
            this.buttonExitGate.Size = new System.Drawing.Size(80, 46);
            this.buttonExitGate.TabIndex = 14;
            this.buttonExitGate.UseVisualStyleBackColor = true;
            this.buttonExitGate.Click += new System.EventHandler(this.buttonExitGate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Installed plugins";
            // 
            // buttonReloadPlugins
            // 
            this.buttonReloadPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReloadPlugins.FlatAppearance.BorderSize = 0;
            this.buttonReloadPlugins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReloadPlugins.Image = global::Balabolin.Crestron.Gate.Resource1.Reload;
            this.buttonReloadPlugins.Location = new System.Drawing.Point(1, 552);
            this.buttonReloadPlugins.Name = "buttonReloadPlugins";
            this.buttonReloadPlugins.Size = new System.Drawing.Size(80, 46);
            this.buttonReloadPlugins.TabIndex = 2;
            this.buttonReloadPlugins.UseVisualStyleBackColor = true;
            this.buttonReloadPlugins.Click += new System.EventHandler(this.buttonReloadPlugins_Click);
            // 
            // buttonGlobalSettings
            // 
            this.buttonGlobalSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGlobalSettings.FlatAppearance.BorderSize = 0;
            this.buttonGlobalSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGlobalSettings.Image = global::Balabolin.Crestron.Gate.Resource1.cfg;
            this.buttonGlobalSettings.Location = new System.Drawing.Point(82, 552);
            this.buttonGlobalSettings.Name = "buttonGlobalSettings";
            this.buttonGlobalSettings.Size = new System.Drawing.Size(80, 46);
            this.buttonGlobalSettings.TabIndex = 1;
            this.buttonGlobalSettings.UseVisualStyleBackColor = true;
            this.buttonGlobalSettings.Click += new System.EventHandler(this.buttonGlobalSettings_Click);
            // 
            // lvPlugins
            // 
            this.lvPlugins.AutoArrange = false;
            this.lvPlugins.BackColor = System.Drawing.Color.SteelBlue;
            this.lvPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvPlugins.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvPlugins.ForeColor = System.Drawing.Color.White;
            this.lvPlugins.FullRowSelect = true;
            this.lvPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvPlugins.HideSelection = false;
            this.lvPlugins.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvPlugins.Location = new System.Drawing.Point(0, 66);
            this.lvPlugins.Margin = new System.Windows.Forms.Padding(66);
            this.lvPlugins.MultiSelect = false;
            this.lvPlugins.Name = "lvPlugins";
            this.lvPlugins.Size = new System.Drawing.Size(247, 460);
            this.lvPlugins.TabIndex = 0;
            this.lvPlugins.UseCompatibleStateImageBehavior = false;
            this.lvPlugins.View = System.Windows.Forms.View.Details;
            this.lvPlugins.ItemActivate += new System.EventHandler(this.lvPlugins_ItemActivate);
            this.lvPlugins.SelectedIndexChanged += new System.EventHandler(this.lvPlugins_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Plugin";
            this.columnHeader1.Width = 240;
            // 
            // lblPluginName
            // 
            this.lblPluginName.AutoSize = true;
            this.lblPluginName.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPluginName.Location = new System.Drawing.Point(322, 13);
            this.lblPluginName.Name = "lblPluginName";
            this.lblPluginName.Size = new System.Drawing.Size(237, 30);
            this.lblPluginName.TabIndex = 3;
            this.lblPluginName.Text = "OpenWeatherMap gate";
            // 
            // buttonCrestronReconnect
            // 
            this.buttonCrestronReconnect.FlatAppearance.BorderSize = 0;
            this.buttonCrestronReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrestronReconnect.Location = new System.Drawing.Point(799, 15);
            this.buttonCrestronReconnect.Name = "buttonCrestronReconnect";
            this.buttonCrestronReconnect.Size = new System.Drawing.Size(72, 33);
            this.buttonCrestronReconnect.TabIndex = 5;
            this.buttonCrestronReconnect.Text = "Disconnect";
            this.buttonCrestronReconnect.UseVisualStyleBackColor = true;
            this.buttonCrestronReconnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPluginVersion
            // 
            this.lblPluginVersion.AutoSize = true;
            this.lblPluginVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPluginVersion.Location = new System.Drawing.Point(324, 46);
            this.lblPluginVersion.Name = "lblPluginVersion";
            this.lblPluginVersion.Size = new System.Drawing.Size(55, 21);
            this.lblPluginVersion.TabIndex = 7;
            this.lblPluginVersion.Text = "1.0.0.1";
            // 
            // comboBoxPID
            // 
            this.comboBoxPID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPID.FormattingEnabled = true;
            this.comboBoxPID.Items.AddRange(new object[] {
            "0x12",
            "0x13",
            "0x14",
            "0x15",
            "0x16",
            "0x17",
            "0x18",
            "0x19",
            "0x1A",
            "0x1B",
            "0x1C",
            "0x1D",
            "0x1E",
            "0x1F"});
            this.comboBoxPID.Location = new System.Drawing.Point(734, 17);
            this.comboBoxPID.MaxDropDownItems = 32;
            this.comboBoxPID.Name = "comboBoxPID";
            this.comboBoxPID.Size = new System.Drawing.Size(59, 29);
            this.comboBoxPID.TabIndex = 8;
            this.comboBoxPID.Visible = false;
            this.comboBoxPID.TextChanged += new System.EventHandler(this.comboBoxPID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(696, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "PID";
            // 
            // lblPID
            // 
            this.lblPID.AutoSize = true;
            this.lblPID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPID.Location = new System.Drawing.Point(734, 21);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(42, 21);
            this.lblPID.TabIndex = 12;
            this.lblPID.Text = "0x12";
            this.lblPID.Visible = false;
            // 
            // buttonPluginSettings
            // 
            this.buttonPluginSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPluginSettings.FlatAppearance.BorderSize = 0;
            this.buttonPluginSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPluginSettings.Image = global::Balabolin.Crestron.Gate.Resource1.setup;
            this.buttonPluginSettings.Location = new System.Drawing.Point(1192, 28);
            this.buttonPluginSettings.Name = "buttonPluginSettings";
            this.buttonPluginSettings.Size = new System.Drawing.Size(59, 46);
            this.buttonPluginSettings.TabIndex = 3;
            this.buttonPluginSettings.UseVisualStyleBackColor = true;
            this.buttonPluginSettings.Click += new System.EventHandler(this.buttonPluginSettings_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::Balabolin.Crestron.Gate.Resource1.OWM_logo;
            this.pbLogo.Location = new System.Drawing.Point(257, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(64, 64);
            this.pbLogo.TabIndex = 6;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pbCrestronConnection
            // 
            this.pbCrestronConnection.Image = global::Balabolin.Crestron.Gate.Resource1.Crestron_connected_png;
            this.pbCrestronConnection.Location = new System.Drawing.Point(653, 16);
            this.pbCrestronConnection.Name = "pbCrestronConnection";
            this.pbCrestronConnection.Size = new System.Drawing.Size(32, 32);
            this.pbCrestronConnection.TabIndex = 4;
            this.pbCrestronConnection.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Crestron to broadlink gate";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 54);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.showToolStripMenuItem.Text = "Hide";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 601);
            this.Controls.Add(this.buttonPluginSettings);
            this.Controls.Add(this.lblPID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPID);
            this.Controls.Add(this.lblPluginVersion);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.buttonCrestronReconnect);
            this.Controls.Add(this.pbCrestronConnection);
            this.Controls.Add(this.lblPluginName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Crestron gate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDigitlSignal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnalogData)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrestronConnection)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvPlugins;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblPluginName;
        private System.Windows.Forms.PictureBox pbCrestronConnection;
        private System.Windows.Forms.Button buttonCrestronReconnect;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblPluginVersion;
        private System.Windows.Forms.ComboBox comboBoxPID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPID;
        private System.Windows.Forms.Button buttonGlobalSettings;
        private System.Windows.Forms.Button buttonReloadPlugins;
        private System.Windows.Forms.Button buttonPluginSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewDigitals;
        private System.Windows.Forms.ColumnHeader columnHeaderDIJoin;
        private System.Windows.Forms.ColumnHeader columnHeaderDIName;
        private System.Windows.Forms.ColumnHeader columnHeaderDIData;
        private System.Windows.Forms.Label labelSignalDirection_D;
        private System.Windows.Forms.Label labelSignalName_D;
        private System.Windows.Forms.RichTextBox richTextBoxDigitalLog;
        private System.Windows.Forms.PictureBox pictureBoxDigitlSignal;
        private System.Windows.Forms.Button buttonTO_ON;
        private System.Windows.Forms.Button buttonTO_OFF;
        private System.Windows.Forms.Button buttonAnalogSend;
        private System.Windows.Forms.NumericUpDown numericUpDownAnalogData;
        private System.Windows.Forms.Label labelSignalDirection_A;
        private System.Windows.Forms.Label labelSignalName_A;
        private System.Windows.Forms.RichTextBox richTextBoxAnalogLog;
        private System.Windows.Forms.ListView listViewAnalogs;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonSerialSend;
        private System.Windows.Forms.RichTextBox richTextBoxSerialData;
        private System.Windows.Forms.Label labelSignalDirection_S;
        private System.Windows.Forms.Label labelSignalName_S;
        private System.Windows.Forms.RichTextBox richTextBoxSerialLog;
        private System.Windows.Forms.ListView listViewSerials;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button buttonDig_Sw;
        private System.Windows.Forms.Button buttonPulse_Off;
        private System.Windows.Forms.Button buttonPulse_On;
        private System.Windows.Forms.RichTextBox richTextBoxPluginLog;
        private System.Windows.Forms.CheckBox checkBoxIncludeSignals;
        private System.Windows.Forms.CheckBox checkBoxInternl;
        private System.Windows.Forms.CheckBox checkBoxCrestron;
        private System.Windows.Forms.Button buttonExitGate;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

