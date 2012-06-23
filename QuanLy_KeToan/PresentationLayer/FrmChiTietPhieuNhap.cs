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
    public partial class FrmChiTietPhieuNhap : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        ChiTietPhieuNhapBLL CTPNBLL = new ChiTietPhieuNhapBLL();
        public string mahdmua;
        public string malohdmua;
        private void LoadHang(string malohdmua,string mahdmua)
        {
            ColMH.DataSource = CTPNBLL.LayMaHang(malohdmua,mahdmua);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";

            cmbMH.DataSource = CTPNBLL.LayMaHang(malohdmua, mahdmua);
            cmbMH.DisplayMember = "TenHang";
            cmbMH.ValueMember = "MaHang";
        }
        private void LoadKhoHang()
        {
            ColMKH.DataSource = CTPNBLL.LayKhoHang(malohdmua);
            ColMKH.DisplayMember = "TenKhoHang";
            ColMKH.ValueMember = "MaKhoHang";
        }
        private void LayDanhSachChiTietPhieuNhap(string malohdmua,string mahdmua)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPNBLL.LayChiTietPhieuNhap(malohdmua,mahdmua);
            bindingCTPN.BindingSource = bds;
            gridChiTietPhieuNhap.DataSource = bds;
            gridChiTietPhieuNhap.AllowUserToAddRows = false;
        }
        private void LoadNguoiLap()
        {
            ColNgL.DataSource = CTPNBLL.LayNguoiLap();
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgL.ValueMember = "TenDangNhap";
            ColNgS.DataSource = CTPNBLL.LayNguoiLap();
            ColNgS.DisplayMember = "TenDangNhap";
            ColNgS.ValueMember = "TenDangNhap";
            ///
            cmbNL.DataSource = CTPNBLL.LayNguoiLap();
            cmbNL.DisplayMember = "TenDangNhap";
            cmbNL.ValueMember = "TenDangNhap";
            cmbNS.DataSource = CTPNBLL.LayNguoiLap();
            cmbNS.DisplayMember = "TenDangNhap";
            cmbNS.ValueMember = "TenDangNhap";
        }
        private void FrmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadHang(malohdmua,mahdmua);
            LoadKhoHang();
            LoadNguoiLap();
            LayDanhSachChiTietPhieuNhap(malohdmua,mahdmua);
            if (gridChiTietPhieuNhap.RowCount == 0)
            {
                SetControlEnable_CTPN(true);
            }
        }
        //Xử lý nhập lưới
        int ctpn_nhapluoi = 0;
        private void ToolBarEnableChiTietPhieuNhap(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
        }
        private void gridChiTietPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableChiTietPhieuNhap();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctpn_nhapluoi = 0;
            FrmChiTietPhieuNhap_Load(sender, e);
            ToolBarEnableChiTietPhieuNhap(true);
        }
        private void Add_Click(object sender, EventArgs e)
        {
            ctpn_nhapluoi = 1;
            ToolBarEnableChiTietPhieuNhap(false);
            if (gridChiTietPhieuNhap.RowCount == 0)
            {
                gridChiTietPhieuNhap.AllowUserToAddRows = true;
            }
            else
            {
                gridChiTietPhieuNhap.AllowUserToAddRows = true;
                bindingCTPN.BindingSource.MoveLast();
            }
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColMLHDM"].Value = malohdmua;
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColMHDM"].Value = mahdmua;
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColMKH"].Value = CTPNBLL.LayMaKhoHang(malohdmua);
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (gridChiTietPhieuNhap.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu nhập này không-Số Lượng hàng trong kho chứa sẽ bị giảm đi?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                int sl = System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value);
                bool xoa = CTPNBLL.XoaCTPN(malohdmua, mahdmua, mahang);
                LayDanhSachChiTietPhieuNhap(malohdmua, mahdmua);
                if (xoa == true)
                {
                    CTPNBLL.CapNhatLaiKhoChuaKhiXoaCTPN(mahang, sl);
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            switch (ctpn_nhapluoi)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPN.Focus();
                            ChiTietPhieuNhap CTPN = new ChiTietPhieuNhap();
                            string mahang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                            string makhohang=gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value.ToString();
                            CTPN.MaKhoHang = makhohang;
                            int sl = (gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            CTPN.SoLuong = sl;
                            CTPN.NgayLap = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTPN.NguoiLap = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTPN.NgaySua = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTPN.NguoiSua = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            CTPNBLL.CapNhatLaiKhoChua(mahang, sl);
                            bool sua=CTPNBLL.SuaCTPN(malohdmua,mahdmua,mahang,CTPN);
                            LayDanhSachChiTietPhieuNhap(malohdmua,mahdmua);
                            if(sua==true)
                                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào " + makhohang + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            PositionCTPN.Focus();
                            if (gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                            string makhohang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value.ToString();
                            int sl = (gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietPhieuNhap.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuNhap.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool them=CTPNBLL.ThemCTPN(malohdmua,mahdmua,mahang,makhohang,sl,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuNhap(malohdmua,mahdmua);
                            ctpn_nhapluoi = 0;
                            if (them == true)
                            {
                                CTPNBLL.CapNhatKhoChua(mahang, makhohang);
                            }
                        }
                        else
                        {
                            ctpn_nhapluoi = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void gridChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex>-1)
            {
                if (ctpn_nhapluoi == 1)
                {
                    gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].ReadOnly = false;
                }
                else
                    gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].ReadOnly = true;
                string name = gridChiTietPhieuNhap.Columns[e.ColumnIndex].Name;
                if (name == "ColMLHDM" || name == "ColMHDM" || name == "ColMKH")
                {
                    gridChiTietPhieuNhap.CurrentRow.Cells["ColMHDM"].Value = mahdmua;
                    gridChiTietPhieuNhap.CurrentRow.Cells["ColMLHDM"].Value = malohdmua;
                    gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value = CTPNBLL.LayMaKhoHang(malohdmua);
                }
                if (gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value != null && name == "ColSL" && ctpn_nhapluoi == 1)
                {
                    gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value = CTPNBLL.LaySLHangTheoChiTietHDMua(malohdmua, mahdmua, gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString());
                }
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctpn_nhapluoi = 0;
                LayDanhSachChiTietPhieuNhap(malohdmua,mahdmua);
                ToolBarEnableChiTietPhieuNhap(true);
            }
            else
            {
                ctpn_nhapluoi = 0;
                return;
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //Xử lý phần nhập tay
        private int ctpn_nhaptay = 0;

        private void SetConTrolToNull_CTPN()
        {
            txtMLHDM.Text = malohdmua;
            txtMHDM.Text = mahdmua;
            cmbMH.Text = "";
            txtMKH.Text = CTPNBLL.LayMaKhoHang(malohdmua);
            intSL.Value = 0;
            dpNL.Value = DateTime.Now;
            cmbNL.Text = "";
            dpNS.Value = DateTime.Now;
            cmbNS.Text = "";
        }
        private void SetControlEnable_CTPN(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            cmbMH.Enabled = !status;
            intSL.Enabled = !status;
            dpNL.Enabled = !status;
            cmbNL.Enabled = !status;
            dpNS.Enabled = !status;
            cmbNS.Enabled = !status;
        }
        private void LoadDataToControl_CTPN(int dong)
        {
            if (gridChiTietPhieuNhap.RowCount > 0 && ctpn_nhapluoi != 1)
            {
                txtMLHDM.Text = gridChiTietPhieuNhap.Rows[dong].Cells["ColMLHDM"].Value.ToString();
                txtMHDM.Text = gridChiTietPhieuNhap.Rows[dong].Cells["ColMHDM"].Value.ToString();
                cmbMH.Text = gridChiTietPhieuNhap.Rows[dong].Cells["ColMH"].Value.ToString();
                txtMKH.Text = gridChiTietPhieuNhap.Rows[dong].Cells["ColMKH"].Value.ToString();
                intSL.Value = System.Convert.ToInt16(gridChiTietPhieuNhap.Rows[dong].Cells["ColSL"].Value.ToString());
                dpNL.Value = System.Convert.ToDateTime(gridChiTietPhieuNhap.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNL.Text = (gridChiTietPhieuNhap.Rows[dong].Cells["ColNgL"].Value == null ? "" : gridChiTietPhieuNhap.Rows[dong].Cells["ColNgL"].Value.ToString());
                dpNS.Value = System.Convert.ToDateTime(gridChiTietPhieuNhap.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNS.Text = (gridChiTietPhieuNhap.Rows[dong].Cells["ColNgS"].Value == null ? "" : gridChiTietPhieuNhap.Rows[dong].Cells["ColNgS"].Value.ToString());
            }
        }

        private void gridChiTietPhieuNhap_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_CTPN(e.RowIndex);
            SetControlEnable_CTPN(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ctpn_nhaptay = 1;
            SetConTrolToNull_CTPN();
            SetControlEnable_CTPN(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_CTPN(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (ctpn_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ChiTietPhieuNhap CTPN = new ChiTietPhieuNhap();
                            string mahang = cmbMH.Text;
                            string makhohang = txtMKH.Text;
                            CTPN.MaKhoHang = makhohang;
                            CTPN.SoLuong = intSL.Value;
                            CTPN.NgayLap = dpNL.Value;
                            CTPN.NguoiLap = cmbNL.Text;
                            CTPN.NgaySua = dpNS.Value;
                            CTPN.NguoiSua = cmbNS.Text;
                            CTPNBLL.CapNhatLaiKhoChua(mahang, intSL.Value);
                            bool sua = CTPNBLL.SuaCTPN(malohdmua, mahdmua, mahang, CTPN);
                            LayDanhSachChiTietPhieuNhap(malohdmua, mahdmua);
                            if (sua == true)
                                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào " + makhohang + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetControlEnable_CTPN(true);
                        }
                        else
                        {
                            SetControlEnable_CTPN(true);
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
                            string mahang = cmbMH.Text;
                            string makh = txtMKH.Text;
                            int sl = intSL.Value;
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
                            bool them = CTPNBLL.ThemCTPN(malohdmua, mahdmua, mahang, makh, sl, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuNhap(malohdmua, mahdmua);
                            SetControlEnable_CTPN(true);
                            if (them == true)
                            {
                                CTPNBLL.CapNhatKhoChua(mahang, makh);
                            }
                            ctpn_nhapluoi = 0;
                        }
                        else
                        {
                            ctpn_nhaptay = 0;
                            SetControlEnable_CTPN(true);
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
                LayDanhSachChiTietPhieuNhap(malohdmua, mahdmua);
                SetControlEnable_CTPN(true);
                ctpn_nhaptay = 0;
            }
            else
            {
                ctpn_nhaptay = 0;
                return;
            }
        }
        //Thoát chương trình bằng ESC
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                OnKeyPress(new KeyPressEventArgs((Char)Keys.Escape));
            if (keyData == Keys.Delete)
                OnKeyPress(new KeyPressEventArgs((Char)Keys.Delete));
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void XoaGridByButton()
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString();
                int sl = System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value);
                bool xoa = CTPNBLL.XoaCTPN(malohdmua, mahdmua, mahang);
                LayDanhSachChiTietPhieuNhap(malohdmua, mahdmua);
                if (xoa == true)
                {
                    CTPNBLL.CapNhatLaiKhoChuaKhiXoaCTPN(mahang, sl);
                }
            }
        }
        private void FrmChiTietPhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
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
                XoaGridByButton();
            }
        }
    }
}