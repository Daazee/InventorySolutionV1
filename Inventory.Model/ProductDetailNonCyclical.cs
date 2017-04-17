using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
  public  class ProductDetailNonCyclical
    {
        public int ProductDetailID { get; set; }
        public int ProductCategoryID { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }

        public DateTime KeyDate { get; set; }

    }
}
