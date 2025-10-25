using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class AreaDAO
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }

        public AreaDAO(int id, string name, string description = null)
        {
            this.AreaID = id;
            this.AreaName = name;
            this.Description = description;
        }
        public AreaDAO() { }

        // === Lấy toàn bộ danh sách khu vực ===
        public static List<AreaDAO> GetAllAreas()
        {
            List<AreaDAO> areas = new List<AreaDAO>();

            string query = "SELECT AreaID, AreaName, Description FROM Areas";

            DataTable dt = DataProvider.ExecuteQuery(query); // bạn đã có lớp DataProvider trong DAL

            foreach (DataRow row in dt.Rows)
            {
                areas.Add(new AreaDAO
                {
                    AreaID = Convert.ToInt32(row["AreaID"]),
                    AreaName = row["AreaName"].ToString(),
                    Description = row["Description"].ToString()
                });
            }

            return areas;
        }

        // === Lấy khu vực theo ID ===
        public static AreaDAO GetAreaById(int id)
        {
            string query = "SELECT AreaID, AreaName, Description FROM Areas WHERE AreaID = @id";
            SqlParameter[] param = { new SqlParameter("@id", id) };

            DataTable dt = DataProvider.ExecuteQuery(query, param);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new AreaDAO
                {
                    AreaID = Convert.ToInt32(r["AreaID"]),
                    AreaName = r["AreaName"].ToString(),
                    Description = r["Description"]?.ToString()
                };
            }
            return null;
        }

        // === Thêm khu vực mới ===
        public static bool InsertArea(string name, string desc)
        {
            string query = "INSERT INTO Areas (AreaName, Description) VALUES (@name, @desc)";
            SqlParameter[] param =
            {
                new SqlParameter("@name", name),
                new SqlParameter("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === Cập nhật khu vực ===
        public static bool UpdateArea(int id, string name, string desc)
        {
            string query = "UPDATE Areas SET AreaName = @name, Description = @desc WHERE AreaID = @id";
            var param = new SqlParameter[]
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@desc", desc ?? (object)DBNull.Value)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === Xóa khu vực ===
        public static bool DeleteArea(int id)
        {
            string query = "DELETE FROM Areas WHERE AreaID = @id";
            var param = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

    }
}