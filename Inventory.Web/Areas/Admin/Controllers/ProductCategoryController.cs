using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.BLL;
using Inventory.Model;

namespace Inventory.Web.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryBs productCategoryBs = new ProductCategoryBs();
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductCategoryEntry()
        {
            return View(productCategoryBs.ListAll());
        }
    }
}