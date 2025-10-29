

using QuanLyCF.BUS;
using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmDrink : Form
    {
        private string selectedImageName = string.Empty;
        private List<DrinkDAO> allDrinks;

        public FrmDrink()
        {
            InitializeComponent();
        }

        private void FrmDrink_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMasterData();
                PopulateFilterComboBox();
                ApplyDrinkFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void LoadMasterData()
        {
            allDrinks = DrinkBUS.GetAllDrinks();
            LoadCategories();
        }

        private void PopulateFilterComboBox()
        {
            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.Add("Đang bán");
            cboFilterStatus.Items.Add("Ngừng bán");
            cboFilterStatus.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            cboCategory.DataSource = DrinkCategoryBUS.GetAllCategories();
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryID";
        }

        private void ApplyDrinkFilters()
        {
            IEnumerable<DrinkDAO> filteredDrinks = allDrinks;

            // Filter by status
            string statusFilter = cboFilterStatus.SelectedItem.ToString();
            if (statusFilter == "Tất cả")
            {
                filteredDrinks = filteredDrinks.Where(d => d.IsAvailable);
            }
            else if (statusFilter == "Ngừng bán")
            {
                filteredDrinks = filteredDrinks.Where(d => !d.IsAvailable);
            }

            // Filter by search text
            string searchText = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                filteredDrinks = filteredDrinks.Where(d => d.DrinkName.ToLower().Contains(searchText));
            }

            dgvDrink.DataSource = filteredDrinks.ToList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            cboCategory.SelectedIndex = 0;
            picImage.Image = null;
            selectedImageName = string.Empty;
            chkIsAvailable.Checked = true;
            dgvDrink.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int categoryId = (int)cboCategory.SelectedValue;
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price format.");
                return;
            }
            bool isAvailable = chkIsAvailable.Checked;

            if (dgvDrink.SelectedRows.Count > 0 && dgvDrink.SelectedRows[0].DataBoundItem is DrinkDAO selectedDrink)
            {
                // Update
                DrinkBUS.UpdateDrink(selectedDrink.DrinkID, name, categoryId, price, selectedImageName, isAvailable);
            }
            else
            {
                // Insert
                DrinkBUS.InsertDrink(name, categoryId, price, selectedImageName, isAvailable);
            }

            LoadMasterData();
            ApplyDrinkFilters();
            btnNew_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDrink.SelectedRows.Count > 0 && dgvDrink.SelectedRows[0].DataBoundItem is DrinkDAO selectedDrink)
            {
                DrinkBUS.DeleteDrink(selectedDrink.DrinkID);
                LoadMasterData();
                ApplyDrinkFilters();
                btnNew_Click(sender, e);
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImageName = Path.GetFileName(openFileDialog.FileName);
                string destinationPath = Path.Combine(AppSettings.ImageFolder, selectedImageName);
                File.Copy(openFileDialog.FileName, destinationPath, true);
                picImage.ImageLocation = destinationPath;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyDrinkFilters();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyDrinkFilters();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDrink.Rows[e.RowIndex].DataBoundItem is DrinkDAO drink)
            {
                txtName.Text = drink.DrinkName;
                txtPrice.Text = drink.Price.ToString();
                cboCategory.SelectedValue = drink.CategoryID;
                chkIsAvailable.Checked = drink.IsAvailable;

                if (!string.IsNullOrEmpty(drink.ImagePath))
                {
                    selectedImageName = drink.ImagePath;
                    picImage.ImageLocation = Path.Combine(AppSettings.ImageFolder, selectedImageName);
                }
                else
                {
                    picImage.Image = null;
                    selectedImageName = string.Empty;
                }
            }
        }
    }
}


