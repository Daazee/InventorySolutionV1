using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using Inventory.DAL;

namespace Inventory.BLL
{
   
   public class ReportBs
    {
        private ReportDA NewReportDA = new ReportDA();

        public IEnumerable<PaymentDetail> SalesReport(DateTime StartDate, DateTime EndDate)
        {
            return NewReportDA.SalesReport(StartDate, EndDate);
           
        }

        public double SalesReportPages(DateTime StartDate, DateTime EndDate)
        {
            return Math.Ceiling(NewReportDA.SalesReportCount(StartDate, EndDate) / 10.0) ;
        }
    }
}
