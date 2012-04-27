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
    }
}
