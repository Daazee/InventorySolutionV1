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
    [RoutePrefix("api/Transaction")]
    public class TransactionController : ApiController
    {
        SalesBs salesBs = new SalesBs();
        Sales salesObjMain = new Sales();

        [HttpPost]
        [Route("MakeSale")]
        public IHttpActionResult PostProductCategory(Sales SalesObj)
        {
            string SessionTransactionNo="";
            if (SalesObj.HeaderDetail == "H")
            {
                salesObjMain.TransactionNo = GenerateTransNo();
            }
            else
            {
                salesObjMain.TransactionNo = SessionTransactionNo;
            }
            salesObjMain.ProductCategoryID = SalesObj.ProductCategoryID;
            salesObjMain.AmountPaid = Convert.ToDouble(SalesObj.AmountPaid);
            salesObjMain.ProductDetailID = SalesObj.ProductDetailID;
            salesObjMain.TotalAmount = Convert.ToDouble(SalesObj.TotalAmount);
            salesObjMain.TotalProductCostAmount = Convert.ToDouble(SalesObj.TotalProductCostAmount);
            salesObjMain.Quantity = SalesObj.Quantity;
            salesObjMain.CreatedBy = "admin";
            salesObjMain.CreatedOn = DateTime.Today;
            salesObjMain.ModifiedBy = "admin";
            salesObjMain.ModifiedOn = DateTime.Today;
            SessionTransactionNo = salesObjMain.TransactionNo;
            salesObjMain.HeaderDetail = SalesObj.HeaderDetail;
            salesBs.Insert(salesObjMain);
            return Ok(salesObjMain.TransactionNo);
            //return Json(new { transNo = salesObjMain.TransactionNo}, JsonRequestBehavior.AllowGet);
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
    }
}
