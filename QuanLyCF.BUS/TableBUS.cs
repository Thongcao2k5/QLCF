using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCF.BUS
{
    public class TableBUS
    {
        public static List<TableDAO> GetTablesByArea(int areaId)
        {
            return TableDAO.GetTablesByArea(areaId);
        }
    }
}
