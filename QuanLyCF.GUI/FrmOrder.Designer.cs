namespace QuanLyCF.GUI
{
    partial class FrmOrder
    {
        private System.ComponentModel.IContainer components = null;

        // LEFT area
        private System.Windows.Forms.Panel panelKhuVuc;
        private System.Windows.Forms.Button btnVuon;
        private System.Windows.Forms.Button btnBanCong;
        private System.Windows.Forms.Button btnTrongNha;

        // TABLE area
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBan;

        // TOP TOOLBAR
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Label lblHomeIcon;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblLogOut;

        /// <summary>
        /// Dọn tài nguyên
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblLogOut = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHome = new System.Windows.Forms.Panel();
            this.lblHomeIcon = new System.Windows.Forms.Label();
            this.panelKhuVuc = new System.Windows.Forms.Panel();
            this.btnTrongNha = new System.Windows.Forms.Button();
            this.btnBanCong = new System.Windows.Forms.Button();
            this.btnVuon = new System.Windows.Forms.Button();
            this.tableLayoutPanelBan = new System.Windows.Forms.TableLayoutPanel();

            this.panelTopBar.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelHome.SuspendLayout();
            this.panelKhuVuc.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTopBar.Controls.Add(this.flpActions);
            this.panelTopBar.Controls.Add(this.panelTitle);
            this.panelTopBar.Controls.Add(this.panelHome);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(2056, 70);
            this.panelTopBar.TabIndex = 2;

            // 
            // flpActions
            // 
            this.flpActions.BackColor = System.Drawing.Color.RoyalBlue;
            this.flpActions.Controls.Add(this.lblDoanhThu);
            this.flpActions.Controls.Add(this.lblLogOut);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpActions.Location = new System.Drawing.Point(1634, 0);
            this.flpActions.Name = "flpActions";
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 18, 0);
            this.flpActions.Size = new System.Drawing.Size(422, 70);
            this.flpActions.TabIndex = 0;
            this.flpActions.WrapContents = false;

            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThu.Location = new System.Drawing.Point(5, 0);
            this.lblDoanhThu.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(193, 70);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "Doanh Thu";
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDoanhThu.Click += new System.EventHandler(this.lblDoanhThu_Click);

            // 
            // lblLogOut
            // 
            this.lblLogOut.BackColor = System.Drawing.Color.Transparent;
            this.lblLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogOut.ForeColor = System.Drawing.Color.White;
            this.lblLogOut.Location = new System.Drawing.Point(208, 0);
            this.lblLogOut.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(214, 70);
            this.lblLogOut.TabIndex = 1;
            this.lblLogOut.Text = "Đăng Xuất";
            this.lblLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogOut.Click += new System.EventHandler(this.TopBar_Menu_Click);

            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTitle.Location = new System.Drawing.Point(90, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(360, 70);
            this.panelTitle.TabIndex = 1;

            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(360, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách hóa đơn";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelHome.Controls.Add(this.lblHomeIcon);
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHome.Location = new System.Drawing.Point(0, 0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(90, 70);
            this.panelHome.TabIndex = 2;

            // 
            // lblHomeIcon
            // 
            this.lblHomeIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHomeIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHomeIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 22F);
            this.lblHomeIcon.ForeColor = System.Drawing.Color.White;
            this.lblHomeIcon.Location = new System.Drawing.Point(0, 0);
            this.lblHomeIcon.Name = "lblHomeIcon";
            this.lblHomeIcon.Size = new System.Drawing.Size(90, 70);
            this.lblHomeIcon.TabIndex = 0;
            this.lblHomeIcon.Text = "⌂";
            this.lblHomeIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHomeIcon.Click += new System.EventHandler(this.TopBar_Home_Click);

            // 
            // panelKhuVuc
            // 
            this.panelKhuVuc.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelKhuVuc.Controls.Add(this.btnTrongNha);
            this.panelKhuVuc.Controls.Add(this.btnBanCong);
            this.panelKhuVuc.Controls.Add(this.btnVuon);
            this.panelKhuVuc.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelKhuVuc.Location = new System.Drawing.Point(0, 70);
            this.panelKhuVuc.Name = "panelKhuVuc";
            this.panelKhuVuc.Size = new System.Drawing.Size(351, 1045);
            this.panelKhuVuc.TabIndex = 1;

            // 
            // btnVuon
            // 
            this.btnVuon.BackColor = System.Drawing.Color.White;
            this.btnVuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVuon.Location = new System.Drawing.Point(20, 100);
            this.btnVuon.Name = "btnVuon";
            this.btnVuon.Size = new System.Drawing.Size(260, 147);
            this.btnVuon.TabIndex = 0;
            this.btnVuon.Text = "Ngoài trời";
            this.btnVuon.UseVisualStyleBackColor = false;
            //this.btnVuon.Click += new System.EventHandler(this.BtnVuon_Click);

            // 
            // btnBanCong
            // 
            this.btnBanCong.BackColor = System.Drawing.Color.White;
            this.btnBanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanCong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBanCong.Location = new System.Drawing.Point(29, 359);
            this.btnBanCong.Name = "btnBanCong";
            this.btnBanCong.Size = new System.Drawing.Size(251, 154);
            this.btnBanCong.TabIndex = 1;
            this.btnBanCong.Text = "Ban Công";
            this.btnBanCong.UseVisualStyleBackColor = false;
            //this.btnBanCong.Click += new System.EventHandler(this.BtnBanCong_Click)

            // 
            // btnTrongNha
            // 
            this.btnTrongNha.BackColor = System.Drawing.Color.White;
            this.btnTrongNha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrongNha.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTrongNha.Location = new System.Drawing.Point(29, 658);
            this.btnTrongNha.Name = "btnTrongNha";
            this.btnTrongNha.Size = new System.Drawing.Size(251, 145);
            this.btnTrongNha.TabIndex = 2;
            this.btnTrongNha.Text = "Trong Nhà";
            this.btnTrongNha.UseVisualStyleBackColor = false;
            //this.btnTrongNha.Click += new System.EventHandler(this.BtnTrongNha_Click);

            // 
            // tableLayoutPanelBan
            // 
            this.tableLayoutPanelBan.BackColor = System.Drawing.Color.LavenderBlush;
            this.tableLayoutPanelBan.ColumnCount = 5;
            this.tableLayoutPanelBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelBan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBan.Location = new System.Drawing.Point(351, 70);
            this.tableLayoutPanelBan.Name = "tableLayoutPanelBan";
            this.tableLayoutPanelBan.Padding = new System.Windows.Forms.Padding(25);
            this.tableLayoutPanelBan.RowCount = 4;
            this.tableLayoutPanelBan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelBan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelBan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelBan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelBan.Size = new System.Drawing.Size(1705, 1045);
            this.tableLayoutPanelBan.TabIndex = 0;

            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2056, 1115);
            this.Controls.Add(this.tableLayoutPanelBan);
            this.Controls.Add(this.panelKhuVuc);
            this.Controls.Add(this.panelTopBar);
            this.Name = "FrmOrder";
            this.Text = "FormOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmOrder_Load);

            this.panelTopBar.ResumeLayout(false);
            this.flpActions.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            this.panelKhuVuc.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
