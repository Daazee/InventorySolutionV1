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
        StockBs stockBs = new StockBs();
        StockHistoryBs stockHistoryBs = new StockHistoryBs();
        IEnumerable<ProductDetailNonCyclical> ProductDetailResult { get; set; }

        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult PostProduct(ProductDetail ProductDetailObj)
        {
            var product = productDetailBs.GetProductByCategoryIdAndProductName(ProductDetailObj.ProductCategoryID, ProductDetailObj.ProductName);
            if (product != null)
                return Ok("Product already exist"); ;
            ProductDetailObj.ModifiedBy = ProductDetailObj.CreatedBy = "admin";
            ProductDetailObj.ModifiedOn = ProductDetailObj.CreatedOn = DateTime.Today;
            ProductDetailObj.Flag = ProductDetailObj.Flag;
            int productId = productDetailBs.Insert(ProductDetailObj);

            //Added newly created product to stock if stock is greater than level is greater than zero
            if (ProductDetailObj.StockLevel > 0)
            {
                Stock StockObj = new Stock();
                StockHistory StockHistoryObj = new StockHistory();
                
                StockHistoryObj.ProductCategoryID = StockObj.ProductCategoryID = ProductDetailObj.ProductCategoryID;
                StockHistoryObj.ProductDetailID = StockObj.ProductDetailID = productId;
                StockObj.StockLevel = ProductDetailObj.StockLevel;
                //Get stock level before delivery
                int CurrentStockLevel = stockBs.GetStockLevelByProductDetailID(StockObj.ProductDetailID);
                StockHistoryObj.UnitAsAtDelievery = CurrentStockLevel;
                StockHistoryObj.UnitReceived = StockObj.StockLevel;
                StockObj.StockLevel += CurrentStockLevel;

                StockHistoryObj.CreatedBy = StockObj.CreatedBy = "admin";
                StockHistoryObj.CreatedOn = StockObj.CreatedOn = DateTime.Today;
                StockHistoryObj.ModifiedOn = StockObj.ModifiedOn = DateTime.Today;
                StockHistoryObj.ModifiedBy = StockObj.ModifiedBy = "admin";


                var StockExist = stockBs.GetByProductDetailID(StockObj.ProductDetailID);
                if (StockExist == null)
                {
                    StockHistoryObj.Flag = StockObj.Flag = "A";
                    stockBs.Insert(StockObj);
                }

                stockHistoryBs.Insert(StockHistoryObj);

            }


            message = "Product added successfully";
            return Ok(message);
        }

        [HttpPatch]
        [Route("UpdateProduct")]
        public IHttpActionResult PatchProductCategory(ProductDetail ProductDetailObj)
        {
            if (string.IsNullOrEmpty(ProductDetailObj.ProductName))
            {
                return BadRequest("Product name must be supplied");
            }


            ProductDetailObj.ModifiedBy = "admin";
            ProductDetailObj.ModifiedOn = DateTime.Today;
            ProductDetailObj.Flag = ProductDetailObj.Flag;
            productDetailBs.Update(ProductDetailObj);
            message = "Product updated successfully";
            return Ok(message);
        }


        [HttpGet]
        [Route("GetProducts")]
        public IHttpActionResult GetProducts()
        {
            return Ok(productDetailBs.ListAll());
        }

        [HttpGet]
        [Route("GetProductById")]
        public IHttpActionResult GetProductById(int id)
        {
            return Ok(productDetailBs.GetById(id));
        }

        [HttpGet]
        [Route("GetProductsByCategoryID")]
        // public IHttpActionResult GetProducts(int ProductCategoryID)
        public IEnumerable<ProductDetailNonCyclical> GetProducts(int ProductCategoryID)
        {
            var result = productDetailBs.GetByProductCategoryID(ProductCategoryID);
            if (result == null)
            {
                return null;
            }
            var ProductDetailResult = result.Select(x => new ProductDetailNonCyclical
            {
                ProductCategoryID = x.ProductCategoryID,
                ProductDetailID = x.ProductDetailID,
                ProductName = x.ProductName,
                CostPrice = x.CostPrice,
                SellingPrice = x.SellingPrice

            });
            return ProductDetailResult;
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