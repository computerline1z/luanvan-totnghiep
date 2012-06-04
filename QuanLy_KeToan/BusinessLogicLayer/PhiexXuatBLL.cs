using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Phieu_Xuat
    {
        public string maloaiphieuxuat { get; set; }
        public string malohdban { get; set; }
        public string mahdban { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class PhieuXuatBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Phieu_Xuat> LayDSPhieuXuat(string malohdban)
        {
            var sql = (from px in QLKT.PhieuXuats
                       where px.MaLoHDBan == malohdban
                       select new Phieu_Xuat
                       {
                           maloaiphieuxuat = px.MaLoaiPhieuXuat,
                           malohdban = px.MaLoHDBan,
                           mahdban = px.MaHDBan,
                           mota = px.MoTa,
                           ngaylap = Convert.ToDateTime(px.NgayLap == null ? DateTime.Today : px.NgayLap),
                           nguoilap = px.NguoiLap,
                           ngaysua = Convert.ToDateTime(px.NgaySua == null ? DateTime.Today : px.NgaySua),
                           nguoisua = px.NguoiSua,

                       }).ToList<Phieu_Xuat>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdban, string mahdban)
        {
            var sql = from px in QLKT.PhieuXuats
                      where px.MaLoHDBan == malohdban && px.MaHDBan == mahdban
                      select px;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public void ThemPhieuXuat(string maloaiphieuxuat, string malohdban,string mahdban, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdban,mahdban) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PhieuXuat PX = new PhieuXuat();
                PX.MaLoaiPhieuXuat = maloaiphieuxuat;
                PX.MaLoHDBan = malohdban;
                PX.MaHDBan = mahdban;
                PX.MoTa = mota;
                PX.NgayLap = ngaylap;
                PX.NguoiLap = nguoilap;
                PX.NgaySua = ngaysua;
                PX.NguoiSua = nguoisua;
                QLKT.PhieuXuats.InsertOnSubmit(PX);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaPX(string malohdban, string mahdban, PhieuXuat PX)
        {
            try
            {
                PhieuXuat px = QLKT.PhieuXuats.Single(_px => _px.MaLoHDBan == malohdban && _px.MaHDBan == mahdban);
                px.MaLoaiPhieuXuat = PX.MaLoaiPhieuXuat;
                px.MoTa = PX.MoTa;
                px.NgayLap = PX.NgayLap;
                px.NguoiLap = PX.NguoiLap;
                px.NgaySua = PX.NgaySua;
                px.NguoiSua = PX.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraMaPhieuXuatChiTietPhieuXuat(string malohdban, string mahdban)
        {
            var sql = from ctpx in QLKT.ChiTietPhieuXuats
                      where ctpx.MaLoHDBan == malohdban && ctpx.MaHDBan == mahdban
                      select ctpx;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaPX(string malohdban, string mahdban)
        {
            if (KiemTraMaPhieuXuatChiTietPhieuXuat(malohdban, mahdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from px in QLKT.PhieuXuats
                             where px.MaLoHDBan == malohdban && px.MaHDBan == mahdban
                             select px;
                if (delete.Count() > 0)
                {
                    QLKT.PhieuXuats.DeleteOnSubmit(delete.First());
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
        public IQueryable LayMaLoaiPhieuXuat()
        {
            var sql = from lpx in QLKT.LoaiPhieuXuats
                      select new
                      {
                          lpx.MaLoaiPhieuXuat,
                          lpx.TenLoaiPhieuXuat,
                      };
            return sql;
        }
        public IQueryable LayLoHDBan()
        {
            var sql = from lohdban in QLKT.LoHDBans
                      select new { lohdban.MaLoHDBan };
            return sql;
        }
        public IQueryable LayMaHDBanTheoLo(string malohdban)
        {
            var sql = from hdban in QLKT.HoaDonBans
                      where hdban.MaLoHDBan == malohdban
                      select new
                      {
                          hdban.MaHDBan,
                      };
            return sql;
        }
        public IQueryable LayMaHDBan()
        {
            var sql = (from hdban in QLKT.HoaDonBans
                      select new
                      {
                          hdban.MaHDBan,
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
