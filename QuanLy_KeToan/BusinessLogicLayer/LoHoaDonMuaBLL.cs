using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class LoHoaDonMua
    {
        public string MaLoHDMua { get; set; }
        public string MaLoaiHang { get; set; }
        public DateTime NgayLoHDMua { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class LoHoaDonMuaBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy Danh Sách Lô Hóa Đơn Mua
        public List<LoHoaDonMua> LayDanhSachLoHoaDonMua()
        {
            var lohoadonmua = (from lohdmua in QLKT.LoHDMuas
                               select new LoHoaDonMua
                               {
                                   MaLoHDMua = lohdmua.MaLoHDMua,
                                   MaLoaiHang = lohdmua.MaLoaiHang,
                                   NgayLoHDMua = Convert.ToDateTime(lohdmua.NgayLoHDMua == null ? DateTime.Today : lohdmua.NgayLoHDMua),
                                   MoTa = lohdmua.MoTa,
                                   NgayLap = Convert.ToDateTime(lohdmua.NgayLap == null ? DateTime.Today : lohdmua.NgayLap),
                                   NguoiLap = lohdmua.NguoiLap,
                                   NgaySua = Convert.ToDateTime(lohdmua.NgaySua == null ? DateTime.Today : lohdmua.NgaySua),
                                   NguoiSua = lohdmua.NguoiSua,
                               }).ToList<LoHoaDonMua>();
            return lohoadonmua;
        }
        //Lấy Danh Sách Mã Lô Hóa Đơn Mua
        public IQueryable LayDanhSachMaLoHoaDonMua()
        {
            var malohdmua = from lohdmua in QLKT.LoHDMuas
                            select new { lohdmua.MaLoHDMua,lohdmua.NgayLoHDMua,lohdmua.MoTa,};
            return malohdmua.Distinct();
        }
        //Lấy Danh Sách Mã Loại Hàng
        public IQueryable LayDanhSachMaLoaiHang()
        {
            var maloaihang = from loaihang in QLKT.LoaiHangs
                             select new { loaihang.MaLoaiHang,loaihang.TenLoaiHang };
            return maloaihang;
        }
        //Lấy Danh Sách Người Lập cho ColNguoiLap
        public IQueryable LayDanhSachNguoiLap()
        {
            var nguoilap = from phanquyen in QLKT.PhanQuyens
                           select new { phanquyen.TenDangNhap };
            return nguoilap.Distinct();
        }
        //Lấy Danh Sách Người Sửa cho ColNguoiSua
        public IQueryable LayDanhSachNguoiSua()
        {
            var nguoisua = from phanquyen in QLKT.PhanQuyens
                           select new { phanquyen.TenDangNhap };
            return nguoisua.Distinct();
        }
        //Kiểm tra 1 lô hóa đơn mua có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraLoHoaDonMua(string malohoadonmua)
        {
            var lohoadonmua = from lohdmua in QLKT.LoHDMuas
                              where lohdmua.MaLoHDMua == malohoadonmua
                              select lohdmua;
            if (lohoadonmua.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm lô hóa đơn mua
        public void ThemLoHDMua(string Malohoadonmua,string maloaihang, DateTime ngaylohoadonmua, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemtraLoHoaDonMua(Malohoadonmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoHDMua LoHDMua = new QuanLy_KeToan.DataAccessLayer.LoHDMua();
                LoHDMua.MaLoHDMua = Malohoadonmua;
                LoHDMua.MaLoaiHang = maloaihang;
                LoHDMua.NgayLoHDMua = ngaylohoadonmua;
                LoHDMua.MoTa = mota;
                LoHDMua.NgayLap = ngaylap;
                LoHDMua.NguoiLap = nguoilap;
                LoHDMua.NgaySua = ngaysua;
                LoHDMua.NguoiSua = nguoisua;

                QLKT.LoHDMuas.InsertOnSubmit(LoHDMua);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 lô hóa đơn mua
        public void SuaLoHDMua(string malohdmua, QuanLy_KeToan.DataAccessLayer.LoHDMua LoHDMua)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoHDMua lohdmua = QLKT.LoHDMuas.Single(lohoadonmua => lohoadonmua.MaLoHDMua == malohdmua);
                lohdmua.MaLoaiHang = LoHDMua.MaLoaiHang;
                lohdmua.NgayLoHDMua = LoHDMua.NgayLoHDMua;
                lohdmua.MoTa = LoHDMua.MoTa;
                lohdmua.NgayLap = LoHDMua.NgayLap;
                lohdmua.NguoiLap = LoHDMua.NguoiLap;
                lohdmua.NgaySua = LoHDMua.NgaySua;
                lohdmua.NguoiSua = LoHDMua.NguoiSua;

                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraLoNhap(string malohdmua)
        {
            var sql = from lpn in QLKT.LoPhieuNhaps
                      where lpn.MaLoHDMua == malohdmua
                      select lpn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraLoPhieuChi(string malohdmua)
        {
            var sql2=from lpc in QLKT.LoPhieuChis
                     where lpc.MaLoHDMua==malohdmua
                     select lpc;
            if (sql2.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraHoaDonMua(string malohdmua)
        {
            var sql3 = from hdm in QLKT.HoaDonMuas
                       where hdm.MaLoHDMua == malohdmua
                       select hdm;
            if (sql3.Count() > 0)
                return true;
            else
                return false;
        }
        //Xóa lô hóa đơn mua
        public void XoaLoHDMua(string malohdmua)
        {
            if (KiemTraLoNhap(malohdmua) == true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này-Liên quan đến CSDL Lô Phiếu Nhập","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraLoPhieuChi(malohdmua) == true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này-Liên quan đến CSDL Lô Phiếu Chi","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraHoaDonMua(malohdmua) == true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này-Liên quan đến CSDL Hóa Đơn Mua","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lohdmua in QLKT.LoHDMuas
                             where lohdmua.MaLoHDMua == malohdmua
                             select lohdmua;
                if (delete.Count() > 0)
                {
                    QLKT.LoHDMuas.DeleteOnSubmit(delete.First());
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
