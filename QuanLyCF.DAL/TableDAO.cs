using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class TableDAO
    {
        public int TableID { get; set; }
        public string TableCode { get; set; }
        public string TableName { get; set; }
        public int AreaID { get; set; }
        public int MaxGuests { get; set; }
        public bool IsOccupied { get; set; }

        public TableDAO() { }

        public TableDAO(int id, string code, string name, int areaId, int maxGuests, bool isOccupied)
        {
            this.TableID = id;
            this.TableCode = code;
            this.TableName = name;
            this.AreaID = areaId;
            this.MaxGuests = maxGuests;
            this.IsOccupied = isOccupied;
        }

        // === 1️⃣ Lấy danh sách bàn theo khu vực ===
        public static List<TableDAO> GetTablesByArea(int areaId)
        {
            string query = "SELECT * FROM Tables WHERE AreaID = @AreaID";
            SqlParameter[] param = { new SqlParameter("@AreaID", SqlDbType.Int) { Value = areaId } };

            DataTable dt = DataProvider.ExecuteQuery(query, param);
            List<TableDAO> tables = new List<TableDAO>();

            foreach (DataRow row in dt.Rows)
            {
                tables.Add(new TableDAO(
                    Convert.ToInt32(row["TableID"]),
                    row["TableCode"].ToString(),
                    row["TableName"].ToString(),
                    Convert.ToInt32(row["AreaID"]),
                    Convert.ToInt32(row["MaxGuests"]),
                    Convert.ToBoolean(row["IsOccupied"])
                ));
            }

            return tables;
        }

        // === 2️⃣ Lấy thông tin 1 bàn theo ID ===
        public static TableDAO GetTableById(int tableId)
        {
            string query = "SELECT * FROM Tables WHERE TableID = @id";
            SqlParameter[] param = { new SqlParameter("@id", tableId) };

            DataTable dt = DataProvider.ExecuteQuery(query, param);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TableDAO(
                    Convert.ToInt32(row["TableID"]),
                    row["TableCode"].ToString(),
                    row["TableName"].ToString(),
                    Convert.ToInt32(row["AreaID"]),
                    Convert.ToInt32(row["MaxGuests"]),
                    Convert.ToBoolean(row["IsOccupied"])
                );
            }
            return null;
        }

        // === 3️⃣ Cập nhật trạng thái bàn (IsOccupied) ===
        public static bool UpdateTableStatus(int tableId, bool isOccupied)
        {
            string query = "UPDATE Tables SET IsOccupied = @status WHERE TableID = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@status", isOccupied),
                new SqlParameter("@id", tableId)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 4️⃣ Cập nhật thông tin bàn ===
        public static bool UpdateTableInfo(TableDAO table)
        {
            string query = @"
                UPDATE Tables
                SET TableCode = @code, TableName = @name, AreaID = @areaId,
                    MaxGuests = @maxGuests, IsOccupied = @isOccupied
                WHERE TableID = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@code", table.TableCode),
                new SqlParameter("@name", table.TableName),
                new SqlParameter("@areaId", table.AreaID),
                new SqlParameter("@maxGuests", table.MaxGuests),
                new SqlParameter("@isOccupied", table.IsOccupied),
                new SqlParameter("@id", table.TableID)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 5️⃣ Thêm bàn mới ===
        public static bool InsertTable(string code, string name, int areaId, int maxGuests, bool isOccupied)
        {
            string query = "INSERT INTO Tables (TableCode, TableName, AreaID, MaxGuests, IsOccupied) " +
                           "VALUES (@code, @name, @areaId, @maxGuests, @isOccupied)";
            SqlParameter[] param =
            {
                new SqlParameter("@code", code),
                new SqlParameter("@name", name),
                new SqlParameter("@areaId", areaId),
                new SqlParameter("@maxGuests", maxGuests),
                new SqlParameter("@isOccupied", isOccupied)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        public static bool InsertTable(int areaId, string tableName, int maxGuests)
        {
            string query = "INSERT INTO Tables (AreaID, TableName, MaxGuests, IsOccupied, TableCode) VALUES ( @AreaID, @TableName, @MaxGuests, 0, @TableCode)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AreaID", areaId),
                new SqlParameter("@TableName", tableName),
                new SqlParameter("@MaxGuests", maxGuests),
                new SqlParameter("@TableCode", tableName) // Using tableName as TableCode
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 6️⃣ Xóa bàn ===
        public static bool DeleteTable(int tableId)
        {
            string query = "DELETE FROM Tables WHERE TableID = @TableID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TableID", tableId)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 7️⃣ Lấy toàn bộ danh sách bàn ===
        public static List<TableDAO> GetAllTables()
        {
            string query = "SELECT * FROM Tables";
            DataTable dt = DataProvider.ExecuteQuery(query);
            List<TableDAO> tables = new List<TableDAO>();

            foreach (DataRow row in dt.Rows)
            {
                tables.Add(new TableDAO(
                    Convert.ToInt32(row["TableID"]),
                    row["TableCode"].ToString(),
                    row["TableName"].ToString(),
                    Convert.ToInt32(row["AreaID"]),
                    Convert.ToInt32(row["MaxGuests"]),
                    Convert.ToBoolean(row["IsOccupied"])
                ));
            }

            return tables;
        }

        // === 8️⃣ Reset trạng thái tất cả các bàn ===
        public static void ResetAllTableStatus()
        {
            string query = "UPDATE Tables SET IsOccupied = 0";
            DataProvider.ExecuteNonQuery(query);
        }
    }
}
