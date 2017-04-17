using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Othername { get; set; }
        public string Sex { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string CustomerPhone { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public int Status { get; set; }
        
        public string CreatedBy { get; set; }
        public string Flag { get; set; }
        public DateTime Keydate { get; set; }
        //public virtual ICollection<Transaction> Transactions { get; set; }
        //public virtual ICollection<PaymentDetail> PaymentDetail { get; set; }
    }
}
