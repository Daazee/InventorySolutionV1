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

        public ProductDetail GetProductByCategoryIdAndProductName(int categoryId, string productName)
        {
           return NewProductDetailDA.GetProductByCategoryIdAndProductName(categoryId, productName);
        }

        public int Insert(ProductDetail ProductDetailBsObj)
        {
            return NewProductDetailDA.Insert(ProductDetailBsObj);
        }

        public void Update(ProductDetail ProductDetailBsObj)
        {
            var ProductDetailExist = NewProductDetailDA.GetById(ProductDetailBsObj.ProductDetailID);
            ProductDetailExist.ProductName = ProductDetailBsObj.ProductName;
            ProductDetailExist.SellingPrice = ProductDetailBsObj.SellingPrice;
            ProductDetailExist.CostPrice = ProductDetailBsObj.CostPrice;
            ProductDetailExist.ReorderLevel = ProductDetailBsObj.ReorderLevel;
            ProductDetailExist.ModifiedBy = ProductDetailBsObj.ModifiedBy;
            ProductDetailBsObj.ModifiedOn = ProductDetailBsObj.ModifiedOn;
            ProductDetailExist.Flag = ProductDetailBsObj.Flag;
            NewProductDetailDA.Update(ProductDetailExist);
        }

        public void UpdateStcokLevel(ProductDetail ProductDetailBsObj)
        {
            var productDetailExist = NewProductDetailDA.GetById(ProductDetailBsObj.ProductDetailID);
            productDetailExist.StockLevel = ProductDetailBsObj.StockLevel;
            NewProductDetailDA.UpdateStcokLevel(productDetailExist);
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
