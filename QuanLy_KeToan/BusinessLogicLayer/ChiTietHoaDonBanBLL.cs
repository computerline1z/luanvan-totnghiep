using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Chi_Tiet_Hoa_Don_Ban
    {
        public string malohdban { get; set; }
        public string mahdban { get; set; }
        public string mahang { get; set; }
        public int soluong { get; set; }
        public bool thanhtoan { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class ChiTietHoaDonBanBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public IQueryable LayMaHang(string malohdban, string mahdban)
        {
            var sql = from hang in QLKT.Hangs
                      from lohdban in QLKT.LoHDBans
                      where lohdban.MaLoaiHang == hang.MaLoaiHang && lohdban.MaLoHDBan == malohdban
                      select new
                      {
                          hang.MaHang,
                          hang.TenHang,
                      };
            return sql;
        }
        //public int LaySLHangTheoChiTietHDBan(string malohdban, string mahdban, string hang)
        //{
        //    int sl = 0;
        //    var sql = from cthdb in QLKT.ChiTietHDBans
        //              where cthdb.MaLoHDBan == malohdban && cthdb.MaHDBan == mahdban && cthdb.MaHang == hang
        //              select cthdb.SoLuong;
        //    foreach (var item in sql)
        //    {
        //        sl = System.Convert.ToInt16(item.ToString());
        //    }
        //    return sl;
        //}
        public List<Chi_Tiet_Hoa_Don_Ban> LayChiTietHoaDonBan(string malohdban, string mahdban)
        {
            var sql = (from cthdb in QLKT.ChiTietHDBans
                       where (cthdb.MaLoHDBan == malohdban && cthdb.MaHDBan == mahdban)
                       select new Chi_Tiet_Hoa_Don_Ban
                       {
                           malohdban = cthdb.MaLoHDBan,
                           mahdban = cthdb.MaHDBan,
                           mahang = cthdb.MaHang,
                           soluong = System.Convert.ToInt16(cthdb.SoLuong.Value != null ? cthdb.SoLuong : 0),
                           thanhtoan = System.Convert.ToBoolean(cthdb.ThanhToan.Value),
                           ngaylap = Convert.ToDateTime(cthdb.NgayLap == null ? DateTime.Today : cthdb.NgayLap),
                           nguoilap = cthdb.NguoiLap,
                           ngaysua = Convert.ToDateTime(cthdb.NgaySua == null ? DateTime.Today : cthdb.NgaySua),
                           nguoisua = cthdb.NguoiSua,
                       }).ToList<Chi_Tiet_Hoa_Don_Ban>();
            return sql;
        }
        
        private bool KiemTraDulieu(string malohdban, string mahdban, string mahang)
        {
            var sql = from cthdb in QLKT.ChiTietHDBans
                      where cthdb.MaLoHDBan == malohdban && cthdb.MaHDBan == mahdban && cthdb.MaHang == mahang
                      select cthdb;
            if (sql.Count() > 0)
                return true;
            else return false;
        }

        //Code Thêm-Xóa-Sửa Chi Tiết Hóa Đơn Bán

        public bool ThemCTHDBan(string malohdban, string mahdban, string mahang, int soluong,bool thanhtoan, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdban, mahdban, mahang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                ChiTietHDBan CTHDBan = new ChiTietHDBan();
                CTHDBan.MaLoHDBan = malohdban;
                CTHDBan.MaHDBan = mahdban;
                CTHDBan.MaHang = mahang;
                CTHDBan.SoLuong = soluong;
                CTHDBan.ThanhToan = thanhtoan;
                CTHDBan.NgayLap = ngaylap;
                CTHDBan.NguoiLap = nguoilap;
                CTHDBan.NgaySua = ngaysua;
                CTHDBan.NguoiSua = nguoisua;
                QLKT.ChiTietHDBans.InsertOnSubmit(CTHDBan);
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
        public bool SuaCTHDBan(string malohdban, string mahdban, string mahang, ChiTietHDBan CTHDBan)
        {
            try
            {
                ChiTietHDBan cthdban = QLKT.ChiTietHDBans.Single(_cthdban => _cthdban.MaLoHDBan == malohdban && _cthdban.MaHDBan == mahdban && _cthdban.MaHang == mahang);
                cthdban.SoLuong = CTHDBan.SoLuong;
                cthdban.ThanhToan = CTHDBan.ThanhToan;
                cthdban.NgayLap = CTHDBan.NgayLap;
                cthdban.NguoiLap = CTHDBan.NguoiLap;
                cthdban.NgaySua = CTHDBan.NgaySua;
                cthdban.NguoiSua = CTHDBan.NguoiSua;
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
        private bool KiemTraChiTietPhieuXuat(string malohdban, string mahdban, string mahang)
        {
            var sql = from ctpx in QLKT.ChiTietPhieuXuats
                      where ctpx.MaLoHDBan == malohdban && ctpx.MaHDBan == mahdban && ctpx.MaHang == mahang
                      select ctpx;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        private bool KiemTraChiTietPhieuThu(string malohdban, string mahdban, string mahang)
        {
            var sql = from ctpt in QLKT.ChiTietPhieuThus
                      where ctpt.MaLoHDBan == malohdban && ctpt.MaHDBan == mahdban && ctpt.MaHang == mahang
                      select ctpt;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public bool XoaCTHDBan(string malohdban, string mahdban, string mahang)
        {
            if (KiemTraChiTietPhieuXuat(malohdban, mahdban, mahang) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (KiemTraChiTietPhieuThu(malohdban, mahdban, mahang) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Chi Tiết Phiếu Thu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                var delete = from cthdban in QLKT.ChiTietHDBans
                             where cthdban.MaLoHDBan == malohdban && cthdban.MaHDBan == mahdban && cthdban.MaHang == mahang
                             select cthdban;
                if (delete.Count() > 0)
                {
                    QLKT.ChiTietHDBans.DeleteOnSubmit(delete.First());
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
        //Cập nhật chi tiết phiếu xuất khi thay đổi chi tiết hóa đơn bán
        public void CapNhatLaiCTPXKhiThayDoiCTHDB(string malohdban, string mahdban, string mahang,int sl)
        {
            var ctpx = from _ctpx in QLKT.ChiTietPhieuXuats
                       where _ctpx.MaLoHDBan == malohdban && _ctpx.MaHDBan == mahdban && _ctpx.MaHang == mahang
                       select _ctpx.SoLuong;
            if (ctpx.Count() > 0)
            {
                int _sl = 0;
                foreach (var item in ctpx)
                {
                    _sl = System.Convert.ToInt16(item);
                }
                if (_sl != sl)
                {
                    int sl_khochua = 0;
                    var hang = from kc in QLKT.KhoChuas
                               where kc.MaHang == mahang
                               select kc.SL;
                    if (hang.Count() > 0)
                    {
                        foreach (var item in hang)
                        {
                            sl_khochua = System.Convert.ToInt16(item);
                        }
                    }
                    int update = sl - _sl;
                    if (update > sl_khochua)
                    {
                        MessageBox.Show("Số lượng Hàng trong kho không đủ để xuất ra thêm", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        sl_khochua -= update;
                        //Cập nhật chi tiết phiếu xuất
                        try
                        {
                            ChiTietPhieuXuat chitietpx = QLKT.ChiTietPhieuXuats.Single(_chitietpx => _chitietpx.MaHang == mahang);
                            chitietpx.SoLuong = sl;
                            QLKT.SubmitChanges();
                            if (update > 0)
                                MessageBox.Show("Số lượng Hàng " + mahang + " xuất thêm khỏi kho: " + update.ToString() + Environment.NewLine +
                                                "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString(), "Cập nhật lại kho chứa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else if (update == 0)
                                MessageBox.Show("Số lượng Hàng " + mahang + " giữ nguyên" + Environment.NewLine +
                                                "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString(), "Cập nhật lại kho chứa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Số lượng Hàng " + mahang + " trả lại vào kho: " + (-update).ToString() + Environment.NewLine +
                                                "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString(), "Cập nhật lại kho chứa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //Cập nhật kho chứa
                        try
                        {
                            KhoChua khochua = QLKT.KhoChuas.Single(_kc => _kc.MaHang == mahang);
                            khochua.SL = sl_khochua;
                            QLKT.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }
    }
}
