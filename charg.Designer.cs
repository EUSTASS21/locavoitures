namespace locavoiture
{
    partial class charg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI.WinForms.GunaElipse gunaElipse6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(charg));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse3 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logoo = new System.Windows.Forms.PictureBox();
            this.Myprogress = new Guna.UI.WinForms.GunaProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaElipse4 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse5 = new Guna.UI.WinForms.GunaElipse(this.components);
            gunaElipse6 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaElipse6
            // 
            gunaElipse6.Radius = 0;
            gunaElipse6.TargetControl = this;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.TargetControl = this;
            // 
            // gunaElipse3
            // 
            this.gunaElipse3.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // logoo
            // 
            this.logoo.Image = ((System.Drawing.Image)(resources.GetObject("logoo.Image")));
            this.logoo.Location = new System.Drawing.Point(4, -12);
            this.logoo.Name = "logoo";
            this.logoo.Size = new System.Drawing.Size(801, 382);
            this.logoo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoo.TabIndex = 3;
            this.logoo.TabStop = false;
            this.logoo.Click += new System.EventHandler(this.logoo_Click);
            // 
            // Myprogress
            // 
            this.Myprogress.BackColor = System.Drawing.Color.Crimson;
            this.Myprogress.BorderColor = System.Drawing.Color.Crimson;
            this.Myprogress.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.Myprogress.IdleColor = System.Drawing.Color.Transparent;
            this.Myprogress.Location = new System.Drawing.Point(0, 313);
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.ProgressMaxColor = System.Drawing.Color.White;
            this.Myprogress.ProgressMinColor = System.Drawing.Color.White;
            this.Myprogress.Size = new System.Drawing.Size(808, 22);
            this.Myprogress.TabIndex = 4;
            this.Myprogress.Click += new System.EventHandler(this.gunaProgressBar1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Myprogress);
            this.panel1.Controls.Add(this.logoo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 335);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Agency FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label6.Location = new System.Drawing.Point(690, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "AMCHYA AYMANE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(690, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "DEVLOPED BY";
            // 
            // gunaElipse4
            // 
            this.gunaElipse4.Radius = 0;
            this.gunaElipse4.TargetControl = this;
            // 
            // gunaElipse5
            // 
            this.gunaElipse5.Radius = 0;
            this.gunaElipse5.TargetControl = this;
            // 
            // charg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 336);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "charg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "charg";
            this.Load += new System.EventHandler(this.charg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaElipse gunaElipse3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaProgressBar Myprogress;
        public System.Windows.Forms.PictureBox logoo;
        private Guna.UI.WinForms.GunaElipse gunaElipse4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaElipse gunaElipse5;
    }
}