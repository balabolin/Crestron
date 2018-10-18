namespace Crestron_Gate
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMQTT = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabDigital = new System.Windows.Forms.TabPage();
            this.tabAnalog = new System.Windows.Forms.TabPage();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDigital = new System.Windows.Forms.DataGridView();
            this.bsDigital = new System.Windows.Forms.BindingSource(this.components);
            this.topicInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topicOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabMQTT.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabDigital.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDigital)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDigital)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabMQTT);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Location = new System.Drawing.Point(1, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1242, 469);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMQTT
            // 
            this.tabMQTT.Controls.Add(this.label3);
            this.tabMQTT.Controls.Add(this.tabControl2);
            this.tabMQTT.Location = new System.Drawing.Point(4, 4);
            this.tabMQTT.Name = "tabMQTT";
            this.tabMQTT.Padding = new System.Windows.Forms.Padding(3);
            this.tabMQTT.Size = new System.Drawing.Size(1234, 443);
            this.tabMQTT.TabIndex = 0;
            this.tabMQTT.Text = "Потоки";
            this.tabMQTT.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Таблица соответствий тпиков MQTT и связей Crestron";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabDigital);
            this.tabControl2.Controls.Add(this.tabAnalog);
            this.tabControl2.Controls.Add(this.tabSerial);
            this.tabControl2.Location = new System.Drawing.Point(7, 37);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1221, 400);
            this.tabControl2.TabIndex = 0;
            // 
            // tabDigital
            // 
            this.tabDigital.Controls.Add(this.dgvDigital);
            this.tabDigital.Location = new System.Drawing.Point(4, 22);
            this.tabDigital.Name = "tabDigital";
            this.tabDigital.Padding = new System.Windows.Forms.Padding(3);
            this.tabDigital.Size = new System.Drawing.Size(1213, 374);
            this.tabDigital.TabIndex = 0;
            this.tabDigital.Text = "Digital";
            this.tabDigital.UseVisualStyleBackColor = true;
            // 
            // tabAnalog
            // 
            this.tabAnalog.Location = new System.Drawing.Point(4, 22);
            this.tabAnalog.Name = "tabAnalog";
            this.tabAnalog.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalog.Size = new System.Drawing.Size(1213, 374);
            this.tabAnalog.TabIndex = 1;
            this.tabAnalog.Text = "Analog";
            this.tabAnalog.UseVisualStyleBackColor = true;
            // 
            // tabSerial
            // 
            this.tabSerial.Location = new System.Drawing.Point(4, 22);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Size = new System.Drawing.Size(1213, 374);
            this.tabSerial.TabIndex = 2;
            this.tabSerial.Text = "Serial";
            this.tabSerial.UseVisualStyleBackColor = true;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.groupBox1);
            this.tabLog.Controls.Add(this.richTextBox1);
            this.tabLog.Location = new System.Drawing.Point(4, 4);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(1234, 443);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Лог";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(1028, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уровень логирования";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(12, 90);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Полный";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 58);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(112, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Предупреждения";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ошибки";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(7, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1015, 431);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.propertyGrid1);
            this.tabConfig.Location = new System.Drawing.Point(4, 4);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Size = new System.Drawing.Size(1234, 443);
            this.tabConfig.TabIndex = 2;
            this.tabConfig.Text = "Настройка";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(1226, 437);
            this.propertyGrid1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.системаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1246, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // системаToolStripMenuItem
            // 
            this.системаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.системаToolStripMenuItem.Name = "системаToolStripMenuItem";
            this.системаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.системаToolStripMenuItem.Text = "Система";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Crestron processor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 24);
            this.panel1.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "MQTT Broker";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(173, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 24);
            this.panel2.TabIndex = 5;
            // 
            // dgvDigital
            // 
            this.dgvDigital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDigital.AutoGenerateColumns = false;
            this.dgvDigital.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvDigital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDigital.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.topicInDataGridViewTextBoxColumn,
            this.lastInDataGridViewTextBoxColumn,
            this.topicOutDataGridViewTextBoxColumn,
            this.lastOutDataGridViewTextBoxColumn});
            this.dgvDigital.DataSource = this.bsDigital;
            this.dgvDigital.Location = new System.Drawing.Point(1, 0);
            this.dgvDigital.Name = "dgvDigital";
            this.dgvDigital.Size = new System.Drawing.Size(1209, 374);
            this.dgvDigital.TabIndex = 0;
            this.dgvDigital.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDigital_RowPrePaint);
            // 
            // bsDigital
            // 
            this.bsDigital.DataSource = typeof(Crestron_Gate.JoinToMQTT);
            // 
            // topicInDataGridViewTextBoxColumn
            // 
            this.topicInDataGridViewTextBoxColumn.DataPropertyName = "TopicIn";
            this.topicInDataGridViewTextBoxColumn.HeaderText = "In topic";
            this.topicInDataGridViewTextBoxColumn.Name = "topicInDataGridViewTextBoxColumn";
            this.topicInDataGridViewTextBoxColumn.Width = 300;
            // 
            // lastInDataGridViewTextBoxColumn
            // 
            this.lastInDataGridViewTextBoxColumn.DataPropertyName = "LastIn";
            this.lastInDataGridViewTextBoxColumn.HeaderText = "Last value";
            this.lastInDataGridViewTextBoxColumn.Name = "lastInDataGridViewTextBoxColumn";
            // 
            // topicOutDataGridViewTextBoxColumn
            // 
            this.topicOutDataGridViewTextBoxColumn.DataPropertyName = "TopicOut";
            this.topicOutDataGridViewTextBoxColumn.HeaderText = "Out topic";
            this.topicOutDataGridViewTextBoxColumn.Name = "topicOutDataGridViewTextBoxColumn";
            this.topicOutDataGridViewTextBoxColumn.Width = 300;
            // 
            // lastOutDataGridViewTextBoxColumn
            // 
            this.lastOutDataGridViewTextBoxColumn.DataPropertyName = "LastOut";
            this.lastOutDataGridViewTextBoxColumn.HeaderText = "Last value";
            this.lastOutDataGridViewTextBoxColumn.Name = "lastOutDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 552);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Crestron to MQTT gate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabMQTT.ResumeLayout(false);
            this.tabMQTT.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabDigital.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabConfig.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDigital)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDigital)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMQTT;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabDigital;
        private System.Windows.Forms.TabPage tabAnalog;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDigital;
        private System.Windows.Forms.DataGridViewTextBoxColumn topicInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn topicOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsDigital;
    }
}

