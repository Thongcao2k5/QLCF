using System.Windows.Forms;

namespace QuanLyCF.GUI
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTenQuan;
        private Label lblTimKiem;
        private TextBox txtSearch;
        private FlowLayoutPanel flowLayoutPanelMenu;
        private Panel pnlBill;
        private ComboBox cbKhachHang;
        private Label lblKhachHang;
        private Label lblKhuyenMai;
        private TextBox txtKhuyenMai;
        private Label lblTotal;
        private Button btnHuy;
        private Button btnLuuOrder;
        private Button btnTinhTien;
        private Button btnXoaMon;
        private DataGridView dgvOrder;
        private DataGridViewTextBoxColumn colMenuItemID;
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTenQuan = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.colMenuItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cbKhachHang = new System.Windows.Forms.ComboBox();
            this.lblKhuyenMai = new System.Windows.Forms.Label();
            this.txtKhuyenMai = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnLuuOrder = new System.Windows.Forms.Button();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.MistyRose;
            this.pnlTop.Controls.Add(this.lblTenQuan);
            this.pnlTop.Controls.Add(this.lblTimKiem);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1485, 100);
            this.pnlTop.TabIndex = 2;
            // 
            // lblTenQuan
            // 
            this.lblTenQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenQuan.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTenQuan.ForeColor = System.Drawing.Color.Maroon;
            this.lblTenQuan.Location = new System.Drawing.Point(0, 0);
            this.lblTenQuan.Name = "lblTenQuan";
            this.lblTenQuan.Size = new System.Drawing.Size(1485, 50);
            this.lblTenQuan.TabIndex = 0;
            this.lblTenQuan.Text = "☕ CAFE THƯ GIÃN";
            this.lblTenQuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.Location = new System.Drawing.Point(20, 65);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(143, 37);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(110, 63);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 31);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // flowLayoutPanelMenu
            // 
            this.flowLayoutPanelMenu.AutoScroll = true;
            this.flowLayoutPanelMenu.BackColor = System.Drawing.Color.LavenderBlush;
            this.flowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(1105, 760);
            this.flowLayoutPanelMenu.TabIndex = 0;
            // 
            // pnlBill
            // 
            this.pnlBill.BackColor = System.Drawing.Color.LavenderBlush;
            this.pnlBill.Controls.Add(this.dgvOrder);
            this.pnlBill.Controls.Add(this.lblKhachHang);
            this.pnlBill.Controls.Add(this.cbKhachHang);
            this.pnlBill.Controls.Add(this.lblKhuyenMai);
            this.pnlBill.Controls.Add(this.txtKhuyenMai);
            this.pnlBill.Controls.Add(this.lblTotal);
            this.pnlBill.Controls.Add(this.btnHuy);
            this.pnlBill.Controls.Add(this.btnXoaMon);
            this.pnlBill.Controls.Add(this.btnLuuOrder);
            this.pnlBill.Controls.Add(this.btnTinhTien);
            this.pnlBill.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBill.Location = new System.Drawing.Point(1105, 100);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBill.Size = new System.Drawing.Size(380, 760);
            this.pnlBill.TabIndex = 1;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMenuItemID,
            this.colName,
            this.colQty,
            this.colPrice});
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrder.Location = new System.Drawing.Point(10, 10);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 82;
            this.dgvOrder.Size = new System.Drawing.Size(360, 430);
            this.dgvOrder.TabIndex = 0;
            // 
            // colMenuItemID
            // 
            this.colMenuItemID.HeaderText = "MenuItemID";
            this.colMenuItemID.MinimumWidth = 10;
            this.colMenuItemID.Name = "colMenuItemID";
            this.colMenuItemID.Visible = false;
            this.colMenuItemID.Width = 200;
            // 
            // colName
            // 
            this.colName.HeaderText = "Tên món";
            this.colName.MinimumWidth = 10;
            this.colName.Name = "colName";
            this.colName.Width = 180;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "SL";
            this.colQty.MinimumWidth = 10;
            this.colQty.Name = "colQty";
            this.colQty.Width = 50;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Thành tiền";
            this.colPrice.MinimumWidth = 10;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 110;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.Location = new System.Drawing.Point(20, 460);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(173, 37);
            this.lblKhachHang.TabIndex = 1;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cbKhachHang
            // 
            this.cbKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhachHang.Items.AddRange(new object[] {
            "Khách lẻ",
            "Thành viên",
            "VIP"});
            this.cbKhachHang.Location = new System.Drawing.Point(130, 460);
            this.cbKhachHang.Name = "cbKhachHang";
            this.cbKhachHang.Size = new System.Drawing.Size(220, 33);
            this.cbKhachHang.TabIndex = 2;
            // 
            // lblKhuyenMai
            // 
            this.lblKhuyenMai.AutoSize = true;
            this.lblKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhuyenMai.Location = new System.Drawing.Point(20, 500);
            this.lblKhuyenMai.Name = "lblKhuyenMai";
            this.lblKhuyenMai.Size = new System.Drawing.Size(219, 37);
            this.lblKhuyenMai.TabIndex = 3;
            this.lblKhuyenMai.Text = "Khuyến mãi (đ):";
            // 
            // txtKhuyenMai
            // 
            this.txtKhuyenMai.Location = new System.Drawing.Point(160, 500);
            this.txtKhuyenMai.Name = "txtKhuyenMai";
            this.txtKhuyenMai.Size = new System.Drawing.Size(120, 31);
            this.txtKhuyenMai.TabIndex = 4;
            this.txtKhuyenMai.Text = "0";
            this.txtKhuyenMai.TextChanged += new System.EventHandler(this.txtKhuyenMai_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.Location = new System.Drawing.Point(20, 540);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(350, 40);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Tổng tiền: 0 đ";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightCoral;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Location = new System.Drawing.Point(10, 600);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.BackColor = System.Drawing.Color.Tomato;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoaMon.Location = new System.Drawing.Point(100, 600);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(80, 40);
            this.btnXoaMon.TabIndex = 7;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnLuuOrder
            // 
            this.btnLuuOrder.BackColor = System.Drawing.Color.Khaki;
            this.btnLuuOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuOrder.Location = new System.Drawing.Point(190, 600);
            this.btnLuuOrder.Name = "btnLuuOrder";
            this.btnLuuOrder.Size = new System.Drawing.Size(80, 40);
            this.btnLuuOrder.TabIndex = 8;
            this.btnLuuOrder.Text = "Lưu Order";
            this.btnLuuOrder.UseVisualStyleBackColor = false;
            this.btnLuuOrder.Click += new System.EventHandler(this.btnLuuOrder_Click);
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.BackColor = System.Drawing.Color.LightGreen;
            this.btnTinhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTinhTien.Location = new System.Drawing.Point(280, 600);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(80, 40);
            this.btnTinhTien.TabIndex = 9;
            this.btnTinhTien.Text = "Tính Tiền";
            this.btnTinhTien.UseVisualStyleBackColor = false;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // FrmMenu
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1485, 860);
            this.Controls.Add(this.flowLayoutPanelMenu);
            this.Controls.Add(this.pnlBill);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmMenu";
            this.Text = "Order Cafe - FormMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBill.ResumeLayout(false);
            this.pnlBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
