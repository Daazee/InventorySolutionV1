using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL
{
 public class EmailSettingDA
    {
        public InventoryContext context = new InventoryContext();
        private string message;
        public IEnumerable<EmailSetting> ListAll()
        {
            return context.EmailSettings.ToList();
        }

        public EmailSetting GetById(int id)
        {
            return context.EmailSettings.Where(c => c.EmailSettingsID == id).FirstOrDefault();
        }

        public EmailSetting GetEmailSetting()
        {
            return context.EmailSettings.FirstOrDefault();
        }
        public void Insert(EmailSetting EmailSettingObj)
        {
            context.EmailSettings.Add(EmailSettingObj);
            context.SaveChanges();
        }

        public void Update(EmailSetting EmailSettingObj)
        {
            context.Entry(EmailSettingObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.EmailSettings.Where(c => c.EmailSettingsID == id).FirstOrDefault();
            context.EmailSettings.Remove(search);
            context.SaveChanges();
        }
    }
}
