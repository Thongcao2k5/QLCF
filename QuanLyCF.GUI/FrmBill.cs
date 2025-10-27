using Guna.UI2.WinForms;
using QuanLyCF.BUS;
using QuanLyCF.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyCF.GUI
{
    public partial class FrmBill : Form
    {
        public int TableId { get; set; }
        private int orderId;

        public FrmBill()
        {
            InitializeComponent();
            this.dgvBill.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBill_CellFormatting);
        }

        private void FrmBill_Load(object sender, EventArgs e)
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
                this.orderId = Convert.ToInt32(order["PendingOrderID"]);
                lblBan.Text = "Bàn: " + this.TableId;
                lblNgay.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                lblNhanVien.Text = "Nhân viên: " + CurrentUser.DisplayName;

                // Load order details
                DataTable orderDetails = PendingOrderDetailBUS.GetDetailsByOrderId(this.orderId);
                dgvBill.DataSource = orderDetails;

                // Load totals from the pending order
                decimal total = Convert.ToDecimal(order["TotalAmount"]);
                decimal discount = Convert.ToDecimal(order["Discount"]);
                decimal finalAmount = Convert.ToDecimal(order["FinalAmount"]);

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

        private void btnLuu_Click(object sender, EventArgs e)
        {

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