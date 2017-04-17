using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
  public  class StockHistory
    {
        [Key]
        public int StockHistoryID { get; set; }

        [Display(Name = "Product Category Code")]
        public int ProductCategoryID { get; set; }

        [Display(Name = "Product Code")]
        public int ProductDetailID { get; set; }

        public int UnitAsAtDelievery { get; set; }

        public int UnitReceived { get; set; }

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
