using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;
namespace Inventory.DAL

{
   public class CodesDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<Codes> ListAll()
        {
            return context.Code.ToList();
        }

        public Codes GetById(int id)
        {
            return context.Code.Where(c => c.CodesID == id).FirstOrDefault();
        }

        public IEnumerable<Codes> GetByCodeType(string code_type)
        {
            return context.Code.Where(c => c.CodesType == code_type).ToList();
        }

        public Codes GetByCodeValue(string code_val)
        {
            //Get Code Description By Code Value
            return context.Code.Where(c => c.CodesValue == code_val).FirstOrDefault();
        }

        public Codes GetByCodeDesc(string code_desc)
        {
            //Get Code Description By Code Value
            return context.Code.Where(c => c.CodesDescription == code_desc).FirstOrDefault();
        }
        public void Insert(Codes CodeObj)
        {
            context.Code.Add(CodeObj);
            context.SaveChanges();
        }

        public void Update(Codes CodeObj)
        {
            context.Entry(CodeObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.Code.Where(c => c.CodesID == id).FirstOrDefault();
            context.Code.Remove(search);
            context.SaveChanges();
        }
    }
}
