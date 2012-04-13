using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.BusinessLogicLayer;
using DevComponents.DotNetBar.Rendering;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmHangHoa : DevComponents.DotNetBar.Office2007Form
    {
        public FrmHangHoa()
        {
            InitializeComponent();
        }
       
        HangBLL HBLL = new HangBLL();
        private bool _MColorSelected;
        private eOffice2007ColorScheme _MBaseColorScheme = eOffice2007ColorScheme.Blue;
        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            LoadDataComboboxLoaiHang();
            LoadDataComboboxNhaCungCap();
            LoadDataColumnCombobox();
            LoadDanhSachHang();
        }
        private void LoadDanhSachHang()
        {
            BindingSource bds = new BindingSource();
            bds.DataSource = HBLL.LayDanhSachHangHoa();
            gridHangHoa.DataSource = bds;
            bindingHangHoa.BindingSource = bds;
        }
        private void LoadTreeView()
        {
            foreach (var item in HBLL.LayDanhSachTenLoaiHang())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item.ToString());
                advTreeLoaiHangHoa.Nodes[0].Nodes.Add(childnode);
            }
            foreach (var item in HBLL.LayDanhSachTenNCC())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item);
                advTreeLoaiHangHoa.Nodes[1].Nodes.Add(childnode);
                foreach (var items in HBLL.LayDanhSachTenLoaiHangTheoNCC(childnode.Text))
                {
                    DevComponents.AdvTree.Node child_node = new DevComponents.AdvTree.Node(items);
                    childnode.Nodes.Add(child_node);
                }
            }

            advTreeLoaiHangHoa.CollapseAll();
        }

        private void advTreeLoaiHangHoa_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            //if ((e.Node.Index == 0 || e.Node.Index==1) && e.Node.Parent==null)
            if (e.Node.Level == 0)
                LoadDanhSachHang();
            else
            {
                //Duyệt các node con của danh mục loại hàng hóa
                if (e.Node.Parent.Index == 0 && e.Node.Level == 1)
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = HBLL.LayDanhSachHangTheoLoaiHang(e.Node.Text);
                    gridHangHoa.DataSource = bds;
                    bindingHangHoa.BindingSource = bds;
                }
                else if (e.Node.Parent.Index == 1 && e.Node.Level == 1)
                {

                }
                else if (e.Node.Level == 2)
                {
                    BindingSource bds = new BindingSource();
                    bds.DataSource = HBLL.LayDanhSachHangTheoTenNhaCungCap(e.Node.Parent.Text, e.Node.Text);
                    gridHangHoa.DataSource = bds;
                    bindingHangHoa.BindingSource = bds;
                }
            }
        }
        #region "Thay đổi màu giao diện"
        private void buttonSilver_Click(object sender, EventArgs e)
        {

            styleManagerHH.ManagerStyle = eStyle.Office2007Silver;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Silver);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            styleManagerHH.ManagerStyle = eStyle.Office2007Blue;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Blue);
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            styleManagerHH.ManagerStyle = eStyle.Office2007Black;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Black);
        }  
        private void colorPickerButton_SelectedColorChanged(object sender, EventArgs e)
        {
            _MColorSelected = true;
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme, colorPickerButton.SelectedColor);
        }

        private void colorPickerButton_ColorPreview(object sender, ColorPreviewEventArgs e)
        {
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme, e.Color);
        }
        private void colorPickerButton_PopupOpen(object sender, EventArgs e)
        {
            if (colorPickerButton.Expanded)
            {
                // Remember the starting color scheme to apply
                // if no color is selected during live-preview

                _MColorSelected = false;
                _MBaseColorScheme = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.InitialColorScheme;
            }
            else
            {
                if (_MColorSelected == false)
                    RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme);
            }
        }
        private void colorPickerButton_PopupClose(object sender, EventArgs e)
        {
            if (colorPickerButton.Expanded)
            {
                // Remember the starting color scheme to apply
                // if no color is selected during live-preview

                _MColorSelected = false;
                _MBaseColorScheme = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.InitialColorScheme;
            }
            else
            {
                if (_MColorSelected == false)
                    RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(_MBaseColorScheme);
            }
        }
#endregion
        private string filename = "";
        private void HienThiDuLieuLenControl(int dong)
        {
            txtMaHang.Text = gridHangHoa.Rows[dong].Cells["ColMaHang"].Value.ToString();
            string tenlh = "";
            foreach (var item in HBLL.LayDanhSachTenLoaiHangTheoMaLoaiHang(gridHangHoa.Rows[dong].Cells["ColMaLoaiHang"].Value.ToString()))
            {
                tenlh = item.ToString();
            }
            cmbMaLoaiHang.Text = tenlh;
            string tenncc = "";
            foreach (var item in HBLL.LayDanhSachTenNCCTheoMaNCC(gridHangHoa.Rows[dong].Cells["ColMaNCC"].Value.ToString()))
            {
                tenncc = item.ToString();
            }
            cmbNCC.Text = tenncc;
            cmbMaLoaiHang.DisplayMember = gridHangHoa.Rows[dong].Cells["ColMaNCC"].Value.ToString();
            txtTenHang.Text = gridHangHoa.Rows[dong].Cells["ColTenHang"].Value.ToString();
            txtMoTaHang.Text = gridHangHoa.Rows[dong].Cells["ColMoTaHang"].Value.ToString();
            cmbDonViTinh.Text = gridHangHoa.Rows[dong].Cells["ColDonViTinh"].Value.ToString();
            doubleInputVAT.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColVAT"].Value.ToString());
            doubleInputThueNhapKhau.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColThueNhapKhau"].Value.ToString());
            doubleInputDonGia.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColDonGia"].Value.ToString());
            doubleInputGiamGia.Value = System.Convert.ToDouble(gridHangHoa.Rows[dong].Cells["ColGiamGia"].Value.ToString());
            if (gridHangHoa.Rows[dong].Cells["ColHinh"].Value != null)
            {
                filename = gridHangHoa.Rows[dong].Cells["ColHinh"].Value.ToString();
                picHang.Image = new Bitmap(Application.StartupPath + "\\Hang\\" + filename);
            }
            else
            {
                filename = "";
                picHang.Image = null;
            }
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingHangHoa.BindingSource.MoveLast();
        }

        private void gridHangHoa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            if (dong < gridHangHoa.RowCount-1)
            {
                HienThiDuLieuLenControl(dong);
            }
        }
        private void LoadDataComboboxLoaiHang()
        {
            cmbMaLoaiHang.DataSource = HBLL.LayDanhSachLoaiHangHoa();
            cmbMaLoaiHang.DisplayMember = "TenLoaiHang";
            cmbMaLoaiHang.ValueMember = "MaLoaiHang";
        }
        private void LoadDataComboboxNhaCungCap()
        {
            cmbNCC.DataSource = HBLL.LayDanhSachNCC();
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
        }
        private void LoadDataColumnCombobox()
        {
            ColMaLoaiHang.DataSource = HBLL.LayDanhSachMaLoaiHang();
            ColMaLoaiHang.DisplayMember = "MaLoaiHang";
            ColMaNCC.DataSource = HBLL.LayDanhSachMaNCC();
            ColMaNCC.DisplayMember = "MaNCC";
            ColDonViTinh.DataSource = HBLL.LayDanhSachMaDonViTinh();
            ColDonViTinh.DisplayMember = "MaDonViTinh";
        }
    }
}