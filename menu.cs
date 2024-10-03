using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace locavoiture
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            panel3.Height = gunaButton1.Height; panel3.Top = gunaButton1.Top;
            userControl41.BringToFront();
            gunaButton5.BringToFront();
            checkim.BringToFront();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            panel3.Height = gunaButton2.Height; panel3.Top = gunaButton2.Top;
            userControl11.BringToFront();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            panel3.Height = gunaButton4.Height; panel3.Top = gunaButton4.Top;
            userControl21.BringToFront();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            panel3.Height = gunaButton3.Height; panel3.Top = gunaButton3.Top;
            userControl31.BringToFront();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            panel3.Height = gunaButton1.Height; panel3.Top = gunaButton1.Top;

            userControl41.BringToFront();
            gunaButton5.BringToFront();
            checkim.BringToFront();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'voitureDataSet.voiture' table. You can move, or remove it, as needed.
            this.voitureTableAdapter.Fill(this.voitureDataSet.voiture);
            // TODO: This line of code loads data into the 'voitureDataSet3.reservation' table. You can move, or remove it, as needed.
            this.reservationTableAdapter.Fill(this.voitureDataSet3.reservation);

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {

            DialogResult rs = MessageBox.Show("Voulez-vous voulez fermer l'application ?", "fermer", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes )
            {
                this.Close();
            }
        }

        private void userControl41_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            menu mennuu = new menu();
            mennuu.Show();
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
        DialogResult result = MessageBox.Show("Voulez-vous voulez déconnecter ?", "deconnection", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                connect connect = new connect();
                connect.Show();
                this.Hide();
            }
            else { this.BackColor = Control.DefaultBackColor; }

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {

            guna2Panel1.BringToFront();
        }

        private void guna2ImageButton3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_MouseLeave(object sender, EventArgs e)
        {

        }

        private void userControl41_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Panel1.SendToBack();
            userControl51.SendToBack();
            checkim.Checked = false;
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            userControl51.BringToFront();
            checkim.Checked = false ;
            guna2Panel1.SendToBack() ;



        }

        private void menu_MouseClick(object sender, MouseEventArgs e)
        {
            guna2Panel1.SendToBack();
            userControl51.SendToBack();
            checkim.Checked = false;
        }

        private void guna2ImageButton3_DoubleClick(object sender, EventArgs e)
        {
        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkim.Checked==true)
            {
                guna2Panel1.BringToFront();

            }else 
            { 
                guna2Panel1.SendToBack();
            }
            
        }
    }
}
