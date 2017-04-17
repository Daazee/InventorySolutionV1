using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.Entity;

namespace Inventory.DAL

{
   public class ProductCategoryDA
    {
        public InventoryContext context = new InventoryContext();
        public IEnumerable<ProductCategory> ListAll()
        {
            return context.ProductCategory.ToList();
        }

        public ProductCategory GetById(int id)
        {
            return context.ProductCategory.Where(c => c.ProductCategoryID == id).FirstOrDefault();
        }

        public ProductCategory GetProductCategoryByName(string name)
        {
            return context.ProductCategory.Where(c => c.ProductCategoryName == name).FirstOrDefault();
        }
        public void Insert(ProductCategory ProductCategoryObj)
        {
            context.ProductCategory.Add(ProductCategoryObj);
            context.SaveChanges();
        }

        public void Update(ProductCategory ProductCategoryObj)
        {
            context.Entry(ProductCategoryObj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var search = context.ProductCategory.Where(c => c.ProductCategoryID == id).FirstOrDefault();
            context.ProductCategory.Remove(search);
            context.SaveChanges();
        }
    }
}
