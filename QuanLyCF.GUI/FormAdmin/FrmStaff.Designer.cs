namespace QuanLyCF.GUI
{
    partial class FrmStaff
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel panelRight;
        private System.Windows.Forms.PictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChooseImage;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtIdCard;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2ComboBox cboRole;
        private Guna.UI2.WinForms.Guna2TextBox txtSalary;
        private Guna.UI2.WinForms.Guna2CheckBox chkWorking;
        private Guna.UI2.WinForms.Guna2Button btnNew;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchName;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearchRole;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.DataGridView dgvStaff;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new Guna.UI2.WinForms.Guna2Button();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtIdCard = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSalary = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkWorking = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnNew = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboSearchRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(34)))), ((int)(((byte)(28)))));
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1100, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(68)))), ((int)(((byte)(31)))));
            this.panelLeft.BorderRadius = 14;
            this.panelLeft.Controls.Add(this.dtpBirth);
            this.panelLeft.Controls.Add(this.picAvatar);
            this.panelLeft.Controls.Add(this.btnChooseImage);
            this.panelLeft.Controls.Add(this.txtFullName);
            this.panelLeft.Controls.Add(this.cboGender);
            this.panelLeft.Controls.Add(this.txtIdCard);
            this.panelLeft.Controls.Add(this.txtEmail);
            this.panelLeft.Controls.Add(this.txtPhone);
            this.panelLeft.Controls.Add(this.txtAddress);
            this.panelLeft.Controls.Add(this.cboRole);
            this.panelLeft.Controls.Add(this.txtSalary);
            this.panelLeft.Controls.Add(this.chkWorking);
            this.panelLeft.Controls.Add(this.btnNew);
            this.panelLeft.Controls.Add(this.btnDelete);
            this.panelLeft.Controls.Add(this.btnSave);
            this.panelLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(61)))), ((int)(((byte)(38)))));
            this.panelLeft.Location = new System.Drawing.Point(20, 20);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(18);
            this.panelLeft.Size = new System.Drawing.Size(440, 660);
            this.panelLeft.TabIndex = 1;
            // 
            // dtpBirth
            // 
            this.dtpBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(68)))), ((int)(((byte)(31)))));
            this.dtpBirth.BorderRadius = 16;
            this.dtpBirth.Checked = true;
            this.dtpBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpBirth.Location = new System.Drawing.Point(180, 72);
            this.dtpBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(230, 36);
            this.dtpBirth.TabIndex = 15;
            this.dtpBirth.Value = new System.DateTime(2025, 10, 28, 10, 45, 48, 518);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(220)))), ((int)(((byte)(202)))));
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(24, 24);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(140, 140);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BorderRadius = 16;
            this.btnChooseImage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(50)))), ((int)(((byte)(35)))));
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(24, 172);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(140, 40);
            this.btnChooseImage.TabIndex = 1;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(68)))), ((int)(((byte)(31)))));
            this.txtFullName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(68)))), ((int)(((byte)(31)))));
            this.txtFullName.BorderRadius = 16;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.Location = new System.Drawing.Point(180, 24);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "Họ và tên";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(230, 36);
            this.txtFullName.TabIndex = 2;
            // 
            // cboGender
            // 
            this.cboGender.BackColor = System.Drawing.Color.Transparent;
            this.cboGender.BorderRadius = 16;
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FocusedColor = System.Drawing.Color.Empty;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGender.ItemHeight = 30;
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGender.Location = new System.Drawing.Point(300, 128);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(110, 36);
            this.cboGender.TabIndex = 3;
            // 
            // txtIdCard
            // 
            this.txtIdCard.BorderRadius = 20;
            this.txtIdCard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdCard.DefaultText = "";
            this.txtIdCard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdCard.Location = new System.Drawing.Point(24, 222);
            this.txtIdCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.PlaceholderText = "Số CCCD";
            this.txtIdCard.SelectedText = "";
            this.txtIdCard.Size = new System.Drawing.Size(386, 48);
            this.txtIdCard.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 20;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(24, 278);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(386, 48);
            this.txtEmail.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 20;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(24, 334);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Số điện thoại";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(386, 48);
            this.txtPhone.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 20;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(24, 390);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "Địa chỉ";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(386, 48);
            this.txtAddress.TabIndex = 8;
            // 
            // cboRole
            // 
            this.cboRole.BackColor = System.Drawing.Color.Transparent;
            this.cboRole.BorderRadius = 16;
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FocusedColor = System.Drawing.Color.Empty;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboRole.ItemHeight = 30;
            this.cboRole.Items.AddRange(new object[] {
            "Quản lý",
            "Nhân viên"});
            this.cboRole.Location = new System.Drawing.Point(24, 445);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(386, 36);
            this.cboRole.TabIndex = 9;
            // 
            // txtSalary
            // 
            this.txtSalary.BorderRadius = 16;
            this.txtSalary.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSalary.DefaultText = "";
            this.txtSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSalary.Location = new System.Drawing.Point(24, 493);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.PlaceholderText = "Mức lương";
            this.txtSalary.SelectedText = "";
            this.txtSalary.Size = new System.Drawing.Size(180, 36);
            this.txtSalary.TabIndex = 10;
            // 
            // chkWorking
            // 
            this.chkWorking.BackColor = System.Drawing.Color.Transparent;
            this.chkWorking.Checked = true;
            this.chkWorking.CheckedState.BorderRadius = 0;
            this.chkWorking.CheckedState.BorderThickness = 0;
            this.chkWorking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWorking.ForeColor = System.Drawing.Color.White;
            this.chkWorking.Location = new System.Drawing.Point(267, 493);
            this.chkWorking.Name = "chkWorking";
            this.chkWorking.Size = new System.Drawing.Size(143, 36);
            this.chkWorking.TabIndex = 11;
            this.chkWorking.Text = "Đang làm việc";
            this.chkWorking.UncheckedState.BorderRadius = 0;
            this.chkWorking.UncheckedState.BorderThickness = 0;
            this.chkWorking.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            this.btnNew.BorderRadius = 20;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(21, 551);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(122, 45);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "Tạo mới";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 20;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(149, 551);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 45);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 20;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(280, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 45);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(68)))), ((int)(((byte)(31)))));
            this.panelRight.BorderRadius = 14;
            this.panelRight.Controls.Add(this.txtSearchName);
            this.panelRight.Controls.Add(this.cboSearchRole);
            this.panelRight.Controls.Add(this.btnSearch);
            this.panelRight.Controls.Add(this.dgvStaff);
            this.panelRight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(61)))), ((int)(((byte)(38)))));
            this.panelRight.Location = new System.Drawing.Point(480, 20);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(597, 660);
            this.panelRight.TabIndex = 0;
            // 
            // txtSearchName
            // 
            this.txtSearchName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(68)))), ((int)(((byte)(31)))));
            this.txtSearchName.BorderRadius = 20;
            this.txtSearchName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchName.DefaultText = "";
            this.txtSearchName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchName.Location = new System.Drawing.Point(30, 17);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.PlaceholderText = "Họ và tên...";
            this.txtSearchName.SelectedText = "";
            this.txtSearchName.Size = new System.Drawing.Size(229, 36);
            this.txtSearchName.TabIndex = 0;
            // 
            // cboSearchRole
            // 
            this.cboSearchRole.BackColor = System.Drawing.Color.Transparent;
            this.cboSearchRole.BorderRadius = 16;
            this.cboSearchRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearchRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchRole.FocusedColor = System.Drawing.Color.Empty;
            this.cboSearchRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSearchRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSearchRole.ItemHeight = 30;
            this.cboSearchRole.Items.AddRange(new object[] {
            "",
            "Quản lý",
            "Nhân viên"});
            this.cboSearchRole.Location = new System.Drawing.Point(282, 17);
            this.cboSearchRole.Name = "cboSearchRole";
            this.cboSearchRole.Size = new System.Drawing.Size(140, 36);
            this.cboSearchRole.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(451, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 36);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvStaff
            // 
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.ColumnHeadersHeight = 29;
            this.dgvStaff.Location = new System.Drawing.Point(30, 72);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowHeadersWidth = 51;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(540, 560);
            this.dgvStaff.TabIndex = 3;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // FrmStaff
            // 
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.FrmStaff_Load);
            this.panelMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBirth;
        private Guna.UI2.WinForms.Guna2ComboBox cboGender;
    }
}
