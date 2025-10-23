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
    public partial class FrmHoaDon : Form // Renamed class
    {
        public FrmHoaDon() // Modified constructor
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvHoaDon.Columns.Clear(); // Renamed dataGridViewInvoices to dgvHoaDon
            dgvHoaDon.AutoGenerateColumns = false;

            // Columns for PendingOrders
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoOrder", HeaderText = "Số Order", DataPropertyName = "OrderID" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoBan", HeaderText = "Số bàn", DataPropertyName = "TableID" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn() { Name = "KhachHang", HeaderText = "Khách hàng", DataPropertyName = "CustomerName" }); // Placeholder
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TongThanhToan", HeaderText = "Tổng tiền", DataPropertyName = "FinalAmount" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ThoiGianOrder", HeaderText = "Thời gian Order", DataPropertyName = "OrderDate" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn() { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "Status" });

            foreach (DataGridViewColumn col in dgvHoaDon.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadPendingOrderData() // Renamed from LoadInvoiceData
        {
            DataTable pendingOrders = OrderDAO.GetAllPendingOrders(); // Call GetAllPendingOrders
            dgvHoaDon.Rows.Clear(); // Renamed dataGridViewInvoices to dgvHoaDon

            foreach (DataRow row in pendingOrders.Rows)
            {
                int rowIndex = dgvHoaDon.Rows.Add(); // Renamed dataGridViewInvoices to dgvHoaDon
                DataGridViewRow newRow = dgvHoaDon.Rows[rowIndex]; // Renamed dataGridViewInvoices to dgvHoaDon

                newRow.Cells["SoOrder"].Value = row["OrderID"];
                newRow.Cells["SoBan"].Value = row["TableID"];
                newRow.Cells["KhachHang"].Value = "Khách lẻ"; // Placeholder for customer name
                newRow.Cells["TongThanhToan"].Value = Convert.ToDecimal(row["FinalAmount"]).ToString("N0", new CultureInfo("vi-VN"));
                newRow.Cells["ThoiGianOrder"].Value = Convert.ToDateTime(row["OrderDate"]).ToString("dd/MM/yyyy HH:mm");
                newRow.Cells["TrangThai"].Value = row["Status"];
            }
        }

        private void FrmHoaDon_Load(object sender, EventArgs e) // Renamed FormDoanhThu_Load
        {
            LoadPendingOrderData();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e) // Renamed dataGridViewInvoices_CellContentClick
        {

        }

        private void labelMenuIcon_Click(object sender, EventArgs e)
        {

        }

        private void labelHomeIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
