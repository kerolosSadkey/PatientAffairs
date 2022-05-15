using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patientAffairs
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }
        QueryClass ob = new QueryClass();
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settingdb f = new settingdb();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            globaleName f = new globaleName();
            f.Show();
        }
    }
}
