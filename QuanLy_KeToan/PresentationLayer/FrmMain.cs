using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
#region (Tạo Thread)
        Thread formThread;
        FormCho form_wait;
        public void Runwait()
        {
            form_wait = new FormCho();
            Application.Run(form_wait);
        }
#endregion
        private void buttonKhoHang_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyKhoHang FRMQLKH = new FrmQuanLyKhoHang();
            FRMQLKH.Show();
            formThread.Abort();
        }

        private void btnQLThu_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyThu FRMQLT = new FrmQuanLyThu();
            FRMQLT.Show();
            formThread.Abort();
        }

        private void btnQLChi_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyChi FRMQLC = new FrmQuanLyChi();
            FRMQLC.Show();
            formThread.Abort();
        }

        private void btnKSTC_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmKetSoThuChi FRMKSTC = new FrmKetSoThuChi();
            FRMKSTC.Show();
            formThread.Abort();
        }
        private void btnQLNK_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyNhapKho FRMQLNK = new FrmQuanLyNhapKho();
            FRMQLNK.Show();
            formThread.Abort();
        }
        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyXuatKho FRMQLXK = new FrmQuanLyXuatKho();
            FRMQLXK.Show();
            formThread.Abort();
        }

        private void btnKSNX_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmKetSoXuatNhapKho FRMKSXNK = new FrmKetSoXuatNhapKho();
            FRMKSXNK.Show();
            formThread.Abort();
        }

        private void btnHangHoa_Click_1(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmHangHoa FRMHH = new FrmHangHoa();
            FRMHH.Show();
            formThread.Abort();
        }

        private void btnQLHDM_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyHoaDonMua FRMQLHDM = new FrmQuanLyHoaDonMua();
            FRMQLHDM.Show();
            formThread.Abort();
        }

        private void btnQLHDB_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmQuanLyHoaDonBan FRMQLHDB = new FrmQuanLyHoaDonBan();
            FRMQLHDB.Show();
            formThread.Abort();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            formThread = new Thread(Runwait);
            formThread.SetApartmentState(ApartmentState.STA);
            formThread.Start();
            FrmKhachHang FRMKH = new FrmKhachHang();
            FRMKH.Show();
            formThread.Abort();
        }
    }
}