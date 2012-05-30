using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;
namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Chi_Tiet_Phieu_Xuat
    {
        public string maphieuxuat { get; set; }
        public string maloxuat { get; set; }
        public string mahang { get; set; }
        public string makhohang { get; set; }
        public int soluong { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class ChiTietPhieuXuatBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        public IQueryable LayMaHang(string maphieuxuat)
        {
            var sql = from hang in QLKT.Hangs
                      from pn in QLKT.PhieuXuats
                      from lpn in QLKT.LoPhieuXuats
                      where hang.MaLoaiHang==lpn.MaLoaiHang && lpn.MaLoXuat==pn.MaLoXuat && pn.MaPhieuXuat == maphieuxuat
                      select new
                      {
                          hang.MaHang,
                          hang.TenHang,
                      };
            return sql;
        }
        public IQueryable LayKhoHang(string maphieuxuat)
        {
            var sql = from kh in QLKT.KhoHangs
                      from pn in QLKT.PhieuXuats
                      from lpn in QLKT.LoPhieuXuats
                      where pn.MaLoXuat==lpn.MaLoXuat && lpn.MaLoaiHang==kh.MaLoaiHang && pn.MaPhieuXuat == maphieuxuat
                      select new { kh.MaKhoHang, kh.TenKhoHang, };
            return sql;
        }
        public IQueryable LayMaKH(string maphieuxuat)
        {
            var sql = from kh in QLKT.KhoHangs
                      from pn in QLKT.PhieuXuats
                      from lpn in QLKT.LoPhieuXuats
                      where pn.MaLoXuat == lpn.MaLoXuat && lpn.MaLoaiHang == kh.MaLoaiHang && pn.MaPhieuXuat == maphieuxuat
                      select kh.MaKhoHang;
            return sql;
        }
        public List<Chi_Tiet_Phieu_Xuat> LayChiTietPhieuXuatTheoMaPhieuXuat(string maphieuxuat)
        {
            var sql = (from ctpx in QLKT.ChiTietPhieuXuats
                       where ctpx.MaPhieuXuat == maphieuxuat
                       select new Chi_Tiet_Phieu_Xuat
                       {
                           maphieuxuat = ctpx.MaPhieuXuat,
                           maloxuat=ctpx.MaLoXuat,
                           mahang = ctpx.MaHang,
                           makhohang = ctpx.MaKhoHang,
                           soluong = System.Convert.ToInt16(ctpx.SoLuong.Value != null ? ctpx.SoLuong : 0),
                           ngaylap = Convert.ToDateTime(ctpx.NgayLap == null ? DateTime.Today : ctpx.NgayLap),
                           nguoilap = ctpx.NguoiLap,
                           ngaysua = Convert.ToDateTime(ctpx.NgaySua == null ? DateTime.Today : ctpx.NgaySua),
                           nguoisua = ctpx.NguoiSua,
                       }).ToList<Chi_Tiet_Phieu_Xuat>();
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
            int sl_ctpx = 0;
            var ctpx = from _ctpx in QLKT.ChiTietPhieuXuats
                       where _ctpx.MaHang == mahang
                       select _ctpx.SoLuong;
            if (ctpx.Count() > 0)
            {
                foreach (var item in ctpx)
                {
                    sl_ctpx = System.Convert.ToInt16(item);
                }
            }
            if (sl_ctpx > sl_khochua)
            {
                MessageBox.Show("Số lượng Hàng xuất lớn hơn số lượng hiện có trong kho", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sl_khochua -= sl_ctpx;
            //MessageBox.Show(sl_khochua.ToString());
            try
            {
                KhoChua khochua = QLKT.KhoChuas.Single(_kc => _kc.MaHang == mahang);
                khochua.SL = sl_khochua;
                QLKT.SubmitChanges();
                MessageBox.Show("Cập nhật số lượng: " + mahang + " vào kho chứa " + makhohang + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Số lượng Hàng " + mahang + " giảm đi " + sl_ctpx.ToString() + Environment.NewLine +
                                "Số lượng Hàng " + mahang + " hiện có " + sl_khochua.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void CapNhatLaiKhoChua(string mahang, string makhohang,int soluongmoi)
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
            int sl_ctpx = 0;
            var ctpx = from _ctpx in QLKT.ChiTietPhieuXuats
                       where _ctpx.MaHang == mahang
                       select _ctpx.SoLuong;
            if (ctpx.Count() > 0)
            {
                foreach (var item in ctpx)
                {
                    sl_ctpx = System.Convert.ToInt16(item);
                }
            }
            int update = soluongmoi - sl_ctpx;
            sl_khochua -= update;
            //Cập nhật chi tiết phiếu xuất
            try
            {
                ChiTietPhieuXuat chitietpx = QLKT.ChiTietPhieuXuats.Single(_chitietpx => _chitietpx.MaHang == mahang);
                chitietpx.SoLuong = soluongmoi;
                QLKT.SubmitChanges();
                if (update > 0)
                    MessageBox.Show("Số lượng Hàng " + mahang + " xuất thêm khỏi kho: " + update.ToString() + Environment.NewLine +
                                    "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString());
                else if (update == 0)
                    MessageBox.Show("Số lượng Hàng " + mahang + " giữ nguyên" + Environment.NewLine +
                                    "Số lượng Hàng " + mahang + " hiện tại là:" + sl_khochua.ToString());
                else
                    MessageBox.Show("Số lượng Hàng " + mahang + " xuất ra giảm bớt: " + update.ToString() + Environment.NewLine +
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

        private bool KiemTraDulieu(string maphieuxuat,string maloxuat,string mahang)
        {
            var sql = from ctpx in QLKT.ChiTietPhieuXuats
                      where ctpx.MaPhieuXuat == maphieuxuat && ctpx.MaLoXuat==maloxuat && ctpx.MaHang==mahang
                      select ctpx;
            if (sql.Count() > 0)
                return true;
            else return false;
        }

        //Code Thêm-Xóa-Sửa Chi tiết phiếu xuất

        public bool ThemCTPX(string maphieuxuat,string maloxuat,string mahang, string makhohang, int soluong,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(maphieuxuat,maloxuat,mahang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                ChiTietPhieuXuat CTPX = new ChiTietPhieuXuat();
                CTPX.MaPhieuXuat = maphieuxuat;
                CTPX.MaLoXuat = maloxuat;
                CTPX.MaHang = mahang;
                CTPX.MaKhoHang = makhohang;
                CTPX.SoLuong = soluong;
                CTPX.NgayLap = ngaylap;
                CTPX.NguoiLap = nguoilap;
                CTPX.NgaySua = ngaysua;
                CTPX.NguoiSua = nguoisua;
                QLKT.ChiTietPhieuXuats.InsertOnSubmit(CTPX);
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
        public bool SuaCTPX(string maphieuxuat,string maloxuat,string mahang,ChiTietPhieuXuat CTPX)
        {
            try
            {
                ChiTietPhieuXuat ctpx = QLKT.ChiTietPhieuXuats.Single(_ctpx => _ctpx.MaPhieuXuat == maphieuxuat && _ctpx.MaLoXuat==maloxuat && _ctpx.MaHang==mahang);
                ctpx.MaKhoHang = CTPX.MaKhoHang;
                ctpx.SoLuong = CTPX.SoLuong;
                ctpx.NgayLap = CTPX.NgayLap;
                ctpx.NguoiLap = CTPX.NguoiLap;
                ctpx.NgaySua = CTPX.NgaySua;
                ctpx.NguoiSua = CTPX.NguoiSua;
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

        public bool XoaCTPX(string maphieuxuat,string maloxuat,string mahang)
        {
            try
            {
                var delete = from ctpx in QLKT.ChiTietPhieuXuats
                             where ctpx.MaPhieuXuat == maphieuxuat && ctpx.MaLoXuat==maloxuat && ctpx.MaHang==mahang
                             select ctpx;
                if (delete.Count() > 0)
                {
                    QLKT.ChiTietPhieuXuats.DeleteOnSubmit(delete.First());
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
        public void CapNhatLaiKhoChuaKhiXoaCTPX(string mahang,string makhohang, int soluong)
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
            sl_khochua += soluong;
            //Cập nhật kho chứa
            try
            {
                KhoChua khochua = QLKT.KhoChuas.Single(_kc => _kc.MaHang == mahang);
                khochua.SL = sl_khochua;
                QLKT.SubmitChanges();
                MessageBox.Show("Số lượng Hàng " + mahang + "  được phục hồi lại " + soluong.ToString()+Environment.NewLine+
                                "Số lượng Hàng hiện tại "+sl_khochua.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
