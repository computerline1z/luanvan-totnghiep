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
    public partial class FrmKetSoXuatNhapKho : DevComponents.DotNetBar.Office2007Form
    {
        public FrmKetSoXuatNhapKho()
        {
            InitializeComponent();
        }
#region (Biến)
        private int xoa = 0;
        #endregion
#region (Hàm dùng chung)
        KetSoXuatNhapKhoBLL KSXNKBLL = new KetSoXuatNhapKhoBLL();
        //Hàm Load các combobox
        private void LoadCmbNguoiLap()
        {
            cmbNguoiLap.DataSource = KSXNKBLL.LayNguoiLap();
            cmbNguoiLap.DisplayMember = "TenDangNhap";
            cmbNguoiLap.ValueMember = "TenDangNhap";
            cmbNguoiSua.DataSource = KSXNKBLL.LayNguoiLap();
            cmbNguoiSua.DisplayMember = "TenDangNhap";
            cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        private void LoadComboboxColumnNguoiLap()
        {
            NguoiLap.DataSource = KSXNKBLL.LayNguoiLap();
            NguoiLap.ValueMember = "TenDangNhap";
            NguoiLap.DisplayMember = "TenDangNhap";
            NguoiSua.DataSource = KSXNKBLL.LayNguoiLap();
            NguoiSua.ValueMember = "TenDangNhap";
            NguoiSua.DisplayMember = "TenDangNhap";
        }
        public void LoadThang()
        {
            for (int i = 1; i <= 12; i++)
            {
                Thang.Items.Add(i);
            }
        }
        public void LoadNam()
        {
            for (int i = 2012; i <= 2030; i++)
            {
                Nam.Items.Add(i);
                cmbNam.Items.Add(i);
                toolstripNam.Items.Add(i);
            }
        }
        public void LoadKhoHang()
        {
            toolStripKhoHang.ComboBox.DataSource = KSXNKBLL.LayKhoHang();
            toolStripKhoHang.ComboBox.ValueMember = "MaKhoHang";
            toolStripKhoHang.ComboBox.DisplayMember = "TenKhoHang";
            cmbMaKhoHang.DataSource = KSXNKBLL.LayKhoHang();
            cmbMaKhoHang.ValueMember = "MaKhoHang";
            cmbMaKhoHang.DisplayMember = "TenKhoHang";
        }
        public void LoadHang()
        {
            MaHang.DataSource = KSXNKBLL.LayHang();
            MaHang.DisplayMember = "MaHang";
            MaHang.ValueMember = "MaHang";
        }
        private void LoadDanhSachKetSoNhapXuat(string makho,int nam)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KSXNKBLL.LayDSKetSoXuatNhapKho(makho,nam);
            gridKetSoXNK.DataSource = bds;
            bindingKetSoXNK.BindingSource = bds;
            gridKetSoXNK.AllowUserToAddRows = false;
        }
        private void FrmKetSoThuChi_Load(object sender, EventArgs e)
        {
            LoadThang();
            LoadNam();
            LoadCmbNguoiLap();
            LoadComboboxColumnNguoiLap();
            LoadKhoHang();
            LoadHang();
            toolstripNam.Focus();
            if (gridKetSoXNK.RowCount == 0)
                SetControlEnable_KSXNK(true);
        }
        #endregion
#region (Xử lý nhập lưới)
        private int ksxnk_nhapluoi = 0;

        private void ToolBarEnableXuatNhapKho(bool DangThaoTac = false)
        {
            KSNX_Add.Enabled = DangThaoTac;
            KSNX_Delete.Enabled = DangThaoTac;
            KSNX_Cancel.Enabled = !DangThaoTac;
            KSNX_Refresh.Enabled = DangThaoTac;
            KSNX_Save.Enabled = !DangThaoTac;
        }
        private void KSNX_Add_Click(object sender, EventArgs e)
        {
            if (toolstripNam.Text == "")
            {
                MessageBox.Show("Chọn tháng,năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ksxnk_nhapluoi = 1;
            ToolBarEnableXuatNhapKho(false);
            progressbar.Minimum = 0;
            progressbar.Maximum = 0;
            if (gridKetSoXNK.RowCount == 0)
            {
                gridKetSoXNK.AllowUserToAddRows = true;
            }
            else
            {
                gridKetSoXNK.AllowUserToAddRows = true;
                bindingKetSoXNK.BindingSource.MoveLast();

            }
            gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 1].Cells["Nam"].Value = int.Parse(toolstripNam.Text);
        }
        private void KSNX_Refresh_Click(object sender, EventArgs e)
        {
            LoadDanhSachKetSoNhapXuat(toolStripKhoHang.ComboBox.SelectedValue.ToString(), System.Convert.ToInt16(toolstripNam.Text));
            ToolBarEnableXuatNhapKho(true);
            ksxnk_nhapluoi = 0;
        }
        private void KSTC_Save_Click(object sender, EventArgs e)
        {
            ToolBarEnableXuatNhapKho(true);
            switch (ksxnk_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionKSXNK.Focus();
                            KetSoXuatNhapKho KSXNK = new KetSoXuatNhapKho();
                            int thang = System.Convert.ToInt16(gridKetSoXNK.CurrentRow.Cells["Thang"].Value.ToString());
                            int nam = System.Convert.ToInt16(toolstripNam.Text);
                            string mahang = gridKetSoXNK.CurrentRow.Cells["MaHang"].Value.ToString();
                            KSXNK.NgayLap = System.Convert.ToDateTime(gridKetSoXNK.CurrentRow.Cells["NgayLap"].Value.ToString());
                            KSXNK.NguoiLap = (gridKetSoXNK.CurrentRow.Cells["NguoiLap"].Value != null ? gridKetSoXNK.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            KSXNK.NgaySua = System.Convert.ToDateTime(gridKetSoXNK.CurrentRow.Cells["NgaySua"].Value.ToString());
                            KSXNK.NguoiSua = (gridKetSoXNK.CurrentRow.Cells["NguoiSua"].Value != null ? gridKetSoXNK.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            KSXNKBLL.Sua(thang, nam,mahang,KSXNK);
                            LoadDanhSachKetSoNhapXuat(toolStripKhoHang.ComboBox.SelectedValue.ToString(),nam);
                            ToolBarEnableXuatNhapKho(true);
                        }
                        else
                        {
                            ToolBarEnableXuatNhapKho(true);
                            return;
                        }
                        break;
                    }
                case 1://Thêm
                    {
                        positionKSXNK.Focus();
                        if(gridKetSoXNK.CurrentRow.Cells["Thang"].Value==null || gridKetSoXNK.CurrentRow.Cells["MaHang"].Value==null)
                        {
                            MessageBox.Show("Nhập thiếu thông tin","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                        int thang = System.Convert.ToInt16(gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["Thang"].Value.ToString());
                        int nam = System.Convert.ToInt16(toolstripNam.Text);
                        string makhohang = toolStripKhoHang.ComboBox.SelectedValue.ToString();
                        string mahang=gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["MaHang"].Value.ToString();
                        if (MessageBox.Show("Kết sổ Mã hàng: " + mahang + " Tháng " + thang + "/" + nam + " ?", "Kết sổ nhập xuất theo tháng",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            progressbar.Minimum = 1;
                            progressbar.Step = 100;
                            progressbar.Maximum = 100;
                            progressbar.PerformStep();
                            int sldauthang = KSXNKBLL.SLDauThang(thang, nam,mahang);
                            int tongnhap = KSXNKBLL.TongNhap(thang, nam,mahang);
                            int tongxuat = KSXNKBLL.TongXuat(thang, nam,mahang);
                            int slcuoithang = KSXNKBLL.SLCuoiThang(thang, nam,mahang);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NguoiLap"].Value != null ? gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NguoiLap"].Value != null ? gridKetSoXNK.Rows[gridKetSoXNK.RowCount - 2].Cells["NguoiLap"].Value.ToString() : "");
                            bool them = KSXNKBLL.LuuThem(thang,nam,mahang,sldauthang,tongnhap,tongxuat,slcuoithang,ngaylap, nguoilap, ngaysua, nguoisua);
                            if (them == true)
                            {
                                progressbar.Maximum = 100;
                            }
                            LoadDanhSachKetSoNhapXuat(makhohang,nam);
                            ToolBarEnableXuatNhapKho(true);
                            ksxnk_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableXuatNhapKho(true);
                            ksxnk_nhapluoi = 0;
                            return;
                        }
                        break;
                    }
            }
        }
        private void LoadKSTCQuy()
        {
            thang1.Text = "";
            thang2.Text = "";
            thang3.Text = "";
            thang4.Text = "";
            thang5.Text = "";
            thang6.Text = "";
            thang7.Text = "";
            thang8.Text = "";
            thang9.Text = "";
            thang10.Text = "";
            thang11.Text = "";
            thang12.Text = "";
            Tong1.Text = "";
            Tong2.Text = "";
            Tong3.Text = "";
            Tong4.Text = "";
            XThang1.Text = "";
            XThang2.Text = "";
            XThang3.Text = "";
            XThang4.Text = "";
            XThang5.Text = "";
            XThang6.Text = "";
            XThang7.Text = "";
            XThang8.Text = "";
            XThang9.Text = "";
            XThang10.Text = "";
            XThang11.Text = "";
            XThang12.Text = "";
            XTong1.Text = "";
            XTong2.Text = "";
            XTong3.Text = "";
            XTong4.Text = "";
            KSXNKBLL.KetSoThuChiQuyNhapXuat(toolStripKhoHang.ComboBox.SelectedValue.ToString(),int.Parse(toolstripNam.Text), thang1, thang2, thang3, thang4, thang5, thang6, thang7, thang8, thang9, thang10, thang11, thang12,XThang1,XThang2,XThang3,XThang4
            ,XThang5,XThang6,XThang7,XThang8,XThang9,XThang10,XThang11,XThang12,Tong1, Tong2, Tong3, Tong4,XTong1,XTong2,XTong3,XTong4);
        }
        private void toolstripNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelX1.Text = "";
            labelX1.Text = "KẾT SỔ NHẬP XUẤT THEO QUÝ NĂM " + toolstripNam.Text;
            int nam = int.Parse(toolstripNam.Text);
            string makho = toolStripKhoHang.ComboBox.SelectedValue.ToString();
            LoadDanhSachKetSoNhapXuat(makho,nam);
            LoadKSTCQuy();
        }
        private void KSNX_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ksxnk_nhapluoi = 0;
                LoadDanhSachKetSoNhapXuat(toolStripKhoHang.ComboBox.SelectedValue.ToString(), int.Parse(toolstripNam.Text));
                ToolBarEnableXuatNhapKho(true);
            }
            else
            {
                ksxnk_nhapluoi = 0;
                return;
            }
        }
        private void gridKetSoXNK_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableXuatNhapKho();
        }
        private void gridKetSoXNK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (gridKetSoXNK.Columns[e.ColumnIndex].Name == "Nam")
                        gridKetSoXNK.CurrentRow.Cells["Nam"].Value = int.Parse(toolstripNam.Text);
                }
                if (ksxnk_nhapluoi == 1)
                {
                    gridKetSoXNK.CurrentRow.Cells["Thang"].ReadOnly = false;
                    gridKetSoXNK.CurrentRow.Cells["MaHang"].ReadOnly = false;
                }
                else
                {
                    gridKetSoXNK.CurrentRow.Cells["Thang"].ReadOnly = true;
                    gridKetSoXNK.CurrentRow.Cells["MaHang"].ReadOnly = true;
                }
            }
            catch { }
        }
        private void KSNX_Delete_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(toolstripNam.Text);
            string mahang = gridKetSoXNK.CurrentRow.Cells["MaHang"].Value.ToString();
            if (MessageBox.Show("Xóa dữ liệu kết sổ nhập xuất Mã hàng: " + mahang + " Năm "+nam+" k ?", "DELETE",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolstripNam.Text == "")
                {
                    MessageBox.Show("Chọn tháng,năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string makho = toolStripKhoHang.ComboBox.SelectedValue.ToString();
                progressbar.Minimum = 0;
                progressbar.Maximum = 0;
                KSXNKBLL.XoaKSXNK(nam,mahang, progressbar);
                LoadDanhSachKetSoNhapXuat(makho,nam);
            }
        }
        private void KSNX_update_Click(object sender, EventArgs e)
        {
            if (toolstripNam.Text == "")
            {
                MessageBox.Show("Chọn Năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gridKetSoXNK.CurrentRow.Cells["MaHang"].Value == null)
            {
                MessageBox.Show("Chọn Mã Hàng cần cập nhật", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nam = int.Parse(toolstripNam.Text);
            string mahang = gridKetSoXNK.CurrentRow.Cells["MaHang"].Value.ToString();
            if (MessageBox.Show("Cập nhật dữ liệu kết sổ nhập xuất Mã hàng: " + mahang + " Năm " + nam + " ?", "UPDATE",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string makho = toolStripKhoHang.ComboBox.SelectedValue.ToString();
                progressbar.Minimum = 0;
                progressbar.Maximum = 0;
                KSXNKBLL.LuuCapNhat(nam, mahang, progressbar);
                LoadDanhSachKetSoNhapXuat(makho, nam);
            }
        }
#endregion
#region(Xử lý nhập tay)
        private int ksxnk_nhaptay = 0;

        private void cmbMaKhoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMaHang.DataSource = KSXNKBLL.LayHangTheoMaKhoHang(cmbMaKhoHang.SelectedValue.ToString());
            cmbMaHang.DisplayMember = "MaHang";
            cmbMaHang.ValueMember = "MaHang";
        }
        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbThang.Items.Clear();
            cmbThang.Text = "";
            int nam = int.Parse(cmbNam.Text);
            string mahang=cmbMaHang.SelectedValue.ToString();
            KSXNKBLL.LayThangTheoNam(nam,mahang,cmbThang);
        }
        private void SetConTrolToNull_KSXNK()
        {
            cmbMaKhoHang.Text = "";
            cmbMaHang.Text = "";
            cmbNam.Text = "";
            cmbThang.Text = "";
            dpSLDauThang.Value = 0;
            dpSLNhap.Value = 0;
            dpSLXuat.Value = 0;
            dpSLCuoiThang.Value = 0;
            dpNgayLap.Value = DateTime.Now;
            cmbNguoiLap.Text = "";
            dpNgaySua.Value = DateTime.Now;
            cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_KSXNK(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            cmbMaKhoHang.Enabled = !status;
            cmbMaHang.Enabled = !status;
            cmbNam.Enabled = !status;
            cmbThang.Enabled = !status;
            dpNgayLap.Enabled = !status;
            cmbNguoiLap.Enabled = !status;
            dpNgaySua.Enabled = !status;
            cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_KSXNK(int dong)
        {
            if (gridKetSoXNK.RowCount > 0 && ksxnk_nhapluoi != 1)
            {
                cmbMaKhoHang.Text = toolStripKhoHang.Text;
                cmbMaHang.Text = gridKetSoXNK.Rows[dong].Cells["MaHang"].Value.ToString();
                cmbNam.Text = gridKetSoXNK.Rows[dong].Cells["Nam"].Value.ToString();
                cmbThang.Text = gridKetSoXNK.Rows[dong].Cells["Thang"].Value.ToString();
                dpSLDauThang.Text = gridKetSoXNK.Rows[dong].Cells["SLDauThang"].Value.ToString();
                dpSLNhap.Text = gridKetSoXNK.Rows[dong].Cells["TongNhap"].Value.ToString();
                dpSLXuat.Text = gridKetSoXNK.Rows[dong].Cells["TongXuat"].Value.ToString();
                dpSLCuoiThang.Text = dpSLNhap.Text = gridKetSoXNK.Rows[dong].Cells["SLCuoiThang"].Value.ToString();
                dpNgayLap.Value = System.Convert.ToDateTime(gridKetSoXNK.Rows[dong].Cells["NgayLap"].Value.ToString());
                cmbNguoiLap.Text = gridKetSoXNK.Rows[dong].Cells["NguoiLap"].Value == null ? "" : gridKetSoXNK.Rows[dong].Cells["NguoiLap"].Value.ToString();
                dpNgaySua.Value = System.Convert.ToDateTime(gridKetSoXNK.Rows[dong].Cells["NgaySua"].Value.ToString());
                cmbNguoiSua.Text = gridKetSoXNK.Rows[dong].Cells["NguoiSua"].Value == null ? "" : gridKetSoXNK.Rows[dong].Cells["NguoiSua"].Value.ToString();
            }
        }
        private void gridKetSoXNK_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_KSXNK(e.RowIndex);
            SetControlEnable_KSXNK(true);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ksxnk_nhaptay = 1;
            SetConTrolToNull_KSXNK();
            SetControlEnable_KSXNK(false);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_KSXNK(false);
            cmbMaKhoHang.Enabled = false;
            cmbMaHang.Enabled = false;
            cmbNam.Enabled = false;
            cmbThang.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (ksxnk_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            KetSoXuatNhapKho KSXNK = new KetSoXuatNhapKho();
                            int nam = int.Parse(cmbNam.Text);
                            int thang = int.Parse(cmbThang.Text);
                            string mahang = cmbMaHang.SelectedValue.ToString();
                            string makhohang = cmbMaKhoHang.SelectedValue.ToString();
                            KSXNK.NgayLap = dpNgayLap.Value;
                            KSXNK.NguoiLap = cmbNguoiLap.Text;
                            KSXNK.NgaySua = dpNgaySua.Value;
                            KSXNK.NguoiSua = cmbNguoiSua.Text;
                            KSXNKBLL.Sua(thang, nam,mahang,KSXNK);
                            LoadDanhSachKetSoNhapXuat(makhohang,nam);
                            SetControlEnable_KSXNK(true);
                        }
                        else
                        {
                            SetControlEnable_KSXNK(true);
                            return;
                        }
                        break;
                    }
                case 1:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu không?", "SAVE",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (cmbMaHang.Text=="" ||cmbNam.Text == "" || cmbThang.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            int thang = int.Parse(cmbThang.Text);
                            int nam = int.Parse(cmbNam.Text);
                            string mahang = cmbMaHang.SelectedValue.ToString();
                            string makhohang = cmbMaKhoHang.SelectedValue.ToString();
                            int sldauthang = KSXNKBLL.SLDauThang(thang, nam,mahang);
                            int tongnhap = KSXNKBLL.TongNhap(thang, nam,mahang);
                            int topngxuat = KSXNKBLL.TongXuat(thang, nam,mahang);
                            int slcuoithang = KSXNKBLL.SLCuoiThang(thang, nam,mahang);
                            DateTime ngaylap;
                            if (dpNgayLap.Value != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(dpNgayLap.Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (dpNgaySua.Value != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(dpNgaySua.Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = cmbNguoiLap.Text;
                            string nguoisua = cmbNguoiSua.Text;
                            KSXNKBLL.LuuThem(thang, nam,mahang,sldauthang,tongnhap,topngxuat,slcuoithang,ngaylap, nguoilap, ngaysua, nguoisua);
                            LoadDanhSachKetSoNhapXuat(makhohang,nam);
                            SetControlEnable_KSXNK(true);
                            ksxnk_nhaptay = 0;
                        }
                        else
                        {
                            ksxnk_nhaptay = 0;
                            SetControlEnable_KSXNK(true);
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
                string makhohang = toolStripKhoHang.ComboBox.SelectedValue.ToString();
                int nam = int.Parse(toolstripNam.Text);
                LoadDanhSachKetSoNhapXuat(makhohang,nam);
                SetControlEnable_KSXNK(true);
                ksxnk_nhaptay = 0;
            }
            else
            {
                ksxnk_nhaptay = 0;
                return;
            }
        }
        #endregion 

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
            int nam = int.Parse(toolstripNam.Text);
            string mahang = gridKetSoXNK.CurrentRow.Cells["MaHang"].Value.ToString();
            if (MessageBox.Show("Xóa dữ liệu kết sổ nhập xuất Mã hàng: " + mahang + " Năm " + nam + " k ?", "DELETE",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolstripNam.Text == "")
                {
                    MessageBox.Show("Chọn tháng,năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string makho = toolStripKhoHang.ComboBox.SelectedValue.ToString();
                progressbar.Minimum = 0;
                progressbar.Maximum = 0;
                KSXNKBLL.XoaKSXNK(nam, mahang, progressbar);
                LoadDanhSachKetSoNhapXuat(makho, nam);
            }
            else
                return;
        }
        private void FrmKetSoXuatNhapKho_KeyPress(object sender, KeyPressEventArgs e)
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