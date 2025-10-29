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
            this.btnUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnDinkType = new Guna.UI2.WinForms.Guna2Button();
            this.lblLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnArea = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.btnDrink = new Guna.UI2.WinForms.Guna2Button();
            this.BtnStaff = new Guna.UI2.WinForms.Guna2Button();
            this.BtnEditTables = new Guna.UI2.WinForms.Guna2Button();
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
            this.panelLeft.Size = new System.Drawing.Size(165, 690);
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
            this.btnVuon.Size = new System.Drawing.Size(146, 48);
            this.btnVuon.TabIndex = 3;
            this.btnVuon.Text = "Ngoài trời";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(61)))), ((int)(((byte)(38)))));
            this.panelTop.Controls.Add(this.btnUser);
            this.panelTop.Controls.Add(this.btnDinkType);
            this.panelTop.Controls.Add(this.lblLogout);
            this.panelTop.Controls.Add(this.btnArea);
            this.panelTop.Controls.Add(this.btnReport);
            this.panelTop.Controls.Add(this.btnDrink);
            this.panelTop.Controls.Add(this.BtnStaff);
            this.panelTop.Controls.Add(this.BtnEditTables);
            this.panelTop.Controls.Add(this.btnStore);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1260, 60);
            this.panelTop.TabIndex = 2;
            // 
            // btnUser
            // 
            this.btnUser.BorderRadius = 20;
            this.btnUser.FillColor = System.Drawing.Color.White;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnUser.ForeColor = System.Drawing.Color.Black;
            this.btnUser.Location = new System.Drawing.Point(8, 9);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(112, 42);
            this.btnUser.TabIndex = 12;
            this.btnUser.Text = "Tài khoản";
            // 
            // btnDinkType
            // 
            this.btnDinkType.BorderRadius = 20;
            this.btnDinkType.FillColor = System.Drawing.Color.White;
            this.btnDinkType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnDinkType.ForeColor = System.Drawing.Color.Black;
            this.btnDinkType.Image = ((System.Drawing.Image)(resources.GetObject("btnDinkType.Image")));
            this.btnDinkType.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnDinkType.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDinkType.Location = new System.Drawing.Point(586, 9);
            this.btnDinkType.Name = "btnDinkType";
            this.btnDinkType.Size = new System.Drawing.Size(108, 42);
            this.btnDinkType.TabIndex = 11;
            this.btnDinkType.Text = "Loại";
            this.btnDinkType.Click += new System.EventHandler(this.btnDinkType_Click);
            // 
            // lblLogout
            // 
            this.lblLogout.BorderRadius = 20;
            this.lblLogout.FillColor = System.Drawing.Color.White;
            this.lblLogout.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.lblLogout.ForeColor = System.Drawing.Color.Black;
            this.lblLogout.Location = new System.Drawing.Point(1102, 9);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(146, 42);
            this.lblLogout.TabIndex = 10;
            this.lblLogout.Text = "Đăng xuất";
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
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
            this.btnArea.Location = new System.Drawing.Point(244, 9);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(108, 42);
            this.btnArea.TabIndex = 5;
            this.btnArea.Text = "Khu vực";
            this.btnArea.Click += new System.EventHandler(this.guna2Button2_Click);
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
            this.btnReport.Location = new System.Drawing.Point(814, 9);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(108, 42);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDrink
            // 
            this.btnDrink.BorderRadius = 20;
            this.btnDrink.FillColor = System.Drawing.Color.White;
            this.btnDrink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnDrink.ForeColor = System.Drawing.Color.Black;
            this.btnDrink.Image = ((System.Drawing.Image)(resources.GetObject("btnDrink.Image")));
            this.btnDrink.ImageOffset = new System.Drawing.Point(2, 0);
            this.btnDrink.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDrink.Location = new System.Drawing.Point(700, 9);
            this.btnDrink.Name = "btnDrink";
            this.btnDrink.Size = new System.Drawing.Size(108, 42);
            this.btnDrink.TabIndex = 8;
            this.btnDrink.Text = "Menu";
            this.btnDrink.Click += new System.EventHandler(this.btnDrink_Click);
            // 
            // BtnStaff
            // 
            this.BtnStaff.BorderRadius = 20;
            this.BtnStaff.FillColor = System.Drawing.Color.White;
            this.BtnStaff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.BtnStaff.ForeColor = System.Drawing.Color.Black;
            this.BtnStaff.Image = ((System.Drawing.Image)(resources.GetObject("BtnStaff.Image")));
            this.BtnStaff.ImageOffset = new System.Drawing.Point(0, 1);
            this.BtnStaff.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnStaff.Location = new System.Drawing.Point(472, 9);
            this.BtnStaff.Name = "BtnStaff";
            this.BtnStaff.Size = new System.Drawing.Size(108, 42);
            this.BtnStaff.TabIndex = 7;
            this.BtnStaff.Text = "Staff";
            this.BtnStaff.Click += new System.EventHandler(this.BtnStaff_Click);
            // 
            // BtnEditTables
            // 
            this.BtnEditTables.BorderRadius = 20;
            this.BtnEditTables.FillColor = System.Drawing.Color.White;
            this.BtnEditTables.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.BtnEditTables.ForeColor = System.Drawing.Color.Black;
            this.BtnEditTables.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditTables.Image")));
            this.BtnEditTables.ImageOffset = new System.Drawing.Point(3, 2);
            this.BtnEditTables.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnEditTables.Location = new System.Drawing.Point(358, 9);
            this.BtnEditTables.Name = "BtnEditTables";
            this.BtnEditTables.Size = new System.Drawing.Size(108, 42);
            this.BtnEditTables.TabIndex = 6;
            this.BtnEditTables.Text = "Bàn";
            this.BtnEditTables.Click += new System.EventHandler(this.BtnEditTables_Click);
            // 
            // btnStore
            // 
            this.btnStore.BorderRadius = 20;
            this.btnStore.FillColor = System.Drawing.Color.White;
            this.btnStore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.btnStore.ForeColor = System.Drawing.Color.Black;
            this.btnStore.Location = new System.Drawing.Point(126, 9);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(112, 42);
            this.btnStore.TabIndex = 4;
            this.btnStore.Text = "Cửa hàng";
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // flpTables
            // 
            this.flpTables.AutoScroll = true;
            this.flpTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTables.Location = new System.Drawing.Point(165, 60);
            this.flpTables.Name = "flpTables";
            this.flpTables.Padding = new System.Windows.Forms.Padding(20);
            this.flpTables.Size = new System.Drawing.Size(1095, 690);
            this.flpTables.TabIndex = 0;
            // 
            // FrmOrder
            // 
            this.ClientSize = new System.Drawing.Size(1260, 750);
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
        private Guna.UI2.WinForms.Guna2Button btnDrink;
        private Guna.UI2.WinForms.Guna2Button BtnStaff;
        private Guna.UI2.WinForms.Guna2Button BtnEditTables;
        private Guna.UI2.WinForms.Guna2Button btnArea;
        private Guna.UI2.WinForms.Guna2Button btnStore;
        private Guna.UI2.WinForms.Guna2Button btnDinkType;
        private Guna.UI2.WinForms.Guna2Button btnUser;
    }



}
