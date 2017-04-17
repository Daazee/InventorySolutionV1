using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL

{
   public class SalesDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<Sales> ListAll()
        {
            return context.Sales.ToList();
        }

        public Sales GetById(int id)
        {
            return context.Sales.Where(c => c.SalesID == id).FirstOrDefault();
        }

        public IEnumerable<Sales> ProductCategoryID(int ProductCategoryID)
        {
            return context.Sales.Where(c => c.ProductCategoryID == ProductCategoryID).ToList();
        }
        public IEnumerable<Sales> GetByProductDetailID(int ProductDetailID)
        {
            return context.Sales.Where(c => c.ProductDetailID == ProductDetailID).ToList();
        }
        public void Insert(Sales SalesObj)
        {
            context.Sales.Add(SalesObj);
            context.SaveChanges();
        }

        public void Update(Sales SalesObj)
        {
            context.Entry(SalesObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.Sales.Where(c => c.SalesID == id).FirstOrDefault();
            context.Sales.Remove(search);
            context.SaveChanges();
        }

        public int GetLastTransNo(string TNo)
        {
            int LastTransNo = 0;
            var search = from p in context.Sales
                         where p.TransactionNo.StartsWith(TNo)
                         orderby p.SalesID descending
                         select p;
            var result = search.FirstOrDefault();

            if (result != null)
            {
                string[] SplitResult = result.TransactionNo.Split('/');
                LastTransNo = Convert.ToInt32(SplitResult[2]);
            }
            return LastTransNo;
        }

        public IEnumerable<Sales> GetByTransactionNo(string TransNo)
        {
            return context.Sales.Where(c => c.TransactionNo == TransNo).ToList();
        }


    }
}
