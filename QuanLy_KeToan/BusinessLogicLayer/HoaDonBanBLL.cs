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
        public string NgayHDBan { get; set; }
        public string Mota { get; set; }
        public string TrangThai { get; set; }

    }
    class HoaDonBanBLL
    {
        QuanLy_KeToanDataContext QLKT=new QuanLy_KeToanDataContext();

        //Lay Danh Sach Hoa Don Ban
        public List<Hoa_Don_Ban> LayDanhSachHoaDonBan()
        {
            var hoadonban=(from hdban in QLKT.HoaDonBans 
                           select new Hoa_Don_Ban
                           {
                               MaHDBan=hdban.MaHDBan,
                               MaLoaiHDBan=hdban.MaLoaiHDBan,
                               MaLoHDBan=hdban.MaLoHDBan,
                               MaKhachHang=hdban.MaKhachHang,
                               MaTienTe=hdban.MaTienTe,
                               NgayHDBan=hdban.NgayHDBan.ToString(),
                               Mota=hdban.MoTa,
                               TrangThai=hdban.TrangThai.ToString(),
                           }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
        //Lay Danh Sach Hoa Don Bán Theo MaKhachHang
        public List<Hoa_Don_Ban> LayDanhSachHoaDonTheoMaKhachHang(string makhachhang)
        {
            var hoadonban=(from hdban in QLKT.HoaDonBans 
                           where (hdban.MaKhachHang==makhachhang)
                           select new Hoa_Don_Ban
                           {
                               MaHDBan=hdban.MaHDBan,
                               MaLoaiHDBan=hdban.MaLoaiHDBan,
                               MaLoHDBan=hdban.MaLoHDBan,
                               MaKhachHang=hdban.MaKhachHang,
                               MaTienTe=hdban.MaTienTe,
                               NgayHDBan=hdban.NgayHDBan.ToString(),
                               Mota=hdban.MoTa,
                               TrangThai=hdban.TrangThai.ToString(),
                           }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
        //Lấy Danh Sách Mã Loại Hóa Đơn Bán cho ColMaLoaiHDBan
        public IQueryable LayDanhSachMaLoaiHoaDonBan()
        {
            var maloaihdban= from loaihdban in QLKT.LoaiHDBans
                             select new {loaihdban.MaLoaiHDBan};                  
            return maloaihdban.Distinct();
        }
        //Lấy Danh Sách Mã Lô Hóa Đơn Bán Cho ColMaLoHDBan
        public IQueryable LayDanhSachMaLoHoaDonBan()
        {
            var malohdban=from lohdban in QLKT.LoHDBans
                          select new {lohdban.MaLoHDBan};
            return malohdban.Distinct();
        }
        //Lấy Danh Sách Mã Khách Hàng cho ColMaKhachHang
        public IQueryable LayDanhSachMaKhachHang()
        {
            var makhachhang=from kh in QLKT.KhachHangs
                            select new {kh.MaKhachHang,kh.TenKhachHang};
            return makhachhang.Distinct();
        }
        //Lấy Danh Sách Mã Tiền Tệ cho ColMaTienTe
        public IQueryable LayDanhSachMaTienTe()
        {
            var matiente = from tiente in QLKT.TyGiaNgoaiTes
                           select new {tiente.MaTienTe};
            return matiente.Distinct();
        }
        //Kiểm tra 1 hóa đơn bán có tồn tại hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraHoaDonBan(string mahoadonban)
        {
            var hoadonban = from hdban in QLKT.HoaDonBans
                            where hdban.MaHDBan == mahoadonban
                            select hdban;
            if (hoadonban.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm hóa đơn bán
        public void ThemHDBan(string Mahoadonban, string Maloaihoadonban, string Malohoadonban, string Makhachhang, string matiente, string ngayhdban, string mota, string trangthai)
        {
            if (KiemtraHoaDonBan(Mahoadonban) == true)
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
               // HDBan.NgayHDBan = ngayhdban;
                HDBan.MoTa = mota;
               // HDBan.TrangThai = trangthai;
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
        public void SuaHDBan(string mahdban, QuanLy_KeToan.DataAccessLayer.HoaDonBan HDBan)
        {
            try
            {
                QuanLy_KeToan.DataAccessLayer.HoaDonBan hdban = QLKT.HoaDonBans.Single(hoadonban => hoadonban.MaHDBan == mahdban);
                hdban.MaLoaiHDBan = HDBan.MaLoaiHDBan;
                hdban.MaLoHDBan = HDBan.MaLoHDBan;
                hdban.MaKhachHang = HDBan.MaKhachHang;
                hdban.MaTienTe = HDBan.MaTienTe;
                hdban.NgayHDBan = HDBan.NgayHDBan;
                hdban.MoTa = HDBan.MoTa;
                hdban.TrangThai = HDBan.TrangThai;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Xóa hóa đơn bán
        public void XoaHDBan(string mahdban)
        {
            
            try
            {
                var delete = from hdban in QLKT.HoaDonBans
                             where hdban.MaHDBan == mahdban
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
                               MaHDBan=hdban.MaHDBan,
                               MaLoaiHDBan=hdban.MaLoaiHDBan,
                               MaLoHDBan=hdban.MaLoHDBan,
                               MaKhachHang=hdban.MaKhachHang,
                               MaTienTe=hdban.MaTienTe,
                               NgayHDBan=hdban.NgayHDBan.ToString(),
                               Mota=hdban.MoTa,
                               TrangThai=hdban.TrangThai.ToString(),
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
                                 NgayHDBan = hdban.NgayHDBan.ToString(),
                                 Mota = hdban.MoTa,
                                 TrangThai = hdban.TrangThai.ToString(),
                             }).ToList<Hoa_Don_Ban>();
            return hoadonban;
        }
    }
}
