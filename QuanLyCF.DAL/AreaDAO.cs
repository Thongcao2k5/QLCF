using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class AreaDAO
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }

        public AreaDAO(int id, string name, string description = null)
        {
            this.AreaID = id;
            this.AreaName = name;
            this.Description = description;
        }
        public AreaDAO() { }
    }
}