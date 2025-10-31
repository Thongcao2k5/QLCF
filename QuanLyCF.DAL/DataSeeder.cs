using System;

namespace QuanLyCF.DAL
{
    public class DataSeeder
    {
        public static void SeedData()
        {
            if (AreaDAO.GetAllAreas().Count == 0)
            {
                AreaDAO.InsertArea("Khu vực 1", "Khu vực ngoài trời");
                AreaDAO.InsertArea("Khu vực 2", "Khu vực trong nhà");
            }

            if (TableDAO.GetAllTables().Count == 0)
            {
                TableDAO.InsertTable(1, "Bàn 1", 4);
                TableDAO.InsertTable(1, "Bàn 2", 4);
                TableDAO.InsertTable(2, "Bàn 3", 2);
                TableDAO.InsertTable(2, "Bàn 4", 8);
            }

            if (DrinkCategoryDAO.GetAllCategories().Rows.Count == 0)
            {
                DrinkCategoryDAO.InsertCategory("Cà phê");
                DrinkCategoryDAO.InsertCategory("Trà");
                DrinkCategoryDAO.InsertCategory("Nước ép");
            }

            if (DrinkDAO.GetAllDrinks().Count == 0)
            {
                DrinkDAO.InsertDrink("Cà phê đen", 1, 20000, "phindenda.jpg", true);
                DrinkDAO.InsertDrink("Cà phê sữa", 1, 25000, "phinsuada.jpg", true);
                DrinkDAO.InsertDrink("Trà đào", 2, 30000, "trathachdao.jpg", true);
                DrinkDAO.InsertDrink("Nước ép cam", 3, 35000, "chanhdaxay.jpg", true);
            }

            if (StoreInfoDAO.GetStoreInfo() == null)
            {
                StoreInfoDAO.InsertStoreInfo("My Coffee Shop", "123456789", "contact@mycoffeeshop.com", "123 Main St, Anytown, USA", "https://www.facebook.com/mycoffeeshop", "logo.png");
            }
        }
    }
}
