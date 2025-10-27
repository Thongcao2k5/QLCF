
using QuanLyCF.DAL;
using System;
using System.Data;

namespace QuanLyCF.BUS
{
    public class ReportBUS
    {
        public static DataTable GetRevenueReport(DateTime fromDate, DateTime toDate, int areaId, int categoryId, int staffId)
        {
            return ReportDAO.GetRevenueReport(fromDate, toDate, areaId, categoryId, staffId);
        }
    }
}
