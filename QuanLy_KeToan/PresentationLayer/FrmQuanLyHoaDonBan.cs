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
    public partial class FrmQuanLyHoaDonBan : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyHoaDonBan()
        {
            InitializeComponent();
        }
#region (Biến)
        private int xoa = 0;
#endregion
#region (Xử lý TreeView)
        private void LoadTreeView()
        {

            foreach (var item in LoHDBanBLL.LayDanhSachMaLoHoaDonBan())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                foreach (DevComponents.AdvTree.Node n in advTreeHDBan.Nodes[0].Nodes)
                {
                    if (n.Name == "nodeLoHDBan")
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
        private void advTreeHDBan_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
            if (e.Node.Level == 0)
                return;
            //Node Loại Hóa Đơn Bán
            if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoaiHDBan.BringToFront();
                AnHienGroup(groupLoaiHDBan, groupLoHDBan, groupHDBan);
                LayDanhSachLoaiHoaDonBan();
                xoa = 1;
            }
            //Node Lô Hóa Đơn Bán
            else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoHDBan.BringToFront();
                AnHienGroup(groupLoHDBan, groupLoaiHDBan, groupHDBan);
                LayDanhSachLoHoaDonBan();
                xoa = 2;
            }
            //Node Hóa Đơn Bán
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelHDBan.BringToFront();
                AnHienGroup(groupHDBan, groupLoHDBan, groupLoaiHDBan);
                string malohdban = xuly_chuoi(e.Node.Text);
                LayDSHoaDonBanTheoLo(malohdban);
                bindingHDBan.Enabled = true;
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
            //Loại Hóa Đơn Bán
            LoaiHDBan_cmbNguoiLap.DataSource = LoaiHDBanBLL.LayDanhSachNguoiLap();
            LoaiHDBan_cmbNguoiLap.ValueMember = "TenDangNhap";
            LoaiHDBan_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LoaiHDBan_cmbNguoiSua.DataSource = LoaiHDBanBLL.LayDanhSachNguoiSua();
            LoaiHDBan_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LoaiHDBan_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô Hóa Đơn Bán
            LoHDBan_cmbNguoiLap.DataSource = LoHDBanBLL.LayDanhSachNguoiLap();
            LoHDBan_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LoHDBan_cmbNguoiLap.ValueMember = "TenDangNhap";
            LoHDBan_cmbNguoiSua.DataSource = LoHDBanBLL.LayDanhSachNguoiSua();
            LoHDBan_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LoHDBan_cmbNguoiSua.ValueMember = "TenDangNhap";
            ////Hóa Đơn Bán
            HDB_cmbNguoiLap.DataSource = HDBanBLL.LayDanhSachNguoiLap();
            HDB_cmbNguoiLap.DisplayMember = "TenDangNhap";
            HDB_cmbNguoiLap.ValueMember = "TenDangNhap";
            HDB_cmbNguoiSua.DataSource = HDBanBLL.LayDanhSachNguoiSua();
            HDB_cmbNguoiSua.DisplayMember = "TenDangNhap";
            HDB_cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        //Hàm load các ComboboxColumn
        private void LoadComboboxColumnNguoiLap()
        {
            //Loại Hóa Đơn Bán
            ColumnNguoiLap.DataSource = LoaiHDBanBLL.LayDanhSachNguoiLap();
            ColumnNguoiLap.ValueMember = "TenDangNhap";
            ColumnNguoiLap.DisplayMember = "TenDangNhap";
            ColumnNguoiSua.DataSource = LoaiHDBanBLL.LayDanhSachNguoiSua();
            ColumnNguoiSua.ValueMember = "TenDangNhap";
            ColumnNguoiSua.DisplayMember = "TenDangNhap";
            //Lô Hóa Đơn Bán
            ColumNguoiLap.DataSource = LoHDBanBLL.LayDanhSachNguoiLap();
            ColumNguoiLap.ValueMember = "TenDangNhap";
            ColumNguoiLap.DisplayMember = "TenDangNhap";
            ColumNguoiSua.DataSource = LoHDBanBLL.LayDanhSachNguoiSua();
            ColumNguoiSua.ValueMember = "TenDangNhap";
            ColumNguoiSua.DisplayMember = "TenDangNhap";
            //Hóa Đơn Bán
            ColNguoiLap.DataSource = HDBanBLL.LayDanhSachNguoiLap();
            ColNguoiLap.ValueMember = "TenDangNhap";
            ColNguoiLap.DisplayMember = "TenDangNhap";
            ColNguoiSua.DataSource = HDBanBLL.LayDanhSachNguoiSua();
            ColNguoiSua.ValueMember = "TenDangNhap";
            ColNguoiSua.DisplayMember = "TenDangNhap";
        }
        
        //----------------Form Load---------------------------------//
        int truycap = 0;
        private void FrmQuanLyHoaDonBan_Load(object sender, EventArgs e)
        {
            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            //Loại Hóa Đơn Bán
            ToolBarEnableLoaiHoaDonBan(true);
            SetControlEnable_LoaiHDBan(true);
            LayDanhSachLoaiHoaDonBan();
            //Lô Hóa Đơn Bán
            ToolBarEnableLoHoaDonBan(true);
            SetControlEnable_LoHDBan(true);
            LoadCmbMaLoaiHang();
            LoadComboboxColumnMaLoaiHang();
            LayDanhSachLoHoaDonBan();
            //Hóa Đơn Bán
            ToolBarEnableHoaDonBan(true);
            SetControlEnable_HDBan(true);
            LoadMaLoaiHDBan();
            LoadMaLoHDBan();
            LoadMaKhachHang();
            LoadMaTienTe();
            if (gridHDBan.RowCount == 0)
            {
                bindingHDBan.Enabled = false;
            }
        }
        private void FrmQuanLyHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loaihdban_nhapluoi == 1 || loaihdban_nhaptay == 1 || lohdban_nhapluoi == 1 || lohdban_nhaptay == 1 || hdban_nhapluoi == 1 || hdban_nhaptay == 1)
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
                            LoaiHDBanBLL.XoaLoaiHDBan(gridLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].Value.ToString());
                            LayDanhSachLoaiHoaDonBan();
                        }
                        break;
                    }
                case 2:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoHDBanBLL.XoaLoHDBan(gridLoHDBan.CurrentRow.Cells["ColumMaLoHDBan"].Value.ToString());
                            LayDanhSachLoHoaDonBan();
                        }
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            HDBanBLL.XoaHDBan(gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value.ToString(), gridHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString());
                            LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
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
        private void FrmQuanLyHoaDonBan_KeyPress(object sender, KeyPressEventArgs e)
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
#region (Phần Loại Hóa Đơn Bán)

        LoaiHoaDonBanBLL LoaiHDBanBLL=new LoaiHoaDonBanBLL();
        private void LayDanhSachLoaiHoaDonBan()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoaiHDBanBLL.LayDanhSachLoaiHoaDonBan();
            gridLoaiHDBan.DataSource = bds;
            bindingLoaiHDBan.BindingSource = bds;
            gridLoaiHDBan.AllowUserToAddRows = false;
        }
        //Xử lý phần nhập lưới
        private int loaihdban_nhapluoi= 0;

        private void ToolBarEnableLoaiHoaDonBan(bool DangThaoTac = false)
        {
            LoaiHDBan_Add.Enabled = DangThaoTac;
            LoaiHDBan_Delete.Enabled = DangThaoTac;
            LoaiHDBan_Refresh.Enabled = DangThaoTac;
            LoaiHDBan_Save.Enabled = !DangThaoTac;
            LoaiHDBan_Cancel.Enabled = !DangThaoTac;
        }
        private void LoaiHDBan_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyHoaDonBan_Load(sender, e);
            ToolBarEnableLoaiHoaDonBan(true);
            loaihdban_nhapluoi = 0;
        }

        private void LoaiHDBan_Add_Click(object sender, EventArgs e)
        {
            loaihdban_nhapluoi = 1;
            ToolBarEnableLoaiHoaDonBan(false);
            if (gridLoaiHDBan.RowCount == 0)
            {
                gridLoaiHDBan.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiHDBan.AllowUserToAddRows = true;
                bindingLoaiHDBan.BindingSource.MoveLast();
            }
        }
        private void LoaiHDBan_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoaiHDBan.RowCount == 0)
                LoaiHDBan_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoaiHDBanBLL.XoaLoaiHDBan(gridLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].Value.ToString());
                LayDanhSachLoaiHoaDonBan();
            }
        }
        private void LoaiHDBan_Save_Click(object sender, EventArgs e)
        {
            switch (loaihdban_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiHDBan.Focus();
                            LoaiHDBan LoaiHDBan = new LoaiHDBan();
                            string maloaihoadonban = gridLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].Value.ToString();
                            LoaiHDBan.TenLoaiHDBan = gridLoaiHDBan.CurrentRow.Cells["ColumnTenLoaiHDBan"].Value != null ? gridLoaiHDBan.CurrentRow.Cells["ColumnTenLoaiHDBan"].Value.ToString() : "";
                            LoaiHDBan.NgayLap = System.Convert.ToDateTime(gridLoaiHDBan.CurrentRow.Cells["ColumnNgayLap"].Value.ToString());
                            LoaiHDBan.NguoiLap = (gridLoaiHDBan.CurrentRow.Cells["ColumnNguoiLap"].Value != null ? gridLoaiHDBan.CurrentRow.Cells["ColumnNguoiLap"].Value.ToString() : "");
                            LoaiHDBan.NgaySua = System.Convert.ToDateTime(gridLoaiHDBan.CurrentRow.Cells["ColumnNgaySua"].Value.ToString());
                            LoaiHDBan.NguoiSua = (gridLoaiHDBan.CurrentRow.Cells["ColumnNguoiSua"].Value != null ? gridLoaiHDBan.CurrentRow.Cells["ColumnNguoiSua"].Value.ToString() : "");
                            LoaiHDBanBLL.SuaLoaiHDBan(maloaihoadonban, LoaiHDBan);
                            LayDanhSachLoaiHoaDonBan();
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
                            positionLoaiHDBan.Focus();
                            if (gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount-2].Cells["ColumnMaLoaiHDBan"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                string maloaihoadonban = gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnMaLoaiHDBan"].Value.ToString();
                                string tenloaihoadonban = gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnTenLoaiHDBan"].Value.ToString();
                                DateTime ngaylap;
                                DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                                if (System.Convert.ToDateTime(gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNgayLap"].Value) != temp)
                                {
                                    ngaylap = System.Convert.ToDateTime(gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNgayLap"].Value);
                                }
                                else
                                {
                                    ngaylap = DateTime.Now.Date;
                                }
                                DateTime ngaysua;
                                if (System.Convert.ToDateTime(gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNgaySua"].Value) != temp)
                                {
                                    ngaysua = System.Convert.ToDateTime(gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNgaySua"].Value);
                                }
                                else
                                {
                                    ngaysua = DateTime.Now.Date;
                                }
                                string nguoilap = (gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNguoiLap"].Value != null ? gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNguoiLap"].Value.ToString() : "");
                                string nguoisua = (gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNguoiSua"].Value != null ? gridLoaiHDBan.Rows[gridLoaiHDBan.RowCount - 2].Cells["ColumnNguoiSua"].Value.ToString() : "");
                                LoaiHDBanBLL.ThemLoaiHDBan(maloaihoadonban, tenloaihoadonban, ngaylap, nguoilap, ngaysua, nguoisua);
                                LayDanhSachLoaiHoaDonBan();
                                loaihdban_nhapluoi = 0;
                            }
                        }
                        else
                        {
                            loaihdban_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoaiHDBan_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                loaihdban_nhapluoi = 0;
                LayDanhSachLoaiHoaDonBan();
                ToolBarEnableLoaiHoaDonBan(true);
            }
            else
            {
                loaihdban_nhapluoi = 0;
                return;
            }
        }
        private void LoaiHDBan_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridLoaiHDBan_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoaiHoaDonBan();
        }
        private void gridLoaiHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (loaihdban_nhapluoi == 1)
                    gridLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].ReadOnly = false;
                else
                    gridLoaiHDBan.CurrentRow.Cells["ColumnMaLoaiHDBan"].ReadOnly = true;
            }
        }

        //Code phần nhập tay
        private int loaihdban_nhaptay = 0;

        private void SetConTrolToNull_LoaiHDBan()
        {
            txtMaLoaiHDBan.Clear();
            txtTenLoaiHDBan.Clear();
            LoaiHDBan_dpNgayLap.Value = DateTime.Now;
            LoaiHDBan_cmbNguoiLap.Text = "";
            LoaiHDBan_dpNgaySua.Value = DateTime.Now;
            LoaiHDBan_cmbNguoiSua.Text = "";
        }

        private void SetControlEnable_LoaiHDBan(bool status)
        {
            btn_LoaiHDBan_Sua.Enabled = status;
            btn_LoaiHDBan_Them.Enabled = status;
            btn_LoaiHDBan_Luu.Enabled = !status;
            btn_LoaiHDBan_Huy.Enabled = !status;
            txtMaLoaiHDBan.ReadOnly = status;
            txtTenLoaiHDBan.ReadOnly = status;
            LoaiHDBan_dpNgayLap.Enabled = !status;
            LoaiHDBan_cmbNguoiLap.Enabled = !status;
            LoaiHDBan_dpNgaySua.Enabled = !status;
            LoaiHDBan_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiHDBan(int dong)
        {
            if (gridLoaiHDBan.RowCount > 0 && loaihdban_nhapluoi != 1)
            {
                txtMaLoaiHDBan.Text = gridLoaiHDBan.Rows[dong].Cells["ColumnMaLoaiHDBan"].Value.ToString();
                txtTenLoaiHDBan.Text = gridLoaiHDBan.Rows[dong].Cells["ColumnTenLoaiHDBan"].Value.ToString();
                LoaiHDBan_dpNgayLap.Value = System.Convert.ToDateTime(gridLoaiHDBan.Rows[dong].Cells["ColumnNgayLap"].Value.ToString());
                LoaiHDBan_cmbNguoiLap.Text = (gridLoaiHDBan.Rows[dong].Cells["ColumnNguoiLap"].Value == null ? "" : gridLoaiHDBan.Rows[dong].Cells["ColumnNguoiLap"].Value.ToString());
                LoaiHDBan_dpNgaySua.Value = System.Convert.ToDateTime(gridLoaiHDBan.Rows[dong].Cells["ColumnNgaySua"].Value.ToString());
                LoaiHDBan_cmbNguoiSua.Text = (gridLoaiHDBan.Rows[dong].Cells["ColumnNguoiSua"].Value == null ? "" : gridLoaiHDBan.Rows[dong].Cells["ColumnNguoiSua"].Value.ToString());
            }
        }
        private void gridLoaiHDBan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiHDBan(e.RowIndex);
            SetControlEnable_LoaiHDBan(true);
        }
        private void btn_LoaiHDBan_Them_Click(object sender, EventArgs e)
        {
            loaihdban_nhaptay = 1;
            SetConTrolToNull_LoaiHDBan();
            SetControlEnable_LoaiHDBan(false);
        }

        private void btn_LoaiHDBan_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoaiHDBan(false);
            txtMaLoaiHDBan.ReadOnly = true;
        }
        private void btn_LoaiHDBan_Luu_Click(object sender, EventArgs e)
        {
            switch (loaihdban_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiHDBan LoaiHDBan = new LoaiHDBan();
                            string maloaihoadonban = txtMaLoaiHDBan.Text;
                            LoaiHDBan.TenLoaiHDBan = txtTenLoaiHDBan.Text;
                            LoaiHDBan.NgayLap = LoaiHDBan_dpNgayLap.Value;
                            LoaiHDBan.NguoiLap = LoaiHDBan_cmbNguoiLap.Text == "" ? "" : LoaiHDBan_cmbNguoiLap.SelectedValue.ToString();
                            LoaiHDBan.NgaySua = LoaiHDBan_dpNgaySua.Value;
                            LoaiHDBan.NguoiSua = LoaiHDBan_cmbNguoiSua.Text == "" ? "" : LoaiHDBan_cmbNguoiSua.SelectedValue.ToString();
                            LoaiHDBanBLL.SuaLoaiHDBan(maloaihoadonban, LoaiHDBan);
                            LayDanhSachLoaiHoaDonBan();
                            SetControlEnable_LoaiHDBan(true);
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
                            if (txtMaLoaiHDBan.Text == "" || txtTenLoaiHDBan.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaihoadonban = txtMaLoaiHDBan.Text;
                            string tenloaihoadonban = txtTenLoaiHDBan.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LoaiHDBan_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LoaiHDBan_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LoaiHDBan_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LoaiHDBan_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LoaiHDBan_cmbNguoiLap.Text == "" ? "" : LoaiHDBan_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = LoaiHDBan_cmbNguoiSua.Text == "" ? "" : LoaiHDBan_cmbNguoiSua.SelectedValue.ToString();
                            LoaiHDBanBLL.ThemLoaiHDBan(maloaihoadonban, tenloaihoadonban, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiHoaDonBan();
                            loaihdban_nhaptay = 0;
                        }
                        else
                        {
                            loaihdban_nhaptay = 0;
                            SetControlEnable_LoaiHDBan(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LoaiHDBan_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiHoaDonBan();
                SetControlEnable_LoaiHDBan(true);
                loaihdban_nhaptay = 0;
            }
            else
            {
                loaihdban_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Lô Hóa Đơn Bán)

        LoHoaDonBanBLL LoHDBanBLL = new LoHoaDonBanBLL();
        
        private void LayDanhSachLoHoaDonBan()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoHDBanBLL.LayDanhSachLoHoaDonBan();
            bindingLoHDBan.BindingSource = bds;
            gridLoHDBan.DataSource = bds;
            gridLoHDBan.AllowUserToAddRows = false;
        }
        //Hàm Load các combobox
        private void LoadCmbMaLoaiHang()
        {
            LoHDBan_cmbMaLoaiHang.DataSource = LoHDBanBLL.LayDanhSachMaLoaiHang();
            LoHDBan_cmbMaLoaiHang.ValueMember = "MaLoaiHang";
            LoHDBan_cmbMaLoaiHang.DisplayMember = "TenLoaiHang";
        }
        //Hàm load các ComboboxColumn
        private void LoadComboboxColumnMaLoaiHang()
        {
            ColumMaLoaiHang.DataSource = LoHDBanBLL.LayDanhSachMaLoaiHang();
            ColumMaLoaiHang.ValueMember = "MaLoaiHang";
            ColumMaLoaiHang.DisplayMember = "TenLoaiHang";
        }
        
        //Xử lý nhập lưới
        int lohdban_nhapluoi = 0;

        private void ToolBarEnableLoHoaDonBan(bool DangThaoTac = false)
        {
            LoHDBan_Add.Enabled = DangThaoTac;
            LoHDBan_Delete.Enabled = DangThaoTac;
            LoHDBan_Refresh.Enabled = DangThaoTac;
            LoHDBan_Save.Enabled = !DangThaoTac;
            LoHDBan_Cancel.Enabled = !DangThaoTac;
        }
        private void LoHDBan_Refresh_Click(object sender, EventArgs e)
        {
            lohdban_nhapluoi = 0;
            FrmQuanLyHoaDonBan_Load(sender, e);
            ToolBarEnableLoHoaDonBan(true);
            LayDanhSachLoHoaDonBan();
        }
        private void LoHDBan_Add_Click(object sender, EventArgs e)
        {
            lohdban_nhapluoi = 1;
            ToolBarEnableLoHoaDonBan(false);
            if (gridLoHDBan.RowCount == 0)
            {
                gridLoHDBan.AllowUserToAddRows = true;
            }
            else
            {
                gridLoHDBan.AllowUserToAddRows = true;
                bindingLoHDBan.BindingSource.MoveLast();
            }
        }
        private void LoHDBan_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoHDBan.RowCount == 0)
                LoHDBan_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoHDBanBLL.XoaLoHDBan(gridLoHDBan.CurrentRow.Cells["ColumMaLoHDBan"].Value.ToString());
                LayDanhSachLoHoaDonBan();
            }
        }
        private void LoHDBan_Save_Click(object sender, EventArgs e)
        {
            switch (lohdban_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoHDBan.Focus();
                            LoHDBan LoHDBan = new LoHDBan();
                            string malohdban = gridLoHDBan.CurrentRow.Cells["ColumMaLoHDBan"].Value.ToString();
                            LoHDBan.MaLoaiHang = gridLoHDBan.CurrentRow.Cells["ColumMaLoaiHang"].Value.ToString();
                            LoHDBan.NgayLoHDBan = System.Convert.ToDateTime(gridLoHDBan.CurrentRow.Cells["ColumNgayLoHDBan"].Value.ToString());
                            LoHDBan.MoTa = (gridLoHDBan.CurrentRow.Cells["ColumMoTa"].Value != null ? gridLoHDBan.CurrentRow.Cells["ColumMoTa"].Value.ToString() : "");
                            LoHDBan.NgayLap = System.Convert.ToDateTime(gridLoHDBan.CurrentRow.Cells["ColumNgayLap"].Value.ToString());
                            LoHDBan.NguoiLap = (gridLoHDBan.CurrentRow.Cells["ColumNguoiLap"].Value != null ? gridLoHDBan.CurrentRow.Cells["ColumNguoiLap"].Value.ToString() : "");
                            LoHDBan.NgaySua = System.Convert.ToDateTime(gridLoHDBan.CurrentRow.Cells["ColumNgaySua"].Value.ToString());
                            LoHDBan.NguoiSua = (gridLoHDBan.CurrentRow.Cells["ColumNguoiSua"].Value != null ? gridLoHDBan.CurrentRow.Cells["ColumNguoiSua"].Value.ToString() : "");
                            LoHDBanBLL.SuaLoHDBan(malohdban, LoHDBan);
                            LayDanhSachLoHoaDonBan();
                            ToolBarEnableLoHoaDonBan(true);
                        }
                        else
                        {
                            ToolBarEnableLoHoaDonBan(true);
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
                            positionLoHDBan.Focus();
                            if (gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumMaLoHDBan"].Value == null || gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumMaLoaiHang"].Value == null ||
                                System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgayLoHDBan"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdban = gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumMaLoHDBan"].Value.ToString();
                            string maloaihang = gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumMaloaiHang"].Value.ToString();
                            DateTime ngaylohoadonban;
                            if (System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgayLoHDBan"].Value) != temp)
                            {
                                ngaylohoadonban = System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgayLoHDBan"].Value);
                            }
                            else
                            {
                                ngaylohoadonban = DateTime.Now.Date;
                            }
                            string mota = (gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumMoTa"].Value != null ? gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumMoTa"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNguoiLap"].Value != null ? gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNguoiSua"].Value != null ? gridLoHDBan.Rows[gridLoHDBan.RowCount - 2].Cells["ColumNguoiSua"].Value.ToString() : "");
                            LoHDBanBLL.ThemLoHDBan(malohdban,maloaihang, ngaylohoadonban, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoHoaDonBan();
                            lohdban_nhapluoi = 0;
                        }
                        else
                        {
                            lohdban_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoHDBan_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lohdban_nhapluoi = 0;
                LayDanhSachLoHoaDonBan();
                ToolBarEnableLoHoaDonBan(true);
            }
            else
            {
                lohdban_nhapluoi = 0;
                return;
            }
        }
        private void LoHDBan_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoHDBan_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoHoaDonBan();
        }
        private void gridLoHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lohdban_nhapluoi == 1)
                    gridLoHDBan.CurrentRow.Cells["ColumMaLoHDBan"].ReadOnly = false;
                else
                    gridLoHDBan.CurrentRow.Cells["ColumMaLoHDBan"].ReadOnly = true;
            }
        }
        //Xử lý phần nhập tay
        private int lohdban_nhaptay = 0;

        private void SetConTrolToNull_LoHDBan()
        {
            txtMaLoHDBan.Text = "";
            LoHDBan_cmbMaLoaiHang.Text = "";
            dpNgayLoHDBan.Value = DateTime.Now;
            txtMoTa.Text = "";
            LoHDBan_dpNgayLap.Value = DateTime.Now;
            LoHDBan_cmbNguoiLap.Text = "";
            LoHDBan_dpNgaySua.Value = DateTime.Now;
            LoHDBan_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_LoHDBan(bool status)
        {
            btn_LoHDBan_Sua.Enabled = status;
            btn_LoHDBan_Them.Enabled = status;
            btn_LoHDBan_Luu.Enabled = !status;
            btn_LoHDBan_Huy.Enabled = !status;
            txtMaLoHDBan.Enabled = !status;
            LoHDBan_cmbMaLoaiHang.Enabled = !status;
            dpNgayLoHDBan.Enabled = !status;
            txtMoTa.Enabled = !status;
            LoHDBan_dpNgayLap.Enabled = !status;
            LoHDBan_cmbNguoiLap.Enabled = !status;
            LoHDBan_dpNgaySua.Enabled = !status;
            LoHDBan_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoHDBan(int dong)
        {
            if (gridLoHDBan.RowCount > 0 && lohdban_nhapluoi != 1)
            {
                txtMaLoHDBan.Text = gridLoHDBan.Rows[dong].Cells["ColumMaLoHDBan"].Value.ToString();
                LoHDBan_cmbMaLoaiHang.Text = gridLoHDBan.Rows[dong].Cells["ColumMaLoaiHang"].Value.ToString();
                dpNgayLoHDBan.Value = System.Convert.ToDateTime(gridLoHDBan.Rows[dong].Cells["ColumNgayLoHDBan"].Value.ToString());
                txtMoTa.Text = gridLoHDBan.Rows[dong].Cells["ColumMoTa"].Value.ToString();
                LoHDBan_dpNgayLap.Value = System.Convert.ToDateTime(gridLoHDBan.Rows[dong].Cells["ColumNgayLap"].Value.ToString());
                LoHDBan_cmbNguoiLap.Text = gridLoHDBan.Rows[dong].Cells["ColumNguoiLap"].Value==null?"":gridLoHDBan.Rows[dong].Cells["ColumNguoiLap"].Value.ToString();
                LoHDBan_dpNgaySua.Value = System.Convert.ToDateTime(gridLoHDBan.Rows[dong].Cells["ColumNgaySua"].Value.ToString());
                LoHDBan_cmbNguoiSua.Text = gridLoHDBan.Rows[dong].Cells["ColumNguoiSua"].Value==null?"":gridLoHDBan.Rows[dong].Cells["ColumNguoiSua"].Value.ToString();
            }
        }
        private void gridLoHDBan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoHDBan(e.RowIndex);
            SetControlEnable_LoHDBan(true);
        }
        private void btn_LoHDBan_Them_Click(object sender, EventArgs e)
        {
            lohdban_nhaptay = 1;
            SetConTrolToNull_LoHDBan();
            SetControlEnable_LoHDBan(false);
        }
        private void btn_LoHDBan_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoHDBan(false);
            txtMaLoHDBan.Enabled = false;
        }
        private void btn_LoHDBan_Luu_Click(object sender, EventArgs e)
        {
            switch (lohdban_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoHDBan LoHDBan = new LoHDBan();
                            string malohdban = txtMaLoHDBan.Text;
                            LoHDBan.MaLoaiHang = LoHDBan_cmbMaLoaiHang.Text;
                            LoHDBan.NgayLoHDBan = dpNgayLoHDBan.Value;
                            LoHDBan.MoTa = txtMoTa.Text;
                            LoHDBan.NgayLap = LoHDBan_dpNgayLap.Value;
                            LoHDBan.NguoiLap = LoHDBan_cmbNguoiLap.Text == "" ? "" : LoHDBan_cmbNguoiLap.SelectedValue.ToString();
                            LoHDBan.NgaySua = LoHDBan_dpNgaySua.Value;
                            LoHDBan.NguoiSua = LoHDBan_cmbNguoiSua.Text == "" ? "" : LoHDBan_cmbNguoiSua.SelectedValue.ToString();
                            LoHDBanBLL.SuaLoHDBan(malohdban, LoHDBan);
                            LayDanhSachLoHoaDonBan();
                            SetControlEnable_LoHDBan(true);
                        }
                        else
                        {
                            SetControlEnable_LoHDBan(true);
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
                            if (txtMaLoHDBan.Text == "" || LoHDBan_cmbMaLoaiHang.Text == "" || dpNgayLoHDBan.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdban = txtMaLoHDBan.Text;
                            string maloaihang = LoHDBan_cmbMaLoaiHang.SelectedValue.ToString();
                            DateTime ngaylohoadonban = dpNgayLoHDBan.Value;
                            string mota = txtMoTa.Text;
                            DateTime ngaylap;
                            if (LoHDBan_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LoHDBan_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LoHDBan_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LoHDBan_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LoHDBan_cmbNguoiLap.Text == "" ? "" : LoHDBan_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = LoHDBan_cmbNguoiSua.Text == "" ? "" : LoHDBan_cmbNguoiSua.SelectedValue.ToString();
                            LoHDBanBLL.ThemLoHDBan(malohdban, maloaihang, ngaylohoadonban, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoHoaDonBan();
                            SetControlEnable_LoHDBan(true);
                            lohdban_nhaptay = 0;
                        }
                        else
                        {
                            lohdban_nhaptay = 0;
                            SetControlEnable_LoHDBan(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LoHDBan_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoHoaDonBan();
                SetControlEnable_LoHDBan(true);
                lohdban_nhaptay = 0;
            }
            else
            {
                lohdban_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Hóa Đơn Bán)
        HoaDonBanBLL HDBanBLL = new HoaDonBanBLL();  

        private void LoadMaLoaiHDBan()
        {
            //Combobox Column
            ColMaLoaiHDBan.DataSource = HDBanBLL.LayDanhSachMaLoaiHoaDonBan();
            ColMaLoaiHDBan.DisplayMember = "MaLoaiHDBan";
            ColMaLoaiHDBan.ValueMember = "MaLoaiHDBan";
            //Combobox
            HDB_cmbMaLoaiHDBan.DataSource = HDBanBLL.LayDanhSachMaLoaiHoaDonBan();
            HDB_cmbMaLoaiHDBan.DisplayMember = "MaLoaiHDBan";
            HDB_cmbMaLoaiHDBan.ValueMember = "MaLoaiHDBan";
        }
        private void LoadMaLoHDBan()
        {
            //Combobox Column
            ColMaLoHDBan.DataSource = HDBanBLL.LayDanhSachMaLoHoaDonBan();
            ColMaLoHDBan.DisplayMember = "MaLoHDBan";
            ColMaLoHDBan.ValueMember = "MaLoHDBan";
            //Combobox
            HDB_cmbMaLoHDBan.DataSource = HDBanBLL.LayDanhSachMaLoHoaDonBan();
            HDB_cmbMaLoHDBan.DisplayMember = "MaLoHDBan";
            HDB_cmbMaLoHDBan.ValueMember = "MaLoHDBan";
        }
        private void LoadMaKhachHang()
        {
            //Combobox Column
            ColMaKhachHang.DataSource = HDBanBLL.LayDanhSachMaKhachHang();
            ColMaKhachHang.DisplayMember = "TenKhachHang";
            ColMaKhachHang.ValueMember = "MaKhachHang";
            //Combobox
            HDB_cmbMaKhachHang.DataSource = HDBanBLL.LayDanhSachMaKhachHang();
            HDB_cmbMaKhachHang.DisplayMember = "TenKhachHang";
            HDB_cmbMaKhachHang.ValueMember = "MaKhachHang";
        }
        private void LoadMaTienTe()
        {
            //Combobox Column
            ColMaTienTe.DataSource = HDBanBLL.LayDanhSachMaTienTe();
            ColMaTienTe.DisplayMember = "MaTienTe";
            ColMaTienTe.ValueMember = "MaTienTe";
            //Combobox
            HDB_cmbMaTienTe.DataSource = HDBanBLL.LayDanhSachMaTienTe();
            HDB_cmbMaTienTe.DisplayMember = "MaTienTe";
            HDB_cmbMaTienTe.ValueMember = "MaTienTe";
        }
        private void LayDSHoaDonBanTheoLo(string malohdban)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HDBanBLL.LayDanhSachHoaDonTheoMaLoHoaDonBan(malohdban);
            bindingHDBan.BindingSource = bds;
            gridHDBan.DataSource = bds;
            gridHDBan.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int hdban_nhapluoi = 0;
        private void ToolBarEnableHoaDonBan(bool DangThaoTac = false)
        {
            HDB_Add.Enabled = DangThaoTac;
            HDB_Delete.Enabled = DangThaoTac;
            HDB_Refresh.Enabled = DangThaoTac;
            HDB_Save.Enabled = !DangThaoTac;
            HDB_Cancel.Enabled = !DangThaoTac;
        }
        private void HDB_Refresh_Click(object sender, EventArgs e)
        {
            hdban_nhapluoi = 0;
            FrmQuanLyHoaDonBan_Load(sender, e);
            ToolBarEnableHoaDonBan(true);
            LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
        }
        private void HDB_Add_Click(object sender, EventArgs e)
        {
            hdban_nhapluoi = 1;
            ToolBarEnableHoaDonBan(false);
            if (gridHDBan.RowCount == 0)
            {
                gridHDBan.AllowUserToAddRows = true;
            }
            else
            {
                gridHDBan.AllowUserToAddRows = true;
                bindingHDBan.BindingSource.MoveLast();
            }
            gridHDBan.Rows[gridHDBan.RowCount - 1].Cells["ColMaLoHDBan"].Value = xuly_chuoi(advTreeHDBan.SelectedNode.Text);
        }
        private void HDB_Delete_Click(object sender, EventArgs e)
        {
            if (gridHDBan.RowCount == 0)
                HDB_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HDBanBLL.XoaHDBan(gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value.ToString(), gridHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString());
                LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
            }
        }
        private void HDB_Save_Click(object sender, EventArgs e)
        {
            switch (hdban_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionHDBan.Focus();
                            if (gridHDBan.CurrentRow.Cells["ColMaHDBan"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            HoaDonBan HDBan = new HoaDonBan();
                            string malohdban = gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value.ToString();
                            string mahdban = gridHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString();
                            HDBan.MaLoaiHDBan = gridHDBan.CurrentRow.Cells["ColMaLoaiHDBan"].Value.ToString();
                            HDBan.MaKhachHang = gridHDBan.CurrentRow.Cells["ColMaKhachHang"].Value.ToString();
                            HDBan.MaTienTe = gridHDBan.CurrentRow.Cells["ColMaTienTe"].Value.ToString();
                            HDBan.MoTa = (gridHDBan.CurrentRow.Cells["ColMoTa"].Value != null ? gridHDBan.CurrentRow.Cells["ColMoTa"].Value.ToString() : "");
                            HDBan.NgayLap = System.Convert.ToDateTime(gridHDBan.CurrentRow.Cells["ColNgayLap"].Value.ToString());
                            HDBan.NguoiLap = (gridHDBan.CurrentRow.Cells["ColNguoiLap"].Value != null ? gridHDBan.CurrentRow.Cells["ColNguoiLap"].Value.ToString() : "");
                            HDBan.NgaySua = System.Convert.ToDateTime(gridHDBan.CurrentRow.Cells["ColNgaySua"].Value.ToString());
                            HDBan.NguoiSua = (gridHDBan.CurrentRow.Cells["ColNguoiSua"].Value != null ? gridHDBan.CurrentRow.Cells["ColNguoiSua"].Value.ToString() : "");
                            HDBanBLL.SuaHDBan(malohdban, mahdban, HDBan);
                            LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
                            ToolBarEnableLoaiHoaDonBan(true);
                        }
                        else
                        {
                            ToolBarEnableLoaiHoaDonBan(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionHDBan.Focus();
                            if (gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaHDBan"].Value == null || gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaLoaiHDBan"].Value == null || gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaLoHDBan"].Value == null || gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaKhachHang"].Value == null || gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaTienTe"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahdban = gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaHDBan"].Value.ToString();
                            string maloaihdban = gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaLoaiHDBan"].Value.ToString();
                            string malohdban = gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaLoHDBan"].Value.ToString();
                            string makhachhang = gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaKhachHang"].Value.ToString();
                            string matiente = gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMaTienTe"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            string mota = (gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMoTa"].Value != null ? gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColMoTa"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNguoiLap"].Value != null ? gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNguoiSua"].Value != null ? gridHDBan.Rows[gridHDBan.RowCount - 2].Cells["ColNguoiSua"].Value.ToString() : "");
                            HDBanBLL.ThemHDBan(mahdban, maloaihdban, malohdban, makhachhang, matiente, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
                            ToolBarEnableLoaiHoaDonBan(true);
                            hdban_nhapluoi = 0;
                        }
                        else
                        {
                            hdban_nhapluoi = 0;
                            ToolBarEnableLoaiHoaDonBan(true);
                            return;
                        }

                        break;
                    }
            }
        }
        private void HDB_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hdban_nhapluoi = 0;
                LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
                ToolBarEnableHoaDonBan(true);
            }
            else
            {
                hdban_nhapluoi = 0;
                return;
            }
        }
        private void HDB_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridHDBan_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableHoaDonBan();
        }
        private void gridHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (hdban_nhapluoi == 1)
                {
                    gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].ReadOnly = false;
                    gridHDBan.CurrentRow.Cells["ColMaHDBan"].ReadOnly = false;
                }
                else
                {
                    gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].ReadOnly = true;
                    gridHDBan.CurrentRow.Cells["ColMaHDBan"].ReadOnly = true;
                }
                if (e.ColumnIndex>-1 && gridHDBan.Columns[e.ColumnIndex].Name == "ColMaLoHDBan")
                {
                    gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value = xuly_chuoi(advTreeHDBan.SelectedNode.Text);
                }
                if (hdban_nhapluoi == 0 && hdban_nhaptay == 0)
                {
                    if (e.ColumnIndex==-1)
                    {
                        if (gridHDBan.CurrentRow.Cells["ColMaHDBan"].Value != null)
                        {
                            FrmChiTietHoaDonBan CTHDBan = new FrmChiTietHoaDonBan();
                            CTHDBan.mahdban = gridHDBan.CurrentRow.Cells["ColMaHDBan"].Value.ToString();
                            CTHDBan.malohdb = gridHDBan.CurrentRow.Cells["ColMaLoHDBan"].Value.ToString();//xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
                            CTHDBan.Show();
                        }
                        else
                            return;
                    }
                }
            }
        }
        //Xử lý phần nhập tay
        private int hdban_nhaptay = 0;

        private void SetConTrolToNull_HDBan()
        {
            HDB_txtMaHDBan.Text = "";
            HDB_cmbMaLoaiHDBan.Text = "";
            HDB_cmbMaLoHDBan.Text = "";
            HDB_cmbMaKhachHang.Text = "";
            HDB_cmbMaTienTe.Text = "";
            HDB_txtMoTa.Text = "";
            HDB_dpNgayLap.Value = DateTime.Now;
            HDB_cmbNguoiLap.Text = "";
            HDB_dpNgaySua.Value = DateTime.Now;
            HDB_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_HDBan(bool status)
        {
            btn_HDB_Sua.Enabled = status;
            btn_HDB_Them.Enabled = status;
            btn_HDB_Luu.Enabled = !status;
            btn_HDB_Huy.Enabled = !status;
            HDB_txtMaHDBan.Enabled = !status;
            HDB_cmbMaLoaiHDBan.Enabled = !status;
            HDB_cmbMaLoHDBan.Enabled = !status;
            HDB_cmbMaKhachHang.Enabled = !status;
            HDB_cmbMaTienTe.Enabled = !status;
            HDB_txtMoTa.Enabled = !status;
            HDB_dpNgayLap.Enabled = !status;
            HDB_cmbNguoiLap.Enabled = !status;
            HDB_dpNgaySua.Enabled = !status;
            HDB_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_HDBan(int dong)
        {
            if (gridHDBan.RowCount > 0 && hdban_nhapluoi != 1)
            {
                HDB_txtMaHDBan.Text = gridHDBan.Rows[dong].Cells["ColMaHDBan"].Value.ToString();
                HDB_cmbMaLoaiHDBan.Text = gridHDBan.Rows[dong].Cells["ColMaLoaiHDBan"].Value.ToString();
                HDB_cmbMaLoHDBan.SelectedValue = gridHDBan.Rows[dong].Cells["ColMaLoHDBan"].Value.ToString();
                HDB_cmbMaKhachHang.Text = gridHDBan.Rows[dong].Cells["ColMaKhachHang"].Value.ToString();
                HDB_cmbMaTienTe.Text = gridHDBan.Rows[dong].Cells["ColMaTienTe"].Value.ToString();
                HDB_txtMoTa.Text = gridHDBan.Rows[dong].Cells["ColMoTa"].Value==null?"":gridHDBan.Rows[dong].Cells["ColMoTa"].Value.ToString();
                HDB_dpNgayLap.Value = System.Convert.ToDateTime(gridHDBan.Rows[dong].Cells["ColNgayLap"].Value.ToString());
                HDB_cmbNguoiLap.SelectedValue = gridHDBan.Rows[dong].Cells["ColNguoiLap"].Value==null?"":gridHDBan.Rows[dong].Cells["ColNguoiLap"].Value.ToString();
                HDB_dpNgaySua.Value = System.Convert.ToDateTime(gridHDBan.Rows[dong].Cells["ColNgaySua"].Value.ToString());
                HDB_cmbNguoiSua.SelectedValue = gridHDBan.Rows[dong].Cells["ColNguoiSua"].Value==null?"":gridHDBan.Rows[dong].Cells["ColNguoiSua"].Value.ToString();
            }
        }
        private void gridHDBan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_HDBan(e.RowIndex);
            SetControlEnable_HDBan(true);
        }

        private void btn_HDB_Them_Click(object sender, EventArgs e)
        {
            hdban_nhaptay = 1;
            SetConTrolToNull_HDBan();
            SetControlEnable_HDBan(false);
        }
        private void btn_HDB_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_HDBan(false);
            HDB_txtMaHDBan.Enabled = false;
            HDB_cmbMaLoHDBan.Enabled = false;
        }
        private void btn_HDB_Luu_Click(object sender, EventArgs e)
        {
            switch (hdban_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            HoaDonBan HDBan = new HoaDonBan();
                            string malohdban = HDB_cmbMaLoHDBan.Text;
                            string mahdb = HDB_txtMaHDBan.Text;
                            HDBan.MaLoaiHDBan = HDB_cmbMaLoaiHDBan.Text;
                            HDBan.MaKhachHang = HDB_cmbMaKhachHang.Text;
                            HDBan.MaTienTe = HDB_cmbMaTienTe.Text;
                            HDBan.MoTa = HDB_txtMoTa.Text;
                            HDBan.NgayLap = HDB_dpNgayLap.Value;
                            HDBan.NguoiLap = HDB_cmbNguoiLap.Text==""?"":HDB_cmbNguoiLap.SelectedValue.ToString();
                            HDBan.NgaySua = HDB_dpNgaySua.Value;
                            HDBan.NguoiSua = HDB_cmbNguoiSua.Text==""?"":HDB_cmbNguoiSua.SelectedValue.ToString();
                            HDBanBLL.SuaHDBan(malohdban, mahdb, HDBan);
                            LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
                            SetControlEnable_HDBan(true);
                        }
                        else
                        {
                            SetControlEnable_HDBan(true);
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
                            if (HDB_txtMaHDBan.Text == "" || HDB_cmbMaLoaiHDBan.Text == "" || HDB_cmbMaLoHDBan.Text == "" || HDB_cmbMaKhachHang.Text == "" || HDB_cmbMaTienTe.Text =="")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahdban = HDB_txtMaHDBan.Text;
                            string maloaihdban = HDB_cmbMaLoaiHDBan.Text;
                            string malohdban = HDB_cmbMaLoHDBan.Text;
                            string makhachhang = HDB_cmbMaKhachHang.Text;
                            string matiente = HDB_cmbMaTienTe.Text;
                            string mota = HDB_txtMoTa.Text;
                            DateTime ngaylap;
                            if (HDB_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(HDB_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (HDB_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(HDB_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = HDB_cmbNguoiLap.Text == "" ? "" : HDB_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = HDB_cmbNguoiSua.Text == "" ? "" : HDB_cmbNguoiSua.SelectedValue.ToString();
                            HDBanBLL.ThemHDBan(mahdban,maloaihdban, malohdban,makhachhang,matiente, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
                            SetControlEnable_HDBan(true);
                            hdban_nhaptay = 0;
                        }
                        else
                        {
                            hdban_nhaptay = 0;
                            SetControlEnable_HDBan(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_HDB_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSHoaDonBanTheoLo(xuly_chuoi(advTreeHDBan.SelectedNode.Text));
                SetControlEnable_HDBan(true);
                hdban_nhaptay = 0;
            }
            else
            {
                hdban_nhaptay = 0;
                return;
            }
        }

#endregion
   }
}