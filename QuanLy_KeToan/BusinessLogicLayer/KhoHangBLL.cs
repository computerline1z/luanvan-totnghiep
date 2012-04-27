using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Kho_Hang
    {
        public string makhohang { get; set; }
        public string maloaihang { get; set; }
        public string tenkhohang { get; set; }
        public string diachikhohang { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class KhoHangBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public IQueryable LayDanhSachLoaiHang()
        {
            var loaihang = from lh in QLKT.LoaiHangs
                           select new { lh.MaLoaiHang, lh.TenLoaiHang, };
            return loaihang;
        }
        public List<Kho_Hang> LayDanhSachKhoHang()
        {
            var khohang = (from kh in QLKT.KhoHangs
                           select new Kho_Hang
                           {
                               makhohang=kh.MaKhoHang,
                               maloaihang=kh.MaLoaiHang,
                               tenkhohang=kh.TenKhoHang,
                               diachikhohang=kh.DiaChiKhoHang,
                               ngaylap = Convert.ToDateTime(kh.NgayLap == null ? DateTime.Today : kh.NgayLap),
                               nguoilap=kh.NguoiLap,
                               ngaysua = Convert.ToDateTime(kh.NguoiSua == null ? DateTime.Today : kh.NgaySua),
                               nguoisua=kh.NguoiSua,
                           }).ToList<Kho_Hang>();
            return khohang;
        }
        //Thao tác thêm-xóa-sửa
         //Kiểm tra có 1 Nước có trong csdl chưa
        private bool KiemTraKhoHang(string makhohang)
        {
            var khohang = from kh in QLKT.KhoHangs
                       where kh.MaKhoHang==makhohang
                       select kh;
            if (khohang.Count() > 0)
                return true;
            else
                return false;
        }
        public void ThemKhoHang(string makhohang, string tenkhohang, string maloaihang, string diachikh, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraKhoHang(makhohang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                KhoHang KH = new KhoHang();
                KH.MaKhoHang = makhohang;
                KH.TenKhoHang = tenkhohang;
                KH.MaLoaiHang = maloaihang;
                KH.DiaChiKhoHang = diachikh;
                KH.NgayLap = ngaylap;
                KH.NguoiLap = nguoilap;
                KH.NgaySua = ngaysua;
                KH.NguoiSua = nguoisua;
                QLKT.KhoHangs.InsertOnSubmit(KH);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaKhoHang(string makhohang,KhoHang Kho)
        {
            try
            {
                KhoHang KH = QLKT.KhoHangs.Single(kh => kh.MaKhoHang == makhohang);
                KH.TenKhoHang = Kho.TenKhoHang;
                KH.MaLoaiHang = Kho.MaLoaiHang;
                KH.DiaChiKhoHang = Kho.DiaChiKhoHang;
                KH.NgayLap = Kho.NgayLap;
                KH.NguoiLap = Kho.NguoiLap;
                KH.NgaySua = Kho.NgaySua;
                KH.NguoiSua = Kho.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public bool KiemtraKhoChua(string makhohang)
        {
            var khochua = from kc in QLKT.KhoChuas
                          where kc.MaKhoHang == makhohang
                          select kc;
            if (khochua.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaKho(string makho)
        {
            try
            {
                if (KiemtraKhoChua(makho)==true)
                {
                    MessageBox.Show("Bạn không thể xóa Kho Hàng này-Liên quan đến dữ liệu Kho chứa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    var delete = from khohang in QLKT.KhoHangs
                                 where khohang.MaKhoHang == makho
                                 select khohang;
                    if (delete.Count() > 0)
                    {
                        QLKT.KhoHangs.DeleteOnSubmit(delete.First());
                        QLKT.SubmitChanges();
                        MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hàm phục vụ tìm kiếm
        public IQueryable LayMaKhoHang()
        {
            var khohang = from kh in QLKT.KhoHangs
                          select new { kh.MaKhoHang, kh.TenKhoHang, };
            return khohang;
        }
        public List<Kho_Hang> LayKhoHangTheoMaKho(string makho)
        {
            var khohang = (from kh in QLKT.KhoHangs
                           where kh.MaKhoHang==makho
                           select new Kho_Hang
                           {
                               makhohang = kh.MaKhoHang,
                               maloaihang = kh.MaLoaiHang,
                               tenkhohang = kh.TenKhoHang,
                               diachikhohang = kh.DiaChiKhoHang,
                               ngaylap = Convert.ToDateTime(kh.NgayLap == null ? DateTime.Today : kh.NgayLap),
                               nguoilap = kh.NguoiLap,
                               ngaysua = Convert.ToDateTime(kh.NguoiSua == null ? DateTime.Today : kh.NgaySua),
                               nguoisua = kh.NguoiSua,
                           }).ToList<Kho_Hang>();
            return khohang;
        }
        public List<Kho_Hang> LayKhoHangTheoMaLoaiHang(string maloaihang)
        {
            var khohang = (from kh in QLKT.KhoHangs
                           where kh.MaLoaiHang==maloaihang
                           select new Kho_Hang
                           {
                               makhohang = kh.MaKhoHang,
                               maloaihang = kh.MaLoaiHang,
                               tenkhohang = kh.TenKhoHang,
                               diachikhohang = kh.DiaChiKhoHang,
                               ngaylap = Convert.ToDateTime(kh.NgayLap == null ? DateTime.Today : kh.NgayLap),
                               nguoilap = kh.NguoiLap,
                               ngaysua = Convert.ToDateTime(kh.NguoiSua == null ? DateTime.Today : kh.NgaySua),
                               nguoisua = kh.NguoiSua,
                           }).ToList<Kho_Hang>();
            return khohang;
        }
    }
}
