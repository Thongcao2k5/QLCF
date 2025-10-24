using QuanLyCF.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCF.BUS
{
    public class AreaBUS
    {
        public static List<AreaDAO> GetAllAreas()
        {
            return AreaDAO.GetAllAreas();
        }
    }
}
