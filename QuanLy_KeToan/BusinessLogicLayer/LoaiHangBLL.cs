using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class LoaiHangHoa
    {
        public string MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }
        public string MoTaLoaiHang { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class LoaiHangBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy Danh Sách Loại Hàng Hóa
        public List<LoaiHangHoa> LoadDanhSachLoaiHangHoa()
        {
            var hang = (from lh in QLKT.LoaiHangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        select new LoaiHangHoa
                        {
                           MaLoaiHang=lh.MaLoaiHang,
                           TenLoaiHang=lh.TenLoaiHang,
                           MoTaLoaiHang=lh.MoTaLoaiHang,
                           NgayLap=Convert.ToDateTime(lh.NgayLap),
                           NguoiLap=lh.NguoiLap,
                           NgaySua=Convert.ToDateTime(lh.NgaySua),
                           NguoiSua=lh.NguoiSua
                        }).ToList<LoaiHangHoa>();
            return hang;
        }

    }
}
