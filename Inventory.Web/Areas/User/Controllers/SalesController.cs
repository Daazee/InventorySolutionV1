using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.BLL;
using Inventory.Model;

namespace Inventory.Web.Areas.User.Controllers
{
    public class SalesController : Controller
    {
        ProductCategoryBs productCategoryBs = new ProductCategoryBs();
        ProductDetailBs productDetailBs = new ProductDetailBs();
        SalesBs salesBs = new SalesBs();
        Sales salesObjMain = new Sales();
       

        StockBs stockBs = new StockBs();
        Stock StockObj = new Stock();

        CompanyDetailBs companyDetailBs = new CompanyDetailBs();
        CompanyDetail CompanyDetailObj = new CompanyDetail();
        PaymentDetailBs paymentDetailBs = new PaymentDetailBs();
        PaymentDetail PaymentDetailObj = new PaymentDetail();
        CompanyLogoBs companyLogoBs = new CompanyLogoBs();
        CompanyLogo CompanyLogoObj = new CompanyLogo();
        UserBs userBs = new UserBs();
        Receipt receipt = new Receipt();
        // GET: User/Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SalesEntry()
        {
            ViewBag.ProudctCategory = new SelectList(productCategoryBs.ListAll(), "ProductCategoryID", "ProductCategoryName");
            //ViewBag.ProudctName = new SelectList(productDetailBs.ListAll(), "ProductDetailID", "ProductName");
            return View();
        }

