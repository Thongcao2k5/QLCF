using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCF.BUS
{
    public class UserBUS
    {
        public static DataRow VerifyLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return UserDAO.VerifyLogin(username.Trim(), password.Trim());
        }
        public static DataTable GetUsersByRole(int role)
        {
            return UserDAO.GetUsersByRole(role);
        }

        public static int UpdateUserPassword(int userId, string newPassword)
        {
            return UserDAO.UpdateUserPassword(userId, newPassword);
        }
    }
}
