using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class HangBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Hang> LayDanhSachHangHoa()
        {
            var hang = from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                       select h;
            return hang.ToList();
        }
        public IQueryable<String> LayDanhSachLoaiHang()
        {
            var loaihang = from lh in QLKT.LoaiHangs
                           select lh.TenLoaiHang;
            return loaihang;
        }
        public List<Hang> LayDanhSachHangTheoLoaiHang(string tenloaihang)
        {
            var hang = from h in QLKT.Hangs
                       from lh in QLKT.LoaiHangs
                       where ((h.MaLoaiHang == lh.MaLoaiHang) && (lh.TenLoaiHang == tenloaihang))
                       select h;
            return hang.ToList();      
        }
        public IQueryable<String> LayDanhSachTenNCC()
        {
            var tenncc = from ncc in QLKT.NhaCungCaps
                         select ncc.TenNCC;
            return tenncc.Distinct();
        }
        public IQueryable<String> LayDanhSachLoaiHangTheoNCC(string tenncc)
        {
            var loaihang = from ncc in QLKT.NhaCungCaps
                           where ncc.TenNCC == tenncc
                           select ncc.MaLoaiHang;
            return loaihang.Distinct();
        }
        public List<Hang> LayDanhSachHangTheoTenNhaCungCap(string tenncc,string maloaihang)
        {
            var hang = from h in QLKT.Hangs
                       from ncc in QLKT.NhaCungCaps
                       where ((h.MaNCC == ncc.MaNCC) && (ncc.TenNCC == tenncc)&&(ncc.MaLoaiHang==maloaihang)&&(h.MaLoaiHang==ncc.MaLoaiHang))
                       select h;
            return hang.ToList();
        }
    }
}
