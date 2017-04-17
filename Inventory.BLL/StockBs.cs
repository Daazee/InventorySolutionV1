using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL

{
   public class StockBs
    {
        private StockDA NewStockDA = new StockDA();

        public IEnumerable<Stock> ListAll()
        {
            return NewStockDA.ListAll();
        }

        public Stock GetById(int id)
        {
            return NewStockDA.GetById(id);
        }

        public IEnumerable<Stock> GetByProductCategoryID(int ProductCategoryID)
        {
            return NewStockDA.GetByProductCategoryID(ProductCategoryID);
        }
        public Stock GetByProductDetailID(int ProductDetailID)
        {
            return NewStockDA.GetByProductDetailID(ProductDetailID);
        }
        public void Insert(Stock StockObj)
        {
            NewStockDA.Insert(StockObj);
        }

        public void Update(Stock StockObj)
        {
            var ExistingStock = GetByProductDetailID(StockObj.ProductDetailID);
            if (ExistingStock != null)
            {
                ExistingStock.StockLevel = StockObj.StockLevel;
                ExistingStock.ModifiedBy = StockObj.ModifiedBy;
                ExistingStock.ModifiedOn = StockObj.ModifiedOn;
                NewStockDA.Update(ExistingStock);
            }
        }

        public void Delete(int id)
        {
            NewStockDA.Delete(id);
        }

        public int GetStockLevelByProductDetailID(int ProductDetailID)
        {
            return NewStockDA.GetStockLevelByProductDetailID(ProductDetailID);
        }
    }
}
