﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Areas.Common.Controllers
{
    public class MenuController : Controller
    {
        // GET: Common/Menu
        public ActionResult Index()
        {
            return View();
        }
    }
}