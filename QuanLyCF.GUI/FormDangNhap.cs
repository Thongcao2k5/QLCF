using QuanLyCF.BUS;
using QuanLyCF.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCF.GUI
{
    public partial class FormDangNhap : Form
    {
        // Constants for placeholder text
        private const string StoreNamePlaceholder = "Nhập tên cửa hàng";
        private const string UsernamePlaceholder = "Tên đăng nhập";
        private const string PasswordPlaceholder = "Mật khẩu";


        public FormDangNhap()
        {
            InitializeComponent();
            buttonThuNgan.Click += new EventHandler(buttonThuNgan_Click);
            this.AcceptButton = buttonThuNgan;
        }



        private void buttonThuNgan_Click(object sender, EventArgs e)

        {

            string username = textBoxUsername.Text;

            string password = textBoxPassword.Text;



            // Hardcoded login for development/testing

            if (username == "Taitruong" && password == "123")

            {

                // Create a mock DataRow for the hardcoded user

                DataTable dt = new DataTable();

                dt.Columns.Add("UserID", typeof(int));

                dt.Columns.Add("Username", typeof(string));

                dt.Columns.Add("DisplayName", typeof(string));

                dt.Columns.Add("Role", typeof(string));

                dt.Rows.Add(-1, "Taitruong", "Taitruong Test", "1");

                CurrentUser.SetUser(dt.Rows[0]);



                FrmOrder frmOrder = new FrmOrder(this);

                frmOrder.Show();

                this.Hide();

                return; // Exit after successful hardcoded login

            }



            // Database login

            DataRow userData = UserBUS.VerifyLogin(username, password);

            if (userData != null)

            {

                CurrentUser.SetUser(userData);

                FrmOrder frmOrder = new FrmOrder(this);

                frmOrder.Show();

                this.Hide();

            }

            else

            {

                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");

            }

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // Set initial placeholder state for all textboxes
            //textBoxStoreName_Leave(textBoxStoreName, EventArgs.Empty);
            //textBoxUsername_Leave(textBoxUsername, EventArgs.Empty);
            //textBoxPassword_Leave(textBoxPassword, EventArgs.Empty);

            // Ensure upload button is behind the image

            buttonUploadImage.SendToBack();

        }

        private void buttonUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxIllustration.Image = new Bitmap(openFileDialog.FileName);
                    buttonUploadImage.Visible = false; // Hide button after image is loaded
                }
            }
        }

        // --- StoreName Link Logic ---
        private void textBoxStoreName_TextChanged(object sender, EventArgs e)
        {
            //if (textBoxStoreName.Text != StoreNamePlaceholder)
            //{
            //    labelStaticStoreName.Text = textBoxStoreName.Text;
            //}
            //else
            //{
            //    labelStaticStoreName.Text = "Cửa hàng của bạn";
            //}
        }

        // --- StoreName Placeholder Logic ---
        private void textBoxStoreName_Enter(object sender, EventArgs e)
        {
            //if (textBoxStoreName.Text == StoreNamePlaceholder)
            //{
            //    textBoxStoreName.Text = "";
            //    textBoxStoreName.ForeColor = SystemColors.WindowText;
            //}
        }

        private void textBoxStoreName_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(textBoxStoreName.Text))
            //{
            //    textBoxStoreName.Text = StoreNamePlaceholder;
            //    textBoxStoreName.ForeColor = SystemColors.GrayText;
            //    //labelStaticStoreName.Text = "Cửa hàng của bạn";
            //}
        }

        // --- Username Placeholder Logic ---
        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == UsernamePlaceholder)
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                textBoxUsername.Text = UsernamePlaceholder;
                textBoxUsername.ForeColor = SystemColors.GrayText;
            }
        }

        // --- Password Placeholder Logic ---
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == PasswordPlaceholder)
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = SystemColors.WindowText;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.Text = PasswordPlaceholder;
                textBoxPassword.ForeColor = SystemColors.GrayText;
                textBoxPassword.UseSystemPasswordChar = false; // Show placeholder text
            }
        }

        private void labelEyeIcon_Click(object sender, EventArgs e)
        {
            // Toggle password visibility only if the user has entered text
            if (textBoxPassword.Text != PasswordPlaceholder)
            {
                textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
            }
        }

        private void pictureBoxIllustration_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}