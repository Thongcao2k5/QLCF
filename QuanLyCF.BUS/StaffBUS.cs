using System;
using System.Data;
using System.IO;
using QuanLyCF.DAL;

namespace QuanLyCF.BUS
{
    public class StaffBUS
    {
        public static object Instance;
        public static readonly string UserFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\User\"));
        public static DataTable GetAllStaff()
            => StaffDAO.GetAll();

        public static DataTable SearchStaff(string name, string phone)
        {
            return StaffDAO.SearchStaff(name, phone);
        }

                public static DataRow GetStaffByUserId(int userId)

                {

                    return StaffDAO.GetStaffByUserId(userId);

                }

        

        public static bool AddStaff(string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
        {
            string avatarPath = null;
            if (avatar != null)
            {
                avatarPath = Guid.NewGuid().ToString() + ".jpg";
                File.WriteAllBytes(Path.Combine(UserFolder, avatarPath), avatar);
            }
            return StaffDAO.Insert(fullname, gender, birth, idCard, email, phone, address, role, salary, working, avatarPath);
        }

        public static bool UpdateStaff(int id, string fullname, string gender, DateTime birth, string idCard, string email, string phone, string address, string role, decimal salary, bool working, byte[] avatar)
        {
            string avatarPath = null;
            if (avatar != null)
            {
                avatarPath = Guid.NewGuid().ToString() + ".jpg";
                File.WriteAllBytes(Path.Combine(UserFolder, avatarPath), avatar);
            }
            return StaffDAO.Update(id, fullname, gender, birth, idCard, email, phone, address, role, salary, working, avatarPath);
        }

        

                public static bool DeleteStaff(int id)

                {

                    return StaffDAO.Delete(id);

                }

            }

        }

        