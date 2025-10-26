using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyCF.DAL;
using QuanLyCF.BUS;

namespace QuanLyCF.GUI
{
    public partial class FrmMenu : Form
    {
        private int tableId;
        private int pendingOrderId = -1; // -1 nghĩa là chưa có order nào
        private decimal totalAmount = 0;
        private List<DrinkDTO> drinks;
        private List<DrinkDTO> filteredDrinks;
        private readonly string imageFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\"));
        private Action onOrderSaved;

        public FrmMenu(int tableId, Action callback = null)
        {
            InitializeComponent();
            this.tableId = tableId;
            this.onOrderSaved = callback;
        }

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            LoadDrinks();
            LoadPendingOrder();
            DisplayDrinks(drinks);
            SetupOrderDataGridView();
        }

        private void SetupOrderDataGridView()
        {
            // Add hidden column for unit price
            var unitPriceCol = new DataGridViewTextBoxColumn
            {
                Name = "colUnitPrice",
                HeaderText = "Unit Price",
                Visible = false
            };
            dgvOrder.Columns.Add(unitPriceCol);

            // Set column read-only properties
            dgvOrder.Columns["colName"].ReadOnly = true;
            dgvOrder.Columns["colPrice"].ReadOnly = true;
            dgvOrder.Columns["colQty"].ReadOnly = false;

            // Attach event handler
            dgvOrder.CellValueChanged += dgvOrder_CellValueChanged;
        }

        // ======================= LOAD DRINKS =======================
        private void LoadDrinks()
        {
            drinks = DrinkBUS.GetAllDrinks().Select(d => new DrinkDTO
            {
                DrinkID = d.DrinkID,
                DrinkName = d.DrinkName,
                CategoryID = d.CategoryID,
                Price = d.Price,
                ImagePath = d.ImagePath,
                IsAvailable = d.IsAvailable,
                CreatedDate = d.CreatedDate
            }).ToList();
            filteredDrinks = new List<DrinkDTO>(drinks);
        }

        // ======================= LOAD EXISTING PENDING ORDER =======================
        private void LoadPendingOrder()
        {
            DataRow order = PendingOrderBUS.GetPendingOrderByTableId(tableId);
            if (order != null)
            {
                pendingOrderId = Convert.ToInt32(order["PendingOrderID"]);
                DataTable orderDetails = PendingOrderDetailBUS.GetDetailsByOrderId(pendingOrderId);

                foreach (DataRow row in orderDetails.Rows)
                {
                    int drinkId = Convert.ToInt32(row["DrinkID"]);
                    string drinkName = row["DrinkName"].ToString();
                    int qty = Convert.ToInt32(row["Quantity"]);
                    decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                    // Add data to the grid, including the hidden unit price column
                    dgvOrder.Rows.Add(drinkId, drinkName, qty, unitPrice * qty, unitPrice);
                }

                UpdateTotal();
            }
        }

        // ======================= HIỂN THỊ DANH SÁCH MÓN =======================
        private void DisplayDrinks(List<DrinkDTO> items)
        {
            flowLayoutPanelMenu.Controls.Clear();

            int itemsPerRow = 5;
            int spacing = 10;
            int width = (flowLayoutPanelMenu.ClientSize.Width - (itemsPerRow + 1) * spacing) / itemsPerRow;
            int height = (int)(width * 1.3);

            foreach (var drink in items)
            {
                Panel panel = new Panel
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.White,
                    //Margin = new Padding(spacing / 2),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = drink
                };

                string imagePath = GetImagePath(drink.ImagePath);

                PictureBox pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = (int)(height * 0.75),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = LoadImageSafe(imagePath),
                    Cursor = Cursors.Hand,
                    Tag = drink
                };
                pic.Click += Drink_Click;

