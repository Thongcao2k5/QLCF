
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
    }
}
