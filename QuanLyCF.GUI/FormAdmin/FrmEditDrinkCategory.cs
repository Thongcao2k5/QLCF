using QuanLyCF.BUS;
using System;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmEditDrinkCategory : Form
    {
        private int? categoryId; // null = add new
        private FrmDrinkCategory parentForm;

        public FrmEditDrinkCategory(FrmDrinkCategory parent, int? id, string currentName)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.categoryId = id;

            this.Load += (s, e) => FrmEditDrinkCategory_Load(currentName);
            this.FormClosed += (s, e) => parentForm?.Show();
        }

        private void FrmEditDrinkCategory_Load(string currentName)
        {
            if (categoryId.HasValue)
            {
                lblTitle.Text = "Chỉnh Sửa Loại";
                btnSave.Text = "Cập Nhật";
                txtCategoryName.Text = currentName;
            }
            else
            {
                lblTitle.Text = "Thêm Loại Mới";
                btnSave.Text = "Thêm Mới";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success;
            if (categoryId.HasValue)
            {
                // Update
                success = DrinkCategoryBUS.UpdateCategory(categoryId.Value, name);
            }
            else
            {
                // Insert
                success = DrinkCategoryBUS.InsertCategory(name);
            }

            if (success)
            {
                MessageBox.Show(categoryId.HasValue ? "Cập nhật thành công!" : "Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parentForm.LoadCategories();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
