using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Tinh
    {
        public string matinh { get; set; }
        public string tentinh { get; set; }
        public string manuoc { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class TinhThanhBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        public IQueryable LayTinh()
        {
            var tinh = from t in QLKT.TinhThanhs
                       select new { t.MaTinh, t.TenTinh, };
            return tinh;
        }
        //Lấy Danh Sách Tỉnh Thành
        public List<Tinh> LoadDanhSachTinhThanhTheoMaNuoc(string manuoc)
        {
            var tinh = (from t in QLKT.TinhThanhs  //Hoặc from h in QLKT.GetTable<TinhThanhs>() 
                        where t.MaNuoc==manuoc
                        select new Tinh
                        {
                            matinh=t.MaTinh,
                            tentinh=t.TenTinh,
                            manuoc=t.MaNuoc,
                            NgayLap = Convert.ToDateTime(t.NgayLap == null ? DateTime.Today : t.NgayLap),
                            NguoiLap = t.NguoiLap,
                            NgaySua = Convert.ToDateTime(t.NgaySua == null ? DateTime.Today : t.NgaySua),
                            NguoiSua = t.NguoiSua
                        }).ToList<Tinh>();
            return tinh;
        }
        //Kiểm tra 1 nhà cung cấp cung cấp thuộc tỉnh thành không?
        private bool KiemtraNCC(string matinh)
        {
            var nhacungcap = from ncc in QLKT.NhaCungCaps
                             where ncc.MaTinh == matinh
                             select ncc;
            if (nhacungcap.Count() > 0)
                return true;
            else
                return false;
        }
        //Kiểm tra có 1 tỉnh có trong csdl chưa
        private bool KiemTraTinhThanh(string matinh)
        {
            var tinh = from t in QLKT.TinhThanhs
                       where t.MaTinh==matinh
                       select t;
            if (tinh.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm 1 tỉnh
        public void ThemTinh(string matinh,string tentinh,string manuoc,DateTime ngaylap,string nguoilap,DateTime ngaysua,string nguoisua)
        {
            if(KiemTraTinhThanh(matinh)==true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                TinhThanh tinh = new TinhThanh();
                tinh.MaTinh = matinh;
                tinh.TenTinh = tentinh;
                tinh.MaNuoc = manuoc;
                tinh.NgayLap = ngaylap;
                tinh.NguoiLap = nguoilap;
                tinh.NgaySua=ngaysua;
                tinh.NguoiSua = nguoisua;
                QLKT.TinhThanhs.InsertOnSubmit(tinh);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void XoaTinh(string matinh)
        {
            if (KiemtraNCC(matinh) == true)
            {
                MessageBox.Show("Không thể xóa dòng này-Liên quan đến nhà cung cấp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var delete = from tinh in QLKT.TinhThanhs
                             where tinh.MaTinh == matinh
                             select tinh;
                if (delete.Count() > 0)
                {
                    QLKT.TinhThanhs.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SuaTinh(string matinh,TinhThanh _tinh)
        {
            try
            {
                TinhThanh tinh = QLKT.TinhThanhs.Single(t => t.MaTinh == matinh);
                tinh.TenTinh=_tinh.TenTinh;
                tinh.MaNuoc=_tinh.MaNuoc;
                tinh.NgayLap=_tinh.NgayLap;
                tinh.NguoiLap=_tinh.NguoiLap;
                tinh.NgaySua=_tinh.NgaySua;
                tinh.NguoiSua=_tinh.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Hàm phục vụ tìm kiếm
        public List<Tinh> LayTinhTheoMaTinh(string matinh)
        {
            var tinh = (from t in QLKT.TinhThanhs  //Hoặc from h in QLKT.GetTable<TinhThanhs>() 
                        where t.MaTinh == matinh
                        select new Tinh
                        {
                            matinh = t.MaTinh,
                            tentinh = t.TenTinh,
                            manuoc = t.MaNuoc,
                            NgayLap = Convert.ToDateTime(t.NgayLap == null ? DateTime.Today : t.NgayLap),
                            NguoiLap = t.NguoiLap,
                            NgaySua = Convert.ToDateTime(t.NgaySua == null ? DateTime.Today : t.NgaySua),
                            NguoiSua = t.NguoiSua
                        }).ToList<Tinh>();
            return tinh;
        }
        //Hàm phục vụ tìm kiếm
        public List<Tinh> LayTinhTheoTenTinh(string tentinh)
        {
            var tinh = (from t in QLKT.TinhThanhs  //Hoặc from h in QLKT.GetTable<TinhThanhs>() 
                        where t.TenTinh.Contains(tentinh)
                        select new Tinh
                        {
                            matinh = t.MaTinh,
                            tentinh = t.TenTinh,
                            manuoc = t.MaNuoc,
                            NgayLap = Convert.ToDateTime(t.NgayLap == null ? DateTime.Today : t.NgayLap),
                            NguoiLap = t.NguoiLap,
                            NgaySua = Convert.ToDateTime(t.NgaySua == null ? DateTime.Today : t.NgaySua),
                            NguoiSua = t.NguoiSua
                        }).ToList<Tinh>();
            return tinh;
        }
    }
}
