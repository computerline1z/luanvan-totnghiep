using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Phieu_Xuat
    {
        public string maphieuxuat { get; set; }
        public string maloaiphieuxuat { get; set; }
        public string maloxuat { get; set; }
        public string makhachhang { get; set; }
        public DateTime ngayphieuxuat { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class PhieuXuatBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Phieu_Xuat> LayDSPhieuXuat(string maloxuat)
        {
            var sql = (from px in QLKT.PhieuXuats
                       where px.MaLoXuat == maloxuat
                       select new Phieu_Xuat
                       {
                           maphieuxuat = px.MaPhieuXuat,
                           maloaiphieuxuat = px.MaLoaiPhieuXuat,
                           maloxuat = px.MaLoXuat,
                           makhachhang = px.MaKhachHang,
                           ngayphieuxuat = Convert.ToDateTime(px.NgayPhieuXuat == null ? DateTime.Today : px.NgayPhieuXuat),
                           mota = px.MoTa,
                           ngaylap = Convert.ToDateTime(px.NgayLap == null ? DateTime.Today : px.NgayLap),
                           nguoilap = px.NguoiLap,
                           ngaysua = Convert.ToDateTime(px.NgaySua == null ? DateTime.Today : px.NgaySua),
                           nguoisua = px.NguoiSua,

                       }).ToList<Phieu_Xuat>();
            return sql;
        }
        private bool KiemTraDulieu(string maphieuxuat, string maloxuat)
        {
            var sql = from px in QLKT.PhieuXuats
                      where px.MaPhieuXuat == maphieuxuat && px.MaLoXuat == maloxuat
                      select px;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public void ThemPhieuXuat(string maphieuxuat, string maloaiphieuxuat, string maloxuat, string makh, DateTime ngayphieuxuat, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(maphieuxuat, maloxuat) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PhieuXuat PX = new PhieuXuat();
                PX.MaPhieuXuat = maphieuxuat;
                PX.MaLoaiPhieuXuat = maloaiphieuxuat;
                PX.MaLoXuat = maloxuat;
                PX.MaKhachHang = makh;
                PX.NgayPhieuXuat = ngayphieuxuat;
                PX.MoTa = mota;
                PX.NgayLap = ngaylap;
                PX.NguoiLap = nguoilap;
                PX.NgaySua = ngaysua;
                PX.NguoiSua = nguoisua;
                QLKT.PhieuXuats.InsertOnSubmit(PX);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaPX(string maphieuxuat, string maloxuat, PhieuXuat PX)
        {
            try
            {
                PhieuXuat px = QLKT.PhieuXuats.Single(_px => _px.MaPhieuXuat == maphieuxuat && _px.MaLoXuat == maloxuat);
                px.MaLoaiPhieuXuat = PX.MaLoaiPhieuXuat;
                px.MaKhachHang = PX.MaKhachHang;
                px.NgayPhieuXuat = PX.NgayPhieuXuat;
                px.MoTa = PX.MoTa;
                px.NgayLap = PX.NgayLap;
                px.NguoiLap = PX.NguoiLap;
                px.NgaySua = PX.NgaySua;
                px.NguoiSua = PX.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraMaPhieuXuatChiTietPhieuXuat(string maphieuxuat, string maloxuat)
        {
            var sql = from ctpx in QLKT.ChiTietPhieuXuats
                      where ctpx.MaPhieuXuat == maphieuxuat && ctpx.MaLoXuat == maloxuat
                      select ctpx;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaPX(string maphieuxuat, string maloxuat)
        {
            if (KiemTraMaPhieuXuatChiTietPhieuXuat(maphieuxuat, maloxuat) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from px in QLKT.PhieuXuats
                             where px.MaPhieuXuat == maphieuxuat && px.MaLoXuat == maloxuat
                             select px;
                if (delete.Count() > 0)
                {
                    QLKT.PhieuXuats.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hàm load dữ liệu lên các combobox column
        public IQueryable LayMaLoaiPhieuXuat()
        {
            var sql = from lpx in QLKT.LoaiPhieuXuats
                      select new
                      {
                          lpx.MaLoaiPhieuXuat,
                          lpx.TenLoaiPhieuXuat,
                      };
            return sql;
        }
        public IQueryable LayMaKhachHang()
        {
            var sql = (from kh in QLKT.KhachHangs
                       select new
                       {
                           kh.MaKhachHang,
                           kh.TenKhachHang,
                       }).Distinct();
            return sql;
        }
    }
}
