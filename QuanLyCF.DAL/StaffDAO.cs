using System;
using System.Data;

namespace QuanLyCF.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;
        public static StaffDAO Instance => instance ??= new StaffDAO();
        private StaffDAO() { }

        public DataTable GetAll()
        {
            string query = "SELECT ID, FullName, Gender, BirthDate, IdCard, Email, Phone, Address, Role, Salary, Working, Avatar FROM Users";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable Search(string name, string role)
        {
            string query = "SELECT * FROM Users WHERE FullName LIKE N'%' + @name + '%'";
            if (!string.IsNullOrEmpty(role))
                query += " AND Role = @role";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, role });
        }

        public bool Insert(string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
        {
            string query = @"INSERT INTO Users (FullName, Gender, BirthDate, IdCard, Email, Phone, Address, Role, Salary, Working, Avatar)
                             VALUES ( @fullname, @gender, @birth, @idCard, @email, @phone, @address, @role, @salary, @working, @avatar)";
            object[] param = { fullname, gender, birth, idCard, email, phone, address, role, salary, working, avatar };
            return DataProvider.Instance.ExecuteNonQuery(query, param) > 0;
        }

        public bool Update(int id, string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
        {
            string query;
            object[] param;
            if (avatar != null)
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idCard, Email= @email, Phone= @phone,
                          Address= @address, Role= @role, Salary= @salary, Working= @working, Avatar= @avatar
                          WHERE ID= @id";
                param = new object[] { fullname, gender, birth, idCard, email, phone, address, role, salary, working, avatar, id };
            }
            else
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idCard, Email= @email, Phone= @phone,
                          Address= @address, Role= @role, Salary= @salary, Working= @working
                          WHERE ID= @id";
                param = new object[] { fullname, gender, birth, idCard, email, phone, address, role, salary, working, id };
            }

            int res = DataProvider.Instance.ExecuteNonQuery(query, param);
            return res > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Users WHERE ID = @id";
            int res = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return res > 0;
        }
    }
}