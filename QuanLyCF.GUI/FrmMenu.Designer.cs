using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace QuanLyCF.GUI
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2Panel panelTop;
        private Guna2Panel panelLeft;
        private Guna2Panel panelRight;
        private FlowLayoutPanel flpMenuItems;
        private Guna2TextBox txtSearch;
        private Label lblSearch;
        private Guna2Button btnBack;
        private Guna2Button btnSaveOrder;
        private Guna2Button btnPay;
        private Guna2Button btnCancel;
        private DataGridView dgvOrder;
        private Label lblTotal;
        private Label lblTitle;
        private ComboBox cbCustomerType;
        private Label lblCustomerType;
        private TextBox txtDiscount;
        private Label lblDiscount;

        private DataGridViewTextBoxColumn colDrinkID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.flpMenuItems = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.colDrinkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.cbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveOrder = new Guna.UI2.WinForms.Guna2Button();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(61)))), ((int)(((byte)(38)))));
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1300, 70);
            this.panelTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "☕ MENU ĐỒ UỐNG";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(834, 32);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(120, 23);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "🔍 Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(960, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Nhập tên món...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(250, 35);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.flpMenuItems);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(30)))));
            this.panelLeft.Location = new System.Drawing.Point(0, 70);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(920, 730);
            this.panelLeft.TabIndex = 0;
            // 
            // flpMenuItems
            // 
            this.flpMenuItems.AutoScroll = true;
            this.flpMenuItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(30)))));
            this.flpMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenuItems.Location = new System.Drawing.Point(0, 0);
            this.flpMenuItems.Name = "flpMenuItems";
            this.flpMenuItems.Padding = new System.Windows.Forms.Padding(20);
            this.flpMenuItems.Size = new System.Drawing.Size(920, 730);
            this.flpMenuItems.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvOrder);
            this.panelRight.Controls.Add(this.lblCustomerType);
            this.panelRight.Controls.Add(this.cbCustomerType);
            this.panelRight.Controls.Add(this.lblDiscount);
            this.panelRight.Controls.Add(this.txtDiscount);
            this.panelRight.Controls.Add(this.lblTotal);
            this.panelRight.Controls.Add(this.btnCancel);
            this.panelRight.Controls.Add(this.btnSaveOrder);
            this.panelRight.Controls.Add(this.btnPay);
            this.panelRight.Controls.Add(this.btnBack);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.FillColor = System.Drawing.Color.White;
            this.panelRight.Location = new System.Drawing.Point(920, 70);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(15);
            this.panelRight.Size = new System.Drawing.Size(380, 730);
            this.panelRight.TabIndex = 1;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrder.ColumnHeadersHeight = 29;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDrinkID,
            this.colName,
            this.colQty,
            this.colPrice});
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrder.Location = new System.Drawing.Point(15, 15);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.Size = new System.Drawing.Size(350, 420);
            this.dgvOrder.TabIndex = 0;
            // 
            // colDrinkID
            // 
            this.colDrinkID.MinimumWidth = 6;
            this.colDrinkID.Name = "colDrinkID";
            this.colDrinkID.Visible = false;
            this.colDrinkID.Width = 125;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tên món";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 160;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "SL";
            this.colQty.MinimumWidth = 6;
            this.colQty.Name = "colQty";
            this.colQty.Width = 40;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Thành tiền";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerType.Location = new System.Drawing.Point(15, 450);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(108, 23);
            this.lblCustomerType.TabIndex = 1;
            this.lblCustomerType.Text = "Khách hàng:";
            // 
            // cbCustomerType
            // 
            this.cbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomerType.Items.AddRange(new object[] {
            "Khách lẻ",
            "Thành viên",
            "VIP"});
            this.cbCustomerType.Location = new System.Drawing.Point(140, 450);
            this.cbCustomerType.Name = "cbCustomerType";
            this.cbCustomerType.Size = new System.Drawing.Size(200, 24);
            this.cbCustomerType.TabIndex = 2;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(15, 490);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(137, 23);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "Khuyến mãi (đ):";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(160, 490);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 22);
            this.txtDiscount.TabIndex = 4;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtKhuyenMai_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(15, 530);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(145, 28);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Tổng tiền: 0 đ";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.IndianRed;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(15, 630);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "🗑 Xóa món";
            this.btnCancel.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.BorderRadius = 10;
            this.btnSaveOrder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnSaveOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveOrder.ForeColor = System.Drawing.Color.Black;
            this.btnSaveOrder.Location = new System.Drawing.Point(130, 580);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(150, 40);
            this.btnSaveOrder.TabIndex = 7;
            this.btnSaveOrder.Text = "💾 Lưu Order";
            this.btnSaveOrder.Click += new System.EventHandler(this.btnLuuOrder_Click);
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 10;
            this.btnPay.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(130, 630);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(150, 40);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = "💰 Thanh toán";
            this.btnPay.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 10;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(103)))), ((int)(((byte)(84)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(15, 580);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 40);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "⬅ Trở lại";
            this.btnBack.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FrmMenu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
