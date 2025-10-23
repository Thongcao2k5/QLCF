using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public class TableDAO
    {
        public int TableID { get; set; }
        public string TableCode { get; set; }
        public string TableName { get; set; }
        public int AreaID { get; set; }
        public int MaxGuests { get; set; }
        public bool IsOccupied { get; set; } // Ánh xạ IsOccupied (bit) trong DB

        public TableDAO(int id, string code, string name, int areaId, int maxGuests, bool isOccupied)
        {
            this.TableID = id;
            this.TableCode = code;
            this.TableName = name;
            this.AreaID = areaId;
            this.MaxGuests = maxGuests;
            this.IsOccupied = isOccupied;
        }

        public TableDAO() { 
        }
    }
}