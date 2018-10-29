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
using Balabolin.Crestron;

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



        private void OnConnect()
        {
            panel1.BackColor = Color.Green;
        }

        private void OnDisconnect()
        {
            panel1.BackColor = Color.Red;
        }

        GateSettings gs = new Crestron_Gate.GateSettings();
        CIPClient cipClient = null;
        List<JoinToMQTT>  Digitals;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Digitals = new List<JoinToMQTTItem>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<JoinToMQTT>));
            try
            {
                using (FileStream fs = new FileStream("Digitals.xml", FileMode.OpenOrCreate))
                {
                    Digitals = (List<JoinToMQTT>)formatter.Deserialize(fs);
                }
            }
            catch 
            {
                Digitals = new List<JoinToMQTT>();
            }
            bsDigital.DataSource = Digitals;
            //joinToMQTTItemBindingSource.DataSource = Digitals;
            

            //gs.Reload();                        
            propertyGrid1.SelectedObject = gs;
            if (gs!=null)
            {
                cipClient = new CIPClient(gs.CrestronIP, (byte)Convert.ToInt32(gs.CrestronPID,16));
                cipClient.OnСonnect += OnConnect;
                cipClient.OnDisconnect += OnDisconnect;
                cipClient.ConnectToServer();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<JoinToMQTT>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Digitals.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Digitals);

                Console.WriteLine("Объект сериализован");
            }
            gs.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {/*
            object head = this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        */}

        private void dgvDigital_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object head = this.dgvDigital.Rows[e.RowIndex].HeaderCell.Value;
            if (head == null ||
               !head.Equals((e.RowIndex + 1).ToString()))
                this.dgvDigital.Rows[e.RowIndex].HeaderCell.Value =
                   (e.RowIndex + 1).ToString();
        }
    }
}
