using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
   public class Receipt
    {
        public ICollection<Sales> SalesReceipt { get; set; }

        public ICollection<CompanyDetail> CompanyDetailReceipt { get; set; }

        public ICollection<PaymentDetail> PaymentDetailReceipt { get; set; }

        public User UserReceipt { get; set; }

        public CompanyLogo CompanyLogoReceipt { get; set; }

        public Customer CustomerReceipt { get; set; }
    }
}
