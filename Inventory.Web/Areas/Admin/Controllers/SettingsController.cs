using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.BLL;
using Inventory.Model;

namespace Inventory.Web.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        ProductCategoryBs productCategoryBs = new ProductCategoryBs();
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }
    }
}