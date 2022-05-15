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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(bool check)
        {
            InitializeComponent();
            button1.Enabled = check;
            button3.Enabled = check;
            button6.Enabled = check;
            button8.Enabled = check;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            users f = new users();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pateions f = new pateions();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchpatient f = new searchpatient();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tosuai f = new tosuai();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            patientDie f = new patientDie();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buckUp f = new buckUp();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            restore f = new restore();
            f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         settings f = new settings();
            f.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
