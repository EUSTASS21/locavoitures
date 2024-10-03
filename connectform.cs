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
using Guna.UI2.WinForms;

namespace locavoiture
{
    public partial class connect : Form
    {
        public connect()
        {
            InitializeComponent();
            pass.UseSystemPasswordChar = true;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=EEUSTASS;Initial Catalog=Voiture;Integrated Security=True;Encrypt=False");
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTileButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void connect_Load(object sender, EventArgs e)
        {

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = usern.Text;
            user_password = pass.Text;

            try
            {
                string querry = "SELECT * FROM connexion WHERE login = '"+usern.Text+"' AND password =  '"+pass.Text+"' ";
                SqlDataAdapter adapter = new SqlDataAdapter(querry,conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    username = usern.Text;
                    user_password = pass.Text;
                    menu menuu = new menu();
                    menuu.Show();
                    this.Hide();


                }
                else {
                    MessageBox.Show("nom d'utilisateur ou mot de passe invalide", "    ", MessageBoxButtons.OK);
                    usern.Clear();
                    pass.Clear();
                   
                  
                }
            }
            catch
            {
                MessageBox.Show("erreur inconnue");
            }
            finally
            {
                conn.Close();

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (check.Checked == true)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;

            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

            if (check.Checked == true)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;

            }
        }

        private void enter(object sender, KeyEventArgs e)
        {

        }

        private void usern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pass.Focus();
            }
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaButton1.PerformClick();
            }
        }

        private void connect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaButton1.PerformClick();
            }
        }
    }
}
