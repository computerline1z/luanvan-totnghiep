using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLy_KeToan.BusinessLogicLayer;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FHangHoa : DevComponents.DotNetBar.Office2007Form
    {
        public FHangHoa()
        {
            InitializeComponent();
        }
        HangBLL HBLL = new HangBLL();
        private void FHangHoa_Load(object sender, EventArgs e)
        {
           LoadTreeView();
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
            foreach (var item in HBLL.LayDanhSachLoaiHang())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item);
                advTreeLoaiHangHoa.Nodes[0].Nodes.Add(childnode);
            }
            foreach (var item in HBLL.LayDanhSachTenNCC())
            {
                DevComponents.AdvTree.Node childnode = new DevComponents.AdvTree.Node(item);
                advTreeLoaiHangHoa.Nodes[1].Nodes.Add(childnode);
                foreach (var items in HBLL.LayDanhSachLoaiHangTheoNCC(childnode.Text))
                {
                    DevComponents.AdvTree.Node child_node = new DevComponents.AdvTree.Node(items);
                    childnode.Nodes.Add(child_node);
                }
            }
           
            advTreeLoaiHangHoa.CollapseAll();
        }

        private void advTreeLoaiHangHoa_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            MessageBox.Show(e.Node.Index.ToString()+","+e.Node.Level.ToString());
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
                    MessageBox.Show(e.Node.Parent.Text + "," + e.Node.Text);
                    bds.DataSource = HBLL.LayDanhSachHangTheoTenNhaCungCap(e.Node.Parent.Text, e.Node.Text);
                    gridHangHoa.DataSource = bds;
                    bindingHangHoa.BindingSource = bds;
                }
            }
        }
    }
}