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
    public partial class login : Form
    {
        public login()
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

        private void login_Load(object sender, EventArgs e)
        {
          
            if (!Properties.Settings.Default.server.Contains(System.Environment.MachineName))
            {
                settingdb f = new settingdb();
                f.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            String query = "select * from [user] where username=N'" + textBox1.Text + "' AND password=N'" + textBox2.Text + "'";
            DataTable dt = ob.fetch_query(query);
            try
            {


                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        if (dtrow["role"].ToString() == "Admin")
                        {
                            Form1 f = new Form1(true);
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form1 f = new Form1();
                            f.Show();
                            this.Hide();
                        }
                    }




                }
                else
                {
                    MessageBox.Show("     password او username يوجد خطاء في ", "notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
