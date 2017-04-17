using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
  public  class CompanyLogo
    {
        [Key]
        public string CompanyLogoId { get; set; }

        public string Username { get; set; }
        public byte[] Logo { get; set; }
        public string Flag { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Key_Date { get; set; }
    }
}
