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
        public double Price { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime KeyDate { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

    }
}
