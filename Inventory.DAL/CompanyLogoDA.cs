using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventory.DAL
{
 public class CompanyLogoDA
    {
        private InventoryContext context = new InventoryContext();

        private string message;

        public CompanyLogo GetByUsername(string username)
        {
            return context.CompanyLogos.Where(c => c.Username == username).FirstOrDefault();

        }

        public CompanyLogo GetCompanyLogo()
        {
            return context.CompanyLogos.FirstOrDefault();

        }
        public void Insert(CompanyLogo CompanyLogoDAObj)
        {
            context.CompanyLogos.Add(CompanyLogoDAObj);
            context.SaveChanges();
        }

        public void Update(CompanyLogo CompanyLogoDAObj)
        {
            context.Entry(CompanyLogoDAObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var search = context.CompanyLogos.Where(c => c.Username == id).FirstOrDefault();
            context.CompanyLogos.Remove(search);
            context.SaveChanges();
        }
    }
}
