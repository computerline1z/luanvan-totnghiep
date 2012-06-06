using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Phieu_Nhap
    {
        public string maloaiphieunhap { get; set; }
        public string malohdmua { get; set; }
        public string mahdmua { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class PhieuNhapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Phieu_Nhap> LayDSPhieuNhap(string malohdmua)
        {
            var sql = (from pn in QLKT.PhieuNhaps
                      where pn.MaLoHDMua == malohdmua
                      select  new  Phieu_Nhap
                      {
                         maloaiphieunhap=pn.MaLoaiPhieuNhap,
                         malohdmua=pn.MaLoHDMua,
                         mahdmua=pn.MaHDMua,
                         mota=pn.MoTa,
                         ngaylap = Convert.ToDateTime(pn.NgayLap == null ? DateTime.Today : pn.NgayLap),
                         nguoilap = pn.NguoiLap,
                         ngaysua = Convert.ToDateTime(pn.NgaySua == null ? DateTime.Today : pn.NgaySua),
                         nguoisua=pn.NguoiSua,

                      }).ToList<Phieu_Nhap>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdmua,string mahdmua)
        {
            var sql = from pn in QLKT.PhieuNhaps
                      where pn.MaLoHDMua == malohdmua && pn.MaHDMua==mahdmua
                      select pn;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public void ThemPhieuNhap(string maloaiphieunhap, string malohdmua, string mahdmua, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdmua, mahdmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PhieuNhap PN = new PhieuNhap();
                PN.MaLoaiPhieuNhap = maloaiphieunhap;
                PN.MaLoHDMua = malohdmua;
                PN.MaHDMua = mahdmua;
                PN.MoTa = mota;
                PN.NgayLap = ngaylap;
                PN.NguoiLap = nguoilap;
                PN.NgaySua = ngaysua;
                PN.NguoiSua = nguoisua;
                QLKT.PhieuNhaps.InsertOnSubmit(PN);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaPN(string malohdmua,string mahdmua,PhieuNhap PN)
        {
            try
            {
                PhieuNhap pn = QLKT.PhieuNhaps.Single(_pn => _pn.MaLoHDMua == malohdmua && _pn.MaHDMua==mahdmua);
                pn.MaLoaiPhieuNhap = PN.MaLoaiPhieuNhap;
                pn.MoTa = PN.MoTa;
                pn.NgayLap = PN.NgayLap;
                pn.NguoiLap = PN.NguoiLap;
                pn.NgaySua = PN.NgaySua;
                pn.NguoiSua = PN.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraMaPhieuNhapChiTietPhieuNhap(string malohdmua,string mahdmua)
        {
            var sql = from ctpn in QLKT.ChiTietPhieuNhaps
                      where ctpn.MaLoHDMua == malohdmua && ctpn.MaHDMua==mahdmua
                      select ctpn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaPN(string malohdmua,string mahdmua)
        {
            if (KiemTraMaPhieuNhapChiTietPhieuNhap(malohdmua,mahdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from pn in QLKT.PhieuNhaps
                             where pn.MaLoHDMua == malohdmua && pn.MaHDMua==mahdmua
                             select pn;
                if (delete.Count() > 0)
                {
                    QLKT.PhieuNhaps.DeleteOnSubmit(delete.First());
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
        public IQueryable LayMaLoaiPhieuNhap()
        {
            var sql = from lpn in QLKT.LoaiPhieuNhaps
                      select new
                      {
                          lpn.MaLoaiPhieuNhap,
                          lpn.TenLoaiPhieuNhap,
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
