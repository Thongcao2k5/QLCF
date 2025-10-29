
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCF.DAL
{
    public class DrinkCategoryDAO
    {
        public static DataTable GetAllCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM DrinkCategories ORDER BY CategoryName";
            return DataProvider.ExecuteQuery(query);
        }

        public static bool InsertCategory(string categoryName)
        {
            string query = "INSERT INTO DrinkCategories (CategoryName) VALUES (@CategoryName)";
            SqlParameter[] parameters = { new SqlParameter("@CategoryName", categoryName) };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool UpdateCategory(int categoryId, string categoryName)
        {
            string query = "UPDATE DrinkCategories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
            SqlParameter[] parameters = 
            {
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@CategoryName", categoryName)
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }

        public static bool DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM DrinkCategories WHERE CategoryID = @CategoryID";
            SqlParameter[] parameters = { new SqlParameter("@CategoryID", categoryId) };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
