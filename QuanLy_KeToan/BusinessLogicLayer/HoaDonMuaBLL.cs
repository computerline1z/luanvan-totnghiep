using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;


namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Hoa_Don_Mua
    {
        public string MaHDMua { get; set; }
        public string MaLoaiHDMua { get; set; }
        public string MaLoHDMua { get; set; }
        public string MaNCC { get; set; }
        public string MaTienTe { get; set; }
        public string Mota { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }

    }
    class HoaDonMuaBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        //Lay Danh Sach Hoa Don Mua
        public List<Hoa_Don_Mua> LayDanhSachHoaDonMua()
        {
            var hoadonmua = (from hdmua in QLKT.HoaDonMuas
                             select new Hoa_Don_Mua
                             {
                                 MaHDMua = hdmua.MaHDMua,
                                 MaLoaiHDMua = hdmua.MaLoaiHDMua,
                                 MaLoHDMua = hdmua.MaLoHDMua,
                                 MaNCC = hdmua.MaNCC,
                                 MaTienTe = hdmua.MaTienTe,
                                 Mota = hdmua.MoTa,
                                 NgayLap = Convert.ToDateTime(hdmua.NgayLap == null ? DateTime.Today : hdmua.NgayLap),
                                 NguoiLap = hdmua.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdmua.NgaySua == null ? DateTime.Today : hdmua.NgaySua),
                                 NguoiSua = hdmua.NguoiSua,
                             }).ToList<Hoa_Don_Mua>();
            return hoadonmua;
        }
        //Lay Danh Sach Hoa Don Mua Theo MaNhaCungCap
        public List<Hoa_Don_Mua> LayDanhSachHoaDonTheoMaNhaCungCap(string manhacungcap)
        {
            var hoadonmua = (from hdmua in QLKT.HoaDonMuas
                             where (hdmua.MaNCC == manhacungcap)
                             select new Hoa_Don_Mua
                             {
                                 MaHDMua = hdmua.MaHDMua,
                                 MaLoaiHDMua = hdmua.MaLoaiHDMua,
                                 MaLoHDMua = hdmua.MaLoHDMua,
                                 MaNCC = hdmua.MaNCC,
                                 MaTienTe = hdmua.MaTienTe,
                                 Mota = hdmua.MoTa,
                                 NgayLap = Convert.ToDateTime(hdmua.NgayLap == null ? DateTime.Today : hdmua.NgayLap),
                                 NguoiLap = hdmua.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdmua.NgaySua == null ? DateTime.Today : hdmua.NgaySua),
                                 NguoiSua = hdmua.NguoiSua,
                             }).ToList<Hoa_Don_Mua>();
            return hoadonmua;
        }
        //Lay danh sách mã hóa đơn theo lô
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
        //Lay Danh Sach Hoa Don Bán Theo MaLoHDMua
        public List<Hoa_Don_Mua> LayDanhSachHoaDonTheoMaLoHoaDonMua(string malohoadonmua)
        {
            var hoadonmua = (from hdmua in QLKT.HoaDonMuas
                             where (hdmua.MaLoHDMua == malohoadonmua)
                             select new Hoa_Don_Mua
                             {
                                 MaHDMua = hdmua.MaHDMua,
                                 MaLoaiHDMua = hdmua.MaLoaiHDMua,
                                 MaLoHDMua = hdmua.MaLoHDMua,
                                 MaNCC = hdmua.MaNCC,
                                 MaTienTe = hdmua.MaTienTe,
                                 Mota = hdmua.MoTa,
                                 NgayLap = Convert.ToDateTime(hdmua.NgayLap == null ? DateTime.Today : hdmua.NgayLap),
                                 NguoiLap = hdmua.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdmua.NgaySua == null ? DateTime.Today : hdmua.NgaySua),
                                 NguoiSua = hdmua.NguoiSua,
                             }).ToList<Hoa_Don_Mua>();
            return hoadonmua;
        }
        //Lấy Danh Sách Mã Loại Hóa Đơn Bán cho ColMaLoaiHDMua
        public IQueryable LayDanhSachMaLoaiHoaDonMua()
        {
            var maloaihdmua = from loaihdmua in QLKT.LoaiHDMuas
                              select new { loaihdmua.MaLoaiHDMua };
            return maloaihdmua.Distinct();
        }
        //Lấy Danh Sách Mã Lô Hóa Đơn Bán Cho ColMaLoHDMua
        public IQueryable LayDanhSachMaLoHoaDonMua()
        {
            var malohdmua = from lohdmua in QLKT.LoHDMuas
                            select new { lohdmua.MaLoHDMua };
            return malohdmua.Distinct();
        }
        //Lấy Danh Sách Mã Khách Hàng cho ColMaKhachHang
        public IQueryable LayDanhSachMaNCC()
        {
            var mancc = from ncc in QLKT.NhaCungCaps
                              select new { ncc.MaNCC, ncc.TenNCC };
            return mancc.Distinct();
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
        //Kiểm tra 1 hóa đơn mua có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraHoaDonMua(string malohoadonmua, string mahoadonmua)
        {
            var hoadonmua = from hdmua in QLKT.HoaDonMuas
                            where hdmua.MaLoHDMua == malohoadonmua && hdmua.MaHDMua == mahoadonmua
                            select hdmua;
            if (hoadonmua.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm hóa đơn mua
        public void ThemHDMua(string Mahoadonmua, string Maloaihoadonmua, string Malohoadonmua, string Manhacungcap, string matiente, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemtraHoaDonMua(Malohoadonmua, Mahoadonmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.HoaDonMua HDMua = new QuanLy_KeToan.DataAccessLayer.HoaDonMua();
                HDMua.MaHDMua = Mahoadonmua;
                HDMua.MaLoaiHDMua = Maloaihoadonmua;
                HDMua.MaLoHDMua = Malohoadonmua;
                HDMua.MaNCC = Manhacungcap;
                HDMua.MaTienTe = matiente;
                HDMua.MoTa = mota;
                HDMua.NgayLap = ngaylap;
                HDMua.NguoiLap = nguoilap;
                HDMua.NgaySua = ngaysua;
                HDMua.NguoiSua = nguoisua;
                QLKT.HoaDonMuas.InsertOnSubmit(HDMua);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 hóa đơn mua
        public void SuaHDMua(string malohdmua, string mahdmua, QuanLy_KeToan.DataAccessLayer.HoaDonMua HDMua)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.HoaDonMua hdmua = QLKT.HoaDonMuas.Single(hoadonmua => hoadonmua.MaLoHDMua == malohdmua && hoadonmua.MaHDMua == mahdmua);
                hdmua.MaLoaiHDMua = HDMua.MaLoaiHDMua;
                hdmua.MaNCC = HDMua.MaNCC;
                hdmua.MaTienTe = HDMua.MaTienTe;
                hdmua.MoTa = HDMua.MoTa;
                hdmua.NgayLap = HDMua.NgayLap;
                hdmua.NguoiLap = HDMua.NguoiLap;
                hdmua.NgaySua = HDMua.NgaySua;
                hdmua.NguoiSua = HDMua.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraChiTietHoaDonMua(string malohdmua, string mahdmua)
        {
            var sql = from cthdmua in QLKT.ChiTietHDMuas
                      where cthdmua.MaLoHDMua == malohdmua && cthdmua.MaHDMua == mahdmua
                      select cthdmua;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraPhieuNhap(string malohdmua, string mahdmua)
        {
            var sql = from phieunhap in QLKT.PhieuNhaps
                      where phieunhap.MaLoHDMua == malohdmua && phieunhap.MaHDMua == mahdmua
                      select phieunhap;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraPhieuChi(string malohdmua, string mahdmua)
        {
            var sql = from phieuchi in QLKT.PhieuChis
                      where phieuchi.MaLoHDMua == malohdmua && phieuchi.MaHDMua == mahdmua
                      select phieuchi;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Xóa hóa đơn mua
        public void XoaHDMua(string malohdmua, string mahdmua)
        {
            if (KiemTraChiTietHoaDonMua(malohdmua, mahdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Hóa Đơn Mua", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraPhieuNhap(malohdmua, mahdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraPhieuChi(malohdmua, mahdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Chi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from hdmua in QLKT.HoaDonMuas
                             where hdmua.MaLoHDMua == malohdmua && hdmua.MaHDMua == mahdmua
                             select hdmua;
                if (delete.Count() > 0)
                {
                    QLKT.HoaDonMuas.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Tìm Kiếm Hoa Don Mua Theo Mã Nhà Cung Cấp cho comboboxMaNhaCungCap
        public List<Hoa_Don_Mua> TimTatCaHoaDonMuaTheoMaKhachHang(string manhacungcap)
        {
            var hoadonmua = (from hdmua in QLKT.HoaDonMuas
                             where hdmua.MaNCC == manhacungcap
                             select new Hoa_Don_Mua
                             {
                                 MaHDMua = hdmua.MaHDMua,
                                 MaLoaiHDMua = hdmua.MaLoaiHDMua,
                                 MaLoHDMua = hdmua.MaLoHDMua,
                                 MaNCC = hdmua.MaNCC,
                                 MaTienTe = hdmua.MaTienTe,
                                 Mota = hdmua.MoTa,
                                 NgayLap = Convert.ToDateTime(hdmua.NgayLap == null ? DateTime.Today : hdmua.NgayLap),
                                 NguoiLap = hdmua.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdmua.NgaySua == null ? DateTime.Today : hdmua.NgaySua),
                                 NguoiSua = hdmua.NguoiSua,

                             }).ToList<Hoa_Don_Mua>();
            return hoadonmua;
        }
        //Tìm Kiếm Hoa Don Mua Theo Mã Hoa Don Mua cho TextBox_TimKiem 
        public List<Hoa_Don_Mua> TimTatCaHoaDonMuaChinhXacTheoMaHoaDonMua(string mahoadonmua)
        {
            var hoadonmua = (from hdmua in QLKT.HoaDonMuas
                             where hdmua.MaHDMua == mahoadonmua
                             select new Hoa_Don_Mua
                             {
                                 MaHDMua = hdmua.MaHDMua,
                                 MaLoaiHDMua = hdmua.MaLoaiHDMua,
                                 MaLoHDMua = hdmua.MaLoHDMua,
                                 MaNCC = hdmua.MaNCC,
                                 MaTienTe = hdmua.MaTienTe,
                                 Mota = hdmua.MoTa,
                                 NgayLap = Convert.ToDateTime(hdmua.NgayLap == null ? DateTime.Today : hdmua.NgayLap),
                                 NguoiLap = hdmua.NguoiLap,
                                 NgaySua = Convert.ToDateTime(hdmua.NgaySua == null ? DateTime.Today : hdmua.NgaySua),
                                 NguoiSua = hdmua.NguoiSua,
                             }).ToList<Hoa_Don_Mua>();
            return hoadonmua;
        }
    }

}
