using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.BusinessLogicLayer;
using DevComponents.DotNetBar.Rendering;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmHangHoa : DevComponents.DotNetBar.Office2007Form
    {
        public FrmHangHoa()
        {
            InitializeComponent();
        }
       
        HangBLL HBLL = new HangBLL();
        private int th=0;
        private bool _MColorSelected;
        private eOffice2007ColorScheme _MBaseColorScheme = eOffice2007ColorScheme.Blue;
        int loadtreeview = 0;
        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            if (loadtreeview == 0)
            {
                LoadTreeView();
            }
            loadtreeview++;
            LoadDataComboboxNhaCungCap();
            LoadDataComboboxDonVi();
            LoadDataColumnCombobox();
            LoadDataComboboxLoaiHang();
            LoadDanhSachHang();
            SetConTrolThemSuaEnable(1, true);
            SetControlThemEnable(true);
            SetControlSuaEnable(true);
            SetTxtKetQuaTimNull();
        }
        private void LoadDanhSachHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.LayDanhSachHangHoa();
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            HienThiDuLieuLenControl(0);
            SetControlEnable(false);
            gridHangHoa.AllowUserToAddRows = false;
        }
        private void LoadTreeView()
        {
            foreach (var item in HBLL.LayDanhSachTenLoaiHang())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                advTreeLoaiHangHoa.Nodes[0].Nodes.Add(childnode);
            }
            foreach (var item in HBLL.LayDanhSachTenNCC())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item);
                advTreeLoaiHangHoa.Nodes[1].Nodes.Add(childnode);
                foreach (var items in HBLL.LayDanhSachTenLoaiHangTheoNCC(childnode.Text))
                {
                    DevComponents.AdvTree.Node child_node = new DevComponents.AdvTree.Node(items);
                    childnode.Nodes.Add(child_node);
                }
            }

            advTreeLoaiHangHoa.CollapseAll();
        }

        private void advTreeLoaiHangHoa_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //if ((e.Node.Index == 0 || e.Node.Index==1) && e.Node.Parent==null)
            if (e.Node.Level == 0)
                LoadDanhSachHang();
            else
            {
                //Duyệt các node con của danh mục loại hàng hóa
                if (e.Node.Parent.Index == 0 && e.Node.Level == 1)
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = HBLL.LayDanhSachHangTheoLoaiHang(e.Node.Text);
                    gridHangHoa.DataSource = bds;
                    bindingHangHoa.BindingSource = bds;
                }
                else if (e.Node.Parent.Index == 1 && e.Node.Level == 1)
                {

                }
                else if (e.Node.Level == 2)
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = HBLL.LayDanhSachHangTheoTenNhaCungCap(e.Node.Parent.Text, e.Node.Text);
                    gridHangHoa.DataSource = bds;
                    bindingHangHoa.BindingSource = bds;
                }
            }
        }
        #region "Thay đổi màu giao diện"
        private void buttonSilver_Click(object sender, EventArgs e)
        {

            styleManagerHH.ManagerStyle = eStyle.Office2007Silver;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Silver);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            styleManagerHH.ManagerStyle = eStyle.Office2007Blue;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Blue);
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            styleManagerHH.ManagerStyle = eStyle.Office2007Black;
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
        private string filename = null;
        private void HienThiDuLieuLenControl(int dong)
        {
            txtMaHang.Text = gridHangHoa.Rows[dong].Cells["ColMaHang"].Value.ToString();
            string tenlh = "";
            foreach (var item in HBLL.LayDanhSachTenLoaiHangTheoMaLoaiHang(gridHangHoa.Rows[dong].Cells["ColMaLoaiHang"].Value.ToString()))
            {
                tenlh = item.ToString();
            }
            cmbMaLoaiHang.Text = tenlh;
            string tenncc = "";
            foreach (var item in HBLL.LayDanhSachTenNCCTheoMaNCC(gridHangHoa.Rows[dong].Cells["ColMaNCC"].Value.ToString()))
            {
                tenncc = item.ToString();
            }
            cmbNCC.Text = tenncc;
            cmbMaLoaiHang.DisplayMember = gridHangHoa.Rows[dong].Cells["ColMaNCC"].Value.ToString();
            txtTenHang.Text = gridHangHoa.Rows[dong].Cells["ColTenHang"].Value.ToString();
            txtMoTaHang.Text = gridHangHoa.Rows[dong].Cells["ColMoTaHang"].Value.ToString();
            string tendonvitinh = "";
            foreach(var item in HBLL.LayDanhSachTenDVTinhTheoMaDVTinh(gridHangHoa.Rows[dong].Cells["ColDonViTinh"].Value.ToString()))
            {
                tendonvitinh=item.ToString();
            }
            cmbDonViTinh.Text = tendonvitinh;
            doubleInputVAT.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColVAT"].Value.ToString());
            doubleInputThueNhapKhau.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColThueNhapKhau"].Value.ToString());
            doubleInputDonGia.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColDonGia"].Value.ToString());
            doubleInputGiamGia.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColGiamGia"].Value.ToString());
            if (gridHangHoa.Rows[dong].Cells["ColHinh"].Value != null)
            {
                filename = gridHangHoa.Rows[dong].Cells["ColHinh"].Value.ToString();
                picHang.Image = new Bitmap(Application.StartupPath + "\\Hang\\" + filename);
            }
            else
            {
                filename = null;
                picHang.Image = null;
            }
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingHangHoa.BindingSource.MoveLast();
        }

        private void gridHangHoa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            if (dong < gridHangHoa.RowCount-1)
            {
                HienThiDuLieuLenControl(dong);
            }
        }
        private void LoadDataComboboxNhaCungCap()
        {
            cmbNCC.DataSource = HBLL.LayDanhSachNCC();
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
            cmbTimKiemMaNCC.DataSource = HBLL.LayDanhSachNCC();
            cmbTimKiemMaNCC.DisplayMember = "TenNCC";
            cmbTimKiemMaNCC.ValueMember = "MaNCC";
        }
        private void LoadDataComboboxDonVi()
        {
            cmbDonViTinh.DataSource = HBLL.LayDanhSachTenDonViTinh();
            cmbDonViTinh.DisplayMember="TenDonViTinh";
            cmbDonViTinh.ValueMember="MaDonViTinh";
            //
            cmbTimKiemDVTinh.DataSource = HBLL.LayDanhSachTenDonViTinh();
            cmbTimKiemDVTinh.DisplayMember = "TenDonViTinh";
            cmbTimKiemDVTinh.ValueMember = "MaDonViTinh";
        }
        private void LoadDataComboboxLoaiHang()
        {
            comboMaLoaiHang.ComboBox.DataSource = HBLL.LayDanhSachMaLoaiHang();
            comboMaLoaiHang.ComboBox.DisplayMember = "MaLoaiHang";
            toolStripcmbMaLoaiHang.ComboBox.DataSource = HBLL.LayDanhSachMaLoaiHang();
            toolStripcmbMaLoaiHang.ComboBox.DisplayMember = "MaLoaiHang";

        }
        private void LoadDataColumnCombobox()
        {
            ColMaLoaiHang.DataSource = HBLL.LayDanhSachMaLoaiHang();
            ColMaLoaiHang.DisplayMember = "MaLoaiHang";
            ColMaNCC.DataSource = HBLL.LayDanhSachMaNCC();
            ColMaNCC.DisplayMember = "MaNCC";
            ColDonViTinh.DataSource = HBLL.LayDanhSachMaDonViTinh();
            ColDonViTinh.DisplayMember = "MaDonViTinh";
        }
        private void SetTxtKetQuaTimNull()
        {
            txtRecords.Text = "";
            txtrecord.Text = "";
            txtThay.Text = "";
        }
        private void SetConTrolHangToNull()
        {
            txtMaHang.Clear();
            cmbMaLoaiHang.Text = "";
            cmbNCC.Text = "";
            txtTenHang.Text = "";
            cmbDonViTinh.Text = "";
            txtMoTaHang.Clear();
            doubleInputVAT.Value = 0;
            doubleInputThueNhapKhau.Value = 0;
            doubleInputDonGia.Value = 0;
            doubleInputGiamGia.Value = 0;
            filename = null;
            picHang.Image = null;
        }
        private void SetControlEnable(bool enable=true)
        {
            txtMaHang.Enabled = enable;
            cmbMaLoaiHang.Enabled=enable;
            cmbNCC.Enabled=enable;
            txtTenHang.Enabled=enable;
            cmbDonViTinh.Enabled = enable;
            txtMoTaHang.Enabled = enable;
            doubleInputVAT.Enabled = enable;
            doubleInputThueNhapKhau.Enabled = enable;
            doubleInputDonGia.Enabled = enable;
            doubleInputGiamGia.Enabled = enable;
            picHang.Enabled = enable;
            btnBoHinh.Enabled = enable;
        }
        private void SetControlThemEnable(bool enable=true)
        {
            btnThem.Enabled = enable;
            btnLuuThem.Enabled = !enable;
            btnHuyThem.Enabled = !enable;
        }
        private void SetControlSuaEnable(bool enable = true)
        {
            btnSua.Enabled = enable;
            btnLuuSua.Enabled = !enable;
            btnHuySua.Enabled = !enable;
        }
        private void SetConTrolThemSuaEnable(int th,bool enable = true)
        {
            switch(th)
            {
                case 1://khởi động chương trình
                    {
                        buttonItemThemHang.Enabled = enable;
                        buttonItemSuaHang.Enabled = enable;
                        break;
                    }
                case 2://các trường hợp khác
                    {
                        buttonItemThemHang.Enabled = enable;
                        buttonItemSuaHang.Enabled = !enable;
                        break;
                    }
            }
        }
        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (KiemTraControl() == true)
                {
                    string maloaihang = cmbMaLoaiHang.SelectedValue.ToString();
                    string mancc = cmbNCC.SelectedValue.ToString();
                    string dvtinh = cmbDonViTinh.SelectedValue.ToString();
                    HBLL.ThemHangHoa(txtMaHang.Text, maloaihang, mancc, txtTenHang.Text, dvtinh, txtMoTaHang.Text, float.Parse(doubleInputVAT.Value.ToString()), float.Parse(doubleInputThueNhapKhau.Value.ToString()), System.Convert.ToDecimal(doubleInputDonGia.Value), float.Parse(doubleInputGiamGia.Value.ToString()), filename);
                    SetControlThemEnable(true);
                    SetConTrolThemSuaEnable(1, true);
                    LoadDanhSachHang();
                }
                else
                {
                    MessageBox.Show("Nhập thiếu thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }
        //Kiểm tra các điều khiển
        private bool KiemTraControl()
        {
            bool kt;
            if ((cmbMaLoaiHang.Text == "") || (txtMaHang.Text == "")||(cmbNCC.Text=="")||(cmbDonViTinh.Text=="")||(txtTenHang.Text==""))
            {
                kt = false;
            }
            else
            {
                kt = true;
            }
            return kt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SetControlEnable(true);
            SetControlThemEnable(false);
            SetConTrolThemSuaEnable(2, true);
            SetConTrolHangToNull();
        }

        private void cmbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMaLoaiHang.DataSource = HBLL.LayDanhSachLoaiHangHoa(cmbNCC.Text);
            cmbMaLoaiHang.DisplayMember = "TenLoaiHang";
            cmbMaLoaiHang.ValueMember = "MaLoaiHang";
        }

        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridHangHoa.RowCount == 0)
               btnXoaHang.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HBLL.XoaHangHoa(gridHangHoa.CurrentRow.Cells["ColMaHang"].Value.ToString());
                LoadDanhSachHang();
                SetControlThemEnable(true);
            }
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác thêm?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachHang();
                SetControlThemEnable(true);
                SetConTrolThemSuaEnable(1, true);
            }
            else
            {
                return;
            }
        }

        private void buttonItemThemHang_Click(object sender, EventArgs e)
        {
            SetConTrolThemSuaEnable(2, true);
        }

        private void buttonItemSuaHang_Click(object sender, EventArgs e)
        {
            SetConTrolThemSuaEnable(2, false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable(true);
            txtMaHang.ReadOnly = true;
            SetControlSuaEnable(false);
            SetConTrolThemSuaEnable(2,false);
        }

        private void btnLuuSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (KiemTraControl() == true)
                {
                    Hang hang = new Hang();
                    string maloaihang = cmbMaLoaiHang.SelectedValue.ToString();
                    hang.MaLoaiHang = maloaihang;
                    string mancc = cmbNCC.SelectedValue.ToString();
                    hang.MaNCC = mancc;
                    string dvtinh = cmbDonViTinh.SelectedValue.ToString();
                    hang.MaDonViTinh = dvtinh;
                    hang.TenHang = txtTenHang.Text;
                    hang.MoTaHang = txtMoTaHang.Text;
                    hang.VAT = float.Parse(doubleInputVAT.Value.ToString());
                    hang.ThueNhapKhau = float.Parse(doubleInputThueNhapKhau.Value.ToString());
                    hang.DonGia = System.Convert.ToDecimal(doubleInputDonGia.Value);
                    hang.GiamGia = float.Parse(doubleInputGiamGia.Value.ToString());
                    hang.Hinh = filename;
                    HBLL.SuaHang(txtMaHang.Text, hang);
                    SetControlSuaEnable(true);
                    SetConTrolThemSuaEnable(1, true);
                    LoadDanhSachHang();
                    txtMaHang.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Nhập thiếu thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }

        private void btnHuySua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác sửa?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachHang();
                SetControlSuaEnable(true);
                SetConTrolThemSuaEnable(1, true);
                txtMaHang.ReadOnly = false;
            }
            else
            {
                return;
            }
        }
        private void NvgThem_Click(object sender, EventArgs e)
        {
            th=1;
            gridHangHoa.AllowUserToAddRows = true;
            bindingHangHoa.BindingSource.MoveLast();
        }
        //Thao Tác Trực Tiếp Trên Lưới
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
                            string mahang = gridHangHoa.CurrentRow.Cells["ColMaHang"].Value.ToString();
                            string maloaihang = gridHangHoa.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            string mancc = gridHangHoa.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            string tenhang = gridHangHoa.CurrentRow.Cells["ColTenHang"].Value.ToString();
                            string dvtinh = gridHangHoa.CurrentRow.Cells["ColDonViTinh"].Value.ToString();
                            string motahang = gridHangHoa.CurrentRow.Cells["ColMoTaHang"].Value.ToString();
                            float vat = float.Parse(gridHangHoa.CurrentRow.Cells["ColVAT"].Value.ToString());
                            float tax = float.Parse(gridHangHoa.CurrentRow.Cells["ColThueNhapKhau"].Value.ToString());
                            decimal dongia = System.Convert.ToDecimal(float.Parse(gridHangHoa.CurrentRow.Cells["ColDonGia"].Value.ToString()));
                            float giamgia = float.Parse(gridHangHoa.CurrentRow.Cells["ColGiamGia"].Value.ToString());
                            if (gridHangHoa.CurrentRow.Cells["ColHinh"].Value != null)
                            {
                                filename = gridHangHoa.CurrentRow.Cells["ColHinh"].Value.ToString();
                            }
                            else
                            {
                                filename = null;
                            }
                            HBLL.ThemHangHoa(mahang, maloaihang, mancc, tenhang, dvtinh, motahang, vat, tax, dongia, giamgia, filename);
                            SetControlThemEnable(true);
                            SetConTrolThemSuaEnable(1, true);
                            LoadDanhSachHang();
                            th = 0;
                        }
                        else
                        {
                            truonghop = 0;
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
                            Hang hang = new Hang();
                            string mahang = gridHangHoa.CurrentRow.Cells["ColMaHang"].Value.ToString();
                            hang.MaLoaiHang = gridHangHoa.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            hang.MaNCC = gridHangHoa.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            hang.TenHang = gridHangHoa.CurrentRow.Cells["ColTenHang"].Value.ToString();
                            hang.MaDonViTinh = gridHangHoa.CurrentRow.Cells["ColDonViTinh"].Value.ToString();
                            hang.MoTaHang = gridHangHoa.CurrentRow.Cells["ColMoTaHang"].Value.ToString();
                            hang.VAT = float.Parse(gridHangHoa.CurrentRow.Cells["ColVAT"].Value.ToString());
                            hang.ThueNhapKhau = float.Parse(gridHangHoa.CurrentRow.Cells["ColThueNhapKhau"].Value.ToString());
                            hang.DonGia = System.Convert.ToDecimal(float.Parse(gridHangHoa.CurrentRow.Cells["ColDonGia"].Value.ToString()));
                            hang.GiamGia = float.Parse(gridHangHoa.CurrentRow.Cells["ColGiamGia"].Value.ToString());
                            if (gridHangHoa.CurrentRow.Cells["ColHinh"].Value != null)
                            {
                                filename = gridHangHoa.CurrentRow.Cells["ColHinh"].Value.ToString();
                            }
                            else
                            {
                                filename = null;
                            }
                            hang.Hinh=filename;
                            HBLL.SuaHang(mahang,hang);
                            LoadDanhSachHang();
                        }
                        else
                            return;
                        break;
                    }
            }
        }

        private void NvgThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTatCaHangTheoMaLoaiHang(comboMaLoaiHang.Text);
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTatCaHangTheoMaHang(txtTimKiem.Text);
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
        }

        private void NvgRefresh_Click(object sender, EventArgs e)
        {
            FrmHangHoa_Load(sender, e);
        }
        private void NvgHuy_Click(object sender, EventArgs e)
        {
            LoadDanhSachHang();
        }
        private void cmbTimKiemMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTimKiemMaLH.DataSource = HBLL.LayDanhSachLoaiHangHoa(cmbTimKiemMaNCC.Text);
            cmbTimKiemMaLH.DisplayMember = "TenLoaiHang";
            cmbTimKiemMaLH.ValueMember = "MaLoaiHang";
        }

        private void cmbTimKiemMaLH_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataColumnCombobox();
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.LayDanhSachHangTheoTenNhaCungCap(cmbTimKiemMaNCC.Text, cmbTimKiemMaLH.Text);
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = gridHangHoa.RowCount.ToString();
        }

        private void btnTimMaHang_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTatCaHangChinhXacTheoMaHang(txtTimKiemMaHang.Text);
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = gridHangHoa.RowCount.ToString();
        }

        private void btnTimTenHang_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTatCaHangChinhXacTheoMaHang(txtTimKiemTenHang.Text);
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = gridHangHoa.RowCount.ToString();
        }

        private void cmbTimKiemDVTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTatCaHangChinhXacTheoDVTinh(cmbTimKiemDVTinh.SelectedValue.ToString());
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtrecord.Text = gridHangHoa.RowCount.ToString();
        }

        private void btnTimDonGia_Click(object sender, EventArgs e)
        {
            if (doubleInputDenGia.Value >= doubleInputTuGia.Value)
            {
                BindingSource bds = new BindingSource();
                bds.DataSource = HBLL.TimTatCaHangTheoGiaSanPham(System.Convert.ToDecimal(doubleInputTuGia.Value), System.Convert.ToDecimal(doubleInputDenGia.Value));
                gridHangHoa.DataSource = bds;
                bindingHangHoa.BindingSource = bds;
                SetControlEnable(false);
                txtrecord.Text = gridHangHoa.RowCount.ToString();
                if (gridHangHoa.RowCount == 0)
                    MessageBox.Show("Không tìm thấy sản phẩm với khoảng giá trên!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Giá không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnTimKiemGiaChinhXac_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimChinhXacGiaSanPham(System.Convert.ToDecimal(dpiGiaChinhXac.Value));
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtrecord.Text = gridHangHoa.RowCount.ToString();
            if(gridHangHoa.RowCount==0)
                MessageBox.Show("Không tìm thấy sản phẩm với giá trên!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimVAT_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTheoVAT(float.Parse(doubleInputTimKiemVAT.Value.ToString()));
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtThay.Text = gridHangHoa.RowCount.ToString();
            if (gridHangHoa.RowCount == 0)
                MessageBox.Show("Không tìm thấy sản phẩm với thuế VAT trên!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimGiamGia_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTheoGiamGia(float.Parse(dbiTimKiemGiamGia.Value.ToString()));
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtThay.Text = gridHangHoa.RowCount.ToString();
            if (gridHangHoa.RowCount == 0)
                MessageBox.Show("Không tìm thấy sản phẩm với giá trị giảm giá trên!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimThueNK_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.TimTheoThueNhapKhau(float.Parse(dbiTimKiemThueNK.Value.ToString()));
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            SetControlEnable(false);
            txtThay.Text = gridHangHoa.RowCount.ToString();
            if (gridHangHoa.RowCount == 0)
                MessageBox.Show("Không tìm thấy sản phẩm vói mức thuế nhập khẩu trên!", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Lấy tên file hình
        private void picHang_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Application.StartupPath + @"\Hang";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                filename = dlg.FileName.Substring(dlg.FileName.LastIndexOf("\\") + 1, dlg.FileName.Length - dlg.FileName.LastIndexOf("\\") - 1);
                try
                {
                    picHang.Image = new Bitmap(Application.StartupPath + @"\Hang\" + filename);
                }
                catch { }
            }
        }

        private void btnBoHinh_Click(object sender, EventArgs e)
        {
            if (filename != "")
            {
                filename= "";
                picHang.Image = null;
            }
        }
      


        //------------------LOẠI HÀNG HÓA-----------------------------------------------//
        LoaiHangBLL LHHBLL = new LoaiHangBLL();
        private void tabItemLoaiHH_Click(object sender, EventArgs e)
        {
            bar1.AutoHide = true;
            LoadDanhSachLoaiHang();
        }

        private void tabItemHH_Click(object sender, EventArgs e)
        {
            bar1.AutoHide = false;
        }
        private void LoadDanhSachLoaiHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LHHBLL.LoadDanhSachLoaiHangHoa(); 
            gridLoaiHH.DataSource = bds;
            bindingLoaiHangHoa.BindingSource = bds;
            gridHangHoa.AllowUserToAddRows = false;
        }
        private int truonghop = 0;
        private void toolStripThem_Click(object sender, EventArgs e)
        {
            truonghop = 1;
            gridLoaiHH.AllowUserToAddRows = true;
            bindingLoaiHangHoa.BindingSource.MoveLast();
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            switch (truonghop)
            {
                case 0://sửa loại hàng hóa
                    {

                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingposition.Focus();
                            LoaiHang loaihang = new LoaiHang();
                            string maloaihang = gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].Value.ToString();
                            loaihang.TenLoaiHang = gridLoaiHH.CurrentRow.Cells["ColumnTenLH"].Value.ToString();
                            loaihang.MoTaLoaiHang = gridLoaiHH.CurrentRow.Cells["ColumnMoTaLH"].Value.ToString();
                            loaihang.NgayLap = System.Convert.ToDateTime(gridLoaiHH.CurrentRow.Cells["ColumnNgayLap"].Value.ToString());
                            loaihang.NguoiLap = (gridLoaiHH.CurrentRow.Cells["ColumnNguoiLap"].Value != null ? gridLoaiHH.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            loaihang.NgaySua = System.Convert.ToDateTime(gridLoaiHH.CurrentRow.Cells["ColumnNgaySua"].Value.ToString());
                            loaihang.NguoiSua = (gridLoaiHH.CurrentRow.Cells["ColumnNguoiSua"].Value != null ? gridLoaiHH.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            LHHBLL.SuaLoaiHang(maloaihang, loaihang);
                            LoadDanhSachLoaiHang();
                        }
                        else
                            return;
                        break;
                    }
                case 1://thêm loại hàng
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingposition.Focus();
                            string maloaihang = gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].Value.ToString();
                            string tenloaihang = gridLoaiHH.CurrentRow.Cells["ColumnTenLH"].Value.ToString();
                            string motaloaihang = gridLoaiHH.CurrentRow.Cells["ColumnMoTaLH"].Value.ToString();
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridLoaiHH.CurrentRow.Cells["ColumnNgayLap"].Value) != temp)
                            {
                                MessageBox.Show(gridLoaiHH.CurrentRow.Cells["ColumnNgayLap"].Value.ToString());
                                ngaylap = System.Convert.ToDateTime(gridLoaiHH.CurrentRow.Cells["ColumnNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoaiHH.CurrentRow.Cells["ColumnNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoaiHH.CurrentRow.Cells["ColumnNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoaiHH.CurrentRow.Cells["ColumnNguoiLap"].Value != null ? gridLoaiHH.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoaiHH.CurrentRow.Cells["ColumnNguoiSua"].Value != null ? gridLoaiHH.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            LHHBLL.ThemLoaiHang(maloaihang, tenloaihang, motaloaihang, ngaylap, nguoilap, ngaysua, nguoisua);
                            LoadDanhSachLoaiHang();
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

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            tabItemLoaiHH_Click(sender, e);
        }

        private void toolStripHuy_Click(object sender, EventArgs e)
        {
            LoadDanhSachLoaiHang();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridLoaiHH.RowCount == 0)
                toolStripXoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LHHBLL.XoaLoaiHang(gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].Value.ToString());
                LoadDanhSachLoaiHang();
            }
        }

        private void toolStripcmbMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LHHBLL.LayDanhSachLoaiHangTheoMaLH(toolStripcmbMaLoaiHang.Text);
            gridLoaiHH.DataSource = bds;
            bindingLoaiHangHoa.BindingSource = bds;
            gridLoaiHH.AllowUserToAddRows = false;
        }

        private void toolStriptxtTenLoaiHang_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LHHBLL.LayDanhSachLoaiHangTheoTenLH(toolStriptxtTenLoaiHang.Text);
            gridLoaiHH.DataSource = bds;
            bindingLoaiHangHoa.BindingSource = bds;
            gridLoaiHH.AllowUserToAddRows = false;
        }

    }
}