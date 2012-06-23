using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;


namespace QuanLy_KeToan.BusinessLogicLayer
{
    class LoaiHoaDonBan
    {
        public string MaLoaiHDBan { get; set; }
        public string TenLoaiHDBan { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class LoaiHoaDonBanBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lay Danh Sach Loai Hoa Don Ban
        public List<LoaiHoaDonBan> LayDanhSachLoaiHoaDonBan()
        {
            var loaihoadonban = (from loaihdban in QLKT.LoaiHDBans
                                 select new LoaiHoaDonBan
                                 {
                                     MaLoaiHDBan = loaihdban.MaLoaiHDBan,
                                     TenLoaiHDBan = loaihdban.TenLoaiHDBan,
                                     NgayLap = Convert.ToDateTime(loaihdban.NgayLap == null ? DateTime.Today : loaihdban.NgayLap),
                                     NguoiLap = loaihdban.NguoiLap,
                                     NgaySua = Convert.ToDateTime(loaihdban.NgaySua == null ? DateTime.Today : loaihdban.NgaySua),
                                     NguoiSua = loaihdban.NguoiSua,

                                 }).ToList<LoaiHoaDonBan>();
            return loaihoadonban;
        }
        //Lay Danh Sach Mã Loại Hóa Đơn Bán
        public IQueryable LayDanhSachMaLoaiHoaDonBan()
        {
            var maloaihdban = from hoadonban in QLKT.LoaiHDBans
                              select new { hoadonban.MaLoaiHDBan, };
            return maloaihdban.Distinct();
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
        //Kiểm tra 1 loai hóa đơn bán có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraLoaiHoaDonBan(string maloaihoadonban)
        {
            var loaihoadonban = from loaihdban in QLKT.LoaiHDBans
                            where loaihdban.MaLoaiHDBan == maloaihoadonban
                            select loaihdban;
            if (loaihoadonban.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm loại hóa đơn bán
        public void ThemLoaiHDBan(string Maloaihoadonban, string tenloaihoadonban, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemtraLoaiHoaDonBan(Maloaihoadonban) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoaiHDBan LoaiHDBan = new QuanLy_KeToan.DataAccessLayer.LoaiHDBan();
                LoaiHDBan.MaLoaiHDBan = Maloaihoadonban;
                LoaiHDBan.TenLoaiHDBan = tenloaihoadonban;
                LoaiHDBan.NgayLap = ngaylap;
                LoaiHDBan.NguoiLap = nguoilap;
                LoaiHDBan.NgaySua = ngaysua;
                LoaiHDBan.NguoiSua = nguoisua; 
                
                QLKT.LoaiHDBans.InsertOnSubmit(LoaiHDBan);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 loại hóa đơn bán
        public void SuaLoaiHDBan(string maloaihdban, QuanLy_KeToan.DataAccessLayer.LoaiHDBan LoaiHDBan)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoaiHDBan loaihdban = QLKT.LoaiHDBans.Single(loaihoadonban => loaihoadonban.MaLoaiHDBan == maloaihdban);
                loaihdban.TenLoaiHDBan = LoaiHDBan.TenLoaiHDBan;
                loaihdban.NgayLap = LoaiHDBan.NgayLap;
                loaihdban.NguoiLap = LoaiHDBan.NguoiLap;
                loaihdban.NgaySua = LoaiHDBan.NgaySua;
                loaihdban.NguoiSua = LoaiHDBan.NguoiSua;
                
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraHoaDonBan(string maloaihdban)
        {
            var sql = from hdb in QLKT.HoaDonBans
                      where hdb.MaLoaiHDBan == maloaihdban
                      select hdb;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Xóa loại hóa đơn bán
        public void XoaLoaiHDBan(string maloaihdban)
        {
            if (KiemTraHoaDonBan(maloaihdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Hóa đơn bán", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from loaihdban in QLKT.LoaiHDBans
                             where loaihdban.MaLoaiHDBan == maloaihdban
                             select loaihdban;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiHDBans.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Tìm Kiếm Loai Hoa Don Ban Theo Mã Loai Hoa Don Ban cho Combobox 
        public List<LoaiHoaDonBan> TimTatCaLoaiHoaDonBanChinhXacTheoMaLoaiHoaDonBan(string maloaihoadonban)
        {
            var loaihoadonban = (from loaihdban in QLKT.LoaiHDBans
                             where loaihdban.MaLoaiHDBan == maloaihoadonban
                             select new LoaiHoaDonBan
                             {
                                 MaLoaiHDBan = loaihdban.MaLoaiHDBan,
                                 TenLoaiHDBan = loaihdban.TenLoaiHDBan,
                                 NgayLap = Convert.ToDateTime(loaihdban.NgayLap == null ? DateTime.Today : loaihdban.NgayLap),
                                 NguoiLap = loaihdban.NguoiLap,
                                 NgaySua = Convert.ToDateTime(loaihdban.NgaySua == null ? DateTime.Today : loaihdban.NgaySua),
                                 NguoiSua = loaihdban.NguoiSua,
                                 
                             }).ToList<LoaiHoaDonBan>();
            return loaihoadonban;
        }
        //Tìm gần đúng
        public List<LoaiHoaDonBan> TimTatCaLoaiHoaDonTheoTenLoaiHoaDon(string tenloaihoadonban)
        {
            var loaihoadonban = (from loaihdban in QLKT.LoaiHDBans  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where loaihdban.TenLoaiHDBan.Contains(tenloaihoadonban)
                        select new LoaiHoaDonBan
                        {
                            MaLoaiHDBan = loaihdban.MaLoaiHDBan,
                            TenLoaiHDBan = loaihdban.TenLoaiHDBan,
                            NgayLap = Convert.ToDateTime(loaihdban.NgayLap == null ? DateTime.Today : loaihdban.NgayLap),
                            NguoiLap = loaihdban.NguoiLap,
                            NgaySua = Convert.ToDateTime(loaihdban.NgaySua == null ? DateTime.Today : loaihdban.NgaySua),
                            NguoiSua = loaihdban.NguoiSua,
                           
                        }).ToList<LoaiHoaDonBan>();
            return loaihoadonban;
        }
    }
}
