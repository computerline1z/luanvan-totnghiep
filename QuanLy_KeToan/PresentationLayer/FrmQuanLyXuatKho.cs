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
    public partial class FrmQuanLyXuatKho : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyXuatKho()
        {
            InitializeComponent();
        }
#region (Biến)
        private int xoa = 0;
#endregion
#region (Xử lý TreeView)
        private void LoadTreeView()
        {
            //advTreeLoXuat.DataSource = LNBLL.LayDanhSachMaLoXuat();
            foreach (var item in LoPXBLL.LayDanhSachMaLoHDBan())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                foreach (DevComponents.AdvTree.Node n in advTreeLoXuat.Nodes[0].Nodes)
                {
                    if (n.Name == "nodeLoPhieuXuat")
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
        private void advTreeLoXuat_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
            if (e.Node.Level == 0)
                return;
            //Node Loại phiếu Xuất
            if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoaiPhieuXuat.BringToFront();
                AnHienGroup(groupLoaiPhieuXuat, groupLoPhieuXuat, groupPhieuXuat);
                LayDanhSachLoaiPX();
                xoa = 1;
            }
            //Node Lô Phiếu Xuất
            else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoPhieuXuat.BringToFront();
                AnHienGroup(groupLoPhieuXuat, groupLoaiPhieuXuat, groupPhieuXuat);
                LayDanhSachLoPX();
                xoa = 2;
            }
            //Node Phiếu Xuất
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelPhieuXuat.BringToFront();
                AnHienGroup(groupPhieuXuat, groupLoPhieuXuat, groupLoaiPhieuXuat);
                string malohdban = xuly_chuoi(e.Node.Text);
                LayDSPhieuXuatTheoLo(malohdban);
                bindingPhieuXuat.Enabled = true;
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
            //Loại phiếu xuất
            LPX_cmbNguoiLap.DataSource = LPXBLL.LayNguoiLap();
            LPX_cmbNguoiLap.ValueMember = "TenDangNhap";
            LPX_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LPX_cmbNguoiSua.DataSource = LPXBLL.LayNguoiLap();
            LPX_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LPX_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô phiếu xuất
            LoPX_cmbNguoiLap.DataSource = LoPXBLL.LayNguoiLap();
            LoPX_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LoPX_cmbNguoiLap.ValueMember = "TenDangNhap";
            LoPX_cmbNguoiSua.DataSource = LoPXBLL.LayNguoiLap();
            LoPX_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LoPX_cmbNguoiSua.ValueMember = "TenDangNhap";
            ////Phiếu xuất
            PX_cmbNguoiLap.DataSource = PXBLL.LayNguoiLap();
            PX_cmbNguoiLap.DisplayMember = "TenDangNhap";
            PX_cmbNguoiLap.ValueMember = "TenDangNhap";
            PX_cmbNguoiSua.DataSource = PXBLL.LayNguoiLap();
            PX_cmbNguoiSua.DisplayMember = "TenDangNhap";
            PX_cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        //Hàm load các ComboboxColumn
        private void LoadComboboxColumnNguoiLap()
        {
            //Loại phiếu xuất
            NgL.DataSource = LPXBLL.LayNguoiLap();
            NgL.ValueMember = "TenDangNhap";
            NgL.DisplayMember = "TenDangNhap";
            NgS.DataSource = LPXBLL.LayNguoiLap();
            NgS.ValueMember = "TenDangNhap";
            NgS.DisplayMember = "TenDangNhap";
            //Lô Phiếu Xuất
            NguoiLap.DataSource = LoPXBLL.LayNguoiLap();
            NguoiLap.ValueMember = "TenDangNhap";
            NguoiLap.DisplayMember = "TenDangNhap";
            NguoiSua.DataSource = LoPXBLL.LayNguoiLap();
            NguoiSua.ValueMember = "TenDangNhap";
            NguoiSua.DisplayMember = "TenDangNhap";
            //Phiếu Xuất
            _NgL.DataSource = PXBLL.LayNguoiLap();
            _NgL.ValueMember = "TenDangNhap";
            _NgL.DisplayMember = "TenDangNhap";
            _NgS.DataSource = PXBLL.LayNguoiLap();
            _NgS.ValueMember = "TenDangNhap";
            _NgS.DisplayMember = "TenDangNhap";
        }
        private void LoadMaLoHDban()
        {
            //Lô Phiếu xuất
            ColMLHDB.DataSource = LoPXBLL.LayMaLoHDBan();
            ColMLHDB.DisplayMember = "MaLoHDBan";
            ColMLHDB.ValueMember = "MaLoHDBan";

            cmbMaLoHDBan.DataSource = LoPXBLL.LayMaLoHDBan();
            cmbMaLoHDBan.DisplayMember = "MaLoHDBan";
            cmbMaLoHDBan.ValueMember = "MaLoHDBan";

            //Phiếu xuất
            MLHDB.DataSource = PXBLL.LayLoHDBan();
            MLHDB.DisplayMember = "MaLoHDBan";
            MLHDB.ValueMember = "MaLoHDBan";

            PX_cmbMLHDB.DataSource = PXBLL.LayLoHDBan();
            PX_cmbMLHDB.DisplayMember = "MaLoHDBan";
            PX_cmbMLHDB.ValueMember = "MaLoHDBan";
        }
        //----------------Form Load---------------------------------//
        int truycap = 0;
        private void FrmQuanLyXuatKho_Load(object sender, EventArgs e)
        {
            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            //Loại phiếu xuất
            ToolBarEnableLoaiPhieuXuat(true);
            SetControlEnable_LoaiPhieuXuat(true);
            LayDanhSachLoaiPX();
            //Lô phiếu xuất
            ToolBarEnableLoPhieuXuat(true);
            SetControlEnable_LoPhieuXuat(true);
            LoadMaLoHDban();
            LayDanhSachLoPX();
            //Phiếu Xuất
            ToolBarEnablePhieuXuat(true);
            SetControlEnable_PhieuXuat(true);
            LoadMaLoaiPX();
            LoadMaHDBan();
            if (gridPhieuXuat.RowCount == 0)
            {
                bindingPhieuXuat.Enabled = false;
            }
            //Kiểm tra lưới có rỗng không
            if (gridLoaiPhieuXuat.RowCount == 0)
                SetControlEnable_LoaiPhieuXuat(true);
            if (gridLoPhieuXuat.RowCount == 0)
                SetControlEnable_LoPhieuXuat(true);
            if (gridPhieuXuat.RowCount == 0)
                SetControlEnable_PhieuXuat(true);
        }
        private void FrmQuanLyXuatKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lpx_nhapluoi == 1 || lpx_nhaptay == 1 || lopx_nhapluoi == 1 || lopx_nhaptay == 1 || px_nhapluoi == 1 || px_nhaptay == 1)
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
                            LPXBLL.XoaLoaiPhieuXuat(gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString());
                            LayDanhSachLoaiPX();
                        }
                        break;
                    }
                case 2:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPXBLL.XoaLPX(gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].Value.ToString());
                            LayDanhSachLoPX();
                        }
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PXBLL.XoaPX(gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value.ToString(), gridPhieuXuat.CurrentRow.Cells["MHDB"].Value.ToString());
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
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
        private void FrmQuanLyXuatKho_KeyPress(object sender, KeyPressEventArgs e)
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
#region (Phần Loại Phiếu Xuất)

        LoaiPhieuXuatBLL LPXBLL=new LoaiPhieuXuatBLL();
        private void LayDanhSachLoaiPX()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPXBLL.LayDanhSachLoaiPhieuXuat();
            gridLoaiPhieuXuat.DataSource = bds;
            bindingLoaiPhieuXuat.BindingSource = bds;
            gridLoaiPhieuXuat.AllowUserToAddRows = false;
        }
        //Xử lý phần nhập lưới
        private int lpx_nhapluoi= 0;

        private void ToolBarEnableLoaiPhieuXuat(bool DangThaoTac = false)
        {
            LPX_Add.Enabled = DangThaoTac;
            LPX_Delete.Enabled = DangThaoTac;
            LPX_Cancel.Enabled = !DangThaoTac;
            LPX_Refresh.Enabled = DangThaoTac;
            LPX_Save.Enabled = !DangThaoTac;
        }
        private void LPX_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyXuatKho_Load(sender, e);
            ToolBarEnableLoaiPhieuXuat(true);
            lpx_nhapluoi = 0;
        }
        private void LPX_Add_Click_1(object sender, EventArgs e)
        {
            lpx_nhapluoi = 1;
            ToolBarEnableLoaiPhieuXuat(false);
            if (gridLoaiPhieuXuat.RowCount == 0)
            {
                gridLoaiPhieuXuat.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiPhieuXuat.AllowUserToAddRows = true;
                bindingLoaiPhieuXuat.BindingSource.MoveLast();
            }
        }
        private void LPX_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoaiPhieuXuat.RowCount == 0)
                LPX_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPXBLL.XoaLoaiPhieuXuat(gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString());
                LayDanhSachLoaiPX();
            }
        }
        private void LPX_Save_Click_1(object sender, EventArgs e)
        {
            switch (lpx_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuXuat.Focus();
                            LoaiPhieuXuat LPX = new LoaiPhieuXuat();
                            string maloaiphieuxuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString();
                            LPX.TenLoaiPhieuXuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value.ToString() : "";
                            LPX.NgayLap = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NL"].Value.ToString());
                            LPX.NguoiLap = (gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value.ToString() : "");
                            LPX.NgaySua = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NS"].Value.ToString());
                            LPX.NguoiSua = (gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value.ToString() : "");
                            LPXBLL.SuaLoaiPhieuXuat(maloaiphieuxuat, LPX);
                            LayDanhSachLoaiPX();
                            ToolBarEnableLoaiPhieuXuat(true);
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuXuat(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuXuat.Focus();
                            if (gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value == null ||gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                string maloaiphieuxuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString();
                                string tenloaiphieuxuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value.ToString();
                                DateTime ngaylap;
                                DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                                if (System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NL"].Value) != temp)
                                {
                                    ngaylap = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NL"].Value);
                                }
                                else
                                {
                                    ngaylap = DateTime.Now.Date;
                                }
                                DateTime ngaysua;
                                if (System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NS"].Value) != temp)
                                {
                                    ngaysua = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NS"].Value);
                                }
                                else
                                {
                                    ngaysua = DateTime.Now.Date;
                                }
                                string nguoilap = (gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value.ToString() : "");
                                string nguoisua = (gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value.ToString() : "");
                                LPXBLL.ThemLoaiPhieuXuat(maloaiphieuxuat, tenloaiphieuxuat, ngaylap, nguoilap, ngaysua, nguoisua);
                                LayDanhSachLoaiPX();
                                ToolBarEnableLoaiPhieuXuat(true);
                                lpx_nhapluoi = 0;
                            }
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuXuat(true);
                            lpx_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LPX_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lpx_nhapluoi = 0;
                LayDanhSachLoaiPX();
                ToolBarEnableLoaiPhieuXuat(true);
            }
            else
            {
                lpx_nhapluoi = 0;
                return;
            }
        }
        private void LPX_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridLoaiPhieuXuat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoaiPhieuXuat();
        }
        private void gridLoaiPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lpx_nhapluoi == 1)
                    gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].ReadOnly = false;
                else
                    gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].ReadOnly = true;
            }
        }
        //Code phần nhập tay
        private int lpx_nhaptay = 0;

        private void SetConTrolToNull_LoaiPhieuXuat()
        {
            txtMaLoaiPhieuXuat.Clear();
            txtTenLoaiPhieuXuat.Clear();
            LPX_dpNgayLap.Value = DateTime.Now;
            LPX_cmbNguoiLap.Text = "";
            LPX_dpNgaySua.Value = DateTime.Now;
            LPX_cmbNguoiSua.Text = "";
        }

        private void SetControlEnable_LoaiPhieuXuat(bool status)
        {
            btn_LPX_Sua.Enabled = status;
            btn_LPX_Them.Enabled = status;
            btn_LPX_Luu.Enabled = !status;
            btn_LPX_Huy.Enabled = !status;
            txtMaLoaiPhieuXuat.ReadOnly = status;
            txtTenLoaiPhieuXuat.ReadOnly = status;
            LPX_dpNgayLap.Enabled = !status;
            LPX_cmbNguoiLap.Enabled = !status;
            LPX_dpNgaySua.Enabled = !status;
            LPX_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiPhieuXuat(int dong)
        {
            if (gridLoaiPhieuXuat.RowCount > 0 && lpx_nhapluoi != 1)
            {
                txtMaLoaiPhieuXuat.Text = gridLoaiPhieuXuat.Rows[dong].Cells["ColMLPX"].Value.ToString();
                txtTenLoaiPhieuXuat.Text = gridLoaiPhieuXuat.Rows[dong].Cells["ColTLPX"].Value.ToString();
                LPX_dpNgayLap.Value = System.Convert.ToDateTime(gridLoaiPhieuXuat.Rows[dong].Cells["NL"].Value.ToString());
                LPX_cmbNguoiLap.Text = (gridLoaiPhieuXuat.Rows[dong].Cells["NgL"].Value == null ? "" : gridLoaiPhieuXuat.Rows[dong].Cells["NgL"].Value.ToString());
                LPX_dpNgaySua.Value = System.Convert.ToDateTime(gridLoaiPhieuXuat.Rows[dong].Cells["NS"].Value.ToString());
                LPX_cmbNguoiSua.Text = (gridLoaiPhieuXuat.Rows[dong].Cells["NgS"].Value == null ? "" : gridLoaiPhieuXuat.Rows[dong].Cells["NgS"].Value.ToString());
            }
        }
        private void gridLoaiPhieuXuat_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiPhieuXuat(e.RowIndex);
            SetControlEnable_LoaiPhieuXuat(true);
        }
        private void btn_LPX_Them_Click(object sender, EventArgs e)
        {
            lpx_nhaptay = 1;
            SetConTrolToNull_LoaiPhieuXuat();
            SetControlEnable_LoaiPhieuXuat(false);
        }
        private void btn_LPX_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoaiPhieuXuat(false);
            txtMaLoaiPhieuXuat.ReadOnly = true;
        }
        private void btn_LPX_Luu_Click(object sender, EventArgs e)
        {
            switch (lpx_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiPhieuXuat LPX = new LoaiPhieuXuat();
                            string maloaiphieuxuat = txtMaLoaiPhieuXuat.Text;
                            LPX.TenLoaiPhieuXuat = txtTenLoaiPhieuXuat.Text;
                            LPX.NgayLap = LPX_dpNgayLap.Value;
                            LPX.NguoiLap = LPX_cmbNguoiLap.SelectedValue.ToString();
                            LPX.NgaySua = LPX_dpNgaySua.Value;
                            LPX.NguoiSua = LPX_cmbNguoiSua.SelectedValue.ToString();
                            LPXBLL.SuaLoaiPhieuXuat(maloaiphieuxuat, LPX);
                            LayDanhSachLoaiPX();
                            SetControlEnable_LoaiPhieuXuat(true);
                        }
                        else
                        {
                            SetControlEnable_LoaiPhieuXuat(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (txtMaLoaiPhieuXuat.Text == "" || txtTenLoaiPhieuXuat.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuxuat = txtMaLoaiPhieuXuat.Text;
                            string tenloaiphieuxuat = txtTenLoaiPhieuXuat.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LPX_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LPX_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LPX_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LPX_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LPX_cmbNguoiLap.Text;
                            string nguoisua = LPX_cmbNguoiSua.Text;
                            LPXBLL.ThemLoaiPhieuXuat(maloaiphieuxuat, tenloaiphieuxuat, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPX();
                            lpx_nhaptay = 0;
                            SetControlEnable_LoaiPhieuXuat(true);
                        }
                        else
                        {
                            lpx_nhaptay = 0;
                            SetControlEnable_LoaiPhieuXuat(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LPX_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiPX();
                SetControlEnable_LoaiPhieuXuat(true);
                lpx_nhaptay = 0;
            }
            else
            {
                lpx_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Lô Phiếu Xuất)

        LoPhieuXuatBLL LoPXBLL = new LoPhieuXuatBLL();
        private void LayDanhSachLoPX()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoPXBLL.LayDanhSachLoPhieuXuat();
            bindingLoPhieuXuat.BindingSource = bds;
            gridLoPhieuXuat.DataSource = bds;
            gridLoPhieuXuat.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int lopx_nhapluoi = 0;

        private void ToolBarEnableLoPhieuXuat(bool DangThaoTac = false)
        {
            LoPX_Add.Enabled = DangThaoTac;
            LoPX_Delete.Enabled = DangThaoTac;
            LoPX_Cancel.Enabled = !DangThaoTac;
            LoPX_Refresh.Enabled = DangThaoTac;
            LoPX_Save.Enabled = !DangThaoTac;
        }
        private void LoPX_Refresh_Click(object sender, EventArgs e)
        {
            lopx_nhapluoi = 0;
            FrmQuanLyXuatKho_Load(sender, e);
            ToolBarEnableLoPhieuXuat(true);
            LayDanhSachLoPX();
        }
        private void LoPX_Add_Click_1(object sender, EventArgs e)
        {
            lopx_nhapluoi = 1;
            ToolBarEnableLoPhieuXuat(false);
            if (gridLoPhieuXuat.RowCount == 0)
            {
                gridLoPhieuXuat.AllowUserToAddRows = true;
            }
            else
            {
                gridLoPhieuXuat.AllowUserToAddRows = true;
                bindingLoPhieuXuat.BindingSource.MoveLast();
            }
        }
        private void LoPX_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoPhieuXuat.RowCount == 0)
                LoPX_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoPXBLL.XoaLPX(gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].Value.ToString());
                LayDanhSachLoPX();
            }
        }
        private void LoPX_Save_Click(object sender, EventArgs e)
        {
            switch (lopx_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuXuat.Focus();
                            LoPhieuXuat LoPX = new LoPhieuXuat();
                            string malohdban = gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].Value.ToString();
                            LoPX.NgayLoXuat = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["ColNLX"].Value.ToString());
                            LoPX.MoTa = (gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LoPX.NgayLap = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LoPX.NguoiLap = (gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LoPX.NgaySua = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LoPX.NguoiSua = (gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPXBLL.SuaLoPX(malohdban, LoPX);
                            LayDanhSachLoPX();
                            ToolBarEnableLoPhieuXuat(true);
                        }
                        else
                        {
                            ToolBarEnableLoPhieuXuat(true);
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
                            positionLoPhieuXuat.Focus();
                            if (gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].Value == null ||
                                System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["ColNLX"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdban = gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].Value.ToString();
                            DateTime ngayloxuat= System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["ColNLX"].Value);
                            string mota = (gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPXBLL.ThemLoPX(malohdban,ngayloxuat, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPX();
                            ToolBarEnableLoPhieuXuat(true);
                            lopx_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableLoPhieuXuat(true);
                            lopx_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoPX_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lopx_nhapluoi = 0;
                LayDanhSachLoPX();
                ToolBarEnableLoPhieuXuat(true);
            }
            else
            {
                lopx_nhapluoi = 0;
                return;
            }
        }
        private void LoPX_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoPhieuXuat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoPhieuXuat();
        }
        private void gridLoPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lopx_nhapluoi == 1)
                    gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].ReadOnly = false;
                else
                    gridLoPhieuXuat.CurrentRow.Cells["ColMLHDB"].ReadOnly = true;
            }
        }
        //Xử lý phần nhập tay
        private int lopx_nhaptay = 0;

        private void SetConTrolToNull_LoPhieuXuat()
        {
            cmbMaLoHDBan.Text = "";
            dpNgayLoXuat.Value = DateTime.Now;
            txtMoTa.Clear();
            LoPX_dpNgayLap.Value = DateTime.Now;
            LoPX_cmbNguoiLap.Text = "";
            LoPX_dpNgaySua.Value = DateTime.Now;
            LoPX_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_LoPhieuXuat(bool status)
        {
            btn_LoPX_Sua.Enabled = status;
            btn_LoPX_Them.Enabled = status;
            btn_LoPX_Luu.Enabled = !status;
            btn_LoPX_Huy.Enabled = !status;
            cmbMaLoHDBan.Enabled = !status;
            dpNgayLoXuat.Enabled = !status;
            txtMoTa.ReadOnly = status;
            LoPX_dpNgayLap.Enabled = !status;
            LoPX_cmbNguoiLap.Enabled = !status;
            LoPX_dpNgaySua.Enabled = !status;
            LoPX_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoPhieuXuat(int dong)
        {
            if (gridLoPhieuXuat.RowCount > 0 && lopx_nhapluoi != 1)
            {
                cmbMaLoHDBan.Text = gridLoPhieuXuat.Rows[dong].Cells["ColMLHDB"].Value.ToString();
                dpNgayLoXuat.Value = System.Convert.ToDateTime(gridLoPhieuXuat.Rows[dong].Cells["ColNLX"].Value.ToString());
                txtMoTa.Text = gridLoPhieuXuat.Rows[dong].Cells["ColMT"].Value.ToString();
                LoPX_dpNgayLap.Value = System.Convert.ToDateTime(gridLoPhieuXuat.Rows[dong].Cells["NgayLap"].Value.ToString());
                LoPX_cmbNguoiLap.Text = gridLoPhieuXuat.Rows[dong].Cells["NguoiLap"].Value.ToString();
                LoPX_dpNgaySua.Value = System.Convert.ToDateTime(gridLoPhieuXuat.Rows[dong].Cells["NgaySua"].Value.ToString());
                LoPX_cmbNguoiSua.Text = gridLoPhieuXuat.Rows[dong].Cells["NguoiSua"].Value.ToString();
            }
        }
        private void gridLoPhieuXuat_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoPhieuXuat(e.RowIndex);
            SetControlEnable_LoPhieuXuat(true);
        }
        private void btn_LoPX_Them_Click(object sender, EventArgs e)
        {
            lopx_nhaptay = 1;
            SetConTrolToNull_LoPhieuXuat();
            SetControlEnable_LoPhieuXuat(false);
        }
        private void btn_LoPX_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoPhieuXuat(false);
            cmbMaLoHDBan.Enabled = false;
        }
        private void btn_LoPX_Luu_Click(object sender, EventArgs e)
        {
            switch (lopx_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPhieuXuat LoPX = new LoPhieuXuat();
                            string malohdban = cmbMaLoHDBan.Text;
                            LoPX.NgayLoXuat = dpNgayLoXuat.Value;
                            LoPX.MoTa = txtMoTa.Text;
                            LoPX.NgayLap = LoPX_dpNgayLap.Value;
                            LoPX.NguoiLap = LoPX_cmbNguoiLap.Text;
                            LoPX.NgaySua = LoPX_dpNgaySua.Value;
                            LoPX.NguoiSua = LoPX_cmbNguoiSua.Text;
                            LoPXBLL.SuaLoPX(malohdban, LoPX);
                            LayDanhSachLoPX();
                            SetControlEnable_LoPhieuXuat(true);
                        }
                        else
                        {
                            SetControlEnable_LoPhieuXuat(true);
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
                            if (cmbMaLoHDBan.Text == "" || dpNgayLoXuat.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdban = cmbMaLoHDBan.Text;
                            DateTime ngayloxuat = LPX_dpNgayLap.Value;
                            string mota = txtMoTa.Text;
                            DateTime ngaylap;
                            if (LoPX_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LoPX_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LoPX_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LoPX_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LoPX_cmbNguoiLap.Text;
                            string nguoisua = LoPX_cmbNguoiSua.Text;
                            LoPXBLL.ThemLoPX(malohdban, ngayloxuat, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPX();
                            SetControlEnable_LoPhieuXuat(true);
                            lopx_nhaptay = 0;
                        }
                        else
                        {
                            lopx_nhaptay = 0;
                            SetControlEnable_LoPhieuXuat(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LoPX_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPX();
                SetControlEnable_LoPhieuXuat(true);
                lopx_nhaptay = 0;
            }
            else
            {
                lopx_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Phiếu xuất)
        PhieuXuatBLL PXBLL = new PhieuXuatBLL();  

        private void LoadMaLoaiPX()
        {
            //Combobox Column
            MLPX.DataSource = PXBLL.LayMaLoaiPhieuXuat();
            MLPX.DisplayMember = "TenLoaiPhieuXuat";
            MLPX.ValueMember = "MaLoaiPhieuXuat";
            //Combobox
            PX_cmbMLPX.DataSource = PXBLL.LayMaLoaiPhieuXuat();
            PX_cmbMLPX.DisplayMember = "TenLoaiPhieuXuat";
            PX_cmbMLPX.ValueMember = "MaLoaiPhieuXuat";
        }
        private void LoadMaHDBan()
        {
            MHDB.DataSource = PXBLL.LayMaHDBan(); ;
            MHDB.DisplayMember = "MaHDBan";
            MHDB.ValueMember = "MaHDBan";
        }
        private void LayDSPhieuXuatTheoLo(string malohdban)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PXBLL.LayDSPhieuXuat(malohdban);
            bindingPhieuXuat.BindingSource = bds;
            gridPhieuXuat.DataSource = bds;
            gridPhieuXuat.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int px_nhapluoi = 0;
        private void ToolBarEnablePhieuXuat(bool DangThaoTac = false)
        {
            PX_Add.Enabled = DangThaoTac;
            PX_Delete.Enabled = DangThaoTac;
            PX_Cancel.Enabled = !DangThaoTac;
            PX_Refresh.Enabled = DangThaoTac;
            PX_Save.Enabled = !DangThaoTac;
        }
        private void PX_Refresh_Click(object sender, EventArgs e)
        {
            px_nhapluoi = 0;
            FrmQuanLyXuatKho_Load(sender, e);
            ToolBarEnablePhieuXuat(true);
            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
        }
        private void PX_Add_Click(object sender, EventArgs e)
        {
            px_nhapluoi = 1;
            ToolBarEnablePhieuXuat(false);
            if (gridPhieuXuat.RowCount == 0)
            {
                gridPhieuXuat.AllowUserToAddRows = true;
            }
            else
            {
                gridPhieuXuat.AllowUserToAddRows = true;
                bindingPhieuXuat.BindingSource.MoveLast();
            }
            gridPhieuXuat.Rows[gridPhieuXuat.RowCount-1].Cells["MLHDB"].Value = xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
        }
        private void PX_Delete_Click(object sender, EventArgs e)
        {
            if (gridPhieuXuat.RowCount == 0)
                PX_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PXBLL.XoaPX(gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value.ToString(), gridPhieuXuat.CurrentRow.Cells["MHDB"].Value.ToString());
                LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
            }
        }
        private void PX_Save_Click(object sender, EventArgs e)
        {
            switch (px_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuXuat.Focus();
                            if (gridPhieuXuat.CurrentRow.Cells["MLPX"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            PhieuXuat PX = new PhieuXuat();
                            string malohdban = gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value.ToString();
                            string mahdban = gridPhieuXuat.CurrentRow.Cells["MHDB"].Value.ToString();
                            PX.MaLoaiPhieuXuat = gridPhieuXuat.CurrentRow.Cells["MLPX"].Value.ToString();
                            PX.MoTa = (gridPhieuXuat.CurrentRow.Cells["MT"].Value != null ? gridPhieuXuat.CurrentRow.Cells["MT"].Value.ToString() : "");
                            PX.NgayLap = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NL"].Value.ToString());
                            PX.NguoiLap = (gridPhieuXuat.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            PX.NgaySua = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NS"].Value.ToString());
                            PX.NguoiSua = (gridPhieuXuat.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PXBLL.SuaPX(malohdban, mahdban, PX);
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                            ToolBarEnablePhieuXuat(true);
                        }
                        else
                        {
                            ToolBarEnablePhieuXuat(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuXuat.Focus();
                            if (gridPhieuXuat.CurrentRow.Cells["MLPX"].Value == null || gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value == null || gridPhieuXuat.CurrentRow.Cells["MHDB"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuxuat = gridPhieuXuat.CurrentRow.Cells["MLPX"].Value.ToString();
                            string malohdban = gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value.ToString();
                            string mahdban = gridPhieuXuat.CurrentRow.Cells["MHDB"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            string mota = (gridPhieuXuat.CurrentRow.Cells["MT"].Value != null ? gridPhieuXuat.CurrentRow.Cells["MT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridPhieuXuat.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            string nguoisua = (gridPhieuXuat.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PXBLL.ThemPhieuXuat(maloaiphieuxuat, malohdban,mahdban,mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                            ToolBarEnablePhieuXuat(true);
                            px_nhapluoi = 0;
                        }
                        else
                        {
                            px_nhapluoi = 0;
                            ToolBarEnablePhieuXuat(true);
                            return;
                        }

                        break;
                    }
            }
        }
        private void PX_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                px_nhapluoi = 0;
                LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                ToolBarEnablePhieuXuat(true);
            }
            else
            {
                px_nhapluoi = 0;
                return;
            }
        }
        private void PX_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridPhieuXuat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnablePhieuXuat();
        }
        private void gridPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (px_nhapluoi == 1)
                {
                    gridPhieuXuat.CurrentRow.Cells["MLHDB"].ReadOnly = false;
                    gridPhieuXuat.CurrentRow.Cells["MHDB"].ReadOnly = false;
                }
                else
                {
                    gridPhieuXuat.CurrentRow.Cells["MLHDB"].ReadOnly = true;
                    gridPhieuXuat.CurrentRow.Cells["MHDB"].ReadOnly = true;
                }
                if (e.ColumnIndex>-1 && gridPhieuXuat.Columns[e.ColumnIndex].Name == "MLHDB")
                {
                    gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value = xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
                }
                if (px_nhapluoi == 0 && px_nhaptay == 0)
                {
                    //string name = gridPhieuXuat.Columns[e.ColumnIndex].Name;
                    if (e.ColumnIndex==-1)//name == "MHDB")
                    {
                        if (gridPhieuXuat.CurrentRow.Cells["MHDB"].Value != null)
                        {
                            FrmChiTietPhieuXuat CTPX = new FrmChiTietPhieuXuat();
                            CTPX.mahdban = gridPhieuXuat.CurrentRow.Cells["MHDB"].Value.ToString();
                            CTPX.malohdb = gridPhieuXuat.CurrentRow.Cells["MLHDB"].Value.ToString();//xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
                            CTPX.Show();
                        }
                        else
                            return;
                    }
                }
            }
        }
        //Xử lý phần nhập tay
        private int px_nhaptay = 0;

        private void SetConTrolToNull_PhieuXuat()
        {
            PX_cmbMLPX.Text = "";
            PX_cmbMLHDB.Text = "";
            PX_cmbMHDB.Text = "";
            PX_txtMT.Clear();
            PX_dpNgayLap.Value = DateTime.Now;
            PX_cmbNguoiLap.Text = "";
            PX_dpNgaySua.Value = DateTime.Now;
            PX_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_PhieuXuat(bool status)
        {
            btn_PX_Sua.Enabled = status;
            btn_PX_Them.Enabled = status;
            btn_PX_Luu.Enabled = !status;
            btn_PX_Huy.Enabled = !status;
            PX_cmbMLPX.Enabled = !status;
            PX_cmbMLHDB.Enabled = !status;
            PX_cmbMHDB.Enabled = !status;
            PX_txtMT.ReadOnly = status;
            PX_dpNgayLap.Enabled = !status;
            PX_cmbNguoiLap.Enabled = !status;
            PX_dpNgaySua.Enabled = !status;
            PX_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_PhieuXuat(int dong)
        {
            if (gridPhieuXuat.RowCount > 0 && px_nhapluoi != 1)
            {
                PX_cmbMLPX.SelectedValue = gridPhieuXuat.Rows[dong].Cells["MLPX"].Value.ToString();
                PX_cmbMLHDB.Text = gridPhieuXuat.Rows[dong].Cells["MLHDB"].Value.ToString();
                PX_cmbMHDB.Text = gridPhieuXuat.Rows[dong].Cells["MHDB"].Value.ToString();
                PX_txtMT.Text = gridPhieuXuat.Rows[dong].Cells["MT"].Value.ToString();
                PX_dpNgayLap.Value = System.Convert.ToDateTime(gridPhieuXuat.Rows[dong].Cells["_NL"].Value.ToString());
                PX_cmbNguoiLap.Text = gridPhieuXuat.Rows[dong].Cells["_NgL"].Value.ToString();
                PX_dpNgaySua.Value = System.Convert.ToDateTime(gridPhieuXuat.Rows[dong].Cells["_NS"].Value.ToString());
                PX_cmbNguoiSua.Text = gridPhieuXuat.Rows[dong].Cells["_NgS"].Value.ToString();
            }
        }
        private void gridPhieuXuat_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_PhieuXuat(e.RowIndex);
            SetControlEnable_PhieuXuat(true);
        }

        private void btn_PX_Them_Click(object sender, EventArgs e)
        {
            px_nhaptay = 1;
            SetConTrolToNull_PhieuXuat();
            SetControlEnable_PhieuXuat(false);
        }
        private void btn_PX_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_PhieuXuat(false);
            PX_cmbMLHDB.Enabled = false;
            PX_cmbMHDB.Enabled = false;
        }
        private void btn_PX_Luu_Click(object sender, EventArgs e)
        {
            switch (px_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PhieuXuat PX = new PhieuXuat();
                            string malohdban = PX_cmbMLHDB.SelectedValue.ToString();
                            string mahdb = PX_cmbMHDB.Text;
                            PX.MaLoaiPhieuXuat = PX_cmbMLPX.Text;
                            PX.MoTa = PX_txtMT.Text;
                            PX.NgayLap = PX_dpNgayLap.Value;
                            PX.NguoiLap = PX_cmbNguoiLap.Text;
                            PX.NgaySua = PX_dpNgaySua.Value;
                            PX.NguoiSua = PX_cmbNguoiSua.Text;
                            PXBLL.SuaPX(malohdban, mahdb, PX);
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                            SetControlEnable_PhieuXuat(true);
                        }
                        else
                        {
                            SetControlEnable_PhieuXuat(true);
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
                            if (PX_cmbMLPX.Text == "" || PX_cmbMLHDB.Text==""||PX_cmbMHDB.Text=="")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuxuat = PX_cmbMLPX.SelectedValue.ToString();
                            string malohdban = PX_cmbMLHDB.Text;
                            string mahdban = PX_cmbMHDB.Text;
                            string mota = PX_txtMT.Text;
                            DateTime ngaylap;
                            if (PX_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(PX_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (PX_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(PX_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = PX_cmbNguoiLap.Text;
                            string nguoisua = PX_cmbNguoiSua.Text;
                            PXBLL.ThemPhieuXuat(maloaiphieuxuat,malohdban,mahdban, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                            SetControlEnable_PhieuXuat(true);
                            px_nhaptay = 0;
                        }
                        else
                        {
                            px_nhaptay = 0;
                            SetControlEnable_PhieuXuat(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_PX_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                SetControlEnable_PhieuXuat(true);
                px_nhaptay = 0;
            }
            else
            {
                px_nhaptay = 0;
                return;
            }
        }
        private void PX_cmbMLHDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PX_cmbMHDB.Text = "";
            PX_cmbMHDB.DataSource = PXBLL.LayMaHDBanTheoLo(PX_cmbMLHDB.Text);
            PX_cmbMHDB.DisplayMember = "MaHDBan";
            PX_cmbMHDB.ValueMember = "MaHDBan";
        }
#endregion
   }
}