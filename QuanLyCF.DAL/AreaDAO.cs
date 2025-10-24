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
    }
}