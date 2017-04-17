using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Model
{
  public class Sales
    {
        public int SalesID { get; set; }

        public string TransactionNo { get; set; }

        [Display(Name = "Product Category")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "Product Code")]
        [ForeignKey("ProductDetail")]
        public int ProductDetailID { get; set; }

        public int Quantity { get; set; }

        public double Rate { get; set; }

        //Quantity * Rate
        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        [Display(Name = "Total Cost")]
        public double TotalProductCostAmount { get; set; }

        [Display(Name = "Amount Paid")]
        public double AmountPaid { get; set; }

        public string HeaderDetail { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

    }
}
