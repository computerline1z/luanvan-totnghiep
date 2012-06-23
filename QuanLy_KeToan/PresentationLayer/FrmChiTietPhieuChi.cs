using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.DataAccessLayer;
using QuanLy_KeToan.BusinessLogicLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmChiTietPhieuChi : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietPhieuChi()
        {
            InitializeComponent();
        }
        ChiTietPhieuChiBLL CTPCBLL = new ChiTietPhieuChiBLL();
        public string mahdmua;
        public string malohdmua;
        private void LoadHang()
        {
            ColMH.DataSource = CTPCBLL.LayMaHang(malohdmua,mahdmua);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";

            cmbMH.DataSource = CTPCBLL.LayMaHang(malohdmua,mahdmua);
            cmbMH.DisplayMember = "TenHang";
            cmbMH.ValueMember = "MaHang";
        }
        private void LayDanhSachChiTietPhieuChi(string malohdmua,string mahdmua)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPCBLL.LayChiTietPhieuChi(malohdmua,mahdmua);
            bindingCTPC.BindingSource = bds;
            gridChiTietPhieuChi.DataSource = bds;
            gridChiTietPhieuChi.AllowUserToAddRows = false;
        }
        private void LoadNguoiLap()
        {
            ColNgL.DataSource = CTPCBLL.LayNguoiLap();
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgL.ValueMember = "TenDangNhap";
            ColNgS.DataSource = CTPCBLL.LayNguoiLap();
            ColNgS.DisplayMember = "TenDangNhap";
            ColNgS.ValueMember = "TenDangNhap";
            ///
            cmbNL.DataSource = CTPCBLL.LayNguoiLap();
            cmbNL.DisplayMember = "TenDangNhap";
            cmbNL.ValueMember = "TenDangNhap";
            cmbNS.DataSource = CTPCBLL.LayNguoiLap();
            cmbNS.DisplayMember = "TenDangNhap";
            cmbNS.ValueMember = "TenDangNhap";
        }
        //Xử lý nhập lưới
        int ctpc_nhapluoi = 0;
        private void ToolBarEnableChiTietPhieuChi(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctpc_nhapluoi = 0;
            FrmChiTietPhieuChi_Load(sender, e);
            ToolBarEnableChiTietPhieuChi(true);      
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ctpc_nhapluoi = 1;
            ToolBarEnableChiTietPhieuChi(false);
            if (gridChiTietPhieuChi.RowCount == 0)
            {
                gridChiTietPhieuChi.AllowUserToAddRows = true;
            }
            else
            {
                gridChiTietPhieuChi.AllowUserToAddRows = true;
                bindingCTPC.BindingSource.MoveLast();
            }
            gridChiTietPhieuChi.Rows[gridChiTietPhieuChi.RowCount - 1].Cells["ColMLHDM"].Value = malohdmua;
            gridChiTietPhieuChi.Rows[gridChiTietPhieuChi.RowCount - 1].Cells["ColMHDM"].Value = mahdmua;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridChiTietPhieuChi.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu thu này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value.ToString();
                bool xoa = CTPCBLL.XoaCTPC(malohdmua, mahdmua, mahang);
                LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (ctpc_nhapluoi)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPC.Focus();
                            ChiTietPhieuChi CTPC = new ChiTietPhieuChi();
                            string mahang = gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value.ToString();
                            CTPC.NgayLap = System.Convert.ToDateTime(gridChiTietPhieuChi.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTPC.NguoiLap = (gridChiTietPhieuChi.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuChi.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTPC.NgaySua = System.Convert.ToDateTime(gridChiTietPhieuChi.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTPC.NguoiSua = (gridChiTietPhieuChi.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuChi.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool sua = CTPCBLL.SuaCTPC(malohdmua, mahdmua, mahang, CTPC);
                            LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
                            ToolBarEnableChiTietPhieuChi(true);
                        }
                        else
                        {
                            ToolBarEnableChiTietPhieuChi(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPC.Focus();
                            if (gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahang = gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietPhieuChi.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietPhieuChi.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietPhieuChi.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietPhieuChi.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietPhieuChi.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuChi.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietPhieuChi.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuChi.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool them = CTPCBLL.ThemCTPC(malohdmua, mahdmua, mahang, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
                            ToolBarEnableChiTietPhieuChi(true);
                            ctpc_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableChiTietPhieuChi(true);
                            ctpc_nhapluoi = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctpc_nhapluoi = 0;
                LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
                ToolBarEnableChiTietPhieuChi(true);
            }
            else
            {
                ctpc_nhapluoi = 0;
                return;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Xử lý phần nhập tay
        private int ctpc_nhaptay = 0;

        private void SetConTrolToNull_CTPC()
        {
            txtMLHDM.Text = malohdmua;
            txtMHDM.Text = mahdmua;
            cmbMH.Text = "";
            dpiTienChi.Value = 0;
            dpNL.Value = DateTime.Now;
            cmbNL.Text = "";
            dpNS.Value = DateTime.Now;
            cmbNS.Text = "";
        }
        private void SetControlEnable_CTPC(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            cmbMH.Enabled = !status;
            dpiTienChi.Enabled = !status;
            dpNL.Enabled = !status;
            cmbNL.Enabled = !status;
            dpNS.Enabled = !status;
            cmbNS.Enabled = !status;
        }
        private void LoadDataToControl_CTPC(int dong)
        {
            if (gridChiTietPhieuChi.RowCount > 0 && ctpc_nhapluoi != 1)
            {
                txtMLHDM.Text = gridChiTietPhieuChi.Rows[dong].Cells["ColMLHDM"].Value.ToString();
                txtMHDM.Text = gridChiTietPhieuChi.Rows[dong].Cells["ColMHDM"].Value.ToString();
                cmbMH.SelectedValue = gridChiTietPhieuChi.Rows[dong].Cells["ColMH"].Value.ToString();
                dpiTienChi.Value = System.Convert.ToDouble(gridChiTietPhieuChi.Rows[dong].Cells["ColTC"].Value.ToString());
                dpNL.Value = System.Convert.ToDateTime(gridChiTietPhieuChi.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNL.Text = (gridChiTietPhieuChi.Rows[dong].Cells["ColNgL"].Value == null ? "" : gridChiTietPhieuChi.Rows[dong].Cells["ColNgL"].Value.ToString());
                dpNS.Value = System.Convert.ToDateTime(gridChiTietPhieuChi.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNS.Text = (gridChiTietPhieuChi.Rows[dong].Cells["ColNgS"].Value == null ? "" : gridChiTietPhieuChi.Rows[dong].Cells["ColNgS"].Value.ToString());
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ctpc_nhaptay = 1;
            SetConTrolToNull_CTPC();
            SetControlEnable_CTPC(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_CTPC(false);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (ctpc_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ChiTietPhieuChi CTPC = new ChiTietPhieuChi();
                            string mahang = cmbMH.SelectedValue.ToString();
                            CTPC.NgayLap = dpNL.Value;
                            CTPC.NguoiLap = cmbNL.Text;
                            CTPC.NgaySua = dpNS.Value;
                            CTPC.NguoiSua = cmbNS.Text;
                            bool sua = CTPCBLL.SuaCTPC(malohdmua, mahdmua, mahang, CTPC);
                            LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
                            SetControlEnable_CTPC(true);
                        }
                        else
                        {
                            SetControlEnable_CTPC(true);
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
                            if (cmbMH.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malohdmua = txtMLHDM.Text;
                            string mahdmua = txtMHDM.Text;
                            string mahang = cmbMH.SelectedValue.ToString();
                            DateTime ngaylap;
                            if (dpNL.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(dpNL.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (dpNS.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(dpNS.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = cmbNL.Text;
                            string nguoisua = cmbNS.Text;
                            bool them = CTPCBLL.ThemCTPC(malohdmua, mahdmua, mahang, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
                            SetControlEnable_CTPC(true);
                            ctpc_nhapluoi = 0;
                        }
                        else
                        {
                            ctpc_nhaptay = 0;
                            SetControlEnable_CTPC(true);
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
                LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
                SetControlEnable_CTPC(true);
                ctpc_nhaptay = 0;
            }
            else
            {
                ctpc_nhaptay = 0;
                return;
            }
        }
        private void gridChiTietPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (ctpc_nhapluoi == 1)
                {
                    gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].ReadOnly = false;
                }
                else
                    gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].ReadOnly = true;
                string name = gridChiTietPhieuChi.Columns[e.ColumnIndex].Name;
                if (name == "ColMLHDM" || name == "ColMHDM")
                {
                    gridChiTietPhieuChi.CurrentRow.Cells["ColMHDM"].Value = mahdmua;
                    gridChiTietPhieuChi.CurrentRow.Cells["ColMLHDM"].Value = malohdmua;
                }
                if (gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value != null && name == "ColTC" && ctpc_nhapluoi == 1)
                {
                    MessageBox.Show(CTPCBLL.TinhGiaTriTheoChiTietHDMua(malohdmua, mahdmua, gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value.ToString()).ToString());
                    gridChiTietPhieuChi.CurrentRow.Cells["ColTC"].Value = CTPCBLL.TinhGiaTriTheoChiTietHDMua(malohdmua, mahdmua, gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value.ToString());
                }
            }
        }
        private void FrmChiTietPhieuChi_Load(object sender, EventArgs e)
        {
            LoadHang();
            LoadNguoiLap();
            LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
            if (gridChiTietPhieuChi.RowCount == 0)
            {
                SetControlEnable_CTPC(true);
            }
        }
        private void gridChiTietPhieuChi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableChiTietPhieuChi();
        }
        private void gridChiTietPhieuChi_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_CTPC(e.RowIndex);
            SetControlEnable_CTPC(true);
        }
        //Xóa dữ liệu trên Datagridview bằng phím delete
        private void XoaGridByButton()
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuChi.CurrentRow.Cells["ColMH"].Value.ToString();
                CTPCBLL.XoaCTPC(malohdmua, mahdmua, mahang);
                LayDanhSachChiTietPhieuChi(malohdmua, mahdmua);
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
        private void gridChiTietPhieuChi_KeyPress(object sender, KeyPressEventArgs e)
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
                XoaGridByButton();
            }
        }
    }
}