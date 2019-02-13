using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace Crestron_Gate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        GateSettings gs = new Crestron_Gate.GateSettings();

        private void Form1_Load(object sender, EventArgs e)
        {
            //gs.Reload();                        
            propertyGrid1.SelectedObject = gs;
            var botClient = new TelegramBotClient("1234567:4TT8bAc8GHUspu3ERYn-KGcvsvGB9u_n4ddy");
            var me = botClient.GetMeAsync().Result;
            richTextBox1.AppendText($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gs.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
