
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class StoreInfoDAO
    {
        public static DataRow GetStoreInfo()
        {
            string query = "SELECT TOP 1 * FROM StoreInfo ORDER BY StoreID";
            DataTable dt = DataProvider.ExecuteQuery(query);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool UpdateStoreInfo(int storeId, string name, string hotline, string email, string address, string facebook, string logoPath)
        {
            string query = @"
                UPDATE StoreInfo 
                SET StoreName = @name, 
                    Hotline = @hotline, 
                    Email = @email, 
                    Address = @address, 
                    Facebook = @facebook, 
                    LogoPath = @logoPath
                WHERE StoreID = @storeId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@storeId", storeId),
                new SqlParameter("@name", name),
                new SqlParameter("@hotline", hotline),
                new SqlParameter("@email", email),
                new SqlParameter("@address", address),
                new SqlParameter("@facebook", facebook),
                new SqlParameter("@logoPath", logoPath)
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
        public static bool InsertStoreInfo(string name, string hotline, string email, string address, string facebook, string logoPath)
        {
            string query = @"
                INSERT INTO StoreInfo (StoreName, Hotline, Email, Address, Facebook, LogoPath)
                VALUES (@name, @hotline, @email, @address, @facebook, @logoPath)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@hotline", hotline),
                new SqlParameter("@email", email),
                new SqlParameter("@address", address),
                new SqlParameter("@facebook", facebook),
                new SqlParameter("@logoPath", logoPath)
            };

            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
