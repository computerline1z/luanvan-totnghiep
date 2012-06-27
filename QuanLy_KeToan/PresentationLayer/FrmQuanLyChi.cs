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
    public partial class FrmQuanLyChi : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyChi()
        {
            InitializeComponent();
        }
#region (Biến)
private int xoa = 0;
#endregion
#region (Xử lý TreeView)
    private void LoadTreeView()
    {
        foreach (var item in LoPCBLL.LayDanhSachMaLoChi())
        {
            DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
            foreach (DevComponents.AdvTree.Node n in advTreeLoChi.Nodes[0].Nodes)
            {
                if (n.Name == "nodeLoPhieuChi")
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
    private void advTreeLoChi_AfterNodeSelect_1(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
    {
        //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
        if (e.Node.Level == 0)
            return;
        //Node Loại phiếu chi
        if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
        {
            tabControlQuanLyChi.SelectedTabIndex = 0;
            AnHienGroup(groupLoaiPhieuChi, groupLoPhieuChi, groupPhieuChi);
            LayDanhSachLoaiPC();
            xoa = 1;
        }
        //Node Lô Phiếu chi
        else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
        {
            tabControlQuanLyChi.SelectedTabIndex = 1;
            AnHienGroup(groupLoPhieuChi, groupLoaiPhieuChi, groupPhieuChi);
            LayDanhSachLoPC();
            xoa = 2;
        }
        //Node Phiếu chi
        else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
        {
            tabControlQuanLyChi.SelectedTabIndex = 2;
            AnHienGroup(groupPhieuChi, groupLoPhieuChi, groupLoaiPhieuChi);
            string malohdmua = xuly_chuoi(e.Node.Text);
            LayDSPhieuChiTheoLo(malohdmua);
            bindingPhieuChi.Enabled = true;
            xoa = 3;
        }
    }
# endregion
#region (Hàm dùng chung)
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
            //Loại phiếu chi
            LPC_cmbNguoiLap.DataSource = LPCBLL.LayNguoiLap();
            LPC_cmbNguoiLap.ValueMember = "TenDangNhap";
            LPC_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LPC_cmbNguoiSua.DataSource = LPCBLL.LayNguoiLap();
            LPC_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LPC_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô phiếu chi
            comboNguoiLap.DataSource = LPCBLL.LayNguoiLap();
            comboNguoiLap.DisplayMember = "TenDangNhap";
            comboNguoiLap.ValueMember = "TenDangNhap";
            comboNguoiSua.DataSource = LPCBLL.LayNguoiLap();
            comboNguoiSua.DisplayMember = "TenDangNhap";
            comboNguoiSua.ValueMember = "TenDangNhap";
            //Phiếu chi
            PC_cmbNguoiLap.DataSource = LPCBLL.LayNguoiLap();
            PC_cmbNguoiLap.DisplayMember = "TenDangNhap";
            PC_cmbNguoiLap.ValueMember = "TenDangNhap";
            PC_cmbNguoiSua.DataSource = LPCBLL.LayNguoiLap();
            PC_cmbNguoiSua.DisplayMember = "TenDangNhap";
            PC_cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        private void LoadComboboxColumnNguoiLap()
        {
            //Loại phiếu chi
            ColNgL.DataSource = LPCBLL.LayNguoiLap();
            ColNgL.ValueMember = "TenDangNhap";
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgS.DataSource = LPCBLL.LayNguoiLap();
            ColNgS.ValueMember = "TenDangNhap";
            ColNgS.DisplayMember = "TenDangNhap";
            //Lô phiếu chi
            NguoiLap.DataSource = LPCBLL.LayNguoiLap();
            NguoiLap.ValueMember = "TenDangNhap";
            NguoiLap.DisplayMember = "TenDangNhap";
            NguoiSua.DataSource = LPCBLL.LayNguoiLap();
            NguoiSua.ValueMember = "TenDangNhap";
            NguoiSua.DisplayMember = "TenDangNhap";
            //Phiếu chi
            _NgL.DataSource = LPCBLL.LayNguoiLap();
            _NgL.ValueMember = "TenDangNhap";
            _NgL.DisplayMember = "TenDangNhap";
            _NgS.DataSource = LPCBLL.LayNguoiLap();
            _NgS.ValueMember = "TenDangNhap";
            _NgS.DisplayMember = "TenDangNhap";
        }
        private void LoadMaLoHDban()
        {
            //Lô Phiếu chi
            ColMLHDM.DataSource = LoPCBLL.LayMaLoHDMua();
            ColMLHDM.DisplayMember = "MaLoHDMua";
            ColMLHDM.ValueMember = "MaLoHDMua";

            cmbMaLoHDMua.DataSource = LoPCBLL.LayMaLoHDMua();
            cmbMaLoHDMua.DisplayMember = "MaLoHDMua";
            cmbMaLoHDMua.ValueMember = "MaLoHDMua";

            //Phiếu chi
            MLHDM.DataSource = PCBLL.LayLoHDMua();
            MLHDM.DisplayMember = "MaLoHDMua";
            MLHDM.ValueMember = "MaLoHDMua";

            PC_cmbMLHDM.DataSource = PCBLL.LayLoHDMua();
            PC_cmbMLHDM.DisplayMember = "MaLoHDMua";
            PC_cmbMLHDM.ValueMember = "MaLoHDMua";
        }
        //---Form Load----
        int truycap = 0;
        private void FrmQuanLyChi_Load(object sender, EventArgs e)
        {

            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            //Loại phiếu chi
            ToolBarEnableLoaiPhieuChi(true);
            SetControlEnable_LoaiPhieuChi(true);
            LayDanhSachLoaiPC();
            //Lô phiếu chi
            ToolBarEnableLoPhieuChi(true);
            SetControlEnable_LoPhieuChi(true);
            LoadMaLoHDban();
            LayDanhSachLoPC();
            //Phiếu chi
            ToolBarEnableLoPhieuChi(true);
            SetControlEnable_LoPhieuChi(true);
            LoadMaLoaiPC();
            LoadMaHDMua();
            if (gridPhieuChi.RowCount == 0)
            {
                bindingPhieuChi.Enabled = false;
            }
            //Kiểm tra lưới có rỗng không
            if (gridLoaiPhieuChi.RowCount == 0)
                SetControlEnable_LoaiPhieuChi(true);
            if (gridLoPhieuChi.RowCount == 0)
                SetControlEnable_LoPhieuChi(true);
            if (gridPhieuChi.RowCount == 0)
                SetControlEnable_PhieuChi(true);
        }
        private void FrmQuanLyChi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lpc_nhapluoi == 1 || lpc_nhaptay == 1 || lopc_nhapluoi == 1 || lopc_nhaptay == 1 || pc_nhapluoi == 1 || pc_nhaptay == 1)
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
                            LPCBLL.XoaLoaiPhieuChi(gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].Value.ToString());
                            LayDanhSachLoaiPC();
                        }
                        break;
                    }
                case 2:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPCBLL.XoaLPC(gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].Value.ToString());
                            LayDanhSachLoPC();
                        }
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PCBLL.XoaPC(gridPhieuChi.CurrentRow.Cells["MLHDM"].Value.ToString(), gridPhieuChi.CurrentRow.Cells["MHDM"].Value.ToString());
                            LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
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
        private void FrmQuanLyChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (MessageBox.Show("Thoát khỏi chương trình không?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (e.KeyChar == (char)Keys.Delete)
            {
                XoaGridByButton(xoa);
            }
        }
#endregion
#region (Code phần Loại phiếu chi)
        LoaiPhieuChiBLL LPCBLL = new LoaiPhieuChiBLL();
       
        private void LayDanhSachLoaiPC()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPCBLL.LayDanhSachLoaiPhieuChi();
            gridLoaiPhieuChi.DataSource = bds;
            bindingLoaiPhieuChi.BindingSource = bds;
            gridLoaiPhieuChi.AllowUserToAddRows = false;
        }
        //Nhập lưới
        private int lpc_nhapluoi = 0;

        private void ToolBarEnableLoaiPhieuChi(bool DangThaoTac=false)
        {
            LPC_Add.Enabled = DangThaoTac;
            LPC_Delete.Enabled = DangThaoTac;
            LPC_Cancel.Enabled = !DangThaoTac;
            LPC_Refresh.Enabled = DangThaoTac;
            LPC_Save.Enabled = !DangThaoTac;
        }
        private void tabItemLoaiPhieuChi_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupLoaiPhieuChi, groupLoPhieuChi, groupPhieuChi);
        }
        private void LPC_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyChi_Load(sender, e);
            ToolBarEnableLoaiPhieuChi(true);
            lpc_nhapluoi = 0;
        }
        private void LPC_Add_Click(object sender, EventArgs e)
        {
            lpc_nhapluoi = 1;
            ToolBarEnableLoaiPhieuChi(false);
            if (gridLoaiPhieuChi.RowCount == 0)
            {
                gridLoaiPhieuChi.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiPhieuChi.AllowUserToAddRows = true;
                bindingLoaiPhieuChi.BindingSource.MoveLast();
            }
        }
        private void LPC_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoaiPhieuChi.RowCount == 0)
                LPC_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPCBLL.XoaLoaiPhieuChi(gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].Value.ToString());
                LayDanhSachLoaiPC();
            }
        }
        private void LPC_Save_Click(object sender, EventArgs e)
        {
            ToolBarEnableLoaiPhieuChi(true);
            switch (lpc_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuChi.Focus();
                            LoaiPhieuChi LPC = new LoaiPhieuChi();
                            string maloaiphieuchi = gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].Value.ToString();
                            LPC.TenLoaiPhieuChi = gridLoaiPhieuChi.CurrentRow.Cells["ColTLPC"].Value != null ? gridLoaiPhieuChi.CurrentRow.Cells["ColTLPC"].Value.ToString() : "";
                            LPC.NgayLap = System.Convert.ToDateTime(gridLoaiPhieuChi.CurrentRow.Cells["ColNL"].Value.ToString());
                            LPC.NguoiLap = (gridLoaiPhieuChi.CurrentRow.Cells["ColNgL"].Value != null ? gridLoaiPhieuChi.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            LPC.NgaySua = System.Convert.ToDateTime(gridLoaiPhieuChi.CurrentRow.Cells["ColNS"].Value.ToString());
                            LPC.NguoiSua = (gridLoaiPhieuChi.CurrentRow.Cells["ColNgS"].Value != null ? gridLoaiPhieuChi.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            LPCBLL.SuaLoaiPhieuChi(maloaiphieuchi, LPC);
                            LayDanhSachLoaiPC();
                            ToolBarEnableLoaiPhieuChi(true);
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuChi(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuChi.Focus();
                            if (gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].Value == null || gridLoaiPhieuChi.CurrentRow.Cells["ColTLPC"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuchi = gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].Value.ToString();
                            string tenloaiphieuchi = gridLoaiPhieuChi.CurrentRow.Cells["ColTLPC"].Value.ToString();
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridLoaiPhieuChi.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoaiPhieuChi.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoaiPhieuChi.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoaiPhieuChi.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoaiPhieuChi.CurrentRow.Cells["ColNgL"].Value != null ? gridLoaiPhieuChi.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridLoaiPhieuChi.CurrentRow.Cells["ColNgS"].Value != null ? gridLoaiPhieuChi.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            LPCBLL.ThemLoaiPhieuChi(maloaiphieuchi, tenloaiphieuchi, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPC();
                            ToolBarEnableLoaiPhieuChi(true);
                            lpc_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuChi(true);
                            lpc_nhapluoi = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void LPC_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lpc_nhapluoi = 0;
                LayDanhSachLoaiPC();
                ToolBarEnableLoaiPhieuChi(true);
            }
            else
            {
                lpc_nhapluoi = 0;
                return;
            }
        }
        private void LPC_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoaiPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lpc_nhapluoi == 1)
                    gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].ReadOnly = false;
                else
                    gridLoaiPhieuChi.CurrentRow.Cells["ColMLPC"].ReadOnly = true;
            }
        }
        private void gridLoaiPhieuChi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoaiPhieuChi();
        }
        //Code phần nhập tay
        private int lpc_nhaptay = 0;
        
        private void SetConTrolToNull_LoaiPhieuChi()
        {
            LPC_txtMaLoaiPhieuChi.Text="";
            LPC_txtTenLoaiPhieuChi.Text = "" ;
            LPC_dpNgayLap.Value = DateTime.Now;
            LPC_cmbNguoiLap.Text = "";
            LPC_dpNgaySua.Value = DateTime.Now;
            LPC_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_LoaiPhieuChi(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            LPC_txtMaLoaiPhieuChi.Enabled = !status;
            LPC_txtTenLoaiPhieuChi.Enabled = !status;
            LPC_dpNgayLap.Enabled = !status;
            LPC_cmbNguoiLap.Enabled = !status;
            LPC_dpNgaySua.Enabled = !status;
            LPC_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiPhieuChi(int dong)
        {
            if (gridLoaiPhieuChi.RowCount > 0 && lpc_nhapluoi != 1)
            {
                LPC_txtMaLoaiPhieuChi.Text = gridLoaiPhieuChi.Rows[dong].Cells["ColMLPC"].Value.ToString();
                LPC_txtTenLoaiPhieuChi.Text = gridLoaiPhieuChi.Rows[dong].Cells["ColTLPC"].Value.ToString();
                LPC_dpNgayLap.Value = System.Convert.ToDateTime(gridLoaiPhieuChi.Rows[dong].Cells["ColNL"].Value.ToString());
                LPC_cmbNguoiLap.Text = gridLoaiPhieuChi.Rows[dong].Cells["ColNgL"].Value==null?"":gridLoaiPhieuChi.Rows[dong].Cells["ColNgL"].Value.ToString();
                LPC_dpNgaySua.Value = System.Convert.ToDateTime(gridLoaiPhieuChi.Rows[dong].Cells["ColNS"].Value.ToString());
                LPC_cmbNguoiSua.Text = gridLoaiPhieuChi.Rows[dong].Cells["ColNgS"].Value==null?"":gridLoaiPhieuChi.Rows[dong].Cells["ColNgS"].Value.ToString();
            }
        }
        private void gridLoaiPhieuChi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiPhieuChi(e.RowIndex);
            SetControlEnable_LoaiPhieuChi(true);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            lpc_nhaptay = 1;
            SetConTrolToNull_LoaiPhieuChi();
            SetControlEnable_LoaiPhieuChi(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoaiPhieuChi(false);
            LPC_txtMaLoaiPhieuChi.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (lpc_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiPhieuChi LPC = new LoaiPhieuChi();
                            string maloaiphieuchi = LPC_txtMaLoaiPhieuChi.Text;
                            LPC.TenLoaiPhieuChi = LPC_txtTenLoaiPhieuChi.Text;
                            LPC.NgayLap = LPC_dpNgayLap.Value;
                            LPC.NguoiLap = LPC_cmbNguoiLap.Text==""?"":LPC_cmbNguoiLap.SelectedValue.ToString();
                            LPC.NgaySua = LPC_dpNgaySua.Value;
                            LPC.NguoiSua = LPC_cmbNguoiSua.Text==""?"":LPC_cmbNguoiSua.SelectedValue.ToString();
                            LPCBLL.SuaLoaiPhieuChi(maloaiphieuchi, LPC);
                            LayDanhSachLoaiPC();
                            SetControlEnable_LoaiPhieuChi(true);
                        }
                        else
                        {
                            SetControlEnable_LoaiPhieuChi(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (LPC_txtMaLoaiPhieuChi.Text == "" || LPC_txtTenLoaiPhieuChi.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuchi = LPC_txtMaLoaiPhieuChi.Text;
                            string tenloaiphieuchi = LPC_txtTenLoaiPhieuChi.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LPC_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LPC_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LPC_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LPC_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LPC_cmbNguoiLap.Text == "" ? "" : LPC_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = LPC_cmbNguoiSua.Text == "" ? "" : LPC_cmbNguoiSua.SelectedValue.ToString();
                            LPCBLL.ThemLoaiPhieuChi(maloaiphieuchi, tenloaiphieuchi, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPC();
                            lpc_nhaptay = 0;
                            SetControlEnable_LoaiPhieuChi(true);
                        }
                        else
                        {
                            lpc_nhaptay = 0;
                            SetControlEnable_LoaiPhieuChi(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiPC();
                SetControlEnable_LoaiPhieuChi(true);
                lpc_nhaptay = 0;
            }
            else
            {
                lpc_nhaptay = 0;
                return;
            }
        }
# endregion
#region (Code phần Lô phiếu chi)

        LoPhieuChiBLL LoPCBLL = new LoPhieuChiBLL();

        private void LayDanhSachLoPC()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoPCBLL.LayDanhSachLoPhieuChi();
            bindingLoPhieuChi.BindingSource = bds;
            gridLoPhieuChi.DataSource = bds;
            gridLoPhieuChi.AllowUserToAddRows = false;
        }
        //Xử lý Nhập lưới
        int lopc_nhapluoi = 0;
        private void ToolBarEnableLoPhieuChi(bool DangThaoTac = false)
        {
            LoPC_Add.Enabled = DangThaoTac;
            LoPC_Delete.Enabled = DangThaoTac;
            LoPC_Cancel.Enabled = !DangThaoTac;
            LoPC_Refresh.Enabled = DangThaoTac;
            LoPC_Save.Enabled = !DangThaoTac;
        }
        private void tabItemLoPhieuChi_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupLoPhieuChi, groupLoaiPhieuChi, groupPhieuChi);
        }
        private void LoPC_Refresh_Click(object sender, EventArgs e)
        {
            lopc_nhapluoi = 0;
            FrmQuanLyChi_Load(sender, e);
            ToolBarEnableLoPhieuChi(true);
            LayDanhSachLoPC();
        }
        private void LoPC_Add_Click(object sender, EventArgs e)
        {
            lopc_nhapluoi = 1;
            ToolBarEnableLoPhieuChi(false);
            if (gridLoPhieuChi.RowCount == 0)
            {
                gridLoPhieuChi.AllowUserToAddRows = true;
            }
            else
            {
                gridLoPhieuChi.AllowUserToAddRows = true;
                bindingLoPhieuChi.BindingSource.MoveLast();
            }
        }
        private void LoPC_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoPhieuChi.RowCount == 0)
                LoPC_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoPCBLL.XoaLPC(gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].Value.ToString());
                LayDanhSachLoPC();
            }
        }
        private void LoPC_Save_Click(object sender, EventArgs e)
        {
            ToolBarEnableLoPhieuChi(true);
            switch (lopc_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuChi.Focus();
                            LoPhieuChi LPC = new LoPhieuChi();
                            string malohdmua = gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].Value.ToString();
                            LPC.NgayLoChi = System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["ColNLC"].Value.ToString());
                            LPC.MoTa = (gridLoPhieuChi.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuChi.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LPC.NgayLap = System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LPC.NguoiLap = (gridLoPhieuChi.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuChi.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LPC.NgaySua = System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LPC.NguoiSua = (gridLoPhieuChi.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuChi.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPCBLL.SuaLoPC(malohdmua, LPC);
                            LayDanhSachLoPC();
                            ToolBarEnableLoPhieuChi(true);
                        }
                        else
                        {
                            ToolBarEnableLoPhieuChi(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuChi.Focus();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].Value == null || System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["ColNLC"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].Value.ToString();
                            DateTime ngaylochi;
                            ngaylochi = System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["ColNLC"].Value);
                            string mota = (gridLoPhieuChi.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuChi.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoPhieuChi.CurrentRow.Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoPhieuChi.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuChi.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoPhieuChi.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuChi.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPCBLL.ThemLoPC(malohdmua, ngaylochi, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPC();
                            ToolBarEnableLoPhieuChi(true);
                            lopc_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableLoPhieuChi(true);
                            lopc_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void LoPC_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lopc_nhapluoi = 0;
                LayDanhSachLoPC();
                ToolBarEnableLoPhieuChi(true);
            }
            else
            {

                lopc_nhapluoi = 0;
                return;
            }
        }
        private void LoPC_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoPhieuChi_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoPhieuChi();
        }
        private void gridLoPhieuChi_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lopc_nhapluoi == 1)
                {
                    gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].ReadOnly = false;
                }
                else
                {
                    gridLoPhieuChi.CurrentRow.Cells["ColMLHDM"].ReadOnly = true;
                }
            }
        }
        //Xử lý phần nhập tay
        private int lopc_nhaptay = 0;

        private void SetConTrolToNull_LoPhieuChi()
        {
            cmbMaLoHDMua.Text = "";
            dpNgayChi.Value = DateTime.Now;
            txtMota.Text = "";
            dpNgayLap.Value = DateTime.Now;
            comboNguoiLap.Text = "";
            dpNgaySua.Value = DateTime.Now;
            comboNguoiSua.Text = "";
        }
        private void SetControlEnable_LoPhieuChi(bool status)
        {
            btn_LPC_Sua.Enabled = status;
            btn_LPC_Them.Enabled = status;
            btn_LPC_Luu.Enabled = !status;
            btn_LPC_Huy.Enabled = !status;
            cmbMaLoHDMua.Enabled = !status;
            dpNgayChi.Enabled = !status;
            txtMota.Enabled = !status;
            dpNgayLap.Enabled = !status;
            comboNguoiLap.Enabled = !status;
            dpNgaySua.Enabled = !status;
            comboNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoPhieuChi(int dong)
        {
            if (gridLoPhieuChi.RowCount > 0 && lopc_nhapluoi != 1)
            {
                cmbMaLoHDMua.Text = gridLoPhieuChi.Rows[dong].Cells["ColMLHDM"].Value.ToString();
                dpNgayChi.Value = System.Convert.ToDateTime(gridLoPhieuChi.Rows[dong].Cells["ColNLC"].Value.ToString());
                txtMota.Text = gridLoPhieuChi.Rows[dong].Cells["ColMT"].Value.ToString();
                dpNgayLap.Value = System.Convert.ToDateTime(gridLoPhieuChi.Rows[dong].Cells["NgayLap"].Value.ToString());
                comboNguoiLap.Text = gridLoPhieuChi.Rows[dong].Cells["NguoiLap"].Value==null?"":gridLoPhieuChi.Rows[dong].Cells["NguoiLap"].Value.ToString();
                dpNgaySua.Value = System.Convert.ToDateTime(gridLoPhieuChi.Rows[dong].Cells["NgaySua"].Value.ToString());
                comboNguoiSua.Text = gridLoPhieuChi.Rows[dong].Cells["NguoiSua"].Value==null?"":gridLoPhieuChi.Rows[dong].Cells["NguoiSua"].Value.ToString();
            }
        }
        private void gridLoPhieuChi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoPhieuChi(e.RowIndex);
            SetControlEnable_LoPhieuChi(true);
        }
        private void btn_LPC_Them_Click(object sender, EventArgs e)
        {
            lopc_nhaptay = 1;
            SetConTrolToNull_LoPhieuChi();
            SetControlEnable_LoPhieuChi(false);
        }
        private void btn_LPC_Sua_Click_1(object sender, EventArgs e)
        {
            SetControlEnable_LoPhieuChi(false);
            cmbMaLoHDMua.Enabled = false;
        }
        private void btn_LPC_Luu_Click(object sender, EventArgs e)
        {
            switch (lopc_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPhieuChi LoPC = new LoPhieuChi();
                            string malohdmua = cmbMaLoHDMua.Text;
                            LoPC.NgayLoChi = dpNgayChi.Value;
                            LoPC.MoTa = txtMota.Text;
                            LoPC.NgayLap = dpNgayLap.Value;
                            LoPC.NguoiLap = comboNguoiLap.Text==""?"":comboNguoiLap.SelectedValue.ToString();
                            LoPC.NgaySua = dpNgaySua.Value;
                            LoPC.NguoiSua = comboNguoiSua.Text == "" ? "" : comboNguoiSua.SelectedValue.ToString();
                            LoPCBLL.SuaLoPC(malohdmua, LoPC);
                            LayDanhSachLoPC();
                            SetControlEnable_LoPhieuChi(true);
                        }
                        else
                        {
                            SetControlEnable_LoPhieuChi(true);
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
                            if (cmbMaLoHDMua.Text == "" || dpNgayChi.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = cmbMaLoHDMua.Text;
                            DateTime ngaychi = dpNgayChi.Value;
                            string mota = txtMota.Text;
                            string tenloaiphieuchi = LPC_txtTenLoaiPhieuChi.Text;
                            DateTime ngaylap;
                            if (LPC_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LPC_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LPC_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LPC_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = comboNguoiLap.Text == "" ? "" : comboNguoiLap.SelectedValue.ToString();
                            string nguoisua = comboNguoiSua.Text == "" ? "" : comboNguoiSua.SelectedValue.ToString();
                            LoPCBLL.ThemLoPC(malohdmua, ngaychi, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPC();
                            SetControlEnable_LoPhieuChi(true);
                            lopc_nhaptay = 0;
                        }
                        else
                        {
                            lopc_nhaptay = 0;
                            SetControlEnable_LoPhieuChi(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_LPC_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPC();
                SetControlEnable_LoPhieuChi(true);
                lopc_nhaptay = 0;
            }
            else
            {
                lopc_nhaptay = 0;
                return;
            }
        }
#endregion
#region (Code phần Phiếu Chi)
        PhieuChiBLL PCBLL = new PhieuChiBLL();
        private void LoadMaHDMua()
        {
            MHDM.DataSource = PCBLL.LayMaHDMua(); ;
            MHDM.DisplayMember = "MaHDMua";
            MHDM.ValueMember = "MaHDMua";
        }
        private void LoadMaLoaiPC()
        {
            //Combobox Column
            MLPC.DataSource = PCBLL.LayMaLoaiPhieuChi();
            MLPC.DisplayMember = "TenLoaiPhieuChi";
            MLPC.ValueMember = "MaLoaiPhieuChi";
            //Combobox
            PC_cmbMLPC.DataSource = PCBLL.LayMaLoaiPhieuChi();
            PC_cmbMLPC.DisplayMember = "TenLoaiPhieuChi";
            PC_cmbMLPC.ValueMember = "MaLoaiPhieuChi";
        }
        private void tabItemNhapKho_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupPhieuChi, groupLoaiPhieuChi, groupLoPhieuChi);
        }
        private void LayDSPhieuChiTheoLo(string malo)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PCBLL.LayDSPhieuChi(malo);
            bindingPhieuChi.BindingSource = bds;
            gridPhieuChi.DataSource = bds;
            gridPhieuChi.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int pc_nhapluoi = 0;

        private void ToolBarEnablePhieuChi(bool DangThaoTac = false)
        {
            PC_Add.Enabled = DangThaoTac;
            PC_Delete.Enabled = DangThaoTac;
            PC_Cancel.Enabled = !DangThaoTac;
            PC_Refresh.Enabled = DangThaoTac;
            PC_Save.Enabled = !DangThaoTac;
        }
        private void PT_Refresh_Click(object sender, EventArgs e)
        {
            pc_nhapluoi = 0;
            FrmQuanLyChi_Load(sender, e);
            ToolBarEnablePhieuChi(true);
            LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
        }
        private void PT_Add_Click(object sender, EventArgs e)
        {
            pc_nhapluoi = 1;
            ToolBarEnablePhieuChi(false);
            if (gridPhieuChi.RowCount == 0)
            {
                gridPhieuChi.AllowUserToAddRows = true;
            }
            else
            {
                gridPhieuChi.AllowUserToAddRows = true;
                bindingPhieuChi.BindingSource.MoveLast();
            }
            gridPhieuChi.Rows[gridPhieuChi.RowCount - 1].Cells["MLHDM"].Value = xuly_chuoi(advTreeLoChi.SelectedNode.Text);
        }

        private void PT_Delete_Click(object sender, EventArgs e)
        {
            if (gridPhieuChi.RowCount == 0)
                PC_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PCBLL.XoaPC(gridPhieuChi.CurrentRow.Cells["MLHDM"].Value.ToString(), gridPhieuChi.CurrentRow.Cells["MHDM"].Value.ToString());
                LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
            }
        }
        private void PT_Save_Click(object sender, EventArgs e)
        {
            switch (pc_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuChi.Focus();
                            if (gridPhieuChi.CurrentRow.Cells["MLPC"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            PhieuChi PT = new PhieuChi();
                            string malohdmua = gridPhieuChi.CurrentRow.Cells["MLHDM"].Value.ToString();
                            string mahdmua = gridPhieuChi.CurrentRow.Cells["MHDM"].Value.ToString();
                            PT.MaLoaiPhieuChi = gridPhieuChi.CurrentRow.Cells["MLPC"].Value.ToString();
                            PT.MoTa = (gridPhieuChi.CurrentRow.Cells["MT"].Value != null ? gridPhieuChi.CurrentRow.Cells["MT"].Value.ToString() : "");
                            PT.NgayLap = System.Convert.ToDateTime(gridPhieuChi.CurrentRow.Cells["_NL"].Value.ToString());
                            PT.NguoiLap = (gridPhieuChi.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuChi.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            PT.NgaySua = System.Convert.ToDateTime(gridPhieuChi.CurrentRow.Cells["_NS"].Value.ToString());
                            PT.NguoiSua = (gridPhieuChi.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuChi.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PCBLL.SuaPC(malohdmua, mahdmua, PT);
                            LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
                            ToolBarEnablePhieuChi(true);
                        }
                        else
                        {
                            ToolBarEnablePhieuChi(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuChi.Focus();
                            if (gridPhieuChi.CurrentRow.Cells["MLPC"].Value == null || gridPhieuChi.CurrentRow.Cells["MLHDM"].Value == null || gridPhieuChi.CurrentRow.Cells["MHDM"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuchi = gridPhieuChi.CurrentRow.Cells["MLPC"].Value.ToString();
                            string malohdmua = gridPhieuChi.CurrentRow.Cells["MLHDM"].Value.ToString();
                            string mahdmua = gridPhieuChi.CurrentRow.Cells["MHDM"].Value.ToString();
                            string mota = (gridPhieuChi.CurrentRow.Cells["MT"].Value != null ? gridPhieuChi.CurrentRow.Cells["MT"].Value.ToString() : "");
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridPhieuChi.CurrentRow.Cells["_NL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridPhieuChi.CurrentRow.Cells["_NL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridPhieuChi.CurrentRow.Cells["_NS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridPhieuChi.CurrentRow.Cells["_NS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridPhieuChi.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuChi.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            string nguoisua = (gridPhieuChi.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuChi.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PCBLL.ThemPhieuChi(maloaiphieuchi,malohdmua,mahdmua,mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
                            ToolBarEnablePhieuChi(true);
                            pc_nhapluoi = 0;
                        }
                        else
                        {
                            pc_nhapluoi = 0;
                            ToolBarEnablePhieuChi(true);
                            return;
                        }

                        break;
                    }
            }
        }
        private void PT_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pc_nhapluoi = 0;
                LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
                ToolBarEnablePhieuChi(true);
            }
            else
            {
                pc_nhapluoi = 0;
                return;
            }
        }
        private void PT_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridPhieuChi_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnablePhieuChi();
        }
        private void gridPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (pc_nhapluoi == 1)
                {
                    gridPhieuChi.CurrentRow.Cells["MLHDM"].ReadOnly = false;
                    gridPhieuChi.CurrentRow.Cells["MHDM"].ReadOnly = false;
                }
                else
                {
                    gridPhieuChi.CurrentRow.Cells["MLHDM"].ReadOnly = true;
                    gridPhieuChi.CurrentRow.Cells["MHDM"].ReadOnly = true;
                }
                if (e.ColumnIndex > -1 && gridPhieuChi.Columns[e.ColumnIndex].Name == "MLHDM")
                {
                    gridPhieuChi.CurrentRow.Cells["MLHDM"].Value = xuly_chuoi(advTreeLoChi.SelectedNode.Text);
                }
                if (pc_nhapluoi == 0 && pc_nhaptay == 0)
                {
                    if (e.ColumnIndex == -1)
                    {
                        if (gridPhieuChi.CurrentRow.Cells["MHDM"].Value != null)
                        {
                            FrmChiTietPhieuChi CTPT = new FrmChiTietPhieuChi();
                            CTPT.mahdmua = gridPhieuChi.CurrentRow.Cells["MHDM"].Value.ToString();
                            CTPT.malohdmua = gridPhieuChi.CurrentRow.Cells["MLHDM"].Value.ToString();//xuly_chuoi(advTreeLoChi.SelectedNode.Text);
                            CTPT.Show();
                        }
                        else
                            return;
                    }
                }
            }
        }      
        //Xử lý phần nhập tay
        private int pc_nhaptay = 0;

        private void SetConTrolToNull_PhieuChi()
        {
            PC_cmbMLPC.Text = "";
            PC_cmbMLHDM.Text = "";
            PC_cmbMHDM.Text = "";
            PC_txtMT.Text="";
            PC_dpNgayLap.Value = DateTime.Now;
            PC_cmbNguoiLap.Text = "";
            PC_dpNgaySua.Value = DateTime.Now;
            PC_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_PhieuChi(bool status)
        {
            btn_PC_Sua.Enabled = status;
            btn_PC_Them.Enabled = status;
            btn_PC_Luu.Enabled = !status;
            btn_PC_Huy.Enabled = !status;
            PC_cmbMLPC.Enabled = !status;
            PC_cmbMLHDM.Enabled = !status;
            PC_cmbMHDM.Enabled = !status;
            PC_txtMT.Enabled = !status;
            PC_dpNgayLap.Enabled = !status;
            PC_cmbNguoiLap.Enabled = !status;
            PC_dpNgaySua.Enabled = !status;
            PC_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_PhieuChi(int dong)
        {
            if (gridPhieuChi.RowCount > 0 && pc_nhapluoi != 1)
            {
                PC_cmbMLPC.SelectedValue = gridPhieuChi.Rows[dong].Cells["MLPC"].Value.ToString();
                PC_cmbMLHDM.Text = gridPhieuChi.Rows[dong].Cells["MLHDM"].Value.ToString();
                PC_cmbMHDM.Text = gridPhieuChi.Rows[dong].Cells["MHDM"].Value.ToString();
                PC_txtMT.Text = gridPhieuChi.Rows[dong].Cells["MT"].Value.ToString();
                PC_dpNgayLap.Value = System.Convert.ToDateTime(gridPhieuChi.Rows[dong].Cells["_NL"].Value.ToString());
                PC_cmbNguoiLap.Text = gridPhieuChi.Rows[dong].Cells["_NgL"].Value==null?"":gridPhieuChi.Rows[dong].Cells["_NgL"].Value.ToString();
                PC_dpNgaySua.Value = System.Convert.ToDateTime(gridPhieuChi.Rows[dong].Cells["_NS"].Value.ToString());
                PC_cmbNguoiSua.Text = gridPhieuChi.Rows[dong].Cells["_NgS"].Value==null?"":gridPhieuChi.Rows[dong].Cells["_NgS"].Value.ToString();
            }
        }
        private void gridPhieuChi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_PhieuChi(e.RowIndex);
            SetControlEnable_PhieuChi(true);
        }

        private void btn_PT_Them_Click(object sender, EventArgs e)
        {
            pc_nhaptay = 1;
            SetConTrolToNull_PhieuChi();
            SetControlEnable_PhieuChi(false);
        }

        private void btn_PT_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_PhieuChi(false);
            PC_cmbMLHDM.Enabled = false;
            PC_cmbMHDM.Enabled = false;
        }
        private void btn_PT_Luu_Click(object sender, EventArgs e)
        {
            switch (pc_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PhieuChi PT = new PhieuChi();
                            string malohdmua = PC_cmbMLHDM.Text;
                            string mahdmua = PC_cmbMHDM.Text;
                            PT.MaLoaiPhieuChi = PC_cmbMLPC.SelectedValue.ToString();
                            PT.MoTa = PC_txtMT.Text;
                            PT.NgayLap = PC_dpNgayLap.Value;
                            PT.NguoiLap = PC_cmbNguoiLap.Text==""?"":PC_cmbNguoiLap.SelectedValue.ToString();
                            PT.NgaySua = PC_dpNgaySua.Value;
                            PT.NguoiSua = PC_cmbNguoiSua.Text==""?"":PC_cmbNguoiSua.SelectedValue.ToString();
                            PCBLL.SuaPC(malohdmua, mahdmua, PT);
                            LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
                            SetControlEnable_PhieuChi(true);
                        }
                        else
                        {
                            SetControlEnable_PhieuChi(true);
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
                            if (PC_cmbMLPC.Text == "" || PC_cmbMLHDM.Text == "" || PC_cmbMHDM.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuchi = PC_cmbMLPC.SelectedValue.ToString();
                            string malohdmua = PC_cmbMLHDM.Text;
                            string mahdmua = PC_cmbMHDM.Text;
                            string mota = PC_txtMT.Text;
                            DateTime ngaylap;
                            if (PC_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(PC_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (PC_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(PC_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = PC_cmbNguoiLap.Text == "" ? "" : PC_cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = PC_cmbNguoiSua.Text == "" ? "" : PC_cmbNguoiSua.SelectedValue.ToString();
                            PCBLL.ThemPhieuChi(maloaiphieuchi, malohdmua, mahdmua, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
                            SetControlEnable_PhieuChi(true);
                            pc_nhaptay = 0;
                        }
                        else
                        {
                            pc_nhaptay = 0;
                            SetControlEnable_PhieuChi(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void btn_PT_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSPhieuChiTheoLo(xuly_chuoi(advTreeLoChi.SelectedNode.Text));
                SetControlEnable_PhieuChi(true);
                pc_nhaptay = 0;
            }
            else
            {
                pc_nhaptay = 0;
                return;
            }
        }
        private void PC_cmbMLHDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            PC_cmbMHDM.Text = "";
            PC_cmbMHDM.DataSource = PCBLL.LayMaHDMuaTheoLo(PC_cmbMLHDM.Text);
            PC_cmbMHDM.DisplayMember = "MaHDMua";
            PC_cmbMHDM.ValueMember = "MaHDMua";
        }
#endregion                           
    }
}