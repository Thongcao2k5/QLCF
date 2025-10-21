using System;
using System.Windows.Forms;
using QuanLyCF.DAL;
using System.Data;

namespace QuanLyCF.GUI
{
    public partial class FrmHoaDon : Form
    {
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            // Assuming OrderDAO has a method to get all orders
            // You might need to create this method in OrderDAO
            DataTable dt = OrderDAO.GetAllOrders();
            dgvHoaDon.DataSource = dt;
        }
    }
}
