
using QuanLyCF.DAL;
using System.Data;

namespace QuanLyCF.BUS
{
    public class StoreInfoBUS
    {
        public static DataRow GetStoreInfo()
        {
            return StoreInfoDAO.GetStoreInfo();
        }

        public static bool UpdateStoreInfo(int storeId, string name, string hotline, string email, string address, string facebook, string logoPath)
        {
            // Add validation logic here if needed
            return StoreInfoDAO.UpdateStoreInfo(storeId, name, hotline, email, address, facebook, logoPath);
        }
        public static bool InsertStoreInfo(string name, string hotline, string email, string address, string facebook, string logoPath)
        {
            return StoreInfoDAO.InsertStoreInfo(name, hotline, email, address, facebook, logoPath);
        }
    }
}
