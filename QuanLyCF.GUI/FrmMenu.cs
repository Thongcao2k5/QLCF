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

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            LoadDrinks();
            LoadPendingOrder();
            DisplayDrinks(drinks);
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
            DataRow order = PendingOrderDAO.GetPendingOrderByTableId(tableId);
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
                    dgvOrder.Rows.Add(drinkId, drinkName, qty, unitPrice * qty);
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
                    Margin = new Padding(spacing / 2),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = drink
                };

                PictureBox pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = (int)(height * 0.75),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = File.Exists(Path.Combine(imageFolder, drink.ImagePath ?? ""))
                            ? Image.FromFile(Path.Combine(imageFolder, drink.ImagePath))
                            : SystemIcons.Warning.ToBitmap(),
                    Cursor = Cursors.Hand,
                    Tag = drink
                };
                pic.Click += Drink_Click;

                Label lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = $"{drink.DrinkName}\n{drink.Price:N0} đ",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(50, 30, 20),
                    Cursor = Cursors.Hand,
                    Tag = drink
                };
                lbl.Click += Drink_Click;

                panel.Controls.Add(lbl);
                panel.Controls.Add(pic);
                flowLayoutPanelMenu.Controls.Add(panel);
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
                existingRow.Cells["colTotal"].Value = newQty * drink.Price;
            }
            else
            {
                dgvOrder.Rows.Add(drink.DrinkID, drink.DrinkName, 1, drink.Price);
            }

            UpdateTotal();
        }

        // ======================= TÍNH TỔNG =======================
        private void UpdateTotal()
        {
            totalAmount = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["colTotal"].Value != null)
                    totalAmount += Convert.ToDecimal(row.Cells["colTotal"].Value);
            }

            decimal discount = 0;
            decimal.TryParse(txtKhuyenMai.Text, out discount);
            decimal final = totalAmount - discount;
            if (final < 0) final = 0;

            lblTotal.Text = $"Tổng tiền: {final:N0} đ";
        }

        // ======================= LƯU ORDER =======================
        private void btnLuuOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món nào để lưu!", "Thông báo");
                return;
            }

            decimal discount = 0;
            decimal.TryParse(txtKhuyenMai.Text, out discount);
            decimal finalAmount = totalAmount - discount;

            if (pendingOrderId == -1)
            {
                pendingOrderId = PendingOrderDAO.CreatePendingOrder(tableId, totalAmount, discount, finalAmount);
                TableDAO.UpdateTableStatus(tableId, true);
            }
            else
            {
                PendingOrderDAO.DeleteOrderDetails(pendingOrderId);
                PendingOrderDAO.UpdatePendingOrder(pendingOrderId, totalAmount, discount, finalAmount);
            }

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                int drinkId = Convert.ToInt32(row.Cells["colDrinkID"].Value);
                int qty = Convert.ToInt32(row.Cells["colQty"].Value);
                decimal total = Convert.ToDecimal(row.Cells["colTotal"].Value);
                decimal unitPrice = total / qty;
                PendingOrderDAO.AddOrderDetail(pendingOrderId, drinkId, qty, unitPrice);
            }

            MessageBox.Show("Đã lưu order!", "Thông báo");
            onOrderSaved?.Invoke();
            this.Close();
        }

        // ======================= THANH TOÁN =======================
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (pendingOrderId == -1)
            {
                MessageBox.Show("Chưa có order để thanh toán!", "Thông báo");
                return;
            }

            PendingOrderDAO.CompletePendingOrder(pendingOrderId);
            TableDAO.UpdateTableStatus(tableId, false);
            MessageBox.Show("Thanh toán thành công!", "Thông báo");
            onOrderSaved?.Invoke();
            this.Close();
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
            if (dgvOrder.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrder.SelectedRows)
                    dgvOrder.Rows.Remove(row);
                UpdateTotal();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
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
