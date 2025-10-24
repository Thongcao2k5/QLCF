using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCF.BUS
{
    public class AreaBUS
    {
        public static List<AreaDAO> GetAllAreas()
        {
            return AreaDAO.GetAllAreas();
        }

        // Cập nhật thông tin khu vực
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

        // Xóa khu vực
        public static bool DeleteArea(int id)
        {
            string query = "DELETE FROM Areas WHERE AreaID = @id";
            var param = new SqlParameter[]
            {
        new SqlParameter("@id", id)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }


        // Lấy thông tin khu vực theo ID
        public static AreaDAO GetAreaById(int id)
        {
            return AreaDAO.GetAreaById(id);
        }


        // Thêm khu vực mới
        public static bool AddArea(string name, string desc)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            return AreaDAO.InsertArea(name, desc);
        }

    }
}
