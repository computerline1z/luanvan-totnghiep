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
        public string maphieuxuat;
        public string id_patch;
        private void LayHang(string maphieuxuat)
        {
            ColMH.DataSource = CTPXBLL.LayMaHang(maphieuxuat);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";
        }
        private void LayKhoHang(string maphieuxuat)
        {
            ColMKH.DataSource = CTPXBLL.LayKhoHang(maphieuxuat);
            ColMKH.DisplayMember = "TenKhoHang";
            ColMKH.ValueMember = "MaKhoHang";
        }
        private void LayDanhSachChiTietPhieuXuat(string maphieuxuat)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPXBLL.LayChiTietPhieuXuatTheoMaPhieuXuat(maphieuxuat);
            bindingCTPX.BindingSource = bds;
            gridChiTietPhieuXuat.DataSource = bds;
            gridChiTietPhieuXuat.AllowUserToAddRows = false;
        }
        
        int th_ctpx = 0;
        private void FrmChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            LayHang(maphieuxuat);
            LayKhoHang(maphieuxuat);
            LayDanhSachChiTietPhieuXuat(maphieuxuat);
        }

        private void gridChiTietPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (th_ctpx == 1)
            {
                gridChiTietPhieuXuat.CurrentRow.Cells["ColMPX"].Value = maphieuxuat;
                gridChiTietPhieuXuat.CurrentRow.Cells["ColMLX"].Value = id_patch;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FrmChiTietPhieuXuat_Load(sender, e);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachChiTietPhieuXuat(maphieuxuat);
            }
            else
                return;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridChiTietPhieuXuat.RowCount == 0)
                Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa chi tiết phiếu nhập này không-Số Lượng hàng trong kho chứa sẽ bị giảm đi?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string mahang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMH"].Value.ToString();
                string makhohang = gridChiTietPhieuXuat.CurrentRow.Cells["ColMKH"].Value.ToString();
                int sl = System.Convert.ToInt16(gridChiTietPhieuXuat.CurrentRow.Cells["ColSL"].Value);
                bool xoa = CTPXBLL.XoaCTPX(maphieuxuat, id_patch, mahang);
                LayDanhSachChiTietPhieuXuat(maphieuxuat);
                if (xoa == true)
                {
                    CTPXBLL.CapNhatLaiKhoChuaKhiXoaCTPX(mahang, makhohang, sl);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            switch (th_ctpx)
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
                            CTPXBLL.CapNhatLaiKhoChua(mahang, makhohang, sl);
                            bool sua = CTPXBLL.SuaCTPX(maphieuxuat, id_patch, mahang, CTPX);
                            LayDanhSachChiTietPhieuXuat(maphieuxuat);
                            if (sua == true)
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
                            bool them = CTPXBLL.ThemCTPX(maphieuxuat, id_patch, mahang, makhohang, sl, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachChiTietPhieuXuat(maphieuxuat);
                            th_ctpx = 0;
                            if (them == true)
                            {
                                CTPXBLL.CapNhatKhoChua(mahang, makhohang);
                            }
                        }
                        else
                        {
                            th_ctpx = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            th_ctpx = 1;
            gridChiTietPhieuXuat.AllowUserToAddRows = true;
            bindingCTPX.BindingSource.MoveLast();
            gridChiTietPhieuXuat.Rows[gridChiTietPhieuXuat.RowCount - 1].Cells["ColMPX"].Value = maphieuxuat;
            gridChiTietPhieuXuat.Rows[gridChiTietPhieuXuat.RowCount - 1].Cells["ColMLX"].Value = id_patch;
            gridChiTietPhieuXuat.Rows[gridChiTietPhieuXuat.RowCount - 1].Cells["ColMH"].ReadOnly = false;
        }
    }
}