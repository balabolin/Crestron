using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balabolin.Crestron.Gate
{
    public partial class CrestronConfig : Form
    {
        public CrestronConfig()
        {
            InitializeComponent();
        }

        public void SetSettings(GateSettings gs)
        {
            propertyGrid1.SelectedObject = gs;
        }

        private void CrestronConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
