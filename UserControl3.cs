using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using TheArtOfDevHtmlRenderer.Adapters;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace locavoiture
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=EEUSTASS;Initial Catalog=Voiture;Integrated Security=True;Encrypt=False");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }
        private void showdata()
        {
            conn.Open();
            string query = "select * from reservation ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            datagr.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (numero.Text == "" || mat.Text == "" || datd.Text == "" || datf.Text == "" || mont.Text == "" || stat.Text == "" )
            {
                MessageBox.Show("missing infos");
                conn.Close();
            }
            else if (DateTime.Parse(datd.Text) > DateTime.Parse(datf.Text))
            {
                MessageBox.Show("date debut > date fin");
                conn.Close();

            }
            else
            {
                try
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM reservation WHERE Matricule = '"+mat.Text+"' AND ('"+datd.Text+ "' <= Date_F AND '"+datf.Text+"' >= Date_D)";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);

                    int conflictingReservations = (int)checkCmd.ExecuteScalar();
                    conn.Close();

                    if (conflictingReservations > 0)
                    {
                        MessageBox.Show("La voiture est déjà réservée pendant cette période.");
                        return;
                    }
               
                    else 
                    {
                        conn.Open();
                        string query = "insert into reservation values ('" + numero.Text + "' , '" + mat.Text + "' , '" + datd.Text + "' , '" + datf.Text + "' , '" + mont.Text + "' , '" + stat.Text + "') ";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("added");
                        showdata();
                        if (stat.Text == "accepté")
                        {
                            conn.Open();
                            string query2 = "update voiture set disponible = 'non' where Matricule = '" + mat.Text + "' ";
                            SqlCommand cmd2 = new SqlCommand(query2, conn);

                            cmd2.ExecuteNonQuery();
                            conn.Close();
                        }
                    }




                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            showdata();
        }

        private void datagr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            numero.Text = datagr.SelectedRows[0].Cells[0].Value.ToString();
            mat.Text = datagr.SelectedRows[0].Cells[1].Value.ToString();
            datd.Text = datagr.SelectedRows[0].Cells[2].Value.ToString();
            datf.Text = datagr.SelectedRows[0].Cells[3].Value.ToString();
            mont.Text = datagr.SelectedRows[0].Cells[4].Value.ToString();
            stat.Text = datagr.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (numero.Text == "" )
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "delete from reservation where NumeroCli ='" + numero.Text + "' and Matricule ='" + mat.Text + "' ";
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
            if (numero.Text == "" || mat.Text == "" || datd.Text == "" || datf.Text == "" || mont.Text == "" || stat.Text == "")
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {

                        conn.Open();

                        string query = "UPDATE reservation SET NumeroCli = '" + numero.Text + "' , Matricule = '" + mat.Text + "' , date_D = '" + datd.Text + "' , date_F = '" + datf.Text + "' , Montant = '" + mont.Text + "' , status = '" + stat.Text + "' WHERE NumeroCli = '" + numero.Text + "'  ";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("UPDATED");
                        showdata();
                        if (stat.Text == "accepté")
                        {
                            conn.Open();
                            string query2 = "update voiture set disponible = 'non' where Matricule = '" + mat.Text + "' ";
                            SqlCommand cmd2 = new SqlCommand(query2, conn);

                            cmd2.ExecuteNonQuery();
                            conn.Close();
                        }
                    



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
            try { 
            if (search.Text == "")
            {
                conn.Open();
                string query = "select * from reservation ";
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
                string query = "select * from reservation where NumeroCli = '" + search.Text + "' ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
                var ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                datagr.DataSource = ds.Tables[0];
                conn.Close();
            }
            }catch(Exception) 
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
