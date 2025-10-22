using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class OrderDAO
    {
        public static int CreateOrder(int tableId, decimal totalAmount, decimal discountAmount, decimal finalAmount)
        {
            string query = "INSERT INTO PendingOrders (TableID, TotalAmount, DiscountAmount, FinalAmount, Status) VALUES (@TableID, @TotalAmount, @DiscountAmount, @FinalAmount, 'Pending'); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@TableID", SqlDbType.Int) { Value = tableId };
            parameters[1] = new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = totalAmount };
            parameters[2] = new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = discountAmount };
            parameters[3] = new SqlParameter("@FinalAmount", SqlDbType.Decimal) { Value = finalAmount };

            object result = DataProvider.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        public static void CreateOrderDetail(int orderId, int menuItemId, int quantity, decimal unitPrice)
        {
            string query = "INSERT INTO PendingOrderDetails (OrderID, MenuItemID, Quantity, UnitPrice) VALUES (@OrderID, @MenuItemID, @Quantity, @UnitPrice);";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            parameters[1] = new SqlParameter("@MenuItemID", SqlDbType.Int) { Value = menuItemId };
            parameters[2] = new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity };
            parameters[3] = new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = unitPrice };

            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static int GetMenuItemID(string itemName)
        {
            string query = "SELECT MenuItemID FROM MenuItems WHERE ItemName = @ItemName;";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ItemName", SqlDbType.NVarChar) { Value = itemName };

            object result = DataProvider.ExecuteScalar(query, parameters);
            if (result != null)
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

        public static DataTable GetAllMenuItems()
        {
            string query = "SELECT MenuItemID, ItemName, Category, Price, ImagePath, IsActive FROM MenuItems WHERE IsActive = 1 AND ItemName NOT IN (N'trà đào cam xả', N'bánh mì pháp', N'cà phê sữa');";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataRow GetActiveOrderByTableId(int tableId)
        {
            string query = "SELECT OrderID, TotalAmount, DiscountAmount, FinalAmount FROM PendingOrders WHERE TableID = @TableID AND Status = 'Pending';";
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
            string query = "SELECT od.MenuItemID, mi.ItemName, od.Quantity, od.UnitPrice FROM PendingOrderDetails od JOIN MenuItems mi ON od.MenuItemID = mi.MenuItemID WHERE od.OrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            return DataProvider.ExecuteQuery(query, parameters);
        }

        public static void ProcessPayment(int orderId, string paymentMethod)
        {
            // Get order details from PendingOrders
            string getPendingOrderQuery = "SELECT TableID, OrderDate, TotalAmount, DiscountAmount, FinalAmount FROM PendingOrders WHERE OrderID = @OrderID;";
            SqlParameter[] getPendingOrderParams = new SqlParameter[1];
            getPendingOrderParams[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            DataTable pendingOrder = DataProvider.ExecuteQuery(getPendingOrderQuery, getPendingOrderParams);

            if (pendingOrder.Rows.Count > 0)
            {
                DataRow orderRow = pendingOrder.Rows[0];
                int tableId = Convert.ToInt32(orderRow["TableID"]);
                DateTime orderDate = Convert.ToDateTime(orderRow["OrderDate"]);
                decimal totalAmount = Convert.ToDecimal(orderRow["TotalAmount"]);
                decimal discountAmount = Convert.ToDecimal(orderRow["DiscountAmount"]);
                decimal finalAmount = Convert.ToDecimal(orderRow["FinalAmount"]);

                // Insert into Invoices
                string insertInvoiceQuery = "INSERT INTO Invoices (TableID, OrderDate, PaymentDate, TotalAmount, DiscountAmount, FinalAmount, PaymentMethod, Status) VALUES (@TableID, @OrderDate, GETDATE(), @TotalAmount, @DiscountAmount, @FinalAmount, @PaymentMethod, 'Paid'); SELECT SCOPE_IDENTITY();";
                SqlParameter[] insertInvoiceParams = new SqlParameter[6];
                insertInvoiceParams[0] = new SqlParameter("@TableID", SqlDbType.Int) { Value = tableId };
                insertInvoiceParams[1] = new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = orderDate };
                insertInvoiceParams[2] = new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = totalAmount };
                insertInvoiceParams[3] = new SqlParameter("@DiscountAmount", SqlDbType.Decimal) { Value = discountAmount };
                insertInvoiceParams[4] = new SqlParameter("@FinalAmount", SqlDbType.Decimal) { Value = finalAmount };
                insertInvoiceParams[5] = new SqlParameter("@PaymentMethod", SqlDbType.NVarChar) { Value = paymentMethod };
                int invoiceId = Convert.ToInt32(DataProvider.ExecuteScalar(insertInvoiceQuery, insertInvoiceParams));

                // Get order details from PendingOrderDetails
                string getPendingOrderDetailsQuery = "SELECT MenuItemID, Quantity, UnitPrice FROM PendingOrderDetails WHERE OrderID = @OrderID;";
                SqlParameter[] getPendingOrderDetailsParams = new SqlParameter[1];
                getPendingOrderDetailsParams[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
                DataTable pendingOrderDetails = DataProvider.ExecuteQuery(getPendingOrderDetailsQuery, getPendingOrderDetailsParams);

                // Insert into InvoiceDetails
                foreach (DataRow detailRow in pendingOrderDetails.Rows)
                {
                    string insertInvoiceDetailQuery = "INSERT INTO InvoiceDetails (InvoiceID, MenuItemID, Quantity, UnitPrice) VALUES (@InvoiceID, @MenuItemID, @Quantity, @UnitPrice);";
                    SqlParameter[] insertInvoiceDetailParams = new SqlParameter[4];
                    insertInvoiceDetailParams[0] = new SqlParameter("@InvoiceID", SqlDbType.Int) { Value = invoiceId };
                    insertInvoiceDetailParams[1] = new SqlParameter("@MenuItemID", SqlDbType.Int) { Value = Convert.ToInt32(detailRow["MenuItemID"]) };
                    insertInvoiceDetailParams[2] = new SqlParameter("@Quantity", SqlDbType.Int) { Value = Convert.ToInt32(detailRow["Quantity"]) };
                    insertInvoiceDetailParams[3] = new SqlParameter("@UnitPrice", SqlDbType.Decimal) { Value = Convert.ToDecimal(detailRow["UnitPrice"]) };
                    DataProvider.ExecuteNonQuery(insertInvoiceDetailQuery, insertInvoiceDetailParams);
                }

                // Delete from PendingOrderDetails
                string deletePendingOrderDetailsQuery = "DELETE FROM PendingOrderDetails WHERE OrderID = @OrderID;";
                SqlParameter[] deletePendingOrderDetailsParams = new SqlParameter[1];
                deletePendingOrderDetailsParams[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
                DataProvider.ExecuteNonQuery(deletePendingOrderDetailsQuery, deletePendingOrderDetailsParams);

                // Delete from PendingOrders
                string deletePendingOrderQuery = "DELETE FROM PendingOrders WHERE OrderID = @OrderID;";
                SqlParameter[] deletePendingOrderParams = new SqlParameter[1];
                deletePendingOrderParams[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
                DataProvider.ExecuteNonQuery(deletePendingOrderQuery, deletePendingOrderParams);
            }
        }

        public static DataTable GetAllInvoices()
        {
            string query = "SELECT InvoiceID, OrderDate, PaymentDate, TableID, TotalAmount, DiscountAmount, FinalAmount, PaymentMethod, Status FROM Invoices ORDER BY PaymentDate DESC;";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataTable GetAllPendingOrders()
        {
            string query = "SELECT OrderID, TableID, OrderDate, TotalAmount, DiscountAmount, FinalAmount, Status FROM PendingOrders ORDER BY OrderDate DESC;";
            return DataProvider.ExecuteQuery(query);
        }

        public static void DeletePendingOrderDetails(int orderId)
        {
            string query = "DELETE FROM PendingOrderDetails WHERE OrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void UpdatePendingOrder(int orderId, decimal totalAmount, decimal discountAmount, decimal finalAmount)
        {
            string query = "UPDATE PendingOrders SET TotalAmount = @TotalAmount, DiscountAmount = @DiscountAmount, FinalAmount = @FinalAmount WHERE OrderID = @OrderID;";
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
            string query = "UPDATE PendingOrders SET TableID = @NewTableID WHERE OrderID = @OrderID;";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@NewTableID", SqlDbType.Int) { Value = newTableId };
            parameters[1] = new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderId };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void MergeOrders(int sourceOrderId, int destOrderId)
        {
            // 1. Get destination order details to update its total amount later
            string getDestOrderQuery = "SELECT TotalAmount, DiscountAmount FROM PendingOrders WHERE OrderID = @OrderID;";
            SqlParameter[] destParams = { new SqlParameter("@OrderID", destOrderId) };
            DataTable destOrderDt = DataProvider.ExecuteQuery(getDestOrderQuery, destParams);
            decimal destTotal = Convert.ToDecimal(destOrderDt.Rows[0]["TotalAmount"]);
            decimal destDiscount = Convert.ToDecimal(destOrderDt.Rows[0]["DiscountAmount"]);

            // 2. Get source order details
            string getSourceOrderQuery = "SELECT TotalAmount, DiscountAmount FROM PendingOrders WHERE OrderID = @OrderID;";
            SqlParameter[] sourceParams = { new SqlParameter("@OrderID", sourceOrderId) };
            DataTable sourceOrderDt = DataProvider.ExecuteQuery(getSourceOrderQuery, sourceParams);
            decimal sourceTotal = Convert.ToDecimal(sourceOrderDt.Rows[0]["TotalAmount"]);
            decimal sourceDiscount = Convert.ToDecimal(sourceOrderDt.Rows[0]["DiscountAmount"]);

            // 3. Update destination order's amounts
            decimal newTotal = destTotal + sourceTotal;
            decimal newDiscount = destDiscount + sourceDiscount; // Or some other logic for discount
            decimal newFinalAmount = newTotal - newDiscount;
            UpdatePendingOrder(destOrderId, newTotal, newDiscount, newFinalAmount);

            // 4. Move order details from source to destination
            string updateDetailsQuery = "UPDATE PendingOrderDetails SET OrderID = @DestOrderID WHERE OrderID = @SourceOrderID;";
            SqlParameter[] updateParams = new SqlParameter[2];
            updateParams[0] = new SqlParameter("@DestOrderID", SqlDbType.Int) { Value = destOrderId };
            updateParams[1] = new SqlParameter("@SourceOrderID", SqlDbType.Int) { Value = sourceOrderId };
            DataProvider.ExecuteNonQuery(updateDetailsQuery, updateParams);

            // 5. Delete the source order
            string deleteSourceQuery = "DELETE FROM PendingOrders WHERE OrderID = @SourceOrderID;";
            SqlParameter[] deleteParams = { new SqlParameter("@SourceOrderID", sourceOrderId) };
            DataProvider.ExecuteNonQuery(deleteSourceQuery, deleteParams);
        }
    }
}