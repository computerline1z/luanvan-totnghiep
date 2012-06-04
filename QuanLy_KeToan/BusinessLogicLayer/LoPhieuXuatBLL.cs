using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Lo_Phieu_Xuat
    {
        public string malohdban { get; set; }
        public DateTime ngayloxuat { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoPhieuXuatBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy dữ liệu cho Treeview
        public IQueryable LayDanhSachMaLoHDBan()
        {
            var sql = from loxuat in QLKT.LoPhieuXuats
                      select new { loxuat.MaLoHDBan, loxuat.NgayLoXuat.Value.Date, loxuat.MoTa, };
            return sql;
        }
        //Lấy mã lô hóa đơn cho combobox
        public IQueryable LayMaLoHDBan()
        {
            var sql = from lohdban in QLKT.LoHDBans
                      select new { lohdban.MaLoHDBan };
            return sql;
        }
        public List<Lo_Phieu_Xuat> LayDanhSachLoPhieuXuat()
        {
                var sql = (from lpx in QLKT.LoPhieuXuats
                           select new Lo_Phieu_Xuat
                           {
                               malohdban=lpx.MaLoHDBan,
                               ngayloxuat = System.Convert.ToDateTime(lpx.NgayLoXuat),
                               mota = lpx.MoTa,
                               ngaylap = Convert.ToDateTime(lpx.NgayLap == null ? DateTime.Today : lpx.NgayLap),
                               nguoilap = lpx.NguoiLap,
                               ngaysua = Convert.ToDateTime(lpx.NgaySua == null ? DateTime.Today : lpx.NgaySua),
                               nguoisua = lpx.NguoiSua,
                           }).ToList<Lo_Phieu_Xuat>();
            return sql;
        }
            
        private bool KiemTraDulieu(string malohdban)
        {
            var sql = from lpx in QLKT.LoPhieuXuats
                      where lpx.MaLoHDBan == malohdban
                      select lpx;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        //Thêm-xóa-sửa
        public void ThemLoPX(string malohdban,DateTime ngayloxuat, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdban) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoPhieuXuat LPX = new LoPhieuXuat();
                LPX.MaLoHDBan = malohdban;
                LPX.NgayLoXuat = ngayloxuat;
                LPX.MoTa = mota;
                LPX.NgayLap = ngaylap;
                LPX.NguoiLap = nguoilap;
                LPX.NgaySua = ngaysua;
                LPX.NguoiSua = nguoisua;
                QLKT.LoPhieuXuats.InsertOnSubmit(LPX);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoPX(string malohdban, LoPhieuXuat LPX)
        {
            try
            {
                LoPhieuXuat lpx = QLKT.LoPhieuXuats.Single(_lpx => _lpx.MaLoHDBan == malohdban);
                lpx.NgayLoXuat = LPX.NgayLoXuat;
                lpx.MoTa = LPX.MoTa;
                lpx.NgayLap = LPX.NgayLap;
                lpx.NguoiLap = LPX.NguoiLap;
                lpx.NgaySua = LPX.NgaySua;
                lpx.NguoiSua = LPX.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KiemTraLoPhieuXuatTrongPhieuXuat(string malohdban)
        {
            var sql = from lpx in QLKT.PhieuXuats
                      where lpx.MaLoHDBan == malohdban
                      select lpx;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaLPX(string malohdban)
        {
            if (KiemTraLoPhieuXuatTrongPhieuXuat(malohdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Xuất", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpx in QLKT.LoPhieuXuats
                             where lpx.MaLoHDBan==malohdban
                             select lpx;
                if (delete.Count() > 0)
                {
                    QLKT.LoPhieuXuats.DeleteOnSubmit(delete.First());
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
