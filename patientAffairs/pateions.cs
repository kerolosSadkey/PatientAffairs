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
    public partial class pateions : Form
    {
        public pateions()
        {
            InitializeComponent();
        }
        QueryClass ob = new QueryClass();
        private void textBox13_TextChanged(object sender, EventArgs e)
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

        private void pateions_Load(object sender, EventArgs e)
        {
            ob.showdata(dataGridView1, "select * from patient", 0,22);
            dateTimePickerexit.Visible = false;

            textBoxid.Text = getidaccount();
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ownername ="";
            string ownerdgree = "";
            string ownertype = "";
            string ownerssn = "";
            string owneradress = "";
            string ownerphone = "";
            if (e.ColumnIndex == dataGridView1.Columns[22].Index && e.RowIndex >= 0)
            {

                

               string id= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string query="select ownername,ownerdgree,ownertype,ownerssn,owneradress,ownerphone from patient where id="+id;

                DataTable dt = new DataTable();
                dt = ob.fetch_query(query);

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    MessageBox.Show(dt.Rows[i]["ownername"].ToString());
                    ownername = dt.Rows[i]["ownername"].ToString();
                     ownerdgree = dt.Rows[i]["ownerdgree"].ToString();
                     ownertype = dt.Rows[i]["ownertype"].ToString();
                     ownerssn = dt.Rows[i]["ownerssn"].ToString();
                     owneradress = dt.Rows[i]["owneradress"].ToString();
                     ownerphone = dt.Rows[i]["ownerphone"].ToString();
                }
                family f = new family(ownername,ownerdgree,ownertype,ownerssn,owneradress,ownerphone);
                f.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string idaccount = textBoxid.Text;
            string name = textBoxname.Text;
            string dgree = textBoxdgree.Text;
            string ssn = textBoxssn.Text;
            string brithdate = dateTimePickerbdate.Text;
            string weapon = textBoxweapon.Text;
            string position = textBoxposition.Text;
            string fathername = textBoxfathername.Text;
            string fatherssn = textBoxfatherssn.Text;
            string fatherbrithdate = dateTimePickerfatherdate.Text;
            string ownername = textBoxownername.Text;
            string ownerdgree = textBoxonweradress.Text;
            string ownertype = textBoxonwertype.Text;
            string ownerssn = textBoxonwerssn.Text;
            string owneradress = textBoxonweradress.Text;
            string ownerphone = textBoxownerphone.Text;
            string dateentring = dateTimePickerentring.Text;
            string dateexit = dateTimePickerexit.Text;
            string tousitype = comboBoxtousi.Text;
            string tousidate= dateTimePickertousi.Text;
            string tousitext = textBoxtousi.Text;

           if(ssn.Trim().Length != 14  || ssn.Trim().Length ==0)
            {
                MessageBox.Show(" تاكد من كتابة الرقم القومي 14 رقم ", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!dateTimePickerexit.Visible)
            {
                dateexit = "";

            }
           string query= "insert into patient (idaccount,name,dgree,ssn,brithdate,weapon,position,fathername," +
                "fatherssn,fatherbrithdate,tousitype,tousidate,tousitext,ownername,ownerdgree,ownertype," +
                "ownerssn,owneradress,ownerphone,dateentring,dateexit) values " +
            "(N'" + idaccount + "',N'" + name + "',N'" +dgree + "',N'" + ssn + "',N'" + brithdate + "',N'" + weapon +
            "',N'" + position + "',N'" + fathername + "',N'" + fatherssn + "',N'" +fatherbrithdate + "',N'"+tousitype + "',N'" + tousidate +
            "',N'" + tousitext  + "',N'" + ownername +"',N'" + ownerdgree + "',N'" + ownertype + "',N'" + ownerssn + "',N'" + owneradress +
            "',N'" + ownerphone  + "',N'" + dateentring + "',N'" + dateexit + "')";

            if (ob.fun_query(query))
            {
                MessageBox.Show("تم الحفظ بنجاح");
                ob.showdata(dataGridView1, "select * from patient", 0, 22);
            }
            
        }

        private void textBoxssn_TextChanged(object sender, EventArgs e)
        {
            long num; 
            if (textBoxssn.Text.Length == 14 && long.TryParse(textBoxssn.Text, out num))
            {
                string n = textBoxssn.Text.Substring(0, 1);
                string yy = textBoxssn.Text.Substring(1, 2);
                int mm = int.Parse(textBoxssn.Text.Substring(3, 2));
                int dd = int.Parse(textBoxssn.Text.Substring(5, 2));
                if (n == "2")
                {
                    if(mm > 12 || dd > 31 )
                    {
                        MessageBox.Show(" تاكد من كتابة الرقم القومي بشكل صحيح", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxssn.Text = "";
                        return;
                    }
                    dateTimePickerbdate.Value = DateTime.Parse( "19" + yy + "/" + mm + "/" + dd);
                }
                else if (n == "3")
                {
                    if (mm > 12 || dd > 31)
                    {
                        MessageBox.Show(" تاكد من كتابة الرقم القومي بشكل صحيح", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxssn.Text = "";
                        return;
                    }
                    dateTimePickerbdate.Value = DateTime.Parse("20" + yy + "/" + mm + "/" + dd);
                }
                else
                {
                    MessageBox.Show(" تاكد من كتابة الرقم القومي بشكل صحيح 14رقم", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            if(textBoxssn.Text.Length > 14)
            {
                MessageBox.Show(" يجب الرقم القومي 14رقم", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string st = textBoxssn.Text.Substring(0, 14);
                textBoxssn.Text = st;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            string idaccount = textBoxid.Text;
            string name = textBoxname.Text;
            string dgree = textBoxdgree.Text;
            string ssn = textBoxssn.Text;
            string brithdate = dateTimePickerbdate.Text;
            string weapon = textBoxweapon.Text;
            string position = textBoxposition.Text;
            string fathername = textBoxfathername.Text;
            string fatherssn = textBoxfatherssn.Text;
            string fatherbrithdate = dateTimePickerfatherdate.Text;
            string ownername = textBoxownername.Text;
            string ownerdgree = textBoxownerdgree.Text;
            string ownertype = textBoxonwertype.Text;
            string ownerssn = textBoxonwerssn.Text;
            string owneradress = textBoxonweradress.Text;
            string ownerphone = textBoxownerphone.Text;
            string dateentring = dateTimePickerentring.Text;
            string dateexit = dateTimePickerexit.Text;
            string tousitype = comboBoxtousi.Text;
            string tousidate = dateTimePickertousi.Text;
            string tousitext = textBoxtousi.Text;
            if (ssn.Length != 14)
            {
                MessageBox.Show(" تاكد من كتابة الرقم القومي 14 رقم ", "notifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!dateTimePickerexit.Visible)
            {
                dateexit = "";

            }
            string query = "update  patient set idaccount=N'" + idaccount + "',name=N'" + name + "',dgree=N'" + dgree + "',ssn= N'" +
            ssn + "',brithdate = N'" + brithdate + "',weapon= N'" + weapon + "',position= N'" + position + "',fathername= N'" + fathername
            + "',fatherssn= N'" + fatherssn + "',fatherbrithdate= N'" + fatherbrithdate + "',ownername= N'" + ownername +
             "',ownerdgree= N'" + ownerdgree + "',ownertype= N'" + ownertype + "',ownerssn= N'" + ownerssn + "',owneradress= N'" + owneradress
             + "',ownerphone= N'" + ownerphone + "',dateentring= N'" + dateentring + "',tousitype= N'" + tousitype+ "',tousidate= N'" +tousidate+
             "',tousitext= N'" + tousitext+ "',dateexit= N'" + dateexit + "' where ssn='" + ssn + "'";


            if (ob.fun_query(query))
            {
                MessageBox.Show("تم التعديل بنجاح");
                ob.showdata(dataGridView1, "select * from patient", 0,22);
            }
        }

        private void textBoxfatherssn_TextChanged(object sender, EventArgs e)
        {
           
            

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxdgree.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxssn.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePickerbdate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxweapon.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxposition.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxfathername.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBoxfatherssn.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            dateTimePickerfatherdate.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
            comboBoxtousi.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            dateTimePickertousi.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            textBoxtousi.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            textBoxownername.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            textBoxownerdgree.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            
            textBoxonwertype.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                textBoxonwerssn.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                textBoxonweradress.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
            textBoxownerphone.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
                dateTimePickerentring.Text= dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
                dateTimePickerexit.Text= dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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


        void showdata(string q)
        {
            cleartextbox();
            DataTable dt = ob.fetch_query(q);
            foreach (DataRow row in dt.Rows)
            {
                
                
                textBoxid.Text = row["idaccount"].ToString();
                textBoxname.Text = row["name"].ToString();
                 textBoxdgree.Text= row["dgree"].ToString();
                textBoxssn.Text= row["ssn"].ToString();
                dateTimePickerbdate.Text=row["brithdate"].ToString();
                textBoxweapon.Text = row["weapon"].ToString();
                 textBoxposition.Text = row["position"].ToString();
                 textBoxfathername.Text = row["fathername"].ToString();
                textBoxfatherssn.Text = row["fatherssn"].ToString();
                 dateTimePickerfatherdate.Text = row["fatherbrithdate"].ToString();
                textBoxownername.Text = row["ownername"].ToString();
                textBoxownerdgree.Text = row["ownerdgree"].ToString();
                 textBoxonwertype.Text = row["ownertype"].ToString();
                 textBoxonwerssn.Text = row["ownerssn"].ToString();
                 textBoxonweradress.Text = row["owneradress"].ToString();
                 textBoxownerphone.Text = row["ownerphone"].ToString();
                 dateTimePickerentring.Text = row["dateentring"].ToString();
                 dateTimePickerexit.Text = row["dateexit"].ToString();
                 comboBoxtousi.Text = row["tousitype"].ToString();
                dateTimePickertousi.Text = row["tousidate"].ToString();
                textBoxtousi.Text = row["tousitext"].ToString();


            }
        }


        void cleartextbox()
        {
            textBoxid.Text = "";
            textBoxname.Text = "";
            textBoxdgree.Text = "";
            textBoxssn.Text ="";
            
            textBoxweapon.Text = "";
            textBoxposition.Text ="";
            textBoxfathername.Text = "";
            textBoxfatherssn.Text = "";
            textBoxownername.Text = "";
            textBoxownerdgree.Text = "";
            textBoxonwertype.Text = "";
            textBoxonwerssn.Text = "";
            textBoxonweradress.Text = "";
            textBoxownerphone.Text = "";
            comboBoxtousi.Text = "";
            textBoxtousi.Text = "";
            textBoxid.Text = getidaccount();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cleartextbox();
        }
       
        string getidaccount()
        {
            string q = "select top 1 idaccount from patient order by  idaccount DESC";
            string a = "";
            DataTable dt = new DataTable();
            dt = ob.fetch_query(q);
            if (dt.Rows.Count > 0)
                a = dt.Rows[0]["idaccount"].ToString();
            else
                a = "000000";

            for(int i=0;i<1; i++)
            {
                string val = a.Substring(1, a.Length - 1);
                int num = Int32.Parse(val)+1;
                a = num.ToString("000000");
            }
            return a;
        }

        private void textBoxssn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
        }

        private void textBoxname_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBoxfathername_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBoxfatherssn_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxonwerssn_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBoxownerdgree_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxownername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxfathername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxonweradress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
