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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=EEUSTASS;Initial Catalog=Voiture;Integrated Security=True;Encrypt=False");
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.voitureTableAdapter.FillBy(this.voitureDataSet.voiture);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            voituredata();
        }
        private void voituredata()
        {
            conn.Open();
            string query = "select * from voiture ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn);
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            datagr.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (mat.Text == "" || mod.Text == "" || mar.Text == "" || km.Text == "" || carb.Text == "" || dis.Text == "")
            {
                MessageBox.Show("incomplet infos");
            }
            else
            {
                try
                {
                    conn.Open();
                   
                    string query = "insert into voiture values ('" + mat.Text + "' , '" + mod.Text + "' , '" + mar.Text + "' , '" + km.Text + "' , '" + carb.Text + "' , '" + disp.Text + "') ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("added");
                    voituredata();


                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }
        }


        private void mat_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (mat.Text == "")
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "delete from voiture where Matricule ='"+mat.Text+"' ";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("deleted");
                    voituredata();


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
            if (mat.Text == "" || mod.Text == "" || mar.Text == "" || km.Text == "" || carb.Text == "" || dis.Text == "")
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE voiture SET Matricule = '" + mat.Text + "' , modele = '" + mod.Text + "' , marque = '" + mar.Text + "' , km = '" + km.Text + "' , carburant = '" + carb.Text + "' , disponible = '" + disp.Text + "' WHERE Matricule = '"+mat.Text+"'  ";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("UPDATED");
                    voituredata();
                    


                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }

        }



        private void datagr_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            mat.Text = datagr.SelectedRows[0].Cells[0].Value.ToString();
            mod.Text = datagr.SelectedRows[0].Cells[1].Value.ToString();
            mar.Text = datagr.SelectedRows[0].Cells[2].Value.ToString();
            km.Text = datagr.SelectedRows[0].Cells[3].Value.ToString();
            carb.Text = datagr.SelectedRows[0].Cells[4].Value.ToString();
            disp.Text = datagr.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (search.Text == "")
            {
                conn.Open();
                string query = "select * from voiture ";
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
                string query = "select * from voiture where marque = '" + search.Text + "' or Matricule = '" + search.Text + "' or disponible = '" + search.Text + "' or modele = '" + search.Text + "' ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
                var ds = new DataSet();
                sqlDataAdapter.Fill(ds);
                datagr.DataSource = ds.Tables[0];
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

        private void UserControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            voituredata();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string Query = " UPDATE voiture SET disponible = 'oui'";
                SqlCommand Cmd = new SqlCommand(Query, conn);
                Cmd.ExecuteNonQuery();
                string Query2 = " UPDATE voiture  SET disponible = 'non' WHERE EXISTS (SELECT 1  FROM reservation    WHERE voiture.Matricule = reservation.Matricule AND (reservation.date_F > '"+dated.Text+ "' and reservation.date_D < '"+datef.Text+"'))";
                SqlCommand Cmd2 = new SqlCommand(Query2, conn);
                Cmd2.ExecuteNonQuery();

                MessageBox.Show("maj");
                conn.Close();
                voituredata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                conn.Close();
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(datagr);
        }
            
    
    }
}
