
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace patientAffairs
{
    public class QueryClass
    {

        static string server = Properties.Settings.Default.server;
        static string database = Properties.Settings.Default.db;
        static string query = @"Data Source="+server+";Initial Catalog ="+database+"; Integrated Security = True";

        SqlConnection con = new SqlConnection(query);
        SqlCommand com;
        SqlDataAdapter sqldata;
        DataTable dt;
        public bool fun_query(string query)
        {
            try
            {

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
        public bool fun_query(string query, byte[] image)
        {
            try
            {
                con.Close();
                con.Open();

                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@image", image);
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

        public DataTable fetch_query(string query)
        {
            try
            {
                con.Close();
                con.Open();
                sqldata = new SqlDataAdapter(query, con);
                dt = new DataTable();
                sqldata.Fill(dt);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            con.Close();
            return dt;
        }

        public void showdata(DataGridView datagrid, string query, int init, int end)
        {
            try
            {
                datagrid.Rows.Clear();
                DataTable dt = fetch_query(query);

                foreach (DataRow item in dt.Rows)
                {
                    int n = datagrid.Rows.Add();
                    for (int i = init, j = 0; i < end; i++, j++)
                    {
                        datagrid.Rows[n].Cells[j].Value = item[i].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void createpdf(DataGridView datagrid, string filename)
        {
            try
            {
                BaseFont bsf = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, true);
                PdfPTable pdftab = new PdfPTable(datagrid.Columns.Count - 1);


                pdftab.DefaultCell.Padding = 3;
                pdftab.WidthPercentage = 100;
                pdftab.HorizontalAlignment = Element.ALIGN_RIGHT;

                pdftab.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bsf, 10, iTextSharp.text.Font.NORMAL);



                foreach (DataGridViewColumn item in datagrid.Columns)
                {


                    PdfPCell cell = new PdfPCell(new Phrase(item.HeaderText, text));

                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);

                    pdftab.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    pdftab.AddCell(cell);

                }
                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    int i = 0;
                    foreach (DataGridViewCell cel in row.Cells)
                    {

                        if (row.Cells.Count - 1 > i)
                        {
                            pdftab.AddCell(new Phrase(cel.Value.ToString(), text));
                            pdftab.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                        }
                        i++;
                    }

                }

                var svfd = new SaveFileDialog();
                svfd.FileName = filename;
                svfd.DefaultExt = ".pdf";
                if (svfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream filst = new FileStream(svfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(doc, filst);
                        doc.Open();
                        doc.Add(pdftab);
                        doc.Close();
                        filst.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void createExcel(DataGridView datagrid, string name)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                worksheet = workbook.Sheets["sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "databaseSchool";
                for (int i = 1; i < datagrid.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = datagrid.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < datagrid.Rows.Count; i++)
                {
                    for (int j = 0; j < datagrid.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = datagrid.Rows[i].Cells[j].Value.ToString();
                    }

                }
                var safefile = new SaveFileDialog();
                safefile.FileName = name;
                safefile.DefaultExt = ".xlsx";
                if (safefile.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(safefile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }
                app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void openbrows(PictureBox pbox)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image file(*.png;*.jpg;*.bmp;*.gif;)|*.png;*.jpg;*.bmp;*.gif;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = new Bitmap(op.FileName);
            }
        }


        public byte[] savephote(PictureBox pbox)
        {
            MemoryStream memophoto = new MemoryStream();
            pbox.Image.Save(memophoto, pbox.Image.RawFormat);
            return memophoto.GetBuffer();
        }
        public void mainimize(Form f)
        {

            if (f.WindowState == FormWindowState.Normal)
            {
                f.WindowState = FormWindowState.Minimized;
            }
            if (f.WindowState == FormWindowState.Maximized)
            {
                f.WindowState = FormWindowState.Minimized;
            }
        }

    }
}
