using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.BusinessLogicLayer;
using DevComponents.DotNetBar.Rendering;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        KhachHangBLL KHBLL = new KhachHangBLL();

        private void HienThiDuLieuLenControl(int dong)
        {
            txtMaKhachHang.Text = grvKhachHang.Rows[dong].Cells["ColMaKhachHang"].Value.ToString();
            txtTenKhachHang.Text = grvKhachHang.Rows[dong].Cells["colTenKhachHang"].Value.ToString();
            txtDCKH.Text = grvKhachHang.Rows[dong].Cells["colDCKH"].Value.ToString();
            string tentinh = "";
            foreach (var item in KHBLL.LayDanhSachTenTinhTheoMaTinh(grvKhachHang.Rows[dong].Cells["ColMaTinhThanh"].Value.ToString()))
            {
                tentinh = item.ToString();
            }
            cmbMaTinhThanh.Text = tentinh;
            //cmbMaLoaiHang.DisplayMember = grvKhachHang.Rows[dong].Cells["ColMaNCC"].Value.ToString();
            txtDT.Text = grvKhachHang.Rows[dong].Cells["ColSoDT"].Value.ToString();
            txtFax.Text = grvKhachHang.Rows[dong].Cells["ColSoFax"].Value.ToString();
            txtEmail.Text = grvKhachHang.Rows[dong].Cells["ColEmail"].Value.ToString();
        }
        private void LoadDanhSachKhachHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.LayDanhSachKhachHang();
            grvKhachHang.DataSource = bds;
            bindingKhachHang.BindingSource = bds;
            HienThiDuLieuLenControl(0);
            SetControlEnable(false);
            grvKhachHang.AllowUserToAddRows = false;
        }

        private void LoadDataComboboxMaTinhThanh()
        {
            comboMaTinhThanh.ComboBox.DataSource = KHBLL.LayDanhSachMaTinh();
            comboMaTinhThanh.ComboBox.DisplayMember = "MaTinh";

        }
        private void comboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.TimTatCaKhachHangTheoMaTinhThanh(comboMaTinhThanh.Text);
            grvKhachHang.DataSource = bds;
            bindingKhachHang.BindingSource = bds;
            SetControlEnable(false);
        }
        private void LoaddatacmbMaTinhThanh()
        {
            cmbMaTinhThanh.DataSource = KHBLL.LayDanhSachMaTinh();
            cmbMaTinhThanh.DisplayMember = "TenTinh";
            cmbMaTinhThanh.ValueMember = "MaTinh";
            cmbTimKiemMaTinhThanh.DataSource = KHBLL.LayDanhSachMaTinh();
            cmbTimKiemMaTinhThanh.DisplayMember = "TenTinh";
            cmbTimKiemMaTinhThanh.ValueMember = "MaTinh";
        }
        private void LoadDataColumnCombobox()
        {
            ColMaTinhThanh.DataSource = KHBLL.LayDanhSachMaTinh();
            ColMaTinhThanh.DisplayMember = "MaTinh";

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingKhachHang.BindingSource.MoveLast();
        }
        private void LoadTreeView()
        {
            foreach (var item in KHBLL.LayDanhSachTinhThanh())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                advTreeTinhThanh.Nodes[0].Nodes.Add(childnode);
            }
            advTreeTinhThanh.CollapseAll();
            loadtreeview++;
        }
        private void advTreeTinhThanh_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            try
            {
                if (e.Node.Level == 0)
                    LoadDanhSachKhachHang();
                else
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = KHBLL.LayDanhSachKhachHangTheoTenTinhThanh(e.Node.Text);
                    grvKhachHang.DataSource = bds;
                    bindingKhachHang.BindingSource = bds;
                }
            }
            catch { }
        }
        int loadtreeview = 0;
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            if (loadtreeview == 0)
            {
                LoadTreeView();
            }
            loadtreeview++;
            LoadDataColumnCombobox();
            LoadDataComboboxMaTinhThanh();
            LoaddatacmbMaTinhThanh();
            LoadDanhSachKhachHang();
        }

        private void grvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            if (dong < grvKhachHang.RowCount - 1)
            {
                HienThiDuLieuLenControl(dong);
            }
        }

        private void SetConTrolKhachHangToNull()
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Text = "";
            txtDCKH.Clear();
            cmbMaTinhThanh.Text = "";
            txtDT.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";

        }

        private void SetControlEnable(bool enable = true)
        {
            txtMaKhachHang.Enabled = enable;
            txtTenKhachHang.Enabled = enable;
            txtDCKH.Enabled = enable;
            cmbMaTinhThanh.Enabled = enable;
            txtDT.Enabled = enable;
            txtFax.Enabled = enable;
            txtEmail.Enabled = enable;
            
        }

        private void SetControlThemEnable(bool enable = true)
        {
            btn_Them.Enabled = enable;
            btn_LuuThem.Enabled = !enable;
            btn_HuyThem.Enabled = !enable;
        }

        private void SetControlSuaEnable(bool enable = true)
        {
            btnSua.Enabled = enable;
            btnLuuSua.Enabled = !enable;
            btnHuySua.Enabled = !enable;
        }

        private void SetConTrolThemSuaEnable(int th, bool enable = true)
        {
            switch (th)
            {
                case 1://khởi động chương trình
                    {
                        buttonItem_ThemHang.Enabled = enable;
                        buttonItem_SuaHang.Enabled = enable;
                        break;
                    }
                case 2://các trường hợp khác
                    {
                        buttonItem_ThemHang.Enabled = enable;
                        buttonItem_SuaHang.Enabled = !enable;
                        break;
                    }
            }
        }


        private void btn_LuuThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (KiemTraControl() == true)
                {
                    string matinhthanh = cmbMaTinhThanh.SelectedValue.ToString();
                    KHBLL.ThemKH(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDCKH.Text, matinhthanh, txtDT.Text, txtFax.Text, txtEmail.Text);
                    SetControlThemEnable(true);
                    SetConTrolThemSuaEnable(1, true);
                    LoadDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Nhập thiếu thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }

        //Kiểm tra các điều khiển
        private bool KiemTraControl()
        {
            bool kt;
            if ((txtMaKhachHang.Text == "") || (txtTenKhachHang.Text == "") || (txtDCKH.Text == "") || (cmbMaTinhThanh.Text == "") || (txtDT.Text == "") || (txtEmail.Text==""))
            {
                kt = false;
            }
            else
            {
                kt = true;
            }
            return kt;
        }
        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (grvKhachHang.RowCount == 0)
                btnXoaKhachHang.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KHBLL.XoaKH(grvKhachHang.CurrentRow.Cells["ColMaKhachHang"].Value.ToString());
                LoadDanhSachKhachHang();
                SetControlThemEnable(true);
            }

        }

        private void btn_HuyThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác thêm?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachKhachHang();
                SetControlThemEnable(true);
                SetConTrolThemSuaEnable(1, true);
            }
            else
            {
                return;
            }
        }

        private void buttonItem_ThemHang_Click(object sender, EventArgs e)
        {
            SetConTrolThemSuaEnable(2, true);
        }

        private void buttonItem_SuaHang_Click(object sender, EventArgs e)
        {
            SetConTrolThemSuaEnable(2, false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable(true);
            txtMaKhachHang.ReadOnly = true;
            SetControlSuaEnable(false);
            SetConTrolThemSuaEnable(2, false);
        }

        private void btnLuuSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (KiemTraControl() == true)
                {
                    QuanLy_KeToan.DataAccessLayer.KhachHang khachhang = new QuanLy_KeToan.DataAccessLayer.KhachHang();
                    khachhang.MaKhachHang = txtMaKhachHang.Text;
                    khachhang.TenKhachHang = txtTenKhachHang.Text;
                    khachhang.DCKH = txtDCKH.Text;
                    string matinhthanh = cmbMaTinhThanh.SelectedValue.ToString();
                    khachhang.MaTinhThanh = matinhthanh;
                    khachhang.SoDT = txtDT.Text;
                    khachhang.SoFax = txtFax.Text;
                    khachhang.Email = txtEmail.Text;
                    KHBLL.SuaKH(txtMaKhachHang.Text, khachhang);
                    SetControlSuaEnable(true);
                    SetConTrolThemSuaEnable(1, true);
                    LoadDanhSachKhachHang();
                    txtMaKhachHang.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Nhập thiếu thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }

        private void btnHuySua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác sửa?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachKhachHang();
                SetControlSuaEnable(true);
                SetConTrolThemSuaEnable(1, true);
                txtMaKhachHang.ReadOnly = false;
            }
            else
            {
                return;
            }
        }

        private int th = 0;
        private void NvgThem_Click(object sender, EventArgs e)
        {
            th = 1;
            grvKhachHang.AllowUserToAddRows = true;
            bindingKhachHang.BindingSource.MoveLast();
        }

        private int truonghop = 0;
        //Thao Tác Trực Tiếp Trên Lưới
        private void NvgLuu_Click(object sender, EventArgs e)
        {
            switch (th)
            {
                case 1://Them
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingNavigatorPositionItem.Focus();
                            string makhachhang = grvKhachHang.CurrentRow.Cells["ColMaKhachHang"].Value.ToString();
                            string tenkhachhang = grvKhachHang.CurrentRow.Cells["ColTenKhachHang"].Value.ToString();
                            string diachi = grvKhachHang.CurrentRow.Cells["ColDCKH"].Value.ToString();
                            string matinh = grvKhachHang.CurrentRow.Cells["ColMaTinhThanh"].Value.ToString();
                            string sodt = grvKhachHang.CurrentRow.Cells["ColSoDT"].Value.ToString();
                            string fax = grvKhachHang.CurrentRow.Cells["ColSoFax"].Value.ToString();
                            string email = grvKhachHang.CurrentRow.Cells["ColEmail"].Value.ToString();


                            KHBLL.ThemKH(makhachhang, tenkhachhang, diachi, matinh, sodt, fax, email);
                            SetControlThemEnable(true);
                            SetConTrolThemSuaEnable(1, true);
                            LoadDanhSachKhachHang();
                            th = 0;
                        }
                        else
                        {
                            truonghop = 0;
                            return;
                        }
                        break;
                    }
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bindingNavigatorPositionItem.Focus();
                            QuanLy_KeToan.DataAccessLayer.KhachHang khachhang = new QuanLy_KeToan.DataAccessLayer.KhachHang();
                            string makhachhang = grvKhachHang.CurrentRow.Cells["ColMaKhachHang"].Value.ToString();
                            khachhang.TenKhachHang = grvKhachHang.CurrentRow.Cells["ColTenKhachHang"].Value.ToString();
                            khachhang.DCKH = grvKhachHang.CurrentRow.Cells["ColDCKH"].Value.ToString();
                            khachhang.MaTinhThanh = grvKhachHang.CurrentRow.Cells["ColMaTinhThanh"].Value.ToString();
                            khachhang.SoDT = grvKhachHang.CurrentRow.Cells["ColSoDT"].Value.ToString();
                            khachhang.SoFax = grvKhachHang.CurrentRow.Cells["ColSoFax"].Value.ToString();
                            khachhang.Email = grvKhachHang.CurrentRow.Cells["ColEmail"].Value.ToString();
                           
                            KHBLL.SuaKH(makhachhang, khachhang);
                            LoadDanhSachKhachHang();
                        }
                        else
                            return;
                        break;
                    }
            }
        }

        private void NvgThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.TimTatCaKhachHangChinhXacTheoMaKhachHang(txtTimKiem.Text);
            grvKhachHang.DataSource = bds;
            bindingKhachHang.BindingSource = bds;
            SetControlEnable(false);
        }

        private void NvgRefresh_Click(object sender, EventArgs e)
        {
            FrmKhachHang_Load(sender, e);
        }

        private void NvgHuy_Click(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
        }

        private void btnTimMaKhachHang_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.TimTatCaKhachHangChinhXacTheoMaKhachHang(txtTimKiemMaKhachHang.Text);
            grvKhachHang.DataSource = bds;
            bindingKhachHang.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = grvKhachHang.RowCount.ToString();
        }

        private void btnTimTenKhachHang_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.TimTatCaKhachHangChinhXacTheoTenKhachHang(txtTimKiemTenKhachHang.Text);
            grvKhachHang.DataSource = bds;
            bindingKhachHang.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = grvKhachHang.RowCount.ToString();
        }

        private void cmbTimKiemMaTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = KHBLL.TimTatCaKhachHangTheoMaTinhThanh(cmbTimKiemMaTinhThanh.SelectedValue.ToString());
            grvKhachHang.DataSource = bds;
            bindingKhachHang.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = grvKhachHang.RowCount.ToString();
        }

        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            SetControlEnable(true);
            SetControlThemEnable(false);
            SetConTrolThemSuaEnable(2, true);
            SetConTrolKhachHangToNull();
        }   

    }

}
