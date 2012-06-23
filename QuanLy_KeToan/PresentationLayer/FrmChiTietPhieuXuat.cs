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
    public partial class FrmChiTietPhieuXuat : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietPhieuXuat()
        {
            InitializeComponent();
        }
        ChiTietPhieuXuatBLL CTPXBLL = new ChiTietPhieuXuatBLL();
        public string mahdban;
        public string malohdb;
        private void LoadHang(string malohdban)
        {
            ColMH.DataSource = CTPXBLL.LayMaHang(malohdban,mahdban);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";

            cmbMH.DataSource = CTPXBLL.LayMaHang(malohdban,mahdban);
            cmbMH.DisplayMember = "TenHang";
            cmbMH.ValueMember = "MaHang";
        }
        private void LoadKhoHang()
        {
            ColMKH.DataSource = CTPXBLL.LayKhoHang(malohdb);
            ColMKH.DisplayMember = "TenKhoHang";
            ColMKH.ValueMember = "MaKhoHang";
        }
        private void LayDanhSachChiTietPhieuXuat(string malohdban,string mahdban)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPXBLL.LayChiTietPhieuXuat(malohdban,mahdban);
            bindingCTPX.BindingSource = bds;
            gridChiTietPhieuXuat.DataSource = bds;
            gridChiTietPhieuXuat.AllowUserToAddRows = false;
        }
        private void LoadNguoiLap()
        {
            ColNgL.DataSource = CTPXBLL.LayNguoiLap();
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgL.ValueMember = "TenDangNhap";
            ColNgS.DataSource = CTPXBLL.LayNguoiLap();
            ColNgS.DisplayMember = "TenDangNhap";
            ColNgS.ValueMember = "TenDangNhap";
            ///
            cmbNL.DataSource = CTPXBLL.LayNguoiLap();
            cmbNL.DisplayMember = "TenDangNhap";
            cmbNL.ValueMember = "TenDangNhap";
            cmbNS.DataSource = CTPXBLL.LayNguoiLap();
            cmbNS.DisplayMember = "TenDangNhap";
            cmbNS.ValueMember = "TenDangNhap";
        }
        private void FrmChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadHang(malohdb);
            LoadKhoHang();
            LoadNguoiLap();
            LayDanhSachChiTietPhieuXuat(malohdb,mahdban);
            if (gridChiTietPhieuXuat.RowCount == 0)
            {
                SetControlEnable_CTPX(true);
            }
        }
        //Xử lý nhập lưới
        int ctpx_nhapluoi = 0;
        private void ToolBarEnableChiTietPhieuXuat(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
        }
        private void gridChiTietPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex>-1)
            {
                if (ctpx_nhapluoi == 1)
                {
                    gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].ReadOnly = false;
                }
                else
                    gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].ReadOnly = true;
                string name=gridChiTietPhieuXuat.Columns[e.ColumnIndex].Name;
                if (name == "ColMLHDB"||name=="ColMHDB"||name=="ColMKH")
                {
                    gridChiTietPhieuXuat.CurrentRow.Cells["ColMHDB"].Value = mahdban;
                    gridChiTietPhieuXuat.CurrentRow.Cells["ColMLHDB"].Value = malohdb;
                    gridChiTietPhieuXuat.CurrentRow.Cells["ColMKH"].Value = CTPXBLL.LayMaKhoHang(malohdb);
                }
                if (gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value!=null && name == "ColSL" && ctpx_nhapluoi ==1)
                {
                    gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value = CTPXBLL.LaySLHangTheoChiTietHDBan(malohdb, mahdban, gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value.ToString());
                }
            }
        }
        private void gridChiTietPhieuXuat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableChiTietPhieuXuat();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ctpx_nhapluoi = 0;
            FrmChiTietPhieuXuat_Load(sender, e);
            ToolBarEnableChiTietPhieuXuat(true);            
        }
        private void Add_Click(object sender, EventArgs e)
        {
            ctpx_nhapluoi = 1;
            ToolBarEnableChiTietPhieuXuat(false);
            if (gridChiTietPhieuXuat.RowCount == 0)
            {
                gridChiTietPhieuXuat.AllowUserToAddRows = true;
            }
            else
            {
                gridChiTietPhieuXuat.AllowUserToAddRows = true;
                bindingCTPX.BindingSource.MoveLast();
            }
            gridChiTietPhieuXuat.Rows[gridChiTietPhieuXuat.RowCount - 1].Cells["ColMLHDB"].Value = malohdb;
            gridChiTietPhieuXuat.Rows[gridChiTietPhieuXuat.RowCount - 1].Cells["ColMHDB"].Value = mahdban;
            gridChiTietPhieuXuat.Rows[gridChiTietPhieuXuat.RowCount - 1].Cells["ColMKH"].Value = CTPXBLL.LayMaKhoHang(malohdb);
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (gridChiTietPhieuXuat.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu nhập này không-Số Lượng hàng trong kho chứa sẽ bị giảm đi?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value.ToString();
                int sl = System.Convert.ToInt16(gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value);
                bool xoa = CTPXBLL.XoaCTPX(malohdb,mahdban, mahang);
                LayDanhSachChiTietPhieuXuat(malohdb,mahdban);
                if (xoa == true)
                {
                    CTPXBLL.CapNhatLaiKhoChuaKhiXoaCTPX(mahang, sl);
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            switch (ctpx_nhapluoi)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPX.Focus();
                            ChiTietPhieuXuat CTPX = new ChiTietPhieuXuat();
                            string mahang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value.ToString();
                            string makhohang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMKH"].Value.ToString();
                            CTPX.MaKhoHang = makhohang;
                            int sl = (gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            CTPX.SoLuong = sl;
                            CTPX.NgayLap = System.Convert.ToDateTime(gridChiTietPhieuXuat.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTPX.NguoiLap = (gridChiTietPhieuXuat.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuXuat.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTPX.NgaySua = System.Convert.ToDateTime(gridChiTietPhieuXuat.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTPX.NguoiSua = (gridChiTietPhieuXuat.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuXuat.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            CTPXBLL.CapNhatLaiKhoChua(mahang, sl);
                            bool sua = CTPXBLL.SuaCTPX(malohdb, mahdban, mahang, CTPX);
                            LayDanhSachChiTietPhieuXuat(malohdb, mahdban);
                            ToolBarEnableChiTietPhieuXuat(true);
                            if (sua == true)
                                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào " + makhohang + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            ToolBarEnableChiTietPhieuXuat(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTPX.Focus();
                            if (gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value.ToString();
                            string makhohang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMKH"].Value.ToString();
                            int sl = (gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietPhieuXuat.CurrentRow.Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietPhieuXuat.CurrentRow.Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietPhieuXuat.CurrentRow.Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietPhieuXuat.CurrentRow.Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietPhieuXuat.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietPhieuXuat.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietPhieuXuat.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietPhieuXuat.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool them = CTPXBLL.ThemCTPX(malohdb,mahdban, mahang, makhohang, sl, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuXuat(malohdb,mahdban);
                            ToolBarEnableChiTietPhieuXuat(true);
                            if (them == true)
                            {
                                CTPXBLL.CapNhatKhoChua(mahang, makhohang);
                            }
                            ctpx_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableChiTietPhieuXuat(true);
                            ctpx_nhapluoi = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctpx_nhapluoi = 0;
                LayDanhSachChiTietPhieuXuat(malohdb, mahdban);
                ToolBarEnableChiTietPhieuXuat(true);
            }
            else
            {
                ctpx_nhapluoi = 0;
                return;
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Xử lý phần nhập tay
        private int ctpx_nhaptay = 0;

        private void SetConTrolToNull_CTPX()
        {
            txtMLHDB.Text = malohdb;
            txtMHDB.Text = mahdban;
            cmbMH.Text = "";
            txtMKH.Text = CTPXBLL.LayMaKhoHang(malohdb);
            intSL.Value = 0;
            dpNL.Value = DateTime.Now;
            cmbNL.Text = "";
            dpNS.Value = DateTime.Now;
            cmbNS.Text = "";
        }
        private void SetControlEnable_CTPX(bool status)
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
        private void LoadDataToControl_CTPX(int dong)
        {
            if (gridChiTietPhieuXuat.RowCount > 0 && ctpx_nhapluoi != 1)
            {
                txtMLHDB.Text = gridChiTietPhieuXuat.Rows[dong].Cells["ColMLHDB"].Value.ToString();
                txtMHDB.Text = gridChiTietPhieuXuat.Rows[dong].Cells["ColMHDB"].Value.ToString();
                cmbMH.SelectedValue = gridChiTietPhieuXuat.Rows[dong].Cells["ColMH"].Value.ToString();
                txtMKH.Text = gridChiTietPhieuXuat.Rows[dong].Cells["ColMKH"].Value.ToString();
                intSL.Value = System.Convert.ToInt16(gridChiTietPhieuXuat.Rows[dong].Cells["ColSL"].Value.ToString());
                dpNL.Value = System.Convert.ToDateTime(gridChiTietPhieuXuat.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNL.Text = (gridChiTietPhieuXuat.Rows[dong].Cells["ColNgL"].Value == null ? "" : gridChiTietPhieuXuat.Rows[dong].Cells["ColNgL"].Value.ToString());
                dpNS.Value = System.Convert.ToDateTime(gridChiTietPhieuXuat.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNS.Text = (gridChiTietPhieuXuat.Rows[dong].Cells["ColNgS"].Value == null ? "" : gridChiTietPhieuXuat.Rows[dong].Cells["ColNgS"].Value.ToString());
            }
        }

        private void gridChiTietPhieuXuat_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_CTPX(e.RowIndex);
            SetControlEnable_CTPX(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ctpx_nhaptay = 1;
            SetConTrolToNull_CTPX();
            SetControlEnable_CTPX(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_CTPX(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (ctpx_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ChiTietPhieuXuat CTPX = new ChiTietPhieuXuat();
                            string mahang = cmbMH.SelectedValue.ToString();
                            string makhohang = txtMKH.Text;
                            CTPX.MaKhoHang = makhohang;
                            CTPX.SoLuong = intSL.Value;
                            CTPX.NgayLap = dpNL.Value;
                            CTPX.NguoiLap = cmbNL.Text;
                            CTPX.NgaySua = dpNS.Value;
                            CTPX.NguoiSua = cmbNS.Text;
                            CTPXBLL.CapNhatLaiKhoChua(mahang, intSL.Value);
                            bool sua = CTPXBLL.SuaCTPX(malohdb, mahdban, mahang, CTPX);
                            LayDanhSachChiTietPhieuXuat(malohdb, mahdban);
                            if (sua == true)
                                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào " + makhohang + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetControlEnable_CTPX(true);
                        }
                        else
                        {
                            SetControlEnable_CTPX(true);
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
                            bool them = CTPXBLL.ThemCTPX(malohdban, mahdban,mahang,makh,sl,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuXuat(malohdb, mahdban);
                            SetControlEnable_CTPX(true);
                            if (them == true)
                            {
                                CTPXBLL.CapNhatKhoChua(mahang, makh);
                            }
                            ctpx_nhapluoi = 0;
                        }
                        else
                        {
                            ctpx_nhaptay = 0;
                            SetControlEnable_CTPX(true);
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
                LayDanhSachChiTietPhieuXuat(malohdb, mahdban);
                SetControlEnable_CTPX(true);
                ctpx_nhaptay = 0;
            }
            else
            {
                ctpx_nhaptay = 0;
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
                string mahang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value.ToString();
                int sl = System.Convert.ToInt16(gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value);
                bool xoa = CTPXBLL.XoaCTPX(malohdb, mahdban, mahang);
                LayDanhSachChiTietPhieuXuat(malohdb, mahdban);
                if (xoa == true)
                {
                    CTPXBLL.CapNhatLaiKhoChuaKhiXoaCTPX(mahang, sl);
                }
            }
        }
        private void FrmChiTietPhieuXuat_KeyPress(object sender, KeyPressEventArgs e)
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