        [HttpGet]
        public ActionResult _AddItem()
        {
            //try
            //{
            //    ViewBag.UserId = Session["Username"].ToString();
            //}
            //catch
            //{
            //    Session["ConfirmLogin"] = "You must login first";
            //    return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            //}
            ViewBag.ProudctCategory = new SelectList(productCategoryBs.ListAll(), "ProductCategoryID", "ProductCategoryName");
           // ViewBag.ProudctName = new SelectList(productDetailBs.ListAll(), "ProductDetailID", "ProductName");

            return PartialView();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult _AddItem(FormCollection collection)
        {
            ViewBag.ProudctCategory = new SelectList(productCategoryBs.ListAll(), "ProductCategoryID", "ProductCategoryName");
            //ViewBag.ProudctName = new SelectList(productDetailBs.ListAll(), "ProductDetailID", "ProductName");

            return PartialView();
        }

        public JsonResult MakeSales(Sales SalesObj)
        {
            //try
            //{
            //    ViewBag.UserId = Session["Username"].ToString();
            //}
            //catch
            //{
            //    ViewBag.UserId = "";
            //}
            try
            {
                if (SalesObj.HeaderDetail == "H")
                {
                    PaymentDetailObj.PaymentNo = salesObjMain.TransactionNo = GenerateTransNo();
                    PaymentDetailObj.SalesAmount = Convert.ToDouble(SalesObj.TotalProductCostAmount);
                    PaymentDetailObj.CreatedBy = "admin"; //ViewBag.UserId;
                    PaymentDetailObj.Flag = "A";
                    PaymentDetailObj.KeyDate = DateTime.Today;
                    paymentDetailBs.Insert(PaymentDetailObj);
                }
                else
                {
                    salesObjMain.TransactionNo = Session["TransactionNo"].ToString(); ;
                }
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
                StockObj.ProductCategoryID = salesObjMain.ProductCategoryID = SalesObj.ProductCategoryID;
                StockObj.ProductDetailID = salesObjMain.ProductDetailID = SalesObj.ProductDetailID;
                salesObjMain.Rate = Convert.ToDouble(SalesObj.Rate);
                salesObjMain.Quantity = SalesObj.Quantity;
                salesObjMain.TotalAmount = Convert.ToDouble(SalesObj.TotalAmount);
                salesObjMain.AmountPaid = Convert.ToDouble(SalesObj.AmountPaid);
                salesObjMain.TotalProductCostAmount = Convert.ToDouble(SalesObj.TotalProductCostAmount);
                Session["TransactionNo"] = salesObjMain.TransactionNo;
                salesObjMain.HeaderDetail = SalesObj.HeaderDetail;
                salesObjMain.CreatedBy = "admin";
                salesObjMain.CreatedOn = DateTime.Today;
                StockObj.ModifiedBy = salesObjMain.ModifiedBy = "admin";
                StockObj.ModifiedOn = salesObjMain.ModifiedOn = DateTime.Today;
                salesBs.Insert(salesObjMain);

                int CurrentStockLevel = stockBs.GetStockLevelByProductDetailID(StockObj.ProductDetailID);
                StockObj.StockLevel = CurrentStockLevel - SalesObj.Quantity;
                stockBs.Update(StockObj);

                return Json(new { transNo = salesObjMain.TransactionNo }, JsonRequestBehavior.AllowGet);
        }

        public string GenerateTransNo()
        {
            string TransNo = "TN";
            string currentDay = DateTime.Today.Day.ToString();
            string currentMonth = DateTime.Today.Month.ToString();
            string currentYear = DateTime.Today.Year.ToString();

            if (currentDay.Length < 2)
                currentDay = "0" + currentDay;
            if (currentMonth.Length < 2)
                currentMonth = "0" + currentMonth;
            TransNo = TransNo + "/" + currentMonth + currentDay + currentYear;
            int LastTransNo = salesBs.GetLastTransNo(TransNo);
            int NewTransNo = LastTransNo + 1;
            TransNo = TransNo + "/" + NewTransNo.ToString();
            return TransNo;
        }

        [HttpGet]
        public ActionResult PrintReceipt()
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
            if (Session["TransactionNo"] != null)
            {
                salesObjMain.TransactionNo = Session["TransactionNo"].ToString();
            }
            return View(salesObjMain);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PrintReceipt(FormCollection frm)
        {
           
            Session["FinalTransNo"] = frm["TransactionNo"];
            return RedirectToAction("SalesReceipt");
        }

        [HttpGet]
        public ActionResult SalesReceipt(string TNo)
        {
            string GetUserOnce = "Y";
            Model.User UserReceipt = new Model.User();
            CompanyLogo CompanyLogoReceipt = new CompanyLogo();
            List<Sales> SalesReceipt = new List<Sales>();
            List<CompanyDetail> CompanyDetailReceipt = new List<CompanyDetail>();
            List<PaymentDetail> PaymentDetailReceipt = new List<PaymentDetail>();
            //try
            //{
            //    ViewBag.UserId = Session["Username"].ToString();
            //}
            //catch
            //{
            //    Session["ConfirmLogin"] = "You must login first";
            //    return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            //}
            if (Session["FinalTransNo"] != null)
            {
                SalesReceipt = salesBs.GetByTransactionNo(Session["FinalTransNo"].ToString()).ToList();
                CompanyDetailReceipt = companyDetailBs.ListAll().ToList();
                PaymentDetailReceipt = paymentDetailBs.GetByPaymentNo(Session["FinalTransNo"].ToString()).ToList();
                CompanyLogoReceipt = companyLogoBs.GetCompanyLogo();
   
                if (GetUserOnce == "Y")
                {
                    foreach (var item in SalesReceipt)
                        UserReceipt = userBs.GetByUsername(item.CreatedBy);
                    GetUserOnce = "N";
                }
               
                receipt.SalesReceipt = SalesReceipt;
                receipt.CompanyDetailReceipt = CompanyDetailReceipt;
                receipt.UserReceipt = UserReceipt;
                receipt.PaymentDetailReceipt = PaymentDetailReceipt;
                receipt.CompanyLogoReceipt = CompanyLogoReceipt;
                //receipt.CustomerReceipt = CustomerReceipt;
                return View(receipt);

            }
            return View();
        }

    }
}