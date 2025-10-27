
using QuanLyCF.BUS;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmStore : Form
    {
        private Form previousForm;
        private DataRow _storeInfoRow;
        private string _newLogoPath = null;
        private readonly string _imageFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\System\"));

        public FrmStore(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
            this.Load += FrmStore_Load;
            this.FormClosed += FrmStore_FormClosed;
        }

        private void FrmStore_Load(object sender, EventArgs e)
        {
            btnUpdate.Click += btnUpdate_Click;
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            LoadStoreInfo();
        }

        private void LoadStoreInfo()
        {
            _storeInfoRow = StoreInfoBUS.GetStoreInfo();
            if (_storeInfoRow != null)
            {
                txtStoreName.Text = _storeInfoRow["StoreName"].ToString();
                txtAdress.Text = _storeInfoRow["Address"].ToString();
                txtHotline.Text = _storeInfoRow["Hotline"].ToString();
                txtEmail.Text = _storeInfoRow["Email"].ToString();
                txtFacebook.Text = _storeInfoRow["Facebook"].ToString();

                string logoPath = _storeInfoRow["LogoPath"].ToString();
                if (!string.IsNullOrEmpty(logoPath) && File.Exists(Path.Combine(_imageFolder, logoPath)))
                {
                    // Use a memory stream to avoid locking the file
                    using (FileStream fs = new FileStream(Path.Combine(_imageFolder, logoPath), FileMode.Open, FileAccess.Read))
                    {
                        guna2PictureBox1.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    guna2PictureBox1.Image = null; // Or a default placeholder image
                }
            }
            else
            {
                // If no store info exists, just leave the form blank for the user to fill out.
                txtStoreName.Text = "";
                txtAdress.Text = "";
                txtHotline.Text = "";
                txtEmail.Text = "";
                txtFacebook.Text = "";
                guna2PictureBox1.Image = null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string logoFileName = _storeInfoRow != null ? _storeInfoRow["LogoPath"].ToString() : "";

            // If a new logo was selected, copy it and get the new name
            if (!string.IsNullOrEmpty(_newLogoPath))
            {
                try
                {
                    logoFileName = Guid.NewGuid().ToString() + Path.GetExtension(_newLogoPath);
                    string newFilePath = Path.Combine(_imageFolder, logoFileName);
                    File.Copy(_newLogoPath, newFilePath, true); // Overwrite if exists
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu logo mới: " + ex.Message);
                    return;
                }
            }

            string name = txtStoreName.Text;
            string address = txtAdress.Text;
            string hotline = txtHotline.Text;
            string email = txtEmail.Text;
            string facebook = txtFacebook.Text;

            bool success;
            if (_storeInfoRow != null)
            {
                // Update existing record
                int storeId = Convert.ToInt32(_storeInfoRow["StoreID"]);
                success = StoreInfoBUS.UpdateStoreInfo(storeId, name, hotline, email, address, facebook, logoFileName);
            }
            else
            {
                // Insert new record
                success = StoreInfoBUS.InsertStoreInfo(name, hotline, email, address, facebook, logoFileName);
            }

            if (success)
            {
                MessageBox.Show("Lưu thông tin cửa hàng thành công!");
                _newLogoPath = null; // Reset new logo path after saving
                LoadStoreInfo(); // Refresh data
            }
            else
            {
                MessageBox.Show("Lưu thông tin thất bại.");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _newLogoPath = openFileDialog.FileName;
                    guna2PictureBox1.Image = new Bitmap(_newLogoPath);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm?.Show();
        }
    }
}
