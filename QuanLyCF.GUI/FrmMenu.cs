using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using QuanLyCF.DAL;
using QuanLyCF.GUI;

namespace QuanLyCF.GUI
{
    public partial class FrmMenu : Form
    {
        private List<MenuItem> menuItems = new List<MenuItem>();
        private List<MenuItem> displayedItems;
        private decimal totalAmount = 0;
        private readonly string imageFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\"));
        private Action<decimal, bool> onOrderSaved;
        private int tableId;
        private int currentOrderId = -1; // -1 indicates no existing order

        public FrmMenu(Action<decimal, bool> onSaveCallback, int tableId)
        {
            InitializeComponent();
            this.onOrderSaved = onSaveCallback;
            this.tableId = tableId;

            LoadMenuItems();
            LoadExistingOrder(tableId); // Load existing order if any
            this.displayedItems = this.menuItems;

            // Gán event Load hợp lệ
            this.Load += FrmMenu_Load;
            this.flowLayoutPanelMenu.Resize += (s, e) => DisplayMenuItems(this.displayedItems);
        }

        private void LoadExistingOrder(int tableId)
        {
            DataRow activeOrder = QuanLyCF.DAL.OrderDAO.GetActiveOrderByTableId(tableId);
            if (activeOrder != null)
            {
                currentOrderId = Convert.ToInt32(activeOrder["OrderID"]); // Set currentOrderId
                DataTable orderDetails = QuanLyCF.DAL.OrderDAO.GetOrderDetailsByOrderId(currentOrderId);

                foreach (DataRow row in orderDetails.Rows)
                {
                    int menuItemId = Convert.ToInt32(row["MenuItemID"]);
                    string itemName = row["ItemName"].ToString();
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);

                    // Find the corresponding MenuItem to get its original price
                    MenuItem originalMenuItem = menuItems.FirstOrDefault(item => item.MenuItemID == menuItemId);
                    decimal originalPrice = originalMenuItem != null ? originalMenuItem.Price : unitPrice; // Use original price if found, else use unitPrice from order details

                    dgvOrder.Rows.Add(menuItemId, itemName, quantity, originalPrice, quantity * unitPrice);
                }
                UpdateTotal();
            }
            else
            {
                currentOrderId = -1; // Ensure it's -1 if no active order
            }
        }

