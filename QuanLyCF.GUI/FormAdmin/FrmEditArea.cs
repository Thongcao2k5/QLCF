using QuanLyCF.BUS;
using System;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmEditArea : Form
    {
        private int? areaId; // null = thêm mới
        private FrmArea parentForm;

        public FrmEditArea(FrmArea parent, int? id = null)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.areaId = id;
            this.Load += FrmEditArea_Load;
            this.FormClosed += FrmEditArea_FormClosed;
        }

        private void FrmEditArea_Load(object sender, EventArgs e)
        {
            if (areaId.HasValue)
            {
                lblTitle.Text = "Chỉnh sửa khu vực";
                btnSave.Text = "Cập nhật";

                var area = AreaBUS.GetAreaById(areaId.Value);
                if (area != null)
                {
                    txtAreaID.Text = area.AreaID.ToString();
                    txtAreaID.ReadOnly = true;
                    txtAreaName.Text = area.AreaName;
                    txtDescription.Text = area.Description;
                }
            }
            else
            {
                txtAreaID.ReadOnly = true;
                lblTitle.Text = "Thêm khu vực mới";
                btnSave.Text = "Thêm mới";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtAreaName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (areaId.HasValue)
            {
                // Cập nhật
                bool ok = AreaBUS.UpdateArea(areaId.Value, name, desc);
                if (ok)
                    MessageBox.Show("Đã cập nhật khu vực thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lỗi khi cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Thêm mới
                bool ok = AreaBUS.AddArea(name, desc);
                if (ok)
                    MessageBox.Show("Đã thêm khu vực mới!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không thể thêm khu vực!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
            parentForm.ReloadAreaList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm?.Show();
        }
    }
}
