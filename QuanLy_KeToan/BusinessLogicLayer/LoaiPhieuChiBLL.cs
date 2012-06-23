using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Loai_Phieu_Chi
    {
        public string maloaiphieuchi { get; set; }
        public string tenloaiphieuchi { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoaiPhieuChiBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Loai_Phieu_Chi> LayDanhSachLoaiPhieuChi()
        {
            var sql = (from lpc in QLKT.LoaiPhieuChis
                       select new Loai_Phieu_Chi
                       {
                           maloaiphieuchi = lpc.MaLoaiPhieuChi,
                           tenloaiphieuchi = lpc.TenLoaiPhieuChi,
                           ngaylap = Convert.ToDateTime(lpc.NgayLap == null ? DateTime.Today : lpc.NgayLap),
                           nguoilap = lpc.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpc.NgaySua == null ? DateTime.Today : lpc.NgaySua),
                           nguoisua = lpc.NguoiSua,
                       }).ToList<Loai_Phieu_Chi>();
            return sql;
        }
        //Kiểm tra 1 Loại Phiếu Nhập có trong csdl chưa
        private bool KiemTraLoaiPhieuChi(string maloaiphieuchi)
        {
            var sql = from lpc in QLKT.LoaiPhieuChis
                      where lpc.MaLoaiPhieuChi == maloaiphieuchi
                      select lpc;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Thao tác Thêm-Xóa-Sửa
        public void ThemLoaiPhieuChi(string maloaiphieuchi, string tenloaiphieuchi,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraLoaiPhieuChi(maloaiphieuchi) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoaiPhieuChi LPC = new LoaiPhieuChi();
                LPC.MaLoaiPhieuChi = maloaiphieuchi;
                LPC.TenLoaiPhieuChi = tenloaiphieuchi;
                LPC.NgayLap = ngaylap;
                LPC.NguoiLap = nguoilap;
                LPC.NgaySua = ngaysua;
                LPC.NguoiSua = nguoisua;
                QLKT.LoaiPhieuChis.InsertOnSubmit(LPC);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoaiPhieuChi(string maloaiphieuchi,LoaiPhieuChi LPC)
        {
            try
            {
                LoaiPhieuChi lpc = QLKT.LoaiPhieuChis.Single(_lpc => _lpc.MaLoaiPhieuChi == maloaiphieuchi);
                lpc.TenLoaiPhieuChi = LPC.TenLoaiPhieuChi;
                lpc.NgayLap = LPC.NgayLap;
                lpc.NguoiLap = LPC.NguoiLap;
                lpc.NgaySua = LPC.NgaySua;
                lpc.NguoiSua = LPC.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraLoaiPhieuChiTrongPhieuChi(string maloaiphieuchi)
        {
            var sql=from pn in QLKT.PhieuChis
                    where pn.MaLoaiPhieuChi==maloaiphieuchi
                    select pn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaLoaiPhieuChi(string maloaiphieuchi)
        {
            if (KiemTraLoaiPhieuChiTrongPhieuChi(maloaiphieuchi) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpc in QLKT.LoaiPhieuChis
                             where lpc.MaLoaiPhieuChi == maloaiphieuchi
                             select lpc;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiPhieuChis.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
