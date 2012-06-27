using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

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
        public string NguoiLap { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiSua { get; set; }
        public DateTime NgaySua { get; set; }
    }
    class HangBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Kiểu IQueryable trả về kiểu object,nếu mình chỉ ra kiểu trả về luôn như IQueryabl<String> thì nó sẽ 
        // trả về kiểu String,nếu chỉ để IQueryable thì sau khi gọi hàm phải chuyển kiểu.

#region(Lấy dữ liệu cho Treeview)
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
#endregion

#region (Lấy dữ liệu cho combobox column)
        
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
                           select new { lh.MaLoaiHang,lh.TenLoaiHang, };
            return loaihang.Distinct();
        }
        //Lấy Danh Sách Mã NCC cho ColMaNCC
        public IQueryable LayDanhSachMaNCC()
        {
            var ncc = from NCC in QLKT.NhaCungCaps
                      select new { NCC.MaNCC, NCC.TenNCC, };
            return ncc.Distinct();
        }
        //Lấy Mã đơn vị tính cho combobox column donvitinh
        public IQueryable LayDanhSachDonViTinh()
        {
            var dvt = from DVT in QLKT.DonViTinhs
                      select new { DVT.MaDonViTinh, DVT.TenDonViTinh };
            return dvt.Distinct();
        }
        //Lấy Danh Sách Người Lập cho ColNguoiLap
        public IQueryable LayDanhSachNguoiLap()
        {
            var nguoilap = from phanquyen in QLKT.PhanQuyens
                           select new { phanquyen.TenDangNhap };
            return nguoilap.Distinct();
        }
        //Lấy Danh Sách Người Sửa cho ColNguoiSua
        public IQueryable LayDanhSachNguoiSua()
        {
            var nguoisua = from phanquyen in QLKT.PhanQuyens
                           select new { phanquyen.TenDangNhap };
            return nguoisua.Distinct();
        }
#endregion

#region (Lấy dữ liệu cho combobox)
        //Lấy danh sách mã loại hàng và tên loại hàng theo tên nhà cung cấp cho Combobox
        public IQueryable LayDanhSachLoaiHangHoa(string tenncc)
        {
            var lh = from loaihang in QLKT.LoaiHangs
                     from ncc in QLKT.NhaCungCaps
                     where ((loaihang.MaLoaiHang == ncc.MaLoaiHang) && (ncc.TenNCC == tenncc))
                     select new
                     {
                         loaihang.MaLoaiHang,
                         loaihang.TenLoaiHang,
                     };
            return lh;
        }
#endregion

#region (Load Danh Sach Hàng)
        //Lấy Danh Sách Hàng Hóa
        public List<HangHoa> LayDanhSachHangHoa()
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
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
        }
        //Lấy Danh sách mặt hàng theo tên loại hàng khi chọn trên treeview
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Lấy danh sách mặt hàng theo tên nhà cung cấp và tên loại hàng khi chọn trên treeview
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
#endregion

