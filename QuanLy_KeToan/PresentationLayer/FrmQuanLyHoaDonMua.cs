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

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmQuanLyHoaDonMua : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyHoaDonMua()
        {
            InitializeComponent();
        }
#region (Biến)
        private int xoa = 0;
#endregion
#region (Xử lý TreeView)
        private void LoadTreeView()
        {
            foreach (var item in LoHDMuaBLL.LayDanhSachMaLoHoaDonMua())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                foreach (DevComponents.AdvTree.Node n in advTreeHDMua.Nodes[0].Nodes)
                {
                    if (n.Name == "nodeLoHDMua")
                        n.Nodes.Add(childnode);
                }
            }
        }
        private string xuly_chuoi(string chuoi)
        {
            int vt = chuoi.IndexOf("=");
            int vt1 = chuoi.IndexOf(",");
            string s1 = chuoi.Substring(vt + 1, vt1 - vt - 1).Trim();
            return s1;
        }
        // Xử lý khi tác động vào các Node 
        private void advTreeHDMua_AfterNodeSelect_1(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
            if (e.Node.Level == 0)
                return;
            //Node Loại Hóa Đơn Mua
            if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoaiHDMua.BringToFront();
                AnHienGroup(groupLoaiHDMua, groupLoHDMua, groupHDMua);
                LayDanhSachLoaiHoaDonMua();
                xoa = 1;
            }
            //Node Lô Hóa Đơn Mua
            else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoHDMua.BringToFront();
                AnHienGroup(groupLoHDMua, groupLoaiHDMua, groupHDMua);
                LayDanhSachLoHoaDonMua();
                xoa = 2;
            }
            //Node Hóa Đơn Mua
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelHDMua.BringToFront();
                AnHienGroup(groupHDMua, groupLoHDMua, groupLoaiHDMua);
                string malohdmua = xuly_chuoi(e.Node.Text);
                LayDSHoaDonMuaTheoLo(malohdmua);
                bindingHDMua.Enabled = true;
                xoa = 3;
            }
        }
