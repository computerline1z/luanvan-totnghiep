using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Loai_Phieu_Xuat
    {
        public string maloaiphieuxuat { get; set; }
        public string tenloaiphieuxuat { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class LoaiPhieuXuatBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public List<Loai_Phieu_Xuat> LayDanhSachLoaiPhieuXuat()
        {
            var sql = (from lpx in QLKT.LoaiPhieuXuats
                       select new Loai_Phieu_Xuat
                       {
                           maloaiphieuxuat = lpx.MaLoaiPhieuXuat,
                           tenloaiphieuxuat = lpx.TenLoaiPhieuXuat,
                           ngaylap = Convert.ToDateTime(lpx.NgayLap == null ? DateTime.Today : lpx.NgayLap),
                           nguoilap = lpx.NguoiLap,
                           ngaysua = Convert.ToDateTime(lpx.NgaySua == null ? DateTime.Today : lpx.NgaySua),
                           nguoisua = lpx.NguoiSua,
                       }).ToList<Loai_Phieu_Xuat>();
            return sql;
        }
        //Kiểm tra 1 Loại Phiếu Nhập có trong csdl chưa
        private bool KiemTraLoaiPhieuXuat(string maloaiphieuxuat)
        {
            var sql = from lpx in QLKT.LoaiPhieuXuats
                      where lpx.MaLoaiPhieuXuat == maloaiphieuxuat
                      select lpx;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Thao tác Thêm-Xóa-Sửa
        public void ThemLoaiPhieuXuat(string maloaiphieuxuat, string tenloaiphieuxuat, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraLoaiPhieuXuat(maloaiphieuxuat) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                LoaiPhieuXuat LPX = new LoaiPhieuXuat();
                LPX.MaLoaiPhieuXuat = maloaiphieuxuat;
                LPX.TenLoaiPhieuXuat = tenloaiphieuxuat;
                LPX.NgayLap = ngaylap;
                LPX.NguoiLap = nguoilap;
                LPX.NgaySua = ngaysua;
                LPX.NguoiSua = nguoisua;
                QLKT.LoaiPhieuXuats.InsertOnSubmit(LPX);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaLoaiPhieuXuat(string maloaiphieuxuat, LoaiPhieuXuat LPX)
        {
            try
            {
                LoaiPhieuXuat lpx = QLKT.LoaiPhieuXuats.Single(_lpx => _lpx.MaLoaiPhieuXuat == maloaiphieuxuat);
                lpx.TenLoaiPhieuXuat = LPX.TenLoaiPhieuXuat;
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
        private bool KiemTraLoaiPhieuXuatTrongPhieuXuat(string maloaiphieuxuat)
        {
            var sql = from px in QLKT.PhieuXuats
                      where px.MaLoaiPhieuXuat == maloaiphieuxuat
                      select px;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        public void XoaLoaiPhieuXuat(string maloaiphieuxuat)
        {
            if (KiemTraLoaiPhieuXuatTrongPhieuXuat(maloaiphieuxuat) == true)
            {
                MessageBox.Show("Không được xóa dữ liệu này-Liên quan đến dữ liệu Phiếu Nhập", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lpx in QLKT.LoaiPhieuXuats
                             where lpx.MaLoaiPhieuXuat == maloaiphieuxuat
                             select lpx;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiPhieuXuats.DeleteOnSubmit(delete.First());
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
