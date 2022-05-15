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
    public partial class searchpatient : Form
    {
        public searchpatient()
        {
            InitializeComponent();
        }
        QueryClass ob = new QueryClass();
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                if (textBoxSearch.Text.Length != 0)
                {
                    query = "SELECT * FROM patient WHERE name LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR ssn LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR dgree LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR dateentring LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR dateexit LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR weapon LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR position LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR tousitext LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" +
                        "'OR ownerssn LIKE N'" + textBoxSearch.Text + textBoxSearch.Text.Substring(textBoxSearch.Text.Length) + "%" + "'";



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



        void showdata(string q)
        {
            dataGridView1.Rows.Clear();
            DataTable dt = ob.fetch_query(q);
            foreach (DataRow row in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = row["idaccount"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = row["name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = row["dgree"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = row["ssn"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = row["brithdate"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = row["weapon"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = row["position"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = row["fathername"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = row["fatherssn"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = row["fatherbrithdate"].ToString();
                dataGridView1.Rows[n].Cells[10].Value = row["ownerdgree"].ToString();
                dataGridView1.Rows[n].Cells[11].Value = row["ownername"].ToString();
                dataGridView1.Rows[n].Cells[12].Value = row["ownerssn"].ToString();
                dataGridView1.Rows[n].Cells[13].Value = row["ownertype"].ToString();
          
                dataGridView1.Rows[n].Cells[14].Value = row["owneradress"].ToString();
                dataGridView1.Rows[n].Cells[15].Value = row["ownerphone"].ToString();
                dataGridView1.Rows[n].Cells[16].Value = row["dateentring"].ToString();
                dataGridView1.Rows[n].Cells[17].Value = row["dateexit"].ToString();
                dataGridView1.Rows[n].Cells[18].Value = row["tousidate"].ToString();
                dataGridView1.Rows[n].Cells[19].Value = row["tousitext"].ToString();


            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //   DataTable dt1 = new DataTable();

            reportSheet f = new reportSheet();
            CrystalReportsheet crs = new CrystalReportsheet();
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
            dt.Columns.Add("onwertype", typeof(string));
            dt.Columns.Add("onweradress", typeof(string));
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
                dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value,
                            dataGridView1.Rows[i].Cells[3].Value, dataGridView1.Rows[i].Cells[4].Value, dataGridView1.Rows[i].Cells[5].Value,
                            dataGridView1.Rows[i].Cells[6].Value, dataGridView1.Rows[i].Cells[7].Value, dataGridView1.Rows[i].Cells[8].Value,
                            dataGridView1.Rows[i].Cells[9].Value, dataGridView1.Rows[i].Cells[10].Value, dataGridView1.Rows[i].Cells[11].Value,
                            dataGridView1.Rows[i].Cells[12].Value, dataGridView1.Rows[i].Cells[13].Value, dataGridView1.Rows[i].Cells[14].Value,
                            dataGridView1.Rows[i].Cells[15].Value, dataGridView1.Rows[i].Cells[16].Value, dataGridView1.Rows[i].Cells[17].Value
                        ,Properties.Settings.Default.leader1, Properties.Settings.Default.leader2,"", dataGridView1.Rows[i].Cells[18].Value,
                            dataGridView1.Rows[i].Cells[19].Value);
            }

            crs.Database.Tables["DataTableSheet"].SetDataSource(dt);


            f.crystalReportViewer1.ReportSource = crs;
            f.crystalReportViewer1.Refresh();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ownername = "";
            string ownerdgree = "";
            string ownertype = "";
            string ownerssn = "";
            string owneradress = "";
            string ownerphone = "";
            if (e.ColumnIndex == dataGridView1.Columns[20].Index && e.RowIndex >= 0)
            {



                string id = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string query = "select ownername,ownerdgree,ownertype,ownerssn,owneradress,ownerphone from patient where ssn=" + id;

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

            /*******************to delete item***********************/
            string q = "";
            if (e.ColumnIndex == dataGridView1.Columns[21].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("هل متاكد من حذف هذا المستخدم", "Message Rusult", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    q = "delete from patient where ssn =" + dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                    if (ob.fun_query(q))
                    {
                        MessageBox.Show("تم الحذف بنجاح", "Message Rusult", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);

                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            reportfullpatient f = new reportfullpatient();
            CrystalReportfullpatient crs = new CrystalReportfullpatient();
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
                dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value,
                            dataGridView1.Rows[i].Cells[3].Value, dataGridView1.Rows[i].Cells[4].Value, dataGridView1.Rows[i].Cells[5].Value,
                            dataGridView1.Rows[i].Cells[6].Value, dataGridView1.Rows[i].Cells[7].Value, dataGridView1.Rows[i].Cells[8].Value,
                            "", "","","","","","", dataGridView1.Rows[i].Cells[10].Value, "",Properties.Settings.Default.leader2, Properties.Settings.Default.leader3, "", "",""  );
            }

            crs.Database.Tables["DataTableSheet"].SetDataSource(dt);


            f.crystalReportViewer1.ReportSource = crs;
            f.crystalReportViewer1.Refresh();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ob.createExcel(dataGridView1, "report");
        }
    }
}
