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
    public partial class buckUp : Form
    {
        public buckUp()
        {
            InitializeComponent();
        }
        QueryClass ob = new QueryClass();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("يجب اختيار مسار الملف", "backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string db = Properties.Settings.Default.db;
            string namepath = textBox1.Text + "\\"+db+ DateTime.Now.ToShortDateString().Replace("/", "-") +
               DateTime.Now.ToShortTimeString().Replace(":", "-");
            string query = "BACKUP Database patient to DISK='" + namepath + ".bak'";

            if (ob.fun_query(query))
            {
                MessageBox.Show("تم انشاء نسخة احتياطية من الملف", "backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op.SelectedPath;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
