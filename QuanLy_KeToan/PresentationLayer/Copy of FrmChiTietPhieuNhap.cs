using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.DataAccessLayer;
using QuanLy_KeToan.BusinessLogicLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class CopyFrmChiTietPhieuNhap : DevComponents.DotNetBar.Office2007Form
    {
        public CopyFrmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        ChiTietPhieuNhapBLL CTPNBLL = new ChiTietPhieuNhapBLL();
        public string maphieunhap;

        private void LayHang(string maphieunhap)
        {
            ColMH.DataSource = CTPNBLL.LayMaHang(maphieunhap);
            ColMH.DisplayMember = "TenHang";
            ColMH.ValueMember = "MaHang";
        }
        private void LayNCC(string maphieunhap)
        {
            ColMKH.DataSource = CTPNBLL.LayKhoHang(maphieunhap);
            ColMKH.DisplayMember = "TenKhoHang";
            ColMKH.ValueMember = "MaKhoHang";
        }
        private void LayDanhSachChiTietPhieuNhap(string maphieunhap)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = CTPNBLL.LayChiTietPhieuNhapTheoMaPhieuNhap(maphieunhap);
            bindingCTPN.BindingSource = bds;
            gridChiTietPhieuNhap.DataSource = bds;
            gridChiTietPhieuNhap.AllowUserToAddRows = false;
        }
        private void KiemTraGridview()
        {
            for (int i = 0; i < gridChiTietPhieuNhap.RowCount; i++)
            {
                if (System.Convert.ToBoolean(gridChiTietPhieuNhap.Rows[i].Cells["ColStatus"].Value) == true)
                {
                    gridChiTietPhieuNhap.Rows[i].Cells["ColUpdate"].ReadOnly = true;
                    gridChiTietPhieuNhap.Rows[i].Cells["ColUpdate"].Style.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        private void FrmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LayHang(maphieunhap);
            LayNCC(maphieunhap);
            LayDanhSachChiTietPhieuNhap(maphieunhap);
            KiemTraGridview();
        }
        private int count = 0;
        int vitri = 0;
        private void gridChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                KiemTraGridview();
                string name = gridChiTietPhieuNhap.Columns[e.ColumnIndex].Name;
                string makhohang=(gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value!=null?gridChiTietPhieuNhap.CurrentRow.Cells["ColMKH"].Value.ToString():"");
                string mahang=(gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value!=null?gridChiTietPhieuNhap.CurrentRow.Cells["ColMH"].Value.ToString():"");
                if (name == "ColUpdate")
                {
                    if (gridChiTietPhieuNhap.CurrentRow.Cells["ColUpdate"].ReadOnly == true)
                    {
                        gridChiTietPhieuNhap.CurrentRow.Cells["ColUpdate"].Style.BackColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (MessageBox.Show("Bạn có chắc cập nhật hàng này vào kho không?", "Update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                        CTPNBLL.CapNhatKhoChua(mahang,makhohang);
                        gridChiTietPhieuNhap.CurrentRow.Cells["ColStatus"].Value = true;
                        gridChiTietPhieuNhap.CurrentRow.Cells["ColUpdate"].Style.BackColor = System.Drawing.Color.Red;
                        //CTPNBLL.CapNhatColStatus(mahang,true);
                     }
                    else
                        return;
                }
                //Code phần cập nhật lại số lượng kho khi thay đổi số lượng.
                if (name == "ColUpdateSL")
                {
                    if (count % 2 == 0)
                    {
                        vitri = e.RowIndex;
                        gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].ReadOnly = false;
                        gridChiTietPhieuNhap.CurrentRow.Cells["ColUpdateSL"].Value = QuanLy_KeToan.Properties.Resources.save;
                        count++;
                    }
                    else
                    {
                        if (e.RowIndex == vitri)
                        {

                            if (MessageBox.Show("Bạn có muốn cập nhật lại số lượng hàng này vào kho không?", "Update",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int sl = System.Convert.ToInt16(gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].Value);
                                CTPNBLL.CapNhatLaiKhoChua(mahang, makhohang, sl);
                                gridChiTietPhieuNhap.CurrentRow.Cells["ColUpdateSL"].Value = QuanLy_KeToan.Properties.Resources.edit;
                                gridChiTietPhieuNhap.CurrentRow.Cells["ColSL"].ReadOnly = true;
                                count++;
                            }
                            else
                            {
                                gridChiTietPhieuNhap.CurrentRow.Cells["ColUpdateSL"].Value = QuanLy_KeToan.Properties.Resources.edit;
                                count++;
                                return;
                            }
                        }
                        else
                            return;
                    }
                }
            }
        }
        int th_ctpn = 0;
        private void Add_Click(object sender, EventArgs e)
        {
            th_ctpn = 1;
            gridChiTietPhieuNhap.AllowUserToAddRows = true;
            bindingCTPN.BindingSource.MoveLast();
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColUpdateSL"].Value = QuanLy_KeToan.Properties.Resources.edit;
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColUpdateSL"].ReadOnly = true;
            gridChiTietPhieuNhap.Rows[gridChiTietPhieuNhap.RowCount - 1].Cells["ColSL"].ReadOnly = false;
            
        }


    }
}