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
using System.Windows.Forms.DataVisualization.Charting;

namespace locavoiture
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=EEUSTASS;Initial Catalog=Voiture;Integrated Security=True;Encrypt=False");


        private void UserControl4_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from client ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            clients.Text = dt.Rows.Count.ToString();

            string query2 = "select * from voiture ";
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(query2, conn);
            DataTable dt1 = new DataTable();
            sqlDataAdapter2.Fill(dt1);
            voit.Text = dt1.Rows.Count.ToString();

            string query3 = "select * from reservation ";
            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(query3, conn);
            DataTable dt2 = new DataTable();
            sqlDataAdapter3.Fill(dt2);
            reser.Text = dt2.Rows.Count.ToString();
            conn.Close();


            DisplayChart();
            conn.Close();
            DisplayChart2();

        }
        private void DisplayChart2()
        {

            {
                string query = "SELECT date_D, sum(Montant) AS ReservationCount FROM reservation  WHERE date_D >= DATEADD(DAY, -7, CAST(GETDATE() as date)) AND date_D < CAST(GETDATE() as date) GROUP BY date_D";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                   
                        chart2.Series.Clear();

                     
                        Series series = new Series("revenue/semaine");
                        series.ChartType = SeriesChartType.Column;

                  
                        while (reader.Read())
                        {
                            DateTime startDate = reader.GetDateTime(0);
                            int reservationCount = reader.GetInt32(1);
                            series.Points.AddXY(startDate.ToString("dd/MM"), reservationCount);
                        }

                  
                        chart2.Series.Add(series);
                    }
                }
            }
        }


        private void DisplayChart()
        {

            {
                string query = "SELECT date_D, COUNT(*) AS ReservationCount FROM reservation WHERE date_D >= DATEADD(DAY, -7, CAST(GETDATE() as date)) AND date_D < CAST(GETDATE() as date) GROUP BY date_D";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                  
                        chart1.Series.Clear();

                    
                        Series series = new Series("Reser/semaine");
                        series.ChartType = SeriesChartType.Column;

                   
                        while (reader.Read())
                        {
                            DateTime startDate = reader.GetDateTime(0);
                            int reservationCount = reader.GetInt32(1);
                            series.Points.AddXY(startDate.ToString("dd/MM"), reservationCount);
                        }

                 
                        chart1.Series.Add(series);
                    }
                }
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Check1.Checked == true)
            {
                chart2.BringToFront();
                Check1.BringToFront();
            }
            else
            {
                chart1.BringToFront();
                Check1.BringToFront();

            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
