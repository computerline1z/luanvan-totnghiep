using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using QuanLy_KeToan.BusinessLogicLayer;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmDanhMucChung : DevComponents.DotNetBar.Office2007Form
    {
        public FrmDanhMucChung()
        {
            InitializeComponent();
        }
        //-------------------------Quản Lý Danh Mục Nhà Cung Cấp--------------------------------//
        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #region "Hiệu chỉnh màu cho Form"
        private bool _MColorSelected;
        private eOffice2007ColorScheme _MBaseColorScheme = eOffice2007ColorScheme.Blue;       

        private void buttonSilver_Click(object sender, EventArgs e)
        {
            styleManagerQuanLyChung.ManagerStyle = eStyle.Office2007Silver;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Silver);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            styleManagerQuanLyChung.ManagerStyle = eStyle.Office2007Blue;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Blue);
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            styleManagerQuanLyChung.ManagerStyle = eStyle.Office2007Black;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Black);
        }

        private void colorPickerButton_SelectedColorChanged(object sender, EventArgs e)
        {
            _MColorSelected = true;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme, colorPickerButton.SelectedColor);
        }

        private void colorPickerButton_ColorPreview(object sender, ColorPreviewEventArgs e)
        {
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme, e.Color);
        }

        private void colorPickerButton_PopupOpen(object sender, EventArgs e)
        {
            if (colorPickerButton.Expanded)
            {
                // Remember the starting color scheme to apply
                // if no color is selected during live-preview

                _MColorSelected = false;
                _MBaseColorScheme = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.InitialColorScheme;
            }
            else
            {
                if (_MColorSelected == false)
                    RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme);
            }
        }

        private void colorPickerButton_PopupClose(object sender, EventArgs e)
        {
            if (colorPickerButton.Expanded)
            {
                // Remember the starting color scheme to apply
                // if no color is selected during live-preview

                _MColorSelected = false;
                _MBaseColorScheme = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.InitialColorScheme;
            }
            else
            {
                if (_MColorSelected == false)
                    RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme);
            }
        }
        #endregion

        NhaCungCapBLL NCCBLL = new NhaCungCapBLL();
        LoaiHangBLL LHBLL = new LoaiHangBLL();
        private int read = 0;
        private int th = 0;
        private void LoadDataComboboxColumn()
        {
            ColMaTinh.DataSource = NCCBLL.LoadDanhSachMaTinh();
            ColMaTinh.DisplayMember = "MaTinh";
            ColMaLoaiHang.DataSource = LHBLL.LoadDanhSachLoaiHangHoa();
            ColMaLoaiHang.DisplayMember = "MaLoaiHang";
        }
        public void LoadDanhSachNCC()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNCC();
            gridNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            gridNCC.AllowUserToAddRows = false;
            gridNCC.ReadOnly = true;
        }
        public void LoadDanhSachMaNCC()
        {
            comboboxMNCC.ComboBox.DataSource = NCCBLL.LayDanhSachMNCC();
            comboboxMNCC.ComboBox.DisplayMember = "MaNCC";
        }
        private void FrmDanhMucChung_Load(object sender, EventArgs e)
        {
            LoadDataComboboxColumn();
            LoadDanhSachMaNCC();
            LoadDanhSachNCC();
        }
        private void Sua_Click(object sender, EventArgs e)
        {
            read = 0;
            th = 0;
        }
        private void gridNCC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            switch(read)
            {
                case 0://trường hợp sửa
                    {
                        gridNCC.ReadOnly = false;
                        gridNCC.Rows[dong].Cells["ColMaNCC"].ReadOnly = true;
                        gridNCC.Rows[dong].Cells["ColMaLoaiHang"].ReadOnly = true;
                        break;
                    }
                case 1://trường hợp thêm
                    {
                        gridNCC.ReadOnly = false;
                        break;
                    }
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            th = 1;//Thêm
            read = 1;
            gridNCC.AllowUserToAddRows = true;
            bindingNCC.BindingSource.MoveLast();
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            switch (th)
            {
                case 0://sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            position.Focus();
                            NhaCungCap NCC = new NhaCungCap();
                            string mancc = gridNCC.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            string maloaihang = gridNCC.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            NCC.TenNCC = gridNCC.CurrentRow.Cells["ColTenNCC"].Value.ToString();
                            NCC.DCNCC = gridNCC.CurrentRow.Cells["ColDiaChiNCC"].Value.ToString();
                            NCC.MaTinh = gridNCC.CurrentRow.Cells["ColMaTinh"].Value.ToString();
                            NCC.SoDT = gridNCC.CurrentRow.Cells["ColSoDT"].Value.ToString();
                            NCC.SoFax = gridNCC.CurrentRow.Cells["ColSoFax"].Value.ToString();
                            NCC.Email = gridNCC.CurrentRow.Cells["ColEmail"].Value.ToString();
                            NCCBLL.SuaNCC(mancc, maloaihang, NCC);
                            LoadDanhSachNCC();
                        }
                        else
                            return;
                        break;
                    }
                case 1://thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            position.Focus();
                            string mancc = gridNCC.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            string maloaihang = gridNCC.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            string tenncc = gridNCC.CurrentRow.Cells["ColTenNCC"].Value.ToString();
                            string dcncc = gridNCC.CurrentRow.Cells["ColDiaChiNCC"].Value.ToString();
                            string matinh = gridNCC.CurrentRow.Cells["ColMaTinh"].Value.ToString();
                            string sodt = gridNCC.CurrentRow.Cells["ColSoDT"].Value.ToString();
                            string sofax = gridNCC.CurrentRow.Cells["ColSoFax"].Value.ToString();
                            string email = gridNCC.CurrentRow.Cells["ColEmail"].Value.ToString();
                            NCCBLL.ThemNCC(mancc, maloaihang, tenncc, dcncc, matinh, sodt, sofax, email);
                            LoadDanhSachNCC();
                            th = 0;
                            read = 0;
                        }
                        else
                        {
                            th = 0;
                            return;
                        }
                        break;
                    }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridNCC.RowCount == 0)
                Xoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NCCBLL.XoaNCC(gridNCC.CurrentRow.Cells["ColMaNCC"].Value.ToString(), gridNCC.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString());
                LoadDanhSachNCC();
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            FrmDanhMucChung_Load(sender, e);
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            LoadDanhSachNCC();
        }

        private void comboboxMNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNhaCungCapTheoMa(comboboxMNCC.Text);
            gridNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            gridNCC.AllowUserToAddRows = false;
            gridNCC.ReadOnly = true;
        }
        private void txtTenNCC_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNhaCungCapTheoTen(txtTenNCC.Text);
            gridNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            gridNCC.AllowUserToAddRows = false;
            gridNCC.ReadOnly = true;
        }

        //---------------------------Code Nước-Tỉnh Thành

        //Nước
        NuocBLL NBLL = new NuocBLL();
        private void LayDanhSachNuoc()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NBLL.LayDanhSachNuoc();
            bindingNuoc.BindingSource = bds;
            gridNuoc.DataSource = bds;
            gridNuoc.AllowUserToAddRows = false;
        }

        private void tabItemTinhThanh_Click(object sender, EventArgs e)
        {
            LayNuoc();
            LayDanhSachNuoc();
            LoadColumnTinh();
            LoadDSTinh();
        }
        private int truonghop = 0;
        private void ThemNuoc_Click(object sender, EventArgs e)
        {
            truonghop = 1;
            gridNuoc.AllowUserToAddRows = true;
            bindingNuoc.BindingSource.MoveLast();
        }

        private void LuuNuoc_Click(object sender, EventArgs e)
        {
            switch (truonghop)
            {
                case 0://sửa thông tin nước
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionNuoc.Focus();
                            Nuoc N = new Nuoc();
                            string manuoc = gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString();
                            N.TenNuoc = gridNuoc.CurrentRow.Cells["ColTenNuoc"].Value.ToString();
                            N.NgayLap = System.Convert.ToDateTime(gridNuoc.CurrentRow.Cells["ColNgayLap"].Value.ToString());
                            N.NguoiLap = (gridNuoc.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridNuoc.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            N.NgaySua = System.Convert.ToDateTime(gridNuoc.CurrentRow.Cells["ColNgaySua"].Value.ToString());
                            N.NguoiSua = (gridNuoc.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridNuoc.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            NBLL.SuaNuoc(manuoc,N);
                            LayDanhSachNuoc();
                        }
                        else
                            return;
                        break;
                    }
                case 1://thêm thông tin nước
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionNuoc.Focus();
                            string manuoc = gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString();
                            string tennuoc = (gridNuoc.CurrentRow.Cells["ColTenNuoc"].Value != null ? gridNuoc.CurrentRow.Cells["ColTenNuoc"].Value.ToString() : "");
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridNuoc.CurrentRow.Cells["ColNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridNuoc.CurrentRow.Cells["ColNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridNuoc.CurrentRow.Cells["ColNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridNuoc.CurrentRow.Cells["ColNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridNuoc.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridNuoc.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridNuoc.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridNuoc.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            NBLL.ThemNuoc(manuoc,tennuoc,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachNuoc();
                            truonghop = 0;
                        }
                        else
                        {
                            truonghop = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void XoaNuoc_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridNuoc.RowCount == 0)
                XoaNuoc.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NBLL.XoaNuoc(gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString());
                LayDanhSachNuoc();
            }
        }

        private void RefreshNuoc_Click(object sender, EventArgs e)
        {
            tabItemTinhThanh_Click(sender, e);
        }

        private void HuyNuoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "HỦY",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachNuoc();
            }
            else
                return;
        }
        private void LayNuoc()
        {
            cmbMaNuoc.ComboBox.DataSource = NBLL.LayDanhSachMaNuoc();
            cmbMaNuoc.ComboBox.DisplayMember = "TenNuoc";
            cmbMaNuoc.ComboBox.ValueMember = "MaNuoc";
        }

        private void cmbMaNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NBLL.LayNuocTheoMaNuoc(cmbMaNuoc.ComboBox.SelectedValue.ToString());
            bindingNuoc.BindingSource = bds;
            gridNuoc.DataSource = bds;
            gridNuoc.AllowUserToAddRows = false;
            //Lấy danh sách tỉnh khi duyệt combobox Nước
            LoadColumnTinh();
            BindingSource _bds = new BindingSource();
            _bds.DataSource = TTBLL.LoadDanhSachTinhThanhTheoMaNuoc(cmbMaNuoc.ComboBox.SelectedValue.ToString());
            bindingTinh.BindingSource = _bds;
            gridTinhThanh.DataSource = _bds;
            gridTinhThanh.AllowUserToAddRows = false;
        }

        private void txtTenNuoc_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NBLL.LayNuocTheoTenNuoc(txtTenNuoc.Text);
            bindingNuoc.BindingSource = bds;
            gridNuoc.DataSource = bds;
            gridNuoc.AllowUserToAddRows = false;
        }
        //------------Phần Tỉnh Thành--------------
        TinhThanhBLL TTBLL = new TinhThanhBLL();

        private void LoadDSTinh()
        {
            comboMaTinh.ComboBox.DataSource = TTBLL.LayTinh();
            comboMaTinh.ComboBox.DisplayMember = "TenTinh";
            comboMaTinh.ComboBox.ValueMember = "MaTinh";
        }

        private void gridNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                BindingSource bds = new BindingSource();
                if (gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value != null)
                {
                    bds.DataSource = TTBLL.LoadDanhSachTinhThanhTheoMaNuoc(gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString());
                }
                bindingTinh.BindingSource = bds;
                gridTinhThanh.DataSource = bds;
                gridTinhThanh.AllowUserToAddRows = false;
        }
        private void LoadColumnTinh()
        {
            ColumnMaNuoc.DataSource = NBLL.LayDanhSachMaNuoc();
            ColumnMaNuoc.DisplayMember = "TenNuoc";
            ColumnMaNuoc.ValueMember = "MaNuoc";
        }
        private int tinh_th = 0;
        private void ThemTinh_Click(object sender, EventArgs e)
        {
            tinh_th = 1;
            gridTinhThanh.AllowUserToAddRows = true;
            bindingTinh.BindingSource.MoveLast();
        }

        private void LuuTinh_Click(object sender, EventArgs e)
        {
            switch (tinh_th)
            {
                case 0://Sửa tỉnh
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionTinh.Focus();
                            TinhThanh T = new TinhThanh();
                            string matinh = gridTinhThanh.CurrentRow.Cells["ColumnMaTinh"].Value.ToString();
                            T.TenTinh = gridTinhThanh.CurrentRow.Cells["ColumnTenTinh"].Value.ToString();
                            T.MaNuoc = gridTinhThanh.CurrentRow.Cells["ColumnMaNuoc"].Value.ToString();
                            T.NguoiLap = (gridTinhThanh.CurrentRow.Cells["ColumnNguoiLap"].Value != null ? gridTinhThanh.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            T.NgayLap = System.Convert.ToDateTime(gridTinhThanh.CurrentRow.Cells["ColumnNgayLap"].Value.ToString());
                            T.NgaySua = System.Convert.ToDateTime(gridTinhThanh.CurrentRow.Cells["ColumnNgaySua"].Value.ToString());
                            T.NguoiSua = (gridTinhThanh.CurrentRow.Cells["ColumnNguoiSua"].Value != null ? gridTinhThanh.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            TTBLL.SuaTinh(matinh, T);
                            BindingSource bds = new BindingSource();
                            bds.DataSource = TTBLL.LoadDanhSachTinhThanhTheoMaNuoc(gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString());
                            bindingTinh.BindingSource = bds;
                            gridTinhThanh.DataSource = bds;
                            gridTinhThanh.AllowUserToAddRows = false;
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm tỉnh
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionTinh.Focus();
                            string matinh = gridTinhThanh.CurrentRow.Cells["ColumnMaTinh"].Value.ToString();
                            string tentinh = gridTinhThanh.CurrentRow.Cells["ColumnTenTinh"].Value.ToString();
                            string manuoc = gridTinhThanh.CurrentRow.Cells["ColumnMaNuoc"].Value.ToString();
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridTinhThanh.CurrentRow.Cells["ColumnNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridTinhThanh.CurrentRow.Cells["ColumnNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridTinhThanh.CurrentRow.Cells["ColumnNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridTinhThanh.CurrentRow.Cells["ColumnNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridTinhThanh.CurrentRow.Cells["ColumnNguoiLap"].Value != null ? gridTinhThanh.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridTinhThanh.CurrentRow.Cells["ColumnNguoiSua"].Value != null ? gridTinhThanh.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            TTBLL.ThemTinh(matinh, tentinh,manuoc,ngaylap, nguoilap, ngaysua, nguoisua);
                            tinh_th = 0;
                            BindingSource bds = new BindingSource();
                            bds.DataSource = TTBLL.LoadDanhSachTinhThanhTheoMaNuoc(gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString());
                            bindingTinh.BindingSource = bds;
                            gridTinhThanh.DataSource = bds;
                            gridTinhThanh.AllowUserToAddRows = false;
                        }
                        else
                        {
                            tinh_th = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void HuyTinh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "HỦY",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BindingSource bds = new BindingSource();
                bds.DataSource = TTBLL.LoadDanhSachTinhThanhTheoMaNuoc(gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString());
                bindingTinh.BindingSource = bds;
                gridTinhThanh.DataSource = bds;
                gridTinhThanh.AllowUserToAddRows = false;
            }
            else
                return;
        }

        private void XoaTinh_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridTinhThanh.RowCount == 0)
                XoaTinh.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TTBLL.XoaTinh(gridTinhThanh.CurrentRow.Cells["ColumnMaTinh"].Value.ToString());
                BindingSource bds = new BindingSource();
                bds.DataSource = TTBLL.LoadDanhSachTinhThanhTheoMaNuoc(gridNuoc.CurrentRow.Cells["ColMaNuoc"].Value.ToString());
                bindingTinh.BindingSource = bds;
                gridTinhThanh.DataSource = bds;
                gridTinhThanh.AllowUserToAddRows = false;
            }
        }

        private void comboMaTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bds = new BindingSource();
                bds.DataSource = TTBLL.LayTinhTheoMaTinh(comboMaTinh.ComboBox.SelectedValue.ToString());
                bindingTinh.BindingSource = bds;
                gridTinhThanh.DataSource = bds;
                gridTinhThanh.AllowUserToAddRows = false;
            }
            catch { }            
        }

        private void txtTenTinh_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = TTBLL.LayTinhTheoTenTinh(txtTenTinh.Text);
            bindingTinh.BindingSource = bds;
            gridTinhThanh.DataSource = bds;
            gridTinhThanh.AllowUserToAddRows = false;
        }
    }
}