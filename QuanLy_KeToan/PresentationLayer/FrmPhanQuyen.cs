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
    public partial class FrmPhanQuyen : DevComponents.DotNetBar.Office2007Form
    {
        public FrmPhanQuyen()
        {
            InitializeComponent();
        }
        #region (Biến)
        private int xoa = 0;
        #endregion

        PhanQuyenBLL PQBLL = new PhanQuyenBLL();
        private void LayDanhSachNguoiDung()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PQBLL.LayDSNguoiDung();
            bindingPhanQuyen.BindingSource = bds;
            gridPhanQuyen.DataSource = bds;
            gridPhanQuyen.AllowUserToAddRows = false;
        }
        private void FrmPhanQuyen_Load(object sender, EventArgs e)
        {
            LayDanhSachNguoiDung();
        }
        //Nhập lưới
        private int nhapluoi = 0;

        private void ToolBarEnable(bool DangThaoTac = false)
        {
            btnAdd.Enabled = DangThaoTac;
            btnDelete.Enabled = DangThaoTac;
            btnCancel.Enabled = !DangThaoTac;
            btnRefresh.Enabled = DangThaoTac;
            btnSave.Enabled = !DangThaoTac;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmPhanQuyen_Load(sender, e);
            ToolBarEnable(true);
            nhapluoi = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            nhapluoi = 1;
            ToolBarEnable(false);
            if (gridPhanQuyen.RowCount == 0)
            {
                gridPhanQuyen.AllowUserToAddRows = true;
            }
            else
            {
                gridPhanQuyen.AllowUserToAddRows = true;
                bindingPhanQuyen.BindingSource.MoveLast();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridPhanQuyen.RowCount == 0)
                btnDelete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PQBLL.XoaNguoiDung(gridPhanQuyen.CurrentRow.Cells["ColTenDangNhap"].Value.ToString());
                LayDanhSachNguoiDung();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ToolBarEnable(true);
            switch (nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            position.Focus();
                            PhanQuyen PQ = new PhanQuyen();
                            string tendangnhap = gridPhanQuyen.CurrentRow.Cells["ColTenDangNhap"].Value.ToString();
                            PQ.MatKhau = gridPhanQuyen.CurrentRow.Cells["ColMatKhau"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColMatKhau"].Value.ToString() : "";
                            PQ.NgaySinh = System.Convert.ToDateTime(gridPhanQuyen.CurrentRow.Cells["ColNgaySinh"].Value.ToString());
                            PQ.HoTen = (gridPhanQuyen.CurrentRow.Cells["ColHoTen"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColHoTen"].Value.ToString() : "");
                            PQ.GioiTinh = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColGioiTinh"].Value);
                            PQ.ChucVu = gridPhanQuyen.CurrentRow.Cells["ColChucVu"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColChucVu"].Value.ToString() : "";
                            PQ.SoDT = gridPhanQuyen.CurrentRow.Cells["ColSoDT"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColSoDT"].Value.ToString() : "";
                            PQ.Email = gridPhanQuyen.CurrentRow.Cells["ColEmail"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColEmail"].Value.ToString() : "";
                            PQ.Them = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColThem"].Value);
                            PQ.Xoa = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColXoa"].Value);
                            PQ.Sua = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColSua"].Value);
                            PQBLL.SuaNguoiDung(tendangnhap,PQ);
                            LayDanhSachNguoiDung();
                            ToolBarEnable(true);
                        }
                        else
                        {
                            ToolBarEnable(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            position.Focus();
                            if (gridPhanQuyen.CurrentRow.Cells["ColTenDangNhap"].Value == null || gridPhanQuyen.CurrentRow.Cells["ColMatKhau"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string tendangnhap = gridPhanQuyen.CurrentRow.Cells["ColTenDangNhap"].Value.ToString();
                            string matkhau = gridPhanQuyen.CurrentRow.Cells["ColMatKhau"].Value.ToString();
                            string hoten = (gridPhanQuyen.CurrentRow.Cells["ColHoTen"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColHoTen"].Value.ToString() : "");
                            DateTime ngaysinh;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridPhanQuyen.CurrentRow.Cells["ColNgaySinh"].Value) != temp)
                            {
                                ngaysinh = System.Convert.ToDateTime(gridPhanQuyen.CurrentRow.Cells["ColNgaySinh"].Value);
                            }
                            else
                            {
                                ngaysinh = DateTime.Now.Date;
                            }
                            bool gioitinh = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColGioiTinh"].Value);
                            string chucvu= (gridPhanQuyen.CurrentRow.Cells["ColChucVu"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColChucVu"].Value.ToString() : "");
                            string sodt = gridPhanQuyen.CurrentRow.Cells["ColSoDT"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColSoDT"].Value.ToString() : "";
                            string email = gridPhanQuyen.CurrentRow.Cells["ColEmail"].Value != null ? gridPhanQuyen.CurrentRow.Cells["ColEmail"].Value.ToString() : "";
                            bool them = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColThem"].Value);
                            bool xoa = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColXoa"].Value);
                            bool sua = System.Convert.ToBoolean(gridPhanQuyen.CurrentRow.Cells["ColSua"].Value);
                            PQBLL.ThemNguoiDung(tendangnhap, matkhau, hoten, ngaysinh, gioitinh, chucvu, sodt, email, them, xoa, sua);
                            LayDanhSachNguoiDung();
                            ToolBarEnable(true);
                            nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnable(true);
                            nhapluoi = 0;
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
                nhapluoi = 0;
                LayDanhSachNguoiDung();
                ToolBarEnable(true);
            }
            else
            {
                nhapluoi = 0;
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridPhanQuyen_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnable();
        }
        private void gridPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (nhapluoi == 1)
                    gridPhanQuyen.CurrentRow.Cells["ColTenDangNhap"].ReadOnly = false;
                else
                    gridPhanQuyen.CurrentRow.Cells["ColTenDangNhap"].ReadOnly = true;
            }
        }
        //Code phần nhập tay
        private int nhaptay = 0;

        private void SetConTrolToNull()
        {
            txtTenDN.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            dpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = false;
            rdNu.Checked = false;
            cmbChucVu.Text = "";
            txtSoDT.Text = "";
            txtEmail.Text = "";
            chkThem.Checked = false;
            chkXoa.Checked = false;
            chkSua.Checked = false;
        }
        private void SetControlEnable(bool status)
        {
            try
            {
                buttonThem.Enabled = status;
                buttonSua.Enabled = status;
                buttonLuu.Enabled = !status;
                buttonHuy.Enabled = !status;
                txtTenDN.Enabled = !status;
                txtMatKhau.Enabled = !status;
                txtHoTen.Enabled = !status;
                dpNgaySinh.Enabled = !status;
                rdNam.Enabled = !status;
                rdNu.Enabled = !status;
                cmbChucVu.Enabled = !status;
                txtSoDT.Enabled = !status;
                txtEmail.Enabled = !status;
                chkThem.Enabled = !status;
                chkSua.Enabled = !status;
                chkXoa.Enabled = !status;
            }
            catch {}            
        }
        private void LoadDataToControl(int dong)
        {
            if (gridPhanQuyen.RowCount > 0 && nhapluoi != 1)
            {
                txtTenDN.Text = gridPhanQuyen.Rows[dong].Cells["ColTenDangNhap"].Value.ToString();
                txtMatKhau.Text = gridPhanQuyen.Rows[dong].Cells["ColMatKhau"].Value.ToString();
                txtHoTen.Text = gridPhanQuyen.Rows[dong].Cells["ColHoTen"].Value==null?"":gridPhanQuyen.Rows[dong].Cells["ColHoTen"].Value.ToString();
                dpNgaySinh.Value = System.Convert.ToDateTime(gridPhanQuyen.Rows[dong].Cells["ColNgaySinh"].Value.ToString());
                if (System.Convert.ToBoolean(gridPhanQuyen.Rows[dong].Cells["ColGioiTinh"].Value) == true)
                    rdNam.Checked = true;
                else
                    rdNu.Checked = true;
                cmbChucVu.Text = gridPhanQuyen.Rows[dong].Cells["ColChucVu"].Value==null?"":gridPhanQuyen.Rows[dong].Cells["ColChucVu"].Value.ToString();
                txtSoDT.Text = gridPhanQuyen.Rows[dong].Cells["ColSoDT"].Value == null ? "" : gridPhanQuyen.Rows[dong].Cells["ColSoDT"].Value.ToString();
                txtEmail.Text = gridPhanQuyen.Rows[dong].Cells["ColEmail"].Value == null ? "" : gridPhanQuyen.Rows[dong].Cells["ColEmail"].Value.ToString();
                chkThem.Checked = System.Convert.ToBoolean(gridPhanQuyen.Rows[dong].Cells["ColThem"].Value);
                chkXoa.Checked = System.Convert.ToBoolean(gridPhanQuyen.Rows[dong].Cells["ColXoa"].Value);
                chkSua.Checked = System.Convert.ToBoolean(gridPhanQuyen.Rows[dong].Cells["ColSua"].Value);
             }
        }
        private void gridPhanQuyen_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl(e.RowIndex);
            SetControlEnable(true);
        }

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            nhaptay = 1;
            SetControlEnable(false);
            SetConTrolToNull();
            buttonThem.Enabled = false;
            buttonSua.Enabled = false;
        }
        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            SetControlEnable(false);
            buttonThem.Enabled = false;
            buttonSua.Enabled = false;
            txtTenDN.Enabled = false;
        }
        private void buttonLuu_Click_1(object sender, EventArgs e)
        {
            switch (nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PhanQuyen PQ = new PhanQuyen();
                            string tendangnhap = txtTenDN.Text;
                            PQ.MatKhau = txtMatKhau.Text;
                            PQ.HoTen = txtHoTen.Text;
                            PQ.NgaySinh = dpNgaySinh.Value;
                            if (rdNam.Checked == true)
                                PQ.GioiTinh = true;
                            else
                                PQ.GioiTinh = false;
                            PQ.ChucVu = cmbChucVu.Text == "" ? "" : cmbChucVu.SelectedValue.ToString();
                            PQ.SoDT = txtSoDT.Text;
                            PQ.Email = txtEmail.Text;
                            PQ.Them = chkThem.Checked;
                            PQ.Xoa = chkXoa.Checked;
                            PQ.Sua = chkSua.Checked;
                            PQBLL.SuaNguoiDung(tendangnhap, PQ);
                            LayDanhSachNguoiDung();
                            SetControlEnable(true);
                        }
                        else
                        {
                            SetControlEnable(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (txtTenDN.Text == "" || txtMatKhau.Text == "" || txtHoTen.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string tendangnhap = txtTenDN.Text;
                            string matkhau = txtMatKhau.Text;
                            string hoten = txtHoTen.Text;
                            DateTime ngaysinh;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (dpNgaySinh.Value != temp)
                            {
                                ngaysinh = System.Convert.ToDateTime(dpNgaySinh.Value);
                            }
                            else
                            {
                                ngaysinh = DateTime.Now.Date;
                            }
                            bool gioitinh = false;
                            if (rdNam.Checked == true)
                                gioitinh = true;
                            if (rdNu.Checked == true)
                                gioitinh = false;
                            string chucvu = cmbChucVu.Text == "" ? "" : cmbChucVu.SelectedValue.ToString();
                            string sodt = txtSoDT.Text;
                            string email = txtEmail.Text;
                            bool them = chkThem.Checked;
                            bool xoa = chkXoa.Checked;
                            bool sua = chkSua.Checked;
                            PQBLL.ThemNguoiDung(tendangnhap, matkhau, hoten, ngaysinh, gioitinh, chucvu,
                                                sodt, email, them, xoa, sua);
                            LayDanhSachNguoiDung();
                            nhaptay = 0;
                            SetControlEnable(true);
                        }
                        else
                        {
                            nhaptay = 0;
                            SetControlEnable(true);
                            return;
                        }
                        break;
                    }
            }
        }
        private void buttonHuy_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachNguoiDung();
                SetControlEnable(true);
                nhaptay = 0;
            }
            else
            {
                nhaptay = 0;
                return;
            }
        }
        //delegate void SetColumnIndex(int i);
        //private void Mymethod(int columnIndex)
        //{
        //    gridPhanQuyen.CurrentCell = gridPhanQuyen.CurrentRow.Cells[columnIndex];
        //    gridPhanQuyen.BeginEdit(true);
        //}

        //private void gridPhanQuyen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (gridPhanQuyen.CurrentCell.ColumnIndex != gridPhanQuyen.Columns.Count - 1)
        //    {
        //        int nextindex = Math.Min(gridPhanQuyen.Columns.Count - 1, gridPhanQuyen.CurrentCell.ColumnIndex + 1);

        //        SetColumnIndex method = new SetColumnIndex(Mymethod);

        //        gridPhanQuyen.BeginInvoke(method, nextindex);

        //    }
        //}
    }
}