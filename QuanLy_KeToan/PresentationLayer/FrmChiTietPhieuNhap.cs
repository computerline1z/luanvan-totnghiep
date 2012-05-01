using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.DataAccessLayer;
using QuanLy_KeToan.BusinessLogicLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmChiTietPhieuNhap : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        ChiTietPhieuNhapBLL CTPNBLL = new ChiTietPhieuNhapBLL();
        public string maphieunhap;
        public string id_patch;
        private void LayHang(string maphieunhap)
        {
            ColMH.DataSource = CTPNBLL.LayMaHang(maphieunhap);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";
        }
        private string LayKH()
        {
            string mkh = "";
            foreach (var item in CTPNBLL.LayMaKH(maphieunhap))
            {
                mkh = item.ToString();
            }
            return mkh;
        }
        private void LayKhoHang(string maphieunhap)
        {
            ColMKH.DataSource = CTPNBLL.LayKhoHang(maphieunhap);
            ColMKH.DisplayMember = "TenKhoHang";
            ColMKH.ValueMember = "MaKhoHang";
        }
        private void LayDanhSachChiTietPhieuNhap(string maphieunhap)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPNBLL.LayChiTietPhieuNhapTheoMaPhieuNhap(maphieunhap);
            bindingCTPN.BindingSource = bds;
            gridChiTietPhieuNhap.DataSource = bds;
            gridChiTietPhieuNhap.AllowUserToAddRows = false;
        }
        private void FrmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LayHang(maphieunhap);
            LayKhoHang(maphieunhap);
            LayDanhSachChiTietPhieuNhap(maphieunhap);
        }
        int th_ctpn = 0;
        private void Add_Click(object sender, EventArgs e)
        {
            th_ctpn = 1;
            gridChiTietPhieuNhap.AllowUserToAddRows = true;
            bindingCTPN.BindingSource.MoveLast();
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColMPN"].Value = maphieunhap;
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColMLN"].Value = id_patch;
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColMH"].ReadOnly = false;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            switch (th_ctpn)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPN.Focus();
                            ChiTietPhieuNhap CTPN = new ChiTietPhieuNhap();
                            string mahang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                            string makhohang=gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value.ToString();
                            CTPN.MaKhoHang = makhohang;
                            int sl = (gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            CTPN.SoLuong = sl;
                            CTPN.NgayLap = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTPN.NguoiLap = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTPN.NgaySua = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTPN.NguoiSua = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            CTPNBLL.CapNhatLaiKhoChua(mahang, makhohang, sl);
                            bool sua=CTPNBLL.SuaCTPN(maphieunhap,id_patch,mahang,CTPN);
                            LayDanhSachChiTietPhieuNhap(maphieunhap);
                            if(sua==true)
                                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào " + makhohang + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            return;
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPN.Focus();
                            string mahang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                            string makhohang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value.ToString();
                            int sl = (gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool them=CTPNBLL.ThemCTPN(maphieunhap,id_patch,mahang,makhohang,sl,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuNhap(maphieunhap);
                            th_ctpn = 0;
                            if (them == true)
                            {
                                CTPNBLL.CapNhatKhoChua(mahang, makhohang);
                            }
                        }
                        else
                        {
                            th_ctpn = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridChiTietPhieuNhap.RowCount == 0)
                Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu nhập này không-Số Lượng hàng trong kho chứa sẽ bị giảm đi?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                string mahang=gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                string makhohang=gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value.ToString();
                int sl= System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value);
                bool xoa=CTPNBLL.XoaCTPN(maphieunhap,id_patch,mahang);
                LayDanhSachChiTietPhieuNhap(maphieunhap);
                if (xoa == true)
                {
                    CTPNBLL.CapNhatLaiKhoChuaKhiXoaCTPN(mahang,makhohang,sl);
                }
            }
        }

        private void gridChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (th_ctpn == 1)
            {
                gridChiTietPhieuNhap.CurrentRow.Cells["ColMPN"].Value = maphieunhap;
                gridChiTietPhieuNhap.CurrentRow.Cells["ColMLN"].Value = id_patch;
                gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value = LayKH();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachChiTietPhieuNhap(maphieunhap);
            }
            else
                return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmChiTietPhieuNhap_Load(sender, e);
        }
    }
}