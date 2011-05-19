using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonUtilities
{
    public partial class CopyDialog : Form
    {
        public CopyDialog()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        public string CopyText
        {
            set
            {
                this.label1.Text = value;
            }
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = (progressBar1.Value + 10) % 100;
            }
            catch (Exception)
            {

                timer1.Enabled = false;
            }

        }
    }
}
