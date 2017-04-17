using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
  public  class ProductDetailBs
    {
        private ProductDetailDA NewProductDetailDA = new ProductDetailDA();

        public IEnumerable<ProductDetail> ListAll()
        {
            return NewProductDetailDA.ListAll();
        }

        public ProductDetail GetById(int id)
        {
            return NewProductDetailDA.GetById(id);
        }

        public ProductDetail GetProductByName(string name)
        {
            return NewProductDetailDA.GetProductByName(name);
        }

        public IEnumerable<ProductDetail> GetByProductCategoryID(int CategoryCode)
        {
            return NewProductDetailDA.GetByProductCategoryID(CategoryCode);
        }
        public void Insert(ProductDetail ProductDetailBsObj)
        {
            NewProductDetailDA.Insert(ProductDetailBsObj);
        }

        public void Update(ProductDetail ProductDetailBsObj)
        {
            var ProductDetailExist = NewProductDetailDA.GetById(ProductDetailBsObj.ProductDetailID);
            ProductDetailExist.ProductName = ProductDetailBsObj.ProductName;
           // ProductDetailExist.ProductDetailID = ProductDetailBsObj.ProductDetailID;
            ProductDetailExist.Flag = ProductDetailBsObj.Flag;
            NewProductDetailDA.Update(ProductDetailExist);
        }

        public void Delete(int ProductDetailID)
        {
            NewProductDetailDA.Delete(ProductDetailID);
        }

        public double GetPrice(int ProductDetailID)
        {
            double Price = NewProductDetailDA.GetPrice(ProductDetailID);
            return Price;
        }
    }
}
