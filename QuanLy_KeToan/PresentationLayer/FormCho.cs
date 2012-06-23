using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FormCho : Form
    {
        public FormCho()
        {
            InitializeComponent();
        }
        private void FormCho_Load(object sender, EventArgs e)
        {
            circularProgress.Minimum = 0;
            circularProgress.Maximum = 100;
            circularProgress.IsRunning = true;
        }
    }
}
