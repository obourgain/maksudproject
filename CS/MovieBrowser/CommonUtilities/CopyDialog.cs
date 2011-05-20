using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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


        public String CopyText
        {
            set
            {
                this.label1.Text = value;
            }
            get
            {
                return this.label1.Text;
            }
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = (progressBar1.Value + 1) % 100;
            }
            catch (Exception)
            {

                timer1.Enabled = false;
            }

        }


    }
}
