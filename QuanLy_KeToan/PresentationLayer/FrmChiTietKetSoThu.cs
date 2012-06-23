using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLy_KeToan.PresentationLayer
{
    public partial class FrmChiTietKetSoThu : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChiTietKetSoThu()
        {
            InitializeComponent();
        }
        public int thang = 0;
        public decimal sodudauki = 0;
        public decimal tongtienthu = 0;
        public decimal tongtienchi = 0;
        public decimal soducuoiki = 0;

        private void FrmChiTietKetSoThu_Load(object sender, EventArgs e)
        {
            decimal doanhthu = tongtienthu - tongtienchi;
            KST.Text += " " + thang.ToString() + ":";
            TKT.Text += " " + thang.ToString() + ":";
            lblKetQua.Text += " " + thang.ToString() + ":";
            labelX1.Text = sodudauki.ToString("0,00.##") + " VNĐ";
            labelX2.Text = tongtienthu.ToString("0,00.##") + " VNĐ";
            labelX3.Text = tongtienchi.ToString("0,00.##") + " VNĐ";
            labelX4.Text = doanhthu.ToString("0,00.##") + " VNĐ";
            labelX5.Text = soducuoiki.ToString("0,00.##") + " VNĐ";
            labelX4.Text = doanhthu.ToString("0,00.##") + " VNĐ";
            if (doanhthu > 0)
                lblKQ2.Text = "Tiền thu lớn hơn tiền chi"+Environment.NewLine+"Doanh Thu đạt yêu cầu!";
            else
                lblKQ2.Text = "Doanh thu không đạt yêu cầu-Lỗ!";
        }
    }
}