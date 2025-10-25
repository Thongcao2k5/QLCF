using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class DrinkDAO
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }

        public DrinkDAO() { }

        public DrinkDAO(int id, string name, int categoryId, decimal price, string imagePath, bool isAvailable, DateTime createdDate)
        {
            DrinkID = id;
            DrinkName = name;
            CategoryID = categoryId;
            Price = price;
            ImagePath = imagePath;
            IsAvailable = isAvailable;
            CreatedDate = createdDate;
        }

        // === 1️⃣ Lấy toàn bộ danh sách đồ uống ===
        public static List<DrinkDAO> GetAllDrinks()
        {
            string query = "SELECT * FROM Drinks ORDER BY CreatedDate DESC";
            DataTable dt = DataProvider.ExecuteQuery(query);

            List<DrinkDAO> drinks = new List<DrinkDAO>();
            foreach (DataRow row in dt.Rows)
            {
                drinks.Add(new DrinkDAO(
                    Convert.ToInt32(row["DrinkID"]),
                    row["DrinkName"].ToString(),
                    Convert.ToInt32(row["CategoryID"]),
                    Convert.ToDecimal(row["Price"]),
                    row["ImagePath"]?.ToString(),
                    Convert.ToBoolean(row["IsAvailable"]),
                    Convert.ToDateTime(row["CreatedDate"])
                ));
            }
            return drinks;
        }

        // === 2️⃣ Lấy danh sách đồ uống theo danh mục ===
        public static List<DrinkDAO> GetDrinksByCategory(int categoryId)
        {
            string query = "SELECT * FROM Drinks WHERE CategoryID = @CategoryID";
            SqlParameter[] param = { new SqlParameter("@CategoryID", categoryId) };
            DataTable dt = DataProvider.ExecuteQuery(query, param);

            List<DrinkDAO> drinks = new List<DrinkDAO>();
            foreach (DataRow row in dt.Rows)
            {
                drinks.Add(new DrinkDAO(
                    Convert.ToInt32(row["DrinkID"]),
                    row["DrinkName"].ToString(),
                    Convert.ToInt32(row["CategoryID"]),
                    Convert.ToDecimal(row["Price"]),
                    row["ImagePath"]?.ToString(),
                    Convert.ToBoolean(row["IsAvailable"]),
                    Convert.ToDateTime(row["CreatedDate"])
                ));
            }
            return drinks;
        }

        // === 3️⃣ Lấy thông tin đồ uống theo ID ===
        public static DrinkDAO GetDrinkById(int drinkId)
        {
            string query = "SELECT * FROM Drinks WHERE DrinkID = @id";
            SqlParameter[] param = { new SqlParameter("@id", drinkId) };
            DataTable dt = DataProvider.ExecuteQuery(query, param);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DrinkDAO(
                    Convert.ToInt32(row["DrinkID"]),
                    row["DrinkName"].ToString(),
                    Convert.ToInt32(row["CategoryID"]),
                    Convert.ToDecimal(row["Price"]),
                    row["ImagePath"]?.ToString(),
                    Convert.ToBoolean(row["IsAvailable"]),
                    Convert.ToDateTime(row["CreatedDate"])
                );
            }
            return null;
        }

        // === 4️⃣ Thêm đồ uống mới ===
        public static bool InsertDrink(string name, int categoryId, decimal price, string imagePath, bool isAvailable)
        {
            string query = @"INSERT INTO Drinks (DrinkName, CategoryID, Price, ImagePath, IsAvailable, CreatedDate)
                             VALUES (@name, @categoryId, @price, @imagePath, @isAvailable, GETDATE())";
            SqlParameter[] param =
            {
                new SqlParameter("@name", name),
                new SqlParameter("@categoryId", categoryId),
                new SqlParameter("@price", price),
                new SqlParameter("@imagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath),
                new SqlParameter("@isAvailable", isAvailable)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 5️⃣ Cập nhật thông tin đồ uống ===
        public static bool UpdateDrink(int id, string name, int categoryId, decimal price, string imagePath, bool isAvailable)
        {
            string query = @"UPDATE Drinks
                             SET DrinkName = @name, CategoryID = @categoryId, Price = @price,
                                 ImagePath = @imagePath, IsAvailable = @isAvailable
                             WHERE DrinkID = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@id", id),
                new SqlParameter("@name", name),
                new SqlParameter("@categoryId", categoryId),
                new SqlParameter("@price", price),
                new SqlParameter("@imagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath),
                new SqlParameter("@isAvailable", isAvailable)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 6️⃣ Xóa đồ uống ===
        public static bool DeleteDrink(int drinkId)
        {
            string query = "DELETE FROM Drinks WHERE DrinkID = @id";
            SqlParameter[] param = { new SqlParameter("@id", drinkId) };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        // === 7️⃣ Tìm kiếm đồ uống theo tên ===
        public static List<DrinkDAO> SearchDrinksByName(string keyword)
        {
            string query = "SELECT * FROM Drinks WHERE DrinkName LIKE '%' + @keyword + '%'";
            SqlParameter[] param = { new SqlParameter("@keyword", keyword) };
            DataTable dt = DataProvider.ExecuteQuery(query, param);

            List<DrinkDAO> drinks = new List<DrinkDAO>();
            foreach (DataRow row in dt.Rows)
            {
                drinks.Add(new DrinkDAO(
                    Convert.ToInt32(row["DrinkID"]),
                    row["DrinkName"].ToString(),
                    Convert.ToInt32(row["CategoryID"]),
                    Convert.ToDecimal(row["Price"]),
                    row["ImagePath"]?.ToString(),
                    Convert.ToBoolean(row["IsAvailable"]),
                    Convert.ToDateTime(row["CreatedDate"])
                ));
            }
            return drinks;
        }


    }
}