        // ====== SỰ KIỆN LOAD FORM ======
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            DisplayMenuItems(this.displayedItems);
            this.btnXoaMon.BringToFront();
        }

        // ===== DANH SÁCH MÓN =====
        private void LoadMenuItems()
        {
            menuItems.Clear();
            DataTable dt = QuanLyCF.DAL.OrderDAO.GetAllMenuItems();

            foreach (DataRow row in dt.Rows)
            {
                int menuItemId = Convert.ToInt32(row["MenuItemID"]);
                string name = row["ItemName"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);
                string imagePath = Path.Combine(imageFolder, row["ImagePath"].ToString());
                string category = row["Category"].ToString();

                menuItems.Add(new MenuItem(menuItemId, name, price, imagePath, category));
            }
        }

        // ===== HIỂN THỊ MENU =====
        private void DisplayMenuItems(List<MenuItem> itemsToDisplay)
        {
            if (flowLayoutPanelMenu.DisplayRectangle.Width == 0) return;

            flowLayoutPanelMenu.Controls.Clear();
            flowLayoutPanelMenu.WrapContents = true;
            flowLayoutPanelMenu.AutoScroll = true;
            flowLayoutPanelMenu.Padding = new Padding(5);

            int itemsPerRow = 5;
            int spacing = 10;
            int containerWidth = flowLayoutPanelMenu.ClientSize.Width - flowLayoutPanelMenu.Padding.Left - flowLayoutPanelMenu.Padding.Right;
            int totalSpacing = (itemsPerRow + 1) * spacing;
            int availableWidth = containerWidth - totalSpacing;
            int itemWidth = availableWidth / itemsPerRow;
            int itemHeight = (int)(itemWidth * 1.35);

            foreach (var item in itemsToDisplay)
            {
                Panel panel = new Panel
                {
                    Width = itemWidth,
                    Height = itemHeight,
                    Margin = new Padding(spacing / 2),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = item
                };

                PictureBox pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = (int)(itemHeight * 0.8),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = File.Exists(item.ImagePath)
                        ? Image.FromFile(item.ImagePath)
                        : SystemIcons.Warning.ToBitmap(),
                    Cursor = Cursors.Hand,
                    Tag = item
                };
                pic.Click += Btn_Click;

                Label lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = $"{item.Name}\n{item.Price:N0} đ",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(30, 30, 30),
                    Tag = item,
                    Cursor = Cursors.Hand
                };
                lbl.Click += Btn_Click;

                panel.Controls.Add(lbl);
                panel.Controls.Add(pic);
                flowLayoutPanelMenu.Controls.Add(panel);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var item = (sender as Control)?.Tag as MenuItem;
            if (item == null) return;

            int index = -1;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["colName"].Value?.ToString() == item.Name)
                {
                    index = row.Index;
                    break;
                }
            }

            if (index >= 0)
            {
                int qty = Convert.ToInt32(dgvOrder.Rows[index].Cells["colQty"].Value) + 1;
                dgvOrder.Rows[index].Cells["colQty"].Value = qty;
                dgvOrder.Rows[index].Cells["colPrice"].Value = qty * item.Price;
            }
            else
            {
                dgvOrder.Rows.Add(item.MenuItemID, item.Name, 1, item.Price);
            }

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            totalAmount = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["colPrice"].Value != null)
                    totalAmount += Convert.ToDecimal(row.Cells["colPrice"].Value);
            }

            decimal khuyenMai = 0;
            decimal.TryParse(txtKhuyenMai.Text, out khuyenMai);
            decimal tongSauKM = totalAmount - khuyenMai;
            if (tongSauKM < 0) tongSauKM = 0;

            lblTotal.Text = $"Tổng tiền: {tongSauKM:N0} đ";
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món nào trong hóa đơn!", "Thông báo");
                return;
            }

            UpdateTotal();

            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["colPrice"].Value != null)
                    totalAmount += Convert.ToDecimal(row.Cells["colPrice"].Value);
            }
            decimal discount = 0;
            decimal.TryParse(txtKhuyenMai.Text, out discount);
            decimal finalAmount = totalAmount - discount;

            // If it's a new order, create it first
            if (currentOrderId == -1)
            {
                currentOrderId = QuanLyCF.DAL.OrderDAO.CreateOrder(this.tableId, totalAmount, discount, finalAmount);
            }
            else // Existing order, update it before payment
            {
                // First, delete existing details for this order
                QuanLyCF.DAL.OrderDAO.DeletePendingOrderDetails(currentOrderId);
                // Then, update the main order details
                QuanLyCF.DAL.OrderDAO.UpdatePendingOrder(currentOrderId, totalAmount, discount, finalAmount);
            }

            // Now, save/update all order details from the DataGridView
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                int menuItemId = Convert.ToInt32(row.Cells["colMenuItemID"].Value);
                int quantity = Convert.ToInt32(row.Cells["colQty"].Value);
                decimal subtotal = Convert.ToDecimal(row.Cells["colPrice"].Value);
                decimal unitPrice = subtotal / quantity; // Calculate unit price from subtotal and quantity
                QuanLyCF.DAL.OrderDAO.CreateOrderDetail(currentOrderId, menuItemId, quantity, unitPrice);
            }

            // Now process payment
            QuanLyCF.DAL.OrderDAO.ProcessPayment(currentOrderId, "Cash"); // Assuming 'Cash' as default payment method
            MessageBox.Show("Thanh toán thành công!", "Thông báo");

            // Reset currentOrderId after payment
            currentOrderId = -1;
            onOrderSaved?.Invoke(0, true); // Inform parent that payment is complete and table is free

            dgvOrder.Rows.Clear();
            UpdateTotal();
            this.Close(); // Close FrmMenu after payment
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Clear();
            UpdateTotal();
            this.Close();
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrder.SelectedRows)
                {
                    dgvOrder.Rows.Remove(row);
                }
                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuuOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món nào để lưu!", "Thông báo");
                return;
            }

            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["colPrice"].Value);
            }
            decimal discount = 0;
            decimal.TryParse(txtKhuyenMai.Text, out discount);
            decimal finalAmount = totalAmount - discount;

            if (currentOrderId == -1) // New order
            {
                currentOrderId = QuanLyCF.DAL.OrderDAO.CreateOrder(this.tableId, totalAmount, discount, finalAmount);
            }
            else // Existing order, update it
            {
                // First, delete existing details for this order
                QuanLyCF.DAL.OrderDAO.DeletePendingOrderDetails(currentOrderId);
                // Then, update the main order details
                QuanLyCF.DAL.OrderDAO.UpdatePendingOrder(currentOrderId, totalAmount, discount, finalAmount);
            }

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                int menuItemId = Convert.ToInt32(row.Cells["colMenuItemID"].Value);
                int quantity = Convert.ToInt32(row.Cells["colQty"].Value);
                decimal subtotal = Convert.ToDecimal(row.Cells["colPrice"].Value);
                decimal unitPrice = subtotal / quantity;
                QuanLyCF.DAL.OrderDAO.CreateOrderDetail(currentOrderId, menuItemId, quantity, unitPrice);
            }

            MessageBox.Show("Đã lưu order thành công!", "Thành công");

            onOrderSaved?.Invoke(finalAmount, false);

            dgvOrder.Rows.Clear();
            UpdateTotal();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            this.displayedItems = menuItems
                .Where(m => m.Name.ToLower().Contains(keyword))
                .ToList();
            DisplayMenuItems(this.displayedItems);
        }

        private void txtKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
    }

    public class MenuItem
    {
        public int MenuItemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }

        public MenuItem(int menuItemId, string name, decimal price, string imagePath, string category)
        {
            MenuItemID = menuItemId;
            Name = name;
            Price = price;
            ImagePath = imagePath;
            Category = category;
        }
    }
}
