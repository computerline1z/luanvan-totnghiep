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
    public partial class FrmQuanLyNhapKho : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyNhapKho()
        {
            InitializeComponent();
        }
#region (Biến)
        private int xoa = 0;
#endregion
#region (Xử lý TreeView)
        private void LoadTreeView()
        {
            foreach (var item in LoPNBLL.LayDanhSachMaLoHDMua())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                foreach (DevComponents.AdvTree.Node n in advTreeLoNhap.Nodes[0].Nodes)
                {
                    if (n.Name == "nodeLoPhieuNhap")
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
        private void advTreeLoNhap_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
            if (e.Node.Level == 0)
                return;
            //Node Loại phiếu Nhập
            if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoaiPhieuNhap.BringToFront();
                AnHienGroup(groupLoaiPhieuNhap,groupLoPhieuNhap,groupLoPhieuNhap);
                LayDanhSachLoaiPN();
                xoa=1;
            }
            //Node Lô Phiếu Nhập
            else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelLoPhieuNhap.BringToFront();
                AnHienGroup(groupLoPhieuNhap,groupLoaiPhieuNhap,groupLoaiPhieuNhap);
                LayDanhSachLoPN();
                xoa = 2;
            }
            //Node Phiếu Nhập
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                navigationPaneThaoTac.SendToBack();
                groupPanelPhieuNhap.BringToFront();
                AnHienGroup(groupPhieuPhap, groupLoPhieuNhap, groupLoaiPhieuNhap);
                string malohdmua = xuly_chuoi(e.Node.Text);
                LayDSPhieuNhapTheoLo(malohdmua);
                bindingPhieuNhap.Enabled = true;
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
            //Loại phiếu nhập
            LPN_cmbNguoiLap.DataSource = LPNBLL.LayNguoiLap();
            LPN_cmbNguoiLap.ValueMember = "TenDangNhap";
            LPN_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LPN_cmbNguoiSua.DataSource = LPNBLL.LayNguoiLap();
            LPN_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LPN_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô phiếu nhập
            LoPN_cmbNguoiLap.DataSource = LoPNBLL.LayNguoiLap();
            LoPN_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LoPN_cmbNguoiLap.ValueMember = "TenDangNhap";
            LoPN_cmbNguoiSua.DataSource = LoPNBLL.LayNguoiLap();
            LoPN_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LoPN_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Phiếu nhập
            PN_cmbNguoiLap.DataSource = PNBLL.LayNguoiLap();
            PN_cmbNguoiLap.DisplayMember = "TenDangNhap";
            PN_cmbNguoiLap.ValueMember = "TenDangNhap";
            PN_cmbNguoiSua.DataSource = PNBLL.LayNguoiLap();
            PN_cmbNguoiSua.DisplayMember = "TenDangNhap";
            PN_cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        //Hàm load các ComboboxColumn
        private void LoadComboboxColumnNguoiLap()
        {
            //Loại phiếu nhập
            NgL.DataSource = LPNBLL.LayNguoiLap();
            NgL.ValueMember = "TenDangNhap";
            NgL.DisplayMember = "TenDangNhap";
            NgS.DataSource = LPNBLL.LayNguoiLap();
            NgS.ValueMember = "TenDangNhap";
            NgS.DisplayMember = "TenDangNhap";
            //Lô Phiếu nhập
            NguoiLap.DataSource = LoPNBLL.LayNguoiLap();
            NguoiLap.ValueMember = "TenDangNhap";
            NguoiLap.DisplayMember = "TenDangNhap";
            NguoiSua.DataSource = LoPNBLL.LayNguoiLap();
            NguoiSua.ValueMember = "TenDangNhap";
            NguoiSua.DisplayMember = "TenDangNhap";
            //Phiếu nhập
            _NgL.DataSource = PNBLL.LayNguoiLap();
            _NgL.ValueMember = "TenDangNhap";
            _NgL.DisplayMember = "TenDangNhap";
            _NgS.DataSource = PNBLL.LayNguoiLap();
            _NgS.ValueMember = "TenDangNhap";
            _NgS.DisplayMember = "TenDangNhap";
        }
        private void LoadMaLoHDMua()
        {
            //Lô Phiếu nhập
            ColMLHDM.DataSource = LoPNBLL.LayMaLoHDMua();
            ColMLHDM.DisplayMember = "MaLoHDMua";
            ColMLHDM.ValueMember = "MaLoHDMua";

            cmbMaLoHDMua.DataSource = LoPNBLL.LayMaLoHDMua();
            cmbMaLoHDMua.DisplayMember = "MaLoHDMua";
            cmbMaLoHDMua.ValueMember = "MaLoHDMua";

            //Phiếu nhập
            MLHDM.DataSource = PNBLL.LayLoHDMua();
            MLHDM.DisplayMember = "MaLoHDMua";
            MLHDM.ValueMember = "MaLoHDMua";

            PN_cmbMLHDM.DataSource = PNBLL.LayLoHDMua();
            PN_cmbMLHDM.DisplayMember = "MaLoHDMua";
            PN_cmbMLHDM.ValueMember = "MaLoHDMua";
        }
        //----------------Form Load---------------------------------//
        int truycap = 0;
        private void FrmQuanLyKhoHang_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            LayDanhSachLoaiPN();
        }
        private void FrmQuanLyNhapKho_Load(object sender, EventArgs e)
        {
            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            //Loại phiếu nhập
            ToolBarEnableLoaiPhieuNhap(true);
            SetControlEnable_LoaiPhieuNhap(true);
            LayDanhSachLoaiPN();
            //Lô phiếu nhập
            ToolBarEnableLoPhieuNhap(true);
            SetControlEnable_LoPhieuNhap(true);
            LoadMaLoHDMua();
            LayDanhSachLoPN();
            //Phiếu nhập
            ToolBarEnablePhieuNhap(true);
            SetControlEnable_PhieuNhap(true);
            LoadMaLoaiPN();
            LoadMaHDMua();
            if (gridPhieuNhap.RowCount == 0)
            {
                bindingPhieuNhap.Enabled = false;
            }
        }
        private void FrmQuanLyNhapKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lpn_nhapluoi == 1 || lpn_nhaptay == 1 || lopn_nhapluoi == 1 || lopn_nhaptay == 1 || pn_nhapluoi == 1 || pn_nhaptay == 1)
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
                            LPNBLL.XoaLoaiPhieuNhap(gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].Value.ToString());
                            LayDanhSachLoaiPN();
                        }
                        break;
                    }
                case 2:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPNBLL.XoaLPN(gridLoPhieuNhap.CurrentRow.Cells["ColMLHDM"].Value.ToString());
                            LayDanhSachLoPN();
                        }
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PNBLL.XoaPN(gridPhieuNhap.CurrentRow.Cells["MLHDM"].Value.ToString(), gridPhieuNhap.CurrentRow.Cells["MHDM"].Value.ToString());
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
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
        private void FrmQuanLyNhapKho_KeyPress(object sender, KeyPressEventArgs e)
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
# region (Phần Loại Phiếu Nhập)
        LoaiPhieuNhapBLL LPNBLL = new LoaiPhieuNhapBLL();
        private void LayDanhSachLoaiPN()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPNBLL.LayDanhSachLoaiPhieuNhap();
            gridLoaiPhieuNhap.DataSource = bds;
            bindingLoaiPhieuNhap.BindingSource = bds;
            gridLoaiPhieuNhap.AllowUserToAddRows = false;
        }
        //Xử lý phần nhập lưới
        private int lpn_nhapluoi = 0;
        private void ToolBarEnableLoaiPhieuNhap(bool DangThaoTac = false)
        {
            LPN_Add.Enabled = DangThaoTac;
            LPN_Delete.Enabled = DangThaoTac;
            LPN_Cancel.Enabled = !DangThaoTac;
            LPN_Refresh.Enabled = DangThaoTac;
            LPN_Save.Enabled = !DangThaoTac;
        }
        private void LPN_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyNhapKho_Load(sender, e);
            ToolBarEnableLoaiPhieuNhap(true);
            lpn_nhapluoi = 0;
        }
        private void LPN_Add_Click(object sender, EventArgs e)
        {
            lpn_nhapluoi = 1;
            ToolBarEnableLoaiPhieuNhap(false);
            if (gridLoaiPhieuNhap.RowCount == 0)
            {
                gridLoaiPhieuNhap.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiPhieuNhap.AllowUserToAddRows = true;
                bindingLoaiPhieuNhap.BindingSource.MoveLast();
            }
            gridLoaiPhieuNhap.AllowUserToAddRows = true;
            bindingLoaiPhieuNhap.BindingSource.MoveLast();
        }
        private void LPN_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoaiPhieuNhap.RowCount == 0)
                LPN_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPNBLL.XoaLoaiPhieuNhap(gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].Value.ToString());
                LayDanhSachLoaiPN();
            }
        }
        private void LPN_Save_Click(object sender, EventArgs e)
        {
           switch (lpn_nhapluoi)
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
                           ToolBarEnableLoaiPhieuNhap(true);
                       }
                       else
                       {
                           ToolBarEnableLoaiPhieuNhap(true);
                           return;
                       }
                       break;
                   }
               case 1://Thêm
                   {
                       if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                       {
                           positionLoaiPhieuNhap.Focus();
                           if (gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].Value == null)
                           {
                               MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               return;
                           }
                           else
                           {
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
                               ToolBarEnableLoaiPhieuNhap(true);
                               lpn_nhapluoi = 0;
                           }
                       }
                       else
                       {
                           lpn_nhapluoi = 0;
                           ToolBarEnableLoaiPhieuNhap(true);
                           return;
                       }

                       break;
                   }
           }
        }
        private void LPN_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lpn_nhapluoi = 0;
                LayDanhSachLoaiPN();
                ToolBarEnableLoaiPhieuNhap(true);
            }
            else
            {
                lpn_nhapluoi = 0;
                return;
            }
        }
        private void LPN_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoaiPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lpn_nhapluoi == 1)
                    gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].ReadOnly = false;
                else
                    gridLoaiPhieuNhap.CurrentRow.Cells["ColMLPN"].ReadOnly = true;
            }
        }
        private void gridLoaiPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoaiPhieuNhap();
        }
        //Code phần nhập tay
        private int lpn_nhaptay = 0;
        private void SetConTrolToNull_LoaiPhieuNhap()
        {
            txtMaLoaiPhieuNhap.Clear();
            txtTenLoaiPhieuNhap.Clear();
            LPN_dpNgayLap.Value = DateTime.Now;
            LPN_cmbNguoiLap.Text = "";
            LPN_dpNgaySua.Value = DateTime.Now;
            LPN_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_LoaiPhieuNhap(bool status)
        {
            btn_LPN_Sua.Enabled = status;
            btn_LPN_Them.Enabled = status;
            btn_LPN_Luu.Enabled = !status;
            btn_LPN_Huy.Enabled = !status;
            txtMaLoaiPhieuNhap.ReadOnly = status;
            txtTenLoaiPhieuNhap.ReadOnly = status;
            LPN_dpNgayLap.Enabled = !status;
            LPN_cmbNguoiLap.Enabled = !status;
            LPN_dpNgaySua.Enabled = !status;
            LPN_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiPhieuNhap(int dong)
        {
            if (gridLoaiPhieuNhap.RowCount > 0 && lpn_nhapluoi != 1)
            {
                txtMaLoaiPhieuNhap.Text = gridLoaiPhieuNhap.Rows[dong].Cells["ColMLPN"].Value.ToString();
                txtTenLoaiPhieuNhap.Text = gridLoaiPhieuNhap.Rows[dong].Cells["ColTLPN"].Value.ToString();
                LPN_dpNgayLap.Value = System.Convert.ToDateTime(gridLoaiPhieuNhap.Rows[dong].Cells["NL"].Value.ToString());
                LPN_cmbNguoiLap.Text = (gridLoaiPhieuNhap.Rows[dong].Cells["NgL"].Value==null?"":gridLoaiPhieuNhap.Rows[dong].Cells["NgL"].Value.ToString());
                LPN_dpNgaySua.Value = System.Convert.ToDateTime(gridLoaiPhieuNhap.Rows[dong].Cells["NS"].Value.ToString());
                LPN_cmbNguoiSua.Text = (gridLoaiPhieuNhap.Rows[dong].Cells["NgS"].Value == null ? "" : gridLoaiPhieuNhap.Rows[dong].Cells["NgS"].Value.ToString());
            }
        }
        private void gridLoaiPhieuNhap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiPhieuNhap(e.RowIndex);
            SetControlEnable_LoaiPhieuNhap(true);
        }
        private void btn_LPN_Them_Click(object sender, EventArgs e)
        {
            lpn_nhaptay = 1;
            SetConTrolToNull_LoaiPhieuNhap();
            SetControlEnable_LoaiPhieuNhap(false);
        }
        private void btn_LPN_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoaiPhieuNhap(false);
            txtMaLoaiPhieuNhap.ReadOnly = true;
        }
        private void btn_LPN_Luu_Click(object sender, EventArgs e)
        {
            switch (lpn_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiPhieuNhap LPN = new LoaiPhieuNhap();
                            string maloaiphieunhap = txtMaLoaiPhieuNhap.Text;
                            LPN.TenLoaiPhieuNhap = txtTenLoaiPhieuNhap.Text;
                            LPN.NgayLap = LPN_dpNgayLap.Value;
                            LPN.NguoiLap = LPN_cmbNguoiLap.SelectedValue.ToString();
                            LPN.NgaySua = LPN_dpNgaySua.Value;
                            LPN.NguoiSua = LPN_cmbNguoiSua.SelectedValue.ToString();
                            LPNBLL.SuaLoaiPhieuNhap(maloaiphieunhap, LPN);
                            LayDanhSachLoaiPN();
                            SetControlEnable_LoaiPhieuNhap(true);
                        }
                        else
                        {
                            SetControlEnable_LoaiPhieuNhap(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (txtMaLoaiPhieuNhap.Text == "" || txtTenLoaiPhieuNhap.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieunhap = txtMaLoaiPhieuNhap.Text;
                            string tenloaiphieunhap = txtTenLoaiPhieuNhap.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LPN_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LPN_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LPN_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LPN_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LPN_cmbNguoiLap.Text;
                            string nguoisua = LPN_cmbNguoiSua.Text;
                            LPNBLL.ThemLoaiPhieuNhap(maloaiphieunhap, tenloaiphieunhap, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPN();
                            SetControlEnable_LoaiPhieuNhap(true);
                            lpn_nhaptay = 0;
                        }
                        else
                        {
                            lpn_nhaptay = 0;
                            SetControlEnable_LoaiPhieuNhap(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LPN_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiPN();
                SetControlEnable_LoaiPhieuNhap(true);
                lpn_nhaptay = 0;
            }
            else
            {
                lpn_nhaptay = 0;
                return;
            }
        }
#endregion
#region (phần Lô Phiếu Nhập)

        LoPhieuNhapBLL LoPNBLL = new LoPhieuNhapBLL();
        private void LayDanhSachLoPN()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoPNBLL.LayDanhSachLoPhieuNhap();
            bindingLoPhieuNhap.BindingSource = bds;
            gridLoPhieuNhap.DataSource = bds;
            gridLoPhieuNhap.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int lopn_nhapluoi = 0;

        private void ToolBarEnableLoPhieuNhap(bool DangThaoTac = false)
        {
            LoPN_Add.Enabled = DangThaoTac;
            LoPN_Delete.Enabled = DangThaoTac;
            LoPN_Cancel.Enabled = !DangThaoTac;
            LoPN_Refresh.Enabled = DangThaoTac;
            LoPN_Save.Enabled = !DangThaoTac;
        }
        private void LoPN_Refresh_Click(object sender, EventArgs e)
        {
            lopn_nhapluoi = 0;
            FrmQuanLyNhapKho_Load(sender, e);
            ToolBarEnableLoPhieuNhap(true);
            LayDanhSachLoPN();
        }        
        private void LoPN_Add_Click(object sender, EventArgs e)
        {
            lopn_nhapluoi = 1;
            ToolBarEnableLoPhieuNhap(false);
            if (gridLoPhieuNhap.RowCount == 0)
            {
                gridLoPhieuNhap.AllowUserToAddRows = true;
            }
            else
            {
                gridLoPhieuNhap.AllowUserToAddRows = true;
                bindingLoPhieuNhap.BindingSource.MoveLast();
            }
        }
        private void LoPN_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoPhieuNhap.RowCount == 0)
                LoPN_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoPNBLL.XoaLPN(gridLoPhieuNhap.CurrentRow.Cells["ColMLN"].Value.ToString());
                LayDanhSachLoPN();
            }
        }
        private void LoPN_Save_Click(object sender, EventArgs e)
        {
            switch (lopn_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuNhap.Focus();
                            LoPhieuNhap LPN = new LoPhieuNhap();
                            string malohdmua = gridLoPhieuNhap.CurrentRow.Cells["ColMLHDM"].Value.ToString();
                            LPN.NgayLoNhap = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["ColNLN"].Value.ToString());
                            LPN.MoTa = (gridLoPhieuNhap.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LPN.NgayLap = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LPN.NguoiLap = (gridLoPhieuNhap.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LPN.NgaySua = System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LPN.NguoiSua = (gridLoPhieuNhap.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuNhap.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPNBLL.SuaLoPN(malohdmua, LPN);
                            LayDanhSachLoPN();
                            ToolBarEnableLoPhieuNhap(true);
                        }
                        else
                        {
                            ToolBarEnableLoPhieuNhap(true);
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
                            positionLoPhieuNhap.Focus();
                            if (gridLoPhieuNhap.CurrentRow.Cells["ColMLHDM"].Value == null ||
                               System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["ColNLN"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = gridLoPhieuNhap.CurrentRow.Cells["ColMLHDM"].Value.ToString();
                            DateTime ngaylonhap=System.Convert.ToDateTime(gridLoPhieuNhap.CurrentRow.Cells["ColNLN"].Value);
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
                            LoPNBLL.ThemLoPN(malohdmua,ngaylonhap,mota,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPN();
                            lopn_nhapluoi = 0;
                        }
                        else
                        {
                            lopn_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoPN_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lopn_nhapluoi = 0;
                LayDanhSachLoPN();
                ToolBarEnableLoPhieuNhap(true);
            }
            else
            {
                lopn_nhapluoi = 0;
                return;
            }
        }
        private void LoPN_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoPhieuNhap();
        }

        private void gridLoPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lopn_nhapluoi == 1)
                    gridLoPhieuNhap.CurrentRow.Cells["ColMLHDM"].ReadOnly = false;
                else
                    gridLoPhieuNhap.CurrentRow.Cells["ColMLHDM"].ReadOnly = true;
            }
        }
        //Xử lý phần nhập tay
        private int lopn_nhaptay = 0;

        private void SetConTrolToNull_LoPhieuNhap()
        {
            cmbMaLoHDMua.Text = "";
            dpNgayLoNhap.Value = DateTime.Now;
            txtMoTa.Clear();
            LoPN_dpNgayLap.Value = DateTime.Now;
            LoPN_cmbNguoiLap.Text = "";
            LoPN_dpNgaySua.Value = DateTime.Now;
            LoPN_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_LoPhieuNhap(bool status)
        {
            btn_LoPN_Sua.Enabled = status;
            btn_LoPN_Them.Enabled = status;
            btn_LoPN_Luu.Enabled = !status;
            btn_LoPN_Huy.Enabled = !status;
            cmbMaLoHDMua.Enabled = !status;
            dpNgayLoNhap.Enabled = !status;
            txtMoTa.ReadOnly = status;
            LoPN_dpNgayLap.Enabled = !status;
            LoPN_cmbNguoiLap.Enabled = !status;
            LoPN_dpNgaySua.Enabled = !status;
            LoPN_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoPhieuNhap(int dong)
        {
            if (gridLoPhieuNhap.RowCount > 0 && lopn_nhapluoi != 1)
            {
                cmbMaLoHDMua.Text = gridLoPhieuNhap.Rows[dong].Cells["ColMLHDM"].Value.ToString();
                dpNgayLoNhap.Value = System.Convert.ToDateTime(gridLoPhieuNhap.Rows[dong].Cells["ColNLN"].Value.ToString());
                txtMoTa.Text = gridLoPhieuNhap.Rows[dong].Cells["ColMT"].Value.ToString();
                LoPN_dpNgayLap.Value = System.Convert.ToDateTime(gridLoPhieuNhap.Rows[dong].Cells["NgayLap"].Value.ToString());
                LoPN_cmbNguoiLap.Text = (gridLoPhieuNhap.Rows[dong].Cells["NguoiLap"].Value == null ? "" : gridLoPhieuNhap.Rows[dong].Cells["NguoiLap"].Value.ToString());
                LoPN_dpNgaySua.Value = System.Convert.ToDateTime(gridLoPhieuNhap.Rows[dong].Cells["NgaySua"].Value.ToString());
                LoPN_cmbNguoiSua.Text = (gridLoPhieuNhap.Rows[dong].Cells["NguoiSua"].Value == null ? "" : gridLoPhieuNhap.Rows[dong].Cells["NguoiSua"].Value.ToString());
            }
        }
        private void gridLoPhieuNhap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoPhieuNhap(e.RowIndex);
            SetControlEnable_LoPhieuNhap(true);
        }
        private void btn_LoPN_Them_Click(object sender, EventArgs e)
        {
            lopn_nhaptay = 1;
            SetConTrolToNull_LoPhieuNhap();
            SetControlEnable_LoPhieuNhap(false);
        }
        private void btn_LoPN_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoPhieuNhap(false);
            cmbMaLoHDMua.Enabled = false;
        }
        private void btn_LoPN_Luu_Click(object sender, EventArgs e)
        {
            switch (lopn_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPhieuNhap LoPN = new LoPhieuNhap();
                            string malohdmua = cmbMaLoHDMua.Text;
                            LoPN.NgayLoNhap = dpNgayLoNhap.Value;
                            LoPN.MoTa = txtMoTa.Text;
                            LoPN.NgayLap = LoPN_dpNgayLap.Value;
                            LoPN.NguoiLap = LoPN_cmbNguoiLap.Text;
                            LoPN.NgaySua = LoPN_dpNgaySua.Value;
                            LoPN.NguoiSua = LoPN_cmbNguoiSua.Text;
                            LoPNBLL.SuaLoPN(malohdmua, LoPN);
                            LayDanhSachLoPN();
                            SetControlEnable_LoPhieuNhap(true);
                        }
                        else
                        {
                            SetControlEnable_LoPhieuNhap(true);
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
                            if (cmbMaLoHDMua.Text == "" || dpNgayLoNhap.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = cmbMaLoHDMua.Text;
                            DateTime ngaylonhap = System.Convert.ToDateTime(LPN_dpNgayLap.Value);
                            string mota = txtMoTa.Text;
                            DateTime ngaylap;
                            if (LoPN_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LoPN_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LoPN_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LoPN_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LoPN_cmbNguoiLap.Text;
                            string nguoisua = LoPN_cmbNguoiSua.Text;
                            LoPNBLL.ThemLoPN(malohdmua, ngaylonhap, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPN();
                            SetControlEnable_LoPhieuNhap(true);
                            lopn_nhaptay = 0;
                        }
                        else
                        {
                            lopn_nhaptay = 0;
                            SetControlEnable_LoPhieuNhap(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LoPN_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPN();
                SetControlEnable_LoPhieuNhap(true);
                lopn_nhaptay = 0;
            }
            else
            {
                lopn_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Phần xử lý Phiếu Nhập)
        PhieuNhapBLL PNBLL = new PhieuNhapBLL();

        private void LoadMaLoaiPN()
        {
            //Combobox Column
            MLPN.DataSource = PNBLL.LayMaLoaiPhieuNhap();
            MLPN.DisplayMember = "TenLoaiPhieuNhap";
            MLPN.ValueMember = "MaLoaiPhieuNhap";
            //Combobox
            PN_cmbMLPN.DataSource = PNBLL.LayMaLoaiPhieuNhap();
            PN_cmbMLPN.DisplayMember = "TenLoaiPhieuNhap";
            PN_cmbMLPN.ValueMember = "MaLoaiPhieuNhap";
        }
        private void LoadMaHDMua()
        {
            MHDM.DataSource = PNBLL.LayMaHDMua(); ;
            MHDM.DisplayMember = "MaHDMua";
            MHDM.ValueMember = "MaHDMua";
        }
        private void LayDSPhieuNhapTheoLo(string malohdmua)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PNBLL.LayDSPhieuNhap(malohdmua);
            bindingPhieuNhap.BindingSource = bds;
            gridPhieuNhap.DataSource = bds;
            gridPhieuNhap.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int pn_nhapluoi = 0;
        private void ToolBarEnablePhieuNhap(bool DangThaoTac = false)
        {
            PN_Add.Enabled = DangThaoTac;
            PN_Delete.Enabled = DangThaoTac;
            PN_Cancel.Enabled = !DangThaoTac;
            PN_Refresh.Enabled = DangThaoTac;
            PN_Save.Enabled = !DangThaoTac;
        }
        private void PN_Refresh_Click(object sender, EventArgs e)
        {
            pn_nhapluoi = 0;
            FrmQuanLyNhapKho_Load(sender, e);
            ToolBarEnablePhieuNhap(true);
            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
        }
        private void PN_Add_Click(object sender, EventArgs e)
        {
            pn_nhapluoi = 1;
            ToolBarEnablePhieuNhap(false);
            if (gridPhieuNhap.RowCount == 0)
            {
                gridPhieuNhap.AllowUserToAddRows = true;
            }
            else
            {
                gridPhieuNhap.AllowUserToAddRows = true;
                bindingPhieuNhap.BindingSource.MoveLast();
            }
            gridPhieuNhap.Rows[gridPhieuNhap.RowCount - 1].Cells["MLHDM"].Value = xuly_chuoi(advTreeLoNhap.SelectedNode.Text);
        }

        private void PN_Delete_Click(object sender, EventArgs e)
        {
            if (gridPhieuNhap.RowCount == 0)
                PN_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string malohdmua = gridPhieuNhap.CurrentRow.Cells["MLHDM"].Value.ToString();
                string mahdmua = gridPhieuNhap.CurrentRow.Cells["MHDM"].Value.ToString();
                PNBLL.XoaPN(malohdmua,mahdmua);
                LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
            }
        }

        private void PN_Save_Click(object sender, EventArgs e)
        {
            switch (pn_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuNhap.Focus();
                            if (gridPhieuNhap.CurrentRow.Cells["MLPN"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            PhieuNhap PN = new PhieuNhap();
                            string malohdmua = gridPhieuNhap.CurrentRow.Cells["MLHDM"].Value.ToString();
                            string mahdmua = gridPhieuNhap.CurrentRow.Cells["MHDM"].Value.ToString();
                            PN.MaLoaiPhieuNhap = gridPhieuNhap.CurrentRow.Cells["MLPN"].Value.ToString();
                            PN.MoTa = (gridPhieuNhap.CurrentRow.Cells["MT"].Value != null ? gridPhieuNhap.CurrentRow.Cells["MT"].Value.ToString() : "");
                            PN.NgayLap = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NL"].Value.ToString());
                            PN.NguoiLap = (gridPhieuNhap.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuNhap.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            PN.NgaySua = System.Convert.ToDateTime(gridPhieuNhap.CurrentRow.Cells["_NS"].Value.ToString());
                            PN.NguoiSua = (gridPhieuNhap.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuNhap.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PNBLL.SuaPN(malohdmua, mahdmua, PN);
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                            ToolBarEnableLoaiPhieuNhap(true);
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuNhap(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuNhap.Focus();
                            if (gridPhieuNhap.CurrentRow.Cells["MLPN"].Value == null || gridPhieuNhap.CurrentRow.Cells["MLHDM"].Value == null || gridPhieuNhap.CurrentRow.Cells["MHDM"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieunhap = gridPhieuNhap.CurrentRow.Cells["MLPN"].Value.ToString();
                            string malohdmua = gridPhieuNhap.CurrentRow.Cells["MLHDM"].Value.ToString();
                            string mahdmua = gridPhieuNhap.CurrentRow.Cells["MHDM"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
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
                            PNBLL.ThemPhieuNhap(maloaiphieunhap,malohdmua,mahdmua,mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                            ToolBarEnableLoaiPhieuNhap(true);
                            pn_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuNhap(true);
                            pn_nhapluoi = 0;
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
                pn_nhapluoi = 0;
                LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                ToolBarEnablePhieuNhap(true);
            }
            else
            {
                pn_nhapluoi = 0;
                return;
            }
        }
        private void PN_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnablePhieuNhap();
        }
        private void gridPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (pn_nhapluoi == 1)
                {
                    gridPhieuNhap.CurrentRow.Cells["MLPN"].ReadOnly = false;
                    gridPhieuNhap.CurrentRow.Cells["MLHDM"].ReadOnly = false;
                    gridPhieuNhap.CurrentRow.Cells["MHDM"].ReadOnly = false;
                }
                else
                {
                    gridPhieuNhap.CurrentRow.Cells["MLPN"].ReadOnly = true;
                    gridPhieuNhap.CurrentRow.Cells["MLHDM"].ReadOnly = true;
                    gridPhieuNhap.CurrentRow.Cells["MHDM"].ReadOnly = true;
                }
                if (gridPhieuNhap.Columns[e.ColumnIndex].Name == "MLHDM")
                {
                    gridPhieuNhap.CurrentRow.Cells["MLHDM"].Value = xuly_chuoi(advTreeLoNhap.SelectedNode.Text);
                }
                if (pn_nhapluoi == 0 && pn_nhaptay == 0)
                {
                    string name = gridPhieuNhap.Columns[e.ColumnIndex].Name;
                    if (name == "MHDM")
                    {
                        if (gridPhieuNhap.CurrentRow.Cells["MHDM"].Value != null)
                        {
                            FrmChiTietPhieuNhap CTPN = new FrmChiTietPhieuNhap();
                            CTPN.mahdmua = gridPhieuNhap.CurrentRow.Cells["MHDM"].Value.ToString();
                            CTPN.malohdmua = xuly_chuoi(advTreeLoNhap.SelectedNode.Text);
                            CTPN.Show();
                        }
                        else
                            return;
                    }
                }
            }
        }
        //Xử lý phần nhập tay
        private int pn_nhaptay = 0;

        private void SetConTrolToNull_PhieuNhap()
        {
            PN_cmbMLPN.Text = "";
            PN_cmbMLHDM.Text = "";
            PN_cmbMHDM.Text = "";
            PN_txtMT.Clear();
            PN_dpNgayLap.Value = DateTime.Now;
            PN_cmbNguoiLap.Text = "";
            PN_dpNgaySua.Value = DateTime.Now;
            PN_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_PhieuNhap(bool status)
        {
            btn_PN_Sua.Enabled = status;
            btn_PN_Them.Enabled = status;
            btn_PN_Luu.Enabled = !status;
            btn_PN_Huy.Enabled = !status;
            PN_cmbMLPN.Enabled = !status;
            PN_cmbMLHDM.Enabled = !status;
            PN_cmbMHDM.Enabled = !status;
            PN_txtMT.ReadOnly = status;
            PN_dpNgayLap.Enabled = !status;
            PN_cmbNguoiLap.Enabled = !status;
            PN_dpNgaySua.Enabled = !status;
            PN_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_PhieuNhap(int dong)
        {
            if (gridPhieuNhap.RowCount > 0 && pn_nhapluoi != 1)
            {
                PN_cmbMLPN.Text = gridPhieuNhap.Rows[dong].Cells["MLPN"].Value.ToString();
                PN_cmbMLHDM.Text = gridPhieuNhap.Rows[dong].Cells["MLHDM"].Value.ToString();
                PN_cmbMHDM.Text = gridPhieuNhap.Rows[dong].Cells["MHDM"].Value.ToString();
                PN_txtMT.Text = gridPhieuNhap.Rows[dong].Cells["MT"].Value.ToString();
                PN_dpNgayLap.Value = System.Convert.ToDateTime(gridPhieuNhap.Rows[dong].Cells["_NL"].Value.ToString());
                PN_cmbNguoiLap.Text = gridPhieuNhap.Rows[dong].Cells["_NgL"].Value.ToString();
                PN_dpNgaySua.Value = System.Convert.ToDateTime(gridPhieuNhap.Rows[dong].Cells["_NS"].Value.ToString());
                PN_cmbNguoiSua.Text = gridPhieuNhap.Rows[dong].Cells["_NgS"].Value.ToString();
            }
        }

        private void gridPhieuNhap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_PhieuNhap(e.RowIndex);
            SetControlEnable_PhieuNhap(true);
        }

        private void btn_PN_Them_Click(object sender, EventArgs e)
        {
            pn_nhaptay = 1;
            SetConTrolToNull_PhieuNhap();
            SetControlEnable_PhieuNhap(false);
        }
        private void btn_PN_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_PhieuNhap(false);
            PN_cmbMLHDM.Enabled = false;
            PN_cmbMHDM.Enabled = false;
        }

        private void btn_PN_Luu_Click(object sender, EventArgs e)
        {
            switch (pn_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PhieuNhap PN = new PhieuNhap();
                            string malohdban = PN_cmbMLHDM.Text;
                            string mahdb = PN_cmbMHDM.Text;
                            PN.MaLoaiPhieuNhap = PN_cmbMLPN.Text;
                            PN.MoTa = PN_txtMT.Text;
                            PN.NgayLap = PN_dpNgayLap.Value;
                            PN.NguoiLap = PN_cmbNguoiLap.Text;
                            PN.NgaySua = PN_dpNgaySua.Value;
                            PN.NguoiSua = PN_cmbNguoiSua.Text;
                            PNBLL.SuaPN(malohdban, mahdb, PN);
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                            SetControlEnable_PhieuNhap(true);
                        }
                        else
                        {
                            SetControlEnable_PhieuNhap(true);
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
                            if (PN_cmbMLPN.Text == "" || PN_cmbMLHDM.Text == "" || PN_cmbMHDM.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuxuat = PN_cmbMLPN.Text;
                            string malohdban = PN_cmbMLHDM.Text;
                            string mahdban = PN_cmbMHDM.Text;
                            string mota = PN_txtMT.Text;
                            DateTime ngaylap;
                            if (PN_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(PN_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (PN_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(PN_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = PN_cmbNguoiLap.Text;
                            string nguoisua = PN_cmbNguoiSua.Text;
                            PNBLL.ThemPhieuNhap(maloaiphieuxuat, malohdban, mahdban, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                            SetControlEnable_PhieuNhap(true);
                            pn_nhaptay = 0;
                        }
                        else
                        {
                            pn_nhaptay = 0;
                            SetControlEnable_PhieuNhap(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_PN_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSPhieuNhapTheoLo(xuly_chuoi(advTreeLoNhap.SelectedNode.Text));
                SetControlEnable_PhieuNhap(true);
                pn_nhaptay = 0;
            }
            else
            {
                pn_nhaptay = 0;
                return;
            }
        }

        private void PN_cmbMLHDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            PN_cmbMHDM.Text = "";
            PN_cmbMHDM.DataSource = PNBLL.LayMaHDMuaTheoLo(PN_cmbMLHDM.Text);
            PN_cmbMHDM.DisplayMember = "MaHDMua";
            PN_cmbMHDM.ValueMember = "MaHDMua";
        }
#endregion
    }
}