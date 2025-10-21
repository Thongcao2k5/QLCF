using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCF.DAL;

namespace QuanLyCF.GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OrderDAO.ClearPendingOrders(); // Clear pending orders at startup
            Application.Run(new FormDangNhap());
        }
    }
}
