using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory.Model;
using Inventory.BLL;

namespace Inventory.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/ProductDetail")]
    public class ProductDetailController : ApiController
    {
        private string message;
        ProductDetailBs productDetailBs = new ProductDetailBs();
        IEnumerable<ProductDetailNonCyclical> ProductDetailResult { get; set; }
       
        [HttpPost]
        [Route("AddProduct")]
        public string PostProduct(ProductDetail ProductDetailObj)
        {
            ProductDetailObj.CreatedBy = "admin";
            ProductDetailObj.KeyDate = DateTime.Today;
            ProductDetailObj.Flag = "A";
            productDetailBs.Insert(ProductDetailObj);
            message = "Product added successfully";
            return message;
        }

        [HttpGet]
        [Route("GetProducts")]
        public IHttpActionResult GetProducts()
        {
            return Ok(productDetailBs.ListAll());
        }

        [HttpGet]
        [Route("GetProductsByCategoryID")]
       // public IHttpActionResult GetProducts(int ProductCategoryID)
             public IEnumerable<ProductDetailNonCyclical> GetProducts(int ProductCategoryID)
        {
            var result = productDetailBs.GetByProductCategoryID(ProductCategoryID);
            if(result == null)
            {
                return null;
            }
          var  ProductDetailResult = result.Select(x => new ProductDetailNonCyclical
          {
              ProductCategoryID =  x.ProductCategoryID,
              ProductDetailID = x.ProductDetailID,
              ProductName = x.ProductName,
              Price = x.Price

          });
            return ProductDetailResult;
           // return OK(productDetailBs.GetByProductCategoryID(ProductCategoryID));
        }


        [HttpGet]
        [Route("GetPrice")]
        public double GetPrice(int ProductDetailID)
        {
            double Price = productDetailBs.GetPrice(ProductDetailID);
            return Price;
        }

        [HttpGet]
        [Route("GetProductByName")]
        public IHttpActionResult GetProductByName(string name)
        {
            return Ok(productDetailBs.GetProductByName(name));
        }

        //[HttpDelete]
        [HttpGet]
        [Route("DeleteProduct")]
        public void DeleteProduct(int ProductDetailID)
        {
           productDetailBs.Delete(ProductDetailID);
        }
    }
}