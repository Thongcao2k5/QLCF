using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class OrderDAO
    {
        public static int CreateOrder(int tableId, decimal totalAmount, decimal discount, decimal finalAmount)
        {
            string query = "INSERT INTO PendingOrders (TableID, TotalAmount, Discount, FinalAmount, Status) VALUES (@TableID, @TotalAmount, @Discount, @FinalAmount, 'Pending'); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@TableID", SqlDbType.Int) { Value = tableId };
            parameters[1] = new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = totalAmount };
            parameters[2] = new SqlParameter("@Discount", SqlDbType.Decimal) { Value = discount };
            parameters[3] = new SqlParameter("@FinalAmount", SqlDbType.Decimal) { Value = finalAmount };

            object result = DataProvider.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        public static void CreateOrderDetail(int orderId, int drinkId, int quantity, decimal unitPrice)
        {
            string query = "INSERT INTO PendingOrderDetails (PendingOrderID, DrinkID, Quantity, UnitPrice) VALUES (@OrderID, @DrinkID, @Quantity, @UnitPrice);";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            parameters[1] = new SqlParameter("@DrinkID", SqlDbType.Int) { Value = drinkId };
            parameters[2] = new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity };
            parameters[3] = new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = unitPrice };

            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static int GetDrinkID(string drinkName)
        {
            string query = "SELECT DrinkID FROM Drinks WHERE DrinkName = @DrinkName;";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@DrinkName", SqlDbType.NVarChar) { Value = drinkName };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return -1; // Or throw an exception if item not found
        }

        public static DataTable GetAllOrders()
        {
            string query = "SELECT OrderID, OrderDate, TableID, TotalAmount, DiscountAmount, FinalAmount, Status, PaymentMethod, PaymentDate FROM Orders;";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataTable GetAllDrinks()
        {
            string query = "SELECT DrinkID, DrinkName, CategoryID, Price, ImagePath, IsAvailable FROM Drinks WHERE IsAvailable = 1 AND DrinkName NOT IN (N'trà đào cam xả', N'bánh mì pháp', N'cà phê sữa');";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataRow GetActiveOrderByTableId(int tableId)
        {
            string query = "SELECT PendingOrderID as OrderID, TotalAmount, Discount, FinalAmount FROM PendingOrders WHERE TableID = @TableID AND Status = 'Pending';";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TableID", SqlDbType.Int) { Value = tableId };
            DataTable dt = DataProvider.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public static DataTable GetOrderDetailsByOrderId(int orderId)
        {
            string query = "SELECT od.DrinkID, mi.DrinkName, od.Quantity, od.UnitPrice FROM PendingOrderDetails od JOIN Drinks mi ON od.DrinkID = mi.DrinkID WHERE od.PendingOrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            return DataProvider.ExecuteQuery(query, parameters);
        }

        public static void ProcessPayment(int pendingOrderId)
        {
            // 1. Get Pending Order data
            string getPendingQuery = "SELECT * FROM PendingOrders WHERE PendingOrderID = @PendingOrderID";
            DataTable pendingOrderDt = DataProvider.ExecuteQuery(getPendingQuery, new[] { new SqlParameter("@PendingOrderID", pendingOrderId) });

            if (pendingOrderDt.Rows.Count == 0) return; // No pending order found

            DataRow pendingOrderRow = pendingOrderDt.Rows[0];
            int tableId = Convert.ToInt32(pendingOrderRow["TableID"]);
            object userIdObj = pendingOrderRow["UserID"];
            int? userId = userIdObj == DBNull.Value ? (int?)null : Convert.ToInt32(userIdObj);
            decimal totalAmount = Convert.ToDecimal(pendingOrderRow["TotalAmount"]);
            decimal discount = Convert.ToDecimal(pendingOrderRow["Discount"]);

            // 2. Create a final Order
            string createOrderQuery = @"
                INSERT INTO Orders (TableID, UserID, OrderDate, Status, TotalAmount)
                OUTPUT INSERTED.OrderID
                VALUES (@TableID, @UserID, GETDATE(), 'Completed', @TotalAmount)";
    
            SqlParameter[] orderParams = {
                new SqlParameter("@TableID", tableId),
                new SqlParameter("@UserID", (object)userId ?? DBNull.Value),
                new SqlParameter("@TotalAmount", totalAmount)
            };
            int newOrderId = Convert.ToInt32(DataProvider.ExecuteScalar(createOrderQuery, orderParams));

            // 3. Move details from PendingOrderDetails to OrderDetails
            string getPendingDetailsQuery = "SELECT * FROM PendingOrderDetails WHERE PendingOrderID = @PendingOrderID";
            DataTable pendingDetailsDt = DataProvider.ExecuteQuery(getPendingDetailsQuery, new[] { new SqlParameter("@PendingOrderID", pendingOrderId) });

            foreach (DataRow detailRow in pendingDetailsDt.Rows)
            {
                string createDetailQuery = @"
                    INSERT INTO OrderDetails (OrderID, DrinkID, Quantity, UnitPrice)
                    VALUES (@OrderID, @DrinkID, @Quantity, @UnitPrice)";
        
                SqlParameter[] detailParams = {
                    new SqlParameter("@OrderID", newOrderId),
                    new SqlParameter("@DrinkID", detailRow["DrinkID"]),
                    new SqlParameter("@Quantity", detailRow["Quantity"]),
                    new SqlParameter("@UnitPrice", detailRow["UnitPrice"])
                };
                DataProvider.ExecuteNonQuery(createDetailQuery, detailParams);
            }

            // 4. Create an Invoice
            string createInvoiceQuery = @"
                INSERT INTO Invoices (OrderID, InvoiceDate, TotalAmount, Discount)
                VALUES (@OrderID, GETDATE(), @TotalAmount, @Discount)";
    
            SqlParameter[] invoiceParams = {
                new SqlParameter("@OrderID", newOrderId),
                new SqlParameter("@TotalAmount", totalAmount),
                new SqlParameter("@Discount", discount),
            };
            DataProvider.ExecuteNonQuery(createInvoiceQuery, invoiceParams);

            // 5. Delete the Pending Order and its details
            string deleteDetailsQuery = "DELETE FROM PendingOrderDetails WHERE PendingOrderID = @PendingOrderID";
            DataProvider.ExecuteNonQuery(deleteDetailsQuery, new[] { new SqlParameter("@PendingOrderID", pendingOrderId) });

            string deleteHeaderQuery = "DELETE FROM PendingOrders WHERE PendingOrderID = @PendingOrderID";
            DataProvider.ExecuteNonQuery(deleteHeaderQuery, new[] { new SqlParameter("@PendingOrderID", pendingOrderId) });

            // 6. Update table status
            TableDAO.UpdateTableStatus(tableId, false);
        }

        public static DataTable GetAllInvoices()
        {
            string query = "SELECT InvoiceID, OrderDate, PaymentDate, TableID, TotalAmount, DiscountAmount, FinalAmount, PaymentMethod, Status FROM Invoices ORDER BY PaymentDate DESC;";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataTable GetAllPendingOrders()
        {
            string query = "SELECT PendingOrderID as OrderID, TableID, OrderDate, TotalAmount, Discount, FinalAmount, Status FROM PendingOrders ORDER BY OrderDate DESC;";
            return DataProvider.ExecuteQuery(query);
        }

        public static void DeletePendingOrderDetails(int orderId)
        {
            string query = "DELETE FROM PendingOrderDetails WHERE PendingOrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void UpdatePendingOrder(int orderId, decimal totalAmount, decimal discountAmount, decimal finalAmount)
        {
            string query = "UPDATE PendingOrders SET TotalAmount = @TotalAmount, Discount = @DiscountAmount, FinalAmount = @FinalAmount WHERE PendingOrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = totalAmount };
            parameters[1] = new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = discountAmount };
            parameters[2] = new SqlParameter("@FinalAmount", SqlDbType.Decimal) { Value = finalAmount };
            parameters[3] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void ClearPendingOrders()
        {
            // Clear details first due to foreign key constraints
            string clearDetailsQuery = "DELETE FROM PendingOrderDetails;";
            DataProvider.ExecuteNonQuery(clearDetailsQuery);

            // Then clear main orders
            string clearOrdersQuery = "DELETE FROM PendingOrders;";
            DataProvider.ExecuteNonQuery(clearOrdersQuery);
        }

        public static void UpdateOrderTable(int orderId, int newTableId)
        {
            string query = "UPDATE PendingOrders SET TableID = @NewTableID WHERE PendingOrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@NewTableID", SqlDbType.Int) { Value = newTableId };
            parameters[1] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void MergeOrders(int sourceOrderId, int destOrderId)
        {
            // 1. Get destination order details to update its total amount later
            string getDestOrderQuery = "SELECT TotalAmount, Discount FROM PendingOrders WHERE PendingOrderID = @OrderID;";
            SqlParameter[] destParams = { new SqlParameter("@OrderID", destOrderId) };
            DataTable destOrderDt = DataProvider.ExecuteQuery(getDestOrderQuery, destParams);
            decimal destTotal = Convert.ToDecimal(destOrderDt.Rows[0]["TotalAmount"]);
            decimal destDiscount = Convert.ToDecimal(destOrderDt.Rows[0]["Discount"]);

            // 2. Get source order details
            string getSourceOrderQuery = "SELECT TotalAmount, Discount FROM PendingOrders WHERE PendingOrderID = @OrderID;";
            SqlParameter[] sourceParams = { new SqlParameter("@OrderID", sourceOrderId) };
            DataTable sourceOrderDt = DataProvider.ExecuteQuery(getSourceOrderQuery, sourceParams);
            decimal sourceTotal = Convert.ToDecimal(sourceOrderDt.Rows[0]["TotalAmount"]);
            decimal sourceDiscount = Convert.ToDecimal(sourceOrderDt.Rows[0]["Discount"]);

            // 3. Update destination order's amounts
            decimal newTotal = destTotal + sourceTotal;
            decimal newDiscount = destDiscount + sourceDiscount; // Or some other logic for discount
            decimal newFinalAmount = newTotal - newDiscount;
            UpdatePendingOrder(destOrderId, newTotal, newDiscount, newFinalAmount);

            // 4. Move order details from source to destination
            string updateDetailsQuery = "UPDATE PendingOrderDetails SET PendingOrderID = @DestOrderID WHERE PendingOrderID = @SourceOrderID;";
            SqlParameter[] updateParams = new SqlParameter[2];
            updateParams[0] = new SqlParameter("@DestOrderID", SqlDbType.Int) { Value = destOrderId };
            updateParams[1] = new SqlParameter("@SourceOrderID", SqlDbType.Int) { Value = sourceOrderId };
            DataProvider.ExecuteNonQuery(updateDetailsQuery, updateParams);

            // 5. Delete the source order
            string deleteSourceQuery = "DELETE FROM PendingOrders WHERE PendingOrderID = @SourceOrderID;";
            SqlParameter[] deleteParams = { new SqlParameter("@SourceOrderID", sourceOrderId) };
            DataProvider.ExecuteNonQuery(deleteSourceQuery, deleteParams);
        }
    }
}