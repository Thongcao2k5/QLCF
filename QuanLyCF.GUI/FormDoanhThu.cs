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

namespace QuanLyCF.GUI
{
    public partial class FormDoanhThu : Form
    {
        private const string SearchPlaceholder = "Tìm kiếm";

        private FrmOrder parentForm;

        public FormDoanhThu(FrmOrder parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.WindowState = FormWindowState.Maximized;
            SetupDataGridView();
            UpdateTotal();
            // Initial state for collapse/expand buttons
            this.buttonDown.Visible = false;
        }

        private void SetupDataGridView()
        {
            dataGridViewInvoices.Columns.Clear();
            dataGridViewInvoices.Columns.Add("SoHoaDon", "Số hóa đơn");
            dataGridViewInvoices.Columns.Add("Order", "Order");
            dataGridViewInvoices.Columns.Add("KhachHang", "Khách hàng");
            dataGridViewInvoices.Columns.Add("TongThanhToan", "Tổng thanh toán");
            dataGridViewInvoices.Columns.Add("ThoiGian", "Thời gian");
            dataGridViewInvoices.Columns.Add("TrangThai", "Trạng thái");

            dataGridViewInvoices.Columns["SoHoaDon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewInvoices.Columns["Order"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewInvoices.Columns["KhachHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewInvoices.Columns["TongThanhToan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewInvoices.Columns["ThoiGian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewInvoices.Rows)
            {
                if (row.Visible)
                {
                    if (decimal.TryParse(row.Cells["TongThanhToan"].Value.ToString().Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
                    {
                        total += value;
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
            parentForm.Show();
        }

        private void dataGridViewInvoices_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
