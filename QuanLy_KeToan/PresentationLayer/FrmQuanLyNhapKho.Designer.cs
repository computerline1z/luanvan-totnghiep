namespace QuanLy_KeToan.PresentationLayer
{
    partial class FrmQuanLyNhapKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuanLyNhapKho));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlNhapKho = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanelLoaiPhieuNhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridLoaiPhieuNhap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColMLPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTLPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NL = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.NgL = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.NS = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.NgS = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.bindingLoaiPhieuNhap = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.positionLoaiPhieuNhap = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.LPN_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.LPN_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.LPN_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.LPN_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.LPN_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.LPN_Exit = new System.Windows.Forms.ToolStripButton();
            this.navigationPaneThaoTac = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanelDuyetDanhMuc = new DevComponents.DotNetBar.NavigationPanePanel();
            this.advTreeLoNhap = new DevComponents.AdvTree.AdvTree();
            this.root_node = new DevComponents.AdvTree.Node();
            this.nodeLoaiPhieuNhap = new DevComponents.AdvTree.Node();
            this.nodeLoPhieuNhap = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.btnDuyetDanhMuc = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanelTimLKiem = new DevComponents.DotNetBar.NavigationPanePanel();
            this.buttonItemTim = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanelThaoTac = new DevComponents.DotNetBar.NavigationPanePanel();
            this.groupLoaiPhieuNhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_LPN_Huy = new DevComponents.DotNetBar.ButtonX();
            this.btn_LPN_Luu = new DevComponents.DotNetBar.ButtonX();
            this.btn_LPN_Sua = new DevComponents.DotNetBar.ButtonX();
            this.btn_LPN_Them = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.LPN_cmbNguoiSua = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.LPN_dpNgaySua = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.LPN_cmbNguoiLap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.LPN_dpNgayLap = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtTenLoaiPhieuNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaLoaiPhieuNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupLoPhieuNhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtMoTa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.dpNgayLoNhap = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cmbMaLoHDMua = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_LoPN_Huy = new DevComponents.DotNetBar.ButtonX();
            this.btn_LoPN_Luu = new DevComponents.DotNetBar.ButtonX();
            this.btn_LoPN_Sua = new DevComponents.DotNetBar.ButtonX();
            this.btn_LoPN_Them = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.LoPN_cmbNguoiSua = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.LoPN_dpNgaySua = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.LoPN_cmbNguoiLap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.LoPN_dpNgayLap = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.groupPhieuPhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PN_txtMT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.PN_cmbMHDM = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.PN_cmbMLHDM = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.PN_cmbMLPN = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_PN_Huy = new DevComponents.DotNetBar.ButtonX();
            this.btn_PN_Luu = new DevComponents.DotNetBar.ButtonX();
            this.btn_PN_Sua = new DevComponents.DotNetBar.ButtonX();
            this.btn_PN_Them = new DevComponents.DotNetBar.ButtonX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.PN_cmbNguoiSua = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.PN_dpNgaySua = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.PN_cmbNguoiLap = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.PN_dpNgayLap = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.buttonItemThaoTac = new DevComponents.DotNetBar.ButtonItem();
            this.expandablePanelCauHinh = new DevComponents.DotNetBar.ExpandablePanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonBlack = new DevComponents.DotNetBar.ButtonX();
            this.buttonBlue = new DevComponents.DotNetBar.ButtonX();
            this.buttonSilver = new DevComponents.DotNetBar.ButtonX();
            this.colorPickerButton = new DevComponents.DotNetBar.ColorPickerButton();
            this.groupPanelLoPhieuNhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridLoPhieuNhap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColMLHDM = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.ColNLN = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.ColMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.NguoiLap = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.NgaySua = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.NguoiSua = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.bindingLoPhieuNhap = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem3 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.positionLoPhieuNhap = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.LoPN_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.LoPN_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.LoPN_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.LoPN_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.LoPN_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.LoPN_Exit = new System.Windows.Forms.ToolStripButton();
            this.groupPanelPhieuNhap = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridPhieuNhap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MLPN = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.MLHDM = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.MHDM = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.MT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._NL = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this._NgL = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this._NS = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this._NgS = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.bindingPhieuNhap = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem4 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem4 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem4 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.positionPhieuNhap = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem4 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem4 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.PN_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.PN_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.PN_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.PN_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.PN_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.PN_Exit = new System.Windows.Forms.ToolStripButton();
            this.tabItemNhapKho = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlNhapKho)).BeginInit();
            this.tabControlNhapKho.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanelLoaiPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoaiPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLoaiPhieuNhap)).BeginInit();
            this.bindingLoaiPhieuNhap.SuspendLayout();
            this.navigationPaneThaoTac.SuspendLayout();
            this.navigationPanePanelDuyetDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeLoNhap)).BeginInit();
            this.navigationPanePanelThaoTac.SuspendLayout();
            this.groupLoaiPhieuNhap.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LPN_dpNgaySua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LPN_dpNgayLap)).BeginInit();
            this.groupLoPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpNgayLoNhap)).BeginInit();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoPN_dpNgaySua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoPN_dpNgayLap)).BeginInit();
            this.groupPhieuPhap.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PN_dpNgaySua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PN_dpNgayLap)).BeginInit();
            this.expandablePanelCauHinh.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanelLoPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLoPhieuNhap)).BeginInit();
            this.bindingLoPhieuNhap.SuspendLayout();
            this.groupPanelPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPhieuNhap)).BeginInit();
            this.bindingPhieuNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlNhapKho
            // 
            this.tabControlNhapKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControlNhapKho.CanReorderTabs = true;
            this.tabControlNhapKho.CloseButtonVisible = true;
            this.tabControlNhapKho.Controls.Add(this.tabControlPanel2);
            this.tabControlNhapKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlNhapKho.Location = new System.Drawing.Point(0, 0);
            this.tabControlNhapKho.Name = "tabControlNhapKho";
            this.tabControlNhapKho.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControlNhapKho.SelectedTabIndex = 0;
            this.tabControlNhapKho.Size = new System.Drawing.Size(1354, 692);
            this.tabControlNhapKho.TabIndex = 12;
            this.tabControlNhapKho.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControlNhapKho.Tabs.Add(this.tabItemNhapKho);
            this.tabControlNhapKho.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.groupPanelLoaiPhieuNhap);
            this.tabControlPanel2.Controls.Add(this.navigationPaneThaoTac);
            this.tabControlPanel2.Controls.Add(this.expandablePanelCauHinh);
            this.tabControlPanel2.Controls.Add(this.groupPanelLoPhieuNhap);
            this.tabControlPanel2.Controls.Add(this.groupPanelPhieuNhap);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1354, 666);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItemNhapKho;
            // 
            // groupPanelLoaiPhieuNhap
            // 
            this.groupPanelLoaiPhieuNhap.BackColor = System.Drawing.Color.Transparent;
            this.groupPanelLoaiPhieuNhap.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelLoaiPhieuNhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelLoaiPhieuNhap.Controls.Add(this.gridLoaiPhieuNhap);
            this.groupPanelLoaiPhieuNhap.Controls.Add(this.bindingLoaiPhieuNhap);
            this.groupPanelLoaiPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanelLoaiPhieuNhap.Location = new System.Drawing.Point(259, 1);
            this.groupPanelLoaiPhieuNhap.Name = "groupPanelLoaiPhieuNhap";
            this.groupPanelLoaiPhieuNhap.Size = new System.Drawing.Size(1094, 638);
            // 
            // 
            // 
            this.groupPanelLoaiPhieuNhap.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelLoaiPhieuNhap.Style.BackColorGradientAngle = 90;
            this.groupPanelLoaiPhieuNhap.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelLoaiPhieuNhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoaiPhieuNhap.Style.BorderBottomWidth = 1;
            this.groupPanelLoaiPhieuNhap.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelLoaiPhieuNhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoaiPhieuNhap.Style.BorderLeftWidth = 1;
            this.groupPanelLoaiPhieuNhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoaiPhieuNhap.Style.BorderRightWidth = 1;
            this.groupPanelLoaiPhieuNhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoaiPhieuNhap.Style.BorderTopWidth = 1;
            this.groupPanelLoaiPhieuNhap.Style.Class = "";
            this.groupPanelLoaiPhieuNhap.Style.CornerDiameter = 4;
            this.groupPanelLoaiPhieuNhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelLoaiPhieuNhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelLoaiPhieuNhap.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelLoaiPhieuNhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelLoaiPhieuNhap.StyleMouseDown.Class = "";
            this.groupPanelLoaiPhieuNhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelLoaiPhieuNhap.StyleMouseOver.Class = "";
            this.groupPanelLoaiPhieuNhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelLoaiPhieuNhap.TabIndex = 1;
            this.groupPanelLoaiPhieuNhap.Text = "Loại Phiếu Nhập";
            this.groupPanelLoaiPhieuNhap.TitleImage = global::QuanLy_KeToan.Properties.Resources.Loaiphieunhap;
            this.groupPanelLoaiPhieuNhap.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // gridLoaiPhieuNhap
            // 
            this.gridLoaiPhieuNhap.AllowUserToAddRows = false;
            this.gridLoaiPhieuNhap.AllowUserToOrderColumns = true;
            this.gridLoaiPhieuNhap.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoaiPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLoaiPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLoaiPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMLPN,
            this.ColTLPN,
            this.NL,
            this.NgL,
            this.NS,
            this.NgS});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLoaiPhieuNhap.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridLoaiPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLoaiPhieuNhap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridLoaiPhieuNhap.Location = new System.Drawing.Point(0, 25);
            this.gridLoaiPhieuNhap.Name = "gridLoaiPhieuNhap";
            this.gridLoaiPhieuNhap.Size = new System.Drawing.Size(1088, 568);
            this.gridLoaiPhieuNhap.TabIndex = 0;
            this.gridLoaiPhieuNhap.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridLoaiPhieuNhap_CellBeginEdit);
            this.gridLoaiPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoaiPhieuNhap_CellClick);
            this.gridLoaiPhieuNhap.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoaiPhieuNhap_RowEnter);
            // 
            // ColMLPN
            // 
            this.ColMLPN.DataPropertyName = "MaLoaiPhieuNhap";
            this.ColMLPN.HeaderText = "Mã Loại PN";
            this.ColMLPN.Name = "ColMLPN";
            // 
            // ColTLPN
            // 
            this.ColTLPN.DataPropertyName = "TenLoaiPhieuNhap";
            this.ColTLPN.HeaderText = "Tên Loại PN";
            this.ColTLPN.Name = "ColTLPN";
            this.ColTLPN.Width = 200;
            // 
            // NL
            // 
            // 
            // 
            // 
            this.NL.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.NL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NL.DataPropertyName = "NgayLap";
            this.NL.HeaderText = "Ngày Lập";
            this.NL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.NL.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NL.MonthCalendar.BackgroundStyle.Class = "";
            this.NL.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.NL.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.NL.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NL.MonthCalendar.DisplayMonth = new System.DateTime(2012, 4, 1, 0, 0, 0, 0);
            this.NL.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NL.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NL.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.NL.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NL.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NL.Name = "NL";
            // 
            // NgL
            // 
            this.NgL.DataPropertyName = "NguoiLap";
            this.NgL.DropDownHeight = 106;
            this.NgL.DropDownWidth = 121;
            this.NgL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NgL.HeaderText = "Người Lập";
            this.NgL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NgL.IntegralHeight = false;
            this.NgL.ItemHeight = 15;
            this.NgL.Name = "NgL";
            this.NgL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NgL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // NS
            // 
            // 
            // 
            // 
            this.NS.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.NS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NS.DataPropertyName = "NgaySua";
            this.NS.HeaderText = "Ngày Sửa";
            this.NS.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.NS.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NS.MonthCalendar.BackgroundStyle.Class = "";
            this.NS.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.NS.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.NS.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NS.MonthCalendar.DisplayMonth = new System.DateTime(2012, 4, 1, 0, 0, 0, 0);
            this.NS.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NS.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NS.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.NS.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NS.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NS.Name = "NS";
            // 
            // NgS
            // 
            this.NgS.DataPropertyName = "NguoiSua";
            this.NgS.DropDownHeight = 106;
            this.NgS.DropDownWidth = 121;
            this.NgS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NgS.HeaderText = "Người Sửa";
            this.NgS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NgS.IntegralHeight = false;
            this.NgS.ItemHeight = 15;
            this.NgS.Name = "NgS";
            this.NgS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NgS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // bindingLoaiPhieuNhap
            // 
            this.bindingLoaiPhieuNhap.AddNewItem = null;
            this.bindingLoaiPhieuNhap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bindingLoaiPhieuNhap.CountItem = this.bindingNavigatorCountItem2;
            this.bindingLoaiPhieuNhap.CountItemFormat = "của {0}";
            this.bindingLoaiPhieuNhap.DeleteItem = null;
            this.bindingLoaiPhieuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem2,
            this.bindingNavigatorMovePreviousItem2,
            this.bindingNavigatorSeparator6,
            this.positionLoaiPhieuNhap,
            this.bindingNavigatorCountItem2,
            this.bindingNavigatorSeparator7,
            this.bindingNavigatorMoveNextItem2,
            this.bindingNavigatorMoveLastItem2,
            this.bindingNavigatorSeparator8,
            this.LPN_Refresh,
            this.toolStripSeparator14,
            this.LPN_Add,
            this.toolStripSeparator15,
            this.LPN_Delete,
            this.toolStripSeparator16,
            this.LPN_Save,
            this.toolStripSeparator17,
            this.LPN_Cancel,
            this.toolStripSeparator18,
            this.LPN_Exit});
            this.bindingLoaiPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.bindingLoaiPhieuNhap.MoveFirstItem = this.bindingNavigatorMoveFirstItem2;
            this.bindingLoaiPhieuNhap.MoveLastItem = this.bindingNavigatorMoveLastItem2;
            this.bindingLoaiPhieuNhap.MoveNextItem = this.bindingNavigatorMoveNextItem2;
            this.bindingLoaiPhieuNhap.MovePreviousItem = this.bindingNavigatorMovePreviousItem2;
            this.bindingLoaiPhieuNhap.Name = "bindingLoaiPhieuNhap";
            this.bindingLoaiPhieuNhap.PositionItem = this.positionLoaiPhieuNhap;
            this.bindingLoaiPhieuNhap.Size = new System.Drawing.Size(1088, 25);
            this.bindingLoaiPhieuNhap.TabIndex = 1;
            // 
            // bindingNavigatorCountItem2
            // 
            this.bindingNavigatorCountItem2.Name = "bindingNavigatorCountItem2";
            this.bindingNavigatorCountItem2.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem2.Text = "của {0}";
            this.bindingNavigatorCountItem2.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem2
            // 
            this.bindingNavigatorMoveFirstItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem2.Image")));
            this.bindingNavigatorMoveFirstItem2.Name = "bindingNavigatorMoveFirstItem2";
            this.bindingNavigatorMoveFirstItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem2.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem2
            // 
            this.bindingNavigatorMovePreviousItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem2.Image")));
            this.bindingNavigatorMovePreviousItem2.Name = "bindingNavigatorMovePreviousItem2";
            this.bindingNavigatorMovePreviousItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem2.Text = "Move previous";
            // 
            // bindingNavigatorSeparator6
            // 
            this.bindingNavigatorSeparator6.Name = "bindingNavigatorSeparator6";
            this.bindingNavigatorSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // positionLoaiPhieuNhap
            // 
            this.positionLoaiPhieuNhap.AccessibleName = "Position";
            this.positionLoaiPhieuNhap.AutoSize = false;
            this.positionLoaiPhieuNhap.Name = "positionLoaiPhieuNhap";
            this.positionLoaiPhieuNhap.Size = new System.Drawing.Size(50, 23);
            this.positionLoaiPhieuNhap.Text = "0";
            this.positionLoaiPhieuNhap.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator7
            // 
            this.bindingNavigatorSeparator7.Name = "bindingNavigatorSeparator7";
            this.bindingNavigatorSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem2
            // 
            this.bindingNavigatorMoveNextItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem2.Image")));
            this.bindingNavigatorMoveNextItem2.Name = "bindingNavigatorMoveNextItem2";
            this.bindingNavigatorMoveNextItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem2.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem2
            // 
            this.bindingNavigatorMoveLastItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem2.Image")));
            this.bindingNavigatorMoveLastItem2.Name = "bindingNavigatorMoveLastItem2";
            this.bindingNavigatorMoveLastItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem2.Text = "Move last";
            // 
            // bindingNavigatorSeparator8
            // 
            this.bindingNavigatorSeparator8.Name = "bindingNavigatorSeparator8";
            this.bindingNavigatorSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // LPN_Refresh
            // 
            this.LPN_Refresh.Image = global::QuanLy_KeToan.Properties.Resources.refresh;
            this.LPN_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LPN_Refresh.Name = "LPN_Refresh";
            this.LPN_Refresh.Size = new System.Drawing.Size(66, 22);
            this.LPN_Refresh.Text = "&Refresh";
            this.LPN_Refresh.Click += new System.EventHandler(this.LPN_Refresh_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // LPN_Add
            // 
            this.LPN_Add.Image = ((System.Drawing.Image)(resources.GetObject("LPN_Add.Image")));
            this.LPN_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LPN_Add.Name = "LPN_Add";
            this.LPN_Add.Size = new System.Drawing.Size(49, 22);
            this.LPN_Add.Text = "&Add";
            this.LPN_Add.Click += new System.EventHandler(this.LPN_Add_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // LPN_Delete
            // 
            this.LPN_Delete.Image = global::QuanLy_KeToan.Properties.Resources.delete;
            this.LPN_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LPN_Delete.Name = "LPN_Delete";
            this.LPN_Delete.Size = new System.Drawing.Size(60, 22);
            this.LPN_Delete.Text = "&Delete";
            this.LPN_Delete.Click += new System.EventHandler(this.LPN_Delete_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // LPN_Save
            // 
            this.LPN_Save.Image = ((System.Drawing.Image)(resources.GetObject("LPN_Save.Image")));
            this.LPN_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LPN_Save.Name = "LPN_Save";
            this.LPN_Save.Size = new System.Drawing.Size(51, 22);
            this.LPN_Save.Text = "&Save";
            this.LPN_Save.Click += new System.EventHandler(this.LPN_Save_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // LPN_Cancel
            // 
            this.LPN_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("LPN_Cancel.Image")));
            this.LPN_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LPN_Cancel.Name = "LPN_Cancel";
            this.LPN_Cancel.Size = new System.Drawing.Size(63, 22);
            this.LPN_Cancel.Text = "&Cancel";
            this.LPN_Cancel.Click += new System.EventHandler(this.LPN_Cancel_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // LPN_Exit
            // 
            this.LPN_Exit.Image = global::QuanLy_KeToan.Properties.Resources.thoat;
            this.LPN_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LPN_Exit.Name = "LPN_Exit";
            this.LPN_Exit.Size = new System.Drawing.Size(45, 22);
            this.LPN_Exit.Text = "&Exit";
            this.LPN_Exit.Click += new System.EventHandler(this.LPN_Exit_Click);
            // 
            // navigationPaneThaoTac
            // 
            this.navigationPaneThaoTac.CanCollapse = true;
            this.navigationPaneThaoTac.Controls.Add(this.navigationPanePanelDuyetDanhMuc);
            this.navigationPaneThaoTac.Controls.Add(this.navigationPanePanelTimLKiem);
            this.navigationPaneThaoTac.Controls.Add(this.navigationPanePanelThaoTac);
            this.navigationPaneThaoTac.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigationPaneThaoTac.ItemPaddingBottom = 2;
            this.navigationPaneThaoTac.ItemPaddingTop = 2;
            this.navigationPaneThaoTac.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnDuyetDanhMuc,
            this.buttonItemThaoTac,
            this.buttonItemTim});
            this.navigationPaneThaoTac.Location = new System.Drawing.Point(1, 1);
            this.navigationPaneThaoTac.Name = "navigationPaneThaoTac";
            this.navigationPaneThaoTac.NavigationBarHeight = 113;
            this.navigationPaneThaoTac.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPaneThaoTac.Size = new System.Drawing.Size(258, 638);
            this.navigationPaneThaoTac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPaneThaoTac.TabIndex = 2;
            // 
            // 
            // 
            this.navigationPaneThaoTac.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPaneThaoTac.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPaneThaoTac.TitlePanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationPaneThaoTac.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.navigationPaneThaoTac.TitlePanel.Name = "panelTitle";
            this.navigationPaneThaoTac.TitlePanel.Size = new System.Drawing.Size(256, 24);
            this.navigationPaneThaoTac.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.navigationPaneThaoTac.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.navigationPaneThaoTac.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.navigationPaneThaoTac.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPaneThaoTac.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.navigationPaneThaoTac.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.navigationPaneThaoTac.TitlePanel.Style.GradientAngle = 90;
            this.navigationPaneThaoTac.TitlePanel.Style.MarginLeft = 4;
            this.navigationPaneThaoTac.TitlePanel.TabIndex = 0;
            this.navigationPaneThaoTac.TitlePanel.Text = "DUYỆT DANH MỤC";
            // 
            // navigationPanePanelDuyetDanhMuc
            // 
            this.navigationPanePanelDuyetDanhMuc.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanelDuyetDanhMuc.Controls.Add(this.advTreeLoNhap);
            this.navigationPanePanelDuyetDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanelDuyetDanhMuc.Location = new System.Drawing.Point(1, 25);
            this.navigationPanePanelDuyetDanhMuc.Name = "navigationPanePanelDuyetDanhMuc";
            this.navigationPanePanelDuyetDanhMuc.ParentItem = this.btnDuyetDanhMuc;
            this.navigationPanePanelDuyetDanhMuc.Size = new System.Drawing.Size(256, 499);
            this.navigationPanePanelDuyetDanhMuc.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanelDuyetDanhMuc.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanelDuyetDanhMuc.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanelDuyetDanhMuc.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanelDuyetDanhMuc.Style.GradientAngle = 90;
            this.navigationPanePanelDuyetDanhMuc.TabIndex = 2;
            // 
            // advTreeLoNhap
            // 
            this.advTreeLoNhap.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeLoNhap.AllowDrop = true;
            this.advTreeLoNhap.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeLoNhap.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeLoNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeLoNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeLoNhap.GridLinesColor = System.Drawing.Color.DodgerBlue;
            this.advTreeLoNhap.HotTracking = true;
            this.advTreeLoNhap.Location = new System.Drawing.Point(0, 0);
            this.advTreeLoNhap.Name = "advTreeLoNhap";
            this.advTreeLoNhap.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.root_node});
            this.advTreeLoNhap.NodesConnector = this.nodeConnector1;
            this.advTreeLoNhap.NodeStyle = this.elementStyle2;
            this.advTreeLoNhap.NodeStyleMouseOver = this.elementStyle3;
            this.advTreeLoNhap.NodeStyleSelected = this.elementStyle4;
            this.advTreeLoNhap.PathSeparator = ";";
            this.advTreeLoNhap.Size = new System.Drawing.Size(256, 499);
            this.advTreeLoNhap.Styles.Add(this.elementStyle1);
            this.advTreeLoNhap.Styles.Add(this.elementStyle2);
            this.advTreeLoNhap.Styles.Add(this.elementStyle3);
            this.advTreeLoNhap.Styles.Add(this.elementStyle4);
            this.advTreeLoNhap.TabIndex = 0;
            this.advTreeLoNhap.Text = "advTree1";
            this.advTreeLoNhap.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTreeLoNhap_AfterNodeSelect);
            // 
            // root_node
            // 
            this.root_node.Expanded = true;
            this.root_node.Image = global::QuanLy_KeToan.Properties.Resources.khohang;
            this.root_node.Name = "root_node";
            this.root_node.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.nodeLoaiPhieuNhap,
            this.nodeLoPhieuNhap});
            this.root_node.Text = "Kho Hàng";
            // 
            // nodeLoaiPhieuNhap
            // 
            this.nodeLoaiPhieuNhap.Expanded = true;
            this.nodeLoaiPhieuNhap.Image = global::QuanLy_KeToan.Properties.Resources.Loaiphieunhap;
            this.nodeLoaiPhieuNhap.Name = "nodeLoaiPhieuNhap";
            this.nodeLoaiPhieuNhap.Text = "Loại Phiếu Nhập";
            // 
            // nodeLoPhieuNhap
            // 
            this.nodeLoPhieuNhap.Expanded = true;
            this.nodeLoPhieuNhap.Image = global::QuanLy_KeToan.Properties.Resources.Lophieunhap;
            this.nodeLoPhieuNhap.Name = "nodeLoPhieuNhap";
            this.nodeLoPhieuNhap.Text = "Lô Phiếu Nhập";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(176)))), ((int)(((byte)(120)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.Class = "";
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Description = "Orange";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle3
            // 
            this.elementStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle3.BackColorGradientAngle = 90;
            this.elementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderBottomWidth = 1;
            this.elementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderLeftWidth = 1;
            this.elementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderRightWidth = 1;
            this.elementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderTopWidth = 1;
            this.elementStyle3.Class = "";
            this.elementStyle3.CornerDiameter = 4;
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Description = "Blue";
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.PaddingBottom = 1;
            this.elementStyle3.PaddingLeft = 1;
            this.elementStyle3.PaddingRight = 1;
            this.elementStyle3.PaddingTop = 1;
            this.elementStyle3.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(151)))));
            this.elementStyle4.BackColorGradientAngle = 90;
            this.elementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderBottomWidth = 1;
            this.elementStyle4.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderLeftWidth = 1;
            this.elementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderRightWidth = 1;
            this.elementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderTopWidth = 1;
            this.elementStyle4.Class = "";
            this.elementStyle4.CornerDiameter = 4;
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Description = "Red";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // btnDuyetDanhMuc
            // 
            this.btnDuyetDanhMuc.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDuyetDanhMuc.Checked = true;
            this.btnDuyetDanhMuc.Image = global::QuanLy_KeToan.Properties.Resources.duyet;
            this.btnDuyetDanhMuc.Name = "btnDuyetDanhMuc";
            this.btnDuyetDanhMuc.OptionGroup = "navBar";
            this.btnDuyetDanhMuc.Text = "DUYỆT DANH MỤC";
            // 
            // navigationPanePanelTimLKiem
            // 
            this.navigationPanePanelTimLKiem.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanelTimLKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanelTimLKiem.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanelTimLKiem.Name = "navigationPanePanelTimLKiem";
            this.navigationPanePanelTimLKiem.ParentItem = this.buttonItemTim;
            this.navigationPanePanelTimLKiem.Size = new System.Drawing.Size(256, 523);
            this.navigationPanePanelTimLKiem.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanelTimLKiem.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanelTimLKiem.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanelTimLKiem.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanelTimLKiem.Style.GradientAngle = 90;
            this.navigationPanePanelTimLKiem.TabIndex = 4;
            // 
            // buttonItemTim
            // 
            this.buttonItemTim.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemTim.Image = global::QuanLy_KeToan.Properties.Resources.search_icon;
            this.buttonItemTim.Name = "buttonItemTim";
            this.buttonItemTim.OptionGroup = "navBar";
            this.buttonItemTim.Text = "TÌM KIẾM";
            // 
            // navigationPanePanelThaoTac
            // 
            this.navigationPanePanelThaoTac.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanelThaoTac.Controls.Add(this.groupLoaiPhieuNhap);
            this.navigationPanePanelThaoTac.Controls.Add(this.groupLoPhieuNhap);
            this.navigationPanePanelThaoTac.Controls.Add(this.groupPhieuPhap);
            this.navigationPanePanelThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanelThaoTac.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanelThaoTac.Name = "navigationPanePanelThaoTac";
            this.navigationPanePanelThaoTac.ParentItem = this.buttonItemThaoTac;
            this.navigationPanePanelThaoTac.Size = new System.Drawing.Size(256, 523);
            this.navigationPanePanelThaoTac.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanelThaoTac.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanelThaoTac.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanelThaoTac.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanelThaoTac.Style.GradientAngle = 90;
            this.navigationPanePanelThaoTac.TabIndex = 3;
            // 
            // groupLoaiPhieuNhap
            // 
            this.groupLoaiPhieuNhap.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupLoaiPhieuNhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupLoaiPhieuNhap.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Yellow;
            this.groupLoaiPhieuNhap.Controls.Add(this.groupPanel5);
            this.groupLoaiPhieuNhap.Controls.Add(this.labelX6);
            this.groupLoaiPhieuNhap.Controls.Add(this.LPN_cmbNguoiSua);
            this.groupLoaiPhieuNhap.Controls.Add(this.LPN_dpNgaySua);
            this.groupLoaiPhieuNhap.Controls.Add(this.labelX5);
            this.groupLoaiPhieuNhap.Controls.Add(this.LPN_cmbNguoiLap);
            this.groupLoaiPhieuNhap.Controls.Add(this.labelX4);
            this.groupLoaiPhieuNhap.Controls.Add(this.LPN_dpNgayLap);
            this.groupLoaiPhieuNhap.Controls.Add(this.txtTenLoaiPhieuNhap);
            this.groupLoaiPhieuNhap.Controls.Add(this.txtMaLoaiPhieuNhap);
            this.groupLoaiPhieuNhap.Controls.Add(this.labelX3);
            this.groupLoaiPhieuNhap.Controls.Add(this.labelX2);
            this.groupLoaiPhieuNhap.Controls.Add(this.labelX1);
            this.groupLoaiPhieuNhap.Location = new System.Drawing.Point(1, 0);
            this.groupLoaiPhieuNhap.Name = "groupLoaiPhieuNhap";
            this.groupLoaiPhieuNhap.Size = new System.Drawing.Size(254, 496);
            // 
            // 
            // 
            this.groupLoaiPhieuNhap.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(178)))));
            this.groupLoaiPhieuNhap.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(69)))));
            this.groupLoaiPhieuNhap.Style.BackColorGradientAngle = 90;
            this.groupLoaiPhieuNhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoaiPhieuNhap.Style.BorderBottomWidth = 1;
            this.groupLoaiPhieuNhap.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(147)))), ((int)(((byte)(17)))));
            this.groupLoaiPhieuNhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoaiPhieuNhap.Style.BorderLeftWidth = 1;
            this.groupLoaiPhieuNhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoaiPhieuNhap.Style.BorderRightWidth = 1;
            this.groupLoaiPhieuNhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoaiPhieuNhap.Style.BorderTopWidth = 1;
            this.groupLoaiPhieuNhap.Style.Class = "";
            this.groupLoaiPhieuNhap.Style.CornerDiameter = 4;
            this.groupLoaiPhieuNhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupLoaiPhieuNhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupLoaiPhieuNhap.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.groupLoaiPhieuNhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupLoaiPhieuNhap.StyleMouseDown.Class = "";
            this.groupLoaiPhieuNhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupLoaiPhieuNhap.StyleMouseOver.Class = "";
            this.groupLoaiPhieuNhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupLoaiPhieuNhap.TabIndex = 2;
            this.groupLoaiPhieuNhap.Text = "Thêm/Sửa Loại Phiếu Nhập";
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.btn_LPN_Huy);
            this.groupPanel5.Controls.Add(this.btn_LPN_Luu);
            this.groupPanel5.Controls.Add(this.btn_LPN_Sua);
            this.groupPanel5.Controls.Add(this.btn_LPN_Them);
            this.groupPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel5.Location = new System.Drawing.Point(0, 426);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(248, 49);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.Class = "";
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.Class = "";
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.Class = "";
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 15;
            this.groupPanel5.Text = "ToolBar Edit";
            // 
            // btn_LPN_Huy
            // 
            this.btn_LPN_Huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LPN_Huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LPN_Huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_LPN_Huy.Image")));
            this.btn_LPN_Huy.Location = new System.Drawing.Point(186, 2);
            this.btn_LPN_Huy.Name = "btn_LPN_Huy";
            this.btn_LPN_Huy.Size = new System.Drawing.Size(56, 23);
            this.btn_LPN_Huy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LPN_Huy.TabIndex = 13;
            this.btn_LPN_Huy.Text = "&Hủy";
            this.btn_LPN_Huy.Click += new System.EventHandler(this.btn_LPN_Huy_Click);
            // 
            // btn_LPN_Luu
            // 
            this.btn_LPN_Luu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LPN_Luu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LPN_Luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_LPN_Luu.Image")));
            this.btn_LPN_Luu.Location = new System.Drawing.Point(124, 3);
            this.btn_LPN_Luu.Name = "btn_LPN_Luu";
            this.btn_LPN_Luu.Size = new System.Drawing.Size(56, 23);
            this.btn_LPN_Luu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LPN_Luu.TabIndex = 12;
            this.btn_LPN_Luu.Text = "&Lưu";
            this.btn_LPN_Luu.Click += new System.EventHandler(this.btn_LPN_Luu_Click);
            // 
            // btn_LPN_Sua
            // 
            this.btn_LPN_Sua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LPN_Sua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LPN_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_LPN_Sua.Image")));
            this.btn_LPN_Sua.Location = new System.Drawing.Point(62, 3);
            this.btn_LPN_Sua.Name = "btn_LPN_Sua";
            this.btn_LPN_Sua.Size = new System.Drawing.Size(56, 23);
            this.btn_LPN_Sua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LPN_Sua.TabIndex = 11;
            this.btn_LPN_Sua.Text = "&Sửa";
            this.btn_LPN_Sua.Click += new System.EventHandler(this.btn_LPN_Sua_Click);
            // 
            // btn_LPN_Them
            // 
            this.btn_LPN_Them.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LPN_Them.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LPN_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_LPN_Them.Image")));
            this.btn_LPN_Them.Location = new System.Drawing.Point(0, 3);
            this.btn_LPN_Them.Name = "btn_LPN_Them";
            this.btn_LPN_Them.Size = new System.Drawing.Size(56, 23);
            this.btn_LPN_Them.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LPN_Them.TabIndex = 10;
            this.btn_LPN_Them.Text = "&Thêm";
            this.btn_LPN_Them.Click += new System.EventHandler(this.btn_LPN_Them_Click);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(-1, 233);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(57, 15);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "<b>Người Sửa:</b>";
            // 
            // LPN_cmbNguoiSua
            // 
            this.LPN_cmbNguoiSua.DisplayMember = "Text";
            this.LPN_cmbNguoiSua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LPN_cmbNguoiSua.FocusHighlightEnabled = true;
            this.LPN_cmbNguoiSua.FormattingEnabled = true;
            this.LPN_cmbNguoiSua.ItemHeight = 14;
            this.LPN_cmbNguoiSua.Location = new System.Drawing.Point(110, 228);
            this.LPN_cmbNguoiSua.Name = "LPN_cmbNguoiSua";
            this.LPN_cmbNguoiSua.Size = new System.Drawing.Size(135, 20);
            this.LPN_cmbNguoiSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LPN_cmbNguoiSua.TabIndex = 10;
            // 
            // LPN_dpNgaySua
            // 
            // 
            // 
            // 
            this.LPN_dpNgaySua.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LPN_dpNgaySua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgaySua.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.LPN_dpNgaySua.ButtonDropDown.Visible = true;
            this.LPN_dpNgaySua.FocusHighlightEnabled = true;
            this.LPN_dpNgaySua.IsPopupCalendarOpen = false;
            this.LPN_dpNgaySua.Location = new System.Drawing.Point(110, 176);
            // 
            // 
            // 
            this.LPN_dpNgaySua.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LPN_dpNgaySua.MonthCalendar.BackgroundStyle.Class = "";
            this.LPN_dpNgaySua.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgaySua.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.LPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgaySua.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.LPN_dpNgaySua.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.LPN_dpNgaySua.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.LPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.LPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.LPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.LPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgaySua.MonthCalendar.TodayButtonVisible = true;
            this.LPN_dpNgaySua.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.LPN_dpNgaySua.Name = "LPN_dpNgaySua";
            this.LPN_dpNgaySua.Size = new System.Drawing.Size(135, 20);
            this.LPN_dpNgaySua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LPN_dpNgaySua.TabIndex = 9;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(0, 181);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(54, 15);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "<b>Ngày Sửa:</b>";
            // 
            // LPN_cmbNguoiLap
            // 
            this.LPN_cmbNguoiLap.DisplayMember = "Text";
            this.LPN_cmbNguoiLap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LPN_cmbNguoiLap.FocusHighlightEnabled = true;
            this.LPN_cmbNguoiLap.FormattingEnabled = true;
            this.LPN_cmbNguoiLap.ItemHeight = 14;
            this.LPN_cmbNguoiLap.Location = new System.Drawing.Point(110, 133);
            this.LPN_cmbNguoiLap.Name = "LPN_cmbNguoiLap";
            this.LPN_cmbNguoiLap.Size = new System.Drawing.Size(135, 20);
            this.LPN_cmbNguoiLap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LPN_cmbNguoiLap.TabIndex = 7;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(0, 138);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 15);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "<b>Người Lập:</b>";
            // 
            // LPN_dpNgayLap
            // 
            // 
            // 
            // 
            this.LPN_dpNgayLap.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LPN_dpNgayLap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgayLap.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.LPN_dpNgayLap.ButtonDropDown.Visible = true;
            this.LPN_dpNgayLap.FocusHighlightEnabled = true;
            this.LPN_dpNgayLap.IsPopupCalendarOpen = false;
            this.LPN_dpNgayLap.Location = new System.Drawing.Point(110, 90);
            // 
            // 
            // 
            this.LPN_dpNgayLap.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LPN_dpNgayLap.MonthCalendar.BackgroundStyle.Class = "";
            this.LPN_dpNgayLap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgayLap.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.LPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgayLap.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.LPN_dpNgayLap.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.LPN_dpNgayLap.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.LPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.LPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.LPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.LPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LPN_dpNgayLap.MonthCalendar.TodayButtonVisible = true;
            this.LPN_dpNgayLap.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.LPN_dpNgayLap.Name = "LPN_dpNgayLap";
            this.LPN_dpNgayLap.Size = new System.Drawing.Size(135, 20);
            this.LPN_dpNgayLap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LPN_dpNgayLap.TabIndex = 5;
            // 
            // txtTenLoaiPhieuNhap
            // 
            // 
            // 
            // 
            this.txtTenLoaiPhieuNhap.Border.Class = "TextBoxBorder";
            this.txtTenLoaiPhieuNhap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenLoaiPhieuNhap.FocusHighlightEnabled = true;
            this.txtTenLoaiPhieuNhap.Location = new System.Drawing.Point(110, 56);
            this.txtTenLoaiPhieuNhap.Name = "txtTenLoaiPhieuNhap";
            this.txtTenLoaiPhieuNhap.Size = new System.Drawing.Size(135, 20);
            this.txtTenLoaiPhieuNhap.TabIndex = 4;
            // 
            // txtMaLoaiPhieuNhap
            // 
            // 
            // 
            // 
            this.txtMaLoaiPhieuNhap.Border.Class = "TextBoxBorder";
            this.txtMaLoaiPhieuNhap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaLoaiPhieuNhap.FocusHighlightEnabled = true;
            this.txtMaLoaiPhieuNhap.Location = new System.Drawing.Point(110, 18);
            this.txtMaLoaiPhieuNhap.Name = "txtMaLoaiPhieuNhap";
            this.txtMaLoaiPhieuNhap.Size = new System.Drawing.Size(135, 20);
            this.txtMaLoaiPhieuNhap.TabIndex = 3;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(0, 95);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(53, 15);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "<b>Ngày Lập:</b>";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(-1, 61);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(112, 15);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "<b>Tên Loại Phiếu Nhập:</b>";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(0, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(108, 15);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "<b>Mã Loại Phiếu Nhập:</b>";
            // 
            // groupLoPhieuNhap
            // 
            this.groupLoPhieuNhap.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupLoPhieuNhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupLoPhieuNhap.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Yellow;
            this.groupLoPhieuNhap.Controls.Add(this.txtMoTa);
            this.groupLoPhieuNhap.Controls.Add(this.labelX19);
            this.groupLoPhieuNhap.Controls.Add(this.dpNgayLoNhap);
            this.groupLoPhieuNhap.Controls.Add(this.cmbMaLoHDMua);
            this.groupLoPhieuNhap.Controls.Add(this.groupPanel4);
            this.groupLoPhieuNhap.Controls.Add(this.labelX7);
            this.groupLoPhieuNhap.Controls.Add(this.LoPN_cmbNguoiSua);
            this.groupLoPhieuNhap.Controls.Add(this.LoPN_dpNgaySua);
            this.groupLoPhieuNhap.Controls.Add(this.labelX8);
            this.groupLoPhieuNhap.Controls.Add(this.LoPN_cmbNguoiLap);
            this.groupLoPhieuNhap.Controls.Add(this.labelX9);
            this.groupLoPhieuNhap.Controls.Add(this.LoPN_dpNgayLap);
            this.groupLoPhieuNhap.Controls.Add(this.labelX10);
            this.groupLoPhieuNhap.Controls.Add(this.labelX11);
            this.groupLoPhieuNhap.Controls.Add(this.labelX12);
            this.groupLoPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.groupLoPhieuNhap.Name = "groupLoPhieuNhap";
            this.groupLoPhieuNhap.Size = new System.Drawing.Size(254, 496);
            // 
            // 
            // 
            this.groupLoPhieuNhap.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(178)))));
            this.groupLoPhieuNhap.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(69)))));
            this.groupLoPhieuNhap.Style.BackColorGradientAngle = 90;
            this.groupLoPhieuNhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoPhieuNhap.Style.BorderBottomWidth = 1;
            this.groupLoPhieuNhap.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(147)))), ((int)(((byte)(17)))));
            this.groupLoPhieuNhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoPhieuNhap.Style.BorderLeftWidth = 1;
            this.groupLoPhieuNhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoPhieuNhap.Style.BorderRightWidth = 1;
            this.groupLoPhieuNhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupLoPhieuNhap.Style.BorderTopWidth = 1;
            this.groupLoPhieuNhap.Style.Class = "";
            this.groupLoPhieuNhap.Style.CornerDiameter = 4;
            this.groupLoPhieuNhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupLoPhieuNhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupLoPhieuNhap.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.groupLoPhieuNhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupLoPhieuNhap.StyleMouseDown.Class = "";
            this.groupLoPhieuNhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupLoPhieuNhap.StyleMouseOver.Class = "";
            this.groupLoPhieuNhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupLoPhieuNhap.TabIndex = 3;
            this.groupLoPhieuNhap.Text = "Thêm/Sửa Lô Phiếu Nhập";
            // 
            // txtMoTa
            // 
            // 
            // 
            // 
            this.txtMoTa.Border.Class = "TextBoxBorder";
            this.txtMoTa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMoTa.FocusHighlightEnabled = true;
            this.txtMoTa.Location = new System.Drawing.Point(59, 89);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(184, 81);
            this.txtMoTa.TabIndex = 19;
            // 
            // labelX19
            // 
            this.labelX19.AutoSize = true;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.Class = "";
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(0, 90);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(36, 15);
            this.labelX19.TabIndex = 18;
            this.labelX19.Text = "<b>Mô Tả:</b>";
            // 
            // dpNgayLoNhap
            // 
            // 
            // 
            // 
            this.dpNgayLoNhap.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dpNgayLoNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dpNgayLoNhap.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dpNgayLoNhap.ButtonDropDown.Visible = true;
            this.dpNgayLoNhap.FocusHighlightEnabled = true;
            this.dpNgayLoNhap.IsPopupCalendarOpen = false;
            this.dpNgayLoNhap.Location = new System.Drawing.Point(110, 56);
            // 
            // 
            // 
            this.dpNgayLoNhap.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dpNgayLoNhap.MonthCalendar.BackgroundStyle.Class = "";
            this.dpNgayLoNhap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dpNgayLoNhap.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dpNgayLoNhap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dpNgayLoNhap.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.dpNgayLoNhap.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dpNgayLoNhap.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dpNgayLoNhap.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dpNgayLoNhap.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dpNgayLoNhap.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dpNgayLoNhap.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dpNgayLoNhap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dpNgayLoNhap.MonthCalendar.TodayButtonVisible = true;
            this.dpNgayLoNhap.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dpNgayLoNhap.Name = "dpNgayLoNhap";
            this.dpNgayLoNhap.Size = new System.Drawing.Size(135, 20);
            this.dpNgayLoNhap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dpNgayLoNhap.TabIndex = 17;
            // 
            // cmbMaLoHDMua
            // 
            this.cmbMaLoHDMua.DisplayMember = "Text";
            this.cmbMaLoHDMua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMaLoHDMua.FocusHighlightEnabled = true;
            this.cmbMaLoHDMua.FormattingEnabled = true;
            this.cmbMaLoHDMua.ItemHeight = 14;
            this.cmbMaLoHDMua.Location = new System.Drawing.Point(110, 18);
            this.cmbMaLoHDMua.Name = "cmbMaLoHDMua";
            this.cmbMaLoHDMua.Size = new System.Drawing.Size(138, 20);
            this.cmbMaLoHDMua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMaLoHDMua.TabIndex = 16;
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.btn_LoPN_Huy);
            this.groupPanel4.Controls.Add(this.btn_LoPN_Luu);
            this.groupPanel4.Controls.Add(this.btn_LoPN_Sua);
            this.groupPanel4.Controls.Add(this.btn_LoPN_Them);
            this.groupPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel4.Location = new System.Drawing.Point(0, 426);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(248, 49);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.Class = "";
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.Class = "";
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.Class = "";
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 15;
            this.groupPanel4.Text = "ToolBar Edit";
            // 
            // btn_LoPN_Huy
            // 
            this.btn_LoPN_Huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LoPN_Huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LoPN_Huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoPN_Huy.Image")));
            this.btn_LoPN_Huy.Location = new System.Drawing.Point(186, 2);
            this.btn_LoPN_Huy.Name = "btn_LoPN_Huy";
            this.btn_LoPN_Huy.Size = new System.Drawing.Size(56, 23);
            this.btn_LoPN_Huy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LoPN_Huy.TabIndex = 13;
            this.btn_LoPN_Huy.Text = "Hủy";
            this.btn_LoPN_Huy.Click += new System.EventHandler(this.btn_LoPN_Huy_Click);
            // 
            // btn_LoPN_Luu
            // 
            this.btn_LoPN_Luu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LoPN_Luu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LoPN_Luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoPN_Luu.Image")));
            this.btn_LoPN_Luu.Location = new System.Drawing.Point(124, 3);
            this.btn_LoPN_Luu.Name = "btn_LoPN_Luu";
            this.btn_LoPN_Luu.Size = new System.Drawing.Size(56, 23);
            this.btn_LoPN_Luu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LoPN_Luu.TabIndex = 12;
            this.btn_LoPN_Luu.Text = "Lưu";
            this.btn_LoPN_Luu.Click += new System.EventHandler(this.btn_LoPN_Luu_Click);
            // 
            // btn_LoPN_Sua
            // 
            this.btn_LoPN_Sua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LoPN_Sua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LoPN_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoPN_Sua.Image")));
            this.btn_LoPN_Sua.Location = new System.Drawing.Point(62, 3);
            this.btn_LoPN_Sua.Name = "btn_LoPN_Sua";
            this.btn_LoPN_Sua.Size = new System.Drawing.Size(56, 23);
            this.btn_LoPN_Sua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LoPN_Sua.TabIndex = 11;
            this.btn_LoPN_Sua.Text = "Sửa";
            this.btn_LoPN_Sua.Click += new System.EventHandler(this.btn_LoPN_Sua_Click);
            // 
            // btn_LoPN_Them
            // 
            this.btn_LoPN_Them.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_LoPN_Them.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_LoPN_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoPN_Them.Image")));
            this.btn_LoPN_Them.Location = new System.Drawing.Point(0, 3);
            this.btn_LoPN_Them.Name = "btn_LoPN_Them";
            this.btn_LoPN_Them.Size = new System.Drawing.Size(56, 23);
            this.btn_LoPN_Them.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_LoPN_Them.TabIndex = 10;
            this.btn_LoPN_Them.Text = "Thêm";
            this.btn_LoPN_Them.Click += new System.EventHandler(this.btn_LoPN_Them_Click);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(0, 320);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(57, 15);
            this.labelX7.TabIndex = 11;
            this.labelX7.Text = "<b>Người Sửa:</b>";
            // 
            // LoPN_cmbNguoiSua
            // 
            this.LoPN_cmbNguoiSua.DisplayMember = "Text";
            this.LoPN_cmbNguoiSua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LoPN_cmbNguoiSua.FocusHighlightEnabled = true;
            this.LoPN_cmbNguoiSua.FormattingEnabled = true;
            this.LoPN_cmbNguoiSua.ItemHeight = 14;
            this.LoPN_cmbNguoiSua.Location = new System.Drawing.Point(108, 315);
            this.LoPN_cmbNguoiSua.Name = "LoPN_cmbNguoiSua";
            this.LoPN_cmbNguoiSua.Size = new System.Drawing.Size(135, 20);
            this.LoPN_cmbNguoiSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoPN_cmbNguoiSua.TabIndex = 10;
            // 
            // LoPN_dpNgaySua
            // 
            // 
            // 
            // 
            this.LoPN_dpNgaySua.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LoPN_dpNgaySua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgaySua.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.LoPN_dpNgaySua.ButtonDropDown.Visible = true;
            this.LoPN_dpNgaySua.FocusHighlightEnabled = true;
            this.LoPN_dpNgaySua.IsPopupCalendarOpen = false;
            this.LoPN_dpNgaySua.Location = new System.Drawing.Point(108, 263);
            // 
            // 
            // 
            this.LoPN_dpNgaySua.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LoPN_dpNgaySua.MonthCalendar.BackgroundStyle.Class = "";
            this.LoPN_dpNgaySua.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgaySua.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.LoPN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgaySua.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.LoPN_dpNgaySua.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.LoPN_dpNgaySua.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LoPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.LoPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.LoPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.LoPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.LoPN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgaySua.MonthCalendar.TodayButtonVisible = true;
            this.LoPN_dpNgaySua.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.LoPN_dpNgaySua.Name = "LoPN_dpNgaySua";
            this.LoPN_dpNgaySua.Size = new System.Drawing.Size(135, 20);
            this.LoPN_dpNgaySua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoPN_dpNgaySua.TabIndex = 9;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(0, 268);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(54, 15);
            this.labelX8.TabIndex = 8;
            this.labelX8.Text = "<b>Ngày Sửa:</b>";
            // 
            // LoPN_cmbNguoiLap
            // 
            this.LoPN_cmbNguoiLap.DisplayMember = "Text";
            this.LoPN_cmbNguoiLap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LoPN_cmbNguoiLap.FocusHighlightEnabled = true;
            this.LoPN_cmbNguoiLap.FormattingEnabled = true;
            this.LoPN_cmbNguoiLap.ItemHeight = 14;
            this.LoPN_cmbNguoiLap.Location = new System.Drawing.Point(108, 220);
            this.LoPN_cmbNguoiLap.Name = "LoPN_cmbNguoiLap";
            this.LoPN_cmbNguoiLap.Size = new System.Drawing.Size(135, 20);
            this.LoPN_cmbNguoiLap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoPN_cmbNguoiLap.TabIndex = 7;
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(0, 225);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(56, 15);
            this.labelX9.TabIndex = 6;
            this.labelX9.Text = "<b>Người Lập:</b>";
            // 
            // LoPN_dpNgayLap
            // 
            // 
            // 
            // 
            this.LoPN_dpNgayLap.BackgroundStyle.Class = "DateTimeInputBackground";
            this.LoPN_dpNgayLap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgayLap.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.LoPN_dpNgayLap.ButtonDropDown.Visible = true;
            this.LoPN_dpNgayLap.FocusHighlightEnabled = true;
            this.LoPN_dpNgayLap.IsPopupCalendarOpen = false;
            this.LoPN_dpNgayLap.Location = new System.Drawing.Point(108, 177);
            // 
            // 
            // 
            this.LoPN_dpNgayLap.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LoPN_dpNgayLap.MonthCalendar.BackgroundStyle.Class = "";
            this.LoPN_dpNgayLap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgayLap.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.LoPN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgayLap.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.LoPN_dpNgayLap.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.LoPN_dpNgayLap.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.LoPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.LoPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.LoPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.LoPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.LoPN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LoPN_dpNgayLap.MonthCalendar.TodayButtonVisible = true;
            this.LoPN_dpNgayLap.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.LoPN_dpNgayLap.Name = "LoPN_dpNgayLap";
            this.LoPN_dpNgayLap.Size = new System.Drawing.Size(135, 20);
            this.LoPN_dpNgayLap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.LoPN_dpNgayLap.TabIndex = 5;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(0, 181);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(53, 15);
            this.labelX10.TabIndex = 2;
            this.labelX10.Text = "<b>Ngày Lập:</b>";
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(-1, 61);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(77, 15);
            this.labelX11.TabIndex = 1;
            this.labelX11.Text = "<b>Ngày Lô Nhập:</b>";
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(0, 23);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(77, 15);
            this.labelX12.TabIndex = 0;
            this.labelX12.Text = "<b>Mã Lô HĐMua:</b>";
            // 
            // groupPhieuPhap
            // 
            this.groupPhieuPhap.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPhieuPhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPhieuPhap.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Yellow;
            this.groupPhieuPhap.Controls.Add(this.PN_txtMT);
            this.groupPhieuPhap.Controls.Add(this.labelX21);
            this.groupPhieuPhap.Controls.Add(this.PN_cmbMHDM);
            this.groupPhieuPhap.Controls.Add(this.PN_cmbMLHDM);
            this.groupPhieuPhap.Controls.Add(this.labelX20);
            this.groupPhieuPhap.Controls.Add(this.PN_cmbMLPN);
            this.groupPhieuPhap.Controls.Add(this.groupPanel6);
            this.groupPhieuPhap.Controls.Add(this.labelX13);
            this.groupPhieuPhap.Controls.Add(this.PN_cmbNguoiSua);
            this.groupPhieuPhap.Controls.Add(this.PN_dpNgaySua);
            this.groupPhieuPhap.Controls.Add(this.labelX14);
            this.groupPhieuPhap.Controls.Add(this.PN_cmbNguoiLap);
            this.groupPhieuPhap.Controls.Add(this.labelX15);
            this.groupPhieuPhap.Controls.Add(this.PN_dpNgayLap);
            this.groupPhieuPhap.Controls.Add(this.labelX16);
            this.groupPhieuPhap.Controls.Add(this.labelX17);
            this.groupPhieuPhap.Controls.Add(this.labelX18);
            this.groupPhieuPhap.Location = new System.Drawing.Point(0, 0);
            this.groupPhieuPhap.Name = "groupPhieuPhap";
            this.groupPhieuPhap.Size = new System.Drawing.Size(254, 496);
            // 
            // 
            // 
            this.groupPhieuPhap.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(178)))));
            this.groupPhieuPhap.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(69)))));
            this.groupPhieuPhap.Style.BackColorGradientAngle = 90;
            this.groupPhieuPhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPhieuPhap.Style.BorderBottomWidth = 1;
            this.groupPhieuPhap.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(147)))), ((int)(((byte)(17)))));
            this.groupPhieuPhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPhieuPhap.Style.BorderLeftWidth = 1;
            this.groupPhieuPhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPhieuPhap.Style.BorderRightWidth = 1;
            this.groupPhieuPhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPhieuPhap.Style.BorderTopWidth = 1;
            this.groupPhieuPhap.Style.Class = "";
            this.groupPhieuPhap.Style.CornerDiameter = 4;
            this.groupPhieuPhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPhieuPhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPhieuPhap.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.groupPhieuPhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPhieuPhap.StyleMouseDown.Class = "";
            this.groupPhieuPhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPhieuPhap.StyleMouseOver.Class = "";
            this.groupPhieuPhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPhieuPhap.TabIndex = 3;
            this.groupPhieuPhap.Text = "Thêm/Sửa Phiếu Nhập";
            // 
            // PN_txtMT
            // 
            // 
            // 
            // 
            this.PN_txtMT.Border.Class = "TextBoxBorder";
            this.PN_txtMT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_txtMT.FocusHighlightEnabled = true;
            this.PN_txtMT.Location = new System.Drawing.Point(59, 133);
            this.PN_txtMT.Multiline = true;
            this.PN_txtMT.Name = "PN_txtMT";
            this.PN_txtMT.Size = new System.Drawing.Size(184, 63);
            this.PN_txtMT.TabIndex = 21;
            // 
            // labelX21
            // 
            this.labelX21.AutoSize = true;
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.Class = "";
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Location = new System.Drawing.Point(-1, 133);
            this.labelX21.Name = "labelX21";
            this.labelX21.Size = new System.Drawing.Size(36, 15);
            this.labelX21.TabIndex = 20;
            this.labelX21.Text = "<b>Mô Tả:</b>";
            // 
            // PN_cmbMHDM
            // 
            this.PN_cmbMHDM.DisplayMember = "Text";
            this.PN_cmbMHDM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PN_cmbMHDM.FocusHighlightEnabled = true;
            this.PN_cmbMHDM.FormattingEnabled = true;
            this.PN_cmbMHDM.ItemHeight = 14;
            this.PN_cmbMHDM.Location = new System.Drawing.Point(108, 90);
            this.PN_cmbMHDM.Name = "PN_cmbMHDM";
            this.PN_cmbMHDM.Size = new System.Drawing.Size(137, 20);
            this.PN_cmbMHDM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_cmbMHDM.TabIndex = 19;
            // 
            // PN_cmbMLHDM
            // 
            this.PN_cmbMLHDM.DisplayMember = "Text";
            this.PN_cmbMLHDM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PN_cmbMLHDM.FocusHighlightEnabled = true;
            this.PN_cmbMLHDM.FormattingEnabled = true;
            this.PN_cmbMLHDM.ItemHeight = 14;
            this.PN_cmbMLHDM.Location = new System.Drawing.Point(108, 56);
            this.PN_cmbMLHDM.Name = "PN_cmbMLHDM";
            this.PN_cmbMLHDM.Size = new System.Drawing.Size(137, 20);
            this.PN_cmbMLHDM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_cmbMLHDM.TabIndex = 18;
            this.PN_cmbMLHDM.SelectedIndexChanged += new System.EventHandler(this.PN_cmbMLHDM_SelectedIndexChanged);
            // 
            // labelX20
            // 
            this.labelX20.AutoSize = true;
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.Class = "";
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(-1, 95);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(65, 15);
            this.labelX20.TabIndex = 17;
            this.labelX20.Text = "<b>Mã HĐ Mua:</b>";
            // 
            // PN_cmbMLPN
            // 
            this.PN_cmbMLPN.DisplayMember = "Text";
            this.PN_cmbMLPN.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PN_cmbMLPN.FocusHighlightEnabled = true;
            this.PN_cmbMLPN.FormattingEnabled = true;
            this.PN_cmbMLPN.ItemHeight = 14;
            this.PN_cmbMLPN.Location = new System.Drawing.Point(108, 18);
            this.PN_cmbMLPN.Name = "PN_cmbMLPN";
            this.PN_cmbMLPN.Size = new System.Drawing.Size(137, 20);
            this.PN_cmbMLPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_cmbMLPN.TabIndex = 16;
            // 
            // groupPanel6
            // 
            this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.btn_PN_Huy);
            this.groupPanel6.Controls.Add(this.btn_PN_Luu);
            this.groupPanel6.Controls.Add(this.btn_PN_Sua);
            this.groupPanel6.Controls.Add(this.btn_PN_Them);
            this.groupPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel6.Location = new System.Drawing.Point(0, 426);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(248, 49);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.Class = "";
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.Class = "";
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.Class = "";
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 15;
            this.groupPanel6.Text = "ToolBar Edit";
            // 
            // btn_PN_Huy
            // 
            this.btn_PN_Huy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_PN_Huy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_PN_Huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_PN_Huy.Image")));
            this.btn_PN_Huy.Location = new System.Drawing.Point(186, 3);
            this.btn_PN_Huy.Name = "btn_PN_Huy";
            this.btn_PN_Huy.Size = new System.Drawing.Size(56, 23);
            this.btn_PN_Huy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_PN_Huy.TabIndex = 13;
            this.btn_PN_Huy.Text = "Hủy";
            this.btn_PN_Huy.Click += new System.EventHandler(this.btn_PN_Huy_Click);
            // 
            // btn_PN_Luu
            // 
            this.btn_PN_Luu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_PN_Luu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_PN_Luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_PN_Luu.Image")));
            this.btn_PN_Luu.Location = new System.Drawing.Point(124, 3);
            this.btn_PN_Luu.Name = "btn_PN_Luu";
            this.btn_PN_Luu.Size = new System.Drawing.Size(56, 23);
            this.btn_PN_Luu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_PN_Luu.TabIndex = 12;
            this.btn_PN_Luu.Text = "Lưu";
            this.btn_PN_Luu.Click += new System.EventHandler(this.btn_PN_Luu_Click);
            // 
            // btn_PN_Sua
            // 
            this.btn_PN_Sua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_PN_Sua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_PN_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_PN_Sua.Image")));
            this.btn_PN_Sua.Location = new System.Drawing.Point(62, 3);
            this.btn_PN_Sua.Name = "btn_PN_Sua";
            this.btn_PN_Sua.Size = new System.Drawing.Size(56, 23);
            this.btn_PN_Sua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_PN_Sua.TabIndex = 11;
            this.btn_PN_Sua.Text = "Sửa";
            this.btn_PN_Sua.Click += new System.EventHandler(this.btn_PN_Sua_Click);
            // 
            // btn_PN_Them
            // 
            this.btn_PN_Them.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_PN_Them.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_PN_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_PN_Them.Image")));
            this.btn_PN_Them.Location = new System.Drawing.Point(0, 3);
            this.btn_PN_Them.Name = "btn_PN_Them";
            this.btn_PN_Them.Size = new System.Drawing.Size(56, 23);
            this.btn_PN_Them.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_PN_Them.TabIndex = 10;
            this.btn_PN_Them.Text = "Thêm";
            this.btn_PN_Them.Click += new System.EventHandler(this.btn_PN_Them_Click);
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(-2, 350);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(57, 15);
            this.labelX13.TabIndex = 11;
            this.labelX13.Text = "<b>Người Sửa:</b>";
            // 
            // PN_cmbNguoiSua
            // 
            this.PN_cmbNguoiSua.DisplayMember = "Text";
            this.PN_cmbNguoiSua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PN_cmbNguoiSua.FocusHighlightEnabled = true;
            this.PN_cmbNguoiSua.FormattingEnabled = true;
            this.PN_cmbNguoiSua.ItemHeight = 14;
            this.PN_cmbNguoiSua.Location = new System.Drawing.Point(109, 345);
            this.PN_cmbNguoiSua.Name = "PN_cmbNguoiSua";
            this.PN_cmbNguoiSua.Size = new System.Drawing.Size(135, 20);
            this.PN_cmbNguoiSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_cmbNguoiSua.TabIndex = 10;
            // 
            // PN_dpNgaySua
            // 
            // 
            // 
            // 
            this.PN_dpNgaySua.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PN_dpNgaySua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgaySua.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.PN_dpNgaySua.ButtonDropDown.Visible = true;
            this.PN_dpNgaySua.FocusHighlightEnabled = true;
            this.PN_dpNgaySua.IsPopupCalendarOpen = false;
            this.PN_dpNgaySua.Location = new System.Drawing.Point(109, 293);
            // 
            // 
            // 
            this.PN_dpNgaySua.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.PN_dpNgaySua.MonthCalendar.BackgroundStyle.Class = "";
            this.PN_dpNgaySua.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgaySua.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.PN_dpNgaySua.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgaySua.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.PN_dpNgaySua.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.PN_dpNgaySua.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.PN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.PN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.PN_dpNgaySua.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgaySua.MonthCalendar.TodayButtonVisible = true;
            this.PN_dpNgaySua.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.PN_dpNgaySua.Name = "PN_dpNgaySua";
            this.PN_dpNgaySua.Size = new System.Drawing.Size(135, 20);
            this.PN_dpNgaySua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_dpNgaySua.TabIndex = 9;
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(-1, 298);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(54, 15);
            this.labelX14.TabIndex = 8;
            this.labelX14.Text = "<b>Ngày Sửa:</b>";
            // 
            // PN_cmbNguoiLap
            // 
            this.PN_cmbNguoiLap.DisplayMember = "Text";
            this.PN_cmbNguoiLap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PN_cmbNguoiLap.FocusHighlightEnabled = true;
            this.PN_cmbNguoiLap.FormattingEnabled = true;
            this.PN_cmbNguoiLap.ItemHeight = 14;
            this.PN_cmbNguoiLap.Location = new System.Drawing.Point(109, 250);
            this.PN_cmbNguoiLap.Name = "PN_cmbNguoiLap";
            this.PN_cmbNguoiLap.Size = new System.Drawing.Size(135, 20);
            this.PN_cmbNguoiLap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_cmbNguoiLap.TabIndex = 7;
            // 
            // labelX15
            // 
            this.labelX15.AutoSize = true;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.Class = "";
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(-1, 255);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(56, 15);
            this.labelX15.TabIndex = 6;
            this.labelX15.Text = "<b>Người Lập:</b>";
            // 
            // PN_dpNgayLap
            // 
            // 
            // 
            // 
            this.PN_dpNgayLap.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PN_dpNgayLap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgayLap.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.PN_dpNgayLap.ButtonDropDown.Visible = true;
            this.PN_dpNgayLap.FocusHighlightEnabled = true;
            this.PN_dpNgayLap.IsPopupCalendarOpen = false;
            this.PN_dpNgayLap.Location = new System.Drawing.Point(109, 207);
            // 
            // 
            // 
            this.PN_dpNgayLap.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.PN_dpNgayLap.MonthCalendar.BackgroundStyle.Class = "";
            this.PN_dpNgayLap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgayLap.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.PN_dpNgayLap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgayLap.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.PN_dpNgayLap.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.PN_dpNgayLap.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.PN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.PN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.PN_dpNgayLap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PN_dpNgayLap.MonthCalendar.TodayButtonVisible = true;
            this.PN_dpNgayLap.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.PN_dpNgayLap.Name = "PN_dpNgayLap";
            this.PN_dpNgayLap.Size = new System.Drawing.Size(135, 20);
            this.PN_dpNgayLap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PN_dpNgayLap.TabIndex = 5;
            // 
            // labelX16
            // 
            this.labelX16.AutoSize = true;
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.Class = "";
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(-1, 212);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(53, 15);
            this.labelX16.TabIndex = 2;
            this.labelX16.Text = "<b>Ngày Lập:</b>";
            // 
            // labelX17
            // 
            this.labelX17.AutoSize = true;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.Class = "";
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(-1, 61);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(81, 15);
            this.labelX17.TabIndex = 1;
            this.labelX17.Text = "<b>Mã Lô HĐ Mua:</b>";
            // 
            // labelX18
            // 
            this.labelX18.AutoSize = true;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.Class = "";
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(0, 23);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(108, 15);
            this.labelX18.TabIndex = 0;
            this.labelX18.Text = "<b>Mã Loại Phiếu Nhập:</b>";
            // 
            // buttonItemThaoTac
            // 
            this.buttonItemThaoTac.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemThaoTac.Image = global::QuanLy_KeToan.Properties.Resources.edit;
            this.buttonItemThaoTac.Name = "buttonItemThaoTac";
            this.buttonItemThaoTac.OptionGroup = "navBar";
            this.buttonItemThaoTac.Text = "THAO TÁC";
            // 
            // expandablePanelCauHinh
            // 
            this.expandablePanelCauHinh.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelCauHinh.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.TopToBottom;
            this.expandablePanelCauHinh.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanelCauHinh.Controls.Add(this.groupPanel2);
            this.expandablePanelCauHinh.Controls.Add(this.groupPanel1);
            this.expandablePanelCauHinh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanelCauHinh.Expanded = false;
            this.expandablePanelCauHinh.ExpandedBounds = new System.Drawing.Rectangle(0, 612, 1354, 80);
            this.expandablePanelCauHinh.Location = new System.Drawing.Point(1, 639);
            this.expandablePanelCauHinh.Name = "expandablePanelCauHinh";
            this.expandablePanelCauHinh.Size = new System.Drawing.Size(1352, 26);
            this.expandablePanelCauHinh.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelCauHinh.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanelCauHinh.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelCauHinh.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelCauHinh.Style.GradientAngle = 90;
            this.expandablePanelCauHinh.TabIndex = 11;
            this.expandablePanelCauHinh.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelCauHinh.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanelCauHinh.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanelCauHinh.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanelCauHinh.TitleStyle.GradientAngle = 90;
            this.expandablePanelCauHinh.TitleText = "<b>Cấu Hình Hệ Thống-Màn Hình Quản Lý Nhập Kho\r\n-Phần Mềm Quản Lý Kế Toán </b>";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel2.Location = new System.Drawing.Point(0, 26);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(436, 0);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "Thông Tin Hệ Thống";
            this.groupPanel2.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonBlack);
            this.groupPanel1.Controls.Add(this.buttonBlue);
            this.groupPanel1.Controls.Add(this.buttonSilver);
            this.groupPanel1.Controls.Add(this.colorPickerButton);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupPanel1.Location = new System.Drawing.Point(1004, 26);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(350, 0);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.TitleImage = ((System.Drawing.Image)(resources.GetObject("groupPanel1.TitleImage")));
            this.groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // buttonBlack
            // 
            this.buttonBlack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlack.Location = new System.Drawing.Point(165, 3);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(75, 23);
            this.buttonBlack.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonBlack.TabIndex = 3;
            this.buttonBlack.Text = "Black";
            // 
            // buttonBlue
            // 
            this.buttonBlue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonBlue.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlue.Location = new System.Drawing.Point(84, 3);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(75, 23);
            this.buttonBlue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonBlue.TabIndex = 2;
            this.buttonBlue.Text = "Blue";
            // 
            // buttonSilver
            // 
            this.buttonSilver.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSilver.BackColor = System.Drawing.Color.Silver;
            this.buttonSilver.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonSilver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSilver.Location = new System.Drawing.Point(3, 3);
            this.buttonSilver.Name = "buttonSilver";
            this.buttonSilver.Size = new System.Drawing.Size(75, 23);
            this.buttonSilver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonSilver.TabIndex = 1;
            this.buttonSilver.Text = "Silver";
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.colorPickerButton.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.colorPickerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
            this.colorPickerButton.Location = new System.Drawing.Point(247, 3);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.colorPickerButton.Size = new System.Drawing.Size(94, 23);
            this.colorPickerButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colorPickerButton.TabIndex = 0;
            this.colorPickerButton.Text = "Tùy Chỉnh";
            // 
            // groupPanelLoPhieuNhap
            // 
            this.groupPanelLoPhieuNhap.BackColor = System.Drawing.Color.Transparent;
            this.groupPanelLoPhieuNhap.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelLoPhieuNhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelLoPhieuNhap.Controls.Add(this.gridLoPhieuNhap);
            this.groupPanelLoPhieuNhap.Controls.Add(this.bindingLoPhieuNhap);
            this.groupPanelLoPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanelLoPhieuNhap.Location = new System.Drawing.Point(1, 1);
            this.groupPanelLoPhieuNhap.Name = "groupPanelLoPhieuNhap";
            this.groupPanelLoPhieuNhap.Size = new System.Drawing.Size(1352, 664);
            // 
            // 
            // 
            this.groupPanelLoPhieuNhap.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelLoPhieuNhap.Style.BackColorGradientAngle = 90;
            this.groupPanelLoPhieuNhap.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelLoPhieuNhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoPhieuNhap.Style.BorderBottomWidth = 1;
            this.groupPanelLoPhieuNhap.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelLoPhieuNhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoPhieuNhap.Style.BorderLeftWidth = 1;
            this.groupPanelLoPhieuNhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoPhieuNhap.Style.BorderRightWidth = 1;
            this.groupPanelLoPhieuNhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelLoPhieuNhap.Style.BorderTopWidth = 1;
            this.groupPanelLoPhieuNhap.Style.Class = "";
            this.groupPanelLoPhieuNhap.Style.CornerDiameter = 4;
            this.groupPanelLoPhieuNhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelLoPhieuNhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelLoPhieuNhap.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelLoPhieuNhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelLoPhieuNhap.StyleMouseDown.Class = "";
            this.groupPanelLoPhieuNhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelLoPhieuNhap.StyleMouseOver.Class = "";
            this.groupPanelLoPhieuNhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelLoPhieuNhap.TabIndex = 1;
            this.groupPanelLoPhieuNhap.Text = "Lô Phiếu Nhập";
            this.groupPanelLoPhieuNhap.TitleImage = global::QuanLy_KeToan.Properties.Resources.Lophieunhap;
            this.groupPanelLoPhieuNhap.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // gridLoPhieuNhap
            // 
            this.gridLoPhieuNhap.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridLoPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLoPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMLHDM,
            this.ColNLN,
            this.ColMT,
            this.NgayLap,
            this.NguoiLap,
            this.NgaySua,
            this.NguoiSua});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLoPhieuNhap.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridLoPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLoPhieuNhap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridLoPhieuNhap.Location = new System.Drawing.Point(0, 25);
            this.gridLoPhieuNhap.Name = "gridLoPhieuNhap";
            this.gridLoPhieuNhap.Size = new System.Drawing.Size(1346, 595);
            this.gridLoPhieuNhap.TabIndex = 2;
            this.gridLoPhieuNhap.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridLoPhieuNhap_CellBeginEdit_1);
            this.gridLoPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoPhieuNhap_CellClick);
            this.gridLoPhieuNhap.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoPhieuNhap_RowEnter);
            // 
            // ColMLHDM
            // 
            this.ColMLHDM.DataPropertyName = "MaLoHDMua";
            this.ColMLHDM.DisplayMember = "Text";
            this.ColMLHDM.DropDownHeight = 106;
            this.ColMLHDM.DropDownWidth = 121;
            this.ColMLHDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColMLHDM.HeaderText = "Mã Lô HĐ Mua";
            this.ColMLHDM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ColMLHDM.IntegralHeight = false;
            this.ColMLHDM.ItemHeight = 15;
            this.ColMLHDM.Name = "ColMLHDM";
            this.ColMLHDM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ColMLHDM.Width = 130;
            // 
            // ColNLN
            // 
            // 
            // 
            // 
            this.ColNLN.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.ColNLN.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.ColNLN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColNLN.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.ColNLN.DataPropertyName = "NgayLoNhap";
            this.ColNLN.HeaderText = "Ngày Lô Nhập";
            this.ColNLN.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.ColNLN.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ColNLN.MonthCalendar.BackgroundStyle.Class = "";
            this.ColNLN.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ColNLN.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.ColNLN.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColNLN.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.ColNLN.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.ColNLN.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.ColNLN.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.ColNLN.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ColNLN.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.ColNLN.Name = "ColNLN";
            this.ColNLN.Width = 130;
            // 
            // ColMT
            // 
            this.ColMT.DataPropertyName = "MoTa";
            this.ColMT.HeaderText = "Mô Tả";
            this.ColMT.Name = "ColMT";
            this.ColMT.Width = 300;
            // 
            // NgayLap
            // 
            // 
            // 
            // 
            this.NgayLap.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.NgayLap.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.NgayLap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập";
            this.NgayLap.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.BackgroundStyle.Class = "";
            this.NgayLap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.NgayLap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.NgayLap.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NgayLap.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.NgayLap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NgayLap.Name = "NgayLap";
            // 
            // NguoiLap
            // 
            this.NguoiLap.DataPropertyName = "NguoiLap";
            this.NguoiLap.DisplayMember = "Text";
            this.NguoiLap.DropDownHeight = 106;
            this.NguoiLap.DropDownWidth = 121;
            this.NguoiLap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NguoiLap.HeaderText = "Người Lập";
            this.NguoiLap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NguoiLap.IntegralHeight = false;
            this.NguoiLap.ItemHeight = 15;
            this.NguoiLap.Name = "NguoiLap";
            this.NguoiLap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // NgaySua
            // 
            // 
            // 
            // 
            this.NgaySua.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.NgaySua.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.NgaySua.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgaySua.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.NgaySua.DataPropertyName = "NgaySua";
            this.NgaySua.HeaderText = "Ngày Sửa";
            this.NgaySua.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.NgaySua.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NgaySua.MonthCalendar.BackgroundStyle.Class = "";
            this.NgaySua.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.NgaySua.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.NgaySua.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgaySua.MonthCalendar.DisplayMonth = new System.DateTime(2012, 6, 1, 0, 0, 0, 0);
            this.NgaySua.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NgaySua.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NgaySua.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.NgaySua.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgaySua.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NgaySua.Name = "NgaySua";
            // 
            // NguoiSua
            // 
            this.NguoiSua.DataPropertyName = "NguoiSua";
            this.NguoiSua.DisplayMember = "Text";
            this.NguoiSua.DropDownHeight = 106;
            this.NguoiSua.DropDownWidth = 121;
            this.NguoiSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NguoiSua.HeaderText = "Người Sửa";
            this.NguoiSua.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NguoiSua.IntegralHeight = false;
            this.NguoiSua.ItemHeight = 15;
            this.NguoiSua.Name = "NguoiSua";
            this.NguoiSua.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // bindingLoPhieuNhap
            // 
            this.bindingLoPhieuNhap.AddNewItem = null;
            this.bindingLoPhieuNhap.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bindingLoPhieuNhap.CountItem = this.bindingNavigatorCountItem3;
            this.bindingLoPhieuNhap.CountItemFormat = "của  {0}";
            this.bindingLoPhieuNhap.DeleteItem = null;
            this.bindingLoPhieuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem3,
            this.bindingNavigatorMovePreviousItem3,
            this.bindingNavigatorSeparator9,
            this.positionLoPhieuNhap,
            this.bindingNavigatorCountItem3,
            this.bindingNavigatorSeparator10,
            this.bindingNavigatorMoveNextItem3,
            this.bindingNavigatorMoveLastItem3,
            this.bindingNavigatorSeparator11,
            this.LoPN_Refresh,
            this.toolStripSeparator22,
            this.LoPN_Add,
            this.toolStripSeparator19,
            this.LoPN_Delete,
            this.toolStripSeparator20,
            this.LoPN_Save,
            this.toolStripSeparator21,
            this.LoPN_Cancel,
            this.toolStripSeparator23,
            this.LoPN_Exit});
            this.bindingLoPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.bindingLoPhieuNhap.MoveFirstItem = this.bindingNavigatorMoveFirstItem3;
            this.bindingLoPhieuNhap.MoveLastItem = this.bindingNavigatorMoveLastItem3;
            this.bindingLoPhieuNhap.MoveNextItem = this.bindingNavigatorMoveNextItem3;
            this.bindingLoPhieuNhap.MovePreviousItem = this.bindingNavigatorMovePreviousItem3;
            this.bindingLoPhieuNhap.Name = "bindingLoPhieuNhap";
            this.bindingLoPhieuNhap.PositionItem = this.positionLoPhieuNhap;
            this.bindingLoPhieuNhap.Size = new System.Drawing.Size(1346, 25);
            this.bindingLoPhieuNhap.TabIndex = 1;
            // 
            // bindingNavigatorCountItem3
            // 
            this.bindingNavigatorCountItem3.Name = "bindingNavigatorCountItem3";
            this.bindingNavigatorCountItem3.Size = new System.Drawing.Size(46, 22);
            this.bindingNavigatorCountItem3.Text = "của  {0}";
            this.bindingNavigatorCountItem3.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem3
            // 
            this.bindingNavigatorMoveFirstItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem3.Image")));
            this.bindingNavigatorMoveFirstItem3.Name = "bindingNavigatorMoveFirstItem3";
            this.bindingNavigatorMoveFirstItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem3.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem3
            // 
            this.bindingNavigatorMovePreviousItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem3.Image")));
            this.bindingNavigatorMovePreviousItem3.Name = "bindingNavigatorMovePreviousItem3";
            this.bindingNavigatorMovePreviousItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem3.Text = "Move previous";
            // 
            // bindingNavigatorSeparator9
            // 
            this.bindingNavigatorSeparator9.Name = "bindingNavigatorSeparator9";
            this.bindingNavigatorSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // positionLoPhieuNhap
            // 
            this.positionLoPhieuNhap.AccessibleName = "Position";
            this.positionLoPhieuNhap.AutoSize = false;
            this.positionLoPhieuNhap.Name = "positionLoPhieuNhap";
            this.positionLoPhieuNhap.Size = new System.Drawing.Size(50, 23);
            this.positionLoPhieuNhap.Text = "0";
            this.positionLoPhieuNhap.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator10
            // 
            this.bindingNavigatorSeparator10.Name = "bindingNavigatorSeparator10";
            this.bindingNavigatorSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem3
            // 
            this.bindingNavigatorMoveNextItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem3.Image")));
            this.bindingNavigatorMoveNextItem3.Name = "bindingNavigatorMoveNextItem3";
            this.bindingNavigatorMoveNextItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem3.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem3
            // 
            this.bindingNavigatorMoveLastItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem3.Image")));
            this.bindingNavigatorMoveLastItem3.Name = "bindingNavigatorMoveLastItem3";
            this.bindingNavigatorMoveLastItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem3.Text = "Move last";
            // 
            // bindingNavigatorSeparator11
            // 
            this.bindingNavigatorSeparator11.Name = "bindingNavigatorSeparator11";
            this.bindingNavigatorSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // LoPN_Refresh
            // 
            this.LoPN_Refresh.Image = global::QuanLy_KeToan.Properties.Resources.refresh;
            this.LoPN_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoPN_Refresh.Name = "LoPN_Refresh";
            this.LoPN_Refresh.Size = new System.Drawing.Size(66, 22);
            this.LoPN_Refresh.Text = "&Refresh";
            this.LoPN_Refresh.Click += new System.EventHandler(this.LoPN_Refresh_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            // 
            // LoPN_Add
            // 
            this.LoPN_Add.Image = ((System.Drawing.Image)(resources.GetObject("LoPN_Add.Image")));
            this.LoPN_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoPN_Add.Name = "LoPN_Add";
            this.LoPN_Add.Size = new System.Drawing.Size(49, 22);
            this.LoPN_Add.Text = "&Add";
            this.LoPN_Add.Click += new System.EventHandler(this.LoPN_Add_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // LoPN_Delete
            // 
            this.LoPN_Delete.Image = global::QuanLy_KeToan.Properties.Resources.delete;
            this.LoPN_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoPN_Delete.Name = "LoPN_Delete";
            this.LoPN_Delete.Size = new System.Drawing.Size(60, 22);
            this.LoPN_Delete.Text = "&Delete";
            this.LoPN_Delete.Click += new System.EventHandler(this.LoPN_Delete_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(6, 25);
            // 
            // LoPN_Save
            // 
            this.LoPN_Save.Image = ((System.Drawing.Image)(resources.GetObject("LoPN_Save.Image")));
            this.LoPN_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoPN_Save.Name = "LoPN_Save";
            this.LoPN_Save.Size = new System.Drawing.Size(51, 22);
            this.LoPN_Save.Text = "&Save";
            this.LoPN_Save.Click += new System.EventHandler(this.LoPN_Save_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            // 
            // LoPN_Cancel
            // 
            this.LoPN_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("LoPN_Cancel.Image")));
            this.LoPN_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoPN_Cancel.Name = "LoPN_Cancel";
            this.LoPN_Cancel.Size = new System.Drawing.Size(63, 22);
            this.LoPN_Cancel.Text = "&Cancel";
            this.LoPN_Cancel.Click += new System.EventHandler(this.LoPN_Cancel_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(6, 25);
            // 
            // LoPN_Exit
            // 
            this.LoPN_Exit.Image = global::QuanLy_KeToan.Properties.Resources.thoat;
            this.LoPN_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoPN_Exit.Name = "LoPN_Exit";
            this.LoPN_Exit.Size = new System.Drawing.Size(45, 22);
            this.LoPN_Exit.Text = "&Exit";
            this.LoPN_Exit.Click += new System.EventHandler(this.LoPN_Exit_Click);
            // 
            // groupPanelPhieuNhap
            // 
            this.groupPanelPhieuNhap.BackColor = System.Drawing.Color.Transparent;
            this.groupPanelPhieuNhap.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelPhieuNhap.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelPhieuNhap.Controls.Add(this.gridPhieuNhap);
            this.groupPanelPhieuNhap.Controls.Add(this.bindingPhieuNhap);
            this.groupPanelPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanelPhieuNhap.Location = new System.Drawing.Point(1, 1);
            this.groupPanelPhieuNhap.Name = "groupPanelPhieuNhap";
            this.groupPanelPhieuNhap.Size = new System.Drawing.Size(1352, 664);
            // 
            // 
            // 
            this.groupPanelPhieuNhap.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelPhieuNhap.Style.BackColorGradientAngle = 90;
            this.groupPanelPhieuNhap.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelPhieuNhap.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelPhieuNhap.Style.BorderBottomWidth = 1;
            this.groupPanelPhieuNhap.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelPhieuNhap.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelPhieuNhap.Style.BorderLeftWidth = 1;
            this.groupPanelPhieuNhap.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelPhieuNhap.Style.BorderRightWidth = 1;
            this.groupPanelPhieuNhap.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelPhieuNhap.Style.BorderTopWidth = 1;
            this.groupPanelPhieuNhap.Style.Class = "";
            this.groupPanelPhieuNhap.Style.CornerDiameter = 4;
            this.groupPanelPhieuNhap.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelPhieuNhap.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelPhieuNhap.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelPhieuNhap.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelPhieuNhap.StyleMouseDown.Class = "";
            this.groupPanelPhieuNhap.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelPhieuNhap.StyleMouseOver.Class = "";
            this.groupPanelPhieuNhap.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelPhieuNhap.TabIndex = 2;
            this.groupPanelPhieuNhap.Text = "Phiếu Nhập";
            this.groupPanelPhieuNhap.TitleImage = global::QuanLy_KeToan.Properties.Resources.receipt;
            this.groupPanelPhieuNhap.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            // 
            // gridPhieuNhap
            // 
            this.gridPhieuNhap.AllowUserToAddRows = false;
            this.gridPhieuNhap.AllowUserToOrderColumns = true;
            this.gridPhieuNhap.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MLPN,
            this.MLHDM,
            this.MHDM,
            this.MT,
            this._NL,
            this._NgL,
            this._NS,
            this._NgS});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPhieuNhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPhieuNhap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridPhieuNhap.Location = new System.Drawing.Point(0, 25);
            this.gridPhieuNhap.Name = "gridPhieuNhap";
            this.gridPhieuNhap.Size = new System.Drawing.Size(1346, 592);
            this.gridPhieuNhap.TabIndex = 0;
            this.gridPhieuNhap.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridPhieuNhap_CellBeginEdit);
            this.gridPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPhieuNhap_CellClick);
            this.gridPhieuNhap.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPhieuNhap_RowEnter);
            // 
            // MLPN
            // 
            this.MLPN.DataPropertyName = "MaLoaiPhieuNhap";
            this.MLPN.DropDownHeight = 106;
            this.MLPN.DropDownWidth = 121;
            this.MLPN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MLPN.HeaderText = "Mã Loại PN";
            this.MLPN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MLPN.IntegralHeight = false;
            this.MLPN.ItemHeight = 15;
            this.MLPN.Name = "MLPN";
            this.MLPN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MLPN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MLPN.Width = 200;
            // 
            // MLHDM
            // 
            this.MLHDM.DataPropertyName = "MaLoHDMua";
            this.MLHDM.DropDownHeight = 106;
            this.MLHDM.DropDownWidth = 121;
            this.MLHDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MLHDM.HeaderText = "Mã Lô HĐMua";
            this.MLHDM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MLHDM.IntegralHeight = false;
            this.MLHDM.ItemHeight = 15;
            this.MLHDM.Name = "MLHDM";
            this.MLHDM.ReadOnly = true;
            this.MLHDM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MLHDM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MLHDM.Width = 130;
            // 
            // MHDM
            // 
            this.MHDM.DataPropertyName = "MaHDMua";
            this.MHDM.DropDownHeight = 106;
            this.MHDM.DropDownWidth = 121;
            this.MHDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MHDM.HeaderText = "Mã HĐMua";
            this.MHDM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MHDM.IntegralHeight = false;
            this.MHDM.ItemHeight = 15;
            this.MHDM.Name = "MHDM";
            this.MHDM.ReadOnly = true;
            this.MHDM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MHDM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // MT
            // 
            this.MT.DataPropertyName = "MoTa";
            this.MT.HeaderText = "Mô Tả";
            this.MT.Name = "MT";
            this.MT.Width = 200;
            // 
            // _NL
            // 
            // 
            // 
            // 
            this._NL.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this._NL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._NL.DataPropertyName = "NgayLap";
            this._NL.HeaderText = "Ngày Lập";
            this._NL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this._NL.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._NL.MonthCalendar.BackgroundStyle.Class = "";
            this._NL.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this._NL.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this._NL.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._NL.MonthCalendar.DisplayMonth = new System.DateTime(2012, 4, 1, 0, 0, 0, 0);
            this._NL.MonthCalendar.MarkedDates = new System.DateTime[0];
            this._NL.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._NL.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this._NL.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._NL.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this._NL.Name = "_NL";
            // 
            // _NgL
            // 
            this._NgL.DataPropertyName = "NguoiLap";
            this._NgL.DropDownHeight = 106;
            this._NgL.DropDownWidth = 121;
            this._NgL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._NgL.HeaderText = "Người Lập";
            this._NgL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._NgL.IntegralHeight = false;
            this._NgL.ItemHeight = 15;
            this._NgL.Name = "_NgL";
            this._NgL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._NgL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // _NS
            // 
            // 
            // 
            // 
            this._NS.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this._NS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._NS.DataPropertyName = "NgaySua";
            this._NS.HeaderText = "Ngày Sửa";
            this._NS.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this._NS.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._NS.MonthCalendar.BackgroundStyle.Class = "";
            this._NS.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this._NS.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this._NS.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._NS.MonthCalendar.DisplayMonth = new System.DateTime(2012, 4, 1, 0, 0, 0, 0);
            this._NS.MonthCalendar.MarkedDates = new System.DateTime[0];
            this._NS.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this._NS.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this._NS.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._NS.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this._NS.Name = "_NS";
            // 
            // _NgS
            // 
            this._NgS.DataPropertyName = "NguoiSua";
            this._NgS.DropDownHeight = 106;
            this._NgS.DropDownWidth = 121;
            this._NgS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._NgS.HeaderText = "Người Sửa";
            this._NgS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._NgS.IntegralHeight = false;
            this._NgS.ItemHeight = 15;
            this._NgS.Name = "_NgS";
            this._NgS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._NgS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // bindingPhieuNhap
            // 
            this.bindingPhieuNhap.AddNewItem = null;
            this.bindingPhieuNhap.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bindingPhieuNhap.CountItem = this.bindingNavigatorCountItem4;
            this.bindingPhieuNhap.CountItemFormat = "của  {0}";
            this.bindingPhieuNhap.DeleteItem = null;
            this.bindingPhieuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem4,
            this.bindingNavigatorMovePreviousItem4,
            this.bindingNavigatorSeparator12,
            this.positionPhieuNhap,
            this.bindingNavigatorCountItem4,
            this.bindingNavigatorSeparator13,
            this.bindingNavigatorMoveNextItem4,
            this.bindingNavigatorMoveLastItem4,
            this.bindingNavigatorSeparator14,
            this.PN_Refresh,
            this.toolStripSeparator24,
            this.PN_Add,
            this.toolStripSeparator25,
            this.PN_Delete,
            this.toolStripSeparator26,
            this.PN_Save,
            this.toolStripSeparator27,
            this.PN_Cancel,
            this.toolStripSeparator28,
            this.PN_Exit});
            this.bindingPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.bindingPhieuNhap.MoveFirstItem = this.bindingNavigatorMoveFirstItem4;
            this.bindingPhieuNhap.MoveLastItem = this.bindingNavigatorMoveLastItem4;
            this.bindingPhieuNhap.MoveNextItem = this.bindingNavigatorMoveNextItem4;
            this.bindingPhieuNhap.MovePreviousItem = this.bindingNavigatorMovePreviousItem4;
            this.bindingPhieuNhap.Name = "bindingPhieuNhap";
            this.bindingPhieuNhap.PositionItem = this.positionPhieuNhap;
            this.bindingPhieuNhap.Size = new System.Drawing.Size(1346, 25);
            this.bindingPhieuNhap.TabIndex = 1;
            this.bindingPhieuNhap.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem4
            // 
            this.bindingNavigatorCountItem4.Name = "bindingNavigatorCountItem4";
            this.bindingNavigatorCountItem4.Size = new System.Drawing.Size(46, 22);
            this.bindingNavigatorCountItem4.Text = "của  {0}";
            this.bindingNavigatorCountItem4.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem4
            // 
            this.bindingNavigatorMoveFirstItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem4.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem4.Image")));
            this.bindingNavigatorMoveFirstItem4.Name = "bindingNavigatorMoveFirstItem4";
            this.bindingNavigatorMoveFirstItem4.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem4.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem4.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem4
            // 
            this.bindingNavigatorMovePreviousItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem4.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem4.Image")));
            this.bindingNavigatorMovePreviousItem4.Name = "bindingNavigatorMovePreviousItem4";
            this.bindingNavigatorMovePreviousItem4.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem4.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem4.Text = "Move previous";
            // 
            // bindingNavigatorSeparator12
            // 
            this.bindingNavigatorSeparator12.Name = "bindingNavigatorSeparator12";
            this.bindingNavigatorSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // positionPhieuNhap
            // 
            this.positionPhieuNhap.AccessibleName = "Position";
            this.positionPhieuNhap.AutoSize = false;
            this.positionPhieuNhap.Name = "positionPhieuNhap";
            this.positionPhieuNhap.Size = new System.Drawing.Size(50, 23);
            this.positionPhieuNhap.Text = "0";
            this.positionPhieuNhap.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator13
            // 
            this.bindingNavigatorSeparator13.Name = "bindingNavigatorSeparator13";
            this.bindingNavigatorSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem4
            // 
            this.bindingNavigatorMoveNextItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem4.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem4.Image")));
            this.bindingNavigatorMoveNextItem4.Name = "bindingNavigatorMoveNextItem4";
            this.bindingNavigatorMoveNextItem4.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem4.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem4.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem4
            // 
            this.bindingNavigatorMoveLastItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem4.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem4.Image")));
            this.bindingNavigatorMoveLastItem4.Name = "bindingNavigatorMoveLastItem4";
            this.bindingNavigatorMoveLastItem4.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem4.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem4.Text = "Move last";
            // 
            // bindingNavigatorSeparator14
            // 
            this.bindingNavigatorSeparator14.Name = "bindingNavigatorSeparator14";
            this.bindingNavigatorSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // PN_Refresh
            // 
            this.PN_Refresh.Image = global::QuanLy_KeToan.Properties.Resources.refresh;
            this.PN_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PN_Refresh.Name = "PN_Refresh";
            this.PN_Refresh.Size = new System.Drawing.Size(66, 22);
            this.PN_Refresh.Text = "&Refresh";
            this.PN_Refresh.Click += new System.EventHandler(this.PN_Refresh_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(6, 25);
            // 
            // PN_Add
            // 
            this.PN_Add.Image = ((System.Drawing.Image)(resources.GetObject("PN_Add.Image")));
            this.PN_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PN_Add.Name = "PN_Add";
            this.PN_Add.Size = new System.Drawing.Size(49, 22);
            this.PN_Add.Text = "&Add";
            this.PN_Add.Click += new System.EventHandler(this.PN_Add_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(6, 25);
            // 
            // PN_Delete
            // 
            this.PN_Delete.Image = global::QuanLy_KeToan.Properties.Resources.delete;
            this.PN_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PN_Delete.Name = "PN_Delete";
            this.PN_Delete.Size = new System.Drawing.Size(60, 22);
            this.PN_Delete.Text = "&Delete";
            this.PN_Delete.Click += new System.EventHandler(this.PN_Delete_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(6, 25);
            // 
            // PN_Save
            // 
            this.PN_Save.Image = ((System.Drawing.Image)(resources.GetObject("PN_Save.Image")));
            this.PN_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PN_Save.Name = "PN_Save";
            this.PN_Save.Size = new System.Drawing.Size(51, 22);
            this.PN_Save.Text = "&Save";
            this.PN_Save.Click += new System.EventHandler(this.PN_Save_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(6, 25);
            // 
            // PN_Cancel
            // 
            this.PN_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("PN_Cancel.Image")));
            this.PN_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PN_Cancel.Name = "PN_Cancel";
            this.PN_Cancel.Size = new System.Drawing.Size(63, 22);
            this.PN_Cancel.Text = "&Cancel";
            this.PN_Cancel.Click += new System.EventHandler(this.PN_Cancel_Click);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(6, 25);
            // 
            // PN_Exit
            // 
            this.PN_Exit.Image = global::QuanLy_KeToan.Properties.Resources.thoat;
            this.PN_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PN_Exit.Name = "PN_Exit";
            this.PN_Exit.Size = new System.Drawing.Size(45, 22);
            this.PN_Exit.Text = "&Exit";
            this.PN_Exit.Click += new System.EventHandler(this.PN_Exit_Click);
            // 
            // tabItemNhapKho
            // 
            this.tabItemNhapKho.AttachedControl = this.tabControlPanel2;
            this.tabItemNhapKho.Name = "tabItemNhapKho";
            this.tabItemNhapKho.Text = "Quản Lý Nhập Kho";
            // 
            // FrmQuanLyNhapKho
            // 
            this.ClientSize = new System.Drawing.Size(1354, 692);
            this.Controls.Add(this.tabControlNhapKho);
            this.DoubleBuffered = true;
            this.Name = "FrmQuanLyNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmQuanLyNhapKho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuanLyNhapKho_FormClosing);
            this.Load += new System.EventHandler(this.FrmQuanLyNhapKho_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmQuanLyNhapKho_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlNhapKho)).EndInit();
            this.tabControlNhapKho.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanelLoaiPhieuNhap.ResumeLayout(false);
            this.groupPanelLoaiPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoaiPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLoaiPhieuNhap)).EndInit();
            this.bindingLoaiPhieuNhap.ResumeLayout(false);
            this.bindingLoaiPhieuNhap.PerformLayout();
            this.navigationPaneThaoTac.ResumeLayout(false);
            this.navigationPanePanelDuyetDanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeLoNhap)).EndInit();
            this.navigationPanePanelThaoTac.ResumeLayout(false);
            this.groupLoaiPhieuNhap.ResumeLayout(false);
            this.groupLoaiPhieuNhap.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LPN_dpNgaySua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LPN_dpNgayLap)).EndInit();
            this.groupLoPhieuNhap.ResumeLayout(false);
            this.groupLoPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpNgayLoNhap)).EndInit();
            this.groupPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoPN_dpNgaySua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoPN_dpNgayLap)).EndInit();
            this.groupPhieuPhap.ResumeLayout(false);
            this.groupPhieuPhap.PerformLayout();
            this.groupPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PN_dpNgaySua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PN_dpNgayLap)).EndInit();
            this.expandablePanelCauHinh.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanelLoPhieuNhap.ResumeLayout(false);
            this.groupPanelLoPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingLoPhieuNhap)).EndInit();
            this.bindingLoPhieuNhap.ResumeLayout(false);
            this.bindingLoPhieuNhap.PerformLayout();
            this.groupPanelPhieuNhap.ResumeLayout(false);
            this.groupPanelPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPhieuNhap)).EndInit();
            this.bindingPhieuNhap.ResumeLayout(false);
            this.bindingPhieuNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControlNhapKho;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemNhapKho;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelLoaiPhieuNhap;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelLoPhieuNhap;
        private DevComponents.DotNetBar.NavigationPane navigationPaneThaoTac;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanelDuyetDanhMuc;
        private DevComponents.AdvTree.AdvTree advTreeLoNhap;
        private DevComponents.AdvTree.Node root_node;
        private DevComponents.AdvTree.Node nodeLoaiPhieuNhap;
        private DevComponents.AdvTree.Node nodeLoPhieuNhap;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonItem btnDuyetDanhMuc;
        private System.Windows.Forms.BindingNavigator bindingLoaiPhieuNhap;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator6;
        private System.Windows.Forms.ToolStripTextBox positionLoaiPhieuNhap;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator7;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator8;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridLoaiPhieuNhap;
        private System.Windows.Forms.ToolStripButton LPN_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton LPN_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton LPN_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripButton LPN_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton LPN_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripButton LPN_Exit;
        private System.Windows.Forms.BindingNavigator bindingLoPhieuNhap;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem3;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator9;
        private System.Windows.Forms.ToolStripTextBox positionLoPhieuNhap;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator10;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem3;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator11;
        private System.Windows.Forms.ToolStripButton LoPN_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripButton LoPN_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripButton LoPN_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripButton LoPN_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripButton LoPN_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripButton LoPN_Exit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelPhieuNhap;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridPhieuNhap;
        private System.Windows.Forms.BindingNavigator bindingPhieuNhap;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem4;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator12;
        private System.Windows.Forms.ToolStripTextBox positionPhieuNhap;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator13;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem4;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator14;
        private System.Windows.Forms.ToolStripButton PN_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
        private System.Windows.Forms.ToolStripButton PN_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
        private System.Windows.Forms.ToolStripButton PN_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
        private System.Windows.Forms.ToolStripButton PN_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
        private System.Windows.Forms.ToolStripButton PN_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator28;
        private System.Windows.Forms.ToolStripButton PN_Exit;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanelThaoTac;
        private DevComponents.DotNetBar.ButtonItem buttonItemThaoTac;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanelTimLKiem;
        private DevComponents.DotNetBar.ButtonItem buttonItemTim;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelCauHinh;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonBlack;
        private DevComponents.DotNetBar.ButtonX buttonBlue;
        private DevComponents.DotNetBar.ButtonX buttonSilver;
        private DevComponents.DotNetBar.ColorPickerButton colorPickerButton;
        private DevComponents.DotNetBar.Controls.GroupPanel groupLoaiPhieuNhap;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.ButtonX btn_LPN_Huy;
        private DevComponents.DotNetBar.ButtonX btn_LPN_Luu;
        private DevComponents.DotNetBar.ButtonX btn_LPN_Sua;
        private DevComponents.DotNetBar.ButtonX btn_LPN_Them;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx LPN_cmbNguoiSua;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput LPN_dpNgaySua;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx LPN_cmbNguoiLap;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput LPN_dpNgayLap;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenLoaiPhieuNhap;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaLoaiPhieuNhap;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupLoPhieuNhap;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMoTa;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dpNgayLoNhap;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMaLoHDMua;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.ButtonX btn_LoPN_Huy;
        private DevComponents.DotNetBar.ButtonX btn_LoPN_Luu;
        private DevComponents.DotNetBar.ButtonX btn_LoPN_Sua;
        private DevComponents.DotNetBar.ButtonX btn_LoPN_Them;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx LoPN_cmbNguoiSua;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput LoPN_dpNgaySua;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx LoPN_cmbNguoiLap;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput LoPN_dpNgayLap;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPhieuPhap;
        private DevComponents.DotNetBar.Controls.TextBoxX PN_txtMT;
        private DevComponents.DotNetBar.LabelX labelX21;
        private DevComponents.DotNetBar.Controls.ComboBoxEx PN_cmbMHDM;
        private DevComponents.DotNetBar.Controls.ComboBoxEx PN_cmbMLHDM;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.Controls.ComboBoxEx PN_cmbMLPN;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private DevComponents.DotNetBar.ButtonX btn_PN_Huy;
        private DevComponents.DotNetBar.ButtonX btn_PN_Luu;
        private DevComponents.DotNetBar.ButtonX btn_PN_Sua;
        private DevComponents.DotNetBar.ButtonX btn_PN_Them;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Controls.ComboBoxEx PN_cmbNguoiSua;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput PN_dpNgaySua;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.Controls.ComboBoxEx PN_cmbNguoiLap;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput PN_dpNgayLap;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridLoPhieuNhap;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ColMLHDM;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn ColNLN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMT;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn NgayLap;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn NguoiLap;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn NgaySua;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn NguoiSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMLPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTLPN;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn NL;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn NgL;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn NS;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn NgS;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn MLPN;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn MLHDM;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn MHDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MT;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn _NL;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn _NgL;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn _NS;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn _NgS;
    }
}