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
    public partial class FrmChiTietPhieuThu : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietPhieuThu()
        {
            InitializeComponent();
        }
        ChiTietPhieuThuBLL CTPTBLL = new ChiTietPhieuThuBLL();
        public string mahdban;
        public string malohdb;
        private void LoadHang()
        {
            ColMH.DataSource = CTPTBLL.LayMaHang(malohdb,mahdban);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";

            cmbMH.DataSource = CTPTBLL.LayMaHang(malohdb,mahdban);
            cmbMH.DisplayMember = "TenHang";
            cmbMH.ValueMember = "MaHang";
        }
        private void LayDanhSachChiTietPhieuThu(string malohdban,string mahdban)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPTBLL.LayChiTietPhieuThu(malohdban,mahdban);
            bindingCTPT.BindingSource = bds;
            gridChiTietPhieuThu.DataSource = bds;
            gridChiTietPhieuThu.AllowUserToAddRows = false;
        }
        private void LoadNguoiLap()
        {
            ColNgL.DataSource = CTPTBLL.LayNguoiLap();
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgL.ValueMember = "TenDangNhap";
            ColNgS.DataSource = CTPTBLL.LayNguoiLap();
            ColNgS.DisplayMember = "TenDangNhap";
            ColNgS.ValueMember = "TenDangNhap";
            ///
            cmbNL.DataSource = CTPTBLL.LayNguoiLap();
            cmbNL.DisplayMember = "TenDangNhap";
            cmbNL.ValueMember = "TenDangNhap";
            cmbNS.DataSource = CTPTBLL.LayNguoiLap();
            cmbNS.DisplayMember = "TenDangNhap";
            cmbNS.ValueMember = "TenDangNhap";
        }
        //Xử lý nhập lưới
        int ctpt_nhapluoi = 0;
        private void ToolBarEnableChiTietPhieuThu(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
        }
        private void gridChiTietPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (ctpt_nhapluoi == 1)
                {
                    gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].ReadOnly = false;
                }
                else
                    gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].ReadOnly = true;
                string name = gridChiTietPhieuThu.Columns[e.ColumnIndex].Name;
                if (name == "ColMLHDB" || name == "ColMHDB")
                {
                    gridChiTietPhieuThu.CurrentRow.Cells["ColMHDB"].Value = mahdban;
                    gridChiTietPhieuThu.CurrentRow.Cells["ColMLHDB"].Value = malohdb;
                }
                if (gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value != null && name == "ColTT" && ctpt_nhapluoi == 1)
                {
                    MessageBox.Show(CTPTBLL.TinhGiaTriTheoChiTietHDBan(malohdb, mahdban, gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value.ToString()).ToString());
                    gridChiTietPhieuThu.CurrentRow.Cells["ColTT"].Value = CTPTBLL.TinhGiaTriTheoChiTietHDBan(malohdb, mahdban, gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value.ToString());
                }
            }
        }
        private void FrmChiTietPhieuThu_Load(object sender, EventArgs e)
        {
            LoadHang();
            LoadNguoiLap();
            LayDanhSachChiTietPhieuThu(malohdb, mahdban);
            if (gridChiTietPhieuThu.RowCount == 0)
            {
                SetControlEnable_CTPT(true);
            }
        }
        private void gridChiTietPhieuThu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableChiTietPhieuThu();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctpt_nhapluoi = 0;
            FrmChiTietPhieuThu_Load(sender, e);
            ToolBarEnableChiTietPhieuThu(true);      
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ctpt_nhapluoi = 1;
            ToolBarEnableChiTietPhieuThu(false);
            if (gridChiTietPhieuThu.RowCount == 0)
            {
                gridChiTietPhieuThu.AllowUserToAddRows = true;
            }
            else
            {
                gridChiTietPhieuThu.AllowUserToAddRows = true;
                bindingCTPT.BindingSource.MoveLast();
            }
            gridChiTietPhieuThu.Rows[gridChiTietPhieuThu.RowCount - 1].Cells["ColMLHDB"].Value = malohdb;
            gridChiTietPhieuThu.Rows[gridChiTietPhieuThu.RowCount - 1].Cells["ColMHDB"].Value = mahdban;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridChiTietPhieuThu.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu thu này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value.ToString();
                bool xoa = CTPTBLL.XoaCTPT(malohdb, mahdban, mahang);
                LayDanhSachChiTietPhieuThu(malohdb, mahdban);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (ctpt_nhapluoi)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPT.Focus();
                            ChiTietPhieuThu CTPT = new ChiTietPhieuThu();
                            string mahang = gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value.ToString();
                            CTPT.NgayLap = System.Convert.ToDateTime(gridChiTietPhieuThu.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTPT.NguoiLap = (gridChiTietPhieuThu.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuThu.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTPT.NgaySua = System.Convert.ToDateTime(gridChiTietPhieuThu.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTPT.NguoiSua = (gridChiTietPhieuThu.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuThu.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool sua = CTPTBLL.SuaCTPT(malohdb, mahdban, mahang, CTPT);
                            LayDanhSachChiTietPhieuThu(malohdb, mahdban);
                            ToolBarEnableChiTietPhieuThu(true);
                        }
                        else
                        {
                            ToolBarEnableChiTietPhieuThu(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPT.Focus();
                            if (gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahang = gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietPhieuThu.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietPhieuThu.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietPhieuThu.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietPhieuThu.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietPhieuThu.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuThu.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietPhieuThu.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuThu.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool them = CTPTBLL.ThemCTPT(malohdb, mahdban, mahang, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuThu(malohdb, mahdban);
                            ToolBarEnableChiTietPhieuThu(true);
                            ctpt_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableChiTietPhieuThu(true);
                            ctpt_nhapluoi = 0;
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
                ctpt_nhapluoi = 0;
                LayDanhSachChiTietPhieuThu(malohdb, mahdban);
                ToolBarEnableChiTietPhieuThu(true);
            }
            else
            {
                ctpt_nhapluoi = 0;
                return;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Xử lý phần nhập tay
        private int ctpt_nhaptay = 0;

        private void SetConTrolToNull_CTPT()
        {
            txtMLHDB.Text = malohdb;
            txtMHDB.Text = mahdban;
            cmbMH.Text = "";
            dpiTienThu.Value = 0;
            dpNL.Value = DateTime.Now;
            cmbNL.Text = "";
            dpNS.Value = DateTime.Now;
            cmbNS.Text = "";
        }
        private void SetControlEnable_CTPT(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            cmbMH.Enabled = !status;
            dpiTienThu.Enabled = !status;
            dpNL.Enabled = !status;
            cmbNL.Enabled = !status;
            dpNS.Enabled = !status;
            cmbNS.Enabled = !status;
        }
        private void LoadDataToControl_CTPT(int dong)
        {
            if (gridChiTietPhieuThu.RowCount > 0 && ctpt_nhapluoi != 1)
            {
                txtMLHDB.Text = gridChiTietPhieuThu.Rows[dong].Cells["ColMLHDB"].Value.ToString();
                txtMHDB.Text = gridChiTietPhieuThu.Rows[dong].Cells["ColMHDB"].Value.ToString();
                cmbMH.SelectedValue = gridChiTietPhieuThu.Rows[dong].Cells["ColMH"].Value.ToString();
                dpiTienThu.Value = System.Convert.ToDouble(gridChiTietPhieuThu.Rows[dong].Cells["ColTT"].Value.ToString());
                dpNL.Value = System.Convert.ToDateTime(gridChiTietPhieuThu.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNL.Text = (gridChiTietPhieuThu.Rows[dong].Cells["ColNgL"].Value == null ? "" : gridChiTietPhieuThu.Rows[dong].Cells["ColNgL"].Value.ToString());
                dpNS.Value = System.Convert.ToDateTime(gridChiTietPhieuThu.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNS.Text = (gridChiTietPhieuThu.Rows[dong].Cells["ColNgS"].Value == null ? "" : gridChiTietPhieuThu.Rows[dong].Cells["ColNgS"].Value.ToString());
            }
        }
        private void gridChiTietPhieuThu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_CTPT(e.RowIndex);
            SetControlEnable_CTPT(true);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ctpt_nhaptay = 1;
            SetConTrolToNull_CTPT();
            SetControlEnable_CTPT(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_CTPT(false);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (ctpt_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ChiTietPhieuThu CTPT = new ChiTietPhieuThu();
                            string mahang = cmbMH.SelectedValue.ToString();
                            CTPT.NgayLap = dpNL.Value;
                            CTPT.NguoiLap = cmbNL.Text;
                            CTPT.NgaySua = dpNS.Value;
                            CTPT.NguoiSua = cmbNS.Text;
                            bool sua = CTPTBLL.SuaCTPT(malohdb, mahdban, mahang, CTPT);
                            LayDanhSachChiTietPhieuThu(malohdb, mahdban);
                            SetControlEnable_CTPT(true);
                        }
                        else
                        {
                            SetControlEnable_CTPT(true);
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
                            string malohdban = txtMLHDB.Text;
                            string mahdban = txtMHDB.Text;
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
                            bool them = CTPTBLL.ThemCTPT(malohdban, mahdban, mahang, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuThu(malohdb, mahdban);
                            SetControlEnable_CTPT(true);
                            ctpt_nhapluoi = 0;
                        }
                        else
                        {
                            ctpt_nhaptay = 0;
                            SetControlEnable_CTPT(true);
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
                LayDanhSachChiTietPhieuThu(malohdb, mahdban);
                SetControlEnable_CTPT(true);
                ctpt_nhaptay = 0;
            }
            else
            {
                ctpt_nhaptay = 0;
                return;
            }
        }
        private void XoaGridByButton()
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuThu.CurrentRow.Cells["ColMH"].Value.ToString();
                CTPTBLL.XoaCTPT(malohdb, mahdban, mahang);
                LayDanhSachChiTietPhieuThu(malohdb, mahdban);
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
                XoaGridByButton();
            }
        }
    }
}