
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCF.DAL
{
    public class DrinkCategoryDAO
    {
        public static DataTable GetAllCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM DrinkCategories";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
