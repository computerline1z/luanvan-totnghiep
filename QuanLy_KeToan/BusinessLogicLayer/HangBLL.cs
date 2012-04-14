using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class HangHoa
    {
        public string MaLoaiHang { get; set; }
        public string MaNCC { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaDonViTinh { get; set; }
        public string MoTaHang { get; set; }
        public float VAT { get; set; }
        public float ThueNhapKhau { get; set; }
        public decimal DonGia { get; set; }
        public float GiamGia { get; set; }
        public string Hinh { get; set; }
    }
    class HangBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Kiểu IQueryable trả về kiểu object,nếu mình chỉ ra kiểu trả về luôn như IQueryabl<String> thì nó sẽ 
            // trả về kiểu String,nếu chỉ để IQueryable thì sau khi gọi hàm phải chuyển kiểu.

        //Lấy Danh Sách Tên Loại Hàng cho TreeView
        public IQueryable LayDanhSachTenLoaiHang()
        {
            var loaihang = from lh in QLKT.LoaiHangs
                           select lh.TenLoaiHang;
            return loaihang;
        }
        //Lấy Danh Sách Nhà Cung Cấp cho TreeView
        public IQueryable<String> LayDanhSachTenNCC()
        {
            var tenncc = from ncc in QLKT.NhaCungCaps
                         select ncc.TenNCC;
            return tenncc.Distinct();
        }

        //Lấy danh sách mã loại hàng hóa và tên loại hàng theo tên nhà cung cấp cho Combobox
        public IQueryable LayDanhSachLoaiHangHoa(string tenncc)
        {
            var lh = from loaihang in QLKT.LoaiHangs
                     from ncc in QLKT.NhaCungCaps
                     where(( loaihang.MaLoaiHang==ncc.MaLoaiHang)&&(ncc.TenNCC==tenncc))
                     select new
                     {
                         loaihang.MaLoaiHang,
                         loaihang.TenLoaiHang,
                     };
            return lh;
        }
        //Lấy tên nhà cung cấp theo mã nhà cung cấp
        public IQueryable LayDanhSachTenNCCTheoMaNCC(string MaNCC)
        {
            var tenncc = from ncc in QLKT.NhaCungCaps
                          where ncc.MaNCC == MaNCC
                          select ncc.TenNCC;
            return tenncc;
        } 
        //Lấy tên loại hàng theo mã loại hàng dùng trong binding control
        public IQueryable LayDanhSachTenLoaiHangTheoMaLoaiHang(string MaLoaiHang)
        {
            var tenlh = from lh in QLKT.LoaiHangs
                        where lh.MaLoaiHang == MaLoaiHang
                        select lh.TenLoaiHang;
            return tenlh;
        }
        //Lấy danh sách mã NCC và tên NCC cho Combobox
        public IQueryable LayDanhSachNCC()
        {
            var ncc = from NCC in QLKT.NhaCungCaps
                     select new
                     {
                         NCC.MaNCC,
                         NCC.TenNCC,
                     };
            return ncc.Distinct();
        }
        //Lấy Danh Sách Mã Loại Hàng cho ColMaLoaiHang
        public IQueryable LayDanhSachMaLoaiHang()
        {
            var loaihang = from lh in QLKT.LoaiHangs
                           select new { lh.MaLoaiHang };
            return loaihang.Distinct();
        }
        //Lấy Danh Sách Mã NCC cho ColMaNCC
        public IQueryable LayDanhSachMaNCC()
        {
            var ncc = from NCC in QLKT.NhaCungCaps
                      select new { NCC.MaNCC };
            return ncc.Distinct();
        }
        //Lấy Mã đơn vị tính cho combobox column donvitinh
        public IQueryable LayDanhSachMaDonViTinh()
        {
            var dvt = from DVT in QLKT.DonViTinhs
                      select new { DVT.MaDonViTinh};
            return dvt.Distinct();
        }
        //Lấy Danh Sách mã đơn vị và tên đơn vị tính cho combobox donvitinh
        public IQueryable LayDanhSachTenDonViTinh()
        {
            var donvi = from DVT in QLKT.DonViTinhs
                        select new { DVT.MaDonViTinh, DVT.TenDonViTinh ,};
            return donvi;
        }
        //Lấy tên đơn vị tính theo mã đơn vị tính
        public IQueryable LayDanhSachTenDVTinhTheoMaDVTinh(string MaDVTinh)
        {
            var tendv = from dvt in QLKT.DonViTinhs
                        where dvt.MaDonViTinh == MaDVTinh
                        select dvt.TenDonViTinh;
            return tendv;
        }
        //Lấy Danh Sách tên loại hàng theo nhà cung cấp cho treeview
        public IQueryable<String> LayDanhSachTenLoaiHangTheoNCC(string tenncc)
        {
            var tenloaihang = from loaihang in QLKT.LoaiHangs
                              from ncc in QLKT.NhaCungCaps
                              where ((loaihang.MaLoaiHang == ncc.MaLoaiHang) && (ncc.TenNCC == tenncc))
                              select loaihang.TenLoaiHang;
            //var loaihang = from ncc in QLKT.NhaCungCaps
            //               where ncc.TenNCC == tenncc
            //               select ncc.MaLoaiHang;
            return tenloaihang.Distinct();
        }
        //Lấy Danh Sách Hàng Hóa
        public List<HangHoa> LayDanhSachHangHoa()
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        select new HangHoa
                        {
                            MaHang = h.MaHang,
                            MaLoaiHang=h.MaLoaiHang,
                            MaNCC=h.MaNCC,
                            TenHang = h.TenHang,
                            MoTaHang = h.MoTaHang,
                            MaDonViTinh = h.MaDonViTinh,
                            VAT = float.Parse(h.VAT.ToString()),
                            ThueNhapKhau = (h.ThueNhapKhau.ToString()!=null?float.Parse(h.ThueNhapKhau.ToString()):0),
                            DonGia = System.Convert.ToDecimal(h.DonGia),
                            GiamGia = (h.GiamGia!=null?float.Parse(h.GiamGia.ToString()):0),
                            Hinh = h.Hinh,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Lấy Theo kiểu này k tác động lên DataGridView được.
        //public IQueryable LayDanhSachHangHoa()
        //{
        //    var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
        //                select new
        //                {
        //                    h.MaHang,
        //                    h.TenHang,
        //                    h.MoTaHang,
        //                    h.DonViTinh,
        //                    h.VAT,
        //                    h.ThueNhapKhau,
        //                    h.DonGia,
        //                    h.GiamGia,
        //                    h.Hinh
        //                });
        //    return hang;
        //}
        
        //Lấy Danh sách mặt hàng theo tên loại hàng
        public List<HangHoa> LayDanhSachHangTheoLoaiHang(string tenloaihang)
        {
            var hang = (from h in QLKT.Hangs
                       from lh in QLKT.LoaiHangs
                       where ((h.MaLoaiHang == lh.MaLoaiHang) && (lh.TenLoaiHang == tenloaihang))
                       select new HangHoa
                        {
                            MaHang = h.MaHang,
                            MaLoaiHang = h.MaLoaiHang,
                            MaNCC = h.MaNCC,
                            TenHang = h.TenHang,
                            MoTaHang = h.MoTaHang,
                            MaDonViTinh = h.MaDonViTinh,
                            VAT = float.Parse(h.VAT.ToString()),
                            ThueNhapKhau = (h.ThueNhapKhau.ToString() != null ? float.Parse(h.ThueNhapKhau.ToString()) : 0),
                            DonGia = System.Convert.ToDecimal(h.DonGia),
                            GiamGia = (h.GiamGia != null ? float.Parse(h.GiamGia.ToString()) : 0),
                            Hinh = h.Hinh,
                        }).ToList<HangHoa>();
            return hang;     
        }
        //Lấy danh sách mặt hàng theo tên nhà cung cấp và tên loại hàng
        public List<HangHoa> LayDanhSachHangTheoTenNhaCungCap(string tenncc, string tenloaihang)
        {
            var hang = (from h in QLKT.Hangs
                       from lh in QLKT.LoaiHangs
                       from ncc in QLKT.NhaCungCaps
                       where ((ncc.MaLoaiHang == lh.MaLoaiHang) && (h.MaLoaiHang == ncc.MaLoaiHang) && (lh.TenLoaiHang == tenloaihang) && (h.MaNCC == ncc.MaNCC) && (ncc.TenNCC == tenncc))
                       select new HangHoa
                        {
                            MaHang = h.MaHang,
                            MaLoaiHang = h.MaLoaiHang,
                            MaNCC = h.MaNCC,
                            TenHang = h.TenHang,
                            MoTaHang = h.MoTaHang,
                            MaDonViTinh = h.MaDonViTinh,
                            VAT = float.Parse(h.VAT.ToString()),
                            ThueNhapKhau = (h.ThueNhapKhau.ToString() != null ? float.Parse(h.ThueNhapKhau.ToString()) : 0),
                            DonGia = System.Convert.ToDecimal(h.DonGia),
                            GiamGia = (h.GiamGia != null ? float.Parse(h.GiamGia.ToString()) : 0),
                            Hinh = h.Hinh,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Thêm 1 mẫu dữ liệu hàng hóa vào csdl
        public void ThemHangHoa(string mahang,string maloaihang,string mancc,string tenhang,string MaDVTinh,string MoTaHang,float VAT,float ThueNK,decimal DonGia,float GiamGia,string Hinh)
        {
            try
            {
                Hang h = new Hang();
                h.MaHang = mahang;
                h.MaLoaiHang = maloaihang;
                h.MaNCC = mancc;
                h.TenHang = tenhang;
                h.MaDonViTinh = MaDVTinh;
                h.MoTaHang = MoTaHang;
                h.VAT = VAT;
                h.ThueNhapKhau = ThueNK;
                h.DonGia = DonGia;
                h.GiamGia = GiamGia;
                h.Hinh = Hinh;
                QLKT.Hangs.InsertOnSubmit(h);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void XoaHangHoa(string mahanghoa)
        {
            try
            {
                var delete = from h in QLKT.Hangs
                             where h.MaHang == mahanghoa
                             select h;
                if (delete.Count() > 0)
                {
                    QLKT.Hangs.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SuaHang(string mahang, Hang h)
        {
            try
            {
                Hang hang = QLKT.Hangs.Single(_h => _h.MaHang ==mahang );
                hang.MaNCC = h.MaNCC;
                hang.MaLoaiHang = h.MaLoaiHang;
                hang.TenHang = h.TenHang;
                hang.MoTaHang = h.MoTaHang;
                hang.MaDonViTinh = h.MaDonViTinh;
                hang.VAT = h.VAT;
                hang.ThueNhapKhau = h.ThueNhapKhau;
                hang.GiamGia = h.GiamGia;
                hang.DonGia = h.DonGia;
                hang.Hinh = h.Hinh;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Các hàm phục vụ tìm kiếm
        public List<HangHoa> TimTatCaHangTheoMaLoaiHang(string maloaihang)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.MaLoaiHang == maloaihang
                        select new HangHoa
                        {
                            MaHang = h.MaHang,
                            MaLoaiHang = h.MaLoaiHang,
                            MaNCC = h.MaNCC,
                            TenHang = h.TenHang,
                            MoTaHang = h.MoTaHang,
                            MaDonViTinh = h.MaDonViTinh,
                            VAT = (h.VAT != null ?float.Parse(h.VAT.ToString()):0),
                            ThueNhapKhau = (h.ThueNhapKhau.ToString() != null ? float.Parse(h.ThueNhapKhau.ToString()) : 0),
                            DonGia =(h.DonGia!=null?System.Convert.ToDecimal(h.DonGia):0),
                            GiamGia = (h.GiamGia != null ? float.Parse(h.GiamGia.ToString()) : 0),
                            Hinh = h.Hinh,
                        }).ToList<HangHoa>();
            return hang;
        }
        public List<HangHoa> TimTatCaHangTheoMaHang(string mahang)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.MaHang.Contains(mahang)
                        select new HangHoa
                        {
                            MaHang = h.MaHang,
                            MaLoaiHang = h.MaLoaiHang,
                            MaNCC = h.MaNCC,
                            TenHang = h.TenHang,
                            MoTaHang = h.MoTaHang,
                            MaDonViTinh = h.MaDonViTinh,
                            VAT = (h.VAT != null ? float.Parse(h.VAT.ToString()) : 0),
                            ThueNhapKhau = (h.ThueNhapKhau.ToString() != null ? float.Parse(h.ThueNhapKhau.ToString()) : 0),
                            DonGia = (h.DonGia != null ? System.Convert.ToDecimal(h.DonGia) : 0),
                            GiamGia = (h.GiamGia != null ? float.Parse(h.GiamGia.ToString()) : 0),
                            Hinh = h.Hinh,
                        }).ToList<HangHoa>();
            return hang;
        }
    }
}
