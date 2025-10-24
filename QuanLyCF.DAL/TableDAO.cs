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

        public static List<TableDAO> GetTablesByArea(int areaId)
        {
            string query = "SELECT * FROM Tables WHERE AreaID = @AreaID";
            SqlParameter param = new SqlParameter("@AreaID", SqlDbType.Int) { Value = areaId };

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
    }
}