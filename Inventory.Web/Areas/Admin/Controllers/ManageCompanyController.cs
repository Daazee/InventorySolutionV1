using Inventory.BLL;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Web.Areas.Admin.Controllers
{
    public class ManageCompanyController : Controller
    {
        // GET: Admin/ManageCompany
        CompanyDetailBs companyDetailBs = new CompanyDetailBs();
        CompanyDetail CompanyDetailObj = new CompanyDetail();
        CompanyLogoBs companyLogoBs = new CompanyLogoBs();
        CompanyLogo CompanyLogoObj = new CompanyLogo();

        HttpPostedFileBase postedImage;
        private static byte[] byteImageData;
        public ActionResult CompanyRegistration()
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
            return View(companyDetailBs.ListAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyRegistration(FormCollection collection)
        {
            if (ModelState.IsValid)
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

                if (collection["Company_Password"] == collection["ConfirmPassword"])
                {

                    CompanyDetailObj.CompanyName = collection["CompanyName"];
                    CompanyDetailObj.CompanyShortName = collection["CompanyShortName"];
                    CompanyDetailObj.CompanyAddress = collection["CompanyAddress"];
                    CompanyDetailObj.CompanyPhone1 = collection["CompanyPhone1"];
                    CompanyDetailObj.CompanyPhone2 = collection["CompanyPhone2"];
                    CompanyDetailObj.CompanyEmail = collection["CompanyEmail"];
                    CompanyDetailObj.CompanyUsername = collection["CompanyUsername"];
                    CompanyDetailObj.CompanyPassword = collection["CompanyPassword"];
                    CompanyDetailObj.CreatedBy = "admin";
                    CompanyDetailObj.CreatedOn = DateTime.Now;
                    CompanyDetailObj.Flag = "A";
                    CompanyDetailObj.ModifiedBy = "admin";
                    CompanyDetailObj.ModifiedOn = DateTime.Now;
                    companyDetailBs.Insert(CompanyDetailObj);
                    ViewData["Message"] = "Record save successfully";
                    return View(companyDetailBs.ListAll());
                }
                else
                {
                    ViewData["Message"] = "Password does not matches";
                    //return RedirectToAction("LaundryManRegistration");
                    return View(CompanyDetailObj);
                }
            }
            else
            {
                return View();
            }
            //return View();
        }

        [HttpGet]
        public ActionResult CompanyRegUpdate(int id = 0)
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
            return View(companyDetailBs.GetById(id));
        }

        [HttpPost]
        public ActionResult CompanyRegUpdate(int id, FormCollection collection)
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
            CompanyDetailObj.CompanyID = Convert.ToInt32(collection["CompanyID"]);
            CompanyDetailObj.CompanyName = collection["CompanyName"];
            CompanyDetailObj.CompanyShortName = collection["CompanyShortName"];
            CompanyDetailObj.CompanyAddress = collection["CompanyAddress"];
            CompanyDetailObj.CompanyPhone1 = collection["CompanyPhone1"];
            CompanyDetailObj.CompanyPhone2 = collection["CompanyPhone2"];
            CompanyDetailObj.CompanyEmail = collection["CompanyEmail"];
            CompanyDetailObj.CompanyUsername = collection["CompanyUsername"];
            CompanyDetailObj.CompanyPassword = collection["CompanyPassword"];
            CompanyDetailObj.Flag = "C";
            CompanyDetailObj.ModifiedBy = ViewBag.UserId;
            CompanyDetailObj.ModifiedOn = DateTime.Now;
            companyDetailBs.Update(CompanyDetailObj);
            ViewData["Message"] = "Record save successfully";
            return RedirectToAction("CompanyRegistration");
        }


        [HttpGet]
        public ActionResult UploadCompanyLogo()
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
            var result = companyLogoBs.GetCompanyLogo();
            if (result != null)
            {
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public ActionResult UploadCompanyLogo(FormCollection collection, HttpPostedFileBase image)
        {
            try
            {
                ViewBag.Username = Session["Username"].ToString();
            }
            catch
            {
                Session["ConfirmLogin"] = "You must login first";
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    CompanyLogoObj.Username = ViewBag.Username;
                    postedImage = image;
                    byteImageData = ByteImage(postedImage.FileName, new string[] { ".gif", ".jpg", ".bmp"}, image);
                    CompanyLogoObj.Logo = byteImageData;
                    var result = companyLogoBs.GetCompanyLogo();
                    if (result == null)
                    {
                        CompanyLogoObj.CompanyLogoId = Guid.NewGuid().ToString("N");
                        CompanyLogoObj.Key_Date = DateTime.Today;
                        CompanyLogoObj.Flag = "A";
                        companyLogoBs.Insert(CompanyLogoObj);
                        return RedirectToAction("UploadCompanyLogo");
                    }
                    else
                    {
                        CompanyLogoObj.Flag = "C";
                        companyLogoBs.Update(CompanyLogoObj);
                        return RedirectToAction("UploadCompanyLogo");
                    }
                }
            }
            else
            {
                return View(CompanyLogoObj);
            }
            return View();
        }


        private static byte[] ReadImage(string p_postedImageFileName, string[] p_fileType)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);
                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] image = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    return image;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static byte[] ByteImage(string p_postedImageFileName, string[] p_fileType, HttpPostedFileBase img)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);
                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension.ToLower())
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                        return array;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}