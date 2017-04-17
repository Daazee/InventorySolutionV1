using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
   public class EmailSettingBs
    {

        private EmailSettingDA NewEmailSettingDA = new EmailSettingDA();

        public IEnumerable<EmailSetting> ListAll()
        {
            return NewEmailSettingDA.ListAll();
        }

        public EmailSetting GetById(int id)
        {
            return NewEmailSettingDA.GetById(id);
        }

        public EmailSetting GetEmailSetting()
        {
            return NewEmailSettingDA.GetEmailSetting();
        }
        public void Insert(EmailSetting EmailSettingObj)
        {
            NewEmailSettingDA.Insert(EmailSettingObj);
        }

        public void Update(EmailSetting EmailSettingObj)
        {
            NewEmailSettingDA.Update(EmailSettingObj);
        }
        public void Delete(int id)
        {
            NewEmailSettingDA.Delete(id);
        }
    }
}
