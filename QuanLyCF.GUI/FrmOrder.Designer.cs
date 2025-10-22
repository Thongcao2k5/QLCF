namespace QuanLyCF.GUI
{
    partial class FrmOrder
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnVuon;
        private System.Windows.Forms.Button btnBanCong;
        private System.Windows.Forms.Button btnTrongNha;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblBanPhucVu;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblLogout;

        private System.Windows.Forms.FlowLayoutPanel flpTables;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnVuon = new System.Windows.Forms.Button();
            this.btnBanCong = new System.Windows.Forms.Button();
            this.btnTrongNha = new System.Windows.Forms.Button();

            this.panelTop = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblBanPhucVu = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();

            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();

            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelLeft.Controls.Add(this.btnTrongNha);
            this.panelLeft.Controls.Add(this.btnBanCong);
            this.panelLeft.Controls.Add(this.btnVuon);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width = 230;

            // 
            // btnVuon
            // 
            this.btnVuon.Text = "Ngoài trời";
            this.btnVuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVuon.Height = 100;
            this.btnVuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVuon.FlatAppearance.BorderSize = 1;
            this.btnVuon.Click += new System.EventHandler(this.btnVuon_Click);

            // 
            // btnBanCong
            // 
            this.btnBanCong.Text = "Ban công";
            this.btnBanCong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanCong.Height = 100;
            this.btnBanCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanCong.FlatAppearance.BorderSize = 1;
            this.btnBanCong.Click += new System.EventHandler(this.btnBanCong_Click);

            // 
            // btnTrongNha
            // 
            this.btnTrongNha.Text = "Trong nhà";
            this.btnTrongNha.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrongNha.Height = 100;
            this.btnTrongNha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTrongNha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrongNha.FlatAppearance.BorderSize = 1;
            this.btnTrongNha.Click += new System.EventHandler(this.btnTrongNha_Click);

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;

            // Thứ tự hiển thị trái -> phải
            this.panelTop.Controls.Add(this.lblLogout);
            this.panelTop.Controls.Add(this.lblDoanhThu);
            this.panelTop.Controls.Add(this.lblBanPhucVu);
            this.panelTop.Controls.Add(this.lblHome);

            // 
            // lblHome
            // 
            this.lblHome.Text = "⌂";
            this.lblHome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHome.Width = 80;
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);

            // 
            // lblBanPhucVu
            // 
            this.lblBanPhucVu.Text = "Bàn đang phục vụ";
            this.lblBanPhucVu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBanPhucVu.ForeColor = System.Drawing.Color.White;
            this.lblBanPhucVu.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBanPhucVu.Width = 200;
            this.lblBanPhucVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBanPhucVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBanPhucVu.Click += new System.EventHandler(this.lblBanPhucVu_Click);

            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Text = "Doanh thu";
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThu.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDoanhThu.Width = 150;
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDoanhThu.Click += new System.EventHandler(this.lblDoanhThu_Click);

            // 
            // lblLogout
            // 
            this.lblLogout.Text = "Đăng xuất";
            this.lblLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLogout.Width = 150;
            this.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);

            // 
            // flpTables
            // 
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTables.AutoScroll = true;
            this.flpTables.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpTables.Padding = new System.Windows.Forms.Padding(20);

            // 
            // FrmOrder
            // 
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.flpTables);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmOrder";
            this.Text = "Quản lý bàn";
            this.Load += new System.EventHandler(this.FrmOrder_Load);

            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
