using System.Collections.Generic;
using QuanLyCF.DAL;

namespace QuanLyCF.BUS
{
    public class DrinkBUS
    {
        public static List<DrinkDAO> GetAllDrinks()
        {
            return DrinkDAO.GetAllDrinks();
        }

        public static List<DrinkDAO> GetDrinksByCategory(int categoryId)
        {
            return DrinkDAO.GetDrinksByCategory(categoryId);
        }

        public static DrinkDAO GetDrinkById(int drinkId)
        {
            return DrinkDAO.GetDrinkById(drinkId);
        }

        public static bool InsertDrink(string name, int categoryId, decimal price, string imagePath, bool isAvailable)
        {
            return DrinkDAO.InsertDrink(name, categoryId, price, imagePath, isAvailable);
        }

        public static bool UpdateDrink(int id, string name, int categoryId, decimal price, string imagePath, bool isAvailable)
        {
            return DrinkDAO.UpdateDrink(id, name, categoryId, price, imagePath, isAvailable);
        }

        public static bool DeleteDrink(int drinkId)
        {
            return DrinkDAO.DeleteDrink(drinkId);
        }

        public static List<DrinkDAO> SearchDrinksByName(string keyword)
        {
            return DrinkDAO.SearchDrinksByName(keyword);
        }
    }
}
