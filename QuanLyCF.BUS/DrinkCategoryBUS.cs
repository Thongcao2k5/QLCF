
using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCF.BUS
{
    public class DrinkCategoryBUS
    {
        public static DataTable GetAllCategories()
        {
            return DrinkCategoryDAO.GetAllCategories();
        }

        public static bool InsertCategory(string categoryName)
        {
            return DrinkCategoryDAO.InsertCategory(categoryName);
        }

        public static bool UpdateCategory(int categoryId, string categoryName)
        {
            return DrinkCategoryDAO.UpdateCategory(categoryId, categoryName);
        }

        public static bool DeleteCategory(int categoryId)
        {
            return DrinkCategoryDAO.DeleteCategory(categoryId);
        }
    }
}
