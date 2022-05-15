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
    public partial class settingdb : Form
    {
        public settingdb()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxserver.Text.Length != 0 && textBoxdb.Text.Length != 0)
            {
                Properties.Settings.Default.server = textBoxserver.Text.Trim();
                Properties.Settings.Default.db = textBoxdb.Text.Trim();
                Properties.Settings.Default.mode = radioButton2.Checked == true ? "SQL" : "Windows";
                Properties.Settings.Default.username = textBoxusername.Text;
                Properties.Settings.Default.password = textBoxpassword.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("save successfully", "messaage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void settingdb_Load(object sender, EventArgs e)
        {
            textBoxserver.Text = Properties.Settings.Default.server;
            textBoxdb.Text = Properties.Settings.Default.db;
            if (Properties.Settings.Default.mode == "SQL")
            {
                radioButton2.Checked = true;
                textBoxusername.Text = Properties.Settings.Default.username;
                textBoxpassword.Text = Properties.Settings.Default.password;
            }
            else
            {
                radioButton1.Checked = true;
                textBoxusername.Clear();
                textBoxpassword.Clear();

                textBoxusername.ReadOnly = true;
                textBoxpassword.ReadOnly = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            textBoxusername.ReadOnly = true;
            textBoxpassword.ReadOnly = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxusername.Clear();
            textBoxpassword.Clear();
            textBoxusername.ReadOnly = false;
            textBoxpassword.ReadOnly = false;
        }
        string getnameserver()
        {
            return "";
        }
    }
}
