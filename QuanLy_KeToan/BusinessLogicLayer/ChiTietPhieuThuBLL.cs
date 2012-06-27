using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;
namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Chi_Tiet_Phieu_Thu
    {
        public string malohdban { get; set; }
        public string mahdban { get; set; }
        public string mahang { get; set; }
        public decimal tienthu { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class ChiTietPhieuThuBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public IQueryable LayMaHang(string malohdban,string mahdban)
        {
            var sql = from hang in QLKT.Hangs
                      from cthdban in QLKT.ChiTietHDBans
                      where cthdban.ThanhToan==true && cthdban.MaLoHDBan==malohdban && cthdban.MaHDBan==mahdban && cthdban.MaHang==hang.MaHang
                      select new
                      {
                          hang.MaHang,
                          hang.TenHang,
                      };
            return sql;
        }
        public decimal TinhGiaTriTheoChiTietHDBan(string malohdban, string mahdban, string hang)
        {
            decimal thanhtien = 0;
            var sql = from cthdb in QLKT.ChiTietHDBans
                      from h in QLKT.Hangs
                      from hdb in QLKT.HoaDonBans
                      from tgnt in QLKT.TyGiaNgoaiTes
                      where cthdb.MaHang == h.MaHang && cthdb.MaLoHDBan==hdb.MaLoHDBan && cthdb.MaHDBan==hdb.MaHDBan &&
                            hdb.MaTienTe==tgnt.MaTienTe && cthdb.MaLoHDBan == malohdban && cthdb.MaHDBan == mahdban && cthdb.MaHang == hang
                      select (cthdb.SoLuong * h.DonGia * tgnt.TyGia);
            foreach (var item in sql)
            {
                thanhtien = System.Convert.ToDecimal(item.ToString());
            }
            return thanhtien;
        }
        public List<Chi_Tiet_Phieu_Thu> LayChiTietPhieuThu(string malohdban,string mahdban)
        {
            var sql = (from CTPT in QLKT.ChiTietPhieuThus
                       where (CTPT.MaLoHDBan == malohdban && CTPT.MaHDBan==mahdban)
                       select new Chi_Tiet_Phieu_Thu
                       {
                           malohdban = CTPT.MaLoHDBan,
                           mahdban=CTPT.MaHDBan,
                           mahang = CTPT.MaHang,
                           tienthu = System.Convert.ToDecimal(CTPT.TienThu),//TinhGiaTriTheoChiTietHDBan(malohdban,mahdban,CTPT.MaHang),
                           ngaylap = Convert.ToDateTime(CTPT.NgayLap == null ? DateTime.Today : CTPT.NgayLap),
                           nguoilap = CTPT.NguoiLap,
                           ngaysua = Convert.ToDateTime(CTPT.NgaySua == null ? DateTime.Today : CTPT.NgaySua),
                           nguoisua = CTPT.NguoiSua,
                       }).ToList<Chi_Tiet_Phieu_Thu>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdban,string mahdban,string mahang)
        {
            var sql = from CTPT in QLKT.ChiTietPhieuThus
                      where CTPT.MaLoHDBan == malohdban && CTPT.MaHDBan==mahdban && CTPT.MaHang==mahang
                      select CTPT;
            if (sql.Count() > 0)
                return true;
            else return false;
        }

        //Code Thêm-Xóa-Sửa Chi tiết phiếu thu

        public bool ThemCTPT(string malohdban,string mahdban,string mahang,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdban,mahdban,mahang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                ChiTietPhieuThu CTPT = new ChiTietPhieuThu();
                CTPT.MaLoHDBan = malohdban;
                CTPT.MaHDBan = mahdban;
                CTPT.MaHang = mahang;
                CTPT.TienThu = TinhGiaTriTheoChiTietHDBan(malohdban, mahdban, mahang);
                CTPT.NgayLap = ngaylap;
                CTPT.NguoiLap = nguoilap;
                CTPT.NgaySua = ngaysua;
                CTPT.NguoiSua = nguoisua;
                QLKT.ChiTietPhieuThus.InsertOnSubmit(CTPT);
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
        public bool SuaCTPT(string malohdban,string mahdban,string mahang,ChiTietPhieuThu CTPhieuThu)
        {
            try
            {
                ChiTietPhieuThu CTPT = QLKT.ChiTietPhieuThus.Single(_CTPT => _CTPT.MaLoHDBan == malohdban && _CTPT.MaHDBan==mahdban && _CTPT.MaHang==mahang);
                CTPT.TienThu = TinhGiaTriTheoChiTietHDBan(malohdban, mahdban, mahang);
                CTPT.NgayLap = CTPhieuThu.NgayLap;
                CTPT.NguoiLap = CTPhieuThu.NguoiLap;
                CTPT.NgaySua = CTPhieuThu.NgaySua;
                CTPT.NguoiSua = CTPhieuThu.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Cập nhật chi tiết phiếu thu thành công !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool XoaCTPT(string malohdban,string mahdban,string mahang)
        {
            try
            {
                var delete = from CTPT in QLKT.ChiTietPhieuThus
                             where CTPT.MaLoHDBan == malohdban && CTPT.MaHDBan==mahdban && CTPT.MaHang==mahang
                             select CTPT;
                if (delete.Count() > 0)
                {
                    QLKT.ChiTietPhieuThus.DeleteOnSubmit(delete.First());
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
