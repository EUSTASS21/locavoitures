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
    public partial class charg : Form
    {
        public charg()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Myprogress.Value < 100)
            {
                Myprogress.Value += 3;
            }
            else
            {
                timer1.Stop();
                connect con = new connect();
                con.Show();
                this.Hide();
            }
        }
        private void gunaProgressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void charg_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void logoo_Click(object sender, EventArgs e)
        {

        }
    }
}
