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
    public partial class users : Form
    {

        QueryClass ob = new QueryClass();
        public users()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ob.mainimize(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string query = "";
            if (textBoxname.Text.Length == 0 && textBoxusername.Text.Length == 0 && textBoxpassword.Text.Length == 0)
            {
                MessageBox.Show("بعض حقول الادخال فارغة تاكد من املاءه", "notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            query = "insert into [user] (name,username,password,role) values " +
                "(N'" + textBoxname.Text + "',N'" + textBoxusername.Text + "',N'" + textBoxpassword.Text + "',N'" + comboBoxrole.Text + "')";
            if (ob.fun_query(query))
            {
                MessageBox.Show("save successfully");
                ob.showdata(dataGridView1, "select * from [user]", 0, 5);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string query = "";
            if (id.Text.Length == 0 && textBoxname.Text.Length == 0 && textBoxusername.Text.Length == 0 && textBoxpassword.Text.Length == 0)
            {
                MessageBox.Show("يجب اختيار المستخدم المراد تعديله", "notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            query = "update  [user] set name=N'" + textBoxname.Text + "',username=N'" + textBoxusername.Text + "',password = N'" + textBoxpassword.Text + "',role=N'" + comboBoxrole.Text + "' where id='" + id.Text+"'";

            if (ob.fun_query(query))
            {
                MessageBox.Show("update successfully");
                ob.showdata(dataGridView1, "select * from [user]", 0, 5);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query = "";
            if (e.ColumnIndex == dataGridView1.Columns[5].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("هل متاكد من حذف هذا المستخدم", "Message Rusult", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    query = "delete from [user] where id =" + dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    if (ob.fun_query(query))
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxusername.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBoxpassword.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxrole.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void textboxsreach_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                if (textboxsreach.Text.Length != 0)
                {
                    query = "SELECT * FROM [user] WHERE id LIKE '" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" +
                        "' OR name LIKE N'" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" +
                        "' OR username LIKE N'" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" +
                         "' OR role LIKE N'" + textboxsreach.Text + textboxsreach.Text.Substring(textboxsreach.Text.Length) + "%" + "'";



                }
                else
                {
                    query = "SELECT * FROM [user]";
                }

                ob.showdata(dataGridView1, query, 0, 5);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            id.Text = "";
            textBoxname.Text = "";
            textBoxusername.Text = "";
            textBoxpassword.Text = "";
            comboBoxrole.Text = "";

        }

        private void users_Load(object sender, EventArgs e)
        {
            ob.showdata(dataGridView1, "SELECT * FROM [user]", 0, 5);
        }
    }
    }
