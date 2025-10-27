using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyCF.DAL;

namespace QuanLyCF.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;
        public static StaffDAO Instance => instance ?? (instance = new StaffDAO());
        private StaffDAO() { }

        public DataTable GetAll()
        {
            string query = "SELECT ID, FullName, Gender, BirthDate, IdCard, Email, Phone, Address, Role, Salary, Working, Avatar FROM Users";
            return DataProvider.ExecuteQuery(query);
        }

        public DataTable Search(string name, string role)
        {
            string query = "SELECT * FROM Users WHERE FullName LIKE N'%' + @name + '%'";
            if (!string.IsNullOrEmpty(role))
                query += " AND Role = @role";
            return DataProvider.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@role", role) });        }

        public bool Insert(string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
        {
            string query = @"INSERT INTO Users (FullName, Gender, BirthDate, IdCard, Email, Phone, Address, Role, Salary, Working, Avatar)
                             VALUES ( @fullname, @gender, @birth, @idCard, @email, @phone, @address, @role, @salary, @working, @avatar)";
            SqlParameter[] param = {
                new SqlParameter("@fullname", fullname),
                new SqlParameter("@gender", gender),
                new SqlParameter("@birth", birth),
                new SqlParameter("@idCard", idCard),
                new SqlParameter("@email", email),
                new SqlParameter("@phone", phone),
                new SqlParameter("@address", address),
                new SqlParameter("@role", role),
                new SqlParameter("@salary", salary),
                new SqlParameter("@working", working),
                new SqlParameter("@avatar", avatar)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        public bool Update(int id, string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
        {
            string query;
            SqlParameter[] param;
            if (avatar != null)
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idCard, Email= @email, Phone= @phone,
                          Address= @address, Role= @role, Salary= @salary, Working= @working, Avatar= @avatar
                          WHERE ID= @id";
                param = new SqlParameter[] {
                    new SqlParameter("@fullname", fullname),
                    new SqlParameter("@gender", gender),
                    new SqlParameter("@birth", birth),
                    new SqlParameter("@idCard", idCard),
                    new SqlParameter("@email", email),
                    new SqlParameter("@phone", phone),
                    new SqlParameter("@address", address),
                    new SqlParameter("@role", role),
                    new SqlParameter("@salary", salary),
                    new SqlParameter("@working", working),
                    new SqlParameter("@avatar", avatar),
                    new SqlParameter("@id", id)
                };
            }
            else
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idCard, Email= @email, Phone= @phone,
                          Address= @address, Role= @role, Salary= @salary, Working= @working
                          WHERE ID= @id";
                param = new SqlParameter[] {
                    new SqlParameter("@fullname", fullname),
                    new SqlParameter("@gender", gender),
                    new SqlParameter("@birth", birth),
                    new SqlParameter("@idCard", idCard),
                    new SqlParameter("@email", email),
                    new SqlParameter("@phone", phone),
                    new SqlParameter("@address", address),
                    new SqlParameter("@role", role),
                    new SqlParameter("@salary", salary),
                    new SqlParameter("@working", working),
                    new SqlParameter("@id", id)
                };
            }

            int res = DataProvider.ExecuteNonQuery(query, param);
            return res > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Users WHERE ID = @id";
            int res = DataProvider.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@id", id) });
            return res > 0;
        }
    }
}