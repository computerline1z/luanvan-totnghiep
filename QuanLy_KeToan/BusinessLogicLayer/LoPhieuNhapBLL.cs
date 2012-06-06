using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Lo_Phieu_Nhap
    {
        public string malohdmua { get; set; }
        public DateTime ngaylonhap { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoPhieuNhapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy dữ liệu cho Treeview
        public IQueryable LayDanhSachMaLoHDMua()
        {
            var sql = from lonhap in QLKT.LoPhieuNhaps
                     select new {lonhap.MaLoHDMua,lonhap.NgayLoNhap.Value.Date,lonhap.MoTa,};
            return sql;
        }
        //Lấy mã lô hóa đơn cho combobox
        public IQueryable LayMaLoHDMua()
        {
            var sql = from lohdmua in QLKT.LoHDMuas
                      select new { lohdmua.MaLoHDMua };
            return sql;
        }
        public List<Lo_Phieu_Nhap> LayDanhSachLoPhieuNhap()
        {
            var sql = (from lpn in QLKT.LoPhieuNhaps
                       select new Lo_Phieu_Nhap
                       {
                           malohdmua = lpn.MaLoHDMua,
                           ngaylonhap = Convert.ToDateTime(lpn.NgayLoNhap),
                           mota = lpn.MoTa,
                           ngaylap = Convert.ToDateTime(lpn.NgayLap == null ? DateTime.Today : lpn.NgayLap),
                           nguoilap = lpn.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpn.NgaySua == null ? DateTime.Today : lpn.NgaySua),
                           nguoisua = lpn.NguoiSua,
                       }).ToList<Lo_Phieu_Nhap>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdmua)
        {
            var sql=from lpn in QLKT.LoPhieuNhaps
                    where lpn.MaLoHDMua==malohdmua
                    select lpn;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        //Thêm-xóa-sửa
        public void ThemLoPN(string malohdmua,DateTime ngaylonhap, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoPhieuNhap LPN = new LoPhieuNhap();
                LPN.MaLoHDMua = malohdmua;
                LPN.NgayLoNhap = ngaylonhap;
                LPN.MoTa = mota;
                LPN.NgayLap = ngaylap;
                LPN.NguoiLap = nguoilap;
                LPN.NgaySua = ngaysua;
                LPN.NguoiSua = nguoisua;
                QLKT.LoPhieuNhaps.InsertOnSubmit(LPN);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoPN(string malohdmua,LoPhieuNhap LPN)
        {
            try
            {
                LoPhieuNhap lpn = QLKT.LoPhieuNhaps.Single(_lpn => _lpn.MaLoHDMua == malohdmua);
                lpn.NgayLoNhap = LPN.NgayLoNhap;
                lpn.MoTa = LPN.MoTa;
                lpn.NgayLap = LPN.NgayLap;
                lpn.NguoiLap = LPN.NguoiLap;
                lpn.NgaySua = LPN.NgaySua;
                lpn.NguoiSua = LPN.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraLoPhieuNhapTrongPhieuNhap(string malohdmua)
        {
            var sql = from lpn in QLKT.PhieuNhaps
                      where lpn.MaLoHDMua == malohdmua
                      select lpn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaLPN(string malohdmua)
        {
            if (KiemTraLoPhieuNhapTrongPhieuNhap(malohdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpn in QLKT.LoPhieuNhaps
                             where lpn.MaLoHDMua == malohdmua
                             select lpn;
                if (delete.Count() > 0)
                {
                    QLKT.LoPhieuNhaps.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public IQueryable LayNguoiLap()
        {
            var sql = from phanquyen in QLKT.PhanQuyens
                      select new { phanquyen.TenDangNhap };
            return sql;
        }
    }
}
