using QuanLyCF.BUS;
using QuanLyCF.DAL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyCF.GUI
{
    public partial class FrmUser : Form
    {
        public static readonly string UserFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\User\"));
        private Form previousForm;
        private byte[] currentAvatar = null;

        public FrmUser(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
            this.FormClosed += FrmUser_FormClosed;
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            DataRow userData = StaffBUS.GetStaffByUserId(CurrentUser.UserID);

            if (userData != null)
            {
                txtFullName.Text = userData["FullName"].ToString();
                cboGender.SelectedItem = userData["Gender"].ToString();
                dtpBirth.Value = Convert.ToDateTime(userData["BirthDate"]);
                txtEmail.Text = userData["Email"].ToString();
                txtPhone.Text = userData["Phone"].ToString();
                txtAddress.Text = userData["Address"].ToString();

                if (userData["Avatar"] != DBNull.Value)
                {
                    string avatarPath = userData["Avatar"].ToString();
                    string fullPath = Path.Combine(UserFolder, avatarPath);
                    if (File.Exists(fullPath))
                    {
                        picAvatar.Image = Image.FromFile(fullPath);
                    }
                }
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow currentUserData = StaffBUS.GetStaffByUserId(CurrentUser.UserID);
            if (currentUserData == null)
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng hiện tại!");
                return;
            }

            string name = txtFullName.Text.Trim();
            string gender = cboGender.SelectedItem?.ToString() ?? "";
            DateTime birth = dtpBirth.Value;
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            string idCard = currentUserData["IdCard"].ToString();
            decimal salary = Convert.ToDecimal(currentUserData["Salary"]);
            bool working = Convert.ToBoolean(currentUserData["Working"]);

            bool ok = StaffBUS.UpdateStaff(CurrentUser.UserID, name, gender, birth, idCard, email, phone, address, CurrentUser.Role, salary, working, currentAvatar);

            if (ok)
            {
                MessageBox.Show("Lưu thành công!");
            }
            else
                MessageBox.Show("Không thể lưu dữ liệu!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm?.Show();
        }
    }
}