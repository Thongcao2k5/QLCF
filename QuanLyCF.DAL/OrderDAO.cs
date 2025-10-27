using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    
        public class OrderDAO
        {
            public static void ProcessPayment(int pendingOrderId)
    
        {
            using (SqlConnection conn = DataProvider.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Get Pending Order data
                        string getPendingQuery = "SELECT * FROM PendingOrders WHERE PendingOrderID = @PendingOrderID";
                        SqlCommand getPendingCmd = new SqlCommand(getPendingQuery, conn, transaction);
                        getPendingCmd.Parameters.AddWithValue("@PendingOrderID", pendingOrderId);
                        DataTable pendingOrderDt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(getPendingCmd))
                        {
                            adapter.Fill(pendingOrderDt);
                        }

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
                        SqlCommand createOrderCmd = new SqlCommand(createOrderQuery, conn, transaction);
                        createOrderCmd.Parameters.AddWithValue("@TableID", tableId);
                        createOrderCmd.Parameters.AddWithValue("@UserID", (object)userId ?? DBNull.Value);
                        createOrderCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        int newOrderId = Convert.ToInt32(createOrderCmd.ExecuteScalar());

                        // 3. Move details from PendingOrderDetails to OrderDetails
                        string getPendingDetailsQuery = "SELECT * FROM PendingOrderDetails WHERE PendingOrderID = @PendingOrderID";
                        SqlCommand getPendingDetailsCmd = new SqlCommand(getPendingDetailsQuery, conn, transaction);
                        getPendingDetailsCmd.Parameters.AddWithValue("@PendingOrderID", pendingOrderId);
                        DataTable pendingDetailsDt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(getPendingDetailsCmd))
                        {
                            adapter.Fill(pendingDetailsDt);
                        }

                        foreach (DataRow detailRow in pendingDetailsDt.Rows)
                        {
                            string createDetailQuery = @"
                                INSERT INTO OrderDetails (OrderID, DrinkID, Quantity, UnitPrice)
                                VALUES (@OrderID, @DrinkID, @Quantity, @UnitPrice)";
                            SqlCommand createDetailCmd = new SqlCommand(createDetailQuery, conn, transaction);
                            createDetailCmd.Parameters.AddWithValue("@OrderID", newOrderId);
                            createDetailCmd.Parameters.AddWithValue("@DrinkID", detailRow["DrinkID"]);
                            createDetailCmd.Parameters.AddWithValue("@Quantity", detailRow["Quantity"]);
                            createDetailCmd.Parameters.AddWithValue("@UnitPrice", detailRow["UnitPrice"]);
                            createDetailCmd.ExecuteNonQuery();
                        }

                        // 4. Create an Invoice
                        string createInvoiceQuery = @"
                            INSERT INTO Invoices (OrderID, InvoiceDate, TotalAmount, Discount)
                            VALUES (@OrderID, GETDATE(), @TotalAmount, @Discount)";
                        SqlCommand createInvoiceCmd = new SqlCommand(createInvoiceQuery, conn, transaction);
                        createInvoiceCmd.Parameters.AddWithValue("@OrderID", newOrderId);
                        createInvoiceCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        createInvoiceCmd.Parameters.AddWithValue("@Discount", discount);
                        createInvoiceCmd.ExecuteNonQuery();

                        // 5. Delete the Pending Order and its details
                        string deleteDetailsQuery = "DELETE FROM PendingOrderDetails WHERE PendingOrderID = @PendingOrderID";
                        SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, conn, transaction);
                        deleteDetailsCmd.Parameters.AddWithValue("@PendingOrderID", pendingOrderId);
                        deleteDetailsCmd.ExecuteNonQuery();

                        string deleteHeaderQuery = "DELETE FROM PendingOrders WHERE PendingOrderID = @PendingOrderID";
                        SqlCommand deleteHeaderCmd = new SqlCommand(deleteHeaderQuery, conn, transaction);
                        deleteHeaderCmd.Parameters.AddWithValue("@PendingOrderID", pendingOrderId);
                        deleteHeaderCmd.ExecuteNonQuery();

                        // 6. Update table status (can be part of the transaction)
                        TableDAO.UpdateTableStatus(tableId, false, conn, transaction);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-throw the exception to notify the caller
                    }
                }
            }
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