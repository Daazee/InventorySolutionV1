using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL

{
   public class StockHistoryDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<StockHistory> ListAll()
        {
            return context.StockHistory.ToList();
        }

        public StockHistory GetById(int id)
        {
            return context.StockHistory.Where(c => c.StockHistoryID == id).FirstOrDefault();
        }

        public IEnumerable<StockHistory> GetByProductCategoryID(int ProductCategoryID)
        {
            return context.StockHistory.Where(c => c.ProductCategoryID == ProductCategoryID).ToList();
        }
        public IEnumerable<StockHistory> GetByProductDetailID(int ProductDetailID)
        {
            return context.StockHistory.Where(c => c.ProductDetailID == ProductDetailID).ToList();
        }
        public void Insert(StockHistory StockHistoryObj)
        {
            context.StockHistory.Add(StockHistoryObj);
            context.SaveChanges();
        }

        public void Update(StockHistory StockHistoryObj)
        {
            context.Entry(StockHistoryObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.StockHistory.Where(c => c.StockHistoryID == id).FirstOrDefault();
            context.StockHistory.Remove(search);
            context.SaveChanges();
        }
    }
}
