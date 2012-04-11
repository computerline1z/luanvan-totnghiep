namespace QuanLy_KeToan.PresentationLayer
{
    partial class FHangHoa:DevComponents.DotNetBar.Office2007Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHangHoa));
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.tabQLHangHoa = new DevComponents.DotNetBar.TabControl();
            this.tabControlHangHoa = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanelHangHoa = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.gridHangHoa = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingHangHoa = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.advTreeLoaiHangHoa = new DevComponents.AdvTree.AdvTree();
            this.NodeLoaiHangHoa = new DevComponents.AdvTree.Node();
            this.NodeNhaCungCap = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle7 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle6 = new DevComponents.DotNetBar.ElementStyle();
            this.expandablePanelTimKiem = new DevComponents.DotNetBar.ExpandablePanel();
            this.tabHangHoa = new DevComponents.DotNetBar.TabItem(this.components);
            this.ColumnDanhMuc = new DevComponents.AdvTree.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.tabQLHangHoa)).BeginInit();
            this.tabQLHangHoa.SuspendLayout();
            this.tabControlHangHoa.SuspendLayout();
            this.groupPanelHangHoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHangHoa)).BeginInit();
            this.bindingHangHoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeLoaiHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // tabQLHangHoa
            // 
            this.tabQLHangHoa.BackColor = System.Drawing.Color.White;
            this.tabQLHangHoa.CanReorderTabs = true;
            this.tabQLHangHoa.Controls.Add(this.tabControlHangHoa);
            this.tabQLHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabQLHangHoa.ForeColor = System.Drawing.Color.Black;
            this.tabQLHangHoa.Location = new System.Drawing.Point(0, 0);
            this.tabQLHangHoa.Name = "tabQLHangHoa";
            this.tabQLHangHoa.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabQLHangHoa.SelectedTabIndex = 0;
            this.tabQLHangHoa.Size = new System.Drawing.Size(1354, 692);
            this.tabQLHangHoa.TabIndex = 2;
            this.tabQLHangHoa.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabQLHangHoa.Tabs.Add(this.tabHangHoa);
            // 
            // tabControlHangHoa
            // 
            this.tabControlHangHoa.Controls.Add(this.groupPanelHangHoa);
            this.tabControlHangHoa.Controls.Add(this.expandablePanelTimKiem);
            this.tabControlHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHangHoa.Location = new System.Drawing.Point(0, 26);
            this.tabControlHangHoa.Name = "tabControlHangHoa";
            this.tabControlHangHoa.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlHangHoa.Size = new System.Drawing.Size(1354, 666);
            this.tabControlHangHoa.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlHangHoa.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlHangHoa.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlHangHoa.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlHangHoa.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlHangHoa.Style.GradientAngle = 90;
            this.tabControlHangHoa.TabIndex = 1;
            this.tabControlHangHoa.TabItem = this.tabHangHoa;
            // 
            // groupPanelHangHoa
            // 
            this.groupPanelHangHoa.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelHangHoa.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelHangHoa.Controls.Add(this.gridHangHoa);
            this.groupPanelHangHoa.Controls.Add(this.bindingHangHoa);
            this.groupPanelHangHoa.Controls.Add(this.advTreeLoaiHangHoa);
            this.groupPanelHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanelHangHoa.Location = new System.Drawing.Point(31, 1);
            this.groupPanelHangHoa.Name = "groupPanelHangHoa";
            this.groupPanelHangHoa.Size = new System.Drawing.Size(1322, 664);
            // 
            // 
            // 
            this.groupPanelHangHoa.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelHangHoa.Style.BackColorGradientAngle = 90;
            this.groupPanelHangHoa.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelHangHoa.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelHangHoa.Style.BorderBottomWidth = 1;
            this.groupPanelHangHoa.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelHangHoa.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelHangHoa.Style.BorderLeftWidth = 1;
            this.groupPanelHangHoa.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelHangHoa.Style.BorderRightWidth = 1;
            this.groupPanelHangHoa.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelHangHoa.Style.BorderTopWidth = 1;
            this.groupPanelHangHoa.Style.Class = "";
            this.groupPanelHangHoa.Style.CornerDiameter = 4;
            this.groupPanelHangHoa.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelHangHoa.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelHangHoa.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelHangHoa.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelHangHoa.StyleMouseDown.Class = "";
            this.groupPanelHangHoa.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelHangHoa.StyleMouseOver.Class = "";
            this.groupPanelHangHoa.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelHangHoa.TabIndex = 4;
            // 
            // gridHangHoa
            // 
            this.gridHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHang});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHangHoa.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHangHoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridHangHoa.Location = new System.Drawing.Point(240, 25);
            this.gridHangHoa.Name = "gridHangHoa";
            this.gridHangHoa.Size = new System.Drawing.Size(1076, 633);
            this.gridHangHoa.TabIndex = 2;
            // 
            // MaHang
            // 
            this.MaHang.DataPropertyName = "MaHang";
            this.MaHang.HeaderText = "Mã Hàng";
            this.MaHang.Name = "MaHang";
            // 
            // bindingHangHoa
            // 
            this.bindingHangHoa.AddNewItem = null;
            this.bindingHangHoa.BackColor = System.Drawing.Color.Transparent;
            this.bindingHangHoa.CountItem = this.bindingNavigatorCountItem;
            this.bindingHangHoa.CountItemFormat = "của {0}";
            this.bindingHangHoa.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingHangHoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingHangHoa.Location = new System.Drawing.Point(240, 0);
            this.bindingHangHoa.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingHangHoa.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingHangHoa.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingHangHoa.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingHangHoa.Name = "bindingHangHoa";
            this.bindingHangHoa.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingHangHoa.Size = new System.Drawing.Size(1076, 25);
            this.bindingHangHoa.TabIndex = 3;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "của {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // advTreeLoaiHangHoa
            // 
            this.advTreeLoaiHangHoa.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeLoaiHangHoa.AllowDrop = true;
            this.advTreeLoaiHangHoa.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeLoaiHangHoa.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeLoaiHangHoa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeLoaiHangHoa.CellEdit = true;
            this.advTreeLoaiHangHoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.advTreeLoaiHangHoa.GridColumnLines = false;
            this.advTreeLoaiHangHoa.GridLinesColor = System.Drawing.Color.DodgerBlue;
            this.advTreeLoaiHangHoa.HotTracking = true;
            this.advTreeLoaiHangHoa.Location = new System.Drawing.Point(0, 0);
            this.advTreeLoaiHangHoa.Name = "advTreeLoaiHangHoa";
            this.advTreeLoaiHangHoa.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.NodeLoaiHangHoa,
            this.NodeNhaCungCap});
            this.advTreeLoaiHangHoa.NodesConnector = this.nodeConnector1;
            this.advTreeLoaiHangHoa.NodeStyle = this.elementStyle7;
            this.advTreeLoaiHangHoa.PathSeparator = ";";
            this.advTreeLoaiHangHoa.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.advTreeLoaiHangHoa.Size = new System.Drawing.Size(240, 658);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle1);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle2);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle3);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle4);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle5);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle6);
            this.advTreeLoaiHangHoa.Styles.Add(this.elementStyle7);
            this.advTreeLoaiHangHoa.TabIndex = 4;
            this.advTreeLoaiHangHoa.Text = "Loại Hàng Hóa";
            this.advTreeLoaiHangHoa.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTreeLoaiHangHoa_AfterNodeSelect);
            // 
            // NodeLoaiHangHoa
            // 
            this.NodeLoaiHangHoa.Expanded = true;
            this.NodeLoaiHangHoa.Image = global::QuanLy_KeToan.Properties.Resources.categories;
            this.NodeLoaiHangHoa.Name = "NodeLoaiHangHoa";
            this.NodeLoaiHangHoa.Text = "Danh Mục Loại Mặt Hàng";
            // 
            // NodeNhaCungCap
            // 
            this.NodeNhaCungCap.Expanded = true;
            this.NodeNhaCungCap.Image = ((System.Drawing.Image)(resources.GetObject("NodeNhaCungCap.Image")));
            this.NodeNhaCungCap.Name = "NodeNhaCungCap";
            this.NodeNhaCungCap.Text = "Danh Mục Nhà Cung Cấp";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle7
            // 
            this.elementStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.elementStyle7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(176)))), ((int)(((byte)(120)))));
            this.elementStyle7.BackColorGradientAngle = 90;
            this.elementStyle7.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderBottomWidth = 1;
            this.elementStyle7.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle7.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderLeftWidth = 1;
            this.elementStyle7.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderRightWidth = 1;
            this.elementStyle7.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle7.BorderTopWidth = 1;
            this.elementStyle7.Class = "";
            this.elementStyle7.CornerDiameter = 4;
            this.elementStyle7.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle7.Description = "Orange";
            this.elementStyle7.Name = "elementStyle7";
            this.elementStyle7.PaddingBottom = 1;
            this.elementStyle7.PaddingLeft = 1;
            this.elementStyle7.PaddingRight = 1;
            this.elementStyle7.PaddingTop = 1;
            this.elementStyle7.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
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
            this.elementStyle2.Description = "Blue";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle3
            // 
            this.elementStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
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
            this.elementStyle3.Description = "BlueLight";
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.PaddingBottom = 1;
            this.elementStyle3.PaddingLeft = 1;
            this.elementStyle3.PaddingRight = 1;
            this.elementStyle3.PaddingTop = 1;
            this.elementStyle3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
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
            this.elementStyle4.Description = "Blue";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle5
            // 
            this.elementStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle5.BackColorGradientAngle = 90;
            this.elementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderBottomWidth = 1;
            this.elementStyle5.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderLeftWidth = 1;
            this.elementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderRightWidth = 1;
            this.elementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle5.BorderTopWidth = 1;
            this.elementStyle5.Class = "";
            this.elementStyle5.CornerDiameter = 4;
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Description = "Blue";
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.PaddingBottom = 1;
            this.elementStyle5.PaddingLeft = 1;
            this.elementStyle5.PaddingRight = 1;
            this.elementStyle5.PaddingTop = 1;
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle6
            // 
            this.elementStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.elementStyle6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.elementStyle6.BackColorGradientAngle = 90;
            this.elementStyle6.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderBottomWidth = 1;
            this.elementStyle6.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle6.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderLeftWidth = 1;
            this.elementStyle6.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderRightWidth = 1;
            this.elementStyle6.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle6.BorderTopWidth = 1;
            this.elementStyle6.Class = "";
            this.elementStyle6.CornerDiameter = 4;
            this.elementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle6.Description = "Yellow";
            this.elementStyle6.Name = "elementStyle6";
            this.elementStyle6.PaddingBottom = 1;
            this.elementStyle6.PaddingLeft = 1;
            this.elementStyle6.PaddingRight = 1;
            this.elementStyle6.PaddingTop = 1;
            this.elementStyle6.TextColor = System.Drawing.Color.Black;
            // 
            // expandablePanelTimKiem
            // 
            this.expandablePanelTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.expandablePanelTimKiem.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelTimKiem.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanelTimKiem.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanelTimKiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanelTimKiem.Expanded = false;
            this.expandablePanelTimKiem.ExpandedBounds = new System.Drawing.Rectangle(1, 1, 209, 664);
            this.expandablePanelTimKiem.Location = new System.Drawing.Point(1, 1);
            this.expandablePanelTimKiem.Name = "expandablePanelTimKiem";
            this.expandablePanelTimKiem.Size = new System.Drawing.Size(30, 664);
            this.expandablePanelTimKiem.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelTimKiem.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanelTimKiem.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanelTimKiem.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelTimKiem.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelTimKiem.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelTimKiem.Style.GradientAngle = 90;
            this.expandablePanelTimKiem.TabIndex = 3;
            this.expandablePanelTimKiem.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelTimKiem.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanelTimKiem.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanelTimKiem.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanelTimKiem.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelTimKiem.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanelTimKiem.TitleStyle.GradientAngle = 90;
            this.expandablePanelTimKiem.TitleText = "Tìm Kiếm";
            // 
            // tabHangHoa
            // 
            this.tabHangHoa.AttachedControl = this.tabControlHangHoa;
            this.tabHangHoa.Name = "tabHangHoa";
            this.tabHangHoa.Text = "Danh Mục Hàng Hóa";
            // 
            // ColumnDanhMuc
            // 
            this.ColumnDanhMuc.Name = "ColumnDanhMuc";
            this.ColumnDanhMuc.Width.Absolute = 150;
            // 
            // FHangHoa
            // 
            this.ClientSize = new System.Drawing.Size(1354, 692);
            this.Controls.Add(this.tabQLHangHoa);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyHangHoa";
            this.Load += new System.EventHandler(this.FHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabQLHangHoa)).EndInit();
            this.tabQLHangHoa.ResumeLayout(false);
            this.tabControlHangHoa.ResumeLayout(false);
            this.groupPanelHangHoa.ResumeLayout(false);
            this.groupPanelHangHoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHangHoa)).EndInit();
            this.bindingHangHoa.ResumeLayout(false);
            this.bindingHangHoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeLoaiHangHoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.TabControl tabQLHangHoa;
        private DevComponents.DotNetBar.TabControlPanel tabControlHangHoa;
        private DevComponents.DotNetBar.TabItem tabHangHoa;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanelTimKiem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelHangHoa;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridHangHoa;
        private System.Windows.Forms.BindingNavigator bindingHangHoa;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DevComponents.AdvTree.AdvTree advTreeLoaiHangHoa;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader ColumnDanhMuc;
        private DevComponents.DotNetBar.ElementStyle elementStyle7;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.DotNetBar.ElementStyle elementStyle6;
        private DevComponents.AdvTree.Node NodeLoaiHangHoa;
        private DevComponents.AdvTree.Node NodeNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHang;
    }
}