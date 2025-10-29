namespace QuanLyCF.GUI.FormAdmin
{
    partial class FrmDrinkCategory
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvCategories = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilterId = new System.Windows.Forms.Label();
            this.txtFilterId = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.txtFilterName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.pnlFilters);
            this.guna2Panel1.Controls.Add(this.dgvCategories);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.btnExit);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1260, 750);
            this.guna2Panel1.TabIndex = 0;
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(12, 142);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Size = new System.Drawing.Size(1236, 596);
            this.dgvCategories.TabIndex = 27;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1236, 60);
            this.guna2Panel2.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1236, 60);
            this.label1.TabIndex = 11;
            this.label1.Text = "Quản Lý Loại Đồ Uống";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 20;
            this.btnAdd.FillColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(12, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 42);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 20;
            this.btnExit.FillColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(1092, 95);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(146, 42);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.lblFilterId);
            this.pnlFilters.Controls.Add(this.txtFilterId);
            this.pnlFilters.Controls.Add(this.lblFilterName);
            this.pnlFilters.Controls.Add(this.txtFilterName);
            this.pnlFilters.Location = new System.Drawing.Point(12, 142);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1236, 45);
            this.pnlFilters.TabIndex = 28;
            // 
            // lblFilterId
            // 
            this.lblFilterId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFilterId.ForeColor = System.Drawing.Color.White;
            this.lblFilterId.Location = new System.Drawing.Point(3, 0);
            this.lblFilterId.Name = "lblFilterId";
            this.lblFilterId.Size = new System.Drawing.Size(100, 35);
            this.lblFilterId.TabIndex = 0;
            this.lblFilterId.Text = "Lọc theo ID:";
            this.lblFilterId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilterId
            // 
            this.txtFilterId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterId.DefaultText = "";
            this.txtFilterId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilterId.Location = new System.Drawing.Point(109, 3);
            this.txtFilterId.Name = "txtFilterId";
            this.txtFilterId.Size = new System.Drawing.Size(200, 30);
            this.txtFilterId.TabIndex = 1;
            this.txtFilterId.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilterName
            // 
            this.lblFilterName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFilterName.ForeColor = System.Drawing.Color.White;
            this.lblFilterName.Location = new System.Drawing.Point(315, 0);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(120, 35);
            this.lblFilterName.TabIndex = 2;
            this.lblFilterName.Text = "Lọc theo Tên:";
            this.lblFilterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilterName
            // 
            this.txtFilterName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterName.DefaultText = "";
            this.txtFilterName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilterName.Location = new System.Drawing.Point(441, 3);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(300, 30);
            this.txtFilterName.TabIndex = 3;
            this.txtFilterName.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // dgvCategories
            // 
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(12, 193);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Size = new System.Drawing.Size(1236, 545);
            this.dgvCategories.TabIndex = 27;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);
            // 
            // FrmDrinkCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDrinkCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drink Category";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCategories;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.FlowLayoutPanel pnlFilters;
        private System.Windows.Forms.Label lblFilterId;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterId;
        private System.Windows.Forms.Label lblFilterName;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterName;
    }
}