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
        private FrmOrder _loginForm;
        private Form previousForm;
        public FrmStaff(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;

            // Attach event handlers
            this.Load += FrmStaff_Load;
            this.FormClosed += FrmReport_FormClosed;
        }

        private decimal ParseCurrency(string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;
            var nfi = new System.Globalization.NumberFormatInfo
            {
                NumberGroupSeparator = ".",
                NumberDecimalSeparator = ","
            };
            decimal.TryParse(text.Replace(" đồng", ""), System.Globalization.NumberStyles.Any, nfi, out decimal result);
            return result;
        }

        private string FormatCurrency(decimal amount)
        {
            var nfi = new System.Globalization.NumberFormatInfo
            {
                NumberGroupSeparator = ".",
                NumberDecimalSeparator = ",",
                NumberDecimalDigits = 0
            };
            return amount.ToString("N", nfi) + " đồng";
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            LoadStaffList();
            ClearForm();

            // Automatically select the first staff member if available
            if (dgvStaff.Rows.Count > 0)
            {
                dgvStaff.Rows[0].Selected = true;
                dgvStaff_CellClick(dgvStaff, new DataGridViewCellEventArgs(0, 0));
            }
        }

        private void LoadStaffList()
        {
            DataTable staffData = StaffBUS.GetAllStaff();

            // Filter out the admin user (UserID = 0)
            DataView dv = new DataView(staffData);
            dv.RowFilter = "UserID <> 0";
            DataTable filteredStaffData = dv.ToTable();

            dgvStaff.AutoGenerateColumns = false; // Disable auto-generation to control columns manually
            dgvStaff.Columns.Clear(); // Clear existing columns

            // Add desired columns with Vietnamese headers
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "FullName", HeaderText = "Họ và tên" });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "BirthDate", HeaderText = "Ngày sinh" });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Email", HeaderText = "Email" });
            dgvStaff.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Phone", HeaderText = "Số điện thoại" });

            dgvStaff.DataSource = filteredStaffData;
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
            string role = "Nhân viên";
            decimal salary = ParseCurrency(txtSalary.Text);
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

            if (dgvStaff.Rows[e.RowIndex].DataBoundItem is DataRowView drv)
            {
                DataRow r = drv.Row;
                selectedStaffId = Convert.ToInt32(r["UserID"]);
                txtFullName.Text = r["FullName"]?.ToString();
                cboGender.SelectedItem = r["Gender"]?.ToString();
                dtpBirth.Value = Convert.ToDateTime(r["BirthDate"]);
                txtIdCard.Text = r["IdCard"]?.ToString();
                txtEmail.Text = r["Email"]?.ToString();
                txtPhone.Text = r["Phone"]?.ToString();
                txtAddress.Text = r["Address"]?.ToString();
                txtSalary.Text = FormatCurrency(Convert.ToDecimal(r["Salary"]));
                chkWorking.Checked = Convert.ToBoolean(r["Working"]);

                if (r["Avatar"] != DBNull.Value)
                {
                    byte[] img = (byte[])r["Avatar"];
                    using (MemoryStream ms = new MemoryStream(img))
                    {
                        picAvatar.Image = Image.FromStream(ms);
                    }
                    currentAvatar = img;
                }
                else
                {
                    picAvatar.Image = null;
                    currentAvatar = null;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearchName.Text.Trim();
            string role = "";

            DataTable searchResult = StaffBUS.SearchStaff(name, role);

            // Filter out the admin user (UserID = 0) from search results
            DataView dv = new DataView(searchResult);
            dv.RowFilter = "UserID <> 0";
            DataTable filteredSearchResult = dv.ToTable();

            dgvStaff.DataSource = filteredSearchResult;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm?.Show();
        }
    }
}
