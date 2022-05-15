using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace patientAffairs
{
    public partial class restore : Form
    {
        public restore()
        {
            InitializeComponent();
        }
        static string server = Properties.Settings.Default.server;
        static string conn = @"Data Source=" + server + ";Initial Catalog =master; Integrated Security = True";
        SqlConnection con = new SqlConnection(conn);
        SqlCommand com;

        QueryClass ob = new QueryClass();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("يجب اختيار مسار الملف", "restore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string qeury = "ALTER DATABASE patient SET OFFLINE WITH ROLLBACK IMMEDIATE; Restore Database patient from DISK='" + textBox1.Text + "'";

            if (fun_query(qeury))
            {
                MessageBox.Show(" تم استعادة نسخة احتياطية في البرنامج ", "Restor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool fun_query(string query)
        {
            try
            {
                con.Close();
                con.Open();

                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op.FileName;
            }
        }
    }
}
