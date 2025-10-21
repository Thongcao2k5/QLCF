using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class UserDAO
    {
        /// <summary>
        /// Verifies user credentials against the database.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if credentials are valid, otherwise false.</returns>
        public static bool VerifyLogin(string username, string password)
        {
            // WARNING: This method checks a plain text password and is NOT SECURE.
            // In a real application, you must hash the password provided by the user 
            // and compare it with the stored hash in the database.
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username };
            parameters[1] = new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password };

            // ExecuteScalar returns the first column of the first row in the result set.
            object result = DataProvider.ExecuteScalar(query, parameters);

            // If a record was found, the count will be 1.
            return result != null && (int)result == 1;
        }
    }
}
