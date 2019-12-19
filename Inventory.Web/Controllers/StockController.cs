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
    [RoutePrefix("api/Stock")]
    public class StockController : ApiController
    {
        // GET api/<controller>
        private string message;
        StockBs stockBs = new StockBs();
        StockHistoryBs stockHistoryBs = new StockHistoryBs();
        ProductDetail productDetail = new ProductDetail();
        ProductDetailBs productDetailBs = new ProductDetailBs();

        [HttpPost]
        [Route("StockEntry")]
        public string PostStock(Stock StockObj)
        {
            try
            {
                StockHistory StockHistoryObj = new StockHistory();


                StockHistoryObj.ProductCategoryID = StockObj.ProductCategoryID;
                productDetail.ProductDetailID = StockHistoryObj.ProductDetailID = StockObj.ProductDetailID;

                //Get stock level before delievery
                int CurrentStockLevel = stockBs.GetStockLevelByProductDetailID(StockObj.ProductDetailID);
                StockHistoryObj.UnitAsAtDelievery = CurrentStockLevel;
                StockHistoryObj.UnitReceived = StockObj.StockLevel;
                productDetail.StockLevel = StockObj.StockLevel += CurrentStockLevel;

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
                else
                {

                    StockHistoryObj.Flag = StockObj.Flag = "C";
                    stockBs.Update(StockObj);
                }

                stockHistoryBs.Insert(StockHistoryObj);
                productDetailBs.UpdateStcokLevel(productDetail);
                message = "Stock updated successfully";
            }
            catch (Exception ex)
            {
                message = "Error occurred when trying to save this record"; 
               
            }
            return message;
        }

        [HttpGet]
        [Route("GetStockLevel")]
        public int GetStockLevel(int ProductDetailID)
        {
            int Level = stockBs.GetStockLevelByProductDetailID(ProductDetailID);
            return Level;
        }

    }
}