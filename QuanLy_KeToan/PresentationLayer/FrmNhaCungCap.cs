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
    public partial class FrmNhaCungCap : Form
    {
        public FrmNhaCungCap()
        {
            InitializeComponent();
        }

        NhaCungCapBLL NCCBLL = new NhaCungCapBLL();

        private void HienThiDuLieuLenControl(int dong)
        {
            txtMaNCC.Text = grvNCC.Rows[dong].Cells["ColMaNCC"].Value.ToString();
            string tenloaihang = "";
            foreach (var item in NCCBLL.LayDanhSachTenLoaiHangTheoMaLoaiHang(grvNCC.Rows[dong].Cells["ColMaLoaiHang"].Value.ToString()))
            {
                tenloaihang = item.ToString();
            }
            cmbMaLoaiHang.Text = tenloaihang;
            txtTenNCC.Text = grvNCC.Rows[dong].Cells["colTenNCC"].Value.ToString();
            txtDCNCC.Text = grvNCC.Rows[dong].Cells["colDCNCC"].Value.ToString();
            string tentinh = "";
            foreach (var item in NCCBLL.LayDanhSachTenTinhTheoMaTinh(grvNCC.Rows[dong].Cells["ColMaTinh"].Value.ToString()))
            {
                tentinh = item.ToString();
            }
            cmbMaTinhThanh.Text = tentinh;

            //cmbMaLoaiHang.DisplayMember = grvKhachHang.Rows[dong].Cells["ColMaNCC"].Value.ToString();
            txtDT.Text = grvNCC.Rows[dong].Cells["ColSoDT"].Value.ToString();
            txtFax.Text = grvNCC.Rows[dong].Cells["ColSoFax"].Value.ToString();
            txtEmail.Text = grvNCC.Rows[dong].Cells["ColEmail"].Value.ToString();

        }
        private void LoadDanhSachNCC()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNCC();
            grvNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            HienThiDuLieuLenControl(0);
            SetControlEnable(false);
            grvNCC.AllowUserToAddRows = false;
        }

        private void LoadDataComboboxLoaiHang()
        {
            comboMaLoaiHang.ComboBox.DataSource = NCCBLL.LayDanhSachMaLoaiHang();
            comboMaLoaiHang.ComboBox.DisplayMember = "MaLoaiHang";
            cmbMaLoaiHang.DataSource = NCCBLL.LayDanhSachMaLoaiHang();
            cmbMaLoaiHang.DisplayMember = "MaLoaiHang";

        }
        private void LoadDatacmbMaTinh()
        {
            cmbMaTinhThanh.DataSource = NCCBLL.LoadDanhSachMaTinh();
            cmbMaTinhThanh.DisplayMember = "TenTinh";
            cmbMaTinhThanh.ValueMember = "MaTinh";
            cmbTimKiemMaTinhThanh.DataSource = NCCBLL.LoadDanhSachMaTinh();
            cmbTimKiemMaTinhThanh.DisplayMember = "TenTinh";
            cmbTimKiemMaTinhThanh.ValueMember = "MaTinh";

        }

        private void LoadDataColumnCombobox()
        {
            ColMaLoaiHang.DataSource = NCCBLL.LayDanhSachMaLoaiHang();
            ColMaLoaiHang.DisplayMember = "MaLoaiHang";
            ColMaTinh.DataSource = NCCBLL.LoadDanhSachMaTinh();
            ColMaTinh.DisplayMember = "MaTinh";

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingNCC.BindingSource.MoveLast();
        }

        private void LoadTreeView()
        {
            foreach (var item in NCCBLL.LoadDanhSachMaTinh())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                advTreeTinhThanh.Nodes[0].Nodes.Add(childnode);
            }
            advTreeTinhThanh.CollapseAll();
        }
        private void grvNCC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            if (dong < grvNCC.RowCount - 1)
            {
                HienThiDuLieuLenControl(dong);
            }
        }

        private void SetConTrolNhaCungCapToNull()
        {
            txtMaNCC.Clear();
            cmbMaLoaiHang.Text = "";
            txtTenNCC.Text = "";
            txtDCNCC.Clear();
            cmbMaTinhThanh.Text = "";
            txtDT.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";

        }

        private void SetControlEnable(bool enable = true)
        {
            txtMaNCC.Enabled = enable;
            cmbMaLoaiHang.Enabled = enable;
            txtTenNCC.Enabled = enable;
            txtDCNCC.Enabled = enable;
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

        private void comboMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.TimTatCaNhaCungCapTheoMaLoaiHang(comboMaLoaiHang.Text);
            grvNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            SetControlEnable(false);

        }

       
        //Kiểm tra các điều khiển
        private bool KiemTraControl()
        {
            bool kt;
            if ((txtMaNCC.Text == "") || (cmbMaLoaiHang.Text == "") || (txtTenNCC.Text == "") || (txtDCNCC.Text == "") || (cmbMaTinhThanh.Text == "") || (txtDT.Text == "") || (txtEmail.Text == ""))
            {
                kt = false;
            }
            else
            {
                kt = true;
            }
            return kt;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            SetControlEnable(true);
            SetControlThemEnable(false);
            SetConTrolThemSuaEnable(2, true);
            SetConTrolNhaCungCapToNull();
        }

        private void btn_LuuThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (KiemTraControl() == true)
                {
                    string maloaihang = cmbMaLoaiHang.SelectedValue.ToString();
                    string matinhthanh = cmbMaTinhThanh.SelectedValue.ToString();
                    NCCBLL.ThemNCC(txtMaNCC.Text, maloaihang , txtTenNCC.Text, txtDCNCC.Text, matinhthanh, txtDT.Text, txtFax.Text, txtEmail.Text);
                    SetControlThemEnable(true);
                    SetConTrolThemSuaEnable(1, true);
                    LoadDanhSachNCC();
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

        private void btn_HuyThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác thêm?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadDanhSachNCC();
                SetControlThemEnable(true);
                SetConTrolThemSuaEnable(1, true);
            }
            else
            {
                return;
            }
        }
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (grvNCC.RowCount == 0)
                btnXoaNCC.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NCCBLL.XoaNCC(grvNCC.CurrentRow.Cells["ColMaNCC"].Value.ToString(),grvNCC.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString());
                LoadDanhSachNCC();
                SetControlThemEnable(true);
            }
        }

       
        private void buttonItem_ThemHang_Click(object sender, EventArgs e)
        {
            SetConTrolThemSuaEnable(2, true);
        }
        //tới chỗ này

        private void buttonItem_SuaHang_Click(object sender, EventArgs e)
        {
            SetConTrolThemSuaEnable(2, false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetControlEnable(true);
            txtMaNCC.ReadOnly = true;
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
                    QuanLy_KeToan.DataAccessLayer.NhaCungCap nhacungcap = new QuanLy_KeToan.DataAccessLayer.NhaCungCap();
                    nhacungcap.MaNCC = txtMaNCC.Text;
                    string maloaihang = cmbMaLoaiHang.SelectedValue.ToString();
                    nhacungcap.MaLoaiHang = maloaihang;
                    nhacungcap.TenNCC = txtTenNCC.Text;
                    nhacungcap.DCNCC = txtDCNCC.Text;
                    string matinhthanh = cmbMaTinhThanh.SelectedValue.ToString();
                    nhacungcap.MaTinh = matinhthanh;
                    nhacungcap.SoDT = txtDT.Text;
                    nhacungcap.SoFax = txtFax.Text;
                    nhacungcap.Email = txtEmail.Text;
                    NCCBLL.SuaNCC(txtMaNCC.Text,maloaihang, nhacungcap);
                    SetControlSuaEnable(true);
                    SetConTrolThemSuaEnable(1, true);
                    LoadDanhSachNCC();
                    txtMaNCC.ReadOnly = false;
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
                LoadDanhSachNCC();
                SetControlSuaEnable(true);
                SetConTrolThemSuaEnable(1, true);
                txtMaNCC.ReadOnly = false;
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
            grvNCC.AllowUserToAddRows = true;
            bindingNCC.BindingSource.MoveLast();
        }
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
                            string manhacungcap = grvNCC.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            string maloaihang = grvNCC.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            string tennhacungcap = grvNCC.CurrentRow.Cells["ColTenNCC"].Value.ToString();
                            string diachi = grvNCC.CurrentRow.Cells["ColDCNCC"].Value.ToString();
                            string matinh = grvNCC.CurrentRow.Cells["ColMaTinh"].Value.ToString();
                            string sodt = grvNCC.CurrentRow.Cells["ColSoDT"].Value.ToString();
                            string fax = grvNCC.CurrentRow.Cells["ColSoFax"].Value.ToString();
                            string email = grvNCC.CurrentRow.Cells["ColEmail"].Value.ToString();
                            NCCBLL.ThemNCC(manhacungcap, maloaihang,tennhacungcap, diachi, matinh, sodt, fax, email);
                            SetControlThemEnable(true);
                            SetConTrolThemSuaEnable(1, true);
                            LoadDanhSachNCC();
                            th = 0;
                        }
                        else
                        {
                            th = 0;
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
                            QuanLy_KeToan.DataAccessLayer.NhaCungCap nhacungcap = new QuanLy_KeToan.DataAccessLayer.NhaCungCap();
                            string manhacungcap = grvNCC.CurrentRow.Cells["ColMaNCC"].Value.ToString();
                            string maloaihang = grvNCC.CurrentRow.Cells["ColMaLoaiHang"].Value.ToString();
                            nhacungcap.TenNCC = grvNCC.CurrentRow.Cells["ColTenNCC"].Value.ToString();
                            nhacungcap.DCNCC = grvNCC.CurrentRow.Cells["ColDCNCC"].Value.ToString();
                            nhacungcap.MaTinh = grvNCC.CurrentRow.Cells["ColMaTinh"].Value.ToString();
                            nhacungcap.SoDT = grvNCC.CurrentRow.Cells["ColSoDT"].Value.ToString();
                            nhacungcap.SoFax = grvNCC.CurrentRow.Cells["ColSoFax"].Value.ToString();
                            nhacungcap.Email = grvNCC.CurrentRow.Cells["ColEmail"].Value.ToString();
                            NCCBLL.SuaNCC(manhacungcap, maloaihang, nhacungcap);
                            LoadDanhSachNCC();
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
            bds.DataSource = NCCBLL.LayDanhSachNhaCungCapTheoMa(txtTimKiem.Text);
            grvNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            SetControlEnable(false);
        }

        private void NvgRefresh_Click(object sender, EventArgs e)
        {
            FrmNhaCungCap_Load(sender, e);
        }

        private void NvgHuy_Click(object sender, EventArgs e)
        {
            LoadDanhSachNCC();
        }

        private void btnTimMaNCC_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNhaCungCapTheoMa(txtTimKiemMaNCC.Text);
            grvNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = grvNCC.RowCount.ToString();
        }

        private void btnTimTenNCC_Click(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNhaCungCapTheoTen(txtTimKiemTenNCC.Text);
            grvNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = grvNCC.RowCount.ToString();
        }

        private void cmbTimKiemMaTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = NCCBLL.LayDanhSachNCCTheoMaTinhThanh(cmbTimKiemMaTinhThanh.SelectedValue.ToString());
            grvNCC.DataSource = bds;
            bindingNCC.BindingSource = bds;
            SetControlEnable(false);
            txtRecords.Text = grvNCC.RowCount.ToString();
        }
        int loadtreeview = 0;
        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            if (loadtreeview == 0)
            {
                LoadTreeView();
            }
            loadtreeview++;
            LoadDataColumnCombobox();
            LoadDataComboboxLoaiHang();
            LoadDatacmbMaTinh();
            LoadDanhSachNCC();
        }
        private string xuly_chuoi(string chuoi)
        {
            int vt = chuoi.LastIndexOf("=");
            int vt2 = chuoi.LastIndexOf("}");
            string s1 = chuoi.Substring(vt+1,vt2-vt-1).Trim();
            return s1;
        }
        private void advTreeTinhThanh_AfterNodeSelect_1(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            if (e.Node.Level == 0)
                LoadDanhSachNCC();
            else
            {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = NCCBLL.LayDanhSachNCCTheoTenTinhThanh(xuly_chuoi(e.Node.Text));
                    grvNCC.DataSource = bds;
                    bindingNCC.BindingSource = bds;
            }

        }    
    }
}
