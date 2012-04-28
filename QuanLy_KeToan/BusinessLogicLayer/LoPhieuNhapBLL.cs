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
        public string malonhap { get; set; }
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
        public IQueryable LayDanhSachMaLoNhap()
        {
            var sql = from lonhap in QLKT.LoPhieuNhaps
                     select new {lonhap.MaLoNhap,lonhap.NgayLoNhap.Value.Date,};
            return sql;
        }
        public List<Lo_Phieu_Nhap> LayDanhSachLoPhieuNhap()
        {
            var sql = (from lpn in QLKT.LoPhieuNhaps
                       select new Lo_Phieu_Nhap
                       {
                           malonhap = lpn.MaLoNhap,
                           ngaylonhap = Convert.ToDateTime(lpn.NgayLoNhap == null ? DateTime.Today : lpn.NgayLoNhap),
                           mota = lpn.MoTa,
                           ngaylap = Convert.ToDateTime(lpn.NgayLap == null ? DateTime.Today : lpn.NgayLap),
                           nguoilap = lpn.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpn.NgaySua == null ? DateTime.Today : lpn.NgaySua),
                           nguoisua = lpn.NguoiSua,
                       }).ToList<Lo_Phieu_Nhap>();
            return sql;
        }
    }
}
