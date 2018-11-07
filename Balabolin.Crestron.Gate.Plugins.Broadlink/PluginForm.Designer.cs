namespace Balabolin.Crestron.Gate.Plugins.Broadlink
{
    partial class PluginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageIR = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvIRCodes = new System.Windows.Forms.DataGridView();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.btnRescan = new System.Windows.Forms.Button();
            this.btnPairing = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabControl1.SuspendLayout();
            this.tabPageIR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIRCodes)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageIR);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1232, 607);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageIR
            // 
            this.tabPageIR.Controls.Add(this.button3);
            this.tabPageIR.Controls.Add(this.button4);
            this.tabPageIR.Controls.Add(this.button2);
            this.tabPageIR.Controls.Add(this.button1);
            this.tabPageIR.Controls.Add(this.dgvIRCodes);
            this.tabPageIR.Location = new System.Drawing.Point(4, 22);
            this.tabPageIR.Name = "tabPageIR";
            this.tabPageIR.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIR.Size = new System.Drawing.Size(1224, 581);
            this.tabPageIR.TabIndex = 0;
            this.tabPageIR.Text = "IR signal definitions";
            this.tabPageIR.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Balabolin.Crestron.Gate.Plugins.Broadlink.Resource1.move_down;
            this.button3.Location = new System.Drawing.Point(275, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 44);
            this.button3.TabIndex = 16;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::Balabolin.Crestron.Gate.Plugins.Broadlink.Resource1.move_up;
            this.button4.Location = new System.Drawing.Point(212, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(57, 44);
            this.button4.TabIndex = 15;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::Balabolin.Crestron.Gate.Plugins.Broadlink.Resource1.ir_send;
            this.button2.Location = new System.Drawing.Point(70, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 44);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Balabolin.Crestron.Gate.Plugins.Broadlink.Resource1.learning;
            this.button1.Location = new System.Drawing.Point(7, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 44);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvIRCodes
            // 
            this.dgvIRCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIRCodes.Location = new System.Drawing.Point(7, 62);
            this.dgvIRCodes.Name = "dgvIRCodes";
            this.dgvIRCodes.Size = new System.Drawing.Size(1210, 510);
            this.dgvIRCodes.TabIndex = 0;
            this.dgvIRCodes.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvIRCodes_RowPrePaint);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.btnRescan);
            this.tabPageSettings.Controls.Add(this.btnPairing);
            this.tabPageSettings.Controls.Add(this.propertyGrid1);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(1224, 581);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Configuration";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // btnRescan
            // 
            this.btnRescan.FlatAppearance.BorderSize = 0;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.Image = global::Balabolin.Crestron.Gate.Plugins.Broadlink.Resource1.rescan;
            this.btnRescan.Location = new System.Drawing.Point(18, 14);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(57, 44);
            this.btnRescan.TabIndex = 12;
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // btnPairing
            // 
            this.btnPairing.FlatAppearance.BorderSize = 0;
            this.btnPairing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPairing.Image = global::Balabolin.Crestron.Gate.Plugins.Broadlink.Resource1.pairing;
            this.btnPairing.Location = new System.Drawing.Point(101, 14);
            this.btnPairing.Name = "btnPairing";
            this.btnPairing.Size = new System.Drawing.Size(57, 44);
            this.btnPairing.TabIndex = 11;
            this.btnPairing.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(18, 71);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(1188, 489);
            this.propertyGrid1.TabIndex = 10;
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 607);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PluginForm";
            this.Text = "Broadlink RM3 blaster plugin";
            this.Load += new System.EventHandler(this.PluginForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageIR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIRCodes)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageIR;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnPairing;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.DataGridView dgvIRCodes;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}