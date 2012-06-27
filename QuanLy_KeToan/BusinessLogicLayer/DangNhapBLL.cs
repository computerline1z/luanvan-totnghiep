using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLy_KeToan.DataAccessLayer;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace QuanLy_KeToan.BusinessLogicLayer
{
    class DangNhapBLL
    {
        QuanLy_KeToanDataContext QLKT = new QuanLy_KeToanDataContext();

        
        public bool KiemtraDangNhap(string tendangnhap, string matkhau,TextBoxX txtTenDangNhap,MaskedTextBoxAdv txtMatKhau)
        {
            var ktra=from pq in QLKT.PhanQuyens
                     where pq.TenDangNhap==tendangnhap
                     select pq;
            if (ktra.Count() > 0)
            {
                var sql = from pq in QLKT.PhanQuyens
                          where pq.TenDangNhap == tendangnhap && pq.MatKhau == matkhau
                          select pq;
                if (sql.Count() > 0)
                    return true;
                else
                {
                    MessageBox.Show("Sai Mật Khẩu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập này không tồn tại trong hệ thống", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }
        }
        public bool QuyenThem(string tendangnhap)
        {
            bool them = false;
            var sql = from pq in QLKT.PhanQuyens
                      where pq.TenDangNhap == tendangnhap
                      select pq.Them;
            foreach (var item in sql)
            {
                them = System.Convert.ToBoolean(item);
            }
            return them;
        }
        public bool QuyenSua(string tendangnhap)
        {
            bool sua = false;
            var sql = from pq in QLKT.PhanQuyens
                      where pq.TenDangNhap == tendangnhap
                      select pq.Sua;
            foreach (var item in sql)
            {
                sua = System.Convert.ToBoolean(item);
            }
            return sua;
        }
        public bool QuyenXoa(string tendangnhap)
        {
            bool xoa = false;
            var sql = from pq in QLKT.PhanQuyens
                      where pq.TenDangNhap == tendangnhap
                      select pq.Xoa;
            foreach (var item in sql)
            {
                xoa = System.Convert.ToBoolean(item);
            }
            return xoa;
        }
        public void CapNhatDangNhap(string tendangnhap,bool them, bool xoa, bool sua)
        {
            DangNhap dn = QLKT.DangNhaps.Single(_dn => _dn.Id == 1);
            dn.TenDangNhap = tendangnhap;
            dn.Them = them;
            dn.Xoa = xoa;
            dn.Sua = sua;
            QLKT.SubmitChanges();
        }
    }
}
