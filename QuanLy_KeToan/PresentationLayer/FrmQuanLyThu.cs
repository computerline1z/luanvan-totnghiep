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
    public partial class FrmQuanLyThu : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyThu()
        {
            InitializeComponent();
        }
#region (Biến)
private int xoa = 0;
#endregion
#region (Xử lý TreeView)
    private void LoadTreeView()
    {
        foreach (var item in LoPTBLL.LayDanhSachMaLoThu())
        {
            DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
            foreach (DevComponents.AdvTree.Node n in advTreeLoThu.Nodes[0].Nodes)
            {
                if (n.Name == "nodeLoPhieuThu")
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
    private void advTreeLoThu_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
    {
        //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
        if (e.Node.Level == 0)
            return;
        //Node Loại phiếu thu
        if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
        {
            tabControlNhapKho.SelectedTabIndex = 0;
            AnHienGroup(groupLoaiPhieuThu, groupLoPhieuThu, groupPhieuThu);
            LayDanhSachLoaiPT();
            xoa = 1;
        }
        //Node Lô Phiếu thu
        else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
        {
            tabControlNhapKho.SelectedTabIndex = 1;
            AnHienGroup(groupLoPhieuThu, groupLoaiPhieuThu, groupPhieuThu);
            LayDanhSachLoPT();
            xoa = 2;
        }
        //Node Phiếu thu
        else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
        {
            tabControlNhapKho.SelectedTabIndex = 2;
            AnHienGroup(groupPhieuThu, groupLoPhieuThu, groupLoaiPhieuThu);
            string malohdban = xuly_chuoi(e.Node.Text);
            LayDSPhieuThuTheoLo(malohdban);
            bindingPhieuThu.Enabled = true;
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
            //Loại phiếu thu
            LPT_cmbNguoiLap.DataSource = LPTBLL.LayNguoiLap();
            LPT_cmbNguoiLap.ValueMember = "TenDangNhap";
            LPT_cmbNguoiLap.DisplayMember = "TenDangNhap";
            LPT_cmbNguoiSua.DataSource = LPTBLL.LayNguoiLap();
            LPT_cmbNguoiSua.DisplayMember = "TenDangNhap";
            LPT_cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô phiếu thu
            comboNguoiLap.DataSource = LPTBLL.LayNguoiLap();
            comboNguoiLap.DisplayMember = "TenDangNhap";
            comboNguoiLap.ValueMember = "TenDangNhap";
            comboNguoiSua.DataSource = LPTBLL.LayNguoiLap();
            comboNguoiSua.DisplayMember = "TenDangNhap";
            comboNguoiSua.ValueMember = "TenDangNhap";
            //Phiếu thu
            PT_cmbNguoiLap.DataSource = LPTBLL.LayNguoiLap();
            PT_cmbNguoiLap.DisplayMember = "TenDangNhap";
            PT_cmbNguoiLap.ValueMember = "TenDangNhap";
            PT_cmbNguoiSua.DataSource = LPTBLL.LayNguoiLap();
            PT_cmbNguoiSua.DisplayMember = "TenDangNhap";
            PT_cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        private void LoadComboboxColumnNguoiLap()
        {
            //Loại phiếu thu
            ColNgL.DataSource = LPTBLL.LayNguoiLap();
            ColNgL.ValueMember = "TenDangNhap";
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgS.DataSource = LPTBLL.LayNguoiLap();
            ColNgS.ValueMember = "TenDangNhap";
            ColNgS.DisplayMember = "TenDangNhap";
            //Lô phiếu thu
            NguoiLap.DataSource = LPTBLL.LayNguoiLap();
            NguoiLap.ValueMember = "TenDangNhap";
            NguoiLap.DisplayMember = "TenDangNhap";
            NguoiSua.DataSource = LPTBLL.LayNguoiLap();
            NguoiSua.ValueMember = "TenDangNhap";
            NguoiSua.DisplayMember = "TenDangNhap";
            //Phiếu thu
            _NgL.DataSource = LPTBLL.LayNguoiLap();
            _NgL.ValueMember = "TenDangNhap";
            _NgL.DisplayMember = "TenDangNhap";
            _NgS.DataSource = LPTBLL.LayNguoiLap();
            _NgS.ValueMember = "TenDangNhap";
            _NgS.DisplayMember = "TenDangNhap";
        }
        private void LoadMaLoHDban()
        {
            //Lô Phiếu thu
            ColMLHDB.DataSource = LoPTBLL.LayMaLoHDBan();
            ColMLHDB.DisplayMember = "MaLoHDBan";
            ColMLHDB.ValueMember = "MaLoHDBan";

            cmbMaLoHDBan.DataSource = LoPTBLL.LayMaLoHDBan();
            cmbMaLoHDBan.DisplayMember = "MaLoHDBan";
            cmbMaLoHDBan.ValueMember = "MaLoHDBan";

            //Phiếu thu
            MLHDB.DataSource = PTBLL.LayLoHDBan();
            MLHDB.DisplayMember = "MaLoHDBan";
            MLHDB.ValueMember = "MaLoHDBan";

            PT_cmbMLHDB.DataSource = PTBLL.LayLoHDBan();
            PT_cmbMLHDB.DisplayMember = "MaLoHDBan";
            PT_cmbMLHDB.ValueMember = "MaLoHDBan";
        }
        //---Form Load----
        int truycap = 0;
        private void FrmQuanLyThu_Load(object sender, EventArgs e)
        {
            if (truycap == 0)
            {
                LoadTreeView();
            }
            truycap++;
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            //Loại phiếu thu
            ToolBarEnableLoaiPhieuThu(true);
            SetControlEnable_LoaiPhieuThu(true);
            LayDanhSachLoaiPT();
            //Lô phiếu thu
            ToolBarEnableLoPhieuThu(true);
            SetControlEnable_LoPhieuThu(true);
            LoadMaLoHDban();
            LayDanhSachLoPT();
            //Phiếu thu
            ToolBarEnableLoPhieuThu(true);
            SetControlEnable_LoPhieuThu(true);
            LoadMaLoaiPT();
            LoadMaHDBan();
            if (gridPhieuThu.RowCount == 0)
            {
                bindingPhieuThu.Enabled = false;
            }
            //Kiểm tra lưới có rỗng không
            if (gridLoaiPhieuThu.RowCount == 0)
                SetControlEnable_LoaiPhieuThu(true);
            if (gridLoPhieuThu.RowCount == 0)
                SetControlEnable_LoPhieuThu(true);
            if (gridPhieuThu.RowCount == 0)
                SetControlEnable_PhieuThu(true);
        }
        private void FrmQuanLyThu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lpt_nhapluoi == 1 || lpt_nhaptay == 1 || lopt_nhapluoi == 1 || lopt_nhaptay == 1 || pt_nhapluoi == 1 || pt_nhaptay == 1)
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
                            LPTBLL.XoaLoaiPhieuThu(gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].Value.ToString());
                            LayDanhSachLoaiPT();
                        }
                        break;
                    }
                case 2:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPTBLL.XoaLPT(gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].Value.ToString());
                            LayDanhSachLoPT();
                        }
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PTBLL.XoaPT(gridPhieuThu.CurrentRow.Cells["MLHDB"].Value.ToString(), gridPhieuThu.CurrentRow.Cells["MHDB"].Value.ToString());
                            LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
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
        private void FrmQuanLyThu_KeyPress(object sender, KeyPressEventArgs e)
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
#region (Code phần Loại phiếu thu)
        LoaiPhieuThuBLL LPTBLL = new LoaiPhieuThuBLL();
        private void tabItemLoaiPhieuThu_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupLoaiPhieuThu, groupLoPhieuThu, groupPhieuThu);
        }
        private void LayDanhSachLoaiPT()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPTBLL.LayDanhSachLoaiPhieuThu();
            gridLoaiPhieuThu.DataSource = bds;
            bindingLoaiPhieuThu.BindingSource = bds;
            gridLoaiPhieuThu.AllowUserToAddRows = false;
        }
        //Nhập lưới
        private int lpt_nhapluoi = 0;

        private void ToolBarEnableLoaiPhieuThu(bool DangThaoTac=false)
        {
            LPT_Add.Enabled = DangThaoTac;
            LPT_Delete.Enabled = DangThaoTac;
            LPT_Cancel.Enabled = !DangThaoTac;
            LPT_Refresh.Enabled = DangThaoTac;
            LPT_Save.Enabled = !DangThaoTac;
        }
        private void LPT_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyThu_Load(sender, e);
            ToolBarEnableLoaiPhieuThu(true);
            lpt_nhapluoi = 0;
        }
        private void LPT_Add_Click(object sender, EventArgs e)
        {
            lpt_nhapluoi = 1;
            ToolBarEnableLoaiPhieuThu(false);
            if (gridLoaiPhieuThu.RowCount == 0)
            {
                gridLoaiPhieuThu.AllowUserToAddRows = true;
            }
            else
            {
                gridLoaiPhieuThu.AllowUserToAddRows = true;
                bindingLoaiPhieuThu.BindingSource.MoveLast();
            }
        }
        private void LPT_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoaiPhieuThu.RowCount == 0)
                LPT_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPTBLL.XoaLoaiPhieuThu(gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].Value.ToString());
                LayDanhSachLoaiPT();
            }
        }
        private void LPT_Save_Click(object sender, EventArgs e)
        {
            ToolBarEnableLoaiPhieuThu(true);
            switch (lpt_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuThu.Focus();
                            LoaiPhieuThu LPT = new LoaiPhieuThu();
                            string maloaiphieuthu = gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].Value.ToString();
                            LPT.TenLoaiPhieuThu = gridLoaiPhieuThu.CurrentRow.Cells["ColTLPT"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColTLPT"].Value.ToString() : "";
                            LPT.NgayLap = System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNL"].Value.ToString());
                            LPT.NguoiLap = (gridLoaiPhieuThu.CurrentRow.Cells["ColNgL"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            LPT.NgaySua = System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNS"].Value.ToString());
                            LPT.NguoiSua = (gridLoaiPhieuThu.CurrentRow.Cells["ColNgS"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            LPTBLL.SuaLoaiPhieuThu(maloaiphieuthu, LPT);
                            LayDanhSachLoaiPT();
                            ToolBarEnableLoaiPhieuThu(true);
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuThu(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuThu.Focus();
                            if (gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].Value == null || gridLoaiPhieuThu.CurrentRow.Cells["ColTLPT"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuthu = gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].Value.ToString();
                            string tenloaiphieuthu = gridLoaiPhieuThu.CurrentRow.Cells["ColTLPT"].Value.ToString();
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoaiPhieuThu.CurrentRow.Cells["ColNgL"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridLoaiPhieuThu.CurrentRow.Cells["ColNgS"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            LPTBLL.ThemLoaiPhieuThu(maloaiphieuthu, tenloaiphieuthu, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPT();
                            ToolBarEnableLoaiPhieuThu(true);
                            lpt_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableLoaiPhieuThu(true);
                            lpt_nhapluoi = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void LPT_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lpt_nhapluoi = 0;
                LayDanhSachLoaiPT();
                ToolBarEnableLoaiPhieuThu(true);
            }
            else
            {

                lpt_nhapluoi = 0;
                return;
            }
        }
        private void LPT_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridLoaiPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lpt_nhapluoi == 1)
                    gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].ReadOnly = false;
                else
                    gridLoaiPhieuThu.CurrentRow.Cells["ColMLPT"].ReadOnly = true;
            }
        }
        private void gridLoaiPhieuThu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoaiPhieuThu();
        }       

        //Code phần nhập tay
        private int lpt_nhaptay = 0;
        
        private void SetConTrolToNull_LoaiPhieuThu()
        {
            LPT_txtMaLoaiPhieuThu.Clear();
            LPT_txtTenLoaiPhieuThu.Clear();
            LPT_dpNgayLap.Value = DateTime.Now;
            LPT_cmbNguoiLap.Text = "";
            LPT_dpNgaySua.Value = DateTime.Now;
            LPT_cmbNguoiSua.Text = "";
        }
        
        private void SetControlEnable_LoaiPhieuThu(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            LPT_txtMaLoaiPhieuThu.ReadOnly = status;
            LPT_txtTenLoaiPhieuThu.ReadOnly = status;
            LPT_dpNgayLap.Enabled = !status;
            LPT_cmbNguoiLap.Enabled = !status;
            LPT_dpNgaySua.Enabled = !status;
            LPT_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiPhieuThu(int dong)
        {
            if (gridLoaiPhieuThu.RowCount > 0 && lpt_nhapluoi != 1)
            {
                LPT_txtMaLoaiPhieuThu.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColMLPT"].Value.ToString();
                LPT_txtTenLoaiPhieuThu.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColTLPT"].Value.ToString();
                LPT_dpNgayLap.Value = System.Convert.ToDateTime(gridLoaiPhieuThu.Rows[dong].Cells["ColNL"].Value.ToString());
                LPT_cmbNguoiLap.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColNgL"].Value.ToString();
                LPT_dpNgaySua.Value = System.Convert.ToDateTime(gridLoaiPhieuThu.Rows[dong].Cells["ColNS"].Value.ToString());
                LPT_cmbNguoiSua.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColNgS"].Value.ToString();
            }
        }
        private void gridLoaiPhieuThu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoaiPhieuThu(e.RowIndex);
            SetControlEnable_LoaiPhieuThu(true);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            lpt_nhaptay = 1;
            SetConTrolToNull_LoaiPhieuThu();
            SetControlEnable_LoaiPhieuThu(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoaiPhieuThu(false);
            LPT_txtMaLoaiPhieuThu.ReadOnly = true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (lpt_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoaiPhieuThu LPT = new LoaiPhieuThu();
                            string maloaiphieuthu = LPT_txtMaLoaiPhieuThu.Text;
                            LPT.TenLoaiPhieuThu = LPT_txtTenLoaiPhieuThu.Text;
                            LPT.NgayLap = LPT_dpNgayLap.Value;
                            LPT.NguoiLap = LPT_cmbNguoiLap.SelectedValue.ToString();
                            LPT.NgaySua = LPT_dpNgaySua.Value;
                            LPT.NguoiSua = LPT_cmbNguoiSua.SelectedValue.ToString();
                            LPTBLL.SuaLoaiPhieuThu(maloaiphieuthu, LPT);
                            LayDanhSachLoaiPT();
                            SetControlEnable_LoaiPhieuThu(true);
                        }
                        else
                        {
                            SetControlEnable_LoaiPhieuThu(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (LPT_txtMaLoaiPhieuThu.Text == "" || LPT_txtTenLoaiPhieuThu.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuthu = LPT_txtMaLoaiPhieuThu.Text;
                            string tenloaiphieuthu = LPT_txtTenLoaiPhieuThu.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (LPT_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LPT_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LPT_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LPT_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = LPT_cmbNguoiLap.Text;
                            string nguoisua = LPT_cmbNguoiSua.Text;
                            LPTBLL.ThemLoaiPhieuThu(maloaiphieuthu, tenloaiphieuthu, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPT();
                            lpt_nhaptay = 0;
                            SetControlEnable_LoaiPhieuThu(true);
                        }
                        else
                        {
                            lpt_nhaptay = 0;
                            SetControlEnable_LoaiPhieuThu(true);
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
                LayDanhSachLoaiPT();
                SetControlEnable_LoaiPhieuThu(true);
                lpt_nhaptay = 0;
            }
            else
            {
                lpt_nhaptay = 0;
                return;
            }
        }
# endregion
#region (Code phần Lô phiếu thu)

        LoPhieuThuBLL LoPTBLL = new LoPhieuThuBLL();
        private void tabItemLoPhieuThu_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupLoPhieuThu, groupLoaiPhieuThu, groupPhieuThu);
        }
        private void LayDanhSachLoPT()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoPTBLL.LayDanhSachLoPhieuThu();
            bindingLoPhieuThu.BindingSource = bds;
            gridLoPhieuThu.DataSource = bds;
            gridLoPhieuThu.AllowUserToAddRows = false;
        }
        //Xử lý Nhập lưới
        int lopt_nhapluoi = 0;
        private void ToolBarEnableLoPhieuThu(bool DangThaoTac = false)
        {
            LoPT_Add.Enabled = DangThaoTac;
            LoPT_Delete.Enabled = DangThaoTac;
            LoPT_Cancel.Enabled = !DangThaoTac;
            LoPT_Refresh.Enabled = DangThaoTac;
            LoPT_Save.Enabled = !DangThaoTac;
        }
        private void LoPT_Refresh_Click(object sender, EventArgs e)
        {
            lopt_nhapluoi = 0;
            FrmQuanLyThu_Load(sender, e);
            ToolBarEnableLoPhieuThu(true);
            LayDanhSachLoPT();
        }
        private void LoPT_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoPT_Add_Click(object sender, EventArgs e)
        {
            lopt_nhapluoi = 1;
            ToolBarEnableLoPhieuThu(false);
            if (gridLoPhieuThu.RowCount== 0)
            {
                gridLoPhieuThu.AllowUserToAddRows = true;
            }
            else
            {
                gridLoPhieuThu.AllowUserToAddRows = true;
                bindingLoPhieuThu.BindingSource.MoveLast();
            }
        }
        private void LoPT_Delete_Click(object sender, EventArgs e)
        {
            if (gridLoPhieuThu.RowCount == 0)
                LoPT_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoPTBLL.XoaLPT(gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].Value.ToString());
                LayDanhSachLoPT();
            }
        }
        private void LoPT_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lopt_nhapluoi = 0;
                LayDanhSachLoPT();
                ToolBarEnableLoPhieuThu(true);
            }
            else
            {
                lopt_nhapluoi = 0;
                return;
            }
        }
        private void LoPT_Save_Click(object sender, EventArgs e)
        {
            ToolBarEnableLoPhieuThu(true);
            switch (lopt_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuThu.Focus();
                            LoPhieuThu LPT = new LoPhieuThu();
                            string malohdban = gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].Value.ToString();
                            LPT.NgayLoThu = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["ColNLT"].Value.ToString());
                            LPT.MoTa = (gridLoPhieuThu.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LPT.NgayLap = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LPT.NguoiLap = (gridLoPhieuThu.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LPT.NgaySua = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LPT.NguoiSua = (gridLoPhieuThu.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPTBLL.SuaLoPT(malohdban, LPT);
                            LayDanhSachLoPT();
                            ToolBarEnableLoPhieuThu(true);
                        }
                        else
                        {
                            ToolBarEnableLoPhieuThu(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuThu.Focus();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].Value == null || System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["ColNLT"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdban = gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].Value.ToString();
                            DateTime ngaylothu;
                            ngaylothu = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["ColNLT"].Value);
                            string mota = (gridLoPhieuThu.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoPhieuThu.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoPhieuThu.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPTBLL.ThemLoPT(malohdban, ngaylothu, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPT();
                            ToolBarEnableLoPhieuThu(true);
                            lopt_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableLoPhieuThu(true);
                            lopt_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }
        private void gridLoPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lopt_nhapluoi == 1)
                {
                    gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].ReadOnly = false;
                }
                else
                {
                    gridLoPhieuThu.CurrentRow.Cells["ColMLHDB"].ReadOnly = true;
                }
            }
        }
        private void gridLoPhieuThu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoPhieuThu();
        }
        //Xử lý phần nhập tay
        private int lopt_nhaptay = 0;

        private void SetConTrolToNull_LoPhieuThu()
        {
            cmbMaLoHDBan.Text = "";
            dpNgayThu.Value = DateTime.Now;
            txtMota.Clear();
            dpNgayLap.Value = DateTime.Now;
            comboNguoiLap.Text = "";
            dpNgaySua.Value = DateTime.Now;
            comboNguoiSua.Text = "";
        }
        private void SetControlEnable_LoPhieuThu(bool status)
        {
            btn_LPT_Sua.Enabled = status;
            btn_LPT_Them.Enabled = status;
            btn_LPT_Luu.Enabled = !status;
            btn_LPT_Huy.Enabled = !status;
            cmbMaLoHDBan.Enabled = !status;
            dpNgayThu.Enabled = !status;
            txtMota.ReadOnly = status;
            dpNgayLap.Enabled = !status;
            comboNguoiLap.Enabled = !status;
            dpNgaySua.Enabled = !status;
            comboNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoPhieuThu(int dong)
        {
            if (gridLoPhieuThu.RowCount > 0 && lopt_nhapluoi != 1)
            {
                cmbMaLoHDBan.Text = gridLoPhieuThu.Rows[dong].Cells["ColMLHDB"].Value.ToString();
                dpNgayThu.Value = System.Convert.ToDateTime(gridLoPhieuThu.Rows[dong].Cells["ColNLT"].Value.ToString());
                txtMota.Text = gridLoPhieuThu.Rows[dong].Cells["ColMT"].Value.ToString();
                dpNgayLap.Value = System.Convert.ToDateTime(gridLoPhieuThu.Rows[dong].Cells["NgayLap"].Value.ToString());
                comboNguoiLap.Text = gridLoPhieuThu.Rows[dong].Cells["NguoiLap"].Value.ToString();
                dpNgaySua.Value = System.Convert.ToDateTime(gridLoPhieuThu.Rows[dong].Cells["NgaySua"].Value.ToString());
                comboNguoiSua.Text = gridLoPhieuThu.Rows[dong].Cells["NguoiSua"].Value.ToString();
            }
        }
        private void gridLoPhieuThu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_LoPhieuThu(e.RowIndex);
            SetControlEnable_LoPhieuThu(true);
        }
        private void btn_LPT_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_LoPhieuThu(false);
            cmbMaLoHDBan.Enabled = false;
        }
        private void btn_LPT_Them_Click(object sender, EventArgs e)
        {
            lopt_nhaptay = 1;
            SetConTrolToNull_LoPhieuThu();
            SetControlEnable_LoPhieuThu(false);
        }

        private void btn_LPT_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPT();
                SetControlEnable_LoPhieuThu(true);
                lopt_nhaptay = 0;
            }
            else
            {
                lopt_nhaptay = 0;
                return;
            }
        }

        private void btn_LPT_Luu_Click(object sender, EventArgs e)
        {
            switch (lopt_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LoPhieuThu LoPT = new LoPhieuThu();
                            string malohdban = cmbMaLoHDBan.Text;
                            LoPT.NgayLoThu = dpNgayThu.Value;
                            LoPT.MoTa = txtMota.Text;
                            LoPT.NgayLap = dpNgayLap.Value;
                            LoPT.NguoiLap = comboNguoiLap.SelectedValue.ToString();
                            LoPT.NgaySua = dpNgaySua.Value;//System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNS"].Value.ToString());
                            LoPT.NguoiSua = comboNguoiSua.SelectedValue.ToString();
                            LoPTBLL.SuaLoPT(malohdban, LoPT);
                            LayDanhSachLoPT();
                            SetControlEnable_LoPhieuThu(true);
                        }
                        else
                        {
                            SetControlEnable_LoPhieuThu(true);
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
                            if (cmbMaLoHDBan.Text == "" || dpNgayThu.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdban = cmbMaLoHDBan.Text;
                            DateTime ngaythu = dpNgayThu.Value;
                            string mota = txtMota.Text;
                            string tenloaiphieuthu = LPT_txtTenLoaiPhieuThu.Text;
                            DateTime ngaylap;
                            if (LPT_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(LPT_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (LPT_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(LPT_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = comboNguoiLap.Text;
                            string nguoisua = comboNguoiSua.Text;
                            LoPTBLL.ThemLoPT(malohdban, ngaythu, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPT();
                            SetControlEnable_LoPhieuThu(true);
                            lopt_nhaptay = 0;
                        }
                        else
                        {
                            lopt_nhaptay = 0;
                            SetControlEnable_LoPhieuThu(true);
                            return;
                        }
                        break;
                    }
            }
        }
#endregion
#region (Code phần Phiếu Thu)
        PhieuThuBLL PTBLL = new PhieuThuBLL();
        private void LoadMaHDBan()
        {
            MHDB.DataSource = PTBLL.LayMaHDBan(); ;
            MHDB.DisplayMember = "MaHDBan";
            MHDB.ValueMember = "MaHDBan";
        }
        private void LoadMaLoaiPT()
        {
            //Combobox Column
            MLPT.DataSource = PTBLL.LayMaLoaiPhieuThu();
            MLPT.DisplayMember = "TenLoaiPhieuThu";
            MLPT.ValueMember = "MaLoaiPhieuThu";
            //Combobox
            PT_cmbMLPT.DataSource = PTBLL.LayMaLoaiPhieuThu();
            PT_cmbMLPT.DisplayMember = "TenLoaiPhieuThu";
            PT_cmbMLPT.ValueMember = "MaLoaiPhieuThu";
        }
        private void tabItemNhapKho_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupPhieuThu, groupLoaiPhieuThu, groupLoPhieuThu);
        }
        private void LayDSPhieuThuTheoLo(string malo)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PTBLL.LayDSPhieuThu(malo);
            bindingPhieuThu.BindingSource = bds;
            gridPhieuThu.DataSource = bds;
            gridPhieuThu.AllowUserToAddRows = false;
        }
        //Xử lý nhập lưới
        int pt_nhapluoi = 0;

        private void ToolBarEnablePhieuThu(bool DangThaoTac = false)
        {
            PT_Add.Enabled = DangThaoTac;
            PT_Delete.Enabled = DangThaoTac;
            PT_Cancel.Enabled = !DangThaoTac;
            PT_Refresh.Enabled = DangThaoTac;
            PT_Save.Enabled = !DangThaoTac;
        }
        private void PT_Refresh_Click(object sender, EventArgs e)
        {
            pt_nhapluoi = 0;
            FrmQuanLyThu_Load(sender, e);
            ToolBarEnablePhieuThu(true);
            LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        }
        private void PT_Add_Click(object sender, EventArgs e)
        {
            pt_nhapluoi = 1;
            ToolBarEnablePhieuThu(false);
            if (gridPhieuThu.RowCount == 0)
            {
                gridPhieuThu.AllowUserToAddRows = true;
            }
            else
            {
                gridPhieuThu.AllowUserToAddRows = true;
                bindingPhieuThu.BindingSource.MoveLast();
            }
            gridPhieuThu.Rows[gridPhieuThu.RowCount - 1].Cells["MLHDB"].Value = xuly_chuoi(advTreeLoThu.SelectedNode.Text);
        }

        private void PT_Delete_Click(object sender, EventArgs e)
        {
            if (gridPhieuThu.RowCount == 0)
                PT_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PTBLL.XoaPT(gridPhieuThu.CurrentRow.Cells["MLHDB"].Value.ToString(), gridPhieuThu.CurrentRow.Cells["MHDB"].Value.ToString());
                LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
            }
        }
        private void PT_Save_Click(object sender, EventArgs e)
        {
            switch (pt_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuThu.Focus();
                            if (gridPhieuThu.CurrentRow.Cells["MLPT"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            PhieuThu PT = new PhieuThu();
                            string malohdban = gridPhieuThu.CurrentRow.Cells["MLHDB"].Value.ToString();
                            string mahdban = gridPhieuThu.CurrentRow.Cells["MHDB"].Value.ToString();
                            PT.MaLoaiPhieuThu = gridPhieuThu.CurrentRow.Cells["MLPT"].Value.ToString();
                            PT.MoTa = (gridPhieuThu.CurrentRow.Cells["MT"].Value != null ? gridPhieuThu.CurrentRow.Cells["MT"].Value.ToString() : "");
                            PT.NgayLap = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NL"].Value.ToString());
                            PT.NguoiLap = (gridPhieuThu.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            PT.NgaySua = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NS"].Value.ToString());
                            PT.NguoiSua = (gridPhieuThu.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PTBLL.SuaPT(malohdban, mahdban, PT);
                            LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
                            ToolBarEnablePhieuThu(true);
                        }
                        else
                        {
                            ToolBarEnablePhieuThu(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuThu.Focus();
                            if (gridPhieuThu.CurrentRow.Cells["MLPT"].Value == null || gridPhieuThu.CurrentRow.Cells["MLHDB"].Value == null || gridPhieuThu.CurrentRow.Cells["MHDB"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuthu = gridPhieuThu.CurrentRow.Cells["MLPT"].Value.ToString();
                            string malohdban = gridPhieuThu.CurrentRow.Cells["MLHDB"].Value.ToString();
                            string mahdban = gridPhieuThu.CurrentRow.Cells["MHDB"].Value.ToString();
                            string mota = (gridPhieuThu.CurrentRow.Cells["MT"].Value != null ? gridPhieuThu.CurrentRow.Cells["MT"].Value.ToString() : "");
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridPhieuThu.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            string nguoisua = (gridPhieuThu.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PTBLL.ThemPhieuThu(maloaiphieuthu,malohdban,mahdban,mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
                            ToolBarEnablePhieuThu(true);
                            pt_nhapluoi = 0;
                        }
                        else
                        {
                            pt_nhapluoi = 0;
                            ToolBarEnablePhieuThu(true);
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
                pt_nhapluoi = 0;
                LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
                ToolBarEnablePhieuThu(true);
            }
            else
            {
                pt_nhapluoi = 0;
                return;
            }
        }
        private void PT_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridPhieuThu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnablePhieuThu();
        }
        private void gridPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (pt_nhapluoi == 1)
                {
                    gridPhieuThu.CurrentRow.Cells["MLHDB"].ReadOnly = false;
                    gridPhieuThu.CurrentRow.Cells["MHDB"].ReadOnly = false;
                }
                else
                {
                    gridPhieuThu.CurrentRow.Cells["MLHDB"].ReadOnly = true;
                    gridPhieuThu.CurrentRow.Cells["MHDB"].ReadOnly = true;
                }
                if (e.ColumnIndex > -1 && gridPhieuThu.Columns[e.ColumnIndex].Name == "MLHDB")
                {
                    gridPhieuThu.CurrentRow.Cells["MLHDB"].Value = xuly_chuoi(advTreeLoThu.SelectedNode.Text);
                }
                if (pt_nhapluoi == 0 && pt_nhaptay == 0)
                {
                    if (e.ColumnIndex == -1)
                    {
                            if (gridPhieuThu.CurrentRow.Cells["MHDB"].Value != null)
                            {
                                FrmChiTietPhieuThu CTPT = new FrmChiTietPhieuThu();
                                CTPT.mahdban = gridPhieuThu.CurrentRow.Cells["MHDB"].Value.ToString();
                                CTPT.malohdb = gridPhieuThu.CurrentRow.Cells["MLHDB"].Value.ToString();//xuly_chuoi(advTreeLoThu.SelectedNode.Text);
                                CTPT.Show();
                            }
                            else
                                return;
                    }
                }
            }
        }
        //Xử lý phần nhập tay
        private int pt_nhaptay = 0;

        private void SetConTrolToNull_PhieuThu()
        {
            PT_cmbMLPT.Text = "";
            PT_cmbMLHDB.Text = "";
            PT_cmbMHDB.Text = "";
            PT_txtMT.Clear();
            PT_dpNgayLap.Value = DateTime.Now;
            PT_cmbNguoiLap.Text = "";
            PT_dpNgaySua.Value = DateTime.Now;
            PT_cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_PhieuThu(bool status)
        {
            btn_PT_Sua.Enabled = status;
            btn_PT_Them.Enabled = status;
            btn_PT_Luu.Enabled = !status;
            btn_PT_Huy.Enabled = !status;
            PT_cmbMLPT.Enabled = !status;
            PT_cmbMLHDB.Enabled = !status;
            PT_cmbMHDB.Enabled = !status;
            PT_txtMT.ReadOnly = status;
            PT_dpNgayLap.Enabled = !status;
            PT_cmbNguoiLap.Enabled = !status;
            PT_dpNgaySua.Enabled = !status;
            PT_cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_PhieuThu(int dong)
        {
            if (gridPhieuThu.RowCount > 0 && pt_nhapluoi != 1)
            {
                PT_cmbMLPT.SelectedValue = gridPhieuThu.Rows[dong].Cells["MLPT"].Value.ToString();
                PT_cmbMLHDB.Text = gridPhieuThu.Rows[dong].Cells["MLHDB"].Value.ToString();
                PT_cmbMHDB.Text = gridPhieuThu.Rows[dong].Cells["MHDB"].Value.ToString();
                PT_txtMT.Text = gridPhieuThu.Rows[dong].Cells["MT"].Value.ToString();
                PT_dpNgayLap.Value = System.Convert.ToDateTime(gridPhieuThu.Rows[dong].Cells["_NL"].Value.ToString());
                PT_cmbNguoiLap.Text = gridPhieuThu.Rows[dong].Cells["_NgL"].Value.ToString();
                PT_dpNgaySua.Value = System.Convert.ToDateTime(gridPhieuThu.Rows[dong].Cells["_NS"].Value.ToString());
                PT_cmbNguoiSua.Text = gridPhieuThu.Rows[dong].Cells["_NgS"].Value.ToString();
            }
        }
        private void gridPhieuThu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_PhieuThu(e.RowIndex);
            SetControlEnable_PhieuThu(true);
        }

        private void btn_PT_Them_Click(object sender, EventArgs e)
        {
            pt_nhaptay = 1;
            SetConTrolToNull_PhieuThu();
            SetControlEnable_PhieuThu(false);
        }

        private void btn_PT_Sua_Click(object sender, EventArgs e)
        {
            SetControlEnable_PhieuThu(false);
            PT_cmbMLHDB.Enabled = false;
            PT_cmbMHDB.Enabled = false;
        }
        private void btn_PT_Luu_Click(object sender, EventArgs e)
        {
            switch (pt_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PhieuThu PT = new PhieuThu();
                            string malohdban = PT_cmbMLHDB.Text;
                            string mahdb = PT_cmbMHDB.Text;
                            PT.MaLoaiPhieuThu = PT_cmbMLPT.SelectedValue.ToString();
                            PT.MoTa = PT_txtMT.Text;
                            PT.NgayLap = PT_dpNgayLap.Value;
                            PT.NguoiLap = PT_cmbNguoiLap.Text;
                            PT.NgaySua = PT_dpNgaySua.Value;
                            PT.NguoiSua = PT_cmbNguoiSua.Text;
                            PTBLL.SuaPT(malohdban, mahdb, PT);
                            LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
                            SetControlEnable_PhieuThu(true);
                        }
                        else
                        {
                            SetControlEnable_PhieuThu(true);
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
                            if (PT_cmbMLPT.Text == "" || PT_cmbMLHDB.Text == "" || PT_cmbMHDB.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuthu = PT_cmbMLPT.SelectedValue.ToString();
                            string malohdban = PT_cmbMLHDB.Text;
                            string mahdban = PT_cmbMHDB.Text;
                            string mota = PT_txtMT.Text;
                            DateTime ngaylap;
                            if (PT_dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(PT_dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (PT_dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(PT_dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = PT_cmbNguoiLap.Text;
                            string nguoisua = PT_cmbNguoiSua.Text;
                            PTBLL.ThemPhieuThu(maloaiphieuthu, malohdban, mahdban, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
                            SetControlEnable_PhieuThu(true);
                            pt_nhaptay = 0;
                        }
                        else
                        {
                            pt_nhaptay = 0;
                            SetControlEnable_PhieuThu(true);
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
                LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
                SetControlEnable_PhieuThu(true);
                pt_nhaptay = 0;
            }
            else
            {
                pt_nhaptay = 0;
                return;
            }
        }
        private void PT_cmbMLHDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PT_cmbMHDB.Text = "";
            PT_cmbMHDB.DataSource = PTBLL.LayMaHDBanTheoLo(PT_cmbMLHDB.Text);
            PT_cmbMHDB.DisplayMember = "MaHDBan";
            PT_cmbMHDB.ValueMember = "MaHDBan";
        }
#endregion             
    }
}