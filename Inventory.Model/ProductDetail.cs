using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Model
{
    public class ProductDetail
    {
        [Key]
        public int ProductDetailID { get; set; }

        [Required]
        [ForeignKey("ProductCategory")]
        [Display(Name = "Product Category Code")]
        public int ProductCategoryID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Required]
        [Display(Name = "Cost Price")]
        public double CostPrice { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public double SellingPrice { get; set; }

        [Required]
        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        public string Flag { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

    }
}
