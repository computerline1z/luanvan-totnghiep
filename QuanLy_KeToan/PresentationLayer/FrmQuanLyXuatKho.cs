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
                            if (gridLoaiPhieuXuat.CurrentRow.Cells["ColMLPX"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
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
        //-----------------------PHIÊÚ XUẤT --------------------------------------//
        PhieuXuatBLL PXBLL = new PhieuXuatBLL();  

        #region "Xử lý TreeView"
        private void LoadTreeView()
        {
            //advTreeLoXuat.DataSource = LNBLL.LayDanhSachMaLoXuat();
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
      
        private string xuly_chuoi(string chuoi)
        {
            int vt = chuoi.IndexOf("=");
            int vt1 = chuoi.IndexOf(",");
            string s1 = chuoi.Substring(vt + 1, vt1 - vt - 1).Trim();
            return s1;
        }
        # endregion

        private void LayMaLoaiPX()
        {
            MLPX.DataSource = PXBLL.LayMaLoaiPhieuXuat();
            MLPX.DisplayMember = "TenLoaiPhieuXuat";
            MLPX.ValueMember = "MaLoaiPhieuXuat";
        }
        private void LayMaKH()
        {
            MKH.DataSource = PXBLL.LayMaKhachHang();
            MKH.DisplayMember = "TenKhachHang";
            MKH.ValueMember = "MaKhachHang";
          
        }
        private void LayDSPhieuXuatTheoLo(string malo)
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = PXBLL.LayDSPhieuXuat(malo);
            bindingPhieuXuat.BindingSource = bds;
            gridPhieuXuat.DataSource = bds;
            gridPhieuXuat.AllowUserToAddRows = false;
        }
        int th_pn = 0;
        private void PX_Save_Click(object sender, EventArgs e)
        {
            switch (th_pn)
            {
                case 0://Sửa
                    {
                        if (MessageBox.Show("Bạn có muốn lưu dòng này không?", "SAVE",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            positionPhieuXuat.Focus();
                            if (gridPhieuXuat.CurrentRow.Cells["MPX"].Value == null || gridPhieuXuat.CurrentRow.Cells["MKH"].Value == null || gridPhieuXuat.CurrentRow.Cells["NPX"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            PhieuXuat PX = new PhieuXuat();
                            string maphieuxuat = gridPhieuXuat.CurrentRow.Cells["MPX"].Value.ToString();
                            string maloxuat = gridPhieuXuat.CurrentRow.Cells["MLX"].Value.ToString();
                            PX.MaLoaiPhieuXuat = gridPhieuXuat.CurrentRow.Cells["MLPX"].Value.ToString();
                            PX.MaKhachHang = gridPhieuXuat.CurrentRow.Cells["MKH"].Value.ToString();
                            PX.NgayPhieuXuat = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["NPX"].Value.ToString());
                            PX.MoTa = (gridPhieuXuat.CurrentRow.Cells["MT"].Value != null ? gridPhieuXuat.CurrentRow.Cells["MT"].Value.ToString() : "");
                            PX.NgayLap = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NL"].Value.ToString());
                            PX.NguoiLap = (gridPhieuXuat.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            PX.NgaySua = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NS"].Value.ToString());
                            PX.NguoiSua = (gridPhieuXuat.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PXBLL.SuaPX(maphieuxuat, maloxuat, PX);
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
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
                            positionPhieuXuat.Focus();
                            if (gridPhieuXuat.CurrentRow.Cells["MPX"].Value == null || gridPhieuXuat.CurrentRow.Cells["MKH"].Value == null || gridPhieuXuat.CurrentRow.Cells["NPX"].Value == null)
                            {
                                MessageBox.Show("Nhập thiếu thông tin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string maphieuxuat = gridPhieuXuat.CurrentRow.Cells["MPX"].Value.ToString();
                            string maloaiphieunhap = gridPhieuXuat.CurrentRow.Cells["MLPX"].Value.ToString();
                            string maloxuat = gridPhieuXuat.CurrentRow.Cells["MLX"].Value.ToString();
                            //MessageBox.Show(gridPhieuXuat.CurrentRow.Cells["MKH"].Value.ToString());
                            string mkh = gridPhieuXuat.CurrentRow.Cells["MKH"].Value.ToString();
                            DateTime temp = DateTime.Parse("1/1/0001 12:00:00 AM");
                            DateTime ngayphieuxuat;
                            if (System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["NPX"].Value) != temp)
                            {
                                ngayphieuxuat = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["NPX"].Value);
                            }
                            else
                            {
                                ngayphieuxuat = DateTime.Now.Date;
                            }
                            string mota = (gridPhieuXuat.CurrentRow.Cells["MT"].Value != null ? gridPhieuXuat.CurrentRow.Cells["MT"].Value.ToString() : "");
                            DateTime ngaylap;
                            if (System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NL"].Value) != temp)
                            {
                                ngaylap = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NL"].Value);
                            }
                            else
                            {
                                ngaylap = DateTime.Now.Date;
                            }
                            DateTime ngaysua;
                            if (System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NS"].Value) != temp)
                            {
                                ngaysua = System.Convert.ToDateTime(gridPhieuXuat.CurrentRow.Cells["_NS"].Value);
                            }
                            else
                            {
                                ngaysua = DateTime.Now.Date;
                            }
                            string nguoilap = (gridPhieuXuat.CurrentRow.Cells["_NgL"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgL"].Value.ToString() : "");
                            string nguoisua = (gridPhieuXuat.CurrentRow.Cells["_NgS"].Value != null ? gridPhieuXuat.CurrentRow.Cells["_NgS"].Value.ToString() : "");
                            PXBLL.ThemPhieuXuat(maphieuxuat, maloaiphieunhap, maloxuat, mkh, ngayphieuxuat, mota, ngaylap, nguoilap, ngaysua, nguoisua);
                            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
                            th_pn = 0;
                        }
                        else
                        {
                            th_pn = 0;
                            return;
                        }

                        break;
                    }
            }
        }

        private void PX_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy thao tác?", "CANCEL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
            }
            else
                return;
        }

        private void PX_Refresh_Click(object sender, EventArgs e)
        {
            LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
        }

        private void gridPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (th_pn == 1)
                {
                    gridPhieuXuat.CurrentRow.Cells["MPX"].ReadOnly = false;
                    gridPhieuXuat.CurrentRow.Cells["MLX"].Value = xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
                }
                string name = gridPhieuXuat.Columns[e.ColumnIndex].Name;
                if (name == "MPX")
                {
                    if (gridPhieuXuat.CurrentRow.Cells["MPX"].Value != null)
                    {
                        FrmChiTietPhieuXuat CTPX = new FrmChiTietPhieuXuat();
                        CTPX.maphieuxuat = gridPhieuXuat.CurrentRow.Cells["MPX"].Value.ToString();
                        CTPX.id_patch = xuly_chuoi(advTreeLoXuat.SelectedNode.Text);
                        CTPX.Show();
                    }
                    else
                        return;
                }
            }
        }

        private void advTreeLoXuat_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
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
            else if (e.Node.Parent.Level == 1 && e.Node.Level == 2)
            {
                LayMaLoaiPX();
                LayMaKH();
                groupPanelPhieuXuat.BringToFront();
                string malo = xuly_chuoi(e.Node.Text);
                LayDSPhieuXuatTheoLo(malo);
            }
        }

        private void PX_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PX_Add_Click(object sender, EventArgs e)
        {
            th_pn = 1;
            gridPhieuXuat.AllowUserToAddRows = true;
            bindingPhieuXuat.BindingSource.MoveLast();
        }

        private void PX_Delete_Click(object sender, EventArgs e)
        {
            // Nếu data gridview không có dòng nào
            if (gridPhieuXuat.RowCount == 0)
                PX_Delete.Enabled = false;
            else if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maphieuxuat = gridPhieuXuat.CurrentRow.Cells["MPX"].Value.ToString();
                string maloxuat = gridPhieuXuat.CurrentRow.Cells["MLX"].Value.ToString();
                PXBLL.XoaPX(maphieuxuat, maloxuat);
                LayDSPhieuXuatTheoLo(xuly_chuoi(advTreeLoXuat.SelectedNode.Text));
            }
        }

    }
}