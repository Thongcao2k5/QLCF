using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Clear any pending data from previous sessions
            //QuanLyCF.BUS.PendingOrderBUS.ClearPendingOrders(); 
            //QuanLyCF.BUS.TableBUS.ResetAllTableStatus();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Thiết lập icon mặc định cho toàn bộ Form
            Icon appIcon = new Icon(Application.StartupPath + @"\..\..\..\QuanLyCF.DAL\Image\System\coffee-cup.ico");
            typeof(Form).InvokeMember("defaultIcon",
                System.Reflection.BindingFlags.SetField |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static,
                null, null, new object[] { appIcon });

            Application.Run(new FormDangNhap());
        }
    }
}
