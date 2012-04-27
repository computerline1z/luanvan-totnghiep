using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class NhaCungCapHang
    {
        public string MaNCC { get; set; }
        public string MaLoaiHang { get; set; }
        public string TenNCC { get; set; }
        public string DCNCC { get; set; }
        public string MaTinh { get; set; }
        public string SoDT { get; set; }
        public string SoFax { get; set; }
        public string Email { get; set; }
        //public DateTime NgayLap { get; set; }
        //public string NguoiLap { get; set; }
        //public DateTime NgaySua { get; set; }
        //public string NguoiSua { get; set; }
    }
    class NhaCungCapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Load danh sách mã tỉnh
        public IQueryable LoadDanhSachMaTinh()
        {
            var t = from tinh in QLKT.TinhThanhs
                    select new { tinh.MaTinh };
            return t;
        }
        public List<NhaCungCapHang> LayDanhSachNCC()
        {
            var nhacungcap = (from ncc in QLKT.NhaCungCaps
                              select new NhaCungCapHang
                              {
                                  MaNCC = ncc.MaNCC,
                                  MaLoaiHang = ncc.MaLoaiHang,
                                  TenNCC = ncc.TenNCC,
                                  DCNCC = ncc.DCNCC,
                                  MaTinh = ncc.MaTinh,
                                  SoDT = ncc.SoDT,
                                  SoFax = ncc.SoFax,
                                  Email = ncc.Email,
                              }).ToList<NhaCungCapHang>();
            return nhacungcap;
        }
        //Kiểm tra 1 nhà cung cấp cung cấp mã loại hàng hay chưa-phục vụ cho việc Insert,Update
        private bool KiemtraLoaiHang(string mancc, string maloaihang)
        {
            var nhacungcap = from ncc in QLKT.NhaCungCaps
                             where ncc.MaNCC == mancc && ncc.MaLoaiHang == maloaihang
                             select ncc;
            if (nhacungcap.Count() > 0)
                return true;
            else
                return false;
        }
        //Kiem tra hàng thuộc loại hàng do 1 nhà cung cấp cung cấp-phục vụ cho việc Delete
        private bool KiemTraHang(string maloaihang, string mancc)
        {
            var h = from hang in QLKT.Hangs
                    where ((hang.MaLoaiHang == maloaihang) && (hang.MaNCC == mancc))
                    select hang;
            if (h.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm một nhà cung cấp
        public void ThemNCC(string mancc, string maloaihang, string tenncc, string dcncc, string matinh, string sodt, string sofax, string email)
        {
            if (KiemtraLoaiHang(mancc, maloaihang) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                NhaCungCap NCCH = new NhaCungCap();
                NCCH.MaNCC = mancc;
                NCCH.MaLoaiHang = maloaihang;
                NCCH.TenNCC = tenncc;
                NCCH.DCNCC = dcncc;
                NCCH.MaTinh = matinh;
                NCCH.SoDT = sodt;
                NCCH.SoFax = sofax;
                NCCH.Email = email;
                QLKT.NhaCungCaps.InsertOnSubmit(NCCH);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Sửa 1 nhà cung cấp
        public void SuaNCC(string mancc, string maloaihang, NhaCungCap NCC)
        {
            try
            {
                NhaCungCap ncc = QLKT.NhaCungCaps.Single(nhacungcap => nhacungcap.MaLoaiHang == maloaihang && nhacungcap.MaNCC == mancc);
                ncc.TenNCC = NCC.TenNCC;
                ncc.DCNCC = ncc.DCNCC;
                ncc.MaTinh = NCC.MaTinh;
                ncc.SoDT = NCC.SoDT;
                ncc.SoFax = NCC.SoFax;
                ncc.Email = NCC.Email;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Xóa nhà cung cấp
        public void XoaNCC(string mancc, string maloaihang)
        {
            if (KiemTraHang(maloaihang, mancc) == true)
            {
                MessageBox.Show("Không thể xóa dòng dữ liệu này-Liên quan đến dữ liệu hàng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var delete = from ncc in QLKT.NhaCungCaps
                             where ncc.MaNCC == mancc && ncc.MaLoaiHang == maloaihang
                             select ncc;
                if (delete.Count() > 0)
                {
                    QLKT.NhaCungCaps.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Các Hàm phục vụ cho việc tìm kiếm
        public IQueryable LayDanhSachMNCC()
        {
            var ncc = from nhacungcap in QLKT.NhaCungCaps
                      select new { nhacungcap.MaNCC };
            return ncc.Distinct();
        }
        public List<NhaCungCapHang> LayDanhSachNhaCungCapTheoMa(string mancc)
        {
            var nhacungcap = (from ncc in QLKT.NhaCungCaps
                              where ncc.MaNCC == mancc
                              select new NhaCungCapHang
                              {
                                  MaNCC = ncc.MaNCC,
                                  MaLoaiHang = ncc.MaLoaiHang,
                                  TenNCC = ncc.TenNCC,
                                  DCNCC = ncc.DCNCC,
                                  MaTinh = ncc.MaTinh,
                                  SoDT = ncc.SoDT,
                                  SoFax = ncc.SoFax,
                                  Email = ncc.Email,
                              }).ToList<NhaCungCapHang>();
            return nhacungcap;
        }
        public List<NhaCungCapHang> LayDanhSachNhaCungCapTheoTen(string tenncc)
        {
            var nhacungcap = (from ncc in QLKT.NhaCungCaps
                              where ncc.TenNCC.Contains(tenncc)
                              select new NhaCungCapHang
                              {
                                  MaNCC = ncc.MaNCC,
                                  MaLoaiHang = ncc.MaLoaiHang,
                                  TenNCC = ncc.TenNCC,
                                  DCNCC = ncc.DCNCC,
                                  MaTinh = ncc.MaTinh,
                                  SoDT = ncc.SoDT,
                                  SoFax = ncc.SoFax,
                                  Email = ncc.Email,
                              }).ToList<NhaCungCapHang>();
            return nhacungcap;
        }
    }
}
