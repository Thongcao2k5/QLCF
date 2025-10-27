using Guna.UI2.WinForms;
using QuanLyCF.BUS;
using QuanLyCF.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyCF.GUI
{
    public partial class FrmBill : Form
    {
        public int TableId { get; set; }
        public Action onPaymentSuccess;
        private int orderId;
        private Form previousForm;

        public FrmBill() : this(null)
        {
        }

        public FrmBill(Form prevForm)
        {
            InitializeComponent();
            this.dgvBill.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBill_CellFormatting);
            this.previousForm = prevForm;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBill_FormClosed);
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {
            try
            {
                // Setup DGV Columns
                dgvBill.Columns.Clear();
                dgvBill.AutoGenerateColumns = false;
                dgvBill.Columns.Add("DrinkName", "Tên món");
                dgvBill.Columns.Add("Quantity", "Số lượng");
                dgvBill.Columns.Add("UnitPrice", "Đơn giá");
                dgvBill.Columns.Add("Total", "Thành tiền");
                dgvBill.Columns["DrinkName"].DataPropertyName = "DrinkName";
                dgvBill.Columns["Quantity"].DataPropertyName = "Quantity";
                dgvBill.Columns["UnitPrice"].DataPropertyName = "UnitPrice";
                dgvBill.Columns["Total"].DataPropertyName = "Total";

                // Load order information
                DataRow order = PendingOrderBUS.GetPendingOrderByTableId(this.TableId);
                if (order != null)
                {
                    this.orderId = order.Table.Columns.Contains("PendingOrderID") && !Convert.IsDBNull(order["PendingOrderID"]) ? Convert.ToInt32(order["PendingOrderID"]) : 0;
                    lblBan.Text = "Bàn: " + this.TableId;
                    lblNgay.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    lblNhanVien.Text = "Nhân viên: " + (CurrentUser.DisplayName ?? "N/A");

                    // Load order details
                    DataTable orderDetails = PendingOrderDetailBUS.GetDetailsByOrderId(this.orderId);
                    dgvBill.DataSource = orderDetails;

                    // Load totals from the pending order with DBNull checks
                    decimal total = order.Table.Columns.Contains("TotalAmount") && !Convert.IsDBNull(order["TotalAmount"]) ? Convert.ToDecimal(order["TotalAmount"]) : 0;
                    decimal discount = order.Table.Columns.Contains("Discount") && !Convert.IsDBNull(order["Discount"]) ? Convert.ToDecimal(order["Discount"]) : 0;
                    decimal finalAmount = order.Table.Columns.Contains("FinalAmount") && !Convert.IsDBNull(order["FinalAmount"]) ? Convert.ToDecimal(order["FinalAmount"]) : 0;

                    txtTongTien.Text = total.ToString("N0", new CultureInfo("en-US"));
                    txtGiamGia.Text = discount.ToString("N0", new CultureInfo("en-US"));
                    txtThanhTien.Text = finalAmount.ToString("N0", new CultureInfo("en-US"));
                }
                else
                {
                    MessageBox.Show("Không tìm thấy order đang hoạt động cho bàn này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải thông tin hóa đơn: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dgvBill_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvBill.Columns["UnitPrice"].Index || e.ColumnIndex == dgvBill.Columns["Total"].Index)
            {
                if (e.Value != null && e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("N0", new CultureInfo("en-US"));
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTongTien.Text, NumberStyles.Any, new CultureInfo("en-US"), out decimal tongTien) &&
                decimal.TryParse(txtGiamGia.Text, NumberStyles.Any, new CultureInfo("en-US"), out decimal giamGia))
            {
                txtThanhTien.Text = (tongTien - giamGia).ToString("N0", new CultureInfo("en-US"));
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // 1. Get final discount and totals from UI
            if (!decimal.TryParse(txtTongTien.Text, NumberStyles.Any, new CultureInfo("en-US"), out decimal total))
            {
                MessageBox.Show("Tổng tiền không hợp lệ!");
                return;
            }
            if (!decimal.TryParse(txtGiamGia.Text, NumberStyles.Any, new CultureInfo("en-US"), out decimal discount))
            {
                discount = 0;
            }

            decimal finalAmount = total - discount;

            try
            {
                // 2. Update the pending order with the final discount amount
                PendingOrderBUS.UpdatePendingOrder(this.orderId, total, discount, finalAmount);

                // 3. Process the payment, which will convert the pending order to a final one
                if (this.orderId > 0)
                {
                    PendingOrderBUS.ProcessPayment(this.orderId, this.TableId);
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    onPaymentSuccess?.Invoke();
                    this.DialogResult = DialogResult.OK; // Set result for the calling form
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm?.Show();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Size = this.Size; // Set size to match FrmBill
            printPreviewDialog.ShowDialog();
        }



        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Font font = new Font("Courier New", 10);
                Font boldFont = new Font("Courier New", 10, FontStyle.Bold);
                Font headerFont = new Font("Courier New", 16, FontStyle.Bold);
                float fontHeight = font.GetHeight();
                int startX = 50;
                int startY = 50;
                int offset = 0;
                int billWidth = 300; // Approximate width for a receipt

                // --- Centering and Store Info ---
                DataRow storeInfo = StoreInfoBUS.GetStoreInfo();
                string storeName = "Tên Cửa Hàng";
                string address = "Địa chỉ của bạn";
                string hotline = "Hotline";

                if (storeInfo != null)
                {
                    storeName = storeInfo["StoreName"]?.ToString() ?? storeName;
                    address = storeInfo["Address"]?.ToString() ?? address;
                    hotline = storeInfo["Hotline"]?.ToString() ?? hotline;
                }

                StringFormat centerFormat = new StringFormat();
                centerFormat.Alignment = StringAlignment.Center;
                RectangleF headerRect = new RectangleF(startX, startY + offset, billWidth, font.GetHeight() * 2);
                g.DrawString(storeName, headerFont, new SolidBrush(Color.Black), headerRect, centerFormat);
                offset += (int)headerRect.Height;

                // --- Address with Word Wrap ---
                RectangleF addressRect = new RectangleF(startX, startY + offset, billWidth, font.GetHeight() * 3); // Allow for up to 3 lines
                g.DrawString($"Địa chỉ: {address}", font, new SolidBrush(Color.Black), addressRect);
                SizeF addressSize = g.MeasureString($"Địa chỉ: {address}", font, billWidth);
                offset += (int)addressSize.Height;

                g.DrawString($"Hotline: {hotline}", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 20;

                // Title
                RectangleF titleRect = new RectangleF(startX, startY + offset, billWidth, font.GetHeight());
                g.DrawString("HÓA ĐƠN THANH TOÁN", boldFont, new SolidBrush(Color.Black), titleRect, centerFormat);
                offset += (int)fontHeight + 20;

                // Order Info
                g.DrawString($"Bàn: {this.TableId}", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 5;
                g.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 5;
                g.DrawString($"Nhân viên: {CurrentUser.DisplayName}", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 10;

                // Separator
                g.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 5;

                // Headers
                g.DrawString("Tên món", boldFont, new SolidBrush(Color.Black), startX, startY + offset);
                g.DrawString("SL", boldFont, new SolidBrush(Color.Black), startX + 180, startY + offset);
                g.DrawString("T.Tiền", boldFont, new SolidBrush(Color.Black), startX + 230, startY + offset);
                offset += (int)fontHeight + 5;

                // Separator
                g.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 10;

                // Items
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (row.IsNewRow || row.Cells["DrinkName"].Value == null || row.Cells["Quantity"].Value == null || row.Cells["Total"].Value == null)
                        continue;

                    string name = row.Cells["DrinkName"].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                    // Draw item name with wrapping
                    RectangleF itemRect = new RectangleF(startX, startY + offset, 170, font.GetHeight() * 2);
                    g.DrawString(name, font, new SolidBrush(Color.Black), itemRect);
                    SizeF itemNameSize = g.MeasureString(name, font, 170);

                    g.DrawString(quantity.ToString(), font, new SolidBrush(Color.Black), startX + 185, startY + offset);
                    g.DrawString(total.ToString("N0"), font, new SolidBrush(Color.Black), startX + 230, startY + offset);
                    offset += (int)Math.Max(itemNameSize.Height, fontHeight) + 5;
                }

                // Separator
                g.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset += (int)fontHeight + 10;

                // Totals
                g.DrawString("Tổng tiền:", font, new SolidBrush(Color.Black), startX + 50, startY + offset);
                g.DrawString(txtTongTien.Text, font, new SolidBrush(Color.Black), startX + 230, startY + offset);
                offset += (int)fontHeight + 5;

                g.DrawString("Giảm giá:", font, new SolidBrush(Color.Black), startX + 50, startY + offset);
                g.DrawString(txtGiamGia.Text, font, new SolidBrush(Color.Black), startX + 230, startY + offset);
                offset += (int)fontHeight + 5;

                g.DrawString("Thành tiền:", boldFont, new SolidBrush(Color.Black), startX + 50, startY + offset);
                g.DrawString(txtThanhTien.Text, boldFont, new SolidBrush(Color.Black), startX + 230, startY + offset);
                offset += (int)fontHeight + 20;

                // Footer
                RectangleF footerRect = new RectangleF(startX, startY + offset, billWidth, font.GetHeight());
                g.DrawString("Cảm ơn quý khách!", font, new SolidBrush(Color.Black), footerRect, centerFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo nội dung hóa đơn để in: \n" + ex.ToString(), "Lỗi In Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}