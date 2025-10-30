using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class UserDAO
    {
        public static DataRow VerifyLogin(string username, string password)
        {
            string query = "SELECT UserID, Username, DisplayName, Role FROM Users WHERE Username = @Username AND Password = @Password";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable result = DataProvider.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }
        public static DataTable GetUsersByRole(int role)
        {
            string query = "SELECT UserID, DisplayName FROM Users WHERE Role = @Role";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Role", role)
            };
            return DataProvider.ExecuteQuery(query, parameters);
        }

        public static int UpdateUserPassword(int userId, string newPassword)
        {
            string query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Password", newPassword),
                new SqlParameter("@UserID", userId)
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }
    }
}
