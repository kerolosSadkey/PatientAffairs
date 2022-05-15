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
    public partial class patientDie : Form
    {
        public patientDie()
        {
            InitializeComponent();
        }
        QueryClass ob = new QueryClass();
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




        //---------------------------------
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
                textBoxssn.Text = row["ssn"].ToString();
                dateTimePickerbdate.Text = row["brithdate"].ToString();
                textBoxweapon.Text = row["weapon"].ToString();
                textBoxposition.Text = row["position"].ToString();
                textBoxfathername.Text = row["fathername"].ToString();
                textBoxfatherssn.Text = row["fatherssn"].ToString();
                dateTimePickerfatherdate.Text = row["fatherbrithdate"].ToString();
              


            }
        }


        void cleartextbox()
        {
            id.Text = "";
            textBoxid.Text = "";
            textBoxname.Text = "";
            textBoxdgree.Text = "";
            textBoxssn.Text = "";
            textBoxweapon.Text = "";
            textBoxposition.Text = "";
            textBoxfathername.Text = "";
            textBoxfatherssn.Text = "";
          
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(textBoxssn.Text.Trim().Length != 14 || textBoxssn.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تاكد من كتابة الرقم القومي 14 رقم ", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into died (id_petient,diedate) values " +
           "(N'" + textBoxssn.Text + "',N'" +dateTimePickerdie.Text + "')";


            if (ob.fun_query(query))
            {
                MessageBox.Show("تم الحفظ بنجاح");
                string q = "select patient.* ,died.*  from patient join died on patient.ssn= died.id_petient";
                showdatagrid(q);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxssn.Text.Trim().Length != 14 || textBoxssn.Text.Trim().Length == 0)
            {
                MessageBox.Show(" تاكد من كتابة الرقم القومي 14 رقم ", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "update  died set diedate=N'" + dateTimePickerdie.Text + "'where id_petient='" + textBoxssn.Text+"'";


            if (ob.fun_query(query))
            {
                MessageBox.Show("تم التعديل بنجاح");
                string q = "select patient.* ,died.*  from patient join died on patient.ssn= died.id_petient";
                showdatagrid(q);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ownername = "";
            string ownerdgree = "";
            string ownertype = "";
            string ownerssn = "";
            string owneradress = "";
            string ownerphone = "";
            if (e.ColumnIndex == dataGridView1.Columns[18].Index && e.RowIndex >= 0)
            {



                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string query = "select ownername,ownerdgree,ownertype,ownerssn,owneradress,ownerphone from patient where id=" + id;

                DataTable dt = new DataTable();
                dt = ob.fetch_query(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MessageBox.Show(dt.Rows[i]["ownername"].ToString());
                    ownername = dt.Rows[i]["ownername"].ToString();
                    ownerdgree = dt.Rows[i]["ownerdgree"].ToString();
                    ownertype = dt.Rows[i]["ownertype"].ToString();
                    ownerssn = dt.Rows[i]["ownerssn"].ToString();
                    owneradress = dt.Rows[i]["owneradress"].ToString();
                    ownerphone = dt.Rows[i]["ownerphone"].ToString();
                }
                family f = new family(ownername, ownerdgree, ownertype, ownerssn, owneradress, ownerphone);
                f.Show();
            }

            if (e.ColumnIndex == dataGridView1.Columns[19].Index && e.RowIndex >= 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[ e.RowIndex]);
            }
        }
        private void patientDie_Load(object sender, EventArgs e)
        {
            string q = "select patient.* ,died.*  from patient join died on patient.ssn= died.id_petient";
            showdatagrid(q);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          

            DataTable dt = new DataTable();
            reportfullpatient f = new reportfullpatient();
            CrystalReportdied crs = new CrystalReportdied();
            crs.Load();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("dgree", typeof(string));
            dt.Columns.Add("ssn", typeof(string));
            dt.Columns.Add("birthdate", typeof(string));
            dt.Columns.Add("weapon", typeof(string));
            dt.Columns.Add("postion", typeof(string));
            dt.Columns.Add("fathername", typeof(string));
            dt.Columns.Add("fatherssn", typeof(string));
            dt.Columns.Add("fatherbirthdate", typeof(string));
            dt.Columns.Add("ownerdgree", typeof(string));
            dt.Columns.Add("ownername", typeof(string));
            dt.Columns.Add("ownerssn", typeof(string));
            dt.Columns.Add("ownertype", typeof(string));
            dt.Columns.Add("owneradress", typeof(string));
            dt.Columns.Add("ownerphone", typeof(string));
            dt.Columns.Add("dateentring", typeof(string));
            dt.Columns.Add("dateexit", typeof(string));
            dt.Columns.Add("leader1", typeof(string));
            dt.Columns.Add("leader2", typeof(string));
            dt.Columns.Add("tousitype", typeof(string));
            dt.Columns.Add("tousidate", typeof(string));
            dt.Columns.Add("tousitext", typeof(string));




            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dt.Rows.Add(dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value,
                            dataGridView1.Rows[i].Cells[4].Value, dataGridView1.Rows[i].Cells[5].Value, dataGridView1.Rows[i].Cells[6].Value,
                            dataGridView1.Rows[i].Cells[7].Value, dataGridView1.Rows[i].Cells[8].Value, dataGridView1.Rows[i].Cells[9].Value,
                            "", "", "", "", "", "", "", dataGridView1.Rows[i].Cells[11].Value, "", Properties.Settings.Default.leader2, Properties.Settings.Default.leader3, "", "", "");
            }

            crs.Database.Tables["DataTableSheet"].SetDataSource(dt);


            f.crystalReportViewer1.ReportSource = crs;
            f.crystalReportViewer1.Refresh();
            f.Show();
        }


        void showdatagrid(string q)
        {
            try
            {
                dataGridView1.Rows.Clear();
                DataTable dt = ob.fetch_query(q);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       

                        dataGridView1.Rows[n].Cells[0].Value = item["id"].ToString();
                        dataGridView1.Rows[n].Cells[1].Value = item["idaccount"].ToString();
                        dataGridView1.Rows[n].Cells[2].Value = item["name"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = item["dgree"].ToString();
                        dataGridView1.Rows[n].Cells[4].Value = item["ssn"].ToString();
                        dataGridView1.Rows[n].Cells[5].Value = item["brithdate"].ToString();
                        dataGridView1.Rows[n].Cells[6].Value = item["weapon"].ToString();
                        dataGridView1.Rows[n].Cells[7].Value = item["position"].ToString();
                        dataGridView1.Rows[n].Cells[8].Value = item["fathername"].ToString();
                        dataGridView1.Rows[n].Cells[9].Value = item["fatherssn"].ToString();
                        dataGridView1.Rows[n].Cells[10].Value = item["fatherbrithdate"].ToString();
                        dataGridView1.Rows[n].Cells[11].Value = item["diedate"].ToString();
                        dataGridView1.Rows[n].Cells[12].Value = item["ownername"].ToString();
                        dataGridView1.Rows[n].Cells[13].Value = item["ownerdgree"].ToString();
                        dataGridView1.Rows[n].Cells[14].Value = item["ownertype"].ToString();
                        dataGridView1.Rows[n].Cells[15].Value = item["ownerssn"].ToString();
                        dataGridView1.Rows[n].Cells[16].Value = item["owneradress"].ToString();
                        dataGridView1.Rows[n].Cells[17].Value = item["ownerphone"].ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ob.createExcel(dataGridView1, "report");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxname.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxdgree.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxssn.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePickerbdate.Text= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxweapon.Text= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxposition.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxfathername.Text= dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBoxfatherssn.Text= dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            dateTimePickerfatherdate.Text= dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            dateTimePickerdie.Text= dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
        }

        private void textBoxid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void textBoxname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar));
        }

        private void textBoxdgree_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar));
        }

        private void textBoxssn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void textBoxfathername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar));
        }

        private void textBoxfatherssn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }
    }
}
