using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class PendingOrderDetailDAO
    {
        // === 1️⃣ Lấy danh sách món theo PendingOrderID ===
        public static DataTable GetDetailsByOrderId(int pendingOrderId)
        {
            string query = @"
                SELECT pod.PendingDetailID, pod.DrinkID, d.DrinkName, pod.Quantity, pod.UnitPrice, pod.Total
                FROM PendingOrderDetails pod
                JOIN Drinks d ON pod.DrinkID = d.DrinkID
                WHERE pod.PendingOrderID = @id";
            SqlParameter[] param = { new SqlParameter("@id", pendingOrderId) };
            return DataProvider.ExecuteQuery(query, param);
        }

        // === 2️⃣ Thêm chi tiết món mới ===
        public static bool AddDetail(int pendingOrderId, int drinkId, int quantity, decimal unitPrice)
        {
            string query = @"
                INSERT INTO PendingOrderDetails (PendingOrderID, DrinkID, Quantity, UnitPrice)
                VALUES (@orderId, @drinkId, @qty, @price)";
            SqlParameter[] param =
            {
                new SqlParameter("@orderId", pendingOrderId),
                new SqlParameter("@drinkId", drinkId),
                new SqlParameter("@qty", quantity),
                new SqlParameter("@price", unitPrice)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 3️⃣ Xóa chi tiết món khi cập nhật lại Order ===
        public static bool DeleteDetailsByOrderId(int pendingOrderId)
        {
            string query = "DELETE FROM PendingOrderDetails WHERE PendingOrderID = @id";
            SqlParameter[] param = { new SqlParameter("@id", pendingOrderId) };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
    }
}
