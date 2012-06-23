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
        
        int th_khohang = 0;

        private void KhoHang_Thoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        private void KhoHang_Huy_Click_1(object sender, EventArgs e)
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

        private void cmbTenLoaiHang_SelectedIndexChanged_1(object sender, EventArgs e)
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
                if (th_khohang == 1)
                    gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].ReadOnly = false;
                //Load dữ liệu cho Datagridview Kho chứa.
                //Load dữ liệu lên 2 column trong gridKhochua
                LayDSKhoHang();
                LayDanhSachHang();
                string makhohang = (gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value != null ? gridKhoHang.CurrentRow.Cells["ColMaKhoHang"].Value.ToString() : "");
                LayDanhSachKhoChua(makhohang);
            }
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
                            KCBLL.SuaKhoChua(makhohang, mahang, KC);
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
                            KCBLL.ThemKhoChua(makhohang, mahang, sl, ngaylap, nguoilap, ngaysua, nguoisua);
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
                KCBLL.XoaKhoChua(gridKhoChua.CurrentRow.Cells["ColMKH"].Value.ToString(), gridKhoChua.CurrentRow.Cells["ColMH"].Value.ToString());
                LayDanhSachKhoChua(gridKhoChua.CurrentRow.Cells["ColMKH"].Value.ToString());
            }
        }

        private void KhoChua_Refresh_Click(object sender, EventArgs e)
        {
            LayDanhSachKhoChua(gridKhoHang.Rows[0].Cells["ColMaKhoHang"].Value.ToString());
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

        private void cmbHang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoMaHang(cmbHang.ComboBox.SelectedValue.ToString());
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
        }

        private void cmbKhoChua_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LayDanhSachHang();
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoMaKhoHang(cmbKhoChua.ComboBox.SelectedValue.ToString());
            bindingKhoChua.BindingSource = bds;
            gridKhoChua.DataSource = bds;
            gridKhoChua.AllowUserToAddRows = false;
        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KCBLL.LayDanhSachKhoChuaTheoTenHang(txtTenHang.Text);
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

        private void FrmQuanLyKhoHang_Load(object sender, EventArgs e)
        {
            LayDanhSachLoaiHang();
            LayTenKhoHang();
            LayKhoHang();
        }

       
    }
}