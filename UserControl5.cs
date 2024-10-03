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

namespace locavoiture
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=EEUSTASS;Initial Catalog=Voiture;Integrated Security=True;Encrypt=False");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            if (passacc.Text == "" || nvpass.Text == "" || confpass.Text == "" )
            {
                MessageBox.Show("missing infos");
            }
            else
            {
                try
                {
                    if (nvpass.Text == confpass.Text)
                    {
                        conn.Open();

                        string query = "UPDATE connexion SET password = '" + nvpass.Text + "'  WHERE password = '" + passacc.Text + "'  ";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("UPDATED");
                    }else
                    {
                        MessageBox.Show("mot de pass n'est pas confirmé");
                    }



                }
                catch (Exception myex)
                {

                    MessageBox.Show(myex.Message);
                    conn.Close();
                }
            }
        }

        private void chek1_CheckedChanged(object sender, EventArgs e)
        {
            if (chek1.Checked == true)
            {
                passacc.UseSystemPasswordChar = false;
            }
            else
            {
                passacc.UseSystemPasswordChar = true;

            }
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            passacc.UseSystemPasswordChar = true;
            nvpass.UseSystemPasswordChar = true;
            confpass.UseSystemPasswordChar = true;
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (chek1.Checked == true)
            {
                nvpass.UseSystemPasswordChar = false;
            }
            else
            {
                nvpass.UseSystemPasswordChar = true;

            }
        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {
            if (chek1.Checked == true)
            {
                confpass.UseSystemPasswordChar = false;
            }
            else
            {
                confpass.UseSystemPasswordChar = true;

            }
        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ImageCheckBox1.Checked == true)
            {
                nvpass.UseSystemPasswordChar = false;
            }
            else
            {
                nvpass.UseSystemPasswordChar = true;

            }
        }

        private void guna2ImageCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ImageCheckBox2.Checked == true)
            {
                confpass.UseSystemPasswordChar = false;
            }
            else
            {
                confpass.UseSystemPasswordChar = true;

            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            this.SendToBack();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }
    }
}
