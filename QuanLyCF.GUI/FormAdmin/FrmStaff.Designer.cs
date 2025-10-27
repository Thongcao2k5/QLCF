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
        private Guna.UI2.WinForms.Guna2ComboBox cboGender;
        private System.Windows.Forms.DateTimePicker dtpBirth;
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
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new Guna.UI2.WinForms.Guna2Button();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
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
            this.txtSearchName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboSearchRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.dgvStaff = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.SuspendLayout();

            // panelMain
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FillColor = System.Drawing.Color.FromArgb(47, 34, 28);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);

            // panelLeft
            this.panelLeft.FillColor = System.Drawing.Color.FromArgb(117, 61, 38);
            this.panelLeft.BorderRadius = 14;
            this.panelLeft.Size = new System.Drawing.Size(440, 660);
            this.panelLeft.Location = new System.Drawing.Point(20, 20);
            this.panelLeft.Padding = new System.Windows.Forms.Padding(18);

            // picAvatar
            this.picAvatar.Size = new System.Drawing.Size(140, 140);
            this.picAvatar.Location = new System.Drawing.Point(24, 24);
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(234, 220, 202);

            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.Location = new System.Drawing.Point(24, 172);
            this.btnChooseImage.Size = new System.Drawing.Size(140, 40);
            this.btnChooseImage.BorderRadius = 10;
            this.btnChooseImage.FillColor = System.Drawing.Color.FromArgb(82, 50, 35);
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);

            this.txtFullName.PlaceholderText = "Họ và tên";
            this.txtFullName.Location = new System.Drawing.Point(180, 24);
            this.txtFullName.Size = new System.Drawing.Size(230, 36);
            this.cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            this.cboGender.Location = new System.Drawing.Point(180, 72);
            this.cboGender.Size = new System.Drawing.Size(110, 36);
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirth.Location = new System.Drawing.Point(300, 72);
            this.dtpBirth.Size = new System.Drawing.Size(110, 36);

            this.txtIdCard.PlaceholderText = "Số CCCD";
            this.txtIdCard.Location = new System.Drawing.Point(24, 230);
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Location = new System.Drawing.Point(24, 278);
            this.txtPhone.PlaceholderText = "Số điện thoại";
            this.txtPhone.Location = new System.Drawing.Point(24, 326);
            this.txtAddress.PlaceholderText = "Địa chỉ";
            this.txtAddress.Location = new System.Drawing.Point(24, 374);

            this.cboRole.Location = new System.Drawing.Point(24, 422);
            this.cboRole.Size = new System.Drawing.Size(386, 36);
            this.cboRole.Items.AddRange(new object[] { "Quản lý", "Nhân viên" });

            this.txtSalary.PlaceholderText = "Mức lương";
            this.txtSalary.Location = new System.Drawing.Point(24, 470);
            this.txtSalary.Size = new System.Drawing.Size(180, 36);
            this.chkWorking.Text = "Đang làm việc";
            this.chkWorking.Location = new System.Drawing.Point(220, 470);
            this.chkWorking.Checked = true;

            this.btnNew.Text = "Tạo mới";
            this.btnNew.Location = new System.Drawing.Point(24, 520);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(170, 520);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(316, 520);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.panelLeft.Controls.Add(this.picAvatar);
            this.panelLeft.Controls.Add(this.btnChooseImage);
            this.panelLeft.Controls.Add(this.txtFullName);
            this.panelLeft.Controls.Add(this.cboGender);
            this.panelLeft.Controls.Add(this.dtpBirth);
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

            // panelRight
            this.panelRight.FillColor = System.Drawing.Color.FromArgb(117, 61, 38);
            this.panelRight.BorderRadius = 14;
            this.panelRight.Size = new System.Drawing.Size(600, 660);
            this.panelRight.Location = new System.Drawing.Point(480, 20);

            this.txtSearchName.PlaceholderText = "Họ và tên...";
            this.txtSearchName.Location = new System.Drawing.Point(30, 24);
            this.cboSearchRole.Items.AddRange(new object[] { "", "Quản lý", "Nhân viên" });
            this.cboSearchRole.Location = new System.Drawing.Point(340, 24);
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Location = new System.Drawing.Point(520, 24);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            this.dgvStaff.Location = new System.Drawing.Point(30, 72);
            this.dgvStaff.Size = new System.Drawing.Size(540, 560);
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);

            this.panelRight.Controls.Add(this.txtSearchName);
            this.panelRight.Controls.Add(this.cboSearchRole);
            this.panelRight.Controls.Add(this.btnSearch);
            this.panelRight.Controls.Add(this.dgvStaff);

            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelMain);

            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.FrmStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
