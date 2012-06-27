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
#region (Biến)
private int xoa = 0;
private string filename = null;
#endregion
#region (Thay đổi màu giao diện)
        private bool _MColorSelected;
        private eOffice2007ColorScheme _MBaseColorScheme = eOffice2007ColorScheme.Blue;
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
#region (Hàm dùng chung)
        //Hàm ẩn hiện các groupbox.
        private void AnHienGroup(DevComponents.DotNetBar.Controls.GroupPanel grb1, DevComponents.DotNetBar.Controls.GroupPanel grb2)
        {
            grb2.Dock = DockStyle.None;
            grb2.SendToBack();
            grb1.Dock = DockStyle.Fill;
            grb1.BringToFront();
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
            cmbDonViTinh.DataSource = HBLL.LayDanhSachDonViTinh();
            cmbDonViTinh.DisplayMember = "TenDonViTinh";
            cmbDonViTinh.ValueMember = "MaDonViTinh";
            //
            cmbTimKiemDVTinh.DataSource = HBLL.LayDanhSachDonViTinh();
            cmbTimKiemDVTinh.DisplayMember = "TenDonViTinh";
            cmbTimKiemDVTinh.ValueMember = "MaDonViTinh";
        }
        private void LoadDataComboboxLoaiHang()
        {
            comboMaLoaiHang.ComboBox.DataSource = HBLL.LayDanhSachMaLoaiHang();
            comboMaLoaiHang.ComboBox.DisplayMember = "TenLoaiHang";
            comboMaLoaiHang.ComboBox.ValueMember = "MaLoaiHang";
            toolStripcmbMaLoaiHang.ComboBox.DataSource = HBLL.LayDanhSachMaLoaiHang();
            toolStripcmbMaLoaiHang.ComboBox.DisplayMember = "TenLoaiHang";
            toolStripcmbMaLoaiHang.ComboBox.ValueMember = "MaLoaiHang";

        }
        private void LoadDataComboboxNguoiLap()
        {
            cmbNguoiLap.DataSource = HBLL.LayDanhSachNguoiLap();
            cmbNguoiLap.ValueMember = "TenDangNhap";
            cmbNguoiLap.DisplayMember = "TenDangNhap";
            cmbNguoiSua.DataSource = HBLL.LayDanhSachNguoiSua();
            cmbNguoiSua.ValueMember = "TenDangNhap";
            cmbNguoiSua.DisplayMember = "TenDangNhap";

            //Loại Hàng Hóa
            LH_cmbNguoiLap.DataSource = HBLL.LayDanhSachNguoiLap();
            LH_cmbNguoiLap.ValueMember = "TenDangNhap";
            LH_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LH_cmbNguoiSua.DataSource = HBLL.LayDanhSachNguoiSua();
            LH_cmbNguoiSua.ValueMember = "TenDangNhap";
            LH_cmbNguoiSua.DisplayMember = "TenDangNhap";
        }
        private void LoadDataColumnCombobox()
        {
            ColMaLoaiHang.DataSource = HBLL.LayDanhSachMaLoaiHang();
            ColMaLoaiHang.ValueMember = "MaLoaiHang";
            ColMaLoaiHang.DisplayMember = "TenLoaiHang";
            ColMaNCC.DataSource = HBLL.LayDanhSachMaNCC();
            ColMaNCC.ValueMember = "MaNCC";
            ColMaNCC.DisplayMember = "TenNCC";
            ColDonViTinh.DataSource = HBLL.LayDanhSachDonViTinh();
            ColDonViTinh.ValueMember = "MaDonViTinh";
            ColDonViTinh.DisplayMember = "TenDonViTinh";
            ColNguoiLap.DataSource = HBLL.LayDanhSachNguoiLap();
            ColNguoiLap.ValueMember = "TenDangNhap";
            ColNguoiLap.DisplayMember = "TenDangNhap";
            ColNguoiSua.DataSource = HBLL.LayDanhSachNguoiSua();
            ColNguoiSua.ValueMember = "TenDangNhap";
            ColNguoiSua.DisplayMember = "TenDangNhap";

            //Loai Hàng Hóa
            ColumnNguoiLap.DataSource = LHHBLL.LayDanhSachNguoiLap();
            ColumnNguoiLap.ValueMember = "TenDangNhap";
            ColumnNguoiLap.DisplayMember = "TenDangNhap";
            ColumnNguoiSua.DataSource = LHHBLL.LayDanhSachNguoiSua();
            ColumnNguoiSua.ValueMember = "TenDangNhap";
            ColumnNguoiSua.DisplayMember = "TenDangNhap";

        }
        int truycap = 0;
        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            //Load Combobox
            LoadDataComboboxNhaCungCap();
            LoadDataComboboxDonVi();
            LoadDataComboboxLoaiHang();
            LoadDataComboboxNguoiLap();
            //Load combobox column
            LoadDataColumnCombobox();
            LoadDanhSachHang();
            ToolBarEnable(true);
            SetTxtKetQuaTimNull();
            LayThongTinDangNhap();
        }
