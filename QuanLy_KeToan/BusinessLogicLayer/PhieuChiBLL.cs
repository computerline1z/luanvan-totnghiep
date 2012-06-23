using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Phieu_Chi
    {
        public string maloaiphieuchi { get; set; }
        public string malohdmua { get; set; }
        public string mahdmua { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class PhieuChiBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Phieu_Chi> LayDSPhieuChi(string malohdmua)
        {
            var sql = (from pc in QLKT.PhieuChis
                       where pc.MaLoHDMua == malohdmua
                       select new Phieu_Chi
                       {
                           maloaiphieuchi = pc.MaLoaiPhieuChi,
                           malohdmua = pc.MaLoHDMua,
                           mahdmua = pc.MaHDMua,
                           mota = pc.MoTa,
                           ngaylap = Convert.ToDateTime(pc.NgayLap == null ? DateTime.Today : pc.NgayLap),
                           nguoilap = pc.NguoiLap,
                           ngaysua = Convert.ToDateTime(pc.NgaySua == null ? DateTime.Today : pc.NgaySua),
                           nguoisua = pc.NguoiSua,

                       }).ToList<Phieu_Chi>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdmua, string mahdmua)
        {
            var sql = from pc in QLKT.PhieuChis
                      where pc.MaLoHDMua == malohdmua && pc.MaHDMua == mahdmua
                      select pc;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public void ThemPhieuChi(string maloaiphieuchi, string malohdmua,string mahdmua, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdmua,mahdmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PhieuChi PX = new PhieuChi();
                PX.MaLoaiPhieuChi = maloaiphieuchi;
                PX.MaLoHDMua = malohdmua;
                PX.MaHDMua = mahdmua;
                PX.MoTa = mota;
                PX.NgayLap = ngaylap;
                PX.NguoiLap = nguoilap;
                PX.NgaySua = ngaysua;
                PX.NguoiSua = nguoisua;
                QLKT.PhieuChis.InsertOnSubmit(PX);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaPC(string malohdmua, string mahdmua, PhieuChi PX)
        {
            try
            {
                PhieuChi pc = QLKT.PhieuChis.Single(_pc => _pc.MaLoHDMua == malohdmua && _pc.MaHDMua == mahdmua);
                pc.MaLoaiPhieuChi = PX.MaLoaiPhieuChi;
                pc.MoTa = PX.MoTa;
                pc.NgayLap = PX.NgayLap;
                pc.NguoiLap = PX.NguoiLap;
                pc.NgaySua = PX.NgaySua;
                pc.NguoiSua = PX.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraMaPhieuChiChiTietPhieuChi(string malohdmua, string mahdmua)
        {
            var sql = from ctpc in QLKT.ChiTietPhieuChis
                      where ctpc.MaLoHDMua == malohdmua && ctpc.MaHDMua == mahdmua
                      select ctpc;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaPC(string malohdmua, string mahdmua)
        {
            if (KiemTraMaPhieuChiChiTietPhieuChi(malohdmua, mahdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from pc in QLKT.PhieuChis
                             where pc.MaLoHDMua == malohdmua && pc.MaHDMua == mahdmua
                             select pc;
                if (delete.Count() > 0)
                {
                    QLKT.PhieuChis.DeleteOnSubmit(delete.First());
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
        public IQueryable LayMaLoaiPhieuChi()
        {
            var sql = from lpc in QLKT.LoaiPhieuChis
                      select new
                      {
                          lpc.MaLoaiPhieuChi,
                          lpc.TenLoaiPhieuChi,
                      };
            return sql;
        }
        public IQueryable LayLoHDMua()
        {
            var sql = from lohdmua in QLKT.LoHDMuas
                      select new { lohdmua.MaLoHDMua };
            return sql;
        }
        public IQueryable LayMaHDMuaTheoLo(string malohdmua)
        {
            var sql = from hdmua in QLKT.HoaDonMuas
                      where hdmua.MaLoHDMua == malohdmua
                      select new
                      {
                          hdmua.MaHDMua,
                      };
            return sql;
        }
        public IQueryable LayMaHDMua()
        {
            var sql = (from hdmua in QLKT.HoaDonMuas
                      select new
                      {
                          hdmua.MaHDMua,
                      }).Distinct();
            return sql;
        }
        public IQueryable LayNguoiLap()
        {
            var sql = from phanquyen in QLKT.PhanQuyens
                      select new { phanquyen.TenDangNhap };
            return sql;
        }
    }
}
