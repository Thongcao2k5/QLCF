using System;
using System.Data;
using System.IO;

namespace QuanLyCF.DAL
{
    public class StaffDAO
    {
        private static StaffDAO instance;
        public static StaffDAO Instance => instance ?? (instance = new StaffDAO());
        private StaffDAO() { }

        public DataTable GetAll()
        {
            string query = "SELECT ID, FullName, Gender, BirthDate, IdCard, Email, Phone, Address, BHXH, Department, Salary, Working, Avatar FROM Users";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable Search(string name, string dept)
        {
            string query = "SELECT ID, FullName, Gender, BirthDate, IdCard, Email, Phone, Address, BHXH, Department, Salary, Working, Avatar FROM Users WHERE (FullName LIKE N'%' + @name + '%')";
            if (!string.IsNullOrEmpty(dept))
            {
                query += " AND Department = @dept";
                return DataProvider.Instance.ExecuteQuery(query, new object[] { name, dept });
            }
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name });
        }

        public bool Insert(string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string bhxh, string department, decimal salary, bool working, byte[] avatar)
        {
            string query = @"INSERT INTO Users (FullName, Gender, BirthDate, IdCard, Email, Phone, Address, BHXH, Department, Salary, Working, Avatar, CreatedAt)
                             VALUES ( @fullname, @gender, @birth, @idcard, @email, @phone, @address, @bhxh, @dept, @salary, @working, @avatar, GETDATE())";
            object[] param = new object[] { fullname, gender, birth, idCard, email, phone, address, bhxh, department, salary, working, avatar };
            int res = DataProvider.Instance.ExecuteNonQuery(query, param);
            return res > 0;
        }

        public bool Update(int id, string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string bhxh, string department, decimal salary, bool working, byte[] avatar)
        {
            string query;
            object[] param;
            if (avatar != null)
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idcard, Email= @email, Phone= @phone,
                          Address= @address, BHXH= @bhxh, Department= @dept, Salary= @salary, Working= @working, Avatar= @avatar, UpdatedAt=GETDATE()
                          WHERE ID= @id";
                param = new object[] { fullname, gender, birth, idCard, email, phone, address, bhxh, department, salary, working, avatar, id };
            }
            else
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idcard, Email= @email, Phone= @phone,
                          Address= @address, BHXH= @bhxh, Department= @dept, Salary= @salary, Working= @working, UpdatedAt=GETDATE()
                          WHERE ID= @id";
                param = new object[] { fullname, gender, birth, idCard, email, phone, address, bhxh, department, salary, working, id };
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

        public DataRow GetById(int id)
        {
            string query = "SELECT * FROM Users WHERE ID = @id";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            if (dt.Rows.Count > 0) return dt.Rows[0];
            return null;
        }

        // Lấy danh sách phòng ban từ Users (distinct)
        public DataTable GetDepartments()
        {
            string query = "SELECT DISTINCT Department FROM Users WHERE Department IS NOT NULL";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}