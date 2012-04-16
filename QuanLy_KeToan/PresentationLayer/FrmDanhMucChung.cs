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
    }
}