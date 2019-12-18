using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL

{
    public class ProductDetailDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<ProductDetail> ListAll()
        {
            return context.ProductDetails.ToList();
        }

        public ProductDetail GetById(int id)
        {
            return context.ProductDetails.Where(c => c.ProductDetailID == id).FirstOrDefault();
        }

        public ProductDetail GetProductByName(string name)
        {
            return context.ProductDetails.Where(c => c.ProductName == name).FirstOrDefault();
        }
        public IEnumerable<ProductDetail> GetByProductCategoryID(int CategoryCode)
        {
            return context.ProductDetails.Where(c => c.ProductCategoryID == CategoryCode).ToList();
        }

        public ProductDetail GetProductByCategoryIdAndProductName(int categoryId, string productName)
        {
            return context.ProductDetails.Where(c => c.ProductName == productName && c.ProductCategoryID == categoryId).FirstOrDefault();
        }
        public int Insert(ProductDetail ProductDetailObj)
        {
            context.ProductDetails.Add(ProductDetailObj);
            context.SaveChanges();
            return ProductDetailObj.ProductDetailID;
        }

        public void Update(ProductDetail ProductDetailObj)
        {
            context.Entry(ProductDetailObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.ProductDetails.Where(c => c.ProductDetailID == id).FirstOrDefault();
            context.ProductDetails.Remove(search);
            context.SaveChanges();
        }

        public double GetPrice(int ProductDetailID)
        {
            double price = context.ProductDetails.Where(c => c.ProductDetailID == ProductDetailID).Select(x => x.SellingPrice).FirstOrDefault();

            return price;
        }
    }
}
