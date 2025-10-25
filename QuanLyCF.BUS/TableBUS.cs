using QuanLyCF.DAL;
using System;
using System.Collections.Generic;

namespace QuanLyCF.BUS
{
    public class TableBUS
    {
        // === 1️⃣ Lấy danh sách bàn theo khu vực ===
        public static List<TableDAO> GetTablesByArea(int areaId)
        {
            return TableDAO.GetTablesByArea(areaId);
        }

        // === 2️⃣ Lấy thông tin 1 bàn theo ID ===
        public static TableDAO GetTableById(int tableId)
        {
            return TableDAO.GetTableById(tableId);
        }

        // === 3️⃣ Cập nhật trạng thái bàn (đang có khách hay trống) ===
        public static bool UpdateTableStatus(int tableId, bool isOccupied)
        {
            return TableDAO.UpdateTableStatus(tableId, isOccupied);
        }

        // === 4️⃣ Cập nhật thông tin bàn (tên, khu vực, số người,...) ===
        public static bool UpdateTableInfo(TableDAO table)
        {
            return TableDAO.UpdateTableInfo(table);
        }

        // === 5️⃣ Thêm bàn mới ===
        public static bool InsertTable(string code, string name, int areaId, int maxGuests, bool isOccupied)
        {
            return TableDAO.InsertTable(code, name, areaId, maxGuests, isOccupied);
        }

        // === 6️⃣ Xóa bàn ===
        public static bool DeleteTable(int tableId)
        {
            return TableDAO.DeleteTable(tableId);
        }

                    // === 7️⃣ Lấy toàn bộ danh sách bàn ===
                    public static List<TableDAO> GetAllTables()
                    {
                        return TableDAO.GetAllTables();
                    }
        
                    // === 8️⃣ Reset trạng thái tất cả các bàn ===
                    public static void ResetAllTableStatus()
                    {
                        TableDAO.ResetAllTableStatus();
                    }    }
}
