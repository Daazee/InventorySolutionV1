using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Model
{
  public  class Stock
    {
        [Key]
        public int StockID { get; set; }

        [Display(Name = "Product Category Code")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "Product Code")]
        [ForeignKey("ProductDetail")]
        public int ProductDetailID { get; set; }

        [Display(Name = "Stock Level")]
        public int StockLevel { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedOn { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

    }
}