# endregion
#region (Hàm Dùng Chung)
        //Hàm ẩn hiện các groupbox.
        private void AnHienGroup(DevComponents.DotNetBar.Controls.GroupPanel grb1, DevComponents.DotNetBar.Controls.GroupPanel grb2, DevComponents.DotNetBar.Controls.GroupPanel grb3)
        {
            grb2.Dock = DockStyle.None;
            grb2.SendToBack();
            grb3.Dock = DockStyle.None;
            grb3.SendToBack();
            grb1.Dock = DockStyle.Fill;
            grb1.BringToFront();
        }
        //Hàm Load các combobox
        private void LoadCmbNguoiLap()
        {
            //Loại Hóa Đơn Mua
            LoaiHDMua_cmbNguoiLap.DataSource = LoaiHDMuaBLL.LayDanhSachNguoiLap();
            LoaiHDMua_cmbNguoiLap.ValueMember = "TenDangNhap";
            LoaiHDMua_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LoaiHDMua_cmbNguoiSua.DataSource = LoaiHDMuaBLL.LayDanhSachNguoiSua();
            LoaiHDMua_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LoaiHDMua_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô Hóa Đơn Mua
            LoHDMua_cmbNguoiLap.DataSource = LoHDMuaBLL.LayDanhSachNguoiLap();
            LoHDMua_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LoHDMua_cmbNguoiLap.ValueMember = "TenDangNhap";
            LoHDMua_cmbNguoiSua.DataSource = LoHDMuaBLL.LayDanhSachNguoiSua();
            LoHDMua_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LoHDMua_cmbNguoiSua.ValueMember = "TenDangNhap";
            ////Hóa Đơn Mua
            HDM_cmbNguoiLap.DataSource = HDMuaBLL.LayDanhSachNguoiLap();
            HDM_cmbNguoiLap.DisplayMember = "TenDangNhap";
            HDM_cmbNguoiLap.ValueMember = "TenDangNhap";
            HDM_cmbNguoiSua.DataSource = HDMuaBLL.LayDanhSachNguoiSua();
            HDM_cmbNguoiSua.DisplayMember = "TenDangNhap";
            HDM_cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        //Hàm load các ComboboxColumn
        private void LoadComboboxColumnNguoiLap()
        {
            //Loại Hóa Đơn Mua
            ColumnNguoiLap.DataSource = LoaiHDMuaBLL.LayDanhSachNguoiLap();
            ColumnNguoiLap.ValueMember = "TenDangNhap";
            ColumnNguoiLap.DisplayMember = "TenDangNhap";
            ColumnNguoiSua.DataSource = LoaiHDMuaBLL.LayDanhSachNguoiSua();
            ColumnNguoiSua.ValueMember = "TenDangNhap";
            ColumnNguoiSua.DisplayMember = "TenDangNhap";
            //Lô Hóa Đơn Mua
            ColumNguoiLap.DataSource = LoHDMuaBLL.LayDanhSachNguoiLap();
            ColumNguoiLap.ValueMember = "TenDangNhap";
            ColumNguoiLap.DisplayMember = "TenDangNhap";
            ColumNguoiSua.DataSource = LoHDMuaBLL.LayDanhSachNguoiSua();
            ColumNguoiSua.ValueMember = "TenDangNhap";
            ColumNguoiSua.DisplayMember = "TenDangNhap";
            //Hóa Đơn Mua
            ColNguoiLap.DataSource = HDMuaBLL.LayDanhSachNguoiLap();
            ColNguoiLap.ValueMember = "TenDangNhap";
            ColNguoiLap.DisplayMember = "TenDangNhap";
            ColNguoiSua.DataSource = HDMuaBLL.LayDanhSachNguoiSua();
            ColNguoiSua.ValueMember = "TenDangNhap";
            ColNguoiSua.DisplayMember = "TenDangNhap";
        }
        
        //---------------------------------Form Load---------------------------------//
        int truycap = 0;
        private void FrmQuanLyHoaDonMua_Load_1(object sender, EventArgs e)
        {
            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            //Loại Hóa Đơn Mua
            ToolBarEnableLoaiHoaDonMua(true);
            SetControlEnable_LoaiHDMua(true);
            LayDanhSachLoaiHoaDonMua();
            //Lô Hóa Đơn Mua
            ToolBarEnableLoHoaDonMua(true);
            SetControlEnable_LoHDMua(true);
            LoadCmbMaLoaiHang();
            LoadComboboxColumnMaLoaiHang();
            LayDanhSachLoHoaDonMua();
            //Hóa Đơn Mua
            ToolBarEnableHoaDonMua(true);
            SetControlEnable_HDMua(true);
            LoadMaLoaiHDMua();
            LoadMaLoHDMua();
            LoadMaNhaCungCap();
            LoadMaTienTe();
            if (gridHDMua.RowCount == 0)
            {
                bindingHDMua.Enabled = false;
            }
        }
        private void FrmQuanLyHoaDonMua_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (loaihdmua_nhapluoi == 1 || loaihdmua_nhaptay == 1 || lohdmua_nhapluoi == 1 || lohdmua_nhaptay == 1 || hdmua_nhapluoi == 1 || hdmua_nhaptay == 1)
            {
                MessageBox.Show("Đang thao tác-Không thể thoát được", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show("Thoát khỏi chương trình không?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        //Xóa dữ liệu trên Datagridview bằng phím delete
        private void XoaGridByButton(int xoa)
        {
            switch (xoa)
            {
                case 1:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiHDMuaBLL.XoaLoaiHDMua(gridLoaiHDMua.CurrentRow.Cells["ColumnMaLoaiHDMua"].Value.ToString());
                            LayDanhSachLoaiHoaDonMua();
                        }
                        break;
                    }
                case 2:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoHDMuaBLL.XoaLoHDMua(gridLoHDMua.CurrentRow.Cells["ColumMaLoHDMua"].Value.ToString());
                            LayDanhSachLoHoaDonMua();
                        }
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            HDMuaBLL.XoaHDMua(gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].Value.ToString(), gridHDMua.CurrentRow.Cells["ColMaHDMua"].Value.ToString());
                            LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                        }
                        break;
                    }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                OnKeyPress(new KeyPressEventArgs((Char)Keys.Escape));
            if (keyData == Keys.Delete)
                OnKeyPress(new KeyPressEventArgs((Char)Keys.Delete));
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmQuanLyHoaDonMua_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (MessageBox.Show("Thoát khỏi chương trình không?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }
            if (e.KeyChar == (char)Keys.Delete)
            {
                XoaGridByButton(xoa);
            }
        }
#endregion
#region (Phần Loại Hóa Đơn Mua)

        LoaiHoaDonMuaBLL LoaiHDMuaBLL=new LoaiHoaDonMuaBLL();
        private void LayDanhSachLoaiHoaDonMua()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoaiHDMuaBLL.LayDanhSachLoaiHoaDonMua();
            gridLoaiHDMua.DataSource = bds;
            bindingLoaiHDMua.BindingSource = bds;
            gridLoaiHDMua.AllowUserToAddRows = false;
        }
        //Xử lý phần nhập lưới
        private int loaihdmua_nhapluoi= 0;

        private void ToolBarEnableLoaiHoaDonMua(bool DangThaoTac = false)
        {
            LoaiHDMua_Add.Enabled = DangThaoTac;
            LoaiHDMua_Delete.Enabled = DangThaoTac;
            LoaiHDMua_Cancel.Enabled = !DangThaoTac;
            LoaiHDMua_Refresh.Enabled = DangThaoTac;
            LoaiHDMua_Save.Enabled = !DangThaoTac;
        }
        private void LoaiHDMua_Refresh_Click_1(object sender, EventArgs e)
        {
            FrmQuanLyHoaDonMua_Load_1(sender, e);
            ToolBarEnableLoaiHoaDonMua(true);
            loaihdmua_nhapluoi = 0;
        }

        private void LoaiHDMua_Add_Click_1(object sender, EventArgs e)
        {
            loaihdmua_nhapluoi = 1;
            ToolBarEnableLoaiHoaDonMua(false);
            if (gridLoaiHDMua.RowCount == 0)
            {
                gridLoaiHDMua.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiHDMua.AllowUserToAddRows = true;
                bindingLoaiHDMua.BindingSource.MoveLast();
            }
        }
        private void LoaiHDMua_Delete_Click_1(object sender, EventArgs e)
        {
            if (gridLoaiHDMua.RowCount == 0)
                LoaiHDMua_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoaiHDMuaBLL.XoaLoaiHDMua(gridLoaiHDMua.CurrentRow.Cells["ColumnMaLoaiHDMua"].Value.ToString());
                LayDanhSachLoaiHoaDonMua();
            }
        }
        private void LoaiHDMua_Save_Click_1(object sender, EventArgs e)
        {
            switch (loaihdmua_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiHDMua.Focus();
                            LoaiHDMua LoaiHDMua = new LoaiHDMua();
                            string maloaihoadonmua = gridLoaiHDMua.CurrentRow.Cells["ColumnMaLoaiHDMua"].Value.ToString();
                            LoaiHDMua.TenLoaiHDMua = gridLoaiHDMua.CurrentRow.Cells["ColumnTenLoaiHDMua"].Value != null ? gridLoaiHDMua.CurrentRow.Cells["ColumnTenLoaiHDMua"].Value.ToString() : "";
                            LoaiHDMua.NgayLap = System.Convert.ToDateTime(gridLoaiHDMua.CurrentRow.Cells["ColumnNgayLap"].Value.ToString());
                            LoaiHDMua.NguoiLap = (gridLoaiHDMua.CurrentRow.Cells["ColumnNguoiLap"].Value != null ? gridLoaiHDMua.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            LoaiHDMua.NgaySua = System.Convert.ToDateTime(gridLoaiHDMua.CurrentRow.Cells["ColumnNgaySua"].Value.ToString());
                            LoaiHDMua.NguoiSua = (gridLoaiHDMua.CurrentRow.Cells["ColumnNguoiSua"].Value != null ? gridLoaiHDMua.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            LoaiHDMuaBLL.SuaLoaiHDMua(maloaihoadonmua, LoaiHDMua);
                            LayDanhSachLoaiHoaDonMua();
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
                            positionLoaiHDMua.Focus();
                            if (gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount-2].Cells["ColumnMaLoaiHDMua"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                string maloaihoadonmua = gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount-2].Cells["ColumnMaLoaiHDMua"].Value.ToString();
                                string tenloaihoadonmua = gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnTenLoaiHDMua"].Value.ToString();
                                DateTime ngaylap;
                                DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                                if (System.Convert.ToDateTime(gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNgayLap"].Value) != temp)
                                {
                                    ngaylap = System.Convert.ToDateTime(gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNgayLap"].Value);
                                }
                                else
                                {
                                    ngaylap = DateTime.Now.Date;
                                }
                                DateTime ngaysua;
                                if (System.Convert.ToDateTime(gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNgaySua"].Value) != temp)
                                {
                                    ngaysua = System.Convert.ToDateTime(gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNgaySua"].Value);
                                }
                                else
                                {
                                    ngaysua = DateTime.Now.Date;
                                }
                                string nguoilap = (gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNguoiLap"].Value != null ? gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNguoiLap"].Value.ToString() : "");
                                string nguoisua = (gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNguoiSua"].Value != null ? gridLoaiHDMua.Rows[gridLoaiHDMua.RowCount - 2].Cells["ColumnNguoiSua"].Value.ToString() : "");
                                LoaiHDMuaBLL.ThemLoaiHDMua(maloaihoadonmua, tenloaihoadonmua, ngaylap, nguoilap, ngaysua, nguoisua);
                                LayDanhSachLoaiHoaDonMua();
                                loaihdmua_nhapluoi = 0;
                            }
                        }
                        else
                        {
                            loaihdmua_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoaiHDMua_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loaihdmua_nhapluoi = 0;
                LayDanhSachLoaiHoaDonMua();
                ToolBarEnableLoaiHoaDonMua(true);
            }
            else
            {
                loaihdmua_nhapluoi = 0;
                return;
            }
        }
        private void LoaiHDMua_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridLoaiHDMua_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoaiHoaDonMua();
        }
        private void gridLoaiHDMua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (loaihdmua_nhapluoi == 1)
                    gridLoaiHDMua.CurrentRow.Cells["ColumnMaLoaiHDMua"].ReadOnly = false;
                else
                    gridLoaiHDMua.CurrentRow.Cells["ColumnMaLoaiHDMua"].ReadOnly = true;
            }
        }


        //Code phần nhập tay
        private int loaihdmua_nhaptay = 0;

        private void SetConTrolToNull_LoaiHDMua()
        {
            txtMaLoaiHDMua.Clear();
            txtTenLoaiHDMua.Clear();
            LoaiHDMua_dpNgayLap.Value = DateTime.Now;
            LoaiHDMua_cmbNguoiLap.Text = "";
            LoaiHDMua_dpNgaySua.Value = DateTime.Now;
            LoaiHDMua_cmbNguoiSua.Text = "";
        }

        private void SetControlEnable_LoaiHDMua(bool status)
        {
            btn_LoaiHDMua_Sua.Enabled = status;
            btn_LoaiHDMua_Them.Enabled = status;
            btn_LoaiHDMua_Luu.Enabled = !status;
            btn_LoaiHDMua_Huy.Enabled = !status;
            txtMaLoaiHDMua.ReadOnly = status;
            txtTenLoaiHDMua.ReadOnly = status;
            LoaiHDMua_dpNgayLap.Enabled = !status;
            LoaiHDMua_cmbNguoiLap.Enabled = !status;
            LoaiHDMua_dpNgaySua.Enabled = !status;
            LoaiHDMua_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiHDMua(int dong)
        {
            if (gridLoaiHDMua.RowCount > 0 && loaihdmua_nhapluoi != 1)
            {
                txtMaLoaiHDMua.Text = gridLoaiHDMua.Rows[dong].Cells["ColumnMaLoaiHDMua"].Value.ToString();
                txtTenLoaiHDMua.Text = gridLoaiHDMua.Rows[dong].Cells["ColumnTenLoaiHDMua"].Value.ToString();
                LoaiHDMua_dpNgayLap.Value = gridLoaiHDMua.Rows[dong].Cells["ColumnNgayLap"].Value == null ? DateTime.Now:System.Convert.ToDateTime(gridLoaiHDMua.Rows[dong].Cells["ColumnNgayLap"].Value);
                LoaiHDMua_cmbNguoiLap.Text = (gridLoaiHDMua.Rows[dong].Cells["ColumnNguoiLap"].Value == null ? "" : gridLoaiHDMua.Rows[dong].Cells["ColumnNguoiLap"].Value.ToString());
                LoaiHDMua_dpNgaySua.Value = gridLoaiHDMua.Rows[dong].Cells["ColumnNgaySua"].Value == null ? DateTime.Now : System.Convert.ToDateTime(gridLoaiHDMua.Rows[dong].Cells["ColumnNgaySua"].Value);
                LoaiHDMua_cmbNguoiSua.Text = (gridLoaiHDMua.Rows[dong].Cells["ColumnNguoiSua"].Value == null ? "" : gridLoaiHDMua.Rows[dong].Cells["ColumnNguoiSua"].Value.ToString());
            }
        }
        private void gridLoaiHDMua_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiHDMua(e.RowIndex);
            SetControlEnable_LoaiHDMua(true);
        }
        private void btn_LoaiHDMua_Them_Click_1(object sender, EventArgs e)
        {
            loaihdmua_nhaptay = 1;
            SetConTrolToNull_LoaiHDMua();
            SetControlEnable_LoaiHDMua(false);
        }


        private void btn_LoaiHDMua_Sua_Click_1(object sender, EventArgs e)
        {
            SetControlEnable_LoaiHDMua(false);
            txtMaLoaiHDMua.ReadOnly = true;
        }
        private void btn_LoaiHDMua_Luu_Click_1(object sender, EventArgs e)
        {
            switch (loaihdmua_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiHDMua LoaiHDMua = new LoaiHDMua();
                            string maloaihoadonmua = txtMaLoaiHDMua.Text;
                            LoaiHDMua.TenLoaiHDMua = txtTenLoaiHDMua.Text;
                            LoaiHDMua.NgayLap = LoaiHDMua_dpNgayLap.Value;
                            LoaiHDMua.NguoiLap = LoaiHDMua_cmbNguoiLap.Text == "" ? "" : LoaiHDMua_cmbNguoiLap.SelectedValue.ToString();
                            LoaiHDMua.NgaySua = LoaiHDMua_dpNgaySua.Value;
                            LoaiHDMua.NguoiSua = LoaiHDMua_cmbNguoiSua.Text == "" ? "" : LoaiHDMua_cmbNguoiSua.SelectedValue.ToString();
                            LoaiHDMuaBLL.SuaLoaiHDMua(maloaihoadonmua, LoaiHDMua);
                            LayDanhSachLoaiHoaDonMua();
                            SetControlEnable_LoaiHDMua(true);
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
                            if (txtMaLoaiHDMua.Text == "" || txtTenLoaiHDMua.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaihoadonmua = txtMaLoaiHDMua.Text;
                            string tenloaihoadonmua = txtTenLoaiHDMua.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LoaiHDMua_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LoaiHDMua_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LoaiHDMua_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LoaiHDMua_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LoaiHDMua_cmbNguoiLap.Text == "" ? "" : LoaiHDMua_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = LoaiHDMua_cmbNguoiSua.Text == "" ? "" : LoaiHDMua_cmbNguoiSua.SelectedValue.ToString();
                            LoaiHDMuaBLL.ThemLoaiHDMua(maloaihoadonmua, tenloaihoadonmua, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiHoaDonMua();
                            loaihdmua_nhaptay = 0;
                        }
                        else
                        {
                            loaihdmua_nhaptay = 0;
                            SetControlEnable_LoaiHDMua(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LoaiHDMua_Huy_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiHoaDonMua();
                SetControlEnable_LoaiHDMua(true);
                loaihdmua_nhaptay = 0;
            }
            else
            {
                loaihdmua_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Lô Hóa Đơn Mua)

        LoHoaDonMuaBLL LoHDMuaBLL = new LoHoaDonMuaBLL();
        
        private void LayDanhSachLoHoaDonMua()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoHDMuaBLL.LayDanhSachLoHoaDonMua();
            bindingLoHDMua.BindingSource = bds;
            gridLoHDMua.DataSource = bds;
            gridLoHDMua.AllowUserToAddRows = false;
        }
        //Hàm Load các combobox
        private void LoadCmbMaLoaiHang()
        {            
            LoHDMua_cmbMaLoaiHang.DataSource = LoHDMuaBLL.LayDanhSachMaLoaiHang();
            LoHDMua_cmbMaLoaiHang.ValueMember = "MaLoaiHang";
            LoHDMua_cmbMaLoaiHang.DisplayMember = "TenLoaiHang";
        }
        //Hàm load các ComboboxColumn
        private void LoadComboboxColumnMaLoaiHang()
        {
            ColumMaLoaiHang.DataSource = LoHDMuaBLL.LayDanhSachMaLoaiHang();
            ColumMaLoaiHang.ValueMember = "MaLoaiHang";
            ColumMaLoaiHang.DisplayMember = "TenLoaiHang";
        }
        //Xử lý nhập lưới
        int lohdmua_nhapluoi = 0;

        private void ToolBarEnableLoHoaDonMua(bool DangThaoTac = false)
        {
            LoHDMua_Add.Enabled = DangThaoTac;
            LoHDMua_Delete.Enabled = DangThaoTac;
            LoHDMua_Refresh.Enabled = DangThaoTac;
            LoHDMua_Save.Enabled = !DangThaoTac;
            LoHDMua_Cancel.Enabled = !DangThaoTac;
        }
        private void LoHDMua_Refresh_Click_1(object sender, EventArgs e)
        {
            lohdmua_nhapluoi = 0;
            FrmQuanLyHoaDonMua_Load_1(sender, e);
            ToolBarEnableLoHoaDonMua(true);
            LayDanhSachLoHoaDonMua();
        }
        private void LoHDMua_Add_Click_1(object sender, EventArgs e)
        {
            lohdmua_nhapluoi = 1;
            ToolBarEnableLoHoaDonMua(false);
            if (gridLoHDMua.RowCount == 0)
            {
                gridLoHDMua.AllowUserToAddRows = true;
            }
            else
            {
                gridLoHDMua.AllowUserToAddRows = true;
                bindingLoHDMua.BindingSource.MoveLast();
            }
        }
        private void LoHDMua_Delete_Click_1(object sender, EventArgs e)
        {
            if (gridLoHDMua.RowCount == 0)
                LoHDMua_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoHDMuaBLL.XoaLoHDMua(gridLoHDMua.CurrentRow.Cells["ColumMaLoHDMua"].Value.ToString());
                LayDanhSachLoHoaDonMua();
            }
        }
        private void LoHDMua_Save_Click_1(object sender, EventArgs e)
        {
            switch (lohdmua_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoHDMua.Focus();
                            LoHDMua LoHDMua = new LoHDMua();
                            string malohdmua = gridLoHDMua.CurrentRow.Cells["ColumMaLoHDMua"].Value.ToString();
                            LoHDMua.MaLoaiHang = gridLoHDMua.CurrentRow.Cells["ColumMaLoaiHang"].Value.ToString();
                            LoHDMua.NgayLoHDMua = System.Convert.ToDateTime(gridLoHDMua.CurrentRow.Cells["ColumNgayLoHDMua"].Value.ToString());
                            LoHDMua.MoTa = (gridLoHDMua.CurrentRow.Cells["ColumMoTa"].Value != null ? gridLoHDMua.CurrentRow.Cells["ColumMoTa"].Value.ToString() : "");
                            LoHDMua.NgayLap = System.Convert.ToDateTime(gridLoHDMua.CurrentRow.Cells["ColumNgayLap"].Value.ToString());
                            LoHDMua.NguoiLap = (gridLoHDMua.CurrentRow.Cells["ColumNguoiLap"].Value != null ? gridLoHDMua.CurrentRow.Cells["ColumNguoiLap"].Value.ToString() : "");
                            LoHDMua.NgaySua = System.Convert.ToDateTime(gridLoHDMua.CurrentRow.Cells["ColumNgaySua"].Value.ToString());
                            LoHDMua.NguoiSua = (gridLoHDMua.CurrentRow.Cells["ColumNguoiSua"].Value != null ? gridLoHDMua.CurrentRow.Cells["ColumNguoiSua"].Value.ToString() : "");
                            LoHDMuaBLL.SuaLoHDMua(malohdmua, LoHDMua);
                            LayDanhSachLoHoaDonMua();
                            ToolBarEnableLoHoaDonMua(true);
                        }
                        else
                        {
                            ToolBarEnableLoHoaDonMua(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            positionLoHDMua.Focus();
                            if (gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumMaLoHDMua"].Value == null || gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumMaLoaiHang"].Value == null ||
                                System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgayLoHDMua"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumMaLoHDMua"].Value.ToString();
                            string maloaihang = gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumMaLoaiHang"].Value.ToString();
                            DateTime ngaylohoadonmua;
                            if (System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgayLoHDMua"].Value) != temp)
                            {
                                ngaylohoadonmua = System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgayLoHDMua"].Value);
                            }
                            else
                            {
                                ngaylohoadonmua = DateTime.Now.Date;
                            }
                            string mota = (gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumMoTa"].Value != null ? gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumMoTa"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNguoiLap"].Value != null ? gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNguoiSua"].Value != null ? gridLoHDMua.Rows[gridLoHDMua.RowCount - 2].Cells["ColumNguoiSua"].Value.ToString() : "");
                            LoHDMuaBLL.ThemLoHDMua(malohdmua,maloaihang, ngaylohoadonmua, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoHoaDonMua();
                            lohdmua_nhapluoi = 0;
                        }
                        else
                        {
                            lohdmua_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoHDMua_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lohdmua_nhapluoi = 0;
                LayDanhSachLoHoaDonMua();
                ToolBarEnableLoHoaDonMua(true);
            }
            else
            {
                lohdmua_nhapluoi = 0;
                return;
            }
        }
        private void LoHDMua_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoHDMua_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoHoaDonMua();
        }
        private void gridLoHDMua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lohdmua_nhapluoi == 1)
                    gridLoHDMua.CurrentRow.Cells["ColumMaLoHDMua"].ReadOnly = false;
                else
                    gridLoHDMua.CurrentRow.Cells["ColumMaLoHDMua"].ReadOnly = true;
            }
        }
        //Xử lý phần nhập tay
        private int lohdmua_nhaptay = 0;

        private void SetConTrolToNull_LoHDMua()
        {
            txtMaLoHDMua.Text = "";
            LoHDMua_cmbMaLoaiHang.Text = "";
            dpNgayLoHDMua.Value = DateTime.Now;
            txtMoTa.Clear();
            LoHDMua_dpNgayLap.Value = DateTime.Now;
            LoHDMua_cmbNguoiLap.Text = "";
            LoHDMua_dpNgaySua.Value = DateTime.Now;
            LoHDMua_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_LoHDMua(bool status)
        {
            btn_LoHDMua_Sua.Enabled = status;
            btn_LoHDMua_Them.Enabled = status;
            btn_LoHDMua_Luu.Enabled = !status;
            btn_LoHDMua_Huy.Enabled = !status;
            txtMaLoHDMua.Enabled = !status;
            LoHDMua_cmbMaLoaiHang.Enabled = !status;
            dpNgayLoHDMua.Enabled = !status;
            txtMoTa.ReadOnly = status;
            LoHDMua_dpNgayLap.Enabled = !status;
            LoHDMua_cmbNguoiLap.Enabled = !status;
            LoHDMua_dpNgaySua.Enabled = !status;
            LoHDMua_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoHDMua(int dong)
        {
            if (gridLoHDMua.RowCount > 0 && lohdmua_nhapluoi != 1)
            {
                txtMaLoHDMua.Text = gridLoHDMua.Rows[dong].Cells["ColumMaLoHDMua"].Value.ToString();
                LoHDMua_cmbMaLoaiHang.Text = gridLoHDMua.Rows[dong].Cells["ColumMaLoaiHang"].Value.ToString();
                dpNgayLoHDMua.Value = System.Convert.ToDateTime(gridLoHDMua.Rows[dong].Cells["ColumNgayLoHDMua"].Value.ToString());
                txtMoTa.Text = gridLoHDMua.Rows[dong].Cells["ColumMoTa"].Value.ToString();
                LoHDMua_dpNgayLap.Value = System.Convert.ToDateTime(gridLoHDMua.Rows[dong].Cells["ColumNgayLap"].Value.ToString());
                LoHDMua_cmbNguoiLap.Text = gridLoHDMua.Rows[dong].Cells["ColumNguoiLap"].Value==null?"":gridLoHDMua.Rows[dong].Cells["ColumNguoiLap"].Value.ToString();
                LoHDMua_dpNgaySua.Value = System.Convert.ToDateTime(gridLoHDMua.Rows[dong].Cells["ColumNgaySua"].Value.ToString());
                LoHDMua_cmbNguoiSua.Text = gridLoHDMua.Rows[dong].Cells["ColumNguoiSua"].Value==null?"":gridLoHDMua.Rows[dong].Cells["ColumNguoiSua"].Value.ToString();
            }
        }
        private void gridLoHDMua_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoHDMua(e.RowIndex);
            SetControlEnable_LoHDMua(true);
        }
        private void btn_LoHDMua_Them_Click_1(object sender, EventArgs e)
        {
            lohdmua_nhaptay = 1;
            SetConTrolToNull_LoHDMua();
            SetControlEnable_LoHDMua(false);
        }
        private void btn_LoHDMua_Sua_Click_1(object sender, EventArgs e)
        {
            SetControlEnable_LoHDMua(false);
            txtMaLoHDMua.Enabled = false;
        }
        private void btn_LoHDMua_Luu_Click(object sender, EventArgs e)
        {
            switch (lohdmua_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoHDMua LoHDMua = new LoHDMua();
                            string malohdmua = txtMaLoHDMua.Text;
                            LoHDMua.MaLoaiHang = LoHDMua_cmbMaLoaiHang.Text;
                            LoHDMua.NgayLoHDMua = dpNgayLoHDMua.Value;
                            LoHDMua.MoTa = txtMoTa.Text;
                            LoHDMua.NgayLap = LoHDMua_dpNgayLap.Value;
                            LoHDMua.NguoiLap = LoHDMua_cmbNguoiLap.Text == "" ? "" : LoHDMua_cmbNguoiLap.SelectedValue.ToString();
                            LoHDMua.NgaySua = LoHDMua_dpNgaySua.Value;
                            LoHDMua.NguoiSua = LoHDMua_cmbNguoiSua.Text == "" ? "" : LoHDMua_cmbNguoiSua.SelectedValue.ToString();
                            LoHDMuaBLL.SuaLoHDMua(malohdmua, LoHDMua);
                            LayDanhSachLoHoaDonMua();
                            SetControlEnable_LoHDMua(true);
                        }
                        else
                        {
                            SetControlEnable_LoHDMua(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (txtMaLoHDMua.Text == "" || LoHDMua_cmbMaLoaiHang.Text == "" || dpNgayLoHDMua.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = txtMaLoHDMua.Text;
                            string maloaihang = LoHDMua_cmbMaLoaiHang.SelectedValue.ToString();
                            DateTime ngaylohoadonmua = dpNgayLoHDMua.Value;
                            string mota = txtMoTa.Text;
                            DateTime ngaylap;
                            if (LoHDMua_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LoHDMua_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LoHDMua_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LoHDMua_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LoHDMua_cmbNguoiLap.Text == "" ? "" : LoHDMua_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = LoHDMua_cmbNguoiSua.Text == "" ? "" : LoHDMua_cmbNguoiSua.SelectedValue.ToString();
                            LoHDMuaBLL.ThemLoHDMua(malohdmua,maloaihang, ngaylohoadonmua, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoHoaDonMua();
                            SetControlEnable_LoHDMua(true);
                            lohdmua_nhaptay = 0;
                        }
                        else
                        {
                            lohdmua_nhaptay = 0;
                            SetControlEnable_LoHDMua(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LoHDMua_Huy_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoHoaDonMua();
                SetControlEnable_LoHDMua(true);
                lohdmua_nhaptay = 0;
            }
            else
            {
                lohdmua_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Hóa Đơn Mua)
        HoaDonMuaBLL HDMuaBLL = new HoaDonMuaBLL();  

        private void LoadMaLoaiHDMua()
        {
            //Combobox Column
            ColMaLoaiHDMua.DataSource = HDMuaBLL.LayDanhSachMaLoaiHoaDonMua();
            ColMaLoaiHDMua.DisplayMember = "MaLoaiHDMua";
            ColMaLoaiHDMua.ValueMember = "MaLoaiHDMua";
            //Combobox
            HDM_cmbMaLoaiHDMua.DataSource = HDMuaBLL.LayDanhSachMaLoaiHoaDonMua();
            HDM_cmbMaLoaiHDMua.DisplayMember = "MaLoaiHDMua";
            HDM_cmbMaLoaiHDMua.ValueMember = "MaLoaiHDMua";
        }
        private void LoadMaLoHDMua()
        {
            //Combobox Column
            ColMaLoHDMua.DataSource = HDMuaBLL.LayDanhSachMaLoHoaDonMua();
            ColMaLoHDMua.DisplayMember = "MaLoHDMua";
            ColMaLoHDMua.ValueMember = "MaLoHDMua";
            //Combobox
            HDM_cmbMaLoHDMua.DataSource = HDMuaBLL.LayDanhSachMaLoHoaDonMua();
            HDM_cmbMaLoHDMua.DisplayMember = "MaLoHDMua";
            HDM_cmbMaLoHDMua.ValueMember = "MaLoHDMua";
        }
        private void LoadMaNhaCungCap()
        {
            //Combobox Column
            ColMaNCC.DataSource = HDMuaBLL.LayDanhSachMaNCC();
            ColMaNCC.DisplayMember = "TenNCC";
            ColMaNCC.ValueMember = "MaNCC";
            //Combobox
            HDM_cmbMaNhaCungCap.DataSource = HDMuaBLL.LayDanhSachMaNCC();
            HDM_cmbMaNhaCungCap.DisplayMember = "TenNCC";
            HDM_cmbMaNhaCungCap.ValueMember = "MaNCC";
        }
        private void LoadMaTienTe()
        {
            //Combobox Column
            ColMaTienTe.DataSource = HDMuaBLL.LayDanhSachMaTienTe();
            ColMaTienTe.DisplayMember = "MaTienTe";
            ColMaTienTe.ValueMember = "MaTienTe";
            //Combobox
            HDM_cmbMaTienTe.DataSource = HDMuaBLL.LayDanhSachMaTienTe();
            HDM_cmbMaTienTe.DisplayMember = "MaTienTe";
            HDM_cmbMaTienTe.ValueMember = "MaTienTe";
        }
        private void LayDSHoaDonMuaTheoLo(string malohdmua)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HDMuaBLL.LayDanhSachHoaDonTheoMaLoHoaDonMua(malohdmua);
            bindingHDMua.BindingSource = bds;
            gridHDMua.DataSource = bds;
            gridHDMua.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int hdmua_nhapluoi = 0;
        private void ToolBarEnableHoaDonMua(bool DangThaoTac = false)
        {
            HDM_Add.Enabled = DangThaoTac;
            HDM_Delete.Enabled = DangThaoTac;
            HDM_Refresh.Enabled = DangThaoTac;
            HDM_Save.Enabled = !DangThaoTac;
            HDM_Cancel.Enabled = !DangThaoTac;
        }
        private void HDM_Refresh_Click(object sender, EventArgs e)
        {
            hdmua_nhapluoi = 0;
            FrmQuanLyHoaDonMua_Load_1(sender, e);
            ToolBarEnableHoaDonMua(true);
            LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
        }
        private void HDM_Add_Click(object sender, EventArgs e)
        {
            hdmua_nhapluoi = 1;
            ToolBarEnableHoaDonMua(false);
            if (gridHDMua.RowCount == 0)
            {
                gridHDMua.AllowUserToAddRows = true;
            }
            else
            {
                gridHDMua.AllowUserToAddRows = true;
                bindingHDMua.BindingSource.MoveLast();
            }
            gridHDMua.Rows[gridHDMua.RowCount - 1].Cells["ColMaLoHDMua"].Value = xuly_chuoi(advTreeHDMua.SelectedNode.Text);
        }

        private void HDM_Delete_Click(object sender, EventArgs e)
        {
            if (gridHDMua.RowCount == 0)
                HDM_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HDMuaBLL.XoaHDMua(gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].Value.ToString(), gridHDMua.CurrentRow.Cells["ColMaHDMua"].Value.ToString());
                LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
            }
        }
        private void HDM_Save_Click(object sender, EventArgs e)
        {
            switch (hdmua_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionHDMua.Focus();
                            if (gridHDMua.CurrentRow.Cells["ColMaHDMua"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            HoaDonMua HDMua = new HoaDonMua();
                            string malohdmua = gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].Value.ToString();
                            string mahdmua = gridHDMua.CurrentRow.Cells["ColMaHDMua"].Value.ToString();
                            HDMua.MaLoaiHDMua = gridHDMua.CurrentRow.Cells["ColMaLoaiHDMua"].Value.ToString();
                            HDMua.MaNCC = gridHDMua.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            HDMua.MaTienTe = gridHDMua.CurrentRow.Cells["ColMaTienTe"].Value.ToString();
                            HDMua.MoTa = (gridHDMua.CurrentRow.Cells["ColMoTa"].Value != null ? gridHDMua.CurrentRow.Cells["ColMoTa"].Value.ToString() : "");
                            HDMua.NgayLap = System.Convert.ToDateTime(gridHDMua.CurrentRow.Cells["ColNgayLap"].Value);
                            HDMua.NguoiLap = (gridHDMua.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridHDMua.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            HDMua.NgaySua = System.Convert.ToDateTime(gridHDMua.CurrentRow.Cells["ColNgaySua"].Value);
                            HDMua.NguoiSua = (gridHDMua.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridHDMua.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            HDMuaBLL.SuaHDMua(malohdmua, mahdmua, HDMua);
                            LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                            ToolBarEnableLoaiHoaDonMua(true);
                        }
                        else
                        {
                            ToolBarEnableLoaiHoaDonMua(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionHDMua.Focus();
                            if (gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaHDMua"].Value == null || gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaLoaiHDMua"].Value == null || gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaLoHDMua"].Value == null || gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaNCC"].Value == null || gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaTienTe"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahdmua = gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaHDMua"].Value.ToString();
                            string maloaihdmua = gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaLoaiHDMua"].Value.ToString();
                            string malohdmua = gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaLoHDMua"].Value.ToString();
                            string manhacungcap = gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaNCC"].Value.ToString();
                            string matiente = gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMaTienTe"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            string mota = (gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMoTa"].Value != null ? gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColMoTa"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNguoiLap"].Value != null ? gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNguoiSua"].Value != null ? gridHDMua.Rows[gridHDMua.RowCount - 2].Cells["ColNguoiSua"].Value.ToString() : "");
                            HDMuaBLL.ThemHDMua(mahdmua, maloaihdmua, malohdmua, manhacungcap, matiente,mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                            ToolBarEnableLoaiHoaDonMua(true);
                            hdmua_nhapluoi = 0;
                        }
                        else
                        {
                            hdmua_nhapluoi = 0;
                            ToolBarEnableLoaiHoaDonMua(true);
                            return;
                        }

                        break;
                    }
            }
        }

        private void HDM_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hdmua_nhapluoi = 0;
                LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                ToolBarEnableHoaDonMua(true);
            }
            else
            {
                hdmua_nhapluoi = 0;
                return;
            }
        }
        private void HDM_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridHDMua_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableHoaDonMua();
        }
        private void gridHDMua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (hdmua_nhapluoi == 1)
                {
                    gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].ReadOnly = false;
                    gridHDMua.CurrentRow.Cells["ColMaHDMua"].ReadOnly = false;
                }
                else
                {
                    gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].ReadOnly = true;
                    gridHDMua.CurrentRow.Cells["ColMaHDMua"].ReadOnly = true;
                }
                if (e.ColumnIndex > -1 && gridHDMua.Columns[e.ColumnIndex].Name == "ColMaLoHDMua")
                {
                    gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].Value = xuly_chuoi(advTreeHDMua.SelectedNode.Text);
                }
                if (hdmua_nhapluoi == 0 && hdmua_nhaptay == 0)
                {
                    if (e.ColumnIndex == -1)
                    {
                        if (gridHDMua.CurrentRow.Cells["ColMaHDMua"].Value != null)
                        {
                            FrmChiTietHoaDonMua CTHDMua = new FrmChiTietHoaDonMua();
                            CTHDMua.mahdmua = gridHDMua.CurrentRow.Cells["ColMaHDMua"].Value.ToString();
                            CTHDMua.malohdm = gridHDMua.CurrentRow.Cells["ColMaLoHDMua"].Value.ToString();//xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
                            CTHDMua.Show();
                        }
                        else
                            return;
                    }
                }
            }
        }
        //Xử lý phần nhập tay
        private int hdmua_nhaptay = 0;

        private void SetConTrolToNull_HDMua()
        {
            HDM_txtMaHDMua.Text = "";
            HDM_cmbMaLoaiHDMua.Text = "";
            HDM_cmbMaLoHDMua.Text = "";
            HDM_cmbMaNhaCungCap.Text = "";
            HDM_cmbMaTienTe.Text = "";
            HDM_txtMoTa.Text = "";
            HDM_dpNgayLap.Value = DateTime.Now;
            HDM_cmbNguoiLap.Text = "";
            HDM_dpNgaySua.Value = DateTime.Now;
            HDM_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_HDMua(bool status)
        {
            btn_HDM_Sua.Enabled = status;
            btn_HDM_Them.Enabled = status;
            btn_HDM_Luu.Enabled = !status;
            btn_HDM_Huy.Enabled = !status;
            HDM_txtMaHDMua.Enabled = !status;
            HDM_cmbMaLoaiHDMua.Enabled = !status;
            HDM_cmbMaLoHDMua.Enabled = !status;
            HDM_cmbMaNhaCungCap.Enabled = !status;
            HDM_cmbMaTienTe.Enabled = !status;
            HDM_txtMoTa.Enabled = !status;
            HDM_dpNgayLap.Enabled = !status;
            HDM_cmbNguoiLap.Enabled = !status;
            HDM_dpNgaySua.Enabled = !status;
            HDM_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_HDMua(int dong)
        {
            if (gridHDMua.RowCount > 0 && hdmua_nhapluoi != 1)
            {
                HDM_txtMaHDMua.Text = gridHDMua.Rows[dong].Cells["ColMaHDMua"].Value.ToString();
                HDM_cmbMaLoaiHDMua.Text = gridHDMua.Rows[dong].Cells["ColMaLoaiHDMua"].Value.ToString();
                HDM_cmbMaLoHDMua.SelectedValue = gridHDMua.Rows[dong].Cells["ColMaLoHDMua"].Value.ToString();
                HDM_cmbMaNhaCungCap.Text = gridHDMua.Rows[dong].Cells["ColMaNCC"].Value.ToString();
                HDM_cmbMaTienTe.Text = gridHDMua.Rows[dong].Cells["ColMaTienTe"].Value.ToString();
                HDM_txtMoTa.Text = gridHDMua.Rows[dong].Cells["ColMoTa"].Value==null?"":gridHDMua.Rows[dong].Cells["ColMoTa"].Value.ToString();
                HDM_dpNgayLap.Value = System.Convert.ToDateTime(gridHDMua.Rows[dong].Cells["ColNgayLap"].Value.ToString());
                HDM_cmbNguoiLap.SelectedValue = gridHDMua.Rows[dong].Cells["ColNguoiLap"].Value==null?"":gridHDMua.Rows[dong].Cells["ColNguoiLap"].Value.ToString();
                HDM_dpNgaySua.Value = System.Convert.ToDateTime(gridHDMua.Rows[dong].Cells["ColNgaySua"].Value.ToString());
                HDM_cmbNguoiSua.SelectedValue = gridHDMua.Rows[dong].Cells["ColNguoiSua"].Value==null?"":gridHDMua.Rows[dong].Cells["ColNguoiSua"].Value.ToString();
            }
        }
        private void gridHDMua_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_HDMua(e.RowIndex);
            SetControlEnable_HDMua(true);
        }
        private void btn_HDM_Them_Click(object sender, EventArgs e)
        {
            hdmua_nhaptay = 1;
            SetConTrolToNull_HDMua();
            SetControlEnable_HDMua(false);
        }
        private void btn_HDM_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_HDMua(false);
            HDM_txtMaHDMua.Enabled = false;
            HDM_cmbMaLoHDMua.Enabled = false;
        }
        private void btn_HDM_Luu_Click(object sender, EventArgs e)
        {
            switch (hdmua_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            HoaDonMua HDMua = new HoaDonMua();
                            string malohdmua = HDM_cmbMaLoHDMua.Text;
                            string mahdb = HDM_txtMaHDMua.Text;
                            HDMua.MaLoaiHDMua = HDM_cmbMaLoaiHDMua.Text;
                            HDMua.MaNCC = HDM_cmbMaNhaCungCap.Text;
                            HDMua.MaTienTe = HDM_cmbMaTienTe.Text;
                            HDMua.MoTa = HDM_txtMoTa.Text;
                            HDMua.NgayLap = HDM_dpNgayLap.Value;
                            HDMua.NguoiLap = HDM_cmbNguoiLap.Text == "" ? "" : HDM_cmbNguoiLap.SelectedValue.ToString();
                            HDMua.NgaySua = HDM_dpNgaySua.Value;
                            HDMua.NguoiSua = HDM_cmbNguoiSua.Text == "" ? "" : HDM_cmbNguoiSua.SelectedValue.ToString();
                            HDMuaBLL.SuaHDMua(malohdmua, mahdb, HDMua);
                            LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                            SetControlEnable_HDMua(true);
                        }
                        else
                        {
                            SetControlEnable_HDMua(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (HDM_txtMaHDMua.Text == "" || HDM_cmbMaLoaiHDMua.Text == "" || HDM_cmbMaLoHDMua.Text == "" || HDM_cmbMaNhaCungCap.Text == "" || HDM_cmbMaTienTe.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahdmua = HDM_txtMaHDMua.Text;
                            string maloaihdmua = HDM_cmbMaLoaiHDMua.Text;
                            string malohdmua = HDM_cmbMaLoHDMua.Text;
                            string makhachhang = HDM_cmbMaNhaCungCap.Text;
                            string matiente = HDM_cmbMaTienTe.Text;
                            string mota = HDM_txtMoTa.Text;
                            DateTime ngaylap;
                            if (HDM_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(HDM_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (HDM_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(HDM_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = HDM_cmbNguoiLap.Text == "" ? "" : HDM_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = HDM_cmbNguoiSua.Text == "" ? "" : HDM_cmbNguoiSua.SelectedValue.ToString();
                            HDMuaBLL.ThemHDMua(mahdmua, maloaihdmua, malohdmua, makhachhang, matiente,mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                            SetControlEnable_HDMua(true);
                            hdmua_nhaptay = 0;
                        }
                        else
                        {
                            hdmua_nhaptay = 0;
                            SetControlEnable_HDMua(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_HDM_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSHoaDonMuaTheoLo(xuly_chuoi(advTreeHDMua.SelectedNode.Text));
                SetControlEnable_HDMua(true);
                hdmua_nhaptay = 0;
            }
            else
            {
                hdmua_nhaptay = 0;
                return;
            }
        }

#endregion


      

       

        

        

       

        
       

       

       

        

        

       

       

        

        

        

        
        

        

        

        

        

        

        

        
        

        

       

        

        

        

        
        

        
        

        

       

        

       

        

       

        
        

       

   }
}