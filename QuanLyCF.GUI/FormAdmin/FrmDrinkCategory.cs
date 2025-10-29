using QuanLyCF.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmDrinkCategory : Form
    {
        private Form previousForm;
        private DataTable allCategoriesTable;

        public FrmDrinkCategory(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;

            this.Load += FrmDrinkCategory_Load;
            this.FormClosed += FrmDrinkCategory_FormClosed;
        }

        private void FrmDrinkCategory_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            StyleDataGridView();
            LoadCategories();
        }

        private void SetupDataGridView()
        {
            dgvCategories.Columns.Clear();
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.ReadOnly = true;

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Loại",
                DataPropertyName = "CategoryID",
                Name = "colID",
                Width = 120
            });

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Loại",
                DataPropertyName = "CategoryName",
                Name = "colName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Sửa",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Name = "colEdit",
                Width = 70,
                FlatStyle = FlatStyle.Flat
            });

            dgvCategories.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Name = "colDelete",
                Width = 70,
                FlatStyle = FlatStyle.Flat
            });
        }

        private void StyleDataGridView()
        {
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.BackgroundColor = AppSettings.BackgroundWhiteColor;
            dgvCategories.GridColor = Color.FromArgb(230, 220, 210);
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.RowTemplate.Height = 42;
            dgvCategories.ColumnHeadersHeight = 48;
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategories.RowHeadersVisible = false;

            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dgvCategories.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgvCategories.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCategories.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCategories.DefaultCellStyle.Padding = new Padding(10, 6, 10, 6);

            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = AppSettings.PrimaryColor;
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppSettings.PrimaryColor;

            dgvCategories.DefaultCellStyle.BackColor = Color.White;
            dgvCategories.DefaultCellStyle.ForeColor = Color.FromArgb(90, 60, 40);
            dgvCategories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 245, 240);
            dgvCategories.DefaultCellStyle.SelectionBackColor = AppSettings.LightBrownColor;
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.White;

            foreach (DataGridViewColumn col in dgvCategories.Columns)
            {
                if (col is DataGridViewButtonColumn btnCol)
                {
                    btnCol.FlatStyle = FlatStyle.Flat;
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = AppSettings.BeigeColor;
                    style.ForeColor = Color.White;
                    style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    style.SelectionBackColor = AppSettings.PrimaryColor;
                    style.SelectionForeColor = Color.White;
                    style.Padding = new Padding(5, 3, 5, 3);
                    btnCol.DefaultCellStyle = style;
                }
            }

            dgvCategories.RowPrePaint += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgvCategories.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(250, 245, 240);
                }
            };

            dgvCategories.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgvCategories.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(235, 225, 215);
            };

            dgvCategories.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgvCategories.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(250, 245, 240);
                }
            };
        }

        public void LoadCategories()
        {
            allCategoriesTable = DrinkCategoryBUS.GetAllCategories();
            DataView dv = new DataView(allCategoriesTable);
            dgvCategories.DataSource = dv;
            txtFilter_TextChanged(null, null); // Apply initial empty filter
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvCategories.DataSource as DataView;
            if (dv != null)
            {
                StringBuilder filter = new StringBuilder();

                string idFilter = txtFilterId.Text.Trim();
                string nameFilter = txtFilterName.Text.Trim();

                if (!string.IsNullOrEmpty(idFilter))
                {
                    filter.AppendFormat("CONVERT(CategoryID, 'System.String') LIKE '%{0}%'", idFilter);
                }

                if (!string.IsNullOrEmpty(nameFilter))
                {
                    if (filter.Length > 0) filter.Append(" AND ");
                    filter.AppendFormat("CategoryName LIKE '%{0}%'", nameFilter);
                }

                dv.RowFilter = filter.ToString();
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataView dv = dgvCategories.DataSource as DataView;
            if (dv == null) return;
            DataRowView rowView = dv[e.RowIndex];

            int categoryId = Convert.ToInt32(rowView["CategoryID"]);
            string categoryName = rowView["CategoryName"].ToString();
            string column = dgvCategories.Columns[e.ColumnIndex].Name;

            if (column == "colEdit")
            {
                FrmEditDrinkCategory frm = new FrmEditDrinkCategory(this, categoryId, categoryName);
                this.Hide();
                frm.Show();
            }
            else if (column == "colDelete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa loại này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (DrinkCategoryBUS.DeleteCategory(categoryId))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadCategories(); // Reload data from DB
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Vui lòng kiểm tra lại.");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEditDrinkCategory frm = new FrmEditDrinkCategory(this, null, null);
            this.Hide();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDrinkCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm?.Show();
        }
    }
}