#endregion
#region (Xử lý TreeView)
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
            //advTreeLoaiHangHoa.CollapseAll();
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
#endregion
#region (Code phần Hàng)
        HangBLL HBLL = new HangBLL();
        private int nhapluoi=0;

        private void LoadDanhSachHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.LayDanhSachHangHoa();
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
            HienThiDuLieuLenControl(0);
            SetControlEnable(true);
            gridHangHoa.AllowUserToAddRows = false;
        }
        //Thao tác trên lưới
        private void ToolBarEnable(bool DangThaoTac = false)
        {
            NvgThem.Enabled = DangThaoTac;
            NvgXoa.Enabled = DangThaoTac;
            NvgRefresh.Enabled = DangThaoTac;
            NvgLuu.Enabled = !DangThaoTac;
            NvgHuy.Enabled = !DangThaoTac;
        }
        private void NvgRefresh_Click(object sender, EventArgs e)
        {
            FrmHangHoa_Load(sender, e);
            ToolBarEnable(true);
            nhapluoi = 0;
        }
        private void NvgThem_Click(object sender, EventArgs e)
        {
            nhapluoi = 1;
            ToolBarEnable(true);
            if (gridHangHoa.RowCount == 0)
            {
                gridHangHoa.AllowUserToAddRows = true;
            }
            else
            {
                gridHangHoa.AllowUserToAddRows = true;
                bindingHangHoa.BindingSource.MoveLast();
            }
            gridHangHoa.AllowUserToAddRows = true;
            bindingHangHoa.BindingSource.MoveLast();
        }
        private void NvgXoa_Click(object sender, EventArgs e)
        {
            if (gridHangHoa.RowCount == 0)
                NvgXoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HBLL.XoaHangHoa(gridHangHoa.CurrentRow.Cells["ColMaHang"].Value.ToString());
                LoadDanhSachHang();
            }
        }
        private void NvgLuu_Click(object sender, EventArgs e)
        {
            ToolBarEnable(true);
            switch (nhapluoi)
            {
                case 1://Them
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingNavigatorPositionItem.Focus();
                            if (gridHangHoa.CurrentRow.Cells["ColMaHang"].Value == null || gridHangHoa.CurrentRow.Cells["ColMaLoaiHang"].Value == null || gridHangHoa.CurrentRow.Cells["ColMaNCC"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
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
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridHangHoa.CurrentRow.Cells["ColNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridHangHoa.CurrentRow.Cells["ColNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridHangHoa.CurrentRow.Cells["ColNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridHangHoa.CurrentRow.Cells["ColNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridHangHoa.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridHangHoa.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridHangHoa.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridHangHoa.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            HBLL.ThemHangHoa(mahang, maloaihang, mancc, tenhang, dvtinh, motahang, vat, tax, dongia, giamgia, filename, ngaylap, nguoilap, ngaysua, nguoisua);
                            ToolBarEnable(true);
                            LoadDanhSachHang();
                            nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnable(true);
                            nhapluoi = 0;
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
                            hang.Hinh = filename;
                            hang.NgayLap = System.Convert.ToDateTime(gridHangHoa.CurrentRow.Cells["ColNgayLap"].Value.ToString());
                            hang.NguoiLap = (gridHangHoa.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridHangHoa.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            hang.NgaySua = System.Convert.ToDateTime(gridHangHoa.CurrentRow.Cells["ColNgaySua"].Value.ToString());
                            hang.NguoiSua = (gridHangHoa.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridHangHoa.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            HBLL.SuaHang(mahang, hang);
                            LoadDanhSachHang();
                            ToolBarEnable(true);
                        }
                        else
                        {
                            ToolBarEnable(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void NvgHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nhapluoi = 0;
                LoadDanhSachHang();
                ToolBarEnable(true);
            }
            else
            {

                nhapluoi = 0;
                return;
            }
        }
        private void NvgThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void gridHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (nhapluoi == 1)
                    gridHangHoa.CurrentRow.Cells["ColMaHang"].ReadOnly = false;
                else
                    gridHangHoa.CurrentRow.Cells["ColMaHang"].ReadOnly = true;
            }
        }
        private void gridHangHoa_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnable();
        }
        //thao tác bằng tay
        private int nhaptay = 0;

        private void SetConTrolHangToNull()
        {
            txtMaHang.Text="";
            cmbMaLoaiHang.Text = "";
            cmbNCC.Text = "";
            txtTenHang.Text = "";
            cmbDonViTinh.Text = "";
            txtMoTaHang.Text="";
            doubleInputVAT.Value = 0;
            doubleInputThueNhapKhau.Value = 0;
            doubleInputDonGia.Value = 0;
            doubleInputGiamGia.Value = 0;
            filename = null;
            picHang.Image = null;
            cmbNguoiLap.Text = "";
            dpNgayLap.Value = DateTime.Now;
            cmbNguoiSua.Text = "";
            dpNgaySua.Value = DateTime.Now;
        }
        private void SetControlEnable(bool status)
        {
            btn_Sua.Enabled = status;
            btn_Them.Enabled = status;
            btn_Luu.Enabled = !status;
            btn_Huy.Enabled = !status;
            txtMaHang.Enabled = !status;
            cmbMaLoaiHang.Enabled = !status;
            cmbNCC.Enabled = !status;
            txtTenHang.Enabled = !status;
            cmbDonViTinh.Enabled = !status;
            txtMoTaHang.Enabled = !status;
            doubleInputVAT.Enabled = !status;
            doubleInputThueNhapKhau.Enabled = !status;
            doubleInputDonGia.Enabled = !status;
            doubleInputGiamGia.Enabled = !status;
            picHang.Enabled = !status;
            btnBoHinh.Enabled = !status;
            cmbNguoiLap.Enabled = !status;
            dpNgayLap.Enabled = !status;
            cmbNguoiSua.Enabled = !status;
            dpNgaySua.Enabled = !status;
        }
        private void HienThiDuLieuLenControl(int dong)
        {
            try
            {
                if (gridHangHoa.RowCount > 0 && nhapluoi != 1)
                {
                    txtMaHang.Text = gridHangHoa.Rows[dong].Cells["ColMaHang"].Value.ToString();
                    cmbMaLoaiHang.SelectedValue = gridHangHoa.Rows[dong].Cells["ColMaLoaiHang"].Value.ToString();
                    cmbNCC.SelectedValue = gridHangHoa.Rows[dong].Cells["ColMaNCC"].Value.ToString();
                    txtTenHang.Text = gridHangHoa.Rows[dong].Cells["ColTenHang"].Value.ToString();
                    txtMoTaHang.Text = gridHangHoa.Rows[dong].Cells["ColMoTaHang"].Value.ToString();
                    cmbDonViTinh.SelectedValue = gridHangHoa.Rows[dong].Cells["ColDonViTinh"].Value.ToString();
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
                    dpNgayLap.Value = System.Convert.ToDateTime(gridHangHoa.Rows[dong].Cells["ColNgayLap"].Value.ToString());
                    cmbNguoiLap.Text = gridHangHoa.Rows[dong].Cells["ColNguoiLap"].Value == null ? "" : gridHangHoa.Rows[dong].Cells["ColNguoiLap"].Value.ToString();
                    dpNgaySua.Value = System.Convert.ToDateTime(gridHangHoa.Rows[dong].Cells["ColNgaySua"].Value.ToString());
                    cmbNguoiSua.Text = gridHangHoa.Rows[dong].Cells["ColNguoiSua"].Value == null ? "" : gridHangHoa.Rows[dong].Cells["ColNguoiSua"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void gridHangHoa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            HienThiDuLieuLenControl(e.RowIndex);
            SetControlEnable(true);
        }
        private void SetTxtKetQuaTimNull()
        {
            txtRecords.Text = "";
            txtrecord.Text = "";
            txtThay.Text = "";
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
        private void cmbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMaLoaiHang.DataSource = HBLL.LayDanhSachLoaiHangHoa(cmbNCC.Text);
            cmbMaLoaiHang.DisplayMember = "TenLoaiHang";
            cmbMaLoaiHang.ValueMember = "MaLoaiHang";
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
        private void btn_Them_Click(object sender, EventArgs e)
        {
            nhaptay = 1;
            SetConTrolHangToNull();
            SetControlEnable(false);
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable(false);
            txtMaHang.Enabled = false;
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            switch (nhaptay)
            {
                case 0:
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
                                hang.NgayLap = dpNgayLap.Value;
                                hang.NguoiLap = cmbNguoiLap.Text == "" ? "" : cmbNguoiLap.SelectedValue.ToString();
                                hang.NgaySua = dpNgaySua.Value;
                                hang.NguoiSua = cmbNguoiSua.Text == "" ? "" : cmbNguoiSua.SelectedValue.ToString();
                                HBLL.SuaHang(txtMaHang.Text, hang);
                                LoadDanhSachHang();
                                SetControlEnable(true);
                            }
                            else
                            {
                                SetControlEnable(true);
                                return;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (KiemTraControl() == true)
                            {
                                string maloaihang = cmbMaLoaiHang.SelectedValue.ToString();
                                string mancc = cmbNCC.SelectedValue.ToString();
                                string dvtinh = cmbDonViTinh.SelectedValue.ToString();
                                DateTime ngaylap;
                                DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                                if (dpNgayLap.Value != temp)
                                {
                                    ngaylap = System.Convert.ToDateTime(dpNgayLap.Value);
                                }
                                else
                                {
                                    ngaylap = DateTime.Now.Date;
                                }
                                DateTime ngaysua;
                                if (dpNgaySua.Value != temp)
                                {
                                    ngaysua = System.Convert.ToDateTime(dpNgaySua.Value);
                                }
                                else
                                {
                                    ngaysua = DateTime.Now.Date;
                                }
                                string nguoilap = cmbNguoiLap.Text == "" ? "" : cmbNguoiLap.SelectedValue.ToString();
                                string nguoisua = cmbNguoiSua.Text == "" ? "" : cmbNguoiSua.SelectedValue.ToString();
                                HBLL.ThemHangHoa(txtMaHang.Text, maloaihang, mancc, txtTenHang.Text, dvtinh,
                                                 txtMoTaHang.Text, float.Parse(doubleInputVAT.Value.ToString()),
                                                 float.Parse(doubleInputThueNhapKhau.Value.ToString()),
                                                 System.Convert.ToDecimal(doubleInputDonGia.Value), float.Parse(doubleInputGiamGia.Value.ToString()),
                                                 filename, ngaylap, nguoilap, ngaysua, nguoisua);
                                LoadDanhSachHang();
                                SetControlEnable(true);
                                nhaptay = 0;
                            }
                            else
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            SetControlEnable(true);
                            nhaptay = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachHang();
                SetControlEnable(true);
                nhaptay = 0;
            }
            else
            {
                nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Loại hàng hóa)
        LoaiHangBLL LHHBLL = new LoaiHangBLL();

        private void tabItemLoaiHH_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupPanelLoaiHH, groupPanelHH);
            LoadDanhSachLoaiHang();
        }
        private void tabItemHH_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupPanelHH, groupPanelLoaiHH);
            LoadDanhSachHang();
        }
        private void LoadDanhSachLoaiHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LHHBLL.LoadDanhSachLoaiHangHoa(); 
            gridLoaiHH.DataSource = bds;
            bindingLoaiHangHoa.BindingSource = bds;
            gridLoaiHH.AllowUserToAddRows = false;
        }
        //Thao tác trên lưới
        private int nhapluoi_loaihh = 0;
        private void ToolBarEnable_LoaiHangHoa(bool DangThaoTac = false)
        {
            toolStripThem.Enabled = DangThaoTac;
            toolStripXoa.Enabled = DangThaoTac;
            toolStripRefresh.Enabled = DangThaoTac;
            toolStripLuu.Enabled = !DangThaoTac;
            toolStripHuy.Enabled = !DangThaoTac;
        }
        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            tabItemLoaiHH_Click(sender, e);
            ToolBarEnable_LoaiHangHoa(true);
            nhapluoi_loaihh = 0;
        }
        private void toolStripThem_Click(object sender, EventArgs e)
        {
            nhapluoi_loaihh = 1;
            ToolBarEnable_LoaiHangHoa(false);
            if (gridLoaiHH.RowCount == 0)
            {
                gridLoaiHH.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiHH.AllowUserToAddRows = true;
                bindingLoaiHangHoa.BindingSource.MoveLast();
            }
        }
        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            ToolBarEnable_LoaiHangHoa(true);
            switch (nhapluoi_loaihh)
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
                            ToolBarEnable_LoaiHangHoa(true);
                        }
                        else
                        {
                            ToolBarEnable_LoaiHangHoa(true);
                            return;
                        }
                        break;
                    }
                case 1://thêm loại hàng
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingposition.Focus();
                            if (gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].Value == null || gridLoaiHH.CurrentRow.Cells["ColumnTenLH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
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
                            ToolBarEnable_LoaiHangHoa(true);
                            nhapluoi_loaihh = 0;
                        }
                        else
                        {
                            ToolBarEnable_LoaiHangHoa(true);
                            nhapluoi_loaihh = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void toolStripHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nhapluoi_loaihh = 0;
                LoadDanhSachLoaiHang();
                ToolBarEnable_LoaiHangHoa(true);
            }
            else
            {

                nhapluoi_loaihh = 0;
                return;
            }
        }
        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            if (gridLoaiHH.RowCount == 0)
                toolStripXoa.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LHHBLL.XoaLoaiHang(gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].Value.ToString());
                LoadDanhSachLoaiHang();
            }
        }
        private void gridLoaiHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (nhapluoi_loaihh == 1)
                    gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].ReadOnly = false;
                else
                    gridLoaiHH.CurrentRow.Cells["ColumnMaLH"].ReadOnly = true;
            }
        }
        private void gridLoaiHH_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnable_LoaiHangHoa();
        }
        //Code phần nhập tay
        private int nhaptay_loaihh = 0;

        private void SetConTrolToNull_LoaiHangHoa()
        {
            LH_txtMLH.Text = "";
            LH_txtTenLoaiHang.Text = "";
            LH_txtMoTaLH.Text = "";
            LH_dpNgayLap.Value = DateTime.Now;
            LH_cmbNguoiLap.Text = "";
            LH_dpNgaySua.Value = DateTime.Now;
            LH_cmbNguoiSua.Text = "";
        }

        private void SetControlEnable_LoaiHangHoa(bool status)
        {
            Sua.Enabled = status;
            Them.Enabled = status;
            Luu.Enabled = !status;
            Huy.Enabled = !status;
            LH_txtMLH.Enabled = !status;
            LH_txtTenLoaiHang.Enabled = !status;
            LH_txtMoTaLH.Enabled = !status;
            LH_dpNgayLap.Enabled = !status;
            LH_cmbNguoiLap.Enabled = !status;
            LH_dpNgaySua.Enabled = !status;
            LH_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiHangHoa(int dong)
        {
            if (gridLoaiHH.RowCount > 0 && nhapluoi_loaihh != 1)
            {
                LH_txtMLH.Text = gridLoaiHH.Rows[dong].Cells["ColumnMaLH"].Value.ToString();
                LH_txtTenLoaiHang.Text = gridLoaiHH.Rows[dong].Cells["ColumnTenLH"].Value.ToString();
                LH_txtMoTaLH.Text = gridLoaiHH.Rows[dong].Cells["ColumnMoTaLH"].Value.ToString();
                LH_dpNgayLap.Value = System.Convert.ToDateTime(gridLoaiHH.Rows[dong].Cells["ColumnNgayLap"].Value.ToString());
                LH_cmbNguoiLap.Text = gridLoaiHH.Rows[dong].Cells["ColumnNguoiLap"].Value == null ? "" : gridLoaiHH.Rows[dong].Cells["ColumnNguoiLap"].Value.ToString();
                LH_dpNgaySua.Value = System.Convert.ToDateTime(gridLoaiHH.Rows[dong].Cells["ColumnNgaySua"].Value.ToString());
                LH_cmbNguoiSua.Text = gridLoaiHH.Rows[dong].Cells["ColumnNguoiSua"].Value == null ? "" : gridLoaiHH.Rows[dong].Cells["ColumnNguoiSua"].Value.ToString();
            }
        }
        private void gridLoaiHH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiHangHoa(e.RowIndex);
            SetControlEnable_LoaiHangHoa(true);
            LayThongTinDangNhap();
        }
        private void Them_Click(object sender, EventArgs e)
        {
            nhaptay_loaihh = 1;
            SetConTrolToNull_LoaiHangHoa();
            SetControlEnable_LoaiHangHoa(false);
        }
        private void Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoaiHangHoa(false);
            LH_txtMLH.Enabled = false;
        }
        private void Luu_Click(object sender, EventArgs e)
        {
            switch (nhaptay_loaihh)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiHang LH = new LoaiHang();
                            string maloaihh = LH_txtMLH.Text;
                            LH.TenLoaiHang = LH_txtTenLoaiHang.Text;
                            LH.MoTaLoaiHang = LH_txtMoTaLH.Text;
                            LH.NgayLap = LH_dpNgayLap.Value;
                            LH.NguoiLap = LH_cmbNguoiLap.Text == "" ? "" : LH_cmbNguoiLap.SelectedValue.ToString();
                            LH.NgaySua = LH_dpNgaySua.Value;
                            LH.NguoiSua = LH_cmbNguoiSua.Text == "" ? "" : LH_cmbNguoiSua.SelectedValue.ToString();
                            LHHBLL.SuaLoaiHang(maloaihh, LH);
                            LoadDanhSachLoaiHang();
                            SetControlEnable_LoaiHangHoa(true);
                            LayThongTinDangNhap();
                        }
                        else
                        {
                            SetControlEnable_LoaiHangHoa(true);
                            LayThongTinDangNhap();
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (LH_txtMLH.Text == "" || LH_txtTenLoaiHang.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaihang = LH_txtMLH.Text;
                            string tenloaihang = LH_txtTenLoaiHang.Text;
                            string mota = LH_txtMoTaLH.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LH_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LH_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LH_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LH_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LH_cmbNguoiLap.Text == "" ? "" : LH_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = LH_cmbNguoiSua.Text == "" ? "" : LH_cmbNguoiSua.SelectedValue.ToString();
                            LHHBLL.ThemLoaiHang(maloaihang, tenloaihang, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LoadDanhSachLoaiHang();
                            nhaptay_loaihh = 0;
                            SetControlEnable_LoaiHangHoa(true);
                            LayThongTinDangNhap();
                        }
                        else
                        {
                            nhaptay_loaihh = 0;
                            SetControlEnable_LoaiHangHoa(true);
                            LayThongTinDangNhap();
                            return;
                        }
                        break;
                    }
            }
        }
        private void Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachLoaiHang();
                SetControlEnable_LoaiHangHoa(true);
                nhaptay_loaihh = 0;
            }
            else
            {
                nhaptay_loaihh = 0;
                return;
            }
        }
        //Tìm Kiếm
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
#endregion
#region (Đăng nhập)
        private void QuyenThemNguoiDung(bool them)
        {
            toolStripThem.Enabled=them;
            NvgThem.Enabled = them;
            Them.Enabled = them;
            btn_Them.Enabled = them;
        }
        private void LayThongTinDangNhap()
        {
            bool them = HBLL.QuyenThem();
            bool sua = HBLL.QuyenSua();
            bool xoa = HBLL.QuyenXoa();
            QuyenThemNguoiDung(them);
        }

#endregion
    }
}