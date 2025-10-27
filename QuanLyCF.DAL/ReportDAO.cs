
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class ReportDAO
    {
        public static DataTable GetRevenueReport(DateTime fromDate, DateTime toDate, int areaId, int categoryId, int staffId)
        {
            string query = @"
                SELECT 
                    i.InvoiceID, 
                    i.InvoiceDate, 
                    a.AreaName, 
                    t.TableName, 
                    u.DisplayName AS StaffName, 
                    d.DrinkName, 
                    dc.CategoryName, 
                    od.Quantity, 
                    od.UnitPrice, 
                    od.Total, 
                    i.TotalAmount AS InvoiceTotal, 
                    i.Discount, 
                    i.FinalAmount
                FROM Invoices i
                JOIN Orders o ON i.OrderID = o.OrderID
                JOIN Users u ON o.UserID = u.UserID
                LEFT JOIN Tables t ON o.TableID = t.TableID
                LEFT JOIN Areas a ON t.AreaID = a.AreaID
                JOIN OrderDetails od ON o.OrderID = od.OrderID
                JOIN Drinks d ON od.DrinkID = d.DrinkID
                JOIN DrinkCategories dc ON d.CategoryID = dc.CategoryID
                WHERE i.InvoiceDate BETWEEN @fromDate AND @toDate
            ";

            if (areaId > 0)
            {
                query += " AND a.AreaID = @areaId";
            }
            if (categoryId > 0)
            {
                query += " AND dc.CategoryID = @categoryId";
            }
            if (staffId > 0)
            {
                query += " AND u.UserID = @staffId";
            }

            query += " ORDER BY i.InvoiceDate DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate),
                new SqlParameter("@areaId", areaId),
                new SqlParameter("@categoryId", categoryId),
                new SqlParameter("@staffId", staffId)
            };

            return DataProvider.ExecuteQuery(query, parameters);
        }
    }
}
