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
#region (Hàm dùng chung)
        //Hàm Load các combobox
        private void LoadCmbNguoiLap()
        {
            //Loại phiếu thu
            cmbNguoiLap.DataSource = LPTBLL.LayNguoiLap();
            cmbNguoiLap.ValueMember = "TenDangNhap";
            cmbNguoiLap.DisplayMember = "TenDangNhap";
            cmbNguoiSua.DataSource = LPTBLL.LayNguoiLap();
            cmbNguoiSua.DisplayMember = "TenDangNhap";
            cmbNguoiSua.ValueMember = "TenDangNhap";
            //Lô phiếu thu
            comboNguoiLap.DataSource = LPTBLL.LayNguoiLap();
            comboNguoiLap.DisplayMember = "TenDangNhap";
            comboNguoiLap.ValueMember = "TenDangNhap";
            comboNguoiSua.DataSource = LPTBLL.LayNguoiLap();
            comboNguoiSua.DisplayMember = "TenDangNhap";
            comboNguoiSua.ValueMember = "TenDangNhap";
            //Phiếu thu
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
        }
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

        private void FrmQuanLyThu_Load(object sender, EventArgs e)
        {
            //LoadTreeView();
            LoadComboboxColumnNguoiLap();
            LoadCmbNguoiLap();
            LayDanhSachLoaiPT();
            LayDanhSachLoPT();
            AnHienGroup(groupLoaiPhieuThu, groupLoPhieuThu, groupPhieuThu);
        }

#endregion
#region (Code phần Loại phiếu thu)
        LoaiPhieuThuBLL LPTBLL = new LoaiPhieuThuBLL();
        private void LayDanhSachLoaiPT()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPTBLL.LayDanhSachLoaiPhieuThu();
            gridLoaiPhieuThu.DataSource = bds;
            bindingLoaiPhieuThu.BindingSource = bds;
            gridLoaiPhieuThu.AllowUserToAddRows = false;
        }
        private void tabItemLoaiPhieuThu_Click(object sender, EventArgs e)
        {
            LayDanhSachLoaiPT();
            AnHienGroup(groupLoaiPhieuThu, groupLoPhieuThu, groupPhieuThu);
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
            tabItemLoaiPhieuThu_Click(sender, e);
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
                            LPT.TenLoaiPhieuThu = gridLoaiPhieuThu.CurrentRow.Cells["ColTLPT"].Value.ToString();
                            LPT.NgayLap = System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNL"].Value.ToString());
                            LPT.NguoiLap = (gridLoaiPhieuThu.CurrentRow.Cells["ColNgL"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColNgL"].Value.ToString() : "");
                            LPT.NgaySua = System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNS"].Value.ToString());
                            LPT.NguoiSua = (gridLoaiPhieuThu.CurrentRow.Cells["ColNgS"].Value != null ? gridLoaiPhieuThu.CurrentRow.Cells["ColNgS"].Value.ToString() : "");
                            LPTBLL.SuaLoaiPhieuThu(maloaiphieuthu, LPT);
                            LayDanhSachLoaiPT();
                        }
                        else
                            return;
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
                            lpt_nhapluoi = 0;
                        }
                        else
                        {
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
            this.Dispose();
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
            txtMaLoaiPhieuThu.Clear();
            txtTenLoaiPhieuThu.Clear();
            dateTimeInputNgayLap.Value = DateTime.Now;
            cmbNguoiLap.Text = "";
            dateTimeInputNgaySua.Value = DateTime.Now;
            cmbNguoiSua.Text = "";
        }
        
        private void SetControlEnable_LoaiPhieuThu(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            txtMaLoaiPhieuThu.ReadOnly = status;
            txtTenLoaiPhieuThu.ReadOnly = status;
            dateTimeInputNgayLap.Enabled = !status;
            cmbNguoiLap.Enabled = !status;
            dateTimeInputNgaySua.Enabled = !status;
            cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_LoaiPhieuThu(int dong)
        {
            if (gridLoaiPhieuThu.RowCount > 0 && lpt_nhapluoi != 1)
            {
                txtMaLoaiPhieuThu.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColMLPT"].Value.ToString();
                txtTenLoaiPhieuThu.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColTLPT"].Value.ToString();
                dateTimeInputNgayLap.Value = System.Convert.ToDateTime(gridLoaiPhieuThu.Rows[dong].Cells["ColNL"].Value.ToString());
                cmbNguoiLap.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColNgL"].Value.ToString();
                dateTimeInputNgaySua.Value = System.Convert.ToDateTime(gridLoaiPhieuThu.Rows[dong].Cells["ColNS"].Value.ToString());
                cmbNguoiSua.Text = gridLoaiPhieuThu.Rows[dong].Cells["ColNgS"].Value.ToString();
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
                            string maloaiphieuthu = txtMaLoaiPhieuThu.Text;
                            LPT.TenLoaiPhieuThu = txtTenLoaiPhieuThu.Text;
                            LPT.NgayLap = dateTimeInputNgayLap.Value;
                            LPT.NguoiLap = cmbNguoiLap.SelectedValue.ToString();
                            LPT.NgaySua = dateTimeInputNgaySua.Value;
                            LPT.NguoiSua = cmbNguoiSua.SelectedValue.ToString();
                            LPTBLL.SuaLoaiPhieuThu(maloaiphieuthu, LPT);
                            LayDanhSachLoaiPT();
                            SetControlEnable_LoaiPhieuThu(true);
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
                            if (txtMaLoaiPhieuThu.Text == "" || txtTenLoaiPhieuThu.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maloaiphieuthu = txtMaLoaiPhieuThu.Text;
                            string tenloaiphieuthu = txtTenLoaiPhieuThu.Text;
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (dateTimeInputNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(dateTimeInputNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (dateTimeInputNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(dateTimeInputNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = cmbNguoiLap.SelectedValue.ToString();
                            string nguoisua = cmbNguoiSua.SelectedValue.ToString();
                            LPTBLL.ThemLoaiPhieuThu(maloaiphieuthu, tenloaiphieuthu, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPT();
                            lpt_nhaptay = 0;
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
                return;
        }
# endregion
#region (Code hần Lô phiếu thu)

        LoPhieuThuBLL LoPTBLL = new LoPhieuThuBLL();

        private void LayDanhSachLoPT()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LoPTBLL.LayDanhSachLoPhieuThu();
            bindingLoPhieuThu.BindingSource = bds;
            gridLoPhieuThu.DataSource = bds;
            gridLoPhieuThu.AllowUserToAddRows = false;
        }
        //Nhập lưới
        int lopt_nhapluoi = 0;
        private void ToolBarEnableLoPhieuThu(bool DangThaoTac = false)
        {
            LoPT_Add.Enabled = DangThaoTac;
            LoPT_Delete.Enabled = DangThaoTac;
            LoPT_Cancel.Enabled = !DangThaoTac;
            LoPT_Refresh.Enabled = DangThaoTac;
            LoPT_Save.Enabled = !DangThaoTac;
        }
        private void LoPT_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                LoPTBLL.XoaLPT(gridLoPhieuThu.CurrentRow.Cells["ColMLT"].Value.ToString());
                LayDanhSachLoPT();
            }
        }

        private void LoPT_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPT();
                ToolBarEnableLoPhieuThu(true);
                lopt_nhapluoi = 0;
            }
            else
            {

                lopt_nhapluoi = 0;
                return;
            }
        }

        private void LoPT_Refresh_Click(object sender, EventArgs e)
        {
            LayDanhSachLoPT();
            ToolBarEnableLoPhieuThu(true);
            lopt_nhapluoi = 0;
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
                            string malothu = gridLoPhieuThu.CurrentRow.Cells["ColMLT"].Value.ToString();
                            LPT.NgayThu = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["ColNT"].Value.ToString());
                            LPT.MoTa = (gridLoPhieuThu.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LPT.NgayLap = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LPT.NguoiLap = (gridLoPhieuThu.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LPT.NgaySua = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LPT.NguoiSua = (gridLoPhieuThu.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuThu.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LoPTBLL.SuaLoPT(malothu, LPT);
                            LayDanhSachLoPT();
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuThu.Focus();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (gridLoPhieuThu.CurrentRow.Cells["ColMLT"].Value == null || System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["ColNT"].Value) == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malothu = gridLoPhieuThu.CurrentRow.Cells["ColMLT"].Value.ToString();
                            DateTime ngaythu;
                            ngaythu = System.Convert.ToDateTime(gridLoPhieuThu.CurrentRow.Cells["ColNT"].Value);
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
                            LoPTBLL.ThemLoPT(malothu, ngaythu, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPT();
                            lopt_nhapluoi = 0;
                        }
                        else
                        {
                            lopt_nhapluoi = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void tabItemLoPhieuThu_Click(object sender, EventArgs e)
        {
            LayDanhSachLoPT();
            AnHienGroup(groupLoPhieuThu, groupLoaiPhieuThu, groupPhieuThu);
        }

        private void gridLoPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (lopt_nhapluoi == 1)
                {
                    gridLoPhieuThu.CurrentRow.Cells["ColMLT"].ReadOnly = false;
                }
                else
                {
                    gridLoPhieuThu.CurrentRow.Cells["ColMLT"].ReadOnly = true;
                }
            }
        }
        private void gridLoPhieuThu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableLoPhieuThu();
        }
        //Code phần nhập tay
        private int lopt_nhaptay = 0;

        private void SetConTrolToNull_LoPhieuThu()
        {
            txtMaLoThu.Clear();
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
            txtMaLoThu.ReadOnly = status;
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
                txtMaLoThu.Text = gridLoPhieuThu.Rows[dong].Cells["ColMLT"].Value.ToString();
                dpNgayThu.Value = System.Convert.ToDateTime(gridLoPhieuThu.Rows[dong].Cells["ColNT"].Value.ToString());
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
                return;
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
                            positionLoPhieuThu.Focus();
                            LoPhieuThu LoPT = new LoPhieuThu();
                            string malophieuthu = txtMaLoThu.Text;
                            LoPT.NgayThu = dpNgayThu.Value;
                            LoPT.MoTa = txtMota.Text;
                            LoPT.NgayLap = dpNgayLap.Value;
                            LoPT.NguoiLap = comboNguoiLap.SelectedValue.ToString();
                            LoPT.NgaySua = dpNgaySua.Value;//System.Convert.ToDateTime(gridLoaiPhieuThu.CurrentRow.Cells["ColNS"].Value.ToString());
                            LoPT.NguoiSua = comboNguoiSua.SelectedValue.ToString();
                            LoPTBLL.SuaLoPT(malophieuthu, LoPT);
                            LayDanhSachLoPT();
                            SetControlEnable_LoPhieuThu(true);
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
                            positionLoPhieuThu.Focus();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (txtMaLoThu.Text == "" || dpNgayThu.Value == temp)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string malophieuthu = txtMaLoThu.Text;
                            DateTime ngaythu = dpNgayThu.Value;
                            string mota = txtMota.Text;
                            string tenloaiphieuthu = txtTenLoaiPhieuThu.Text;
                            DateTime ngaylap;
                            if (dateTimeInputNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(dateTimeInputNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (dateTimeInputNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(dateTimeInputNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (comboNguoiLap.SelectedValue.ToString());
                            string nguoisua = (comboNguoiSua.SelectedValue.ToString());
                            LoPTBLL.ThemLoPT(malophieuthu, ngaythu, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPT();
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
        //PhieuThuBLL PNBLL = new PhieuThuBLL();  

        //#region "Xử lý TreeView"
        //private void LoadTreeView()
        //{
        //    //advTreeLoThu.DataSource = LTBLL.LayDanhSachMaLoNhap();
        //    foreach (var item in LTBLL.LayDanhSachMaLoNhap())
        //    {
        //        DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
        //        foreach (DevComponents.AdvTree.Node n in advTreeLoThu.Nodes[0].Nodes)
        //        {
        //            if (n.Name == "nodeLoPhieuThu")
        //                n.Nodes.Add(childnode);
        //        }
        //    }
        //}
        //private void advTreeLoThu_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        //{
        //    //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
        //    if (e.Node.Level == 0)
        //        return;
        //    //Node Loại phiếu Thu
        //    if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
        //    {
        //        groupPanelLoaiPhieuThu.BringToFront();
        //    }
        //    //Node Lô Phiếu Thu
        //    else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
        //    {
        //        groupPanelLoPhieuThu.BringToFront();
        //        LayMaLoaiHang();
        //        LayDanhSachLoPT();
        //    }
        //    else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
        //    {
        //        LayMaLoaiPT();
        //        LayMaNCC();
        //        groupPanelPhieuThu.BringToFront();
        //        string malo = xuly_chuoi(e.Node.Text);
        //        LayDSPhieuThuTheoLo(malo);
        //    }
        //}
        //private string xuly_chuoi(string chuoi)
        //{
        //    int vt = chuoi.IndexOf("=");
        //    int vt1 = chuoi.IndexOf(",");
        //    string s1 = chuoi.Substring(vt + 1, vt1 - vt - 1).Trim();
        //    return s1;
        //}
        //# endregion

        //private void LayMaLoaiPT()
        //{
        //    MLPT.DataSource = PNBLL.LayMaLoaiPhieuThu();
        //    MLPT.DisplayMember = "TenLoaiPhieuThu";
        //    MLPT.ValueMember = "MaLoaiPhieuThu";
        //}
        //private void LayMaNCC()
        //{
        //    MNCC.DataSource = PNBLL.LayMaNCC();
        //    MNCC.DisplayMember = "TenNCC";
        //    MNCC.ValueMember = "MaNCC";
          
        //}
        //private void LayDSPhieuThuTheoLo(string malo)
        //{
        //    BindingSource bds = new BindingSource();
        //    bds.DataSource = PNBLL.LayDSPhieuThu(malo);
        //    bindingPhieuThu.BindingSource = bds;
        //    gridPhieuThu.DataSource = bds;
        //    gridPhieuThu.AllowUserToAddRows = false;
        //}
        //private void PN_Exit_Click(object sender, EventArgs e)
        //{
        //    this.Dispose();
        //}
        //int th_pn = 0;
        //private void PN_Add_Click(object sender, EventArgs e)
        //{
        //    th_pn = 1;
        //    gridPhieuThu.AllowUserToAddRows = true;
        //    bindingPhieuThu.BindingSource.MoveLast();
        //}

        //private void PN_Delete_Click(object sender, EventArgs e)
        //{
        //    //MessageBox.Show(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        //    // Nếu data gridview không có dòng nào
        //    if (gridPhieuThu.RowCount == 0)
        //        PN_Delete.Enabled = false;
        //    else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
        //        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        string maphieunhap = gridPhieuThu.CurrentRow.Cells["MPN"].Value.ToString();
        //        string malothu = gridPhieuThu.CurrentRow.Cells["MLN"].Value.ToString();
        //        PNBLL.XoaPN(maphieunhap,malothu);
        //        LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        //    }
        //}

        //private void PN_Save_Click(object sender, EventArgs e)
        //{
        //    switch (th_pn)
        //    {
        //        case 0://Sửa
        //            {
        //                if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
        //                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                {
        //                    positionPhieuThu.Focus();
        //                    PhieuThu PN = new PhieuThu();
        //                    string maphieunhap = gridPhieuThu.CurrentRow.Cells["MPN"].Value.ToString();
        //                    string malothu = gridPhieuThu.CurrentRow.Cells["MLN"].Value.ToString();
        //                    PN.MaLoaiPhieuThu = gridPhieuThu.CurrentRow.Cells["MLPT"].Value.ToString();
        //                    PN.MaNCC = gridPhieuThu.CurrentRow.Cells["MNCC"].Value.ToString();
        //                    PN.NgayPhieuThu = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["NPN"].Value.ToString());
        //                    PN.MoTa = (gridPhieuThu.CurrentRow.Cells["MT"].Value != null ? gridPhieuThu.CurrentRow.Cells["MT"].Value.ToString() : "");
        //                    PN.NgayLap = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NL"].Value.ToString());
        //                    PN.NguoiLap = (gridPhieuThu.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgL"].Value.ToString() : "");
        //                    PN.NgaySua = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NS"].Value.ToString());
        //                    PN.NguoiSua = (gridPhieuThu.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgS"].Value.ToString() : "");
        //                    PNBLL.SuaPN(maphieunhap,malothu,PN);
        //                    LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        //                }
        //                else
        //                    return;
        //                break;
        //            }
        //        case 1://Thêm
        //            {
        //                if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
        //                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                {
        //                    positionPhieuThu.Focus();
        //                    string maphieunhap = gridPhieuThu.CurrentRow.Cells["MPN"].Value.ToString();
        //                    string maloaiphieuthu = gridPhieuThu.CurrentRow.Cells["MLPT"].Value.ToString();
        //                    string malothu = gridPhieuThu.CurrentRow.Cells["MLN"].Value.ToString();
        //                    string mncc = gridPhieuThu.CurrentRow.Cells["MNCC"].Value.ToString();
        //                    DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
        //                    DateTime ngayphieunhap;
        //                    if (System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["NPN"].Value) != temp)
        //                    {
        //                        ngayphieunhap = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["NPN"].Value);
        //                    }
        //                    else
        //                    {
        //                        ngayphieunhap = DateTime.Now.Date;
        //                    }
        //                    string mota = (gridPhieuThu.CurrentRow.Cells["MT"].Value != null ? gridPhieuThu.CurrentRow.Cells["MT"].Value.ToString() : "");
        //                    DateTime ngaylap;
        //                    if (System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NL"].Value) != temp)
        //                    {
        //                        ngaylap = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NL"].Value);
        //                    }
        //                    else
        //                    {
        //                        ngaylap = DateTime.Now.Date;
        //                    }
        //                    DateTime ngaysua;
        //                    if (System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NS"].Value) != temp)
        //                    {
        //                        ngaysua = System.Convert.ToDateTime(gridPhieuThu.CurrentRow.Cells["_NS"].Value);
        //                    }
        //                    else
        //                    {
        //                        ngaysua = DateTime.Now.Date;
        //                    }
        //                    string nguoilap = (gridPhieuThu.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgL"].Value.ToString() : "");
        //                    string nguoisua = (gridPhieuThu.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuThu.CurrentRow.Cells["_NgS"].Value.ToString() : "");
        //                    PNBLL.ThemPhieuThu(maphieunhap, maloaiphieuthu, malothu, mncc, ngayphieunhap, mota, ngaylap, nguoilap, ngaysua, nguoisua);
        //                    LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        //                    th_pn = 0;
        //                }
        //                else
        //                {
        //                    th_pn = 0;
        //                    return;
        //                }

        //                break;
        //            }
        //    }
        //}

        //private void PN_Cancel_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Hủy thao tác?", "CANCEL",
        //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        //    }
        //    else
        //        return;
        //}

        //private void PN_Refresh_Click(object sender, EventArgs e)
        //{
        //    LayDSPhieuThuTheoLo(xuly_chuoi(advTreeLoThu.SelectedNode.Text));
        //}
        //private void gridPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        if (th_pn == 1)
        //        {
        //            gridPhieuThu.CurrentRow.Cells["MPN"].ReadOnly = false;
        //            gridPhieuThu.CurrentRow.Cells["MLN"].Value = xuly_chuoi(advTreeLoThu.SelectedNode.Text);
        //        }
        //        string name = gridPhieuThu.Columns[e.ColumnIndex].Name;
        //        if (name == "MPN")
        //        {
        //            if (gridPhieuThu.CurrentRow.Cells["MPN"].Value != null)
        //            {
        //                FrmChiTietPhieuThu CTPN = new FrmChiTietPhieuThu();
        //                CTPN.maphieunhap = gridPhieuThu.CurrentRow.Cells["MPN"].Value.ToString();
        //                CTPN.id_patch = xuly_chuoi(advTreeLoThu.SelectedNode.Text);
        //                CTPN.Show();
        //            }
        //            else
        //                return;
        //        }
        //    }
        //}
        private void tabItemNhapKho_Click(object sender, EventArgs e)
        {
            AnHienGroup(groupPhieuThu, groupLoaiPhieuThu, groupLoPhieuThu);
        }
#endregion             
    }
}