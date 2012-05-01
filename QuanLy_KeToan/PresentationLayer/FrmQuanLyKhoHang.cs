using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.BusinessLogicLayer;
using QuanLy_KeToan.DataAccessLayer;
using QuanLy_KeToan.PresentationLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmQuanLyKhoHang : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyKhoHang()
        {
            InitializeComponent();
        }
        //--------------------Quản lý Kho Hàng--------------------------------------//
        KhoHangBLL KHBLL = new KhoHangBLL();
        private void LayKhoHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.LayDanhSachKhoHang();
            bindingKhoHang.BindingSource = bds;
            gridKhoHang.DataSource = bds;
            gridKhoHang.AllowUserToAddRows = false;
        }
        private void LayDanhSachLoaiHang()
        {
            ColMaLoaiHang.DataSource = KHBLL.LayDanhSachLoaiHang();
            ColMaLoaiHang.DisplayMember = "TenLoaiHang";
            ColMaLoaiHang.ValueMember = "MaLoaiHang";
            cmbTenLoaiHang.ComboBox.DataSource = KHBLL.LayDanhSachLoaiHang();
            cmbTenLoaiHang.ComboBox.DisplayMember = "TenLoaiHang";
            cmbTenLoaiHang.ComboBox.ValueMember = "MaLoaiHang";
        }
        private void LayTenKhoHang()
        {
            cmbTenKhoHang.ComboBox.DataSource = KHBLL.LayMaKhoHang();
            cmbTenKhoHang.ComboBox.DisplayMember = "TenKhoHang";
            cmbTenKhoHang.ComboBox.ValueMember = "MaKhoHang";
        }
        private void FrmQuanLyKhoHang_Load(object sender, EventArgs e)
        {
            LayDanhSachLoaiHang();
            LayTenKhoHang();
            LayKhoHang();
        
            LoadTreeView();
        }
        int th_khohang = 0;
        private void KhoHang_Them_Click(object sender, EventArgs e)
        {
            th_khohang = 1;
            gridKhoHang.AllowUserToAddRows = true;
            bindingKhoHang.BindingSource.MoveLast();
        }

        private void KhoHang_Luu_Click(object sender, EventArgs e)
        {
            switch (th_khohang)
            {
                case 0://sửa thông tin kho hàng
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionKhoHang.Focus();
                            KhoHang KH = new KhoHang();
                            string makhohang = gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString();
                            KH.TenKhoHang = gridKhoHang.CurrentRow.Cells["ColTenKhoHang"].Value.ToString();
                            KH.MaLoaiHang = gridKhoHang.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            KH.DiaChiKhoHang = gridKhoHang.CurrentRow.Cells["ColDiaChiKhoHang"].Value.ToString();
                            KH.NgayLap = System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgayLap"].Value.ToString());
                            KH.NguoiLap = (gridKhoHang.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridKhoHang.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            KH.NgaySua = System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgaySua"].Value.ToString());
                            KH.NguoiSua = (gridKhoHang.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridKhoHang.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            KHBLL.SuaKhoHang(makhohang, KH);
                            LayKhoHang();
                        }
                        else
                            return;
                        break;
                    }
                case 1://thêm thông tin kho hàng
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionKhoHang.Focus();
                            string makhohang = gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString();
                            string tenkhohang = (gridKhoHang.CurrentRow.Cells["ColTenKhoHang"].Value != null ? gridKhoHang.CurrentRow.Cells["ColTenKhoHang"].Value.ToString() : "");
                            string maloaihang = gridKhoHang.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            string diachikhohang = (gridKhoHang.CurrentRow.Cells["ColDiaChiKhoHang"].Value != null ? gridKhoHang.CurrentRow.Cells["ColDiaChiKhoHang"].Value.ToString() : "");
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridKhoHang.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridKhoHang.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridKhoHang.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridKhoHang.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            KHBLL.ThemKhoHang(makhohang, tenkhohang, maloaihang, diachikhohang, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayKhoHang();
                            th_khohang = 0;
                        }
                        else
                        {
                            th_khohang = 0;
                            return;
                        }
                        break;
                    }
            }
        }

        private void KhoHang_Xoa_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridKhoHang.RowCount == 0)
                KhoHang_Xoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KHBLL.XoaKho(gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString());
                LayKhoHang();
            }
        }
        private void KhoHang_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyKhoHang_Load(sender, e);
        }

        private void KhoHang_Huy_Click(object sender, EventArgs e)
        {
            LayKhoHang();
        }
        private void cmbTenKhoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.LayKhoHangTheoMaKho(cmbTenKhoHang.ComboBox.SelectedValue.ToString());
            bindingKhoHang.BindingSource = bds;
            gridKhoHang.DataSource = bds;
            gridKhoHang.AllowUserToAddRows = false;
        }

        private void cmbTenLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.LayKhoHangTheoMaLoaiHang(cmbTenLoaiHang.ComboBox.SelectedValue.ToString());
            bindingKhoHang.BindingSource = bds;
            gridKhoHang.DataSource = bds;
            gridKhoHang.AllowUserToAddRows = false;
        }
        //----------------------------Kho Chứa---------------------------------------//
        KhoChuaBLL KCBLL = new KhoChuaBLL();

        private void LayDSKhoHang()
        {
            ColMKH.DataSource = KCBLL.LayDSKhoHang();
            ColMKH.DisplayMember = "TenKhoHang";
            ColMKH.ValueMember = "MaKhoHang";
            cmbKhoChua.ComboBox.DataSource = KCBLL.LayDSKhoHang();
            cmbKhoChua.ComboBox.DisplayMember = "TenKhoHang";
            cmbKhoChua.ComboBox.ValueMember = "MaKhoHang";
        }
        private void LayDanhSachHang()
        {
            ColMH.DataSource = KCBLL.LayDSHangTheoMaLoaiHang();
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";
            cmbHang.ComboBox.DataSource = KCBLL.LayDSHangTheoMaLoaiHang();
            cmbHang.ComboBox.DisplayMember = "TenHang";
            cmbHang.ComboBox.ValueMember = "MaHang";
        }
        private void LayDanhSachKhoChua(string makhohang)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoMaKhoHang(makhohang);
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
            //Phần Thống kê
            lblTongKho.Text = KCBLL.ThongKeSoLuongKhoHang().ToString();
            lblMaKhoHT.Text = makhohang;
            lblTenKhoHT.Text = (gridKhoHang.CurrentRow.Cells["ColTenKhoHang"].Value != null ? gridKhoHang.CurrentRow.Cells["ColTenKhoHang"].Value.ToString() : "");
            lblTongSL.Text = KCBLL.ThongKeSLHangTrongKho(makhohang).ToString();
            lblTongSLHang.Text = KCBLL.ThongKeSLMatHangTrongKho(makhohang).ToString();
            lblTongGiaTri.Text = String.Format("{0:0,0 VNĐ}", KCBLL.ThongKeTongGiaTriHang(makhohang));
        }
        private void gridKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridKhoHang.RowCount > 0)
            {
                if(th_khohang==1)
                    gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].ReadOnly = false;
                //Load dữ liệu cho Datagridview Kho chứa.
                //Load dữ liệu lên 2 column trong gridKhochua
                LayDSKhoHang();
                LayDanhSachHang();
                string makhohang = (gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value != null ? gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString() : "");
                LayDanhSachKhoChua(makhohang);
            }
        }

        private void KhoHang_Thoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        int th_khochua = 0;
        private void KhoChua_Them_Click(object sender, EventArgs e)
        {
            try
            {
                th_khochua = 1;
                gridKhoChua.AllowUserToAddRows = true;
                bindingKhoChua.BindingSource.MoveLast();
            }
            catch { }
        }

        private void gridKhoChua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (th_khochua == 0)
            {
                gridKhoChua.CurrentRow.Cells["ColMKH"].ReadOnly = true;
                gridKhoChua.CurrentRow.Cells["ColMH"].ReadOnly = true;
            }
            if (th_khochua == 1)
            {
                gridKhoChua.CurrentRow.Cells["ColMKH"].ReadOnly = false;
                gridKhoChua.CurrentRow.Cells["ColMH"].ReadOnly = false;
                gridKhoChua.CurrentRow.Cells["ColMKH"].Value = gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString();
            }
        }

        private void KhoChua_Luu_Click(object sender, EventArgs e)
        {
            switch (th_khochua)
            {
                case 0://Sửa kho chứa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionKhoChua.Focus();
                            KhoChua KC = new KhoChua();
                            string makhohang = gridKhoChua.CurrentRow.Cells["ColMKH"].Value.ToString();
                            string mahang = gridKhoChua.CurrentRow.Cells["ColMH"].Value.ToString();
                            KC.SL = System.Convert.ToInt16(gridKhoChua.CurrentRow.Cells["ColSL"].Value);
                            KC.NgayLap = System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgayLap"].Value.ToString());
                            KC.NguoiLap = (gridKhoHang.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridKhoHang.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            KC.NgaySua = System.Convert.ToDateTime(gridKhoHang.CurrentRow.Cells["ColNgaySua"].Value.ToString());
                            KC.NguoiSua = (gridKhoHang.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridKhoHang.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            KCBLL.SuaKhoChua(makhohang,mahang,KC);
                            LayDanhSachKhoChua(makhohang);
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm Kho chứa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionKhoChua.Focus();
                            string makhohang = gridKhoChua.CurrentRow.Cells["ColMKH"].Value.ToString();
                            string mahang = gridKhoChua.CurrentRow.Cells["ColMH"].Value.ToString();
                            int sl = System.Convert.ToInt16(gridKhoChua.CurrentRow.Cells["ColSL"].Value);
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridKhoChua.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridKhoChua.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridKhoChua.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridKhoChua.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridKhoChua.CurrentRow.Cells["ColNgL"].Value != null ? gridKhoChua.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridKhoChua.CurrentRow.Cells["ColNgS"].Value != null ? gridKhoChua.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            KCBLL.ThemKhoChua(makhohang,mahang,sl,ngaylap,nguoilap,ngaysua,nguoisua);
                            LayDanhSachKhoChua(makhohang);
                            th_khochua = 0;
                        }
                        else
                        {
                            th_khochua = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void KhoChua_Xoa_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridKhoChua.RowCount == 0)
                KhoChua_Xoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KCBLL.XoaKhoChua(gridKhoChua.CurrentRow.Cells["ColMKH"].Value.ToString(),gridKhoChua.CurrentRow.Cells["ColMH"].Value.ToString());
                LayDanhSachKhoChua(gridKhoChua.CurrentRow.Cells["ColMKH"].Value.ToString());
            }
        }

        private void KhoChua_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachKhoChua(gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString());
            }
            else
                return;
        }

        private void KhoChua_Refresh_Click(object sender, EventArgs e)
        {
            LayDanhSachKhoChua(gridKhoHang.Rows[0].Cells["ColMaKhoHang"].Value.ToString());
        }
        private void cmbHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoMaHang(cmbHang.ComboBox.SelectedValue.ToString());
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
        }

        private void txtTenKhoChua_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoTenHang(txtTenKhoChua.Text);
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
        }

        private void comboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoTinhTrang(comboTinhTrang.Text);
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
        }

        private void cmbKhoChua_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDanhSachHang();
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoMaKho(cmbKhoChua.ComboBox.SelectedValue.ToString());
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
        }

        //----------------Phần Loại Phiếu Nhập-------------------------------------//
        LoaiPhieuNhapBLL LPNBLL = new LoaiPhieuNhapBLL();
        private void LPN_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void LayDanhSachLoaiPN()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPNBLL.LayDanhSachLoaiPhieuNhap();
            gridLoaiPhieuNhap.DataSource = bds;
            bindingLoaiPhieuNhap.BindingSource = bds;
            gridLoaiPhieuNhap.AllowUserToAddRows = false;
        }

        private void tabItemNhapKho_Click(object sender, EventArgs e)
        {
            LayDanhSachLoaiPN();
        }
        private int th_lpn = 0;
        private void LPN_Add_Click(object sender, EventArgs e)
        {
            th_lpn = 1;
            gridLoaiPhieuNhap.AllowUserToAddRows = true;
            bindingLoaiPhieuNhap.BindingSource.MoveLast();
        }

        private void LPN_Save_Click(object sender, EventArgs e)
        {
           switch (th_lpn)
           {
               case 0://Sửa
                   {
                       if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                       {
                           positionLoaiPhieuNhap.Focus();
                           LoaiPhieuNhap LPN = new LoaiPhieuNhap();
                           string maloaiphieunhap = gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].Value.ToString();
                           LPN.TenLoaiPhieuNhap = gridLoaiPhieuNhap.CurrentRow.Cells["ColTLPN"].Value.ToString();
                           LPN.NgayLap = System.Convert.ToDateTime(gridLoaiPhieuNhap.CurrentRow.Cells["NL"].Value.ToString());
                           LPN.NguoiLap = (gridLoaiPhieuNhap.CurrentRow.Cells["NgL"].Value != null ? gridLoaiPhieuNhap.CurrentRow.Cells["NgL"].Value.ToString() : "");
                           LPN.NgaySua = System.Convert.ToDateTime(gridLoaiPhieuNhap.CurrentRow.Cells["NS"].Value.ToString());
                           LPN.NguoiSua = (gridLoaiPhieuNhap.CurrentRow.Cells["NgS"].Value != null ? gridLoaiPhieuNhap.CurrentRow.Cells["NgS"].Value.ToString() : "");
                           LPNBLL.SuaLoaiPhieuNhap(maloaiphieunhap, LPN);
                           LayDanhSachLoaiPN();
                       }
                       else
                           return;
                       break;
                   }
               case 1://Thêm
                   {
                       if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                       {
                           positionLoaiPhieuNhap.Focus();
                           string maloaiphieunhap = gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].Value.ToString();
                           string tenloaiphieunhap = gridLoaiPhieuNhap.CurrentRow.Cells["ColTLPN"].Value.ToString();
                           DateTime ngaylap;
                           DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                           if (System.Convert.ToDateTime(gridLoaiPhieuNhap.CurrentRow.Cells["NL"].Value) != temp)
                           {
                               ngaylap = System.Convert.ToDateTime(gridLoaiPhieuNhap.CurrentRow.Cells["NL"].Value);
                           }
                           else
                           {
                               ngaylap = DateTime.Now.Date;
                           }
                           DateTime ngaysua;
                           if (System.Convert.ToDateTime(gridLoaiPhieuNhap.CurrentRow.Cells["NS"].Value) != temp)
                           {
                               ngaysua = System.Convert.ToDateTime(gridLoaiPhieuNhap.CurrentRow.Cells["NS"].Value);
                           }
                           else
                           {
                               ngaysua = DateTime.Now.Date;
                           }
                           string nguoilap = (gridLoaiPhieuNhap.CurrentRow.Cells["NgL"].Value != null ? gridLoaiPhieuNhap.CurrentRow.Cells["NgL"].Value.ToString() : "");
                           string nguoisua = (gridLoaiPhieuNhap.CurrentRow.Cells["NgS"].Value != null ? gridLoaiPhieuNhap.CurrentRow.Cells["NgS"].Value.ToString() : "");
                           LPNBLL.ThemLoaiPhieuNhap(maloaiphieunhap, tenloaiphieunhap, ngaylap, nguoilap, ngaysua, nguoisua);
                           LayDanhSachLoaiPN();
                           th_lpn = 0;
                       }
                       else
                       {
                           th_lpn = 0;
                           return;
                       }

                       break;
                   }
           }
        }

        private void LPN_Delete_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridLoaiPhieuNhap.RowCount == 0)
                LPN_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPNBLL.XoaLoaiPhieuNhap(gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].Value.ToString());
                LayDanhSachLoaiPN();
            }
        }

        private void LPN_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiPN();
            }
            else
                return;
        }

        private void LPN_Refresh_Click(object sender, EventArgs e)
        {
            tabItemNhapKho_Click(sender, e);
        }
        //------------------------Code phần Lô Phiếu Nhập--------------------------------------//

        LoPhieuNhapBLL LNBLL = new LoPhieuNhapBLL();

        private void LayMaLoaiHang()
        {
            ColMLH.DataSource = LNBLL.LayMaLoaiHang();
            ColMLH.DisplayMember = "TenLoaiHang";
            ColMLH.ValueMember = "MaLoaiHang";
        }
        private void LayDanhSachLoPN()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LNBLL.LayDanhSachLoPhieuNhap();
            bindingLoPhieuNhap.BindingSource = bds;
            gridLoPhieuNhap.DataSource = bds;
            gridLoPhieuNhap.AllowUserToAddRows = false;
        }
        private void LoPN_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        int th_lophieunhap = 0;
        private void LoPN_Add_Click(object sender, EventArgs e)
        {
            th_lophieunhap = 1;
            gridLoPhieuNhap.AllowUserToAddRows = true;
            bindingLoPhieuNhap.BindingSource.MoveLast();
        }

        private void LoPN_Delete_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridLoPhieuNhap.RowCount == 0)
                LoPN_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LNBLL.XoaLPN(gridLoPhieuNhap.CurrentRow.Cells["ColMLN"].Value.ToString(), gridLoPhieuNhap.CurrentRow.Cells["ColMLH"].Value.ToString());
                LayDanhSachLoPN();
            }
        }

        private void LoPN_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPN();
            }
            else
                return;
        }

        private void LoPN_Refresh_Click(object sender, EventArgs e)
        {
            LayDanhSachLoPN();
        }

        private void LoPN_Save_Click(object sender, EventArgs e)
        {
            switch (th_lophieunhap)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuNhap.Focus();
                            LoPhieuNhap LPN = new LoPhieuNhap();
                            string malonhap = gridLoPhieuNhap.CurrentRow.Cells["ColMLN"].Value.ToString();
                            string maloaihang = (gridLoPhieuNhap.CurrentRow.Cells["ColMLH"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["ColMLH"].Value.ToString() : "");
                            LPN.NgayLoNhap = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["ColNLN"].Value.ToString());
                            LPN.MoTa = (gridLoPhieuNhap.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LPN.NgayLap = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LPN.NguoiLap = (gridLoPhieuNhap.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LPN.NgaySua = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LPN.NguoiSua = (gridLoPhieuNhap.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LNBLL.SuaLoPN(malonhap,maloaihang,LPN);
                            LayDanhSachLoPN();
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuNhap.Focus();
                            string malonhap = gridLoPhieuNhap.CurrentRow.Cells["ColMLN"].Value.ToString();
                            string maloaihang = gridLoPhieuNhap.CurrentRow.Cells["ColMLH"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylonhap;
                            if (System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["ColNLN"].Value) != temp)
                            {
                                ngaylonhap = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["ColNLN"].Value);
                            }
                            else
                            {
                                ngaylonhap = DateTime.Now.Date;
                            }
                           string mota=(gridLoPhieuNhap.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                           DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoPhieuNhap.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoPhieuNhap.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LNBLL.ThemLoPN(malonhap,maloaihang,ngaylonhap,mota,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPN();
                            th_lophieunhap = 0;
                        }
                        else
                        {
                            th_lophieunhap = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        //--------------------------------------Phần xử lý Phiếu Nhập----------------------------//
        PhieuNhapBLL PNBLL = new PhieuNhapBLL();  

        #region "Xử lý TreeView"
        private void LoadTreeView()
        {
            //advTreeLoNhap.DataSource = LNBLL.LayDanhSachMaLoNhap();
            foreach (var item in LNBLL.LayDanhSachMaLoNhap())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                foreach (DevComponents.AdvTree.Node n in advTreeLoNhap.Nodes[0].Nodes)
                {
                    if (n.Name == "nodeLoPhieuNhap")
                        n.Nodes.Add(childnode);
                }
            }
        }
        private void AnHienGroup(bool status)
        {
            if (status == true)
            {
                groupPanelLoaiPhieuNhap.Visible = true;
                groupPanelLoPhieuNhap.Visible = false;
            }
            else
            {
                groupPanelLoaiPhieuNhap.Visible = false;
                groupPanelLoPhieuNhap.Visible = true;
            }
        }
        private void advTreeLoNhap_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
            if (e.Node.Level == 0)
                return;
            //Node Loại phiếu Nhập
            if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
            {
                groupPanelLoaiPhieuNhap.BringToFront();
            }
            //Node Lô Phiếu Nhập
            else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
            {
                groupPanelLoPhieuNhap.BringToFront();
                LayMaLoaiHang();
                LayDanhSachLoPN();
            }
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                LayMaLoaiPN();
                LayMaNCC();
                groupPanelPhieuNhap.BringToFront();
                string malo = xuly_chuoi(e.Node.Text);
                LayDSPhieuNhapTheoLo(malo);
            }
        }
        private string xuly_chuoi(string chuoi)
        {
            int vt = chuoi.IndexOf("=");
            int vt1 = chuoi.IndexOf(",");
            string s1 = chuoi.Substring(vt + 1, vt1 - vt - 1).Trim();
            return s1;
        }
        # endregion

        private void LayMaLoaiPN()
        {
            MLPN.DataSource = PNBLL.LayMaLoaiPhieuNhap();
            MLPN.DisplayMember = "TenLoaiPhieuNhap";
            MLPN.ValueMember = "MaLoaiPhieuNhap";
        }
        private void LayMaNCC()
        {
            MNCC.DataSource = PNBLL.LayMaNCC();
            MNCC.DisplayMember = "TenNCC";
            MNCC.ValueMember = "MaNCC";
          
        }
        private void LayDSPhieuNhapTheoLo(string malo)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PNBLL.LayDSPhieuNhap(malo);
            bindingPhieuNhap.BindingSource = bds;
            gridPhieuNhap.DataSource = bds;
            gridPhieuNhap.AllowUserToAddRows = false;
        }
        private void PN_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        int th_pn = 0;
        private void PN_Add_Click(object sender, EventArgs e)
        {
            th_pn = 1;
            gridPhieuNhap.AllowUserToAddRows = true;
            bindingPhieuNhap.BindingSource.MoveLast();
        }

        private void PN_Delete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
            // Nếu data gridview không có dòng nào
            if (gridPhieuNhap.RowCount == 0)
                PN_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maphieunhap = gridPhieuNhap.CurrentRow.Cells["MPN"].Value.ToString();
                string malonhap = gridPhieuNhap.CurrentRow.Cells["MLN"].Value.ToString();
                PNBLL.XoaPN(maphieunhap,malonhap);
                LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
            }
        }

        private void PN_Save_Click(object sender, EventArgs e)
        {
            switch (th_pn)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuNhap.Focus();
                            PhieuNhap PN = new PhieuNhap();
                            string maphieunhap = gridPhieuNhap.CurrentRow.Cells["MPN"].Value.ToString();
                            string malonhap = gridPhieuNhap.CurrentRow.Cells["MLN"].Value.ToString();
                            PN.MaLoaiPhieuNhap = gridPhieuNhap.CurrentRow.Cells["MLPN"].Value.ToString();
                            PN.MaNCC = gridPhieuNhap.CurrentRow.Cells["MNCC"].Value.ToString();
                            PN.NgayPhieuNhap = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["NPN"].Value.ToString());
                            PN.MoTa = (gridPhieuNhap.CurrentRow.Cells["MT"].Value != null ? gridPhieuNhap.CurrentRow.Cells["MT"].Value.ToString() : "");
                            PN.NgayLap = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NL"].Value.ToString());
                            PN.NguoiLap = (gridPhieuNhap.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuNhap.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            PN.NgaySua = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NS"].Value.ToString());
                            PN.NguoiSua = (gridPhieuNhap.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuNhap.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PNBLL.SuaPN(maphieunhap,malonhap,PN);
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuNhap.Focus();
                            string maphieunhap = gridPhieuNhap.CurrentRow.Cells["MPN"].Value.ToString();
                            string maloaiphieunhap = gridPhieuNhap.CurrentRow.Cells["MLPN"].Value.ToString();
                            string malonhap = gridPhieuNhap.CurrentRow.Cells["MLN"].Value.ToString();
                            string mncc = gridPhieuNhap.CurrentRow.Cells["MNCC"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngayphieunhap;
                            if (System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["NPN"].Value) != temp)
                            {
                                ngayphieunhap = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["NPN"].Value);
                            }
                            else
                            {
                                ngayphieunhap = DateTime.Now.Date;
                            }
                            string mota = (gridPhieuNhap.CurrentRow.Cells["MT"].Value != null ? gridPhieuNhap.CurrentRow.Cells["MT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridPhieuNhap.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuNhap.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            string nguoisua = (gridPhieuNhap.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuNhap.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PNBLL.ThemPhieuNhap(maphieunhap, maloaiphieunhap, malonhap, mncc, ngayphieunhap, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                            th_pn = 0;
                        }
                        else
                        {
                            th_pn = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void PN_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
            }
            else
                return;
        }

        private void PN_Refresh_Click(object sender, EventArgs e)
        {
            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
        }
        private void gridPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (th_pn == 1)
                {
                    gridPhieuNhap.CurrentRow.Cells["MPN"].ReadOnly = false;
                    gridPhieuNhap.CurrentRow.Cells["MLN"].Value = xuly_chuoi(advTreeLoNhap.SelectedNode.Text);
                }
                string name = gridPhieuNhap.Columns[e.ColumnIndex].Name;
                if (name == "MPN")
                {
                    if (gridPhieuNhap.CurrentRow.Cells["MPN"].Value != null)
                    {
                        FrmChiTietPhieuNhap CTPN = new FrmChiTietPhieuNhap();
                        CTPN.maphieunhap = gridPhieuNhap.CurrentRow.Cells["MPN"].Value.ToString();
                        CTPN.id_patch = xuly_chuoi(advTreeLoNhap.SelectedNode.Text);
                        CTPN.Show();
                    }
                    else
                        return;
                }
            }
        }
    }
}