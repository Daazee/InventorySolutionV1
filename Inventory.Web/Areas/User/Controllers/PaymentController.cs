using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Model;
using Inventory.BLL;

namespace Inventory.Web.Areas.User.Controllers
{
    public class PaymentController : Controller
    {
        // GET: User/Payment
        PaymentDetailBs paymentDetailBs = new PaymentDetailBs();
        PaymentDetail PaymentDetailObj = new PaymentDetail();
        // GET: User/Payment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PaymentDetails(string PaymentNo)
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
            return View(paymentDetailBs.GetByPaymentNo(PaymentNo));
        }
    }
}