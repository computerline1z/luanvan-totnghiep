using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Ket_So_Xuat_Nhap_Kho
    {
        public int thang { get; set; }
        public int nam { get; set; }
        public string mahang { get; set; }
        public int sldauthang { get; set; }
        public int tongnhap { get; set; }
        public int tongxuat { get; set; }
        public int slcuoithang { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class KetSoXuatNhapKhoBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        public List<Ket_So_Xuat_Nhap_Kho> LayDSKetSoXuatNhapKho(string makhohang,int nam)
        {
            var sql = (from ksxn in QLKT.KetSoXuatNhapKhos
                       from kh in QLKT.KhoHangs
                       from h in QLKT.Hangs
                       where h.MaLoaiHang==kh.MaLoaiHang && h.MaHang==ksxn.MaHang && kh.MaKhoHang==makhohang && ksxn.Nam==nam
                       orderby ksxn.Thang ascending
                       select new Ket_So_Xuat_Nhap_Kho
                       {
                           thang = ksxn.Thang,
                           nam = ksxn.Nam,
                           mahang=ksxn.MaHang,
                           tongnhap=System.Convert.ToInt16(ksxn.TongNhap),
                           tongxuat=System.Convert.ToInt16(ksxn.TongXuat),
                           sldauthang=System.Convert.ToInt16(ksxn.SLDauThang),
                           slcuoithang=System.Convert.ToInt16(ksxn.SLCuoiThang),
                           ngaylap = Convert.ToDateTime(ksxn.NgayLap == null ? DateTime.Today : ksxn.NgayLap),
                           nguoilap = ksxn.NguoiLap,
                           ngaysua = Convert.ToDateTime(ksxn.NgaySua == null ? DateTime.Today : ksxn.NgaySua),
                           nguoisua = ksxn.NguoiSua,
                       }).ToList<Ket_So_Xuat_Nhap_Kho>();
            return sql;
        }
        public int TongNhap(int thang,int nam,string mahang)
        {
            var sql = from ctpn in QLKT.ChiTietPhieuNhaps
                      from lopn in QLKT.LoPhieuNhaps
                      where lopn.MaLoHDMua == ctpn.MaLoHDMua && ctpn.MaHang==mahang && System.Convert.ToDateTime(lopn.NgayLoNhap).Date.Month==thang && System.Convert.ToDateTime(lopn.NgayLoNhap).Date.Year==nam
                      select ctpn.SoLuong;
            int tong = 0;
            foreach (var items in sql)
            {
                tong += System.Convert.ToInt16(items);
            }
            return tong;
        }
        public int TongXuat(int thang, int nam,string mahang)
        {
            var sql = from ctpx in QLKT.ChiTietPhieuXuats
                      from lopx in QLKT.LoPhieuXuats
                      where lopx.MaLoHDBan == ctpx.MaLoHDBan && System.Convert.ToDateTime(lopx.NgayLoXuat).Date.Month == thang && System.Convert.ToDateTime(lopx.NgayLoXuat).Date.Year == nam
                      select ctpx.SoLuong;
            int tong = 0;
            foreach (var items in sql)
            {
                tong += System.Convert.ToInt16(items);
            }
            return tong;
        }
        public int SLDauThang(int thang,int nam,string mahang)
        {
            IQueryable sql;
            sql = from ksxnk in QLKT.KetSoXuatNhapKhos
                  where ksxnk.Thang == thang - 1 && ksxnk.Nam == nam && ksxnk.MaHang == mahang
                  select ksxnk.SLCuoiThang;
            int sldauthang = 0;
            foreach (var items in sql)
            {
                sldauthang = System.Convert.ToInt16(items);
            }
            return sldauthang;
        }
        public int SLCuoiThang(int thang, int nam, string mahang)
        {
            int tongnhap = TongNhap(thang,nam,mahang);
            int tongxuat = TongXuat(thang, nam,mahang);
            int sldauthang = SLDauThang(thang, nam,mahang);
            int slcuoithang = sldauthang + (tongnhap - tongxuat);
            return slcuoithang;
        }
        private bool KiemTraDulieu(int thang,int nam,string mahang)
        {
            var sql = from ksxnk in QLKT.KetSoXuatNhapKhos
                      where ksxnk.Thang==thang && ksxnk.Nam==nam && ksxnk.MaHang==mahang
                      select ksxnk;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public bool Sua(int thang,int nam,string mahang,KetSoXuatNhapKho KSXNK)
        {
            try
            {
                KetSoXuatNhapKho _KSXNK = QLKT.KetSoXuatNhapKhos.Single(_ksxnk => _ksxnk.Thang == thang && _ksxnk.Nam == nam && _ksxnk.MaHang==mahang);
                _KSXNK.NgayLap = KSXNK.NgayLap;
                _KSXNK.NguoiLap = KSXNK.NguoiLap;
                _KSXNK.NgaySua = KSXNK.NgaySua;
                _KSXNK.NguoiSua = KSXNK.NguoiSua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool LuuCapNhat(int nam,string mahang,ToolStripProgressBar pb)
        {
            var sql = from ksxn in QLKT.KetSoXuatNhapKhos
                      where ksxn.Nam == nam && ksxn.MaHang==mahang
                      orderby ksxn.Thang ascending
                      select new { ksxn.Thang, ksxn.Nam };
            int sl = 0;
            foreach (var item in sql)
            {
                sl++;
            }
            pb.Minimum = 0;
            pb.Step = 5;
            pb.Maximum = sl;
            foreach (var items in sql)
            {
                pb.PerformStep();
                int month = System.Convert.ToInt16(items.Thang);
                int year = System.Convert.ToInt16(items.Nam);
                int sldauthang =SLDauThang(month,year,mahang);
                int tongnhap = TongNhap(month, year,mahang);
                int tongxuat = TongXuat(month, year,mahang);
                int slcuoithang = SLCuoiThang(month, year,mahang);
                KetSoXuatNhapKho _KSXNK = QLKT.KetSoXuatNhapKhos.Single(_ksxn => _ksxn.Thang == month && _ksxn.Nam == year && _ksxn.MaHang==mahang);
                _KSXNK.SLDauThang = sldauthang;
                _KSXNK.SLCuoiThang = slcuoithang;
                _KSXNK.TongNhap = tongnhap;
                _KSXNK.TongXuat = tongxuat;
                QLKT.SubmitChanges();
            }
            if (pb.Maximum == sl)
                MessageBox.Show("Cập nhật Kết sổ nhập xuất các tháng trong năm: " + nam + " thành công!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public bool KiemTraThangNamKSTC(int thang, int nam,string mahang)
        {
            var sql = from ksxn in QLKT.KetSoXuatNhapKhos
                      where ksxn.Nam == nam && ksxn.MaHang== mahang
                      orderby ksxn.Thang ascending
                      select new { ksxn.Thang };
            int month = 0;
            foreach (var items in sql)
            {
                month = System.Convert.ToInt16(items.Thang);
            }
            if ((thang == 1 && month == 0) || (thang == month + 1))
                return true;
            else
                return false;
        }
        public bool LuuThem(int thang, int nam,string mahang,int sldauthang,int tongnhap,int tongxuat,int slcuoithang, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraThangNamKSTC(thang, nam,mahang) == false)
            {
                MessageBox.Show("Dữ liệu kết sổ Tháng " + (thang - 1).ToString() + "/" + nam.ToString() + " chưa có.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (KiemTraDulieu(thang, nam, mahang) == true)
                {
                    MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                try
                {
                    KetSoXuatNhapKho KSXNK = new KetSoXuatNhapKho();
                    KSXNK.Thang = thang;
                    KSXNK.Nam = nam;
                    KSXNK.MaHang = mahang;
                    KSXNK.SLDauThang = sldauthang;
                    KSXNK.TongNhap = tongnhap;
                    KSXNK.TongXuat = tongxuat;
                    KSXNK.SLCuoiThang = slcuoithang;
                    KSXNK.NguoiLap = nguoilap;
                    KSXNK.NgaySua = ngaysua;
                    KSXNK.NguoiSua = nguoisua;
                    QLKT.KetSoXuatNhapKhos.InsertOnSubmit(KSXNK);
                    QLKT.SubmitChanges();
                    MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public bool XoaKSXNK(int nam,string mahang,ToolStripProgressBar pb)
        {
            var sql = from ksxn in QLKT.KetSoXuatNhapKhos
                      where ksxn.Nam == nam && ksxn.MaHang==mahang
                      orderby ksxn.Thang ascending
                      select new { ksxn.Thang, ksxn.Nam };
            int sl = 0;
            foreach (var item in sql)
            {
                sl++;
            }
            pb.Minimum = 0;
            pb.Step = 5;
            pb.Maximum = sl;
            foreach (var items in sql)
            {
                pb.PerformStep();
                int month = items.Thang;
                int year = items.Nam;
                try
                {
                    var delete = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Thang == month && ksxn.Nam == nam && ksxn.MaHang==mahang
                                 select ksxn;
                    if (delete.Count() > 0)
                    {
                        QLKT.KetSoXuatNhapKhos.DeleteOnSubmit(delete.First());
                        QLKT.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (pb.Maximum == sl)
                MessageBox.Show("Xóa Kết sổ nhập xuất Mã hàng: "+mahang+" Năm: " + nam + " Thành công!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public void LayThangTheoNam(int nam,string mahang, ComboBoxEx cmb)
        {
            var sql = from ksxn in QLKT.KetSoXuatNhapKhos
                      where ksxn.Nam == nam && ksxn.MaHang==mahang
                      orderby ksxn.Thang ascending
                      select ksxn.Thang;
            int thang = 1;
            foreach (var items in sql)
            {
                thang = System.Convert.ToInt16(items);
            }
            if (thang == 12)
                return;
            else
            {
                for (int i = thang + 1; i <= 12; i++)
                {
                    cmb.Items.Add(i);
                }
            }
        }
        public void KetSoThuChiQuyNhapXuat(string makhohang,int nam,LabelX lbl1,LabelX lbl2,LabelX lbl3,
                                    LabelX lbl4,LabelX lbl5,LabelX lbl6,LabelX lbl7,LabelX lbl8,
                                    LabelX lbl9, LabelX lbl10, LabelX lbl11, LabelX lbl12,
                                    LabelX x_lbl1, LabelX x_lbl2, LabelX x_lbl3,
                                    LabelX x_lbl4, LabelX x_lbl5, LabelX x_lbl6, LabelX x_lbl7, LabelX x_lbl8,
                                    LabelX x_lbl9, LabelX x_lbl10, LabelX x_lbl11, LabelX x_lbl12,
                                    LabelX tong1, LabelX tong2, LabelX tong3, LabelX tong4,
                                    LabelX x_tong1, LabelX x_tong2, LabelX x_tong3, LabelX x_tong4) 
        {
            var sql = (from ksxn in QLKT.KetSoXuatNhapKhos
                      from kh in QLKT.KhoHangs
                      from h in QLKT.Hangs
                      where h.MaLoaiHang==kh.MaLoaiHang && h.MaHang==ksxn.MaHang && kh.MaKhoHang==makhohang && ksxn.Nam==nam
                      orderby ksxn.Thang ascending
                      select new { ksxn.Thang,ksxn.MaHang}).Distinct();
            int tn_sum1 = 0;
            int tx_sum1 = 0;
            int tn_sum2 = 0;
            int tx_sum2 = 0;
            int tn_sum3 = 0;
            int tx_sum3 = 0;
            int tn_sum4 = 0;
            int tx_sum4 = 0;
            int tongnhap1 = 0;
            int tongxuat1 = 0;
            int tongnhap2 = 0;
            int tongxuat2 = 0;
            int tongnhap3 = 0;
            int tongxuat3 = 0;
            int tongnhap4 = 0;
            int tongxuat4 = 0;
            int tongnhap5 = 0;
            int tongxuat5 = 0;
            int tongnhap6 = 0;
            int tongxuat6 = 0;
            int tongnhap7 = 0;
            int tongxuat7 = 0;
            int tongnhap8 = 0;
            int tongxuat8 = 0;
            int tongnhap9 = 0;
            int tongxuat9 = 0;
            int tongnhap10 = 0;
            int tongxuat10 = 0;
            int tongnhap11 = 0;
            int tongxuat11 = 0;
            int tongnhap12 = 0;
            int tongxuat12 = 0;
            foreach (var items in sql)
            {
                int thang = items.Thang;
                string mahang = items.MaHang;
                if (thang == 1)
                {
                    var month1 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang==1 && ksxn.MaHang==mahang
                                 select new {ksxn.TongNhap, ksxn.TongXuat};
                    foreach (var item1 in month1)
                    {
                        tongnhap1 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat1 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl1.Text = tongnhap1.ToString();
                    x_lbl1.Text = tongxuat1.ToString();
                }
                if (thang == 2)
                {
                    var month2 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 2 && ksxn.MaHang==mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item2 in month2)
                    {
                        tongnhap2 += System.Convert.ToInt16(item2.TongNhap);
                        tongxuat2 += System.Convert.ToInt16(item2.TongXuat);
                    }
                    lbl2.Text = tongnhap2.ToString();
                    x_lbl2.Text = tongxuat2.ToString();
                }
                if (thang == 3)
                {
                    var month3 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 3 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month3)
                    {
                        tongnhap3 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat3 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl3.Text = tongnhap3.ToString();
                    x_lbl3.Text = tongxuat3.ToString();
                }
                if (thang == 4)
                {
                    var month4 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 4 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month4)
                    {
                        tongnhap4 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat4 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl4.Text = tongnhap4.ToString();
                    x_lbl4.Text = tongxuat4.ToString();
                }
                if (thang == 5)
                {
                    var month5 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 5 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month5)
                    {
                        tongnhap5 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat5 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl5.Text = tongnhap5.ToString();
                    x_lbl5.Text = tongxuat5.ToString();
                }
                if (thang == 6)
                {
                    var month6 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 6 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month6)
                    {
                        tongnhap6 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat6 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl6.Text = tongnhap6.ToString();
                    x_lbl6.Text = tongxuat6.ToString();
                }
                if (thang == 7)
                {
                    var month7 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 7 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month7)
                    {
                        tongnhap7 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat7 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl7.Text = tongnhap7.ToString();
                    x_lbl7.Text = tongxuat7.ToString();
                }
                if (thang == 8)
                {
                    var month8 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 8 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                   foreach (var item1 in month8)
                    {
                        tongnhap8 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat8 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl8.Text = tongnhap8.ToString();
                    x_lbl8.Text = tongxuat8.ToString();
                }
                if (thang == 9)
                {
                    var month9 = from ksxn in QLKT.KetSoXuatNhapKhos
                                 where ksxn.Nam == nam && ksxn.Thang == 9 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month9)
                    {
                        tongnhap9 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat9 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl9.Text = tongnhap9.ToString();
                    x_lbl9.Text = tongxuat9.ToString();
                }
                if (thang == 10)
                {
                    var month10 = from ksxn in QLKT.KetSoXuatNhapKhos
                                  where ksxn.Nam == nam && ksxn.Thang == 10 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month10)
                    {
                        tongnhap10 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat10 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl10.Text = tongnhap10.ToString();
                    x_lbl10.Text = tongxuat10.ToString();
                }
                if (thang == 11)
                {
                    var month11 = from ksxn in QLKT.KetSoXuatNhapKhos
                                  where ksxn.Nam == nam && ksxn.Thang == 11 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month11)
                    {
                        tongnhap11 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat11 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl11.Text = tongnhap11.ToString();
                    x_lbl11.Text = tongxuat11.ToString();
                }
                if (thang == 12)
                {
                    var month12 = from ksxn in QLKT.KetSoXuatNhapKhos
                                  where ksxn.Nam == nam && ksxn.Thang == 12 && ksxn.MaHang == mahang
                                 select new { ksxn.TongNhap, ksxn.TongXuat };
                    foreach (var item1 in month12)
                    {
                        tongnhap12 += System.Convert.ToInt16(item1.TongNhap);
                        tongxuat12 += System.Convert.ToInt16(item1.TongXuat);
                    }
                    lbl12.Text = tongnhap12.ToString();
                    x_lbl12.Text = tongxuat12.ToString();
                }
                if (thang == 1 || thang == 2 || thang == 3)
                {
                    tn_sum1 = tongnhap1 + tongnhap2 + tongnhap3;
                    tx_sum1 = tongxuat1 + tongxuat2 + tongxuat3;
                }
                if (thang == 4 || thang == 5 || thang == 6)
                {
                    tn_sum2 = tongnhap2 + tongnhap2 + tongnhap2;
                    tx_sum2 = tongxuat2 + tongxuat2 + tongxuat2;
                }
                if (thang == 7 || thang == 8 || thang == 9)
                {
                    tn_sum3 = tongnhap3 + tongnhap3 + tongnhap3;
                    tx_sum3 = tongxuat3 + tongxuat3 + tongxuat3;
                }
                if (thang == 10 || thang == 11 || thang == 12)
                {
                    tn_sum4 = tongnhap4 + tongnhap4 + tongnhap4;
                    tx_sum4 = tongxuat4 + tongxuat4 + tongxuat4;
                }
            }
            tong1.Text = tn_sum1.ToString();
            x_tong1.Text = tx_sum1.ToString();
            tong2.Text = tn_sum2.ToString();
            x_tong2.Text = tx_sum2.ToString();
            tong3.Text = tn_sum3.ToString();
            x_tong3.Text = tx_sum3.ToString();
            tong4.Text = tn_sum4.ToString();
            x_tong4.Text = tx_sum4.ToString();
        }
         public IQueryable LayNguoiLap()
        {
            var sql = from phanquyen in QLKT.PhanQuyens
                      select new { phanquyen.TenDangNhap };
            return sql;
        }
        public IQueryable LayKhoHang()
        {
            var sql = from kh in QLKT.KhoHangs
                      select new { kh.MaKhoHang, kh.TenKhoHang };
            return sql;
        }
        public IQueryable LayHang()
        {
            var sql = from h in QLKT.Hangs
                      select new { h.MaHang };
            return sql;
        }
        public IQueryable LayHangTheoMaKhoHang(string makhohang)
        {
            var sql = from h in QLKT.Hangs
                      from kh in QLKT.KhoHangs
                      where h.MaLoaiHang == kh.MaLoaiHang && kh.MaKhoHang == makhohang
                      select new { h.MaHang };
            return sql;
        }
    }
}
