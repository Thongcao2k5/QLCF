using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class UserDAO
    {
        public static bool VerifyLogin(string username, string password)
        {
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username };
            parameters[1] = new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password };

            object result = DataProvider.ExecuteScalar(query, parameters);

            return result != null && (int)result == 1;
        }
    }
}
