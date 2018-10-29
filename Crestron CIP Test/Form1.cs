using System;
using System.Windows.Forms;
using Balabolin.Utils;

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
            //client = new Balabolin.Crestron.CIPClient("192.168.100.100", 0x12);
            client = new Balabolin.Crestron.CIPClient("127.0.0.1", 0x12);
            client.Debug += new EventHandler<StringEventArgs>(Crestron_Debug);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.ConnectToServer();
            if (!client.Connected) UpdateMainTextbox("Failed to connect!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.UpdateRequest();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            client.SendAnalogue(1, (ushort)numericUpDown1.Value);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            client.SendDigital(1, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.SendDigital(1, true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            client.SendSerial(2, textBox1.Text);
        }
    }
}
