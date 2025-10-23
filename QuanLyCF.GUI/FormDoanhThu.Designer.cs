namespace QuanLyCF.GUI
{
    partial class FormDoanhThu
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.flowLayoutPanelRightIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonInvoiceList = new System.Windows.Forms.Button();
            this.labelHomeIcon = new System.Windows.Forms.Label();
            this.panelFilterBar = new System.Windows.Forms.Panel();
            this.flowLayoutPanelFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFrom = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.comboBoxFilter1 = new System.Windows.Forms.ComboBox();
            this.comboBoxFilter2 = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearchIcon = new System.Windows.Forms.Label();
            this.labelSearchOnline = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.panelTotals = new System.Windows.Forms.Panel();
            this.labelTotalText = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.panelTitleBar.SuspendLayout();
            this.flowLayoutPanelRightIcons.SuspendLayout();
            this.panelFilterBar.SuspendLayout();
            this.flowLayoutPanelFilter.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.panelTotals.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.panelTitleBar.Controls.Add(this.flowLayoutPanelRightIcons);
            this.panelTitleBar.Controls.Add(this.buttonInvoiceList);
            this.panelTitleBar.Controls.Add(this.labelHomeIcon);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(6);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1735, 96);
            this.panelTitleBar.TabIndex = 0;
            // 
            // flowLayoutPanelRightIcons
            // 
            this.flowLayoutPanelRightIcons.Controls.Add(this.label1);
            this.flowLayoutPanelRightIcons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelRightIcons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelRightIcons.Location = new System.Drawing.Point(835, 0);
            this.flowLayoutPanelRightIcons.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanelRightIcons.Name = "flowLayoutPanelRightIcons";
            this.flowLayoutPanelRightIcons.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.flowLayoutPanelRightIcons.Size = new System.Drawing.Size(900, 96);
            this.flowLayoutPanelRightIcons.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(-303, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(1180, 0);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh sách hóa đơn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonInvoiceList
            // 
            this.buttonInvoiceList.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonInvoiceList.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonInvoiceList.FlatAppearance.BorderSize = 0;
            this.buttonInvoiceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInvoiceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.buttonInvoiceList.ForeColor = System.Drawing.Color.White;
            this.buttonInvoiceList.Location = new System.Drawing.Point(100, 0);
            this.buttonInvoiceList.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInvoiceList.Name = "buttonInvoiceList";
            this.buttonInvoiceList.Size = new System.Drawing.Size(300, 96);
            this.buttonInvoiceList.TabIndex = 2;
            this.buttonInvoiceList.Text = "Danh sách hóa đơn";
            this.buttonInvoiceList.UseVisualStyleBackColor = false;
            // 
            // labelHomeIcon
            // 
            this.labelHomeIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelHomeIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 14F, System.Drawing.FontStyle.Bold);
            this.labelHomeIcon.ForeColor = System.Drawing.Color.White;
            this.labelHomeIcon.Location = new System.Drawing.Point(0, 0);
            this.labelHomeIcon.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelHomeIcon.Name = "labelHomeIcon";
            this.labelHomeIcon.Size = new System.Drawing.Size(100, 96);
            this.labelHomeIcon.TabIndex = 1;
            this.labelHomeIcon.Text = "🏠";
            this.labelHomeIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelHomeIcon.Click += new System.EventHandler(this.labelHomeIcon_Click);
            // 
            // panelFilterBar
            // 
            this.panelFilterBar.BackColor = System.Drawing.Color.White;
            this.panelFilterBar.Controls.Add(this.flowLayoutPanelFilter);
            this.panelFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterBar.Location = new System.Drawing.Point(0, 96);
            this.panelFilterBar.Margin = new System.Windows.Forms.Padding(6);
            this.panelFilterBar.Name = "panelFilterBar";
            this.panelFilterBar.Padding = new System.Windows.Forms.Padding(10);
            this.panelFilterBar.Size = new System.Drawing.Size(1735, 135);
            this.panelFilterBar.TabIndex = 1;
            // 
            // flowLayoutPanelFilter
            // 
            this.flowLayoutPanelFilter.Controls.Add(this.labelFrom);
            this.flowLayoutPanelFilter.Controls.Add(this.dateTimePickerFrom);
            this.flowLayoutPanelFilter.Controls.Add(this.labelTo);
            this.flowLayoutPanelFilter.Controls.Add(this.dateTimePickerTo);
            this.flowLayoutPanelFilter.Controls.Add(this.comboBoxFilter1);
            this.flowLayoutPanelFilter.Controls.Add(this.comboBoxFilter2);
            this.flowLayoutPanelFilter.Controls.Add(this.textBoxSearch);
            this.flowLayoutPanelFilter.Controls.Add(this.labelSearchIcon);
            this.flowLayoutPanelFilter.Controls.Add(this.labelSearchOnline);
            this.flowLayoutPanelFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFilter.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanelFilter.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanelFilter.Name = "flowLayoutPanelFilter";
            this.flowLayoutPanelFilter.Size = new System.Drawing.Size(1715, 115);
            this.flowLayoutPanelFilter.TabIndex = 0;
            // 
            // labelFrom
            // 
            this.labelFrom.Location = new System.Drawing.Point(6, 0);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(60, 50);
            this.labelFrom.TabIndex = 0;
            this.labelFrom.Text = "Từ:";
            this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(78, 6);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(196, 31);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // labelTo
            // 
            this.labelTo.Location = new System.Drawing.Point(286, 0);
            this.labelTo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(70, 50);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "Đến:";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(368, 6);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(196, 31);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // comboBoxFilter1
            // 
            this.comboBoxFilter1.FormattingEnabled = true;
            this.comboBoxFilter1.Items.AddRange(new object[] {
            "Tất cả"});
            this.comboBoxFilter1.Location = new System.Drawing.Point(576, 6);
            this.comboBoxFilter1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxFilter1.Name = "comboBoxFilter1";
            this.comboBoxFilter1.Size = new System.Drawing.Size(236, 33);
            this.comboBoxFilter1.TabIndex = 4;
            this.comboBoxFilter1.Text = "Tất cả";
            // 
            // comboBoxFilter2
            // 
            this.comboBoxFilter2.FormattingEnabled = true;
            this.comboBoxFilter2.Items.AddRange(new object[] {
            "Tất cả"});
            this.comboBoxFilter2.Location = new System.Drawing.Point(824, 6);
            this.comboBoxFilter2.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxFilter2.Name = "comboBoxFilter2";
            this.comboBoxFilter2.Size = new System.Drawing.Size(236, 33);
            this.comboBoxFilter2.TabIndex = 5;
            this.comboBoxFilter2.Text = "Tất cả";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(1072, 6);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(356, 31);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.Text = "Tìm kiếm";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // labelSearchIcon
            // 
            this.labelSearchIcon.Font = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.labelSearchIcon.Location = new System.Drawing.Point(1440, 0);
            this.labelSearchIcon.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSearchIcon.Name = "labelSearchIcon";
            this.labelSearchIcon.Size = new System.Drawing.Size(46, 50);
            this.labelSearchIcon.TabIndex = 7;
            this.labelSearchIcon.Text = "🔍";
            this.labelSearchIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSearchOnline
            // 
            this.labelSearchOnline.Location = new System.Drawing.Point(1498, 0);
            this.labelSearchOnline.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSearchOnline.Name = "labelSearchOnline";
            this.labelSearchOnline.Size = new System.Drawing.Size(200, 44);
            this.labelSearchOnline.TabIndex = 8;
            this.labelSearchOnline.Text = "Tìm trực tuyến";
            this.labelSearchOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMainContent
            // 
            this.panelMainContent.Controls.Add(this.dataGridViewInvoices);
            this.panelMainContent.Controls.Add(this.panelTotals);
            this.panelMainContent.Controls.Add(this.panelNavigation);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 231);
            this.panelMainContent.Margin = new System.Windows.Forms.Padding(6);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1735, 634);
            this.panelMainContent.TabIndex = 2;
            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.AllowUserToAddRows = false;
            this.dataGridViewInvoices.AllowUserToDeleteRows = false;
            this.dataGridViewInvoices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInvoices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInvoices.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewInvoices.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.ReadOnly = true;
            this.dataGridViewInvoices.RowHeadersVisible = false;
            this.dataGridViewInvoices.RowHeadersWidth = 82;
            this.dataGridViewInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInvoices.Size = new System.Drawing.Size(1735, 499);
            this.dataGridViewInvoices.TabIndex = 0;
            this.dataGridViewInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInvoices_CellContentClick_1);
            // 
            // panelTotals
            // 
            this.panelTotals.BackColor = System.Drawing.Color.White;
            this.panelTotals.Controls.Add(this.labelTotalText);
            this.panelTotals.Controls.Add(this.labelTotalAmount);
            this.panelTotals.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotals.Location = new System.Drawing.Point(0, 499);
            this.panelTotals.Margin = new System.Windows.Forms.Padding(6);
            this.panelTotals.Name = "panelTotals";
            this.panelTotals.Size = new System.Drawing.Size(1735, 58);
            this.panelTotals.TabIndex = 1;
            // 
            // labelTotalText
            // 
            this.labelTotalText.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.labelTotalText.Location = new System.Drawing.Point(1215, 0);
            this.labelTotalText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalText.Name = "labelTotalText";
            this.labelTotalText.Size = new System.Drawing.Size(200, 58);
            this.labelTotalText.TabIndex = 0;
            this.labelTotalText.Text = "Tổng tiền:";
            this.labelTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.labelTotalAmount.Location = new System.Drawing.Point(1415, 0);
            this.labelTotalAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.labelTotalAmount.Size = new System.Drawing.Size(320, 58);
            this.labelTotalAmount.TabIndex = 1;
            this.labelTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelNavigation.Controls.Add(this.buttonDown);
            this.panelNavigation.Controls.Add(this.buttonUp);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavigation.Location = new System.Drawing.Point(0, 557);
            this.panelNavigation.Margin = new System.Windows.Forms.Padding(6);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(1735, 77);
            this.panelNavigation.TabIndex = 2;
            // 
            // buttonDown
            // 
            this.buttonDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDown.FlatAppearance.BorderSize = 0;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.Font = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.buttonDown.Location = new System.Drawing.Point(1595, 0);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(70, 77);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.Text = "▼";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonUp.FlatAppearance.BorderSize = 0;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Font = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.buttonUp.Location = new System.Drawing.Point(1665, 0);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(6);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(70, 77);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.Text = "▲";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // FormDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 865);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelFilterBar);
            this.Controls.Add(this.panelTitleBar);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormDoanhThu";
            this.Text = "FormDoanhThu";
            this.Load += new System.EventHandler(this.FormDoanhThu_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.flowLayoutPanelRightIcons.ResumeLayout(false);
            this.panelFilterBar.ResumeLayout(false);
            this.flowLayoutPanelFilter.ResumeLayout(false);
            this.flowLayoutPanelFilter.PerformLayout();
            this.panelMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.panelTotals.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelFilterBar;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.Panel panelTotals;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Label labelHomeIcon;
        private System.Windows.Forms.Button buttonInvoiceList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRightIcons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFilter;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.ComboBox comboBoxFilter1;
        private System.Windows.Forms.ComboBox comboBoxFilter2;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearchIcon;
        private System.Windows.Forms.Label labelSearchOnline;
        private System.Windows.Forms.Label labelTotalText;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Label label1;
    }
}
