using System;
using System.Data;
using QuanLyCF.DAO;

namespace QuanLyCF.BUS
{
    public class StaffBUS
    {
        public static DataTable GetAllStaff()
            => StaffDAO.Instance.GetAll();

        public static DataTable SearchStaff(string name, string role)
            => StaffDAO.Instance.Search(name, role);

        public static bool AddStaff(string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
            => StaffDAO.Instance.Insert(fullname, gender, birth, idCard, email, phone, address, role, salary, working, avatar);

        public static bool UpdateStaff(int id, string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
            => StaffDAO.Instance.Update(id, fullname, gender, birth, idCard, email, phone, address, role, salary, working, avatar);

        public static bool DeleteStaff(int id)
            => StaffDAO.Instance.Delete(id);
    }
}