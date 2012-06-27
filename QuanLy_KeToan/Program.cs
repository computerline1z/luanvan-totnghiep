using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLy_KeToan.PresentationLayer;

namespace QuanLy_KeToan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmDangNhap());
        }
    }
}
