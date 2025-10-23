using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCF.DAL;

namespace QuanLyCF.GUI
{
    public partial class FormDoanhThu : Form
    {
        private const string SearchPlaceholder = "Tìm kiếm";

        public FormDoanhThu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            SetupDataGridView();
            // UpdateTotal(); // Will be called after LoadInvoiceData
            // Initial state for collapse/expand buttons
            this.buttonDown.Visible = false;
        }

        private void SetupDataGridView()
        {
            dataGridViewInvoices.Columns.Clear();
            dataGridViewInvoices.AutoGenerateColumns = false;

            dataGridViewInvoices.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoHoaDon", HeaderText = "Số hóa đơn", DataPropertyName = "InvoiceID" });
            dataGridViewInvoices.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoBan", HeaderText = "Số bàn", DataPropertyName = "TableID" });
            dataGridViewInvoices.Columns.Add(new DataGridViewTextBoxColumn() { Name = "KhachHang", HeaderText = "Khách hàng", DataPropertyName = "CustomerName" });
            dataGridViewInvoices.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TongThanhToan", HeaderText = "Tổng thanh toán", DataPropertyName = "FinalAmount" });
            dataGridViewInvoices.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ThoiGian", HeaderText = "Thời gian", DataPropertyName = "PaymentDate" });
            dataGridViewInvoices.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "Status" });

            foreach (DataGridViewColumn col in dataGridViewInvoices.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadInvoiceData()
        {
            DataTable invoices = OrderDAO.GetAllInvoices();
            dataGridViewInvoices.Rows.Clear();

            foreach (DataRow row in invoices.Rows)
            {
                int rowIndex = dataGridViewInvoices.Rows.Add();
                DataGridViewRow newRow = dataGridViewInvoices.Rows[rowIndex];

                newRow.Cells["SoHoaDon"].Value = row["InvoiceID"];
                newRow.Cells["SoBan"].Value = row["TableID"];
                newRow.Cells["KhachHang"].Value = "Khách lẻ";
                newRow.Cells["TongThanhToan"].Value = Convert.ToDecimal(row["FinalAmount"]).ToString("N0", new CultureInfo("vi-VN"));
                newRow.Cells["ThoiGian"].Value = Convert.ToDateTime(row["PaymentDate"]).ToString("dd/MM/yyyy HH:mm");
                newRow.Cells["TrangThai"].Value = row["Status"];
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewInvoices.Rows)
            {
                if (row.Visible)
                {
                    if (row.Cells["TongThanhToan"].Value != null)
                    {
                        string cellValue = row.Cells["TongThanhToan"].Value.ToString();
                        // Remove currency symbol and thousands separator for parsing
                        cellValue = cellValue.Replace(" đ", "").Replace(".", "");

                        if (decimal.TryParse(cellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
                        {
                            total += value;
                        }
                    }
                }
            }
            labelTotalAmount.Text = total.ToString("N0", new CultureInfo("vi-VN"));
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == SearchPlaceholder)
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = SearchPlaceholder;
                textBoxSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text;
            if (searchText == SearchPlaceholder)
            {
                return;
            }

            foreach (DataGridViewRow row in dataGridViewInvoices.Rows)
            {
                bool match = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        match = true;
                        break;
                    }
                }
                row.Visible = match;
            }

            UpdateTotal();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            panelFilterBar.Visible = false;
            buttonUp.Visible = false;
            buttonDown.Visible = true;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            panelFilterBar.Visible = true;
            buttonDown.Visible = false;
            buttonUp.Visible = true;
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            LoadInvoiceData();
        }

        private void dataGridViewInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelMenuIcon_Click(object sender, EventArgs e)
        {

        }

        private void labelHomeIcon_Click(object sender, EventArgs e)
        {
            this.Close();
            // parentForm.Show(); // Removed as parentForm is no longer a field
        }

        private void dataGridViewInvoices_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}