using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class Codes
    {
        [Key]
        public int CodesID { get; set; }

        [Display(Name ="Code Type")]
        public string CodesType { get; set; }

        [Display(Name = "Code Description")]
        public string CodesDescription { get; set; }

        [Display(Name = "Code Value")]
        public string CodesValue { get; set; }

        public string Flag { get; set; }

        public string CreatedBy { get; set; }

        public DateTime KeyDate { get; set; }
    }
}
