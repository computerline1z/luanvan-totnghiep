using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;
namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Chi_Tiet_Phieu_Chi
    {
        public string malohdmua { get; set; }
        public string mahdmua { get; set; }
        public string mahang { get; set; }
        public decimal tienchi { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class ChiTietPhieuChiBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public IQueryable LayMaHang(string malohdmua,string mahdmua)
        {
            var sql = from hang in QLKT.Hangs
                      from cthdmua in QLKT.ChiTietHDMuas
                      where cthdmua.ThanhToan==true && cthdmua.MaLoHDMua==malohdmua && cthdmua.MaHDMua==mahdmua && cthdmua.MaHang==hang.MaHang
                      select new
                      {
                          hang.MaHang,
                          hang.TenHang,
                      };
            return sql;
        }
        public decimal TinhGiaTriTheoChiTietHDMua(string malohdmua, string mahdmua, string hang)
        {
            decimal tienchi = 0;
            var sql = from cthdm in QLKT.ChiTietHDMuas
                      from h in QLKT.Hangs
                      from hdm in QLKT.HoaDonMuas
                      from tgnt in QLKT.TyGiaNgoaiTes
                      where cthdm.MaHang == h.MaHang && cthdm.MaLoHDMua==hdm.MaLoHDMua && cthdm.MaHDMua==hdm.MaHDMua &&
                            hdm.MaTienTe==tgnt.MaTienTe && cthdm.MaLoHDMua == malohdmua && cthdm.MaHDMua == mahdmua && cthdm.MaHang == hang
                      select (cthdm.SoLuong * h.DonGia * tgnt.TyGia);
            foreach (var item in sql)
            {
                tienchi = System.Convert.ToDecimal(item.ToString());
            }
            return tienchi;
        }
        public List<Chi_Tiet_Phieu_Chi> LayChiTietPhieuChi(string malohdmua,string mahdmua)
        {
            var sql = (from CTPC in QLKT.ChiTietPhieuChis
                       where (CTPC.MaLoHDMua == malohdmua && CTPC.MaHDMua==mahdmua)
                       select new Chi_Tiet_Phieu_Chi
                       {
                           malohdmua = CTPC.MaLoHDMua,
                           mahdmua=CTPC.MaHDMua,
                           mahang = CTPC.MaHang,
                           tienchi = System.Convert.ToDecimal(CTPC.TienChi),//TinhGiaTriTheoChiTietHDMua(malohdmua,mahdmua,CTPC.MaHang),
                           ngaylap = Convert.ToDateTime(CTPC.NgayLap == null ? DateTime.Today : CTPC.NgayLap),
                           nguoilap = CTPC.NguoiLap,
                           ngaysua = Convert.ToDateTime(CTPC.NgaySua == null ? DateTime.Today : CTPC.NgaySua),
                           nguoisua = CTPC.NguoiSua,
                       }).ToList<Chi_Tiet_Phieu_Chi>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdmua,string mahdmua,string mahang)
        {
            var sql = from CTPC in QLKT.ChiTietPhieuChis
                      where CTPC.MaLoHDMua == malohdmua && CTPC.MaHDMua==mahdmua && CTPC.MaHang==mahang
                      select CTPC;
            if (sql.Count() > 0)
                return true;
            else return false;
        }

        //Code Thêm-Xóa-Sửa Chi tiết phiếu Chi

        public bool ThemCTPC(string malohdmua,string mahdmua,string mahang,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdmua,mahdmua,mahang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                ChiTietPhieuChi CTPC = new ChiTietPhieuChi();
                CTPC.MaLoHDMua = malohdmua;
                CTPC.MaHDMua = mahdmua;
                CTPC.MaHang = mahang;
                CTPC.TienChi = TinhGiaTriTheoChiTietHDMua(malohdmua, mahdmua, mahang);
                CTPC.NgayLap = ngaylap;
                CTPC.NguoiLap = nguoilap;
                CTPC.NgaySua = ngaysua;
                CTPC.NguoiSua = nguoisua;
                QLKT.ChiTietPhieuChis.InsertOnSubmit(CTPC);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SuaCTPC(string malohdmua,string mahdmua,string mahang,ChiTietPhieuChi CTPhieuChi)
        {
            try
            {
                ChiTietPhieuChi CTPC = QLKT.ChiTietPhieuChis.Single(_CTPC => _CTPC.MaLoHDMua == malohdmua && _CTPC.MaHDMua==mahdmua && _CTPC.MaHang==mahang);
                CTPC.TienChi = TinhGiaTriTheoChiTietHDMua(malohdmua, mahdmua, mahang);
                CTPC.NgayLap = CTPhieuChi.NgayLap;
                CTPC.NguoiLap = CTPhieuChi.NguoiLap;
                CTPC.NgaySua = CTPhieuChi.NgaySua;
                CTPC.NguoiSua = CTPhieuChi.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool XoaCTPC(string malohdmua,string mahdmua,string mahang)
        {
            try
            {
                var delete = from CTPC in QLKT.ChiTietPhieuChis
                             where CTPC.MaLoHDMua == malohdmua && CTPC.MaHDMua==mahdmua && CTPC.MaHang==mahang
                             select CTPC;
                if (delete.Count() > 0)
                {
                    QLKT.ChiTietPhieuChis.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public IQueryable LayNguoiLap()
        {
            var sql = from phanquyen in QLKT.PhanQuyens
                      select new { phanquyen.TenDangNhap };
            return sql;
        }
    }
}
