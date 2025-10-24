using System.Data;
using QuanLyCF.DAL;

namespace QuanLyCF.BUS
{
    public class PendingOrderDetailBUS
    {
        public static DataTable GetDetailsByOrderId(int pendingOrderId)
        {
            return PendingOrderDetailDAO.GetDetailsByOrderId(pendingOrderId);
        }

        public static bool AddDetail(int pendingOrderId, int drinkId, int quantity, decimal unitPrice)
        {
            return PendingOrderDetailDAO.AddDetail(pendingOrderId, drinkId, quantity, unitPrice);
        }

        public static bool DeleteDetailsByOrderId(int pendingOrderId)
        {
            return PendingOrderDetailDAO.DeleteDetailsByOrderId(pendingOrderId);
        }
    }
}
