using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL

{
   public class SalesBs
    {
        private SalesDA NewSalesDA = new SalesDA();

        public IEnumerable<Sales> ListAll()
        {
            return NewSalesDA.ListAll();
        }

        public Sales GetById(int id)
        {
            return NewSalesDA.GetById(id);
        }

        public IEnumerable<Sales> GetByProductCategoryID(int ProductCategoryID)
        {
            return NewSalesDA.ProductCategoryID(ProductCategoryID);
        }
        public IEnumerable<Sales> GetByProductDetailID(int ProductDetailID)
        {
            return NewSalesDA.GetByProductDetailID(ProductDetailID);
        }
        public void Insert(Sales SalesObj)
        {
            NewSalesDA.Insert(SalesObj);
        }

        public void Update(Sales SalesObj)
        {
            NewSalesDA.Update(SalesObj);
        }

        public void Delete(int id)
        {
            NewSalesDA.Delete(id);
        }

        public int GetLastTransNo(string TNo)
        {
            return NewSalesDA.GetLastTransNo(TNo);
        }

        public IEnumerable<Sales> GetByTransactionNo(string TransNo)
        {
            return NewSalesDA.GetByTransactionNo(TransNo);
        }

    }
}
