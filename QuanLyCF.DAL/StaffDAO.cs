using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class StaffDAO
    {
        public static DataTable GetAll()
        {
            string query = "SELECT UserID, FullName, Gender, BirthDate, IdCard, Email, Phone, Address, Role, Salary, Working, Avatar FROM Users";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataTable Search(string name, string role)
        {
            string query = "SELECT * FROM Users WHERE FullName LIKE N'%' + @name + '%'";
            if (!string.IsNullOrEmpty(role))
                query += " AND Role = @role";
            return DataProvider.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@name", name), new SqlParameter("@role", role) });
        }

        public static bool Insert(string fullname, string gender, System.DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, string avatarPath)
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
                new SqlParameter("@avatar", avatarPath)
            };
            return DataProvider.ExecuteNonQuery(query, param) > 0;
        }

        public static bool Update(int id, string fullname, string gender, System.DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, string avatarPath)
        {
            string query;
            SqlParameter[] param;
            if (avatarPath != null)
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idCard, Email= @email, Phone= @phone,
                          Address= @address, Role= @role, Salary= @salary, Working= @working, Avatar= @avatar
                          WHERE UserID= @id";
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
                    new SqlParameter("@avatar", avatarPath),
                    new SqlParameter("@id", id)
                };
            }
            else
            {
                query = @"UPDATE Users SET FullName= @fullname, Gender= @gender, BirthDate= @birth, IdCard= @idCard, Email= @email, Phone= @phone,
                          Address= @address, Role= @role, Salary= @salary, Working= @working
                          WHERE UserID= @id";
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

        public static bool Delete(int id)
        {
            string query = "DELETE FROM Users WHERE UserID = @id";
            int res = DataProvider.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@id", id) });
            return res > 0;
        }

        public static DataTable SearchStaff(string name, string phone)
        {
            string query = "SELECT * FROM Users WHERE FullName LIKE @FullName AND Phone LIKE @Phone";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", "N'%" + name + "%'"),
                new SqlParameter("@Phone", "N'%" + phone + "%'")
            };

            return DataProvider.ExecuteQuery(query, parameters);
        }

        public static DataRow GetStaffByUserId(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId)
            };

            DataTable result = DataProvider.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }
    }
}