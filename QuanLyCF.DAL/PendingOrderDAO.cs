using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class PendingOrderDAO
    {
        // === 1️⃣ Lấy order tạm đang mở theo bàn ===
        public static DataRow GetPendingOrderByTableId(int tableId)
        {
            string query = "SELECT TOP 1 * FROM PendingOrders WHERE TableID = @TableID AND Status = N'Pending'";
            SqlParameter param = new SqlParameter("@TableID", tableId);
            DataTable dt = DataProvider.ExecuteQuery(query, param);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // === 2️⃣ Lấy order tạm theo ID ===
        public static DataRow GetPendingOrderById(int pendingOrderId)
        {
            string query = "SELECT * FROM PendingOrders WHERE PendingOrderID = @id";
            SqlParameter param = new SqlParameter("@id", pendingOrderId);
            DataTable dt = DataProvider.ExecuteQuery(query, param);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // === 3️⃣ Tạo order tạm mới ===
        public static int CreatePendingOrder(int tableId, decimal totalAmount, decimal discount, decimal finalAmount)
        {
            string query = @"
                INSERT INTO PendingOrders (TableID, UserID, OrderDate, TotalAmount, Discount, FinalAmount, Status)
                OUTPUT INSERTED.PendingOrderID
                VALUES (@tableId, 1, GETDATE(), @total, @discount, @final, N'Pending')";
            SqlParameter[] param =
            {
                new SqlParameter("@tableId", tableId),
                new SqlParameter("@total", totalAmount),
                new SqlParameter("@discount", discount),
                new SqlParameter("@final", finalAmount)
            };

            object result = DataProvider.ExecuteScalar(query, param);
            return Convert.ToInt32(result);
        }

        // === 4️⃣ Cập nhật tổng tiền, giảm giá, tổng cuối ===
        public static bool UpdatePendingOrder(int id, decimal total, decimal discount, decimal final)
        {
            string query = @"UPDATE PendingOrders
                             SET TotalAmount = @total, Discount = @discount, FinalAmount = @final
                             WHERE PendingOrderID = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@total", total),
                new SqlParameter("@discount", discount),
                new SqlParameter("@final", final),
                new SqlParameter("@id", id)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 5️⃣ Chuyển order tạm sang trạng thái "Completed" ===
        public static bool CompletePendingOrder(int pendingOrderId)
        {
            string query = "UPDATE PendingOrders SET Status = N'Completed' WHERE PendingOrderID = @id";
            SqlParameter param = new SqlParameter("@id", pendingOrderId);
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }
    }
}
