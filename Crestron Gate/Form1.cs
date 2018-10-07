using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gs.Save();
        }
    }
}
