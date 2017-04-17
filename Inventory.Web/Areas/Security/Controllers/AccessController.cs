using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Model;
using Inventory.BLL;


namespace Inventory.Web.Areas.Security.Controllers
{
    public class AccessController : Controller
    {
        UserBs userBs = new UserBs();
        Model.User UserObj = new Model.User();
        CompanyDetailBs companyDetailBs = new CompanyDetailBs();

        // GET: Security/Access
        public ActionResult Index()
        {
            return View();
        }

        // GET: Security/Access/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Security/Access/Create
        public ActionResult Login()
        {
            var CompanyShortName = companyDetailBs.DisplayCompanyShortName();
            ViewBag.CompanyShortName = CompanyShortName;
            return View();
        }

        // POST: Security/Access/Create
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Session["ConfirmLogin"] = "";
                UserObj.Username = collection["Username"];
                UserObj.Password = collection["Password"];
                //var result = userBs.Login(UserObj.Username, UserObj.Password);
                //if (result == true)
                //{
                //    Session["Username"] = collection["Username"];
                //    Session["ConfirmLogin"] = "";
                //    return RedirectToAction("Index", new { Controller = "Menu", Area = "Common" });
                //}
                //else
                //{
                //    ViewData["Message"] = result;
                //    return View(UserObj);
                //}
                var result= userBs.LoginNew(UserObj.Username, UserObj.Password);
                if (result == "")//No error message
                {
                    var CompanyName = companyDetailBs.DisplayCompanyName();
                    Session["CompanyName"] = CompanyName;
                    Session["Username"] = collection["Username"];
                    Session["ConfirmLogin"] = "";
                    return RedirectToAction("Index", new { Controller = "Menu", Area = "Common" });
                }
                else
                {
                    ViewData["Message"] = result;
                    return View(UserObj);
                }
            }
            else
            {
                return View(UserObj);
            }
            // return View();
        }

        public ActionResult Logout()
        {
            if (Session["Username"] != null)

            {
                Session.Remove(Session["Username"].ToString());
                Session.Remove(Session["ConfirmLogin"].ToString());
                Session.Abandon();
            }
            return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });

        }
        // GET: Security/Access/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Security/Access/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Access/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Security/Access/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
