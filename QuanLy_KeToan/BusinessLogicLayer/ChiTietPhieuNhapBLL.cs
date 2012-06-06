using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;
namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Chi_Tiet_Phieu_Nhap
    {
        public string malohdmua { get; set; }
        public string mahdmua { get; set; }
        public string mahang { get; set; }
        public string makhohang { get; set; }
        public int soluong { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class ChiTietPhieuNhapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        public IQueryable LayMaHang(string malohdmua,string mahdmua)
        {
            var sql = from hang in QLKT.Hangs
                      from cthdmua in QLKT.ChiTietHDMuas
                      where hang.MaHang==cthdmua.MaHang && cthdmua.MaLoHDMua ==malohdmua && cthdmua.MaHDMua==mahdmua
                      select new
                      {
                          hang.MaHang,
                          hang.TenHang,
                      };
            return sql;
        }
        public int LaySLHangTheoChiTietHDMua(string malohdmua, string mahdmua, string hang)
        {
            int sl = 0;
            var sql = from cthdm in QLKT.ChiTietHDMuas
                      where cthdm.MaLoHDMua == malohdmua && cthdm.MaHDMua == mahdmua && cthdm.MaHang == hang
                      select cthdm.SoLuong;
            foreach (var item in sql)
            {
                sl = System.Convert.ToInt16(item.ToString());
            }
            return sl;
        }
        public IQueryable LayKhoHang(string malohdmua)
        {
            var sql = from kh in QLKT.KhoHangs
                      from pn in QLKT.PhieuNhaps
                      from lohdmua in QLKT.LoHDMuas
                      where (pn.MaLoHDMua==lohdmua.MaLoHDMua &&
                        lohdmua.MaLoaiHang==kh.MaLoaiHang && pn.MaLoHDMua == malohdmua)
                      select new { kh.MaKhoHang, kh.TenKhoHang, };
            return sql;
        }
        public string LayMaKhoHang(string malohdmua)
        {
            string makhohang = "";
            var sql = from kh in QLKT.KhoHangs
                      from pn in QLKT.PhieuNhaps
                      from lohdmua in QLKT.LoHDMuas
                      where (pn.MaLoHDMua == lohdmua.MaLoHDMua &&
                        lohdmua.MaLoaiHang == kh.MaLoaiHang && pn.MaLoHDMua == malohdmua)
                      select kh.MaKhoHang;
            foreach (var item in sql)
            {
                makhohang = item.ToString();
            }
            return makhohang;
        }
        public List<Chi_Tiet_Phieu_Nhap> LayChiTietPhieuNhap(string malohdmua,string mahdmua)
        {
            var sql = (from ctpn in QLKT.ChiTietPhieuNhaps
                       where (ctpn.MaLoHDMua == malohdmua && ctpn.MaHDMua == mahdmua)
                       select new Chi_Tiet_Phieu_Nhap
                       {
                           malohdmua = ctpn.MaLoHDMua,
                           mahdmua = ctpn.MaHDMua,
                           mahang = ctpn.MaHang,
                           makhohang = ctpn.MaKhoHang,
                           soluong = System.Convert.ToInt16(ctpn.SoLuong.Value != null ? ctpn.SoLuong : 0),
                           ngaylap = Convert.ToDateTime(ctpn.NgayLap == null ? DateTime.Today : ctpn.NgayLap),
                           nguoilap = ctpn.NguoiLap,
                           ngaysua = Convert.ToDateTime(ctpn.NgaySua == null ? DateTime.Today : ctpn.NgaySua),
                           nguoisua = ctpn.NguoiSua,
                       }).ToList<Chi_Tiet_Phieu_Nhap>();
            return sql;
        }
        public void CapNhatKhoChua(string mahang,string makhohang)
        {
            int sl_khochua = 0;
            var hang = from kc in QLKT.KhoChuas
                       where kc.MaHang == mahang
                       select kc.SL;
            if(hang.Count()>0)
            {
                foreach (var item in hang)
                {
                    sl_khochua = System.Convert.ToInt16(item);
                }
            }
            //MessageBox.Show(sl.ToString());
            int sl_ctpn = 0;
            var ctpn = from _ctpn in QLKT.ChiTietPhieuNhaps
                       where _ctpn.MaHang == mahang
                       select _ctpn.SoLuong;
            if (ctpn.Count() > 0)
            {
                foreach (var item in ctpn)
                {
                    sl_ctpn = System.Convert.ToInt16(item);
                }
            }
            sl_khochua += sl_ctpn;
            //MessageBox.Show(sl_khochua.ToString());
            try
            {
                KhoChua khochua = QLKT.KhoChuas.Single(_kc => _kc.MaHang == mahang);
                khochua.SL = sl_khochua;
                QLKT.SubmitChanges();
                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào kho chứa "+makhohang+" thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Số lượng Hàng " + mahang + " tăng thêm: " + sl_ctpn.ToString() + Environment.NewLine +
                                "Số lượng Hàng " + mahang + " hiện có: "+sl_khochua.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void CapNhatLaiKhoChua(string mahang,int soluongmoi)
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
            int sl_ctpn = 0;
            var ctpn = from _ctpn in QLKT.ChiTietPhieuNhaps
                       where _ctpn.MaHang == mahang
                       select _ctpn.SoLuong;
            if (ctpn.Count() > 0)
            {
                foreach (var item in ctpn)
                {
                    sl_ctpn = System.Convert.ToInt16(item);
                }
            }
            int update = soluongmoi - sl_ctpn;
            sl_khochua += update;
            //Cập nhật chi tiết phiếu nhập
            try
            {
                ChiTietPhieuNhap chitietpn = QLKT.ChiTietPhieuNhaps.Single(_chitietpn => _chitietpn.MaHang == mahang);
                chitietpn.SoLuong = soluongmoi;
                QLKT.SubmitChanges();
                if (update > 0)
                    MessageBox.Show("Số lượng Hàng " + mahang + " thêm tiếp vào kho: " + update.ToString()+Environment.NewLine+
                                    "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString());
                else if (update == 0)
                    MessageBox.Show("Số lượng Hàng " + mahang + " giữ nguyên."+Environment.NewLine+
                                    "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString());
                else
                    MessageBox.Show("Số lượng Hàng " + mahang + " thêm vào giảm bớt: " + update.ToString()+Environment.NewLine+
                                    "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString());
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

        private bool KiemTraDulieu(string malohdmua,string mahdmua,string mahang)
        {
            var sql = from ctpn in QLKT.ChiTietPhieuNhaps
                      where ctpn.MaLoHDMua == malohdmua && ctpn.MaHDMua==mahdmua && ctpn.MaHang==mahang
                      select ctpn;
            if (sql.Count() > 0)
                return true;
            else return false;
        }

        //Code Thêm-Xóa-Sửa Chi tiết phiếu nhập

        public bool ThemCTPN(string malohdmua,string mahdmua,string mahang, string makhohang, int soluong,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdmua,mahdmua,mahang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                ChiTietPhieuNhap CTPN = new ChiTietPhieuNhap();
                CTPN.MaLoHDMua = malohdmua;
                CTPN.MaHDMua = mahdmua;
                CTPN.MaHang = mahang;
                CTPN.MaKhoHang = makhohang;
                CTPN.SoLuong = soluong;
                CTPN.NgayLap = ngaylap;
                CTPN.NguoiLap = nguoilap;
                CTPN.NgaySua = ngaysua;
                CTPN.NguoiSua = nguoisua;
                QLKT.ChiTietPhieuNhaps.InsertOnSubmit(CTPN);
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
        public bool SuaCTPN(string malohdmua,string mahdmua,string mahang,ChiTietPhieuNhap CTPN)
        {
            try
            {
                ChiTietPhieuNhap ctpn = QLKT.ChiTietPhieuNhaps.Single(_ctpn => _ctpn.MaLoHDMua == malohdmua && _ctpn.MaHDMua==mahdmua && _ctpn.MaHang==mahang);
                ctpn.MaKhoHang = CTPN.MaKhoHang;
                ctpn.SoLuong = CTPN.SoLuong;
                ctpn.NgayLap = CTPN.NgayLap;
                ctpn.NguoiLap = CTPN.NguoiLap;
                ctpn.NgaySua = CTPN.NgaySua;
                ctpn.NguoiSua = CTPN.NguoiSua;
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

        public bool XoaCTPN(string malohdmua,string mahdmua,string mahang)
        {
            try
            {
                var delete = from ctpn in QLKT.ChiTietPhieuNhaps
                             where ctpn.MaLoHDMua == malohdmua && ctpn.MaHDMua==mahdmua && ctpn.MaHang==mahang
                             select ctpn;
                if (delete.Count() > 0)
                {
                    QLKT.ChiTietPhieuNhaps.DeleteOnSubmit(delete.First());
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
        public void CapNhatLaiKhoChuaKhiXoaCTPN(string mahang, int soluong)
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
            sl_khochua -= soluong;
            //Cập nhật kho chứa
            try
            {
                KhoChua khochua = QLKT.KhoChuas.Single(_kc => _kc.MaHang == mahang);
                khochua.SL = sl_khochua;
                QLKT.SubmitChanges();
                MessageBox.Show("Số lượng Hàng " + mahang + "  bị xóa khỏi kho: " + soluong.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
