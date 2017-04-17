using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL
{
   public class CompanyDetailDA
    {
        public InventoryContext context = new InventoryContext();
        private string message;
        public IEnumerable<CompanyDetail> ListAll()
        {
            return context.CompanyDetails.ToList();
        }

        public CompanyDetail GetCompanyDetail()
        {
            return context.CompanyDetails.FirstOrDefault();
        }

        public CompanyDetail GetById(int id)
        {
            return context.CompanyDetails.Where(c => c.CompanyID == id).FirstOrDefault();
        }

        public IEnumerable<CompanyDetail> GetByIdList(int id)
        {
            return context.CompanyDetails.Where(c => c.CompanyID == id).ToList();
        }

        //For sales report purpose
        public IEnumerable<CompanyDetail> GetCompanyDetailList()
        {
            return context.CompanyDetails.ToList();
        }


        public CompanyDetail GetByCompCode(string code)
        {
            return context.CompanyDetails.Where(c => c.CompanyCode == code).FirstOrDefault();
        }
        
        public void Insert(CompanyDetail CompanyDetailObj)
        {
            context.CompanyDetails.Add(CompanyDetailObj);
            context.SaveChanges();
        }

        public void Update(CompanyDetail CompanyDetailObj)
        {
            context.Entry(CompanyDetailObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UpdateLogo(CompanyDetail CompanyDetailObj)
        {
            context.Entry(CompanyDetailObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.CompanyDetails.Where(c => c.CompanyID == id).FirstOrDefault();
            context.CompanyDetails.Remove(search);
            context.SaveChanges();
        }

        public string VerifyCompanyEmail(string email)
        {
            var search = context.CompanyDetails.Where(c => c.CompanyEmail == email).FirstOrDefault();
            if (search != null)
            {
                message = "Company email already exist";
            }
            else
            {
                message = "";
            }
            return message;
        }
    }
}
