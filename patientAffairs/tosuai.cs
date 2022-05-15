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
    public partial class tosuai : Form
    {
        public tosuai()
        {
            InitializeComponent();
        }

        QueryClass ob = new QueryClass();
        void showdata(string q)
        {
            cleartextbox();
            DataTable dt = ob.fetch_query(q);
            foreach (DataRow row in dt.Rows)
            {

                id.Text = row["id"].ToString();
                textBoxid.Text = row["idaccount"].ToString();
                textBoxname.Text = row["name"].ToString();
                textBoxdgree.Text = row["dgree"].ToString();
  
                textBoxweapon.Text = row["weapon"].ToString();
                dateTimePickerentring.Text = row["dateentring"].ToString();
                dateTimePickerexit.Text = row["dateexit"].ToString();
                dateTimePicker3.Text = row["tousidate"].ToString();




            }
        }
        void cleartextbox()
        {
            id.Text = "";
            textBoxid.Text = "";
            textBoxname.Text = "";
            textBoxdgree.Text = "";
            textBoxweapon.Text = "";
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                if (textboxsreach.Text.Length != 0)
                {
                    query = "SELECT * FROM patient WHERE name LIKE N'" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" +
                        "'OR ssn LIKE N'" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" +
                        "'OR ownerssn LIKE N'" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" + " LIMIT 1 '";



                }
                else
                {
                    query = "SELECT * FROM patient where id=0";
                }


                this.showdata(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            string id = textBoxid.Text;
            string name = textBoxname.Text;
            string dgree = textBoxdgree.Text;
            string section = comboBoxsection.Text;
            string weapon = textBoxweapon.Text;
            
            string status = comboBoxstetus.Text;
            string tousai = comboBoxtosuai.Text;
            string dateentring = dateTimePickerentring.Text;
            string dateexit = dateTimePickerexit.Text;

            if (!dateTimePickerexit.Visible)
            {
                dateexit = "";

            }
                 this.dataGridView1.Rows.Add(id, name, dgree, section, weapon, status,tousai,dateentring,dateexit);

             textBoxid.Text="";
             textBoxname.Text="";
             textBoxdgree.Text="";
             comboBoxsection.Text="";
             textBoxweapon.Text="";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[9].Index && e.RowIndex >= 0)
            {

                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
         //   DataTable dt1 = new DataTable();
           
            reportTousia f = new reportTousia();
            CrystalReport1 crs = new CrystalReport1();
            crs.Load();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("dgree", typeof(string));
            dt.Columns.Add("section", typeof(string));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("report", typeof(string));
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("weapon", typeof(string));
            dt.Columns.Add("leader1", typeof(string));
            dt.Columns.Add("leader2", typeof(string));
            dt.Columns.Add("dateentring", typeof(string));
            dt.Columns.Add("dateexit", typeof(string));
            


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value,
                            dataGridView1.Rows[i].Cells[3].Value, dataGridView1.Rows[i].Cells[5].Value, dataGridView1.Rows[i].Cells[6].Value
                        ,dateTimePicker3.Text, dataGridView1.Rows[i].Cells[4].Value, Properties.Settings.Default.leader2, Properties.Settings.Default.leader3,
                           dataGridView1.Rows[i].Cells[7].Value, dataGridView1.Rows[i].Cells[8].Value);
            }

            crs.Database.Tables["DataTablereport"].SetDataSource(dt);


            f.crystalReportViewer1.ReportSource = crs;
            f.crystalReportViewer1.Refresh();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePickerexit.Visible = true;
            }
            else
            {
                dateTimePickerexit.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dateTimePickerexit.Visible = false;
            }
            else
            {
                dateTimePickerexit.Visible = true;
            }
        }

        private void tosuai_Load(object sender, EventArgs e)
        {
            dateTimePickerexit.Visible = false;
        }

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxname_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBoxdgree_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxid_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
