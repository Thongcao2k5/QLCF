using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCF.BUS
{
    public class UserBUS
    {
        public static bool VerifyLogin(string username, string password)
        {
            // 1️⃣ Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            username = username.Trim();
            password = password.Trim();

            // 2️⃣ Gọi xuống DAL để kiểm tra
            return UserDAO.VerifyLogin(username, password);
        }
    }
}
