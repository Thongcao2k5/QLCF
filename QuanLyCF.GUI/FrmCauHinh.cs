
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QuanLyCF.GUI
{
    public partial class FrmCauHinh : Form
    {
        private FormDangNhap formDangNhap;

        public FrmCauHinh(FormDangNhap formDangNhap)
        {
            InitializeComponent();
            LoadConnectionString();
            this.formDangNhap = formDangNhap;
        }

        private void LoadConnectionString()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                txtServer.Text = appSettings["ServerName"] ?? "";
                txtDatabase.Text = appSettings["DatabaseName"] ?? "";
                txtUsername.Text = appSettings["Username"] ?? "";
                txtPassword.Text = appSettings["Password"] ?? "";
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string database = txtDatabase.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            }
            else
            {
                connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
            }

            if (QuanLyCF.DAL.DataProvider.TestConnection(connectionString))
            {
                try
                {
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;

                    settings.Remove("ServerName");
                    settings.Add("ServerName", txtServer.Text);

                    settings.Remove("DatabaseName");
                    settings.Add("DatabaseName", txtDatabase.Text);

                    settings.Remove("Username");
                    settings.Add("Username", txtUsername.Text);

                    settings.Remove("Password");
                    settings.Add("Password", txtPassword.Text);

                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                    QuanLyCF.DAL.DataProvider.ReloadConnectionString(); // Add this line

                    MessageBox.Show("Lưu kết nối thành công!");
                    this.formDangNhap.EnableLoginButton();
                    this.Close();
                }
                catch (ConfigurationErrorsException)
                {
                    MessageBox.Show("Lỗi khi ghi cài đặt ứng dụng");
                }
            }
            else
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu không thành công!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text;
            string database = txtDatabase.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            }
            else
            {
                connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
            }

            if (QuanLyCF.DAL.DataProvider.TestConnection(connectionString))
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");
            }
            else
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu không thành công!");
            }
        }
    }
}
