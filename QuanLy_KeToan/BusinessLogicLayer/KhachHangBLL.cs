using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Khach_Hang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang{ get; set; }
        public string DCKH { get; set; }
        public string MaTinhThanh { get; set; }
        public string SoDT { get; set; }
        public string SoFax { get; set; }
        public string Email { get; set; }
        //public DateTime NgayLap { get; set; }
        //public string NguoiLap { get; set; }
        //public DateTime NgaySua { get; set; }
        //public string NguoiSua { get; set; }
    }
    class KhachHangBLL
    {
         QuanLy_KeToanDataContext QLKT=new QuanLy_KeToanDataContext();
        //Lay danh sách Khách Hàng
        public List<Khach_Hang> LayDanhSachKhachHang()
        {
            var khachhang=(from kh in QLKT.KhachHangs 
                           select new Khach_Hang
                           {
                               MaKhachHang=kh.MaKhachHang,
                               TenKhachHang=kh.TenKhachHang,
                               DCKH=kh.DCKH,
                               MaTinhThanh=kh.MaTinhThanh,
                               SoDT=kh.SoDT,
                               SoFax=kh.SoFax,
                               Email=kh.Email
                           }).ToList<Khach_Hang>();
            return khachhang;

        }
        //Lấy Danh Sách Khách Hàng Theo Tên Tỉnh
        public List<Khach_Hang> LayDanhSachKhachHangTheoTenTinhThanh(string tentinh)
        {
            var kh = (from khachhang in QLKT.KhachHangs
                      from tinhthanh in QLKT.TinhThanhs
                      where ((khachhang.MaTinhThanh == tinhthanh.MaTinh) && (tinhthanh.TenTinh == tentinh))
                      select new Khach_Hang
                      {
                          MaKhachHang = khachhang.MaKhachHang,
                          TenKhachHang = khachhang.TenKhachHang,
                          DCKH = khachhang.DCKH,
                          MaTinhThanh = khachhang.MaTinhThanh,
                          SoDT = khachhang.SoDT,
                          SoFax = khachhang.SoFax,
                          Email = khachhang.Email,
                      }).ToList<Khach_Hang>();
                     
            return kh;
        }

        //Lấy Danh Sách Tên Tỉnh Theo Mã Tỉnh
        public IQueryable LayDanhSachTenTinhTheoMaTinh(string matinh)
        {
            var tentinh = from tt in QLKT.TinhThanhs
                          where tt.MaTinh == matinh
                          select tt.TenTinh;
            return tentinh;
        }
        //Lấy Danh Sách Mã Tỉnh cho ColMaTinhThanh và comboMaTinhThanh
        public IQueryable LayDanhSachMaTinh()
        {
            var tinhthanh = from tt in QLKT.TinhThanhs
                           select new { tt.MaTinh,tt.TenTinh };
            return tinhthanh.Distinct();
        }
        //Lấy Danh Sách Tỉnh Thành cho TreeView
        public IQueryable LayDanhSachTinhThanh()
        {
            var tentinhthanh = from tt in QLKT.TinhThanhs
                         select tt.TenTinh;
            return tentinhthanh;
        }
        //Kiểm tra 1 khách hàng có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraKhachHang(string makh)
        {
            var khachhang = from kh in QLKT.KhachHangs
                             where kh.MaKhachHang == makh
                             select kh;
            if (khachhang.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm khách hàng
        public void ThemKH(string MaKhachHang, string TenKhachHang, string DCKH, string MaTinhThanh, String SoDT, string SoFax, string Email)
        {
            if (KiemtraKhachHang(MaKhachHang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.KhachHang KH = new QuanLy_KeToan.DataAccessLayer.KhachHang();
                KH.MaKhachHang = MaKhachHang;
                KH.TenKhachHang = TenKhachHang;
                KH.DCKH = DCKH;
                KH.MaTinhThanh = MaTinhThanh;
                KH.SoDT = SoDT;
                KH.SoFax = SoFax;
                KH.Email = Email;
                QLKT.KhachHangs.InsertOnSubmit(KH);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
          //Sửa 1 khách hàng
        public void SuaKH(string makh, QuanLy_KeToan.DataAccessLayer.KhachHang KH)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.KhachHang kh = QLKT.KhachHangs.Single(khachhang => khachhang.MaKhachHang == makh);
                kh.TenKhachHang = KH.TenKhachHang;
                kh.DCKH = KH.DCKH;
                kh.MaTinhThanh = KH.MaTinhThanh;
                kh.SoDT = KH.SoDT;
                kh.SoFax = KH.SoFax;
                kh.Email = KH.Email;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Kiểm tra khách hàng này có trong hóa đơn bán không?-phục vụ hàm xóa
        private bool KiemTraHoaDonBan(string makh)
        {
            var sql=from hdb in QLKT.HoaDonBans
                    where hdb.MaKhachHang==makh
                    select hdb;
            if (sql.Count() > 0)
                return true;
            else
                return false;

        }
        //Xóa khách hàng
        public void XoaKH(string makh)
        {
            if (KiemTraHoaDonBan(makh) == true)
            {
                MessageBox.Show("Không thể xóa dòng dữ liệu này-Liên quan đến dữ liệu Hóa đơn bán", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var delete = from kh in QLKT.KhachHangs
                             where kh.MaKhachHang == makh 
                             select kh;
                if (delete.Count() > 0)
                {
                    QLKT.KhachHangs.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Các Hàm phục vụ cho việc tìm kiếm
        public List<Khach_Hang> TimTatCaKhachHangTheoMaTinhThanh(string matinhthanh)
        {
            var khachhang = (from kh in QLKT.KhachHangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where kh.MaTinhThanh == matinhthanh
                        select new Khach_Hang
                        {
                            MaKhachHang = kh.MaKhachHang,
                            TenKhachHang = kh.TenKhachHang,
                            DCKH = kh.DCKH,
                            MaTinhThanh = kh.MaTinhThanh,
                            SoDT = kh.SoDT,
                            SoFax = kh.SoFax,
                            Email=kh.Email,
                        }).ToList<Khach_Hang>();
            return khachhang;
        }

        //Tìm gần đúng
        public List<Khach_Hang> TimTatCaKhachHangTheoMaKhachHang(string makhachhang)
        {
            var khachhang = (from kh in QLKT.KhachHangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where kh.MaKhachHang.Contains(makhachhang)
                        select new Khach_Hang
                        {
                            MaKhachHang = kh.MaKhachHang,
                            TenKhachHang = kh.TenKhachHang,
                            DCKH = kh.DCKH,
                            MaTinhThanh = kh.MaTinhThanh,
                            SoDT = kh.SoDT,
                            SoFax = kh.SoFax,
                            Email=kh.Email,                         
                        }).ToList<Khach_Hang>();
            return khachhang;
        }
        //Tìm chính xác
        public List<Khach_Hang> TimTatCaKhachHangChinhXacTheoMaKhachHang(string makhachhang)
        {
            var khachhang = (from kh in QLKT.KhachHangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where kh.MaKhachHang == makhachhang
                        select new Khach_Hang
                        {
                            MaKhachHang = kh.MaKhachHang,
                            TenKhachHang = kh.TenKhachHang,
                            DCKH = kh.DCKH,
                            MaTinhThanh = kh.MaTinhThanh,
                            SoDT = kh.SoDT,
                            SoFax = kh.SoFax,
                            Email = kh.Email,   
                        }).ToList<Khach_Hang>();
            return khachhang;
        }
        //Tìm theo tên khách hàng
        public List<Khach_Hang> TimTatCaKhachHangChinhXacTheoTenKhachHang(string tenkhachhang)
        {
            var khachhang = (from kh in QLKT.KhachHangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where kh.TenKhachHang == tenkhachhang
                        select new Khach_Hang
                        {
                            MaKhachHang = kh.MaKhachHang,
                            TenKhachHang = kh.TenKhachHang,
                            DCKH = kh.DCKH,
                            MaTinhThanh = kh.MaTinhThanh,
                            SoDT = kh.SoDT,
                            SoFax = kh.SoFax,
                            Email = kh.Email,   
                        }).ToList<Khach_Hang>();
            return khachhang;
        }
        public IQueryable LayDanhSachMKH()
        {
            var kh = from khachhang in QLKT.KhachHangs
                      select new { khachhang.MaKhachHang };
            return kh.Distinct();
        }
       
        public List<Khach_Hang> LayDanhSachKhachHangTheoTen(string tenkh)
        {
            var khachhang = (from kh in QLKT.KhachHangs
                              where kh.TenKhachHang.Contains(tenkh)
                              select new Khach_Hang
                              {
                                  MaKhachHang = kh.MaKhachHang,
                                  TenKhachHang = kh.TenKhachHang,
                                  DCKH = kh.DCKH,
                                  MaTinhThanh = kh.MaTinhThanh,
                                  SoDT = kh.SoDT,
                                  SoFax = kh.SoFax,
                                  Email = kh.Email,
                              }).ToList<Khach_Hang>();
            return khachhang;
        }
    }
}
    