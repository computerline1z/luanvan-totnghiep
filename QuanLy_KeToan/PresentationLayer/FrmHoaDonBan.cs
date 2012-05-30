using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;
using QuanLy_KeToan.BusinessLogicLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmHoaDonBan : Form
    {
        HoaDonBanBLL HDBanBLL = new HoaDonBanBLL();
        LoaiHoaDonBanBLL LoaiHDBanBLL = new LoaiHoaDonBanBLL();

        public FrmHoaDonBan()
        {
            InitializeComponent();
        }
        private void LoadDataComboboxMaKhachHang()
        {
            comboMaKhachHang.ComboBox.DataSource = HDBanBLL.LayDanhSachMaKhachHang();
            comboMaKhachHang.ComboBox.DisplayMember = "TenKhachHang";
            comboMaKhachHang.ComboBox.ValueMember = "MaKhachHang";

        }
        private void comboMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HDBanBLL.TimTatCaHoaDonBanTheoMaKhachHang(comboMaKhachHang.ComboBox.SelectedValue.ToString());
            grivHDBan.DataSource = bds;
            bindingHDBan.BindingSource = bds;
            //SetControlEnable(false);
        }
        private void LoadDaTaColumnCombobox()
        {
            ColMaLoaiHDBan.DataSource = HDBanBLL.LayDanhSachMaLoaiHoaDonBan();
            ColMaLoaiHDBan.DisplayMember = "MaLoaiHDBan";
            ColMaLoHDBan.DataSource = HDBanBLL.LayDanhSachMaLoHoaDonBan();
            ColMaLoHDBan.DisplayMember = "MaLoHDBan";
            ColMaKhachHang.DataSource = HDBanBLL.LayDanhSachMaKhachHang();
            ColMaKhachHang.DisplayMember = "MaKhachHang";
            ColMaTienTe.DataSource = HDBanBLL.LayDanhSachMaTienTe();
            ColMaTienTe.DisplayMember = "MaTienTe";

        }
        private void LoadDanhSachHoaDonBan()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HDBanBLL.LayDanhSachHoaDonBan();
            grivHDBan.DataSource = bds;
            bindingHDBan.BindingSource = bds;
            //HienThiDuLieuLenControl(0);
            //SetControlEnable(false);
            grivHDBan.AllowUserToAddRows = false;
        }

        private void FrmHoaDonBan_Load(object sender, EventArgs e)
        {
            
            LoadDaTaColumnCombobox();
            LoadDataComboboxMaKhachHang();
            LoadDanhSachHoaDonBan();
            
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HDBanBLL.TimTatCaHoaDonBanChinhXacTheoMaHoaDonBan(txtTimKiem.Text);
            grivHDBan.DataSource = bds;
            bindingHDBan.BindingSource = bds;
            //SetControlEnable(false);
        }

        private void NvgRefresh_Click(object sender, EventArgs e)
        {
            FrmHoaDonBan_Load(sender, e);
        }

        private int th=0;
        private void NvgThem_Click(object sender, EventArgs e)
        {
            th = 1;
            grivHDBan.AllowUserToAddRows = true;
            bindingHDBan.BindingSource.MoveLast();
        }

        private void btnXoaHDBan_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (grivHDBan.RowCount == 0)
                btnXoaHDBan.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HDBanBLL.XoaHDBan(grivHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString());
                LoadDanhSachHoaDonBan();
                //SetControlThemEnable(true);
            }
        }
        private void NvgLuu_Click(object sender, EventArgs e)
        {
            switch (th)
            {
                case 1://Them
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingNavigatorPositionItem.Focus();
                            string mahoadonban = grivHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString();
                            string maloaihoadonban = grivHDBan.CurrentRow.Cells["ColMaLoaiHDBan"].Value.ToString();
                            string malohoadonban = grivHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value.ToString();
                            string makhachhang = grivHDBan.CurrentRow.Cells["ColMaKhachHang"].Value.ToString();
                            string matiente = grivHDBan.CurrentRow.Cells["ColMaTienTe"].Value.ToString();
                            string ngayhdban = grivHDBan.CurrentRow.Cells["ColNgayHDBan"].Value.ToString();
                            string mota = grivHDBan.CurrentRow.Cells["ColMoTa"].Value.ToString();
                            string trangthai = grivHDBan.CurrentRow.Cells["ColTrangThai"].Value.ToString();
                            HDBanBLL.ThemHDBan(mahoadonban, maloaihoadonban, malohoadonban, makhachhang, matiente, ngayhdban, mota, trangthai);
                            //SetControlThemEnable(true);
                            //SetConTrolThemSuaEnable(1, true);
                            LoadDanhSachHoaDonBan();
                            th = 0;
                        }
                        else
                        {
                            th = 0;
                            return;
                        }
                        break;
                    }
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingNavigatorPositionItem.Focus();
                            QuanLy_KeToan.DataAccessLayer.HoaDonBan hoadonban = new QuanLy_KeToan.DataAccessLayer.HoaDonBan();
                            string mahoadonban = grivHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString();
                            hoadonban.MaLoaiHDBan = grivHDBan.CurrentRow.Cells["ColMaLoaiHDBan"].Value.ToString();
                            hoadonban.MaLoHDBan = grivHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value.ToString();
                            hoadonban.MaKhachHang = grivHDBan.CurrentRow.Cells["ColMaKhachHang"].Value.ToString();
                            hoadonban.MaTienTe = grivHDBan.CurrentRow.Cells["ColMaTienTe"].Value.ToString();
                           // hoadonban.NgayHDBan = grivHDBan.CurrentRow.Cells["ColNgayHDBan"].Value.ToString();
                            hoadonban.MoTa = grivHDBan.CurrentRow.Cells["ColMoTa"].Value.ToString();
                           // hoadonban.TrangThai = grivHDBan.CurrentRow.Cells["ColTrangThai"].Value.ToString();

                            HDBanBLL.SuaHDBan(mahoadonban, hoadonban);
                            LoadDanhSachHoaDonBan();
                        }
                        else
                            return;
                        break;
                    }
            }
        }

        private void NvgHuy_Click(object sender, EventArgs e)
        {
            LoadDanhSachHoaDonBan();
        }

        private void NvgThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       //--------------------Loại Hóa Đơn Bán--------------------------------------------
        private void tabItemLoaiHDBan_Click(object sender, EventArgs e)
        {
            LoadDataComboboxMaLoaiHoaDonBan();
            LoadDanhSachLoaiHoaDonBan();
        }
        public void LoadDanhSachLoaiHoaDonBan()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoaiHDBanBLL.LayDanhSachLoaiHoaDonBan();
            grivLoaiHDBan.DataSource = bds;
            bindingHDBan.BindingSource = bds;
            //HienThiDuLieuLenControl(0);
            //SetControlEnable(false);
            grivLoaiHDBan.AllowUserToAddRows = false;
        }
        private void LoadDataComboboxMaLoaiHoaDonBan()
        {
            toolStripcmbMaLoaiHDBan.ComboBox.DataSource = LoaiHDBanBLL.LayDanhSachMaLoaiHoaDonBan();
            toolStripcmbMaLoaiHDBan.ComboBox.DisplayMember = "MaLoaiHDBan";

        }
        private void toolStripcmbMaLoaiHDBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoaiHDBanBLL.TimTatCaLoaiHoaDonBanChinhXacTheoMaLoaiHoaDonBan(comboMaKhachHang.ComboBox.SelectedValue.ToString());
            grivLoaiHDBan.DataSource = bds;
            bindingLoaiHoaDonBan.BindingSource = bds;
            //SetControlEnable(false);
        }

        private void toolStriptxtTenLoaiHDBan_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoaiHDBanBLL.TimTatCaLoaiHoaDonTheoTenLoaiHoaDon(txtTimKiem.Text);
            grivLoaiHDBan.DataSource = bds;
            bindingLoaiHoaDonBan.BindingSource = bds;
            //SetControlEnable(false);
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            tabItemLoaiHDBan_Click(sender, e);
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            th = 1;
            grivLoaiHDBan.AllowUserToAddRows = true;
            bindingLoaiHoaDonBan.BindingSource.MoveLast();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (grivLoaiHDBan.RowCount == 0)
                toolStripXoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoaiHDBanBLL.XoaLoaiHDBan(grivLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].Value.ToString());
                LoadDanhSachLoaiHoaDonBan();
                //SetControlThemEnable(true);
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            switch (th)
            {
                case 1://Them
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingposition.Focus();
                            string maloaihoadonban = grivLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].Value.ToString();
                            string tenloaihoadonban = grivLoaiHDBan.CurrentRow.Cells["ColumnTenLoaiHDBan"].Value.ToString();
                            
                            LoaiHDBanBLL.ThemLoaiHDBan(maloaihoadonban, tenloaihoadonban);
                            //SetControlThemEnable(true);
                            //SetConTrolThemSuaEnable(1, true);
                            LoadDanhSachLoaiHoaDonBan();
                            th = 0;
                        }
                        else
                        {
                            th = 0;
                            return;
                        }
                        break;
                    }
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingposition.Focus();
                            QuanLy_KeToan.DataAccessLayer.LoaiHDBan loaihoadonban = new QuanLy_KeToan.DataAccessLayer.LoaiHDBan();
                            string maloaihoadonban = grivLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].Value.ToString();
                            loaihoadonban.TenLoaiHDBan = grivLoaiHDBan.CurrentRow.Cells["ColumnTenLoaiHDBan"].Value.ToString();

                            LoaiHDBanBLL.SuaLoaiHDBan(maloaihoadonban, loaihoadonban);
                            LoadDanhSachLoaiHoaDonBan();
                        }
                        else
                            return;
                        break;
                    }
            }
        }

        private void toolStripHuy_Click(object sender, EventArgs e)
        {
            LoadDanhSachLoaiHoaDonBan();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
        
    }
}
