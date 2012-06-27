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
    class Ket_So_Thu_Chi
    {
        public int thang { get; set; }
        public int nam { get; set; }
        public decimal sodudauki { get; set; }
        public decimal tongtienthu { get; set; }
        public decimal tongtienchi { get; set; }
        public decimal soducuoiki { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoilap { get; set; }
        public DateTime ngaysua { get; set; }
        public string nguoisua { get; set; }
    }
    class KetSoThuChiBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        public List<Ket_So_Thu_Chi> LayDSKetSoThuChi(int nam)
        {
            var sql = (from kstc in QLKT.KetSoThuChis
                       where kstc.Nam==nam
                       orderby kstc.Thang ascending
                       select new Ket_So_Thu_Chi
                       {
                           thang = kstc.Thang,
                           nam = kstc.Nam,
                           sodudauki=System.Convert.ToDecimal(kstc.SoDuDauKi),
                           tongtienthu=System.Convert.ToDecimal(kstc.TongTienThu),
                           tongtienchi=System.Convert.ToDecimal(kstc.TongTienChi),
                           soducuoiki=System.Convert.ToDecimal(kstc.SoDuCuoiKi),
                           ngaylap = Convert.ToDateTime(kstc.NgayLap == null ? DateTime.Today : kstc.NgayLap),
                           nguoilap = kstc.NguoiLap,
                           ngaysua = Convert.ToDateTime(kstc.NgaySua == null ? DateTime.Today : kstc.NgaySua),
                           nguoisua = kstc.NguoiSua,
                       }).ToList<Ket_So_Thu_Chi>();
            return sql;
        }
        public decimal TongTienThu(int thang,int nam)
        {
            var sql = from ctpt in QLKT.ChiTietPhieuThus
                      from lopt in QLKT.LoPhieuThus
                      where lopt.MaLoHDBan == ctpt.MaLoHDBan && System.Convert.ToDateTime(lopt.NgayLoThu).Date.Month==thang && System.Convert.ToDateTime(lopt.NgayLoThu).Date.Year==nam
                      select ctpt.TienThu;
            decimal tong = 0;
            foreach (var items in sql)
            {
                tong += System.Convert.ToDecimal(items);
            }
            return tong;
        }
        public decimal TongTienChi(int thang, int nam)
        {
            var sql = from ctpc in QLKT.ChiTietPhieuChis
                      from lopc in QLKT.LoPhieuChis
                      where lopc.MaLoHDMua == ctpc.MaLoHDMua && System.Convert.ToDateTime(lopc.NgayLoChi).Date.Month == thang && System.Convert.ToDateTime(lopc.NgayLoChi).Date.Year == nam
                      select ctpc.TienChi;
            decimal tong = 0;
            foreach (var items in sql)
            {
                tong += System.Convert.ToDecimal(items);
            }
            return tong;
        }
        public decimal SoDuDauKi(int thang, int nam)
        {
            IQueryable sql;
            //if (thang == 1)
            //{
            //    sql = from kstc in QLKT.KetSoThuChis
            //              where kstc.Thang == 12 && kstc.Nam == nam - 1
            //              select kstc.SoDuCuoiKi;
            //}
            //else
            //{
            sql = from kstc in QLKT.KetSoThuChis
                  where kstc.Thang == thang - 1 && kstc.Nam == nam
                  select kstc.SoDuCuoiKi;
            decimal soducuoiki = 0;
            foreach (var items in sql)
            {
                soducuoiki = System.Convert.ToDecimal(items.ToString());
            }
            return soducuoiki;
        }
        public decimal SoDuCuoiKi(int thang, int nam)
        {
            decimal tienchi = TongTienChi(thang, nam);
            decimal tienthu = TongTienThu(thang, nam);
            decimal sodudauki = SoDuDauKi(thang, nam);
            decimal soducuoiki = sodudauki+(tienthu-tienchi);
            return soducuoiki;
        }
        private bool KiemTraDulieu(int thang,int nam)
        {
            var sql = from kstc in QLKT.KetSoThuChis
                      where kstc.Thang==thang && kstc.Nam==nam
                      select kstc;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        
        public bool Sua(int thang,int nam,KetSoThuChi KSTC)
        {
            try
            {
                KetSoThuChi _KSTC = QLKT.KetSoThuChis.Single(_kstc => _kstc.Thang == thang && _kstc.Nam == nam);
                _KSTC.NgayLap = KSTC.NgayLap;
                _KSTC.NguoiLap = KSTC.NguoiLap;
                _KSTC.NgaySua = KSTC.NgaySua;
                _KSTC.NguoiSua = KSTC.NguoiSua;
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
        public bool LuuCapNhat(int nam,ToolStripProgressBar pb)
        {
            var sql = from kstc in QLKT.KetSoThuChis
                      where kstc.Nam==nam
                      orderby kstc.Thang ascending
                      select new { kstc.Thang, kstc.Nam };
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
                decimal sodudauki = SoDuDauKi(month, year);
                decimal tongtienthu = TongTienThu(month, year);
                decimal tongtienchi = TongTienChi(month, year);
                decimal soducuoiki = SoDuCuoiKi(month, year);
                KetSoThuChi _KSTC = QLKT.KetSoThuChis.Single(_kstc => _kstc.Thang == month && _kstc.Nam == year);
                _KSTC.SoDuDauKi = sodudauki;
                _KSTC.SoDuCuoiKi = soducuoiki;
                _KSTC.TongTienThu = tongtienthu;
                _KSTC.TongTienChi = tongtienchi;
                QLKT.SubmitChanges();
            }
            if(pb.Maximum==sl)
                MessageBox.Show("Cập nhật Kết sổ thu chi các tháng trong năm: " + nam + " thành công!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public bool KiemTraThangNamKSTC(int thang, int nam)
        {
            var sql = from kstc in QLKT.KetSoThuChis
                      where kstc.Nam == nam
                      orderby kstc.Thang ascending
                      select new { kstc.Thang };
            int month = 0;
            foreach (var items in sql)
            {
                month = System.Convert.ToInt16(items.Thang);
            }
            int kt_thang = 0;
            if (thang == 1)
            {
                var kt = from kstc in QLKT.KetSoThuChis
                         where kstc.Nam == nam - 1
                         orderby kstc.Thang ascending
                         select new { kstc.Thang };
                
                foreach (var item in kt)
                {
                    kt_thang = System.Convert.ToInt16(item.Thang);
                }
            }
            if ((thang == 1 && kt_thang == 12)||(thang!=1 && thang == month + 1))
            {
                return true;
            }
            else
            {
                if(thang==1 && kt_thang!=12)
                     MessageBox.Show("Dữ liệu kết sổ tháng 12 năm " + (nam - 1).ToString() + " chưa có!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if(thang!=1 && thang!=month+1)
                    MessageBox.Show("Dữ liệu kết sổ Tháng " + (thang-1).ToString() + "/" + nam.ToString() + " chưa có.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public bool LuuThem(int thang, int nam, decimal sodudauki, decimal tongtienthu, decimal tongtienchi, decimal soducuoiki, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            if (KiemTraDulieu(thang, nam) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (KiemTraThangNamKSTC(thang, nam) == true)
            {
               
                try
                {
                    KetSoThuChi KSTC = new KetSoThuChi();
                    KSTC.Thang = thang;
                    KSTC.Nam = nam;
                    KSTC.SoDuDauKi = sodudauki;
                    KSTC.TongTienThu = tongtienthu;
                    KSTC.TongTienChi = tongtienchi;
                    KSTC.SoDuCuoiKi = soducuoiki;
                    KSTC.NguoiLap = nguoilap;
                    KSTC.NgaySua = ngaysua;
                    KSTC.NguoiSua = nguoisua;
                    QLKT.KetSoThuChis.InsertOnSubmit(KSTC);
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
            else
                return false;
        }
        public bool XoaKSTC(int nam, ToolStripProgressBar pb)
        {
            var sql = from kstc in QLKT.KetSoThuChis
                      where kstc.Nam == nam
                      orderby kstc.Thang ascending
                      select new { kstc.Thang, kstc.Nam };
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
                    var delete = from kstc in QLKT.KetSoThuChis
                                 where kstc.Thang == month && kstc.Nam==nam
                                 select kstc;
                    if (delete.Count() > 0)
                    {
                        QLKT.KetSoThuChis.DeleteOnSubmit(delete.First());
                        QLKT.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (pb.Maximum == sl)
                MessageBox.Show("Xóa thành công Kết sổ thu chi Năm: " + nam + " Thành công!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public void LayThangTheoNam(int nam,ComboBoxEx cmb)
        {
            var sql = from kstc in QLKT.KetSoThuChis
                      where kstc.Nam == nam
                      orderby kstc.Thang ascending
                      select kstc.Thang;
            int thang = 1;
            foreach (var items in sql)
            {
                thang = System.Convert.ToInt16(items);
            }
            if (thang == 12)
                return;
            else
            {
                for (int i = thang+1; i <= 12; i++)
                {
                    cmb.Items.Add(i);
                }
            }
        }
        public void KetSoThuChiQuy(int nam,LabelX txt1,LabelX txt2,LabelX txt3,
                                    LabelX txt4,LabelX txt5,LabelX txt6,LabelX txt7,LabelX txt8,
                                    LabelX txt9, LabelX txt10, LabelX txt11, LabelX txt12, LabelX tong1, LabelX tong2, LabelX tong3,LabelX tong4,LabelX tong)
        {
            var sql = from kstc in QLKT.KetSoThuChis
                      where kstc.Nam == nam
                      orderby kstc.Thang ascending
                      select new { kstc.Thang, kstc.TongTienThu,kstc.TongTienChi,kstc.SoDuCuoiKi };
            decimal sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;
            decimal sum4 = 0;
            foreach (var items in sql)
            {
                int thang = items.Thang;
                decimal tongtienthu = System.Convert.ToDecimal(items.TongTienThu);
                decimal tongtienchi = System.Convert.ToDecimal(items.TongTienChi);
                if (thang == 1)
                {
                    txt1.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 2)
                {
                    txt2.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 3)
                {
                    txt3.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 4)
                {
                    txt4.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 5)
                {
                    txt5.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 6)
                {
                    txt6.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 7)
                {
                    txt7.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 8)
                {
                    txt8.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 9)
                {
                    txt9.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 10)
                {
                    txt10.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 11)
                {
                    txt11.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 12)
                {
                    txt12.Text = (tongtienthu - tongtienchi).ToString("0,00.##") + " VNĐ";
                }
                if (thang == 1 || thang == 2 || thang == 3)
                {
                    sum1 += tongtienthu - tongtienchi;
                }
                if (thang == 4 || thang == 5 || thang == 6)
                {
                    sum2 += tongtienthu - tongtienchi;
                }
                if (thang == 7 || thang == 8 || thang == 9)
                {
                    sum3 += tongtienthu - tongtienchi;
                }
                if (thang == 10 || thang == 11 || thang == 12)
                {
                    sum4 += tongtienthu - tongtienchi;
                }
            }
            tong1.Text = sum1.ToString("0,00.##") + " VNĐ";
            tong2.Text = sum2.ToString("0,00.##") + " VNĐ";
            tong3.Text = sum3.ToString("0,00.##") + " VNĐ";
            tong4.Text = sum4.ToString("0,00.##") + " VNĐ";
            decimal sum = sum1 + sum2 + sum3 + sum4;
            tong.Text = sum.ToString("0,00.##") + " VNĐ";

        }
        public void TongTaiSan(LabelX lbl)
        {
            var sql = (from kstc in QLKT.KetSoThuChis
                      orderby kstc.Nam ascending
                      select kstc.Nam).Distinct();
            decimal tongtien = 0;
            foreach (var items in sql)
            {
                int nam = items;
                var _sql = from kstc in QLKT.KetSoThuChis
                          orderby kstc.Thang ascending
                          where kstc.Nam==nam
                          select kstc.SoDuCuoiKi;
                decimal tientungnam = 0;
                foreach (var sdck in _sql)
                {
                    tientungnam = System.Convert.ToDecimal(sdck);
                }
                tongtien += tientungnam;
            }
            lbl.Text += tongtien.ToString("0,00.##") + " VNĐ";
        }
        public IQueryable LayNguoiLap()
        {
            var sql = from phanquyen in QLKT.PhanQuyens
                      select new { phanquyen.TenDangNhap };
            return sql;
        }
    }
}
