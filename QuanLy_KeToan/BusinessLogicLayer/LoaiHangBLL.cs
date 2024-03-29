﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class LoaiHangHoa
    {
        public string MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }
        public string MoTaLoaiHang { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgaySua { get; set; }
        public string NguoiSua { get; set; }
    }
    class LoaiHangBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        //Lấy Danh Sách Loại Hàng Hóa
        public List<LoaiHangHoa> LoadDanhSachLoaiHangHoa()
        {
            var hang = (from lh in QLKT.LoaiHangs  //Hoặc from h in QLKT.GetTable<Hang>() 
                        select new LoaiHangHoa
                        {
                            MaLoaiHang = lh.MaLoaiHang,
                            TenLoaiHang = lh.TenLoaiHang,
                            MoTaLoaiHang = lh.MoTaLoaiHang,
                            NgayLap = Convert.ToDateTime(lh.NgayLap),
                            NguoiLap = lh.NguoiLap,
                            NgaySua = Convert.ToDateTime(lh.NgaySua),
                            NguoiSua = lh.NguoiSua
                        }).ToList<LoaiHangHoa>();
            return hang;
        }
        //Thêm Loại Hàng Hóa
        public void ThemLoaiHang(string maloaihang, string tenloaihang, string motaloaihang, DateTime ngaylap, string nguoilap, DateTime ngaysua, string nguoisua)
        {
            try
            {
                LoaiHang LH = new LoaiHang();
                LH.MaLoaiHang = maloaihang;
                LH.TenLoaiHang = tenloaihang;
                LH.MoTaLoaiHang = motaloaihang;
                LH.NgayLap = ngaylap;
                LH.NguoiLap = nguoilap;
                LH.NgaySua = ngaysua;
                LH.NguoiSua = nguoisua;
                QLKT.LoaiHangs.InsertOnSubmit(LH);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void XoaLoaiHang(string maloaihang)
        {
            
            var ktra = from h in QLKT.Hangs
                        where h.MaLoaiHang == maloaihang
                        select h;
            if (ktra.Count() > 0)
            {
                MessageBox.Show("Bạn không thể xóa loại hàng này-Liên quan đến dữ liệu Hàng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ktr2=from lhdb in QLKT.LoHDBans
                     where lhdb.MaLoaiHang==maloaihang
                     select lhdb;
            if (ktr2.Count() > 0)
            {
                MessageBox.Show("Bạn không thể xóa loại hàng này-Liên quan đến dữ liệu Lô Hóa Đơn Bán", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ktr3 = from lhdm in QLKT.LoHDMuas
                       where lhdm.MaLoaiHang == maloaihang
                       select lhdm;
            if (ktr3.Count() > 0)
            {
                MessageBox.Show("Bạn không thể xóa loại hàng này-Liên quan đến dữ liệu Lô Hóa Đơn Mua", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var delete = from lh in QLKT.LoaiHangs
                                where lh.MaLoaiHang == maloaihang
                                select lh;
                if (delete.Count() > 0)
                {
                    QLKT.LoaiHangs.DeleteOnSubmit(delete.First());
                    QLKT.SubmitChanges();
                    MessageBox.Show("Xóa thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SuaLoaiHang(string maloaihang, LoaiHang LH)
        {
            try
            {
                LoaiHang loaihang = QLKT.LoaiHangs.Single(lh => lh.MaLoaiHang == maloaihang);
                loaihang.TenLoaiHang = LH.TenLoaiHang;
                loaihang.MoTaLoaiHang = LH.MoTaLoaiHang;
                loaihang.NgayLap = LH.NgayLap;
                loaihang.NguoiLap = LH.NguoiLap;
                loaihang.NgaySua = LH.NgaySua;
                loaihang.NguoiSua = LH.NguoiSua;
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
        public List<LoaiHangHoa> LayDanhSachLoaiHangTheoMaLH(string maloaihang)
        {
            var loaihang = (from lh in QLKT.LoaiHangs
                            where lh.MaLoaiHang == maloaihang
                            select new LoaiHangHoa
                            {
                                MaLoaiHang = lh.MaLoaiHang,
                                TenLoaiHang = lh.TenLoaiHang,
                                MoTaLoaiHang = lh.MoTaLoaiHang,
                                NgayLap = Convert.ToDateTime(lh.NgayLap),
                                NguoiLap = lh.NguoiLap,
                                NgaySua = Convert.ToDateTime(lh.NgaySua),
                                NguoiSua = lh.NguoiSua
                            }).ToList<LoaiHangHoa>();
            return loaihang;
        }
        public List<LoaiHangHoa> LayDanhSachLoaiHangTheoTenLH(string tenloaihang)
        {
            var loaihang = (from lh in QLKT.LoaiHangs
                            where lh.TenLoaiHang.Contains(tenloaihang)
                            select new LoaiHangHoa
                            {
                                MaLoaiHang = lh.MaLoaiHang,
                                TenLoaiHang = lh.TenLoaiHang,
                                MoTaLoaiHang = lh.MoTaLoaiHang,
                                NgayLap = Convert.ToDateTime(lh.NgayLap),
                                NguoiLap = lh.NguoiLap,
                                NgaySua = Convert.ToDateTime(lh.NgaySua),
                                NguoiSua = lh.NguoiSua
                            }).ToList<LoaiHangHoa>();
            return loaihang;
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
    }
}
