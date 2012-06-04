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
        public string maphieunhap { get; set; }
        public string maloaiphieunhap { get; set; }
        public string malonhap { get; set; }
        public string mancc { get; set; }
        public DateTime ngayphieunhap { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class PhieuNhapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        ////Lấy dữ liệu cho TreeView
        public IQueryable LayMaPhieuNhap(string malonhap)
        {
            var sql = from pn in QLKT.PhieuNhaps
                      where pn.MaLoNhap == malonhap
                      select pn.MaPhieuNhap;
            return sql;
        }
        public List<Phieu_Nhap> LayDSPhieuNhap(string malonhap)
        {
            var sql = (from pn in QLKT.PhieuNhaps
                      where pn.MaLoNhap == malonhap
                      select  new  Phieu_Nhap
                      {
                         maphieunhap=pn.MaPhieuNhap,
                         maloaiphieunhap=pn.MaLoaiPhieuNhap,
                         malonhap=pn.MaLoNhap,
                         mancc=pn.MaNCC,
                         ngayphieunhap = Convert.ToDateTime(pn.NgayPhieuNhap == null ? DateTime.Today : pn.NgayPhieuNhap),
                         mota=pn.MoTa,
                         ngaylap = Convert.ToDateTime(pn.NgayLap == null ? DateTime.Today : pn.NgayLap),
                         nguoilap = pn.NguoiLap,
                         ngaysua = Convert.ToDateTime(pn.NgaySua == null ? DateTime.Today : pn.NgaySua),
                         nguoisua=pn.NguoiSua,

                      }).ToList<Phieu_Nhap>();
            return sql;
        }
        private bool KiemTraDulieu(string maphieunhap,string malonhap)
        {
            var sql = from pn in QLKT.PhieuNhaps
                      where pn.MaPhieuNhap == maphieunhap && pn.MaLoNhap==malonhap
                      select pn;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public void ThemPhieuNhap(string maphieunhap, string maloaiphieunhap, string malonhap, string mancc, DateTime ngayphieunhap, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(maphieunhap,malonhap) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PhieuNhap PN = new PhieuNhap();
                PN.MaPhieuNhap = maphieunhap;
                PN.MaLoaiPhieuNhap = maloaiphieunhap;
                PN.MaLoNhap = malonhap;
                PN.MaNCC = mancc;
                PN.NgayPhieuNhap = ngayphieunhap;
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
        public void SuaPN(string maphieunhap,string malonhap,PhieuNhap PN)
        {
            try
            {
                PhieuNhap pn = QLKT.PhieuNhaps.Single(_pn => _pn.MaPhieuNhap == maphieunhap && _pn.MaLoNhap==malonhap);
                pn.MaLoaiPhieuNhap = PN.MaLoaiPhieuNhap;
                pn.MaNCC = PN.MaNCC;
                pn.NgayPhieuNhap = PN.NgayPhieuNhap;
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
        private bool KiemTraMaPhieuNhapChiTietPhieuNhap(string maphieunhap,string malonhap)
        {
            var sql = from ctpn in QLKT.ChiTietPhieuNhaps
                      where ctpn.MaPhieuNhap == maphieunhap && ctpn.MaLoNhap==malonhap
                      select ctpn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaPN(string maphieunhap,string malonhap)
        {
            if (KiemTraMaPhieuNhapChiTietPhieuNhap(maphieunhap,malonhap) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from pn in QLKT.PhieuNhaps
                             where pn.MaPhieuNhap == maphieunhap && pn.MaLoNhap==malonhap
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
        //public IQueryable LayMaLoNhap()
        //{
        //    var sql = from ln in QLKT.LoPhieuNhaps
        //              select new
        //              {
        //                  ln.MaLoNhap,
        //              };
        //    return sql;
        //}
        //public IQueryable LayMaNCC( string malonhap)
        //{
        //    var sql = from ncc in QLKT.NhaCungCaps
        //              from lpn in QLKT.LoPhieuNhaps
        //              from pn in QLKT.PhieuNhaps
        //              where lpn.MaLoaiHang==ncc.MaLoaiHang && pn.MaLoNhap==lpn.MaLoNhap && pn.MaLoNhap==malonhap
        //              select new
        //              {
        //                  ncc.MaNCC,
        //                  ncc.TenNCC,
        //              };
        //    return sql;
        //}
        public IQueryable LayMaNCC()
        {
            var sql = (from ncc in QLKT.NhaCungCaps
                      select new
                      {
                          ncc.MaNCC,
                          ncc.TenNCC,
                      }).Distinct();
            return sql;
        }
    }
}
