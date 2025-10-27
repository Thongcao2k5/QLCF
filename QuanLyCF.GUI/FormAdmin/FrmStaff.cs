using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyCF.BUS;

namespace QuanLyCF.GUI
{
    public partial class FrmStaff : Form
    {
        private int selectedStaffId = -1;
        private byte[] currentAvatar = null;
        private FormDangNhap _loginForm;

        public FrmStaff()
        {
            InitializeComponent();
        }

        public FrmStaff(FormDangNhap loginForm) : this()
        {
            _loginForm = loginForm;
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            LoadStaffList();
            ClearForm();
        }

        private void LoadStaffList()
        {
            dgvStaff.DataSource = StaffBUS.GetAllStaff();
            if (dgvStaff.Columns["Avatar"] != null)
                dgvStaff.Columns["Avatar"].Visible = false;
        }

        private void ClearForm()
        {
            selectedStaffId = -1;
            txtFullName.Text = "";
            cboGender.SelectedIndex = -1;
            dtpBirth.Value = DateTime.Today;
            txtIdCard.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            cboRole.SelectedIndex = -1;
            txtSalary.Text = "";
            chkWorking.Checked = true;
            picAvatar.Image = null;
            currentAvatar = null;
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png;*.jpeg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(dlg.FileName);
                currentAvatar = File.ReadAllBytes(dlg.FileName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e) => ClearForm();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }

            string name = txtFullName.Text.Trim();
            string gender = cboGender.SelectedItem?.ToString() ?? "";
            DateTime birth = dtpBirth.Value;
            string idCard = txtIdCard.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string role = cboRole.SelectedItem?.ToString() ?? "";
            decimal salary = 0;
            decimal.TryParse(txtSalary.Text.Trim(), out salary);
            bool working = chkWorking.Checked;
            byte[] avatar = currentAvatar;

            bool ok;
            if (selectedStaffId <= 0)
                ok = StaffBUS.AddStaff(name, gender, birth, idCard, email, phone, address, role, salary, working, avatar);
            else
                ok = StaffBUS.UpdateStaff(selectedStaffId, name, gender, birth, idCard, email, phone, address, role, salary, working, avatar);

            if (ok)
            {
                MessageBox.Show("Lưu thành công!");
                LoadStaffList();
                ClearForm();
            }
            else
                MessageBox.Show("Không thể lưu dữ liệu!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStaffId <= 0)
            {
                MessageBox.Show("Chọn nhân viên cần xóa!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (StaffBUS.DeleteStaff(selectedStaffId))
                {
                    MessageBox.Show("Đã xóa!");
                    LoadStaffList();
                    ClearForm();
                }
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvStaff.Rows[e.RowIndex];
            selectedStaffId = Convert.ToInt32(r.Cells["ID"].Value);
            txtFullName.Text = r.Cells["FullName"].Value?.ToString();
            cboGender.SelectedItem = r.Cells["Gender"].Value?.ToString();
            dtpBirth.Value = Convert.ToDateTime(r.Cells["BirthDate"].Value);
            txtIdCard.Text = r.Cells["IdCard"].Value?.ToString();
            txtEmail.Text = r.Cells["Email"].Value?.ToString();
            txtPhone.Text = r.Cells["Phone"].Value?.ToString();
            txtAddress.Text = r.Cells["Address"].Value?.ToString();
            cboRole.SelectedItem = r.Cells["Role"].Value?.ToString();
            txtSalary.Text = r.Cells["Salary"].Value?.ToString();
            chkWorking.Checked = Convert.ToBoolean(r.Cells["Working"].Value);

            if (r.Cells["Avatar"].Value != DBNull.Value)
            {
                byte[] img = (byte[])r.Cells["Avatar"].Value;
                using (MemoryStream ms = new MemoryStream(img))
                    picAvatar.Image = Image.FromStream(ms);
                currentAvatar = img;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearchName.Text.Trim();
            string role = cboSearchRole.SelectedItem?.ToString() ?? "";
            dgvStaff.DataSource = StaffBUS.SearchStaff(name, role);
        }
    }
}
