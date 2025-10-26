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
            //dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;


            // Load order information
            DataRow order = OrderDAO.GetActiveOrderByTableId(this.TableId);
            if (order != null)
            {
                this.orderId = Convert.ToInt32(order["OrderID"]);
                lblBan.Text = "Bàn: " + this.TableId;
                lblNgay.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                // TODO: Get employee name from UserDAO
                lblNhanVien.Text = "Nhân viên: Nhân viên 1";

                // Load order details
                DataTable orderDetails = OrderDAO.GetOrderDetailsByOrderId(this.orderId);
                orderDetails.Columns.Add("Total", typeof(decimal));
                decimal total = 0;
                foreach (DataRow row in orderDetails.Rows)
                {
                    decimal totalForRow = Convert.ToDecimal(row["Quantity"]) * Convert.ToDecimal(row["UnitPrice"]);
                    row["Total"] = totalForRow;
                    total += totalForRow;

                }


                dgvBill.DataSource = orderDetails;



                // Calculate total
                txtTongTien.Text = total.ToString("N0", new CultureInfo("en-US"));
                txtThanhTien.Text = total.ToString("N0", new CultureInfo("en-US"));
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

            // Lấy dữ liệu tổng tiền và giảm giá ở UI
            decimal discount = 0;
            decimal.TryParse(txtGiamGia.Text, out discount);

            decimal total = 0;
            decimal.TryParse(txtTongTien.Text, out total);

            decimal finalAmount = total - discount;

            //AppSettings.ShowToastTest(this, "Tổng tiền: " + total + " Giảm giá: " + discount);

            PendingOrderDetailBUS.DeleteDetailsByOrderId(this.orderId);
            PendingOrderBUS.UpdatePendingOrder(this.orderId, total, discount, finalAmount);

            if (this.orderId > 0)
            {
                OrderDAO.ProcessPayment(this.orderId);
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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