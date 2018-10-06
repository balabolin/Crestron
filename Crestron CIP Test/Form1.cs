using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Balabolin;

namespace Crestron_CIP_Test
{
    public partial class Form1 : Form
    {
        Balabolin.Crestron.CIPClient client;

        void UpdateMainTextbox(string s)
        {
            if (richTextBox1.InvokeRequired)
                richTextBox1.BeginInvoke(new Action<string>(UpdateMainTextbox), new object[] { s });
            else
                richTextBox1.AppendText(s + "\n");
        }


        void Crestron_Debug(object sender, StringEventArgs e)
        {
            UpdateMainTextbox(e.val);
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Balabolin.Crestron.CIPClient("192.168.100.100", 0x12);
            client.Debug += new EventHandler<StringEventArgs>(Crestron_Debug);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.ConnectToServer();
        }
    }
}
