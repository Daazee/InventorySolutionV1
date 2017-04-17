using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class EmailSetting
    {
        [Key]
        public int EmailSettingsID { get; set; }
        public string SmtpServer { get; set; }
        
        public int PortNo { get; set; }

        [EmailAddress]
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public int DailyCountBalance { get; set; }
        public string CountDate { get; set; }
        public int MaximumEmail { get; set; }

        public string CreatedBy { get; set; }

        public string Flag { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime KeyDate { get; set; }
    }
}
