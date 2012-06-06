using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Loai_Phieu_Nhap
    {
        public string maloaiphieunhap { get; set; }
        public string tenloaiphieunhap { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoaiPhieuNhapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Loai_Phieu_Nhap> LayDanhSachLoaiPhieuNhap()
        {
            var sql = (from lpn in QLKT.LoaiPhieuNhaps
                       select new Loai_Phieu_Nhap
                       {
                           maloaiphieunhap = lpn.MaLoaiPhieuNhap,
                           tenloaiphieunhap = lpn.TenLoaiPhieuNhap,
                           ngaylap = Convert.ToDateTime(lpn.NgayLap == null ? DateTime.Today : lpn.NgayLap),
                           nguoilap = lpn.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpn.NgaySua == null ? DateTime.Today : lpn.NgaySua),
                           nguoisua = lpn.NguoiSua,
                       }).ToList<Loai_Phieu_Nhap>();
            return sql;
        }
        //Kiểm tra 1 Loại Phiếu Nhập có trong csdl chưa
        private bool KiemTraLoaiPhieuNhap(string maloaiphieunhap)
        {
            var sql = from lpn in QLKT.LoaiPhieuNhaps
                      where lpn.MaLoaiPhieuNhap == maloaiphieunhap
                      select lpn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Thao tác Thêm-Xóa-Sửa
        public void ThemLoaiPhieuNhap(string maloaiphieunhap, string tenloaiphieunhap,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraLoaiPhieuNhap(maloaiphieunhap) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoaiPhieuNhap LPN = new LoaiPhieuNhap();
                LPN.MaLoaiPhieuNhap = maloaiphieunhap;
                LPN.TenLoaiPhieuNhap = tenloaiphieunhap;
                LPN.NgayLap = ngaylap;
                LPN.NguoiLap = nguoilap;
                LPN.NgaySua = ngaysua;
                LPN.NguoiSua = nguoisua;
                QLKT.LoaiPhieuNhaps.InsertOnSubmit(LPN);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoaiPhieuNhap(string maloaiphieunhap,LoaiPhieuNhap LPN)
        {
            try
            {
                LoaiPhieuNhap lpn = QLKT.LoaiPhieuNhaps.Single(_lpn => _lpn.MaLoaiPhieuNhap == maloaiphieunhap);
                lpn.TenLoaiPhieuNhap = LPN.TenLoaiPhieuNhap;
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
        private bool KiemTraLoaiPhieuNhapTrongPhieuNhap(string maloaiphieunhap)
        {
            var sql=from pn in QLKT.PhieuNhaps
                    where pn.MaLoaiPhieuNhap==maloaiphieunhap
                    select pn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaLoaiPhieuNhap(string maloaiphieunhap)
        {
            if (KiemTraLoaiPhieuNhapTrongPhieuNhap(maloaiphieunhap) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpn in QLKT.LoaiPhieuNhaps
                             where lpn.MaLoaiPhieuNhap == maloaiphieunhap
                             select lpn;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiPhieuNhaps.DeleteOnSubmit(delete.First());
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
