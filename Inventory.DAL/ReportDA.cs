using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;

namespace Inventory.DAL
{
   public class ReportDA
    {
        private string message;
        private InventoryContext context = new InventoryContext();

        public IEnumerable<PaymentDetail> SalesReport(DateTime StartDate, DateTime EndDate)
        {
            return context.PaymentDetails.Where(c => c.KeyDate >= StartDate && c.KeyDate <= EndDate).ToList();
        }

        public int SalesReportCount(DateTime StartDate, DateTime EndDate)
        {
            return context.PaymentDetails.Where(c => c.KeyDate >= StartDate).Where(c => c.KeyDate <= EndDate).Count();
        }



    }
}
