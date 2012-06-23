namespace QuanLy_KeToan.PresentationLayer
{
    partial class FormCho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCho));
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.SuspendLayout();
            // 
            // circularProgress
            // 
            this.circularProgress.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.Class = "";
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circularProgress.Location = new System.Drawing.Point(0, 0);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgress.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.circularProgress.ProgressText = "Đang Load Dữ Liệu";
            this.circularProgress.ProgressTextColor = System.Drawing.Color.DeepSkyBlue;
            this.circularProgress.Size = new System.Drawing.Size(116, 98);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 0;
            // 
            // FormCho
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(116, 98);
            this.ControlBox = false;
            this.Controls.Add(this.circularProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCho";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCho_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;

    }
}