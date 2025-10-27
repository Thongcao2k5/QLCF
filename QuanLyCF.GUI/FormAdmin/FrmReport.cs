using QuanLyCF.BUS;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmReport : Form
    {
        private Form previousForm;

        public FrmReport(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
            this.Load += FrmReport_Load;
            btnFilter.Click += btnFilter_Click;
            btnClearFilter.Click += btnClearFilter_Click;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            LoadAreas();
            LoadDrinkCategories();
            LoadStaff();
            LoadChartTypes();
            SetDefaultDates();
        }

        private void LoadDataAndBind()
        {
            DateTime fromDate = dtFrom.Value;
            DateTime toDate = dtTo.Value;
            int areaId = Convert.ToInt32(cmbArea.SelectedValue);
            int categoryId = Convert.ToInt32(cmbDrinkCate.SelectedValue);
            int staffId = Convert.ToInt32(cmdStaff.SelectedValue);

            DataTable reportData = ReportBUS.GetRevenueReport(fromDate, toDate, areaId, categoryId, staffId);
            dgvOrder.DataSource = reportData;

            UpdateCharts(reportData);
        }

        private void UpdateCharts(DataTable data)
        {
            chartRevenue.Series[0].Points.Clear();
            chartSumBill.Series[0].Points.Clear();

            if (data == null || data.Rows.Count == 0) return;

            string chartType = cmbTypeChar.SelectedItem.ToString();

            var filteredData = data.AsEnumerable();

            // Correctly calculate revenue by first getting distinct invoices
            var distinctInvoices = filteredData.GroupBy(r => r.Field<int>("InvoiceID"))
                                               .Select(g => g.First())
                                               .Select(r => new {
                                                   InvoiceID = r.Field<int>("InvoiceID"),
                                                   InvoiceDate = r.Field<DateTime>("InvoiceDate"),
                                                   FinalAmount = r.Field<decimal>("FinalAmount")
                                               });

            if (chartType == "Ngày")
            {
                var dailyRevenue = distinctInvoices
                    .GroupBy(i => i.InvoiceDate.Date)
                    .Select(g => new { Date = g.Key, Revenue = g.Sum(i => i.FinalAmount) })
                    .OrderBy(g => g.Date);

                var dailyBills = filteredData
                    .GroupBy(r => r.Field<DateTime>("InvoiceDate").Date)
                    .Select(g => new { Date = g.Key, BillCount = g.Select(r => r.Field<int>("InvoiceID")).Distinct().Count() })
                    .OrderBy(g => g.Date);

                foreach (var item in dailyRevenue)
                {
                    chartRevenue.Series[0].Points.AddXY(item.Date.ToString("dd/MM"), item.Revenue);
                }
                foreach (var item in dailyBills)
                {
                    chartSumBill.Series[0].Points.AddXY(item.Date.ToString("dd/MM"), item.BillCount);
                }
            }
            else if (chartType == "Tháng")
            {
                var monthlyRevenue = distinctInvoices
                    .GroupBy(i => new { Year = i.InvoiceDate.Year, Month = i.InvoiceDate.Month })
                    .Select(g => new { YearMonth = new DateTime(g.Key.Year, g.Key.Month, 1), Revenue = g.Sum(i => i.FinalAmount) })
                    .OrderBy(g => g.YearMonth);

                var monthlyBills = filteredData
                    .GroupBy(r => new { Year = r.Field<DateTime>("InvoiceDate").Year, Month = r.Field<DateTime>("InvoiceDate").Month })
                    .Select(g => new { YearMonth = new DateTime(g.Key.Year, g.Key.Month, 1), BillCount = g.Select(r => r.Field<int>("InvoiceID")).Distinct().Count() })
                    .OrderBy(g => g.YearMonth);

                foreach (var item in monthlyRevenue)
                {
                    chartRevenue.Series[0].Points.AddXY(item.YearMonth.ToString("MM/yyyy"), item.Revenue);
                }
                foreach (var item in monthlyBills)
                {
                    chartSumBill.Series[0].Points.AddXY(item.YearMonth.ToString("MM/yyyy"), item.BillCount);
                }
            }
            else if (chartType == "Năm")
            {
                var yearlyRevenue = distinctInvoices
                    .GroupBy(i => i.InvoiceDate.Year)
                    .Select(g => new { Year = g.Key, Revenue = g.Sum(i => i.FinalAmount) })
                    .OrderBy(g => g.Year);

                var yearlyBills = filteredData
                    .GroupBy(r => r.Field<DateTime>("InvoiceDate").Year)
                    .Select(g => new { Year = g.Key, BillCount = g.Select(r => r.Field<int>("InvoiceID")).Distinct().Count() })
                    .OrderBy(g => g.Year);

                foreach (var item in yearlyRevenue)
                {
                    chartRevenue.Series[0].Points.AddXY(item.Year.ToString(), item.Revenue);
                }
                foreach (var item in yearlyBills)
                {
                    chartSumBill.Series[0].Points.AddXY(item.Year.ToString(), item.BillCount);
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadDataAndBind();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbArea.SelectedValue = 0;
            cmbDrinkCate.SelectedValue = 0;
            cmdStaff.SelectedValue = 0;
            cmbTypeChar.SelectedIndex = 0;
            SetDefaultDates();
            dgvOrder.DataSource = null;
            chartRevenue.Series[0].Points.Clear();
            chartSumBill.Series[0].Points.Clear();
        }

        private void SetDefaultDates()
        {
            dtFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTo.Value = DateTime.Now;
        }

        private void LoadAreas()
        {
            var areas = AreaBUS.GetAllAreas();
            DataTable dt = new DataTable();
            dt.Columns.Add("AreaID", typeof(int));
            dt.Columns.Add("AreaName", typeof(string));

            DataRow dr = dt.NewRow();
            dr["AreaID"] = 0;
            dr["AreaName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);

            foreach (var area in areas)
            {
                dt.Rows.Add(area.AreaID, area.AreaName);
            }

            cmbArea.DataSource = dt;
            cmbArea.DisplayMember = "AreaName";
            cmbArea.ValueMember = "AreaID";
        }

        private void LoadDrinkCategories()
        {
            DataTable dt = DrinkCategoryBUS.GetAllCategories();
            DataRow dr = dt.NewRow();
            dr["CategoryID"] = 0;
            dr["CategoryName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cmbDrinkCate.DataSource = dt;
            cmbDrinkCate.DisplayMember = "CategoryName";
            cmbDrinkCate.ValueMember = "CategoryID";
        }

        private void LoadStaff()
        {
            DataTable dt = UserBUS.GetUsersByRole(0);
            DataRow dr = dt.NewRow();
            dr["UserID"] = 0;
            dr["DisplayName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cmdStaff.DataSource = dt;
            cmdStaff.DisplayMember = "DisplayName";
            cmdStaff.ValueMember = "UserID";
        }

        private void LoadChartTypes()
        {
            cmbTypeChar.Items.Add("Ngày");
            cmbTypeChar.Items.Add("Tháng");
            cmbTypeChar.Items.Add("Năm");
            cmbTypeChar.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm?.Show();
        }
    }
}