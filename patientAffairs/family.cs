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
    public partial class family : Form
    {
        public family()
        {
            InitializeComponent();
        }
        public family(string name, string dgree,string type,string ssn,string adress,string phone)
        {
            InitializeComponent();
            textBoxname.Text = name;
            textBoxdgree.Text = dgree;
            textBoxtype.Text = type;
            textBoxssn.Text = ssn;
            textBoxadress.Text = adress;
            textBoxphone.Text = phone;
            
        }
        QueryClass ob = new QueryClass();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void family_Load(object sender, EventArgs e)
        {

        }
    }
}
