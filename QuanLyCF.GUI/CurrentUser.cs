
using System.Data;

namespace QuanLyCF.GUI
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }
        public static string DisplayName { get; set; }
        public static string Role { get; set; }

        public static void SetUser(DataRow userData)
        {
            if (userData != null)
            {
                UserID = (int)userData["UserID"];
                Username = (string)userData["Username"];
                DisplayName = (string)userData["DisplayName"];
                Role = (string)userData["Role"];
            }
        }

        public static void Clear()
        {
            UserID = 0;
            Username = null;
            DisplayName = null;
            Role = null;
        }
    }
}
