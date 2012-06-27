namespace QuanLy_KeToan
{
    partial class FrmDangNhap:DevComponents.DotNetBar.Office2007Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtTenDangNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMatKhau = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Chưa Nhập Tên Đăng Nhập.");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Chưa Nhập Mật Khẩu");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.lblTop = new System.Windows.Forms.Label();
            this.btnQLDN = new DevComponents.DotNetBar.ButtonX();
            this.btnKDN = new DevComponents.DotNetBar.ButtonX();
            this.lblNgayGio = new System.Windows.Forms.Label();
            this.timerNgaygio = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(24, 53);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 17);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "<b>Tên Đăng Nhập:</b>";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(24, 92);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 17);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "<b>Mật Khẩu:</b>";
            // 
            // txtTenDangNhap
            // 
            // 
            // 
            // 
            this.txtTenDangNhap.Border.Class = "TextBoxBorder";
            this.txtTenDangNhap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDangNhap.FocusHighlightEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.txtTenDangNhap, true);
            this.txtTenDangNhap.Location = new System.Drawing.Point(129, 50);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(180, 20);
            this.txtTenDangNhap.TabIndex = 2;
            this.superValidator1.SetValidator1(this.txtTenDangNhap, this.requiredFieldValidator1);
            this.txtTenDangNhap.WatermarkText = "<b>Nhập User Name</b>";
            // 
            // txtMatKhau
            // 
            // 
            // 
            // 
            this.txtMatKhau.BackgroundStyle.Class = "TextBoxBorder";
            this.txtMatKhau.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMatKhau.BeepOnError = true;
            this.txtMatKhau.ButtonClear.Visible = true;
            this.txtMatKhau.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtMatKhau.FocusHighlightEnabled = true;
            this.highlighter1.SetHighlightOnFocus(this.txtMatKhau, true);
            this.txtMatKhau.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtMatKhau.Location = new System.Drawing.Point(129, 89);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(180, 20);
            this.txtMatKhau.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.Text = "";
            this.txtMatKhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMatKhau.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.superValidator1.SetValidator1(this.txtMatKhau, this.requiredFieldValidator2);
            this.txtMatKhau.WatermarkText = "<b>Nhập PassWord</b>";
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            this.superValidator1.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.ValidatingEventPerControl;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Chưa Nhập Tên Đăng Nhập.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Chưa Nhập Mật Khẩu";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(355, 22);
            this.lblTop.TabIndex = 4;
            this.lblTop.Text = "ĐĂNG NHẬP CHƯƠNG TRÌNH";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQLDN
            // 
            this.btnQLDN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQLDN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQLDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDN.Image = ((System.Drawing.Image)(resources.GetObject("btnQLDN.Image")));
            this.btnQLDN.Location = new System.Drawing.Point(48, 115);
            this.btnQLDN.Name = "btnQLDN";
            this.btnQLDN.Size = new System.Drawing.Size(148, 44);
            this.btnQLDN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQLDN.TabIndex = 5;
            this.btnQLDN.Text = "Quản Lý Đăng Nhập";
            this.btnQLDN.Click += new System.EventHandler(this.btnQLDN_Click);
            // 
            // btnKDN
            // 
            this.btnKDN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKDN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnKDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKDN.Image = global::QuanLy_KeToan.Properties.Resources.user;
            this.btnKDN.Location = new System.Drawing.Point(202, 115);
            this.btnKDN.Name = "btnKDN";
            this.btnKDN.Size = new System.Drawing.Size(148, 44);
            this.btnKDN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnKDN.TabIndex = 6;
            this.btnKDN.Text = "Khách Đăng Nhập";
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.AutoSize = true;
            this.lblNgayGio.Location = new System.Drawing.Point(144, 162);
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(35, 13);
            this.lblNgayGio.TabIndex = 10;
            this.lblNgayGio.Text = "label3";
            // 
            // timerNgaygio
            // 
            this.timerNgaygio.Tick += new System.EventHandler(this.timerNgaygio_Tick);
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(355, 184);
            this.Controls.Add(this.lblNgayGio);
            this.Controls.Add(this.btnKDN);
            this.Controls.Add(this.btnQLDN);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDangNhap";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtMatKhau;
        public DevComponents.DotNetBar.Controls.TextBoxX txtTenDangNhap;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private System.Windows.Forms.Label lblNgayGio;
        private DevComponents.DotNetBar.ButtonX btnKDN;
        private DevComponents.DotNetBar.ButtonX btnQLDN;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Timer timerNgaygio;


    }
}

