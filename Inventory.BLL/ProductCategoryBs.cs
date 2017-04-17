using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
  public  class ProductCategoryBs
    {
        private ProductCategoryDA NewProductCategoryDA = new ProductCategoryDA();

        public IEnumerable<ProductCategory> ListAll()
        {
            return NewProductCategoryDA.ListAll();
        }

        public ProductCategory GetById(int id)
        {
            return NewProductCategoryDA.GetById(id);
        }

        public ProductCategory GetProductCategoryByName(string name)
        {
            return NewProductCategoryDA.GetProductCategoryByName(name);
        }
        public void Insert(ProductCategory ProductCategoryBsObj)
        {
            NewProductCategoryDA.Insert(ProductCategoryBsObj);
        }

        public void Update(ProductCategory ProductCategoryBsObj)
        {
            var ProductCategoryExist = NewProductCategoryDA.GetById(ProductCategoryBsObj.ProductCategoryID);
            ProductCategoryExist.ProductCategoryName = ProductCategoryBsObj.ProductCategoryName;
            //ProductCategoryExist.ProductCategoryID = ProductCategoryBsObj.ProductCategoryID;
            ProductCategoryExist.Flag = ProductCategoryBsObj.Flag;
            NewProductCategoryDA.Update(ProductCategoryExist);
        }
    }
}
