using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class NuocClass
    {
        public string manuoc { get; set; }
        public string tennuoc { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class NuocBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy danh sách nước
        public List<NuocClass> LayDanhSachNuoc()
        {
            var nuoc = (from n in QLKT.Nuocs
                        select new NuocClass
                        {
                            manuoc = n.MaNuoc,
                            tennuoc = n.TenNuoc,
                            NgayLap = Convert.ToDateTime(n.NgayLap==null?DateTime.Today:n.NgayLap),
                            NguoiLap = n.NguoiLap,
                            NgaySua = Convert.ToDateTime(n.NgaySua == null ? DateTime.Today : n.NgaySua),
                            NguoiSua = n.NguoiSua
                        }).ToList<NuocClass>();
            return nuoc;
        }
        //Kiểm tra có 1 Nước có trong csdl chưa
        private bool KiemTraNuoc(string manuoc)
        {
            var nuoc = from n in QLKT.Nuocs
                       where n.MaNuoc == manuoc
                       select n;
            if (nuoc.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm Nước
        public void ThemNuoc(string manuoc, string tennuoc, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraNuoc(manuoc) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Nuoc N = new Nuoc();
                N.MaNuoc = manuoc;
                N.TenNuoc = tennuoc;
                N.NgayLap = ngaylap;
                N.NguoiLap = nguoilap;
                N.NgaySua = ngaysua;
                N.NguoiSua = nguoisua;
                QLKT.Nuocs.InsertOnSubmit(N);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void XoaNuoc(string manuoc)
        {
            try
            {
                var ktra = from tinh in QLKT.TinhThanhs
                           where tinh.MaNuoc == manuoc
                           select tinh;
                if (ktra.Count() > 0)
                {
                    MessageBox.Show("Bạn không thể xóa Nước này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    var delete = from _nuoc in QLKT.Nuocs
                                 where _nuoc.MaNuoc == manuoc
                                 select _nuoc;
                    if (delete.Count() > 0)
                    {
                        QLKT.Nuocs.DeleteOnSubmit(delete.First());
                        QLKT.SubmitChanges();
                        MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SuaNuoc(string manuoc, Nuoc N)
        {
            try
            {
                Nuoc nuoc = QLKT.Nuocs.Single(_n => _n.MaNuoc == manuoc);
                nuoc.TenNuoc = N.TenNuoc;
                nuoc.NgayLap = N.NgayLap;
                nuoc.NguoiLap = N.NguoiLap;
                nuoc.NgaySua = N.NgaySua;
                nuoc.NguoiSua = N.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Cac hàm phục vụ cho việc tìm kiếm

        public IQueryable LayDanhSachMaNuoc()
        {
            var nuoc = from n in QLKT.Nuocs
                       select new
                       {
                           n.MaNuoc,
                           n.TenNuoc,
                       };
            return nuoc;
        }

        public List<NuocClass> LayNuocTheoMaNuoc(string manuoc)
        {
            var nuoc= (from n in QLKT.Nuocs
                            where n.MaNuoc == manuoc
                            select new NuocClass
                            {
                                manuoc = n.MaNuoc,
                                tennuoc = n.TenNuoc,
                                NgayLap = Convert.ToDateTime(n.NgayLap == null ? DateTime.Today : n.NgayLap),
                                NguoiLap = n.NguoiLap,
                                NgaySua = Convert.ToDateTime(n.NgaySua == null ? DateTime.Today : n.NgaySua),
                                NguoiSua = n.NguoiSua
                            }).ToList<NuocClass>();
            return nuoc;
        }
        public List<NuocClass> LayNuocTheoTenNuoc(string tennuoc)
        {
            var nuoc = (from n in QLKT.Nuocs
                            where n.TenNuoc.Contains(tennuoc)
                            select new NuocClass
                            {
                                manuoc = n.MaNuoc,
                                tennuoc=n.TenNuoc,
                                NgayLap = Convert.ToDateTime(n.NgayLap == null ? DateTime.Today : n.NgayLap),
                                NguoiLap = n.NguoiLap,
                                NgaySua = Convert.ToDateTime(n.NgaySua == null ? DateTime.Today : n.NgaySua),
                                NguoiSua = n.NguoiSua
                            }).ToList<NuocClass>();
            return nuoc;
        }
    }
}
