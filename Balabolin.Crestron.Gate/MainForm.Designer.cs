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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("OpenWeatherMap gate");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Broadlink IR blaster");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvPlugins = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblPluginName = new System.Windows.Forms.Label();
            this.buttonCrestronReconnect = new System.Windows.Forms.Button();
            this.lblPluginVersion = new System.Windows.Forms.Label();
            this.comboBoxPID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPluginSettings = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbCrestronConnection = new System.Windows.Forms.PictureBox();
            this.buttonReloadPlugins = new System.Windows.Forms.Button();
            this.buttonGlobalSettings = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrestronConnection)).BeginInit();
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
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Digital";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1022, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analog";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonReloadPlugins);
            this.panel1.Controls.Add(this.buttonGlobalSettings);
            this.panel1.Controls.Add(this.lvPlugins);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 601);
            this.panel1.TabIndex = 2;
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
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1022, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Serial";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1022, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Log";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.buttonCrestronReconnect.Location = new System.Drawing.Point(799, 17);
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
            "0x13"});
            this.comboBoxPID.Location = new System.Drawing.Point(734, 20);
            this.comboBoxPID.MaxDropDownItems = 32;
            this.comboBoxPID.Name = "comboBoxPID";
            this.comboBoxPID.Size = new System.Drawing.Size(59, 29);
            this.comboBoxPID.TabIndex = 8;
            this.comboBoxPID.Text = "0x12";
            this.comboBoxPID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(696, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "PID";
            // 
            // lblPID
            // 
            this.lblPID.AutoSize = true;
            this.lblPID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPID.Location = new System.Drawing.Point(736, 23);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(42, 21);
            this.lblPID.TabIndex = 12;
            this.lblPID.Text = "0x12";
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
            this.pbCrestronConnection.Location = new System.Drawing.Point(653, 18);
            this.pbCrestronConnection.Name = "pbCrestronConnection";
            this.pbCrestronConnection.Size = new System.Drawing.Size(32, 32);
            this.pbCrestronConnection.TabIndex = 4;
            this.pbCrestronConnection.TabStop = false;
            // 
            // buttonReloadPlugins
            // 
            this.buttonReloadPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReloadPlugins.FlatAppearance.BorderSize = 0;
            this.buttonReloadPlugins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReloadPlugins.Image = global::Balabolin.Crestron.Gate.Resource1.Reload;
            this.buttonReloadPlugins.Location = new System.Drawing.Point(3, 552);
            this.buttonReloadPlugins.Name = "buttonReloadPlugins";
            this.buttonReloadPlugins.Size = new System.Drawing.Size(116, 46);
            this.buttonReloadPlugins.TabIndex = 2;
            this.buttonReloadPlugins.UseVisualStyleBackColor = true;
            // 
            // buttonGlobalSettings
            // 
            this.buttonGlobalSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGlobalSettings.FlatAppearance.BorderSize = 0;
            this.buttonGlobalSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGlobalSettings.Image = global::Balabolin.Crestron.Gate.Resource1.cfg;
            this.buttonGlobalSettings.Location = new System.Drawing.Point(125, 552);
            this.buttonGlobalSettings.Name = "buttonGlobalSettings";
            this.buttonGlobalSettings.Size = new System.Drawing.Size(116, 46);
            this.buttonGlobalSettings.TabIndex = 1;
            this.buttonGlobalSettings.UseVisualStyleBackColor = true;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrestronConnection)).EndInit();
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
    }
}

