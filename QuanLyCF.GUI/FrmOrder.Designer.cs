namespace QuanLyCF.GUI



{



    partial class FrmOrder



    {



        private System.ComponentModel.IContainer components = null;



        private System.Windows.Forms.Panel panelLeft;



        private System.Windows.Forms.Panel panelTop;



        private System.Windows.Forms.FlowLayoutPanel flpTables;





        private Guna.UI2.WinForms.Guna2Button btnVuon;







        protected override void Dispose(bool disposing)



        {



            if (disposing && (components != null))



                components.Dispose();



            base.Dispose(disposing);



        }







        private void InitializeComponent()



        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrder));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnVuon = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnArea = new Guna.UI2.WinForms.Guna2Button();
            this.btnStore = new Guna.UI2.WinForms.Guna2Button();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(61)))), ((int)(((byte)(38)))));
            this.panelLeft.Controls.Add(this.btnVuon);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 60);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(230, 689);
            this.panelLeft.TabIndex = 1;
            // 
            // btnVuon
            // 
            this.btnVuon.BorderRadius = 20;
            this.btnVuon.FillColor = System.Drawing.Color.White;
            this.btnVuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnVuon.ForeColor = System.Drawing.Color.Black;
            this.btnVuon.Location = new System.Drawing.Point(8, 6);
            this.btnVuon.Name = "btnVuon";
            this.btnVuon.Size = new System.Drawing.Size(216, 48);
            this.btnVuon.TabIndex = 3;
            this.btnVuon.Text = "Ngoài trời";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(61)))), ((int)(((byte)(38)))));
            this.panelTop.Controls.Add(this.guna2Button1);
            this.panelTop.Controls.Add(this.lblLogout);
            this.panelTop.Controls.Add(this.btnReport);
            this.panelTop.Controls.Add(this.guna2Button5);
            this.panelTop.Controls.Add(this.guna2Button4);
            this.panelTop.Controls.Add(this.guna2Button3);
            this.panelTop.Controls.Add(this.btnArea);
            this.panelTop.Controls.Add(this.btnStore);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1260, 60);
            this.panelTop.TabIndex = 2;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageOffset = new System.Drawing.Point(2, 0);
            this.guna2Button1.ImageSize = new System.Drawing.Size(24, 24);
            this.guna2Button1.Location = new System.Drawing.Point(572, 6);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(108, 48);
            this.guna2Button1.TabIndex = 11;
            this.guna2Button1.Text = "Loại";
            // 
            // lblLogout
            // 
            this.lblLogout.BorderRadius = 20;
            this.lblLogout.FillColor = System.Drawing.Color.White;
            this.lblLogout.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.lblLogout.ForeColor = System.Drawing.Color.Black;
            this.lblLogout.Location = new System.Drawing.Point(1038, 6);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(216, 48);
            this.lblLogout.TabIndex = 10;
            this.lblLogout.Text = "Đăng xuất";
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
            // 
            // btnReport
            // 
            this.btnReport.BorderRadius = 20;
            this.btnReport.FillColor = System.Drawing.Color.White;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageOffset = new System.Drawing.Point(2, 2);
            this.btnReport.ImageSize = new System.Drawing.Size(24, 24);
            this.btnReport.Location = new System.Drawing.Point(800, 6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(108, 48);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.BorderRadius = 20;
            this.guna2Button5.FillColor = System.Drawing.Color.White;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.guna2Button5.ForeColor = System.Drawing.Color.Black;
            this.guna2Button5.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.Image")));
            this.guna2Button5.ImageOffset = new System.Drawing.Point(2, 0);
            this.guna2Button5.ImageSize = new System.Drawing.Size(24, 24);
            this.guna2Button5.Location = new System.Drawing.Point(686, 6);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(108, 48);
            this.guna2Button5.TabIndex = 8;
            this.guna2Button5.Text = "Menu";
            // 
            // guna2Button4
            // 
            this.guna2Button4.BorderRadius = 20;
            this.guna2Button4.FillColor = System.Drawing.Color.White;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.guna2Button4.ForeColor = System.Drawing.Color.Black;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageOffset = new System.Drawing.Point(0, 1);
            this.guna2Button4.ImageSize = new System.Drawing.Size(24, 24);
            this.guna2Button4.Location = new System.Drawing.Point(458, 6);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(108, 48);
            this.guna2Button4.TabIndex = 7;
            this.guna2Button4.Text = "Staff";
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 20;
            this.guna2Button3.FillColor = System.Drawing.Color.White;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageOffset = new System.Drawing.Point(3, 2);
            this.guna2Button3.ImageSize = new System.Drawing.Size(24, 24);
            this.guna2Button3.Location = new System.Drawing.Point(344, 6);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(108, 48);
            this.guna2Button3.TabIndex = 6;
            this.guna2Button3.Text = "Bàn";
            // 
            // btnArea
            // 
            this.btnArea.BorderRadius = 20;
            this.btnArea.FillColor = System.Drawing.Color.White;
            this.btnArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnArea.ForeColor = System.Drawing.Color.Black;
            this.btnArea.Image = ((System.Drawing.Image)(resources.GetObject("btnArea.Image")));
            this.btnArea.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnArea.ImageSize = new System.Drawing.Size(24, 24);
            this.btnArea.Location = new System.Drawing.Point(230, 6);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(108, 48);
            this.btnArea.TabIndex = 5;
            this.btnArea.Text = "Khu vực";
            this.btnArea.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btnStore
            // 
            this.btnStore.BorderRadius = 20;
            this.btnStore.FillColor = System.Drawing.Color.White;
            this.btnStore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnStore.ForeColor = System.Drawing.Color.Black;
            this.btnStore.Location = new System.Drawing.Point(8, 6);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(216, 48);
            this.btnStore.TabIndex = 4;
            this.btnStore.Text = "Cửa hàng";
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // flpTables
            // 
            this.flpTables.AutoScroll = true;
            this.flpTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTables.Location = new System.Drawing.Point(230, 60);
            this.flpTables.Name = "flpTables";
            this.flpTables.Padding = new System.Windows.Forms.Padding(20);
            this.flpTables.Size = new System.Drawing.Size(1030, 689);
            this.flpTables.TabIndex = 0;
            // 
            // FrmOrder
            // 
            this.ClientSize = new System.Drawing.Size(1260, 749);
            this.Controls.Add(this.flpTables);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn";
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Button lblLogout;
        private Guna.UI2.WinForms.Guna2Button btnReport;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button btnArea;
        private Guna.UI2.WinForms.Guna2Button btnStore;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }



}
