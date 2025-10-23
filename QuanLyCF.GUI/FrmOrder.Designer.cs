namespace QuanLyCF.GUI



{



    partial class FrmOrder



    {



        private System.ComponentModel.IContainer components = null;



        private System.Windows.Forms.Panel panelLeft;



        private System.Windows.Forms.Panel panelTop;



        private System.Windows.Forms.FlowLayoutPanel flpTables;



        private System.Windows.Forms.Label lblLogout;



        private Guna.UI2.WinForms.Guna2Button btnVuon;







        protected override void Dispose(bool disposing)



        {



            if (disposing && (components != null))



                components.Dispose();



            base.Dispose(disposing);



        }







        private void InitializeComponent()



        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnVuon = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.Label();
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
            this.panelTop.Controls.Add(this.lblLogout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1260, 60);
            this.panelTop.TabIndex = 2;
            // 
            // lblLogout
            // 
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Location = new System.Drawing.Point(1110, 0);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(150, 60);
            this.lblLogout.TabIndex = 0;
            this.lblLogout.Text = "Đăng xuất";
            this.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
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
    }



}
