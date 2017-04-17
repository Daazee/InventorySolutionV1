using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL

{
   public class StockHistoryBs
    {
        private StockHistoryDA NewStockHistoryDA = new StockHistoryDA();

        public IEnumerable<StockHistory> ListAll()
        {
            return NewStockHistoryDA.ListAll();
        }

        public StockHistory GetById(int id)
        {
            return NewStockHistoryDA.GetById(id);
        }

        public IEnumerable<StockHistory> GetByProductCategoryID(int ProductCategoryID)
        {
            return NewStockHistoryDA.GetByProductCategoryID(ProductCategoryID);
        }
        public IEnumerable<StockHistory> GetByProductDetailID(int ProductDetailID)
        {
            return NewStockHistoryDA.GetByProductDetailID(ProductDetailID);
        }
        public void Insert(StockHistory StockHistoryObj)
        {
            NewStockHistoryDA.Insert(StockHistoryObj);
        }

        public void Update(StockHistory StockHistoryObj)
        {
            NewStockHistoryDA.Update(StockHistoryObj);
        }

        public void Delete(int id)
        {
            NewStockHistoryDA.Delete(id);
        }
    }
}
