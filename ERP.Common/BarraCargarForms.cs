using System;
using System.Windows.Forms;

namespace ERP.Common
{
    public partial class BarraCargarForms : Form
    {
        public BarraCargarForms()
        {
            InitializeComponent();
        }

        private void fadeInForm_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                fadeInForm.Stop();
                fadeOutForm.Start();
            }
        }

        private void fadeOutForm_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                fadeOutForm.Stop();
                this.Close();
            }
        }

        private void LoadingAppForms_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            fadeInForm.Start();
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
