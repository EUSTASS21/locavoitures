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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace locavoiture
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=EEUSTASS;Initial Catalog=Voiture;Integrated Security=True;Encrypt=False");

        private void UserControl2_Load(object sender, EventArgs e)
        {
            showdata();
        }
        private void showdata()
        {
            conn.Open();
            string query = "select * from client ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            datagr.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (numero.Text == "" || nom.Text == "" || pren.Text == "" || ville.Text == "" || tele.Text == "" || email.Text == "")
            {
                MessageBox.Show("missing infos");
                conn.Close();
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "insert into client values ('" + numero.Text + "' , '" + nom.Text + "' , '" + pren.Text + "' , '" + ville.Text + "' , '" + tele.Text + "' , '" + email.Text + "') ";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("added");
                    showdata();


                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }
        }

        private void datagr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            numero.Text = datagr.SelectedRows[0].Cells[0].Value.ToString();
            nom.Text = datagr.SelectedRows[0].Cells[1].Value.ToString();
            pren.Text = datagr.SelectedRows[0].Cells[2].Value.ToString();
            ville.Text = datagr.SelectedRows[0].Cells[3].Value.ToString();
            tele.Text = datagr.SelectedRows[0].Cells[4].Value.ToString();
            email.Text = datagr.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (numero.Text == "")
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "delete from client where NumeroCli ='" + numero.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("deleted");
                    showdata();


                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (numero.Text == "" || nom.Text == "" || pren.Text == "" || ville.Text == "" || tele.Text == "" || email.Text == "")
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE client SET NumeroCli = '" + numero.Text + "' , nom = '" + nom.Text + "' , prenom = '" + pren.Text + "' , ville = '" + ville.Text + "' , tel = '" + tele.Text + "' , email = '" + email.Text + "' WHERE NumeroCli = '" + numero.Text + "'  ";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("UPDATED");
                    showdata();


                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.Text == "")
                {
                    conn.Open();
                    string query = "select * from client ";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    datagr.DataSource = ds.Tables[0];
                    conn.Close();

                }
                else
                {
                    conn.Open();
                    string query = "select * from client where NumeroCli = '" + search.Text + "' ";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
                    var ds = new DataSet();
                    sqlDataAdapter.Fill(ds);
                    datagr.DataSource = ds.Tables[0];
                    conn.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("le nombre doit etre un entier");
                conn.Close();

                
            }
 
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2ImageButton1.PerformClick();
            }
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            if (dataGridView == null || dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
            {
                MessageBox.Show("No data available to export.");
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;

                // Entête
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }

                // Contenu
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export réussi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            ExportToExcel(datagr);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(datagr);
        }
    }
}
