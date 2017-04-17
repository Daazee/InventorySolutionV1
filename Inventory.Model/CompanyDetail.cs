using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
   public class CompanyDetail
    {
        [Key]
        public int CompanyID { get; set; }

        public string CompanyCode { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Short Name")]
        public string CompanyShortName { get; set; }

        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Phone Number 1")]
        public string CompanyPhone1 { get; set; }

        [Display(Name = "Phone Number 2")]
        public string CompanyPhone2 { get; set; }

        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

        [Display(Name = "Username")]
        public string CompanyUsername { get; set; }

        [Display(Name = "Password")]
        public string CompanyPassword { get; set; }

        //The person that key this information 
        public string CreatedBy { get; set; }
        public byte[] Logo { get; set; }
        public string Flag { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
