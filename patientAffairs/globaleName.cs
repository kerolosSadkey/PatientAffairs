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
    public partial class globaleName : Form
    {
        public globaleName()
        {
            InitializeComponent();
        }
        QueryClass ob = new QueryClass();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void globaleName_Load(object sender, EventArgs e)
        {

            textBox1.Text = Properties.Settings.Default.leader1;
            textBox2.Text = Properties.Settings.Default.leader2;
            textBox3.Text = Properties.Settings.Default.leader3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
              Properties.Settings.Default.leader1= textBox1.Text;
            Properties.Settings.Default.leader2= textBox2.Text;
             Properties.Settings.Default.leader3= textBox3.Text ;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم التعديل بنجاح");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
