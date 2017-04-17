using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL

{
   public class StockDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<Stock> ListAll()
        {
            return context.Stocks.ToList();
        }

        public Stock GetById(int id)
        {
            return context.Stocks.Where(c => c.StockID == id).FirstOrDefault();
        }

        public IEnumerable<Stock> GetByProductCategoryID(int ProductCategoryID)
        {
            return context.Stocks.Where(c => c.ProductCategoryID == ProductCategoryID).ToList();
        }
        public Stock GetByProductDetailID(int ProductDetailID)
        {
            return context.Stocks.Where(c => c.ProductDetailID == ProductDetailID).FirstOrDefault();
        }
        public void Insert(Stock StockObj)
        {
            context.Stocks.Add(StockObj);
            context.SaveChanges();
        }

        public void Update(Stock StockObj)
        {
            context.Entry(StockObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.Stocks.Where(c => c.StockID == id).FirstOrDefault();
            context.Stocks.Remove(search);
            context.SaveChanges();
        }

        public int GetStockLevelByProductDetailID(int ProductDetailID)
        {           
          int level =  context.Stocks.Where(c => c.ProductDetailID == ProductDetailID).Select(x => x.StockLevel).FirstOrDefault();
           
            return level;
        }

    }
}
