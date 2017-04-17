using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
  public  class ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime KeyDate { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }

    }
}
