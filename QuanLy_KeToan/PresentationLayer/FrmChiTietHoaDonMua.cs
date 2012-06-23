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
    public partial class FrmChiTietHoaDonMua : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietHoaDonMua()
        {
            InitializeComponent();
        }
        ChiTietHoaDonMuaBLL CTHDMuaBLL = new ChiTietHoaDonMuaBLL();
        public string mahdmua;
        public string malohdm;
        private void LoadHang(string malohdmua)
        {
            ColMH.DataSource = CTHDMuaBLL.LayMaHang(malohdmua);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";

            cmbMH.DataSource = CTHDMuaBLL.LayMaHang(malohdmua);
            cmbMH.DisplayMember = "TenHang";
            cmbMH.ValueMember = "MaHang";
        }

        private void LayDanhSachChiTietHDMua(string malohdmua,string mahdmua)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTHDMuaBLL.LayChiTietHoaDonMua(malohdmua,mahdmua);
            bindingCTHDMua.BindingSource = bds;
            gridChiTietHDMua.DataSource = bds;
            gridChiTietHDMua.AllowUserToAddRows = false;
        }
        private void LoadNguoiLap()
        {
            ColNgL.DataSource = CTHDMuaBLL.LayNguoiLap();
            ColNgL.DisplayMember = "TenDangNhap";
            ColNgL.ValueMember = "TenDangNhap";
            ColNgS.DataSource = CTHDMuaBLL.LayNguoiLap();
            ColNgS.DisplayMember = "TenDangNhap";
            ColNgS.ValueMember = "TenDangNhap";
            ///
            cmbNL.DataSource = CTHDMuaBLL.LayNguoiLap();
            cmbNL.DisplayMember = "TenDangNhap";
            cmbNL.ValueMember = "TenDangNhap";
            cmbNS.DataSource = CTHDMuaBLL.LayNguoiLap();
            cmbNS.DisplayMember = "TenDangNhap";
            cmbNS.ValueMember = "TenDangNhap";
        }
        private void FrmChiTietHoaDonMua_Load(object sender, EventArgs e)
        {
            LoadHang(malohdm);
            LoadNguoiLap();
            LayDanhSachChiTietHDMua(malohdm, mahdmua);
        }

        //Xử lý nhập lưới
        int cthdmua_nhapluoi = 0;
        private void ToolBarEnableChiTietHDMua(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
        }
        private void gridChiTietHDMua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (cthdmua_nhapluoi == 1)
                {
                    gridChiTietHDMua.CurrentRow.Cells["ColMH"].ReadOnly = false;
                }
                else
                    gridChiTietHDMua.CurrentRow.Cells["ColMH"].ReadOnly = true;
                string name = gridChiTietHDMua.Columns[e.ColumnIndex].Name;
                if (name == "ColMLHDM" || name == "ColMHDM" || name == "ColMKH")
                {
                    gridChiTietHDMua.CurrentRow.Cells["ColMHDM"].Value = mahdmua;
                    gridChiTietHDMua.CurrentRow.Cells["ColMLHDM"].Value = malohdm;
                }
            }
        }
        private void gridChiTietHDMua_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableChiTietHDMua();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cthdmua_nhapluoi = 0;
            FrmChiTietHoaDonMua_Load(sender, e);
            ToolBarEnableChiTietHDMua(true);            
        }
        private void Add_Click(object sender, EventArgs e)
        {
            cthdmua_nhapluoi = 1;
            ToolBarEnableChiTietHDMua(false);
            if (gridChiTietHDMua.RowCount == 0)
            {
                gridChiTietHDMua.AllowUserToAddRows = true;
            }
            else
            {
                gridChiTietHDMua.AllowUserToAddRows = true;
                bindingCTHDMua.BindingSource.MoveLast();
            }
            gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 1].Cells["ColMLHDM"].Value = malohdm;
            gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 1].Cells["ColMHDM"].Value = mahdmua;

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (gridChiTietHDMua.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu nhập này không", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahang = gridChiTietHDMua.CurrentRow.Cells["ColMH"].Value.ToString();
                bool xoa = CTHDMuaBLL.XoaCTHDMua(malohdm,mahdmua, mahang);
                LayDanhSachChiTietHDMua(malohdm,mahdmua);

            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            switch (cthdmua_nhapluoi)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTHDMua.Focus();
                            ChiTietHDMua CTHDMua = new ChiTietHDMua();
                            string mahang = gridChiTietHDMua.CurrentRow.Cells["ColMH"].Value.ToString();
                            int sl = (gridChiTietHDMua.CurrentRow.Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietHDMua.CurrentRow.Cells["ColSL"].Value.ToString()) : 0);
                            CTHDMua.SoLuong = sl;
                            CTHDMua.ThanhToan = System.Convert.ToBoolean(gridChiTietHDMua.CurrentRow.Cells["ColThanhToan"].Value);
                            CTHDMua.NgayLap = System.Convert.ToDateTime(gridChiTietHDMua.CurrentRow.Cells["ColNL"].Value.ToString());
                            CTHDMua.NguoiLap = (gridChiTietHDMua.CurrentRow.Cells["ColNgL"].Value != null ? gridChiTietHDMua.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            CTHDMua.NgaySua = System.Convert.ToDateTime(gridChiTietHDMua.CurrentRow.Cells["ColNS"].Value.ToString());
                            CTHDMua.NguoiSua = (gridChiTietHDMua.CurrentRow.Cells["ColNgS"].Value != null ? gridChiTietHDMua.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            bool sua = CTHDMuaBLL.SuaCTHDMua(malohdm, mahdmua, mahang, CTHDMua);
                            LayDanhSachChiTietHDMua(malohdm, mahdmua);
                            ToolBarEnableChiTietHDMua(true);
                            if (sua == true)
                                MessageBox.Show("Cập nhật thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            ToolBarEnableChiTietHDMua(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PositionCTHDMua.Focus();
                            if (gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount-2].Cells["ColMH"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string mahang = gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColMH"].Value.ToString();
                            int sl = (gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColSL"].Value != null ? System.Convert.ToInt16(gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColSL"].Value.ToString()) : 0);
                            bool thanhtoan = System.Convert.ToBoolean(gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColThanhToan"].Value);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNgL"].Value != null ? gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNgL"].Value.ToString() : "");
                            string nguoisua = (gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNgS"].Value != null ? gridChiTietHDMua.Rows[gridChiTietHDMua.RowCount - 2].Cells["ColNgS"].Value.ToString() : "");
                            bool them = CTHDMuaBLL.ThemCTHDMua(malohdm,mahdmua, mahang, sl,thanhtoan, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietHDMua(malohdm,mahdmua);
                            ToolBarEnableChiTietHDMua(true);
                            cthdmua_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableChiTietHDMua(true);
                            cthdmua_nhapluoi = 0;
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
                cthdmua_nhapluoi = 0;
                LayDanhSachChiTietHDMua(malohdm, mahdmua);
                ToolBarEnableChiTietHDMua(true);
            }
            else
            {
                cthdmua_nhapluoi = 0;
                return;
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Xử lý phần nhập tay
        private int cthdmua_nhaptay = 0;

        private void SetConTrolToNull_CTHDMua()
        {
            txtMLHDM.Text = malohdm;
            txtMHDM.Text = mahdmua;
            cmbMH.Text = "";
            intSL.Value = 0;
            chkbThanhToan.Checked = false;
            dpNL.Value = DateTime.Now;
            cmbNL.Text = "";
            dpNS.Value = DateTime.Now;
            cmbNS.Text = "";
        }
        private void SetControlEnable_CTHDMua(bool status)
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
        private void LoadDataToControl_CTHDMua(int dong)
        {
            if (gridChiTietHDMua.RowCount > 0 && cthdmua_nhapluoi != 1)
            {
                txtMLHDM.Text = gridChiTietHDMua.Rows[dong].Cells["ColMLHDM"].Value.ToString();
                txtMHDM.Text = gridChiTietHDMua.Rows[dong].Cells["ColMHDM"].Value.ToString();
                cmbMH.Text = gridChiTietHDMua.Rows[dong].Cells["ColMH"].Value.ToString();
                intSL.Value = System.Convert.ToInt16(gridChiTietHDMua.Rows[dong].Cells["ColSL"].Value);
                if (System.Convert.ToBoolean(gridChiTietHDMua.Rows[dong].Cells["ColThanhToan"].Value.ToString()) == true)
                {
                    chkbThanhToan.Checked = true;
                }
                else
                {
                    chkbThanhToan.Checked = false;
                }
                dpNL.Value = System.Convert.ToDateTime(gridChiTietHDMua.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNL.Text = (gridChiTietHDMua.Rows[dong].Cells["ColNgL"].Value == null ? "" : gridChiTietHDMua.Rows[dong].Cells["ColNgL"].Value.ToString());
                dpNS.Value = System.Convert.ToDateTime(gridChiTietHDMua.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNS.Text = (gridChiTietHDMua.Rows[dong].Cells["ColNgS"].Value == null ? "" : gridChiTietHDMua.Rows[dong].Cells["ColNgS"].Value.ToString());
            }
        }
        private void gridChiTietHDMua_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_CTHDMua(e.RowIndex);
            SetControlEnable_CTHDMua(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cthdmua_nhaptay = 1;
            SetConTrolToNull_CTHDMua();
            SetControlEnable_CTHDMua(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_CTHDMua(false);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (cthdmua_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ChiTietHDMua CTHDMua = new ChiTietHDMua();
                            string mahang = cmbMH.SelectedValue.ToString();
                            CTHDMua.SoLuong = intSL.Value;
                            CTHDMua.ThanhToan = chkbThanhToan.Checked;
                            CTHDMua.NgayLap = dpNL.Value;
                            CTHDMua.NguoiLap = cmbNL.Text==""?"":cmbNL.SelectedValue.ToString();
                            CTHDMua.NgaySua = dpNS.Value;
                            CTHDMua.NguoiSua = cmbNS.Text==""?"":cmbNS.SelectedValue.ToString();
                            bool sua = CTHDMuaBLL.SuaCTHDMua(malohdm, mahdmua, mahang, CTHDMua);
                            LayDanhSachChiTietHDMua(malohdm, mahdmua);
                            SetControlEnable_CTHDMua(true);
                        }
                        else
                        {
                            SetControlEnable_CTHDMua(true);
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
                            bool them = CTHDMuaBLL.ThemCTHDMua(malohdmua, mahdmua,mahang,sl,thanhtoan,ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietHDMua(malohdm, mahdmua);
                            SetControlEnable_CTHDMua(true);
                            cthdmua_nhapluoi = 0;
                        }
                        else
                        {
                            cthdmua_nhaptay = 0;
                            SetControlEnable_CTHDMua(true);
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
                LayDanhSachChiTietHDMua(malohdm, mahdmua);
                SetControlEnable_CTHDMua(true);
                cthdmua_nhaptay = 0;
            }
            else
            {
                cthdmua_nhaptay = 0;
                return;
            }
        }
    }
}