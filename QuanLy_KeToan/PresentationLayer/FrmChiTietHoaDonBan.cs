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
    public partial class FrmChiTietHoaDonBan : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietHoaDonBan()
        {
            InitializeComponent();
        }
        ChiTietHoaDonBanBLL CTHDBanBLL = new ChiTietHoaDonBanBLL();
        public string mahdban;
        public string malohdb;
        private void LoadHang(string malohdban)
        {
            ColMH.DataSource = CTHDBanBLL.LayMaHang(malohdban,mahdban);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";

            cmbMH.DataSource = CTHDBanBLL.LayMaHang(malohdban,mahdban);
            cmbMH.DisplayMember = "TenHang";
            cmbMH.ValueMember = "MaHang";
        }

        private void LayDanhSachChiTietHDBan(string malohdban,string mahdban)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTHDBanBLL.LayChiTietHoaDonBan(malohdban,mahdban);
            bindingCTHDBan.BindingSource = bds;
            gridChiTietHDBan.DataSource = bds;
            gridChiTietHDBan.AllowUserToAddRows = false;
        }
        private void LoadNguoiLap()
        {
            ColNgL.DataSource = CTHDBanBLL.LayNguoiLap();
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgL.ValueMember = "TenDangNhap";
            ColNgS.DataSource = CTHDBanBLL.LayNguoiLap();
            ColNgS.DisplayMember = "TenDangNhap";
            ColNgS.ValueMember = "TenDangNhap";
            ///
            cmbNL.DataSource = CTHDBanBLL.LayNguoiLap();
            cmbNL.DisplayMember = "TenDangNhap";
            cmbNL.ValueMember = "TenDangNhap";
            cmbNS.DataSource = CTHDBanBLL.LayNguoiLap();
            cmbNS.DisplayMember = "TenDangNhap";
            cmbNS.ValueMember = "TenDangNhap";
        }
        private void FrmChiTietHoaDonBan_Load_1(object sender, EventArgs e)
        {
            LoadHang(malohdb);
            LoadNguoiLap();
            LayDanhSachChiTietHDBan(malohdb, mahdban);
        }
        //Xử lý nhập lưới
        int cthdban_nhapluoi = 0;
        private void ToolBarEnableChiTietHDBan(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
        }
        private void gridChiTietHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (cthdban_nhapluoi == 1)
                {
                    gridChiTietHDBan.CurrentRow.Cells["ColMH"].ReadOnly = false;
                }
                else
                    gridChiTietHDBan.CurrentRow.Cells["ColMH"].ReadOnly = true;
                string name = gridChiTietHDBan.Columns[e.ColumnIndex].Name;
                if (name == "ColMLHDB" || name == "ColMHDB" || name == "ColMKH")
                {
                    gridChiTietHDBan.CurrentRow.Cells["ColMHDB"].Value = mahdban;
                    gridChiTietHDBan.CurrentRow.Cells["ColMLHDB"].Value = malohdb;

                }
            }
        }
        private void gridChiTietHDBan_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableChiTietHDBan();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cthdban_nhapluoi = 0;
            FrmChiTietHoaDonBan_Load_1(sender, e);
            ToolBarEnableChiTietHDBan(true);            
        }
        private void Add_Click(object sender, EventArgs e)
        {
            cthdban_nhapluoi = 1;
            ToolBarEnableChiTietHDBan(false);
            if (gridChiTietHDBan.RowCount == 0)
            {
                gridChiTietHDBan.AllowUserToAddRows = true;
            }
            else
            {
                gridChiTietHDBan.AllowUserToAddRows = true;
                bindingCTHDBan.BindingSource.MoveLast();
            }
            gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 1].Cells["ColMLHDB"].Value = malohdb;
            gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 1].Cells["ColMHDB"].Value = mahdban;

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (gridChiTietHDBan.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu nhập này không", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietHDBan.CurrentRow.Cells["ColMH"].Value.ToString();
                bool xoa = CTHDBanBLL.XoaCTHDBan(malohdb,mahdban, mahang);
                LayDanhSachChiTietHDBan(malohdb,mahdban);

            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            switch (cthdban_nhapluoi)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTHDBan.Focus();
                            ChiTietHDBan CTHDBan = new ChiTietHDBan();
                            string mahang = gridChiTietHDBan.CurrentRow.Cells["ColMH"].Value.ToString();
                            int sl = (gridChiTietHDBan.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietHDBan.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            CTHDBan.SoLuong = sl;
                            CTHDBan.ThanhToan = System.Convert.ToBoolean(gridChiTietHDBan.CurrentRow.Cells["ColThanhToan"].Value);
                            CTHDBan.NgayLap = System.Convert.ToDateTime(gridChiTietHDBan.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTHDBan.NguoiLap = (gridChiTietHDBan.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietHDBan.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTHDBan.NgaySua = System.Convert.ToDateTime(gridChiTietHDBan.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTHDBan.NguoiSua = (gridChiTietHDBan.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietHDBan.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            MessageBox.Show("Kiểm tra lại thông tin kho chứa trước khi cập nhật hóa đơn bán", "Kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bool capnhat=CTHDBanBLL.CapNhatLaiCTPXKhiThayDoiCTHDB(malohdb, mahdban, mahang, sl);
                            if (capnhat == true)
                            {
                                CTHDBanBLL.SuaCTHDBan(malohdb, mahdban, mahang, CTHDBan);
                                CTHDBanBLL.CapNhatCTPTKhiThayDoiCTHDB(malohdb, mahdban, mahang);
                            }
                            LayDanhSachChiTietHDBan(malohdb, mahdban);
                            ToolBarEnableChiTietHDBan(true);
                        }
                        else
                        {
                            ToolBarEnableChiTietHDBan(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTHDBan.Focus();
                            if (gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount-2].Cells["ColMH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahang = gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColMH"].Value.ToString();
                            int sl = (gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColSL"].Value.ToString()) : 0);
                            bool thanhtoan = System.Convert.ToBoolean(gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColThanhToan"].Value);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNgL"].Value != null ? gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNgS"].Value != null ? gridChiTietHDBan.Rows[gridChiTietHDBan.RowCount - 2].Cells["ColNgS"].Value.ToString() : "");
                            bool them = CTHDBanBLL.ThemCTHDBan(malohdb,mahdban, mahang, sl,thanhtoan, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietHDBan(malohdb,mahdban);
                            ToolBarEnableChiTietHDBan(true);
                            cthdban_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableChiTietHDBan(true);
                            cthdban_nhapluoi = 0;
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
                cthdban_nhapluoi = 0;
                LayDanhSachChiTietHDBan(malohdb, mahdban);
                ToolBarEnableChiTietHDBan(true);
            }
            else
            {
                cthdban_nhapluoi = 0;
                return;
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Xử lý phần nhập tay
        private int cthdban_nhaptay = 0;

        private void SetConTrolToNull_CTHDBan()
        {
            txtMLHDB.Text = malohdb;
            txtMHDB.Text = mahdban;
            cmbMH.Text = "";
            intSL.Value = 0;
            chkbThanhToan.Checked = false;
            dpNL.Value = DateTime.Now;
            cmbNL.Text = "";
            dpNS.Value = DateTime.Now;
            cmbNS.Text = "";
        }
        private void SetControlEnable_CTHDBan(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            cmbMH.Enabled = !status;
            intSL.Enabled = !status;
            chkbThanhToan.Enabled = !status;
            dpNL.Enabled = !status;
            cmbNL.Enabled = !status;
            dpNS.Enabled = !status;
            cmbNS.Enabled = !status;
        }
        private void LoadDataToControl_CTHDBan(int dong)
        {
            if (gridChiTietHDBan.RowCount > 0 && cthdban_nhapluoi != 1)
            {
                txtMLHDB.Text = gridChiTietHDBan.Rows[dong].Cells["ColMLHDB"].Value.ToString();
                txtMHDB.Text = gridChiTietHDBan.Rows[dong].Cells["ColMHDB"].Value.ToString();
                cmbMH.Text = gridChiTietHDBan.Rows[dong].Cells["ColMH"].Value.ToString();
                intSL.Value = System.Convert.ToInt16(gridChiTietHDBan.Rows[dong].Cells["ColSL"].Value.ToString());
                if (System.Convert.ToBoolean(gridChiTietHDBan.Rows[dong].Cells["ColThanhToan"].Value.ToString()) == true)
                {
                    chkbThanhToan.Checked = true;
                }
                else
                {
                    chkbThanhToan.Checked = false;
                }
                dpNL.Value = System.Convert.ToDateTime(gridChiTietHDBan.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNL.Text = (gridChiTietHDBan.Rows[dong].Cells["ColNgL"].Value == null ? "" : gridChiTietHDBan.Rows[dong].Cells["ColNgL"].Value.ToString());
                dpNS.Value = System.Convert.ToDateTime(gridChiTietHDBan.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNS.Text = (gridChiTietHDBan.Rows[dong].Cells["ColNgS"].Value == null ? "" : gridChiTietHDBan.Rows[dong].Cells["ColNgS"].Value.ToString());
            }
        }

        private void gridChiTietHDBan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_CTHDBan(e.RowIndex);
            SetControlEnable_CTHDBan(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cthdban_nhaptay = 1;
            SetConTrolToNull_CTHDBan();
            SetControlEnable_CTHDBan(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_CTHDBan(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (cthdban_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ChiTietHDBan CTHDBan = new ChiTietHDBan();
                            string mahang = cmbMH.SelectedValue.ToString();
                            CTHDBan.SoLuong = intSL.Value;
                            CTHDBan.ThanhToan = chkbThanhToan.Checked;
                            CTHDBan.NgayLap = dpNL.Value;
                            CTHDBan.NguoiLap = cmbNL.Text == "" ? "" : cmbNL.SelectedValue.ToString();
                            CTHDBan.NgaySua = dpNS.Value;
                            CTHDBan.NguoiSua = cmbNS.Text == "" ? "" : cmbNS.SelectedValue.ToString();
                            bool sua = CTHDBanBLL.SuaCTHDBan(malohdb, mahdban, mahang, CTHDBan);
                            LayDanhSachChiTietHDBan(malohdb, mahdban);
                            if (sua == true)
                                MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetControlEnable_CTHDBan(true);
                        }
                        else
                        {
                            SetControlEnable_CTHDBan(true);
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
                            int sl = intSL.Value;
                            bool thanhtoan = chkbThanhToan.Checked;
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
                            string nguoilap = cmbNL.Text == "" ? "" : cmbNL.SelectedValue.ToString();
                            string nguoisua = cmbNS.Text == "" ? "" : cmbNS.SelectedValue.ToString();
                            bool them = CTHDBanBLL.ThemCTHDBan(malohdban, mahdban,mahang,sl,thanhtoan,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietHDBan(malohdb, mahdban);
                            SetControlEnable_CTHDBan(true);
                            cthdban_nhapluoi = 0;
                        }
                        else
                        {
                            cthdban_nhaptay = 0;
                            SetControlEnable_CTHDBan(true);
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
                LayDanhSachChiTietHDBan(malohdb, mahdban);
                SetControlEnable_CTHDBan(true);
                cthdban_nhaptay = 0;
            }
            else
            {
                cthdban_nhaptay = 0;
                return;
            }
        }
    }
}