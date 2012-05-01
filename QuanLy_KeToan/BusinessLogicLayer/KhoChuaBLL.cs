using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Kho_Chua
    {
        public string makhohang { get; set; }
        public string mahang { get; set; }
        public int sl { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class KhoChuaBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        public IQueryable LayDSKhoHang()
        {
            var sql = from kh in QLKT.KhoHangs
                      select new { kh.MaKhoHang, kh.TenKhoHang, };
            return sql;
        }
        public IQueryable LayDSHangTheoMaLoaiHang()//đáng lẽ lấy hàng theo mã loại hàng,tuy nhiên do combobox column không tự Refresh được.
        {
            var sql = from hang in QLKT.Hangs
                      select new { hang.MaHang,hang.TenHang };
            return sql;
        }
        public List<Kho_Chua> LayDanhSachKhoChuaTheoMaKhoHang(string makhohang)
        {
            var sql = (from khochua in QLKT.KhoChuas
                       where khochua.MaKhoHang == makhohang
                       select new Kho_Chua
                       {
                           makhohang = khochua.MaKhoHang,
                           mahang = khochua.MaHang,
                           sl = System.Convert.ToInt16(khochua.SL),
                           ngaylap = Convert.ToDateTime(khochua.NgayLap == null ? DateTime.Today : khochua.NgayLap),
                           nguoilap = khochua.NguoiLap,
                           ngaysua = Convert.ToDateTime(khochua.NgaySua == null ? DateTime.Today : khochua.NgaySua),
                           nguoisua=khochua.NguoiSua,
                       }).ToList<Kho_Chua>();
            return sql;
        }
        public List<Kho_Chua> LayDanhSachKhoChuaTheoMaKho(string makho)
        {
            var sql = (from khochua in QLKT.KhoChuas
                       where khochua.MaKhoHang==makho
                       select new Kho_Chua
                       {
                           makhohang = khochua.MaKhoHang,
                           mahang = khochua.MaHang,
                           sl = System.Convert.ToInt16(khochua.SL),
                           ngaylap = Convert.ToDateTime(khochua.NgayLap == null ? DateTime.Today : khochua.NgayLap),
                           nguoilap = khochua.NguoiLap,
                           ngaysua = Convert.ToDateTime(khochua.NgaySua == null ? DateTime.Today : khochua.NgaySua),
                           nguoisua = khochua.NguoiSua,
                       }).ToList<Kho_Chua>();
            return sql;
        }
        public List<Kho_Chua> LayDanhSachKhoChuaTheoMaHang(string mahang)
        {
            var sql = (from khochua in QLKT.KhoChuas
                       where khochua.MaHang==mahang
                       select new Kho_Chua
                       {
                           makhohang = khochua.MaKhoHang,
                           mahang = khochua.MaHang,
                           sl = System.Convert.ToInt16(khochua.SL),
                           ngaylap = Convert.ToDateTime(khochua.NgayLap == null ? DateTime.Today : khochua.NgayLap),
                           nguoilap = khochua.NguoiLap,
                           ngaysua = Convert.ToDateTime(khochua.NgaySua == null ? DateTime.Today : khochua.NgaySua),
                           nguoisua = khochua.NguoiSua,
                       }).ToList<Kho_Chua>();
            return sql;
        }
        public List<Kho_Chua> LayDanhSachKhoChuaTheoTenHang(string tenhang)
        {
            var sql = (from khochua in QLKT.KhoChuas
                       from hang in QLKT.Hangs
                       where khochua.MaHang == hang.MaHang && hang.TenHang.Contains(tenhang)
                       select new Kho_Chua
                       {
                           makhohang = khochua.MaKhoHang,
                           mahang = khochua.MaHang,
                           sl = System.Convert.ToInt16(khochua.SL),
                           ngaylap = Convert.ToDateTime(khochua.NgayLap == null ? DateTime.Today : khochua.NgayLap),
                           nguoilap = khochua.NguoiLap,
                           ngaysua = Convert.ToDateTime(khochua.NgaySua == null ? DateTime.Today : khochua.NgaySua),
                           nguoisua = khochua.NguoiSua,
                       }).ToList<Kho_Chua>();
            return sql;
        }
        public List<Kho_Chua> LayDanhSachKhoChuaTheoTinhTrang(string tinhtrang)
        {
            switch (tinhtrang)
            {
                case "=0":
                    {
                        var sql = (from khochua in QLKT.KhoChuas
                               where khochua.SL == 0
                               select new Kho_Chua
                               {
                                   makhohang = khochua.MaKhoHang,
                                   mahang = khochua.MaHang,
                                   sl = System.Convert.ToInt16(khochua.SL),
                                   ngaylap = Convert.ToDateTime(khochua.NgayLap == null ? DateTime.Today : khochua.NgayLap),
                                   nguoilap = khochua.NguoiLap,
                                   ngaysua = Convert.ToDateTime(khochua.NgaySua == null ? DateTime.Today : khochua.NgaySua),
                                   nguoisua = khochua.NguoiSua,
                               }).ToList<Kho_Chua>();
                        return sql;
                    }
                case ">0":
                    {
                       var sql = (from khochua in QLKT.KhoChuas
                               where khochua.SL > 0
                               select new Kho_Chua
                               {
                                   makhohang = khochua.MaKhoHang,
                                   mahang = khochua.MaHang,
                                   sl = System.Convert.ToInt16(khochua.SL),
                                   ngaylap = Convert.ToDateTime(khochua.NgayLap == null ? DateTime.Today : khochua.NgayLap),
                                   nguoilap = khochua.NguoiLap,
                                   ngaysua = Convert.ToDateTime(khochua.NgaySua == null ? DateTime.Today : khochua.NgaySua),
                                   nguoisua = khochua.NguoiSua,
                               }).ToList<Kho_Chua>();

                       return sql;
                    }
            }
            return null;
        }

        //Hàm thống kê
        
        public int ThongKeSLHangTrongKho(string makho)
        {
            int tong = 0;
            var kt = from khochua in QLKT.KhoChuas
                     where khochua.MaKhoHang == makho
                     select khochua;
            if (kt.Count() == 0)
                return tong;
            var sql = from khochua in QLKT.KhoChuas
                      group khochua by khochua.MaKhoHang == makho into result
                      select new { tong = result.Sum(i => i.SL) };
            foreach (var item in sql)
            {
                tong= int.Parse(item.tong.ToString());
            }
            return tong;
        }
        public int ThongKeSLMatHangTrongKho(string makho)
        {
            int tong = 0;
            var kt = from khochua in QLKT.KhoChuas
                     where khochua.MaKhoHang == makho
                     select khochua;
            if (kt.Count() == 0)
                return tong;
            var sql = from khochua in QLKT.KhoChuas
                      group khochua by khochua.MaKhoHang == makho into result
                      select new { tong = result.Count(), };
            foreach (var item in sql)
            {
                tong = int.Parse(item.tong.ToString());
            }
            return tong;
        }
        public int ThongKeSoLuongKhoHang()
        {
            int tong = 0;
            var sql = from khohang in QLKT.KhoHangs
                      group khohang by khohang.MaKhoHang into result
                      select new { kho = result.Count(), };
            foreach (var item in sql)
            {
                tong += int.Parse(item.kho.ToString());
            }
            return tong;
        }
        public decimal ThongKeTongGiaTriHang(string makho)
        {
            decimal tong = 0;
            var sql = from khochua in QLKT.KhoChuas
                      from hang in QLKT.Hangs
                      where (khochua.MaHang == hang.MaHang && khochua.MaKhoHang==makho)
                      select new
                      {
                          giatri = khochua.SL * hang.DonGia,
                      };
            foreach (var item in sql)
            {
                tong += System.Convert.ToDecimal(item.giatri);
            }
            return tong;
        }

        //Kiểm tra có 1 Hàng có trong kho chứa chưa
        private bool KiemTraKhoChua(string makhohang,string mahang)
        {
            var sql = from kc in QLKT.KhoChuas
                          where kc.MaKhoHang == makhohang && kc.MaHang==mahang
                          select kc;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Thao tác Thêm-Xóa-Sửa
        public void ThemKhoChua(string makhohang,string mahang,int sl,DateTime ngaylap,string nguoilap,DateTime ngaysua,string nguoisua)
        {
            if (KiemTraKhoChua(makhohang,mahang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                KhoChua KC = new KhoChua();
                KC.MaKhoHang = makhohang;
                KC.MaHang = mahang;
                KC.SL = sl;
                KC.NgayLap = ngaylap;
                KC.NguoiLap = nguoilap;
                KC.NgaySua = ngaysua;
                KC.NguoiSua = nguoisua;
                QLKT.KhoChuas.InsertOnSubmit(KC);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaKhoChua(string makhohang, string mahang,KhoChua KhCh)
        {
            try
            {
                KhoChua KC = QLKT.KhoChuas.Single(kc => kc.MaKhoHang == makhohang && kc.MaHang==mahang);
                KC.SL = KhCh.SL;
                KC.NgayLap = KhCh.NgayLap;
                KC.NguoiLap = KhCh.NguoiLap;
                KC.NgaySua = KhCh.NgaySua;
                KC.NguoiSua = KhCh.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraCTPN(string mahang)
        {
            var sql=from ctpn in QLKT.ChiTietPhieuNhaps
                    where ctpn.MaHang==mahang
                    select ctpn;
            if (sql.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }
        public void XoaKhoChua(string makhohang, string mahang)
        {
            if (KiemTraCTPN(mahang) == true)
            {
                MessageBox.Show("Không xóa được dữ liệu này-Liên quan đến Table chi tiết phiếu nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                    var delete = from khochua in QLKT.KhoChuas
                                 where khochua.MaKhoHang == makhohang&& khochua.MaHang==mahang
                                 select khochua;
                    if (delete.Count() > 0)
                    {
                        QLKT.KhoChuas.DeleteOnSubmit(delete.First());
                        QLKT.SubmitChanges();
                        MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
