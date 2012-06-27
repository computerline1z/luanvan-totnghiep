using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.PresentationLayer;
using QuanLy_KeToan.DataAccessLayer;
using QuanLy_KeToan.BusinessLogicLayer;

namespace QuanLy_KeToan
{
    public partial class FrmDangNhap : DevComponents.DotNetBar.Office2007Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Focus();
            timerNgaygio.Enabled = true;
        }
        private void timerNgaygio_Tick(object sender, EventArgs e)
        {
            lblNgayGio.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " " + DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
        DangNhapBLL DNBLL = new DangNhapBLL();
        private void btnQLDN_Click(object sender, EventArgs e)
        {
            string tendangnhap=txtTenDangNhap.Text.Trim();
            string matkhau=txtMatKhau.Text.Trim();
            if (DNBLL.KiemtraDangNhap(tendangnhap, matkhau, txtTenDangNhap, txtMatKhau) == true)
            {
                bool them = DNBLL.QuyenThem(tendangnhap);
                bool sua = DNBLL.QuyenSua(tendangnhap);
                bool xoa = DNBLL.QuyenXoa(tendangnhap);
                DNBLL.CapNhatDangNhap(tendangnhap, them, xoa, sua);
                this.Hide();
                FrmMain FMain = new FrmMain();
                FMain.Show();
            }

        }
    }
}
