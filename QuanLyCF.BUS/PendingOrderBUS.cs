using System.Data;
using QuanLyCF.DAL;

namespace QuanLyCF.BUS
{
    public class PendingOrderBUS
    {
        public static DataRow GetPendingOrderByTableId(int tableId)
        {
            return PendingOrderDAO.GetPendingOrderByTableId(tableId);
        }

        public static DataRow GetPendingOrderById(int pendingOrderId)
        {
            return PendingOrderDAO.GetPendingOrderById(pendingOrderId);
        }

        public static int CreatePendingOrder(int tableId, decimal total, decimal discount, decimal final)
        {
            return PendingOrderDAO.CreatePendingOrder(tableId, total, discount, final);
        }

        public static bool UpdatePendingOrder(int id, decimal total, decimal discount, decimal final)
        {
            return PendingOrderDAO.UpdatePendingOrder(id, total, discount, final);
        }

        public static void ProcessPayment(int pendingOrderId, int tableId)
        {
            // Move pending order to a final order and invoice
            OrderDAO.ProcessPayment(pendingOrderId);

            // Update table status to not occupied
            TableBUS.UpdateTableStatus(tableId, false);
        }

        public static void ClearPendingOrders()
        {
            OrderDAO.ClearPendingOrders();
        }

        //public static bool CompletePendingOrder(int pendingOrderId)
        //{
        //    return PendingOrderDAO.CompletePendingOrder(pendingOrderId);
        //}
    }
}
