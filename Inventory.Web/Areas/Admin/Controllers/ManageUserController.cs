using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Model;
using Inventory.BLL;

namespace Inventory.Web.Areas.Admin.Controllers
{
    public class ManageUserController : Controller
    {
        UserBs userBs = new UserBs();
        Model.User UserObj = new Model.User();

        RoleBs roleBs = new RoleBs();
        // GET: Admin/ManageUser
        public ActionResult ListUsers()
        {
            try
            {
                ViewBag.UserId = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }

            return View(userBs.ListAll());
        }

        public ActionResult UpdateUser(string username)
        {
            try
            {
                ViewBag.UserId = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            ViewBag.Roles = new SelectList(roleBs.GetAllRoles(), "RoleID", "RoleName");
            return View(userBs.GetByUsername(username));
        }

        [HttpPost] 
        public ActionResult UpdateUser(FormCollection collection)
        {
            try
            {
                ViewBag.UserId = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            UserObj.UserID = Convert.ToInt32(collection["UserID"]);
            UserObj.Status = Convert.ToInt32(collection["Status"]);
            UserObj.RoleID = Convert.ToInt32(collection["RoleID"]);
            UserObj.Password = collection["NewPassword"];
            ViewBag.Roles = new SelectList(roleBs.GetAllRoles(), "RoleID", "RoleName");
            if (collection["NewPassword"] != "" && collection["NewConfirmPassword"] != "")
            {
                if (collection["NewPassword"] != collection["NewConfirmPassword"])
                {
                    ViewData["Message"] = "Password does not matches";
                    return View(UserObj);
                }
            }

            UserObj.Flag = "C";
            userBs.Update(UserObj);
            ViewData["Message"] = "Record updated successfully";
            return View(UserObj);
        }

    }
}