using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLyCF.GUI
{
    partial class FrmEditTables

    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private Guna2Button btnVuon;
        private Guna2Button lblLogout;
        private Guna2Button guna2Button5;
        private Guna2Button guna2Button4;
        private Guna2Button guna2Button3;
        private Guna2Button btnArea;
        private Guna2Button btnStore;
        private Guna2Button guna2Button6;

        // 🔹 Nút mới
        private Guna2Button btnAddTable;
        private Guna2Button btnDeleteTable;

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
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.lblLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnArea = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnStore = new Guna.UI2.WinForms.Guna2Button();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTable = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteTable = new Guna.UI2.WinForms.Guna2Button();
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
            this.panelTop.Controls.Add(this.guna2Button6);
            this.panelTop.Controls.Add(this.lblLogout);
            this.panelTop.Controls.Add(this.btnArea);
            this.panelTop.Controls.Add(this.guna2Button5);
            this.panelTop.Controls.Add(this.guna2Button4);
            this.panelTop.Controls.Add(this.guna2Button3);
            this.panelTop.Controls.Add(this.btnStore);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1260, 60);
            this.panelTop.TabIndex = 2;
            // 
            // guna2Button6
            // 
            this.guna2Button6.BorderRadius = 20;
            this.guna2Button6.FillColor = System.Drawing.Color.White;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.guna2Button6.ForeColor = System.Drawing.Color.Black;
            this.guna2Button6.Location = new System.Drawing.Point(8, 9);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(172, 42);
            this.guna2Button6.TabIndex = 12;
            this.guna2Button6.Text = "Tài khoản";
            // 
            // lblLogout
            // 
            this.lblLogout.BorderRadius = 20;
            this.lblLogout.FillColor = System.Drawing.Color.White;
            this.lblLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
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
            this.btnArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnArea.ForeColor = System.Drawing.Color.White;
            this.btnArea.Location = new System.Drawing.Point(0, 0);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(180, 45);
            this.btnArea.TabIndex = 13;
            // 
            // guna2Button5
            // 
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Location = new System.Drawing.Point(0, 0);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(180, 45);
            this.guna2Button5.TabIndex = 14;
            // 
            // guna2Button4
            // 
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Location = new System.Drawing.Point(0, 0);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(180, 45);
            this.guna2Button4.TabIndex = 15;
            // 
            // guna2Button3
            // 
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(0, 0);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(180, 45);
            this.guna2Button3.TabIndex = 16;
            // 
            // btnStore
            // 
            this.btnStore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStore.ForeColor = System.Drawing.Color.White;
            this.btnStore.Location = new System.Drawing.Point(0, 0);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(180, 45);
            this.btnStore.TabIndex = 17;
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
            // btnAddTable
            // 
            this.btnAddTable.BorderRadius = 12;
            this.btnAddTable.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnAddTable.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddTable.ForeColor = System.Drawing.Color.White;
            this.btnAddTable.Location = new System.Drawing.Point(950, 70);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(140, 45);
            this.btnAddTable.TabIndex = 0;
            this.btnAddTable.Text = "➕ Thêm bàn";
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.BorderRadius = 12;
            this.btnDeleteTable.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(96)))), ((int)(((byte)(90)))));
            this.btnDeleteTable.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTable.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTable.Location = new System.Drawing.Point(1100, 70);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(140, 45);
            this.btnDeleteTable.TabIndex = 1;
            this.btnDeleteTable.Text = "🗑️ Xóa bàn";
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // FrmEditTables
            // 
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.flpTables);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEditTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bàn";
            this.Load += new System.EventHandler(this.FrmEditTables_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