                Label lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = $"{drink.ImagePath}\n{drink.Price:N0},000 đ",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic),
                    ForeColor = Color.FromArgb(50, 30, 20),
                    BackColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = drink
                };
                lbl.Click += Drink_Click;

                panel.Controls.Add(lbl);
                panel.Controls.Add(pic);
                flowLayoutPanelMenu.Controls.Add(panel);
            }
        }
        // ======================= LẤY ĐƯỜNG DẪN HÌNH ẢNH =======================
        private string GetImagePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return Path.Combine(imageFolder, "error_image.png");

            var fullPath = Path.Combine(imageFolder, fileName);

            return File.Exists(fullPath)
                ? fullPath
                : Path.Combine(imageFolder, "error_image.png");
        }

        // ======================= LOAD HÌNH ẢNH AN TOÀN =======================
        private Image LoadImageSafe(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(fs);
                }
            }
            catch
            {
                return SystemIcons.Warning.ToBitmap();
            }
        }

        // ======================= CLICK MÓN =======================
        private void Drink_Click(object sender, EventArgs e)
        {
            var drink = (sender as Control)?.Tag as DrinkDTO;
            if (drink == null) return;

            DataGridViewRow existingRow = null;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (Convert.ToInt32(row.Cells["colDrinkID"].Value) == drink.DrinkID)
                {
                    existingRow = row;
                    break;
                }
            }

            if (existingRow != null)
            {
                int newQty = Convert.ToInt32(existingRow.Cells["colQty"].Value) + 1;
                existingRow.Cells["colQty"].Value = newQty;
                existingRow.Cells["colPrice"].Value = newQty * drink.Price;
            }
            else
            {
                dgvOrder.Rows.Add(drink.DrinkID, drink.DrinkName, 1, drink.Price, drink.Price);
            }

            UpdateTotal();
        }

        // ======================= TÍNH TỔNG =======================
        private void UpdateTotal()
        {
            totalAmount = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["colPrice"].Value != null)
                    totalAmount += Convert.ToDecimal(row.Cells["colPrice"].Value);
            }

            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text, out discount);
            decimal finalAmount = totalAmount - discount;
            if (finalAmount < 0) finalAmount = 0;

            lblTotal.Text = $"Tổng tiền: {finalAmount:N0} đ";
        }

        // ======================= LƯU ORDER =======================
        private bool SaveOrder()
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món nào trong order!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal.TryParse(txtDiscount.Text, out decimal discount);
            decimal finalAmount = totalAmount - discount;

            if (pendingOrderId == -1) // Create new pending order
            {
                pendingOrderId = PendingOrderBUS.CreatePendingOrder(tableId, totalAmount, discount, finalAmount);
                TableBUS.UpdateTableStatus(tableId, true);
            }
            else // Update existing pending order
            {
                PendingOrderDetailBUS.DeleteDetailsByOrderId(pendingOrderId);
                PendingOrderBUS.UpdatePendingOrder(pendingOrderId, totalAmount, discount, finalAmount);
            }

            // Add all items from DataGridView to the order details
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                int drinkId = Convert.ToInt32(row.Cells["colDrinkID"].Value);
                int qty = Convert.ToInt32(row.Cells["colQty"].Value);
                decimal unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                PendingOrderDetailBUS.AddDetail(pendingOrderId, drinkId, qty, unitPrice);
            }
            return true;
        }

        private void btnLuuOrder_Click(object sender, EventArgs e)
        {
            if (SaveOrder())
            {
                MessageBox.Show("Đã lưu order thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onOrderSaved?.Invoke();
                this.Close();
            }
        }

        // ======================= THANH TOÁN =======================
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (pendingOrderId == -1 && dgvOrder.Rows.Count == 0)
            {
                 MessageBox.Show("Chưa có order để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }

            // Save any last-minute changes before paying
            if (SaveOrder())
            {
                // Process payment
                PendingOrderBUS.ProcessPayment(pendingOrderId, tableId);
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onOrderSaved?.Invoke();
                this.Close();
            }
        }

        private void txtKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            filteredDrinks = drinks.Where(d => d.DrinkName.ToLower().Contains(keyword)).ToList();
            DisplayDrinks(filteredDrinks);
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            AppSettings.ShowToast(this, "Xóa món thành công!");
            if (dgvOrder.SelectedRows.Count > 0)
            {
                DataTable dt = dgvOrder.DataSource as DataTable;
                if (dt != null)
                {
                    foreach (DataGridViewRow row in dgvOrder.SelectedRows)
                    {
                        if (!row.IsNewRow)
                            dt.Rows.RemoveAt(row.Index);
                    }
                }
                UpdateTotal();
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the event is for the quantity column and the row is valid
            if (e.RowIndex < 0 || e.ColumnIndex != dgvOrder.Columns["colQty"].Index)
            {
                return;
            }

            DataGridViewRow row = dgvOrder.Rows[e.RowIndex];

            // Get the new quantity
            if (!int.TryParse(row.Cells["colQty"].Value.ToString(), out int newQty))
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ cho số lượng.", "Số lượng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If quantity is 0 or less, remove the item
            if (newQty <= 0)
            {
                this.BeginInvoke(new MethodInvoker(() => {
                    if (!row.IsNewRow)
                    {
                        dgvOrder.Rows.Remove(row);
                        UpdateTotal();
                    }
                }));
                return;
            }

            // Get the unit price from the hidden column
            if (!decimal.TryParse(row.Cells["colUnitPrice"].Value.ToString(), out decimal unitPrice))
            {
                return;
            }

            // Update the total price for the row
            row.Cells["colPrice"].Value = newQty * unitPrice;

            // Update the grand total
            UpdateTotal();
        }
    }

    // ===== DTO: DRINK =====
    public class DrinkDTO
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
