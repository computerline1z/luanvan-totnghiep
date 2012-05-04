using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.BusinessLogicLayer;
using QuanLy_KeToan.DataAccessLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmQuanLyXuatKho : DevComponents.DotNetBar.Office2007Form
    {
        public FrmQuanLyXuatKho()
        {
            InitializeComponent();
        }
        private void LoadTreeView()
        {
            foreach (var item in LXBLL.LayDanhSachMaLoXuat())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                foreach (DevComponents.AdvTree.Node n in advTreeLoXuat.Nodes[0].Nodes)
                {
                    if (n.Name == "nodeLoPhieuXuat")
                        n.Nodes.Add(childnode);
                }
            }
        }
        private void advTreeXuatKho_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //MessageBox.Show(e.Node.Index.ToString()+","+ e.Node.Level.ToString());
            if (e.Node.Level == 0)
                return;
            //Node Loại phiếu Xuất
            if (e.Node.Parent.Index == 0 && e.Node.Index == 0 && e.Node.Level == 1)
            {
                groupPanelLoaiPhieuXuat.BringToFront();
            }
            //Node Lô Phiếu Xuất
            else if (e.Node.Parent.Index == 0 && e.Node.Index == 1 && e.Node.Level == 1)
            {
                groupPanelLoPhieuXuat.BringToFront();
                LayMaLoaiHang();
                LayDanhSachLoPX();
            }
            //Phiếu Xuất
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                //LayMaLoaiPN();
                //LayMaNCC();
                groupPanelPhieuXuat.BringToFront();
                //string malo = xuly_chuoi(e.Node.Text);
                //LayDSPhieuNhapTheoLo(malo);
            }
        }
        //----------------Form Load---------------------------------//
        private void FrmQuanLyXuatKho_Load(object sender, EventArgs e)
        {
            LayDanhSachLoaiPX();
            LoadTreeView();
        }
        //----------------Phần Loại Phiếu Xuất-------------------------------------//

        LoaiPhieuXuatBLL LPXBLL=new LoaiPhieuXuatBLL();
        
        private int th_lpx = 0;
        

        private void LPX_Exit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void LayDanhSachLoaiPX()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LPXBLL.LayDanhSachLoaiPhieuXuat();
            gridLoaiPhieuXuat.DataSource = bds;
            bindingLoaiPhieuXuat.BindingSource = bds;
            gridLoaiPhieuXuat.AllowUserToAddRows = false;
        }

        private void LPX_Add_Click_1(object sender, EventArgs e)
        {
            th_lpx = 1;
            gridLoaiPhieuXuat.AllowUserToAddRows = true;
            bindingLoaiPhieuXuat.BindingSource.MoveLast();
        }

        private void LPX_Save_Click_1(object sender, EventArgs e)
        {
            switch (th_lpx)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuXuat.Focus();
                            LoaiPhieuXuat LPX = new LoaiPhieuXuat();
                            string maloaiphieuxuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString();
                            LPX.TenLoaiPhieuXuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value.ToString() : "";
                            LPX.NgayLap = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NL"].Value.ToString());
                            LPX.NguoiLap = (gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value.ToString() : "");
                            LPX.NgaySua = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NS"].Value.ToString());
                            LPX.NguoiSua = (gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value.ToString() : "");
                            LPXBLL.SuaLoaiPhieuXuat(maloaiphieuxuat, LPX);
                            LayDanhSachLoaiPX();
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoaiPhieuXuat.Focus();
                            string maloaiphieuxuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString();
                            string tenloaiphieuxuat = gridLoaiPhieuXuat.CurrentRow.Cells["ColTLPX"].Value.ToString();
                            DateTime ngaylap;
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            if (System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoaiPhieuXuat.CurrentRow.Cells["NS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgL"].Value.ToString() : "");
                            string nguoisua = (gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value != null ? gridLoaiPhieuXuat.CurrentRow.Cells["NgS"].Value.ToString() : "");
                            LPXBLL.ThemLoaiPhieuXuat(maloaiphieuxuat, tenloaiphieuxuat, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoaiPX();
                            th_lpx = 0;
                        }
                        else
                        {
                            th_lpx = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void LPX_Delete_Click(object sender, EventArgs e)
        {

            // Nếu data gridview không có dòng nào
            if (gridLoaiPhieuXuat.RowCount == 0)
                LPX_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LPXBLL.XoaLoaiPhieuXuat(gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value.ToString());
                LayDanhSachLoaiPX();
            }
        }

        private void LPX_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoaiPX();
            }
            else
                return;
        }

        private void LPX_Refresh_Click(object sender, EventArgs e)
        {
            FrmQuanLyXuatKho_Load(sender, e);
        }

        //------------------------Code phần Lô Phiếu Xuất--------------------------------------//

        LoPhieuXuatBLL LXBLL = new LoPhieuXuatBLL();

        private void LayMaLoaiHang()
        {
            ColMLH.DataSource = LXBLL.LayMaLoaiHang();
            ColMLH.DisplayMember = "TenLoaiHang";
            ColMLH.ValueMember = "MaLoaiHang";
        }
        private void LayDanhSachLoPX()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = LXBLL.LayDanhSachLoPhieuXuat();
            bindingLoPhieuXuat.BindingSource = bds;
            gridLoPhieuXuat.DataSource = bds;
            gridLoPhieuXuat.AllowUserToAddRows = false;
        }
        int th_lophieuxuat = 0;
        private void LoPX_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LoPX_Add_Click_1(object sender, EventArgs e)
        {
            th_lophieuxuat = 1;
            gridLoPhieuXuat.AllowUserToAddRows = true;
            bindingLoPhieuXuat.BindingSource.MoveLast();
        }

        private void LoPX_Delete_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridLoPhieuXuat.RowCount == 0)
                LoPX_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LXBLL.XoaLPX(gridLoPhieuXuat.CurrentRow.Cells["ColMLX"].Value.ToString(), gridLoPhieuXuat.CurrentRow.Cells["ColMLH"].Value.ToString());
                LayDanhSachLoPX();
            }
        }

        private void LoPX_Cancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDanhSachLoPX();
            }
            else
                return;
        }

        private void LoPX_Refresh_Click(object sender, EventArgs e)
        {
            LayDanhSachLoPX();
        }

        private void LoPX_Save_Click(object sender, EventArgs e)
        {
            switch (th_lophieuxuat)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuXuat.Focus();
                            LoPhieuXuat LPX = new LoPhieuXuat();
                            string maloxuat = gridLoPhieuXuat.CurrentRow.Cells["ColMLX"].Value.ToString();
                            string maloaihang = (gridLoPhieuXuat.CurrentRow.Cells["ColMLH"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["ColMLH"].Value.ToString() : "");
                            LPX.NgayLoXuat = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["ColNLX"].Value.ToString());
                            LPX.MoTa = (gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            LPX.NgayLap = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgayLap"].Value.ToString());
                            LPX.NguoiLap = (gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            LPX.NgaySua = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgaySua"].Value.ToString());
                            LPX.NguoiSua = (gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LXBLL.SuaLoPX(maloxuat, maloaihang, LPX);
                            LayDanhSachLoPX();
                        }
                        else
                            return;
                        break;
                    }
                case 1://Thêm
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionLoPhieuXuat.Focus();
                            string maloxuat = gridLoPhieuXuat.CurrentRow.Cells["ColMLX"].Value.ToString();
                            string maloaihang = gridLoPhieuXuat.CurrentRow.Cells["ColMLH"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngayloxuat;

                            if (System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["ColNLX"].Value) != temp)
                            {
                                ngayloxuat = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["ColNLX"].Value);
                            }
                            else
                            {
                                ngayloxuat = DateTime.Now.Date;
                            }
                            string mota = (gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["ColMT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgayLap"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgayLap"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgaySua"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridLoPhieuXuat.CurrentRow.Cells["NgaySua"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiLap"].Value.ToString() : "");
                            string nguoisua = (gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value != null ? gridLoPhieuXuat.CurrentRow.Cells["NguoiSua"].Value.ToString() : "");
                            LXBLL.ThemLoPX(maloxuat, maloaihang, ngayloxuat, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDanhSachLoPX();
                            th_lophieuxuat = 0;
                        }
                        else
                        {
                            th_lophieuxuat = 0;
                            return;
                        }

                        break;
                    }
            }
        }
    }
}