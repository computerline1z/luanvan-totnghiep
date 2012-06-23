using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Lo_Phieu_Thu
    {
        public string malohdban { get; set; }
        public DateTime ngaylothu { get; set; }
        public string mota { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoPhieuThuBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy dữ liệu cho Treeview
        public IQueryable LayDanhSachMaLoThu()
        {
            var sql = from lothu in QLKT.LoPhieuThus
                     select new {lothu.MaLoHDBan,lothu.NgayLoThu.Value.Date,lothu.MoTa,};
            return sql;
        }
        //Lấy mã lô hóa đơn cho combobox
        public IQueryable LayMaLoHDBan()
        {
            var sql = from lohdban in QLKT.LoHDBans
                      select new { lohdban.MaLoHDBan };
            return sql;
        }
        public List<Lo_Phieu_Thu> LayDanhSachLoPhieuThu()
        {
            var sql = (from lpt in QLKT.LoPhieuThus
                       select new Lo_Phieu_Thu
                       {
                           malohdban = lpt.MaLoHDBan,
                           ngaylothu = Convert.ToDateTime(lpt.NgayLoThu),
                           mota = lpt.MoTa,
                           ngaylap = Convert.ToDateTime(lpt.NgayLap == null ? DateTime.Today : lpt.NgayLap),
                           nguoilap = lpt.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpt.NgaySua == null ? DateTime.Today : lpt.NgaySua),
                           nguoisua = lpt.NguoiSua,
                       }).ToList<Lo_Phieu_Thu>();
            return sql;
        }
        private bool KiemTraDulieu(string malohdban)
        {
            var sql=from lpt in QLKT.LoPhieuThus
                    where lpt.MaLoHDBan==malohdban
                    select lpt;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        //Thêm-xóa-sửa
        public void ThemLoPT(string malohdban,DateTime ngaylothu, string mota, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(malohdban) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoPhieuThu LPT = new LoPhieuThu();
                LPT.MaLoHDBan = malohdban;
                LPT.NgayLoThu = ngaylothu;
                LPT.MoTa = mota;
                LPT.NgayLap = ngaylap;
                LPT.NguoiLap = nguoilap;
                LPT.NgaySua = ngaysua;
                LPT.NguoiSua = nguoisua;
                QLKT.LoPhieuThus.InsertOnSubmit(LPT);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoPT(string malohdban,LoPhieuThu LPT)
        {
            try
            {
                LoPhieuThu lpt = QLKT.LoPhieuThus.Single(_lpt => _lpt.MaLoHDBan== malohdban);
                lpt.NgayLoThu = LPT.NgayLoThu;
                lpt.MoTa = LPT.MoTa;
                lpt.NgayLap = LPT.NgayLap;
                lpt.NguoiLap = LPT.NguoiLap;
                lpt.NgaySua = LPT.NgaySua;
                lpt.NguoiSua = LPT.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool KiemTraLoPhieuThuTrongPhieuThu(string malohdban)
        {
            var sql = from lpt in QLKT.PhieuThus
                      where lpt.MaLoHDBan == malohdban
                      select lpt;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }

        public void XoaLPT(string malohdban)
        {
            if (KiemTraLoPhieuThuTrongPhieuThu(malohdban) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpt in QLKT.LoPhieuThus
                             where lpt.MaLoHDBan == malohdban
                             select lpt;
                if (delete.Count() > 0)
                {
                    QLKT.LoPhieuThus.DeleteOnSubmit(delete.First());
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