#region (Thao tác thêm xóa sửa)
        //Kiểm tra trước khi thêm
        private bool KiemTraThem(string mahang)
        {
            var sql = from h in QLKT.Hangs
                      where h.MaHang == mahang
                      select h;
            if (sql.Count() > 0)
                return true;
            else
                return false;
        }
        //Hàm Thêm
        public void ThemHangHoa(string mahang, string maloaihang, string mancc, string tenhang, string MaDVTinh, string MoTaHang, float VAT, float ThueNK, decimal DonGia, float GiamGia, string Hinh,DateTime ngaylap,string nguoilap,DateTime ngaysua,string nguoisua)
        {
            if (KiemTraThem(mahang) == true)
            {
                MessageBox.Show("Mã hàng trên đã tồn tại trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                h.NgayLap = ngaylap;
                h.NguoiLap = nguoilap;
                h.NgaySua = ngaysua;
                h.NguoiSua = nguoisua;
                QLKT.Hangs.InsertOnSubmit(h);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void SuaHang(string mahang, Hang h)
        {
            try
            {
                Hang hang = QLKT.Hangs.Single(_h => _h.MaHang == mahang);
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
                hang.NgayLap=h.NgayLap;
                hang.NguoiLap=h.NguoiLap;
                hang.NgaySua=h.NgaySua;
                hang.NguoiSua=h.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool KtraKhochua(string mahang)
        {
            var sql=from kc in QLKT.KhoChuas
                    where kc.MaHang==mahang
                    select kc;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
        private bool KtraCTHDB(string mahang)
        {
            var sql=from cthdb in QLKT.ChiTietHDBans
                    where cthdb.MaHang==mahang
                    select cthdb;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
        private bool KtraCTHDM(string mahang)
        {
            var sql=from cthdm in QLKT.ChiTietHDMuas
                    where cthdm.MaHang==mahang
                    select cthdm;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
          private bool KtraCTPC(string mahang)
        {
            var sql=from ctpc in QLKT.ChiTietPhieuChis
                    where ctpc.MaHang==mahang
                    select ctpc;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
        private bool KtraCTPT(string mahang)
        {
            var sql=from ctpt in QLKT.ChiTietPhieuThus
                    where ctpt.MaHang==mahang
                    select ctpt;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
        private bool KtraCTPN(string mahang)
        {
            var sql=from ctpn in QLKT.ChiTietPhieuNhaps
                    where ctpn.MaHang==mahang
                    select ctpn;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
        private bool KtraCTPX(string mahang)
        {
            var sql=from ctpx in QLKT.ChiTietPhieuXuats
                    where ctpx.MaHang==mahang
                    select ctpx;
            if(sql.Count()>0)
                return true;
            else
                return false;
        }
        public void XoaHangHoa(string mahanghoa)
        {
            if(KtraKhochua(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL Kho chứa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KtraCTHDB(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL CTHDB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KtraCTHDM(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL CTHDM", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KtraCTPT(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL CTPT", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KtraCTPC(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL CTPC ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KtraCTPN(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL CTPN", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(KtraCTPX(mahanghoa)==true)
            {
                MessageBox.Show("Không thể xóa dữ liệu này- Liên quan đên CSDL CTPX", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
#endregion

#region (Hàm Tìm kiếm)
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
                            VAT = (h.VAT != null ? float.Parse(h.VAT.ToString()) : 0),
                            ThueNhapKhau = (h.ThueNhapKhau.ToString() != null ? float.Parse(h.ThueNhapKhau.ToString()) : 0),
                            DonGia = (h.DonGia != null ? System.Convert.ToDecimal(h.DonGia) : 0),
                            GiamGia = (h.GiamGia != null ? float.Parse(h.GiamGia.ToString()) : 0),
                            Hinh = h.Hinh,
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm gần đúng
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm chính xác
        public List<HangHoa> TimTatCaHangChinhXacTheoMaHang(string mahang)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.MaHang == mahang
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm theo tên hàng
        public List<HangHoa> TimTatCaHangChinhXacTheoTenHang(string tenhang)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.TenHang == tenhang
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm theo đơn vị
        public List<HangHoa> TimTatCaHangChinhXacTheoDVTinh(string dvtinh)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.MaDonViTinh == dvtinh
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm theo giá sản phẩm
        public List<HangHoa> TimTatCaHangTheoGiaSanPham(decimal giatu, decimal dengia)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.DonGia >= giatu && h.DonGia <= dengia
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm chính xác giá sản phẩm
        public List<HangHoa> TimChinhXacGiaSanPham(decimal gia)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.DonGia == gia
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm theo VAT
        public List<HangHoa> TimTheoVAT(float VAT)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.VAT == VAT
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm theo Giảm Giá
        public List<HangHoa> TimTheoGiamGia(float GiamGia)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.GiamGia == GiamGia
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
        //Tìm theo Thuế Nhập Khẩu
        public List<HangHoa> TimTheoThueNhapKhau(float ThueNhapKhau)
        {
            var hang = (from h in QLKT.Hangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        where h.ThueNhapKhau == ThueNhapKhau
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
                            NgayLap = System.Convert.ToDateTime(h.NgayLap),
                            NguoiLap = h.NguoiLap,
                            NgaySua = System.Convert.ToDateTime(h.NgaySua),
                            NguoiSua = h.NguoiSua,
                        }).ToList<HangHoa>();
            return hang;
        }
#endregion
#region (Đăng nhập)
        public bool QuyenThem()
        {
            bool them = false;
            var sql = from dn in QLKT.DangNhaps
                      where dn.Id == 1
                      select dn.Them;
            foreach (var item in sql)
            {
                them = System.Convert.ToBoolean(item);
            }
            return them;
        }
        public bool QuyenSua()
        {
            bool sua = false;
            var sql = from dn in QLKT.DangNhaps
                      where dn.Id == 1
                      select dn.Sua;
            foreach (var item in sql)
            {
                sua = System.Convert.ToBoolean(item);
            }
            return sua;
        }
        public bool QuyenXoa()
        {
            bool xoa = false;
            var sql = from dn in QLKT.DangNhaps
                      where dn.Id == 1
                      select dn.Xoa;
            foreach (var item in sql)
            {
                xoa = System.Convert.ToBoolean(item);
            }
            return xoa;
        }
        #endregion
    }
}