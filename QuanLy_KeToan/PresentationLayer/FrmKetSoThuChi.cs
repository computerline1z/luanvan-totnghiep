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
    public partial class FrmKetSoThuChi : DevComponents.DotNetBar.Office2007Form
    {
        public FrmKetSoThuChi()
        {
            InitializeComponent();
        }
#region (Biến)
        private int xoa = 0;
        #endregion
#region (Hàm dùng chung)
        KetSoThuChiBLL KSTCBLL = new KetSoThuChiBLL();
        //Hàm Load các combobox
        private void LoadCmbNguoiLap()
        {
            cmbNguoiLap.DataSource = KSTCBLL.LayNguoiLap();
            cmbNguoiLap.DisplayMember = "TenDangNhap";
            cmbNguoiLap.ValueMember = "TenDangNhap";
            cmbNguoiSua.DataSource = KSTCBLL.LayNguoiLap();
            cmbNguoiSua.DisplayMember = "TenDangNhap";
            cmbNguoiSua.ValueMember = "TenDangNhap";
        }
        private void LoadComboboxColumnNguoiLap()
        {
            NguoiLap.DataSource = KSTCBLL.LayNguoiLap();
            NguoiLap.ValueMember = "TenDangNhap";
            NguoiLap.DisplayMember = "TenDangNhap";
            NguoiSua.DataSource = KSTCBLL.LayNguoiLap();
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
        private void LoadDanhSachKetSoThuChi(int nam)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KSTCBLL.LayDSKetSoThuChi(nam);
            gridKetSoThuChi.DataSource = bds;
            bindingKetSoThuChi.BindingSource = bds;
            gridKetSoThuChi.AllowUserToAddRows = false;
        }
        private void FrmKetSoThuChi_Load(object sender, EventArgs e)
        {
            LoadThang();
            LoadNam();
            LoadCmbNguoiLap();
            LoadComboboxColumnNguoiLap();
            toolstripNam.Focus();
            if (gridKetSoThuChi.RowCount == 0)
                SetControlEnable_KSTC(true);
        }
        #endregion
#region (Xử lý nhập lưới)
        private int kstc_nhapluoi = 0;

        private void ToolBarEnableKetSoThuChi(bool DangThaoTac = false)
        {
            KSTC_Add.Enabled = DangThaoTac;
            KSTC_Delete.Enabled = DangThaoTac;
            KSTC_Cancel.Enabled = !DangThaoTac;
            KSTC_Refresh.Enabled = DangThaoTac;
            KSTC_Save.Enabled = !DangThaoTac;
        }
        private void KSTC_Add_Click(object sender, EventArgs e)
        {
            if (toolstripNam.Text == "")
            {
                MessageBox.Show("Chọn tháng,năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            kstc_nhapluoi = 1;
            ToolBarEnableKetSoThuChi(false);
            progressbar.Minimum = 0;
            progressbar.Maximum = 0;
            if (gridKetSoThuChi.RowCount == 0)
            {
                gridKetSoThuChi.AllowUserToAddRows = true;
            }
            else
            {
                gridKetSoThuChi.AllowUserToAddRows = true;
                bindingKetSoThuChi.BindingSource.MoveLast();
               
            }
            gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 1].Cells["Nam"].Value = int.Parse(toolstripNam.Text);
        }
        private void KSTC_Refresh_Click(object sender, EventArgs e)
        {
            LoadDanhSachKetSoThuChi(System.Convert.ToInt16(toolstripNam.Text));
            ToolBarEnableKetSoThuChi(true);
            kstc_nhapluoi = 0;
        }
        private void KSTC_Save_Click(object sender, EventArgs e)
        {
            ToolBarEnableKetSoThuChi(true);
            switch (kstc_nhapluoi)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionKSTC.Focus();
                            KetSoThuChi KSTC = new KetSoThuChi();
                            int thang = System.Convert.ToInt16(gridKetSoThuChi.CurrentRow.Cells["Thang"].Value.ToString());
                            int nam = System.Convert.ToInt16(toolstripNam.Text);
                            KSTC.NgayLap = System.Convert.ToDateTime(gridKetSoThuChi.CurrentRow.Cells["NgayLap"].Value.ToString());
                            KSTC.NguoiLap = (gridKetSoThuChi.CurrentRow.Cells["NguoiLap"].Value != null ? gridKetSoThuChi.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            KSTC.NgaySua = System.Convert.ToDateTime(gridKetSoThuChi.CurrentRow.Cells["NgaySua"].Value.ToString());
                            KSTC.NguoiSua = (gridKetSoThuChi.CurrentRow.Cells["NguoiSua"].Value != null ? gridKetSoThuChi.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            KSTCBLL.Sua(thang,nam,KSTC);
                            LoadDanhSachKetSoThuChi(nam);
                            ToolBarEnableKetSoThuChi(true);
                        }
                        else
                        {
                            ToolBarEnableKetSoThuChi(true);
                            return;
                        }
                        break;
                        
                    }            
                case 1://Thêm
                    {
                        positionKSTC.Focus();
                        int thang = System.Convert.ToInt16(gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount-2].Cells["Thang"].Value.ToString());
                        int nam = System.Convert.ToInt16(toolstripNam.Text);
                        if (MessageBox.Show("Kết sổ thu chi Tháng " + thang + "/" + nam + " ?", "Kết sổ thu chi theo tháng",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            progressbar.Minimum = 1;
                            progressbar.Step=100;
                            progressbar.Maximum = 100;
                            progressbar.PerformStep();
                            decimal sodudauki = KSTCBLL.SoDuDauKi(thang, nam);
                            decimal soducuoiki = KSTCBLL.SoDuCuoiKi(thang, nam);
                            decimal tongtienthu = KSTCBLL.TongTienThu(thang, nam);
                            decimal tongtienchi = KSTCBLL.TongTienChi(thang, nam);
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount-2].Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 2].Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount-2].Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 2].Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 2].Cells["NguoiLap"].Value != null ? gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 2].Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 2].Cells["NguoiLap"].Value != null ? gridKetSoThuChi.Rows[gridKetSoThuChi.RowCount - 2].Cells["NguoiLap"].Value.ToString() : "");
                            bool them=KSTCBLL.LuuThem(thang, nam, sodudauki, tongtienthu, tongtienchi, soducuoiki, ngaylap, nguoilap, ngaysua, nguoisua);
                            if (them == true)
                            {
                                progressbar.Maximum = 100;
                            }
                            LoadDanhSachKetSoThuChi(nam);
                            ToolBarEnableKetSoThuChi(true);
                            kstc_nhapluoi = 0;
                        }
                        else
                        {
                            ToolBarEnableKetSoThuChi(true);
                            kstc_nhapluoi = 0;
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
            KSTCBLL.KetSoThuChiQuy(int.Parse(toolstripNam.Text), thang1, thang2, thang3, thang4, thang5, thang6, thang7, thang8, thang9, thang10, thang11, thang12,Tong1,Tong2,Tong3,Tong4,Tong);
        }
        private void toolstripNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelX1.Text = "";
            labelX1.Text = "KẾT SỔ THU CHI THEO QUÝ NĂM " + toolstripNam.Text;
            labelX22.Text = "Kết Sổ Năm" + toolstripNam.Text + ": ";
            lblTongTaiSan.Text = "";
            LoadDanhSachKetSoThuChi(int.Parse(toolstripNam.Text));
            LoadKSTCQuy();
            KSTCBLL.TongTaiSan(lblTongTaiSan);
        }
        private void KSTC_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                kstc_nhapluoi = 0;
                LoadDanhSachKetSoThuChi(int.Parse(toolstripNam.Text));
                ToolBarEnableKetSoThuChi(true);
            }
            else
            {
                kstc_nhapluoi = 0;
                return;
            }
        }
        private void KSTC_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridKetSoThuChi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            ToolBarEnableKetSoThuChi();
            
        }
        private void gridKetSoThuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (gridKetSoThuChi.Columns[e.ColumnIndex].Name == "Nam")
                        gridKetSoThuChi.CurrentRow.Cells["Nam"].Value = int.Parse(toolstripNam.Text);
                }
                if (kstc_nhapluoi == 0 )//&& kstc_nhaptay == 0)
                {
                    if (e.ColumnIndex == -1)
                    {
                        FrmChiTietKetSoThu CTKST = new FrmChiTietKetSoThu();
                        int month=System.Convert.ToInt16(gridKetSoThuChi.CurrentRow.Cells["Thang"].Value);
                        int year=System.Convert.ToInt16(toolstripNam.Text);
                        CTKST.thang=month;
                        CTKST.sodudauki=KSTCBLL.SoDuDauKi(month,year);
                        CTKST.tongtienthu=KSTCBLL.TongTienThu(month,year);
                        CTKST.tongtienchi=KSTCBLL.TongTienChi(month,year);
                        CTKST.soducuoiki=KSTCBLL.SoDuCuoiKi(month,year);
                        CTKST.Text +=" "+ month.ToString();
                        CTKST.Show();
                    }
                    else
                        return;
                 }
                if (kstc_nhapluoi == 1)
                {
                    gridKetSoThuChi.CurrentRow.Cells["Thang"].ReadOnly = false;
                }
                else
                {
                    gridKetSoThuChi.CurrentRow.Cells["Thang"].ReadOnly = true;
                }
            }
            catch {}
        }
        private void KSTC_update_Click_1(object sender, EventArgs e)
        {
            if (toolstripNam.Text == "")
            {
                MessageBox.Show("Chọn Năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nam = int.Parse(toolstripNam.Text);
            progressbar.Minimum = 0;
            progressbar.Maximum = 0;
            KSTCBLL.LuuCapNhat(nam, progressbar);
            LoadDanhSachKetSoThuChi(nam);
        }

        private void KSTC_Delete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu kết sổ thu chi k-Toàn bộ dữ liệu kết sổ thu chi sẽ bị xóa ?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (toolstripNam.Text == "")
                {
                    MessageBox.Show("Chọn tháng,năm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int nam = int.Parse(toolstripNam.Text);
                progressbar.Minimum = 0;
                progressbar.Maximum = 0;
                KSTCBLL.XoaKSTC(nam, progressbar);
                LoadDanhSachKetSoThuChi(nam);
            }
        }
        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbThang.Items.Clear();
            cmbThang.Text = "";
            KSTCBLL.LayThangTheoNam(int.Parse(cmbNam.Text), cmbThang);
        }
#endregion
#region(Xử lý nhập tay)
        private int kstc_nhaptay = 0;

        private void SetConTrolToNull_KSTC()
        {
            cmbNam.Text = "";
            cmbThang.Text = "";
            dpSoDuDauKi.Value = 0;
            dpTienThu.Value = 0;
            dpTienChi.Value = 0;
            dpSoDuCuoiKi.Value = 0;
            dpNgayLap.Value = DateTime.Now;
            cmbNguoiLap.Text = "";
            dpNgaySua.Value = DateTime.Now;
            cmbNguoiSua.Text = "";
        }
        private void SetControlEnable_KSTC(bool status)
        {
            btnSua.Enabled = status;
            btnThem.Enabled = status;
            btnLuu.Enabled = !status;
            btnHuy.Enabled = !status;
            cmbNam.Enabled = !status;
            cmbThang.Enabled = !status;
            dpNgayLap.Enabled = !status;
            cmbNguoiLap.Enabled = !status;
            dpNgaySua.Enabled = !status;
            cmbNguoiSua.Enabled = !status;
        }
        private void LoadDataToControl_KSTC(int dong)
        {
            if (gridKetSoThuChi.RowCount > 0 && kstc_nhapluoi != 1)
            {
                cmbNam.Text = gridKetSoThuChi.Rows[dong].Cells["Nam"].Value.ToString();
                cmbThang.Text = gridKetSoThuChi.Rows[dong].Cells["Thang"].Value.ToString();
                dpSoDuDauKi.Text = gridKetSoThuChi.Rows[dong].Cells["SoDuDauKi"].Value.ToString();
                dpTienThu.Text = gridKetSoThuChi.Rows[dong].Cells["TongTienThu"].Value.ToString();
                dpTienChi.Text = gridKetSoThuChi.Rows[dong].Cells["TongTienChi"].Value.ToString();
                dpSoDuCuoiKi.Text = dpTienThu.Text = gridKetSoThuChi.Rows[dong].Cells["SoDuCuoiKi"].Value.ToString();
                dpNgayLap.Value = System.Convert.ToDateTime(gridKetSoThuChi.Rows[dong].Cells["NgayLap"].Value.ToString());
                cmbNguoiLap.Text = gridKetSoThuChi.Rows[dong].Cells["NguoiLap"].Value==null?"":gridKetSoThuChi.Rows[dong].Cells["NguoiLap"].Value.ToString();
                dpNgaySua.Value = System.Convert.ToDateTime(gridKetSoThuChi.Rows[dong].Cells["NgaySua"].Value.ToString());
                cmbNguoiSua.Text = gridKetSoThuChi.Rows[dong].Cells["NguoiSua"].Value==null?"":gridKetSoThuChi.Rows[dong].Cells["NguoiSua"].Value.ToString();
            }
        }
        private void gridKetSoThuChi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataToControl_KSTC(e.RowIndex);
            SetControlEnable_KSTC(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            kstc_nhaptay = 1;
            SetConTrolToNull_KSTC();
            SetControlEnable_KSTC(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable_KSTC(false);
            cmbNam.Enabled = false;
            cmbThang.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (kstc_nhaptay)
            {
                case 0:
                    {
                        if (MessageBox.Show("Bạn có muốn lưu không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            KetSoThuChi KSTC = new KetSoThuChi();
                            int nam = int.Parse(cmbNam.Text);
                            int thang = int.Parse(cmbThang.Text);
                            KSTC.NgayLap = dpNgayLap.Value;
                            KSTC.NguoiLap = cmbNguoiLap.Text;
                            KSTC.NgaySua = dpNgaySua.Value;
                            KSTC.NguoiSua = cmbNguoiSua.Text;
                            KSTCBLL.Sua(thang, nam, KSTC);
                            LoadDanhSachKetSoThuChi(nam);
                            SetControlEnable_KSTC(true);
                        }
                        else
                        {
                            SetControlEnable_KSTC(true);
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
                            if (cmbNam.Text == "" || cmbThang.Text == "")
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            int thang = int.Parse(cmbThang.Text);
                            int nam = int.Parse(cmbNam.Text);
                            decimal sodudauki = KSTCBLL.SoDuDauKi(thang, nam);
                            decimal soducuoiki = KSTCBLL.SoDuCuoiKi(thang, nam);
                            decimal tienthu = KSTCBLL.TongTienThu(thang, nam);
                            decimal tienchi = KSTCBLL.TongTienChi(thang, nam);
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
                            KSTCBLL.LuuThem(thang, nam, sodudauki, tienthu, tienchi, soducuoiki, ngaylap, nguoilap, ngaysua, nguoisua);
                            LoadDanhSachKetSoThuChi(nam);
                            SetControlEnable_KSTC(true);
                            kstc_nhaptay = 0;
                        }
                        else
                        {
                            kstc_nhaptay = 0;
                            SetControlEnable_KSTC(true);
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
                LoadDanhSachKetSoThuChi(int.Parse(cmbNam.Text));
                SetControlEnable_KSTC(true);
                kstc_nhaptay = 0;
            }
            else
            {
                kstc_nhaptay = 0;
                return;
            }
        }
#endregion
    }
}