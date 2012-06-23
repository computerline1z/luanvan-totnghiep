using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class LoHoaDonBan
    {
        public string MaLoHDBan { get; set; }
        public string MaLoaiHang { get; set; }
        public DateTime NgayLoHDBan { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class LoHoaDonBanBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy Danh Sách Lô Hóa Đơn Bán
        public List<LoHoaDonBan> LayDanhSachLoHoaDonBan()
        {
            var lohoadonban = (from lohdban in QLKT.LoHDBans
                               select new LoHoaDonBan
                               {
                                   MaLoHDBan = lohdban.MaLoHDBan,
                                   MaLoaiHang = lohdban.MaLoaiHang,
                                   NgayLoHDBan = Convert.ToDateTime(lohdban.NgayLoHDBan == null ? DateTime.Today : lohdban.NgayLoHDBan),
                                   MoTa = lohdban.MoTa,
                                   NgayLap = Convert.ToDateTime(lohdban.NgayLap == null ? DateTime.Today : lohdban.NgayLap),
                                   NguoiLap = lohdban.NguoiLap,
                                   NgaySua = Convert.ToDateTime(lohdban.NgaySua == null ? DateTime.Today : lohdban.NgaySua),
                                   NguoiSua = lohdban.NguoiSua,
                               }).ToList<LoHoaDonBan>();
            return lohoadonban;
        }
        //Lấy Danh Sách Mã Lô Hóa Đơn Bán
        public IQueryable LayDanhSachMaLoHoaDonBan()
        {
            var malohdban = from lohdban in QLKT.LoHDBans
                            select new { lohdban.MaLoHDBan,lohdban.NgayLoHDBan,lohdban.MoTa,};
            return malohdban.Distinct();
        }
        //Lấy Danh Sách Mã Loại Hàng
        public IQueryable LayDanhSachMaLoaiHang()
        {
            var maloaihang = from loaihang in QLKT.LoaiHangs
                             select new { loaihang.MaLoaiHang, loaihang.TenLoaiHang };
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
        //Kiểm tra 1 lô hóa đơn bán có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraLoHoaDonBan(string malohoadonban)
        {
            var lohoadonban = from lohdban in QLKT.LoHDBans
                                where lohdban.MaLoHDBan == malohoadonban
                                select lohdban;
            if (lohoadonban.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm lô hóa đơn bán
        public void ThemLoHDBan(string Malohoadonban,string maloaihang, DateTime ngaylohoadonban, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemtraLoHoaDonBan(Malohoadonban) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoHDBan LoHDBan = new QuanLy_KeToan.DataAccessLayer.LoHDBan();
                LoHDBan.MaLoHDBan = Malohoadonban;
                LoHDBan.MaLoaiHang = maloaihang;
                LoHDBan.NgayLoHDBan = ngaylohoadonban;
                LoHDBan.MoTa = mota;
                LoHDBan.NgayLap = ngaylap;
                LoHDBan.NguoiLap = nguoilap;
                LoHDBan.NgaySua = ngaysua;
                LoHDBan.NguoiSua = nguoisua;

                QLKT.LoHDBans.InsertOnSubmit(LoHDBan);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 lô hóa đơn bán
        public void SuaLoHDBan(string malohdban, QuanLy_KeToan.DataAccessLayer.LoHDBan LoHDBan)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.LoHDBan lohdban = QLKT.LoHDBans.Single(lohoadonban => lohoadonban.MaLoHDBan == malohdban);
                lohdban.MaLoaiHang = LoHDBan.MaLoaiHang;
                lohdban.NgayLoHDBan = LoHDBan.NgayLoHDBan;
                lohdban.MoTa = LoHDBan.MoTa;
                lohdban.NgayLap = LoHDBan.NgayLap;
                lohdban.NguoiLap = LoHDBan.NguoiLap;
                lohdban.NgaySua = LoHDBan.NgaySua;
                lohdban.NguoiSua = LoHDBan.NguoiSua;

                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraLoXuat(string malohdban)
        {
            var sql = from lpx in QLKT.LoPhieuXuats
                      where lpx.MaLoHDBan == malohdban
                      select lpx;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraLoPhieuThu(string malohdban)
        {
            var sql2 = from lpt in QLKT.LoPhieuThus
                       where lpt.MaLoHDBan == malohdban
                       select lpt;
            if (sql2.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraHoaDonBan(string malohdban)
        {
            var sql3 = from hdb in QLKT.HoaDonBans
                       where hdb.MaLoHDBan == malohdban
                       select hdb;
            if (sql3.Count() > 0)
                return true;
            else
                return false;
        }
        //Xóa lô hóa đơn bán
        public void XoaLoHDBan(string malohdban)
        {
            if (KiemTraLoXuat(malohdban) == true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này-Liên quan đến CSDL Lô Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraLoPhieuThu(malohdban) == true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này-Liên quan đến CSDL Lô Phiếu Thu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraHoaDonBan(malohdban) == true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này-Liên quan đến CSDL Hóa Đơn Bán", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lohdban in QLKT.LoHDBans
                             where lohdban.MaLoHDBan == malohdban
                             select lohdban;
                if (delete.Count() > 0)
                {
                    QLKT.LoHDBans.DeleteOnSubmit(delete.First());
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
