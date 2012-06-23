using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Hoa_Don_Ban //chú mày chú  ý giúp a,nên đặt tên chỗ này khác với tên mặc định của nó Hoa_Hon_Ban
    {
        public string MaHDBan { get; set; }
        public string MaLoaiHDBan { get; set; }
        public string MaLoHDBan { get; set; }
        public string MaKhachHang { get; set; }
        public string MaTienTe { get; set; }
        public string Mota { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }

    }
    class HoaDonBanBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        //Lay Danh Sach Hoa Don Ban
        public List<Hoa_Don_Ban> LayDanhSachHoaDonBan()
        {
            var hoadonban = (from hdban in QLKT.HoaDonBans
                             select new Hoa_Don_Ban
                             {
                                 MaHDBan = hdban.MaHDBan,
                                 MaLoaiHDBan = hdban.MaLoaiHDBan,
                                 MaLoHDBan = hdban.MaLoHDBan,
                                 MaKhachHang = hdban.MaKhachHang,
                                 MaTienTe = hdban.MaTienTe,
                                 Mota = hdban.MoTa,
                                 NgayLap = Convert.ToDateTime(hdban.NgayLap == null ? DateTime.Today : hdban.NgayLap),
                                 NguoiLap = hdban.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdban.NgaySua == null ? DateTime.Today : hdban.NgaySua),
                                 NguoiSua = hdban.NguoiSua,
                             }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
        //Lay Danh Sach Hoa Don Bán Theo MaKhachHang
        public List<Hoa_Don_Ban> LayDanhSachHoaDonTheoMaKhachHang(string makhachhang)
        {
            var hoadonban = (from hdban in QLKT.HoaDonBans
                             where (hdban.MaKhachHang == makhachhang)
                             select new Hoa_Don_Ban
                             {
                                 MaHDBan = hdban.MaHDBan,
                                 MaLoaiHDBan = hdban.MaLoaiHDBan,
                                 MaLoHDBan = hdban.MaLoHDBan,
                                 MaKhachHang = hdban.MaKhachHang,
                                 MaTienTe = hdban.MaTienTe,
                                 Mota = hdban.MoTa,
                                 NgayLap = Convert.ToDateTime(hdban.NgayLap == null ? DateTime.Today : hdban.NgayLap),
                                 NguoiLap = hdban.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdban.NgaySua == null ? DateTime.Today : hdban.NgaySua),
                                 NguoiSua = hdban.NguoiSua,
                             }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
        //Lay danh sách mã hóa đơn theo lô
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
        //Lay Danh Sach Hoa Don Bán Theo MaLoHDBan
        public List<Hoa_Don_Ban> LayDanhSachHoaDonTheoMaLoHoaDonBan(string malohoadonban)
        {
            var hoadonban = (from hdban in QLKT.HoaDonBans
                             where (hdban.MaLoHDBan == malohoadonban)
                             select new Hoa_Don_Ban
                             {
                                 MaHDBan = hdban.MaHDBan,
                                 MaLoaiHDBan = hdban.MaLoaiHDBan,
                                 MaLoHDBan = hdban.MaLoHDBan,
                                 MaKhachHang = hdban.MaKhachHang,
                                 MaTienTe = hdban.MaTienTe,
                                 Mota = hdban.MoTa,
                                 NgayLap = Convert.ToDateTime(hdban.NgayLap == null ? DateTime.Today : hdban.NgayLap),
                                 NguoiLap = hdban.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdban.NgaySua == null ? DateTime.Today : hdban.NgaySua),
                                 NguoiSua = hdban.NguoiSua,
                             }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
        //Lấy Danh Sách Mã Loại Hóa Đơn Bán cho ColMaLoaiHDBan
        public IQueryable LayDanhSachMaLoaiHoaDonBan()
        {
            var maloaihdban = from loaihdban in QLKT.LoaiHDBans
                              select new { loaihdban.MaLoaiHDBan };
            return maloaihdban.Distinct();
        }
        //Lấy Danh Sách Mã Lô Hóa Đơn Bán Cho ColMaLoHDBan
        public IQueryable LayDanhSachMaLoHoaDonBan()
        {
            var malohdban = from lohdban in QLKT.LoHDBans
                            select new { lohdban.MaLoHDBan };
            return malohdban.Distinct();
        }
        //Lấy Danh Sách Mã Khách Hàng cho ColMaKhachHang
        public IQueryable LayDanhSachMaKhachHang()
        {
            var makhachhang = from kh in QLKT.KhachHangs
                              select new { kh.MaKhachHang, kh.TenKhachHang };
            return makhachhang.Distinct();
        }
        //Lấy Danh Sách Mã Tiền Tệ cho ColMaTienTe
        public IQueryable LayDanhSachMaTienTe()
        {
            var matiente = from tiente in QLKT.TyGiaNgoaiTes
                           select new { tiente.MaTienTe };
            return matiente.Distinct();
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
        //Kiểm tra 1 hóa đơn bán có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraHoaDonBan(string malohoadonban, string mahoadonban)
        {
            var hoadonban = from hdban in QLKT.HoaDonBans
                            where hdban.MaLoHDBan == malohoadonban && hdban.MaHDBan == mahoadonban
                            select hdban;
            if (hoadonban.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm hóa đơn bán
        public void ThemHDBan(string Mahoadonban, string Maloaihoadonban, string Malohoadonban, string Makhachhang, string matiente,string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua )
        {
            if (KiemtraHoaDonBan(Malohoadonban , Mahoadonban) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.HoaDonBan HDBan = new QuanLy_KeToan.DataAccessLayer.HoaDonBan();
                HDBan.MaHDBan = Mahoadonban;
                HDBan.MaLoaiHDBan = Maloaihoadonban;
                HDBan.MaLoHDBan = Malohoadonban;
                HDBan.MaKhachHang = Makhachhang;
                HDBan.MaTienTe = matiente;
                HDBan.MoTa = mota;
                HDBan.NgayLap = ngaylap;
                HDBan.NguoiLap = nguoilap;
                HDBan.NgaySua = ngaysua;
                HDBan.NguoiSua = nguoisua;
                QLKT.HoaDonBans.InsertOnSubmit(HDBan);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 hóa đơn bán
        public void SuaHDBan(string malohdban, string mahdban, QuanLy_KeToan.DataAccessLayer.HoaDonBan HDBan)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.HoaDonBan hdban = QLKT.HoaDonBans.Single(hoadonban => hoadonban.MaLoHDBan == malohdban && hoadonban.MaHDBan == mahdban);
                hdban.MaLoaiHDBan = HDBan.MaLoaiHDBan;
                hdban.MaKhachHang = HDBan.MaKhachHang;
                hdban.MaTienTe = HDBan.MaTienTe;
                hdban.MoTa = HDBan.MoTa;
                hdban.NgayLap = HDBan.NgayLap;
                hdban.NguoiLap = HDBan.NguoiLap;
                hdban.NgaySua = HDBan.NgaySua;
                hdban.NguoiSua = HDBan.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraMaHoaDonBanChiTietHoaDonBan(string malohdban, string mahdban)
        {
            var sql = from cthdban in QLKT.ChiTietHDBans
                      where cthdban.MaLoHDBan == malohdban && cthdban.MaHDBan == mahdban
                      select cthdban;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraPhieuXuat(string malohdban, string mahdban)
        {
            var sql = from phieuxuat in QLKT.PhieuXuats
                      where phieuxuat.MaLoHDBan == malohdban && phieuxuat.MaHDBan == mahdban
                      select phieuxuat;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraPhieuThu(string malohdban, string mahdban)
        {
            var sql = from phieuthu in QLKT.PhieuThus
                      where phieuthu.MaLoHDBan == malohdban && phieuthu.MaHDBan == mahdban
                      select phieuthu;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Xóa hóa đơn bán
        public void XoaHDBan(string malohdban, string mahdban)
        {
            if (KiemTraMaHoaDonBanChiTietHoaDonBan(malohdban, mahdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraPhieuXuat(malohdban, mahdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraPhieuThu(malohdban, mahdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Thu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from hdban in QLKT.HoaDonBans
                             where hdban.MaLoHDBan == malohdban && hdban.MaHDBan == mahdban
                             select hdban;
                if (delete.Count() > 0)
                {
                    QLKT.HoaDonBans.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Tìm Kiếm Hoa Don Ban Theo Mã Khách Hàng cho comboboxMaKhachHang
        public List<Hoa_Don_Ban> TimTatCaHoaDonBanTheoMaKhachHang(string makhachhang)
        {
            var hoadonban = (from hdban in QLKT.HoaDonBans
                             where hdban.MaKhachHang == makhachhang
                             select new Hoa_Don_Ban
                             {
                                 MaHDBan = hdban.MaHDBan,
                                 MaLoaiHDBan = hdban.MaLoaiHDBan,
                                 MaLoHDBan = hdban.MaLoHDBan,
                                 MaKhachHang = hdban.MaKhachHang,
                                 MaTienTe = hdban.MaTienTe,
                                 Mota = hdban.MoTa,
                                 NgayLap = Convert.ToDateTime(hdban.NgayLap == null ? DateTime.Today : hdban.NgayLap),
                                 NguoiLap = hdban.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdban.NgaySua == null ? DateTime.Today : hdban.NgaySua),
                                 NguoiSua = hdban.NguoiSua,
                                 
                             }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
        //Tìm Kiếm Hoa Don Ban Theo Mã Hoa Don Ban cho TextBox_TimKiem 
        public List<Hoa_Don_Ban> TimTatCaHoaDonBanChinhXacTheoMaHoaDonBan(string mahoadonban)
        {
            var hoadonban = (from hdban in QLKT.HoaDonBans
                             where hdban.MaHDBan == mahoadonban
                             select new Hoa_Don_Ban
                             {
                                 MaHDBan = hdban.MaHDBan,
                                 MaLoaiHDBan = hdban.MaLoaiHDBan,
                                 MaLoHDBan = hdban.MaLoHDBan,
                                 MaKhachHang = hdban.MaKhachHang,
                                 MaTienTe = hdban.MaTienTe,
                                 Mota = hdban.MoTa,
                                 NgayLap = Convert.ToDateTime(hdban.NgayLap == null ? DateTime.Today : hdban.NgayLap),
                                 NguoiLap = hdban.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdban.NgaySua == null ? DateTime.Today : hdban.NgaySua),
                                 NguoiSua = hdban.NguoiSua,
                             }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
    }
    
}
