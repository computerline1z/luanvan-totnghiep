using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Lo_Phieu_Chi
    {
        public string malohdmua { get; set; }
        public DateTime ngaylochi { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoPhieuChiBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy dữ liệu cho Treeview
        public IQueryable LayDanhSachMaLoChi()
        {
            var sql = from lochi in QLKT.LoPhieuChis
                     select new {lochi.MaLoHDMua,lochi.NgayLoChi.Value.Date,lochi.MoTa,};
            return sql;
        }
        //Lấy mã lô hóa đơn cho combobox
        public IQueryable LayMaLoHDMua()
        {
            var sql = from lohdmua in QLKT.LoHDMuas
                      select new { lohdmua.MaLoHDMua };
            return sql;
        }
        public List<Lo_Phieu_Chi> LayDanhSachLoPhieuChi()
        {
            var sql = (from lpc in QLKT.LoPhieuChis
                       select new Lo_Phieu_Chi
                       {
                           malohdmua = lpc.MaLoHDMua,
                           ngaylochi = Convert.ToDateTime(lpc.NgayLoChi),
                           mota = lpc.MoTa,
                           ngaylap = Convert.ToDateTime(lpc.NgayLap == null ? DateTime.Today : lpc.NgayLap),
                           nguoilap = lpc.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpc.NgaySua == null ? DateTime.Today : lpc.NgaySua),
                           nguoisua = lpc.NguoiSua,
                       }).ToList<Lo_Phieu_Chi>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdmua)
        {
            var sql=from lpc in QLKT.LoPhieuChis
                    where lpc.MaLoHDMua==malohdmua
                    select lpc;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        //Thêm-xóa-sửa
        public void ThemLoPC(string malohdmua,DateTime ngaylochi, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdmua) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoPhieuChi LPC = new LoPhieuChi();
                LPC.MaLoHDMua = malohdmua;
                LPC.NgayLoChi = ngaylochi;
                LPC.MoTa = mota;
                LPC.NgayLap = ngaylap;
                LPC.NguoiLap = nguoilap;
                LPC.NgaySua = ngaysua;
                LPC.NguoiSua = nguoisua;
                QLKT.LoPhieuChis.InsertOnSubmit(LPC);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoPC(string malohdmua,LoPhieuChi LPC)
        {
            try
            {
                LoPhieuChi lpc = QLKT.LoPhieuChis.Single(_lpc => _lpc.MaLoHDMua== malohdmua);
                lpc.NgayLoChi = LPC.NgayLoChi;
                lpc.MoTa = LPC.MoTa;
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

        private bool KiemTraLoPhieuChiTrongPhieuChi(string malohdmua)
        {
            var sql = from lpc in QLKT.PhieuChis
                      where lpc.MaLoHDMua == malohdmua
                      select lpc;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }

        public void XoaLPC(string malohdmua)
        {
            if (KiemTraLoPhieuChiTrongPhieuChi(malohdmua) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpc in QLKT.LoPhieuChis
                             where lpc.MaLoHDMua == malohdmua
                             select lpc;
                if (delete.Count() > 0)
                {
                    QLKT.LoPhieuChis.DeleteOnSubmit(delete.First());
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
