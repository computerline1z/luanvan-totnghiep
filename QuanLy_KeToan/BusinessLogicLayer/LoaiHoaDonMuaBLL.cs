using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;


namespace QuanLy_KeToan.BusinessLogicLayer
{
    class LoaiHoaDonMua
    {
        public string MaLoaiHDMua { get; set; }
        public string TenLoaiHDMua { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class LoaiHoaDonMuaBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lay Danh Sach Loai Hoa Don Mua
        public List<LoaiHoaDonMua> LayDanhSachLoaiHoaDonMua()
        {
            var loaihoadonmua = (from loaihdmua in QLKT.LoaiHDMuas
                                 select new LoaiHoaDonMua
                                 {
                                     MaLoaiHDMua = loaihdmua.MaLoaiHDMua,
                                     TenLoaiHDMua = loaihdmua.TenLoaiHDMua,
                                     NgayLap = Convert.ToDateTime(loaihdmua.NgayLap == null ? DateTime.Today : loaihdmua.NgayLap),
                                     NguoiLap = loaihdmua.NguoiLap,
                                     NgaySua = Convert.ToDateTime(loaihdmua.NgaySua == null ? DateTime.Today : loaihdmua.NgaySua),
                                     NguoiSua = loaihdmua.NguoiSua,
                                 }).ToList<LoaiHoaDonMua>();
            return loaihoadonmua;
        }
        //Lay Danh Sach Mã Loại Hóa Đơn Mua
        public IQueryable LayDanhSachMaLoaiHoaDonMua()
        {
            var maloaihdmua = from hoadonmua in QLKT.LoaiHDMuas
                              select new { hoadonmua.MaLoaiHDMua, };
            return maloaihdmua.Distinct();
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
        //Kiểm tra 1 loai hóa đơn mua có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraLoaiHoaDonMua(string maloaihoadonmua)
        {
            var loaihoadonmua = from loaihdmua in QLKT.LoaiHDMuas
                                where loaihdmua.MaLoaiHDMua == maloaihoadonmua
                                select loaihdmua;
            if (loaihoadonmua.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm loại hóa đơn mua
        public void ThemLoaiHDMua(string Maloaihoadonmua, string tenloaihoadonmua, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemtraLoaiHoaDonMua(Maloaihoadonmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoaiHDMua LoaiHDMua = new QuanLy_KeToan.DataAccessLayer.LoaiHDMua();
                LoaiHDMua.MaLoaiHDMua = Maloaihoadonmua;
                LoaiHDMua.TenLoaiHDMua = tenloaihoadonmua;
                LoaiHDMua.NgayLap = ngaylap;
                LoaiHDMua.NguoiLap = nguoilap;
                LoaiHDMua.NgaySua = ngaysua;
                LoaiHDMua.NguoiSua = nguoisua;

                QLKT.LoaiHDMuas.InsertOnSubmit(LoaiHDMua);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 loại hóa đơn mua
        public void SuaLoaiHDMua(string maloaihdmua, QuanLy_KeToan.DataAccessLayer.LoaiHDMua LoaiHDMua)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoaiHDMua loaihdmua = QLKT.LoaiHDMuas.Single(loaihoadonmua => loaihoadonmua.MaLoaiHDMua == maloaihdmua);
                loaihdmua.TenLoaiHDMua = LoaiHDMua.TenLoaiHDMua;
                loaihdmua.NgayLap = LoaiHDMua.NgayLap;
                loaihdmua.NguoiLap = LoaiHDMua.NguoiLap;
                loaihdmua.NgaySua = LoaiHDMua.NgaySua;
                loaihdmua.NguoiSua = LoaiHDMua.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraHoaDonMua(string maloaihdmua)
        {
            var sql = from hdm in QLKT.HoaDonMuas
                      where hdm.MaLoaiHDMua == maloaihdmua
                      select hdm;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Xóa loại hóa đơn mua
        public void XoaLoaiHDMua(string maloaihdmua)
        {
            if (KiemTraHoaDonMua(maloaihdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Hóa đơn mua", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from loaihdmua in QLKT.LoaiHDMuas
                             where loaihdmua.MaLoaiHDMua == maloaihdmua
                             select loaihdmua;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiHDMuas.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Tìm Kiếm Loai Hoa Don Mua Theo Mã Loai Hoa Don Mua cho Combobox 
        public List<LoaiHoaDonMua> TimTatCaLoaiHoaDonMuaChinhXacTheoMaLoaiHoaDonMua(string maloaihoadonmua)
        {
            var loaihoadonmua = (from loaihdmua in QLKT.LoaiHDMuas
                                 where loaihdmua.MaLoaiHDMua == maloaihoadonmua
                                 select new LoaiHoaDonMua
                                 {
                                     MaLoaiHDMua = loaihdmua.MaLoaiHDMua,
                                     TenLoaiHDMua = loaihdmua.TenLoaiHDMua,

                                 }).ToList<LoaiHoaDonMua>();
            return loaihoadonmua;
        }
        //Tìm gần đúng
        public List<LoaiHoaDonMua> TimTatCaLoaiHoaDonTheoTenLoaiHoaDon(string tenloaihoadonmua)
        {
            var loaihoadonmua = (from loaihdmua in QLKT.LoaiHDMuas  
                                 where loaihdmua.TenLoaiHDMua.Contains(tenloaihoadonmua)
                                 select new LoaiHoaDonMua
                                 {
                                     MaLoaiHDMua = loaihdmua.MaLoaiHDMua,
                                     TenLoaiHDMua = loaihdmua.TenLoaiHDMua,

                                 }).ToList<LoaiHoaDonMua>();
            return loaihoadonmua;
        }
    }
}
