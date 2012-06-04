using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Loai_Phieu_Thu
    {
        public string maloaiphieuthu { get; set; }
        public string tenloaiphieuthu { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoaiPhieuThuBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Loai_Phieu_Thu> LayDanhSachLoaiPhieuThu()
        {
            var sql = (from lpt in QLKT.LoaiPhieuThus
                       select new Loai_Phieu_Thu
                       {
                           maloaiphieuthu = lpt.MaLoaiPhieuThu,
                           tenloaiphieuthu = lpt.TenLoaiPhieuThu,
                           ngaylap = Convert.ToDateTime(lpt.NgayLap == null ? DateTime.Today : lpt.NgayLap),
                           nguoilap = lpt.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpt.NgaySua == null ? DateTime.Today : lpt.NgaySua),
                           nguoisua = lpt.NguoiSua,
                       }).ToList<Loai_Phieu_Thu>();
            return sql;
        }
        //Kiểm tra 1 Loại Phiếu Nhập có trong csdl chưa
        private bool KiemTraLoaiPhieuThu(string maloaiphieuthu)
        {
            var sql = from lpt in QLKT.LoaiPhieuThus
                      where lpt.MaLoaiPhieuThu == maloaiphieuthu
                      select lpt;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Thao tác Thêm-Xóa-Sửa
        public void ThemLoaiPhieuThu(string maloaiphieuthu, string tenloaiphieuthu,DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraLoaiPhieuThu(maloaiphieuthu) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoaiPhieuThu LPT = new LoaiPhieuThu();
                LPT.MaLoaiPhieuThu = maloaiphieuthu;
                LPT.TenLoaiPhieuThu = tenloaiphieuthu;
                LPT.NgayLap = ngaylap;
                LPT.NguoiLap = nguoilap;
                LPT.NgaySua = ngaysua;
                LPT.NguoiSua = nguoisua;
                QLKT.LoaiPhieuThus.InsertOnSubmit(LPT);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoaiPhieuThu(string maloaiphieuthu,LoaiPhieuThu LPT)
        {
            try
            {
                LoaiPhieuThu lpt = QLKT.LoaiPhieuThus.Single(_lpt => _lpt.MaLoaiPhieuThu == maloaiphieuthu);
                lpt.TenLoaiPhieuThu = LPT.TenLoaiPhieuThu;
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
        private bool KiemTraLoaiPhieuThuTrongPhieuThu(string maloaiphieuthu)
        {
            var sql=from pn in QLKT.PhieuThus
                    where pn.MaLoaiPhieuThu==maloaiphieuthu
                    select pn;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaLoaiPhieuThu(string maloaiphieuthu)
        {
            if (KiemTraLoaiPhieuThuTrongPhieuThu(maloaiphieuthu) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpt in QLKT.LoaiPhieuThus
                             where lpt.MaLoaiPhieuThu == maloaiphieuthu
                             select lpt;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiPhieuThus.DeleteOnSubmit(delete.First());
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
