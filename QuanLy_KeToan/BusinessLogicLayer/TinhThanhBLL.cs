using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        //Lấy Danh Sách Tỉnh Thành
        public List<Tinh> LoadDanhSachTinhThanh()
        {
            var tinh = (from t in QLKT.TinhThanhs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        select new Tinh
                        {
                            matinh=t.MaTinh,
                            tentinh=t.TenTinh,
                            manuoc=t.MaNuoc,
                            NgayLap = Convert.ToDateTime(t.NgayLap),
                            NguoiLap = t.NguoiLap,
                            NgaySua = Convert.ToDateTime(t.NgaySua),
                            NguoiSua = t.NguoiSua
                        }).ToList<Tinh>();
            return tinh;
        }
        //Kiểm tra 1 nhà cung cấp cung cấp thuộc tỉnh thành không?
        private bool KiemtraNCC(string matinh)
        {
            var nhacungcap = from ncc in QLKT.NhaCungCaps
                             where ncc.MaNCC == mancc && ncc.MaLoaiHang == maloaihang
                             select ncc;
            if (nhacungcap.Count() > 0)
                return true;
            else
                return false;
        }
        //Thêm 1 tỉnh
        public void ThemTinh()
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
    }
}
