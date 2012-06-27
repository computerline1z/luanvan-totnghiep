using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class Phan_Quyen
    {
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }
        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public bool gioitinh { get; set; }
        public string chucvu { get; set; }
        public string sodt { get; set; }
        public string email { get; set; }
        public bool them { get; set; }
        public bool xoa { get; set; }
        public bool sua { get; set; }
    }
    class PhanQuyenBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();
        
        public List<Phan_Quyen> LayDSNguoiDung()
        {
            var sql = (from pq in QLKT.PhanQuyens
                         select new Phan_Quyen
                       {
                           tendangnhap=pq.TenDangNhap,
                           matkhau=pq.MatKhau,
                           hoten=pq.HoTen,
                           ngaysinh = Convert.ToDateTime(pq.NgaySinh == null ? DateTime.Today : pq.NgaySinh),
                           gioitinh = System.Convert.ToBoolean(pq.GioiTinh),
                           chucvu=pq.ChucVu,
                           sodt=pq.SoDT,
                           email=pq.Email,
                           them=System.Convert.ToBoolean(pq.Them),
                           xoa = System.Convert.ToBoolean(pq.Xoa),
                           sua= System.Convert.ToBoolean(pq.Sua),
                       }).ToList<Phan_Quyen>();
            return sql;
        }
        private bool KiemTraDulieu(string tendangnhap)
        {
            var sql = from pq in QLKT.PhanQuyens
                      where pq.TenDangNhap == tendangnhap
                      select pq;
            if (sql.Count() > 0)
                return true;
            else return false;
        }
        public void ThemNguoiDung(string tendangnhap,string matkhau,string hoten,DateTime ngaysinh,bool gioitinh,string chucvu,string sodt,string email,bool them,bool xoa,bool sua)
        {
            if (KiemTraDulieu(tendangnhap) == true)
            {
                MessageBox.Show("Đã tồn tại dữ liệu này trong CSDL", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PhanQuyen PQ = new PhanQuyen();
                PQ.TenDangNhap = tendangnhap;
                PQ.MatKhau =matkhau;
                PQ.HoTen =hoten;
                PQ.NgaySinh = ngaysinh;
                PQ.GioiTinh = gioitinh;
                PQ.ChucVu =chucvu;
                PQ.SoDT =sodt;
                PQ.Email= email;
                PQ.Them=them;
                PQ.Xoa=xoa;
                PQ.Sua=sua;
                QLKT.PhanQuyens.InsertOnSubmit(PQ);
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void SuaNguoiDung(string tendangnhap,PhanQuyen PQ)
        {
            try
            {
                PhanQuyen pq = QLKT.PhanQuyens.Single(_pq => _pq.TenDangNhap == tendangnhap);
                pq.MatKhau = PQ.MatKhau;
                pq.HoTen = PQ.HoTen;
                pq.NgaySinh = PQ.NgaySinh;
                pq.GioiTinh = PQ.GioiTinh;
                pq.ChucVu = PQ.ChucVu;
                pq.SoDT = PQ.SoDT;
                pq.Email = PQ.Email;
                pq.Them = PQ.Them;
                pq.Xoa = PQ.Xoa;
                pq.Sua = PQ.Sua;
                QLKT.SubmitChanges();
                MessageBox.Show("Lưu thành công 1 record !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void XoaNguoiDung(string tendangnhap)
        {
            try
            {
                var delete = from pq in QLKT.PhanQuyens
                             where pq.TenDangNhap == tendangnhap
                             select pq;
                if (delete.Count() > 0)
                {
                    QLKT.PhanQuyens.DeleteOnSubmit(delete.First());
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
