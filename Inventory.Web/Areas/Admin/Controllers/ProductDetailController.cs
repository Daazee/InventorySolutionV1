using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.BLL;
using Inventory.Model;
using System.Net;
using System.Net.Http;

namespace Inventory.Web.Areas.Admin.Controllers
{
    public class ProductDetailController : Controller
    {
        ProductCategoryBs productCategoryBs = new ProductCategoryBs();
        ProductDetailBs productDetailBs = new ProductDetailBs();
        ProductDetail ProductDetailObj = new ProductDetail();
        HttpClient client = new HttpClient();
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductEntry()
        {
            ViewBag.ProudctCategory = new SelectList(productCategoryBs.ListAll(), "ProductCategoryID", "ProductCategoryName");
            return View(productDetailBs.ListAll());
        }

        [HttpPost]
        public ActionResult ProductEntry(FormCollection collection)
        {
            ViewBag.ProudctCategory = new SelectList(productCategoryBs.ListAll(), "ProductCategoryID", "ProductCategoryName");
            return View();
        }

        public JsonResult GetProductsByCategoryID (int ProductCategoryID)
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
                Price = x.Price

            });
            return Json(ProductDetailResult, JsonRequestBehavior.AllowGet);
        }
    }
}