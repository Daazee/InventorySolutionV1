using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Model;
using Inventory.BLL;
using System.IO;

namespace Inventory.Web.Areas.Security.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Security/Registration
        UserBs userBs = new UserBs();
        Model.User UserObj = new Model.User();

        CompanyDetailBs companyDetailBs = new CompanyDetailBs();
        CompanyDetail CompanyDetailObj = new CompanyDetail();
        CompanyLogoBs NewCompanyLogoBs = new CompanyLogoBs();
        CompanyLogo CompanyLogoObj = new CompanyLogo();

        // GET: Security/Registration
       
        string message;


        HttpPostedFileBase postedImage;
        private static byte[] byteImageData;
        public ActionResult ListUsers(int status)
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
            //if (status == null)
            //{
            //    status = "P";
            //}
            //ViewBag.status = status;
            //if (status == "L")
            //{
            //    return View(userBs.ListAll());
            //}

            return View(userBs.ListAllByStatus(status));
        }

        // GET: Security/Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Security/Registration/Create
        public ActionResult UserRegistration(string ValidateReg = "")
        {
            if (ValidateReg != "Y")
            {
                return RedirectToAction("Login", new { Area = "Security", Controller = "Access" });
            }
            return View();
        }

        // POST: Security/Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserRegistration(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                UserObj.Surname = collection["Surname"];
                UserObj.Othername = collection["Othername"];
                UserObj.Sex = collection["Sex"];
                UserObj.PhoneNumber = collection["PhoneNumber"];
                UserObj.Address = collection["Address"];
                UserObj.Username = collection["Username"];
                UserObj.Password = collection["Password"];


                if (collection["Password"] == collection["ConfirmPassword"])
                {
                    var result = userBs.GetByUsername(UserObj.Username);

                    if (result != null)
                    {
                        ViewData["Message"] = "Username already exist";
                        return View(UserObj);
                    }
                    UserObj.Status = 0;
                    UserObj.Keydate = DateTime.Now;
                    UserObj.Flag = "A";
                    userBs.Insert(UserObj);
                    ViewData["Message"] = "Record save successfully";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "Password does not matches";
                    //return RedirectToAction("LaundryManRegistration");
                    return View(UserObj);
                }
            }
            else
            {
                return View();
            }
            //return View();
        }


        
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

                    CompanyDetailObj.CompanyName = collection["Company_Name"];
                    CompanyDetailObj.CompanyShortName = collection["Company_ShortName"];
                    CompanyDetailObj.CompanyAddress = collection["Company_Address"];
                    CompanyDetailObj.CompanyPhone1 = collection["Company_Phone1"];
                    CompanyDetailObj.CompanyPhone2 = collection["Company_Phone2"];
                    CompanyDetailObj.CompanyEmail = collection["Company_Email"];
                    CompanyDetailObj.CompanyUsername = collection["Company_Username"];
                    CompanyDetailObj.CompanyPassword = collection["Company_Password"];
                    CompanyDetailObj.CreatedBy = "admin";
                    CompanyDetailObj.CreatedOn = DateTime.Now;
                    CompanyDetailObj.ModifiedBy = "admin";
                    CompanyDetailObj.ModifiedOn = DateTime.Now;
                    CompanyDetailObj.Flag = "A";
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

            CompanyDetailObj.CompanyID = Convert.ToInt32(collection["Company_Id"]);
            CompanyDetailObj.CompanyName = collection["Company_Name"];
            CompanyDetailObj.CompanyShortName = collection["Company_ShortName"];
            CompanyDetailObj.CompanyAddress = collection["Company_Address"];
            CompanyDetailObj.CompanyPhone1 = collection["Company_Phone1"];
            CompanyDetailObj.CompanyPhone2 = collection["Company_Phone2"];
            CompanyDetailObj.CompanyEmail = collection["Company_Email"];
            //CompanyDetailObj.Company_Username = collection["Company_Username"];
            //CompanyDetailObj.Company_Password = collection["Company_Password"];
            CompanyDetailObj.ModifiedBy = "admin";
            CompanyDetailObj.ModifiedOn = DateTime.Today;
            CompanyDetailObj.Flag = "C";
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
            var result = NewCompanyLogoBs.GetCompanyLogo();
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
                    byteImageData = ByteImage(postedImage.FileName, new string[] { ".gif", ".jpg", ".bmp" }, image);
                    CompanyLogoObj.Logo = byteImageData;
                    var result = NewCompanyLogoBs.GetCompanyLogo();
                    if (result == null)
                    {
                        CompanyLogoObj.CompanyLogoId = Guid.NewGuid().ToString("N");
                        CompanyLogoObj.Key_Date = DateTime.Today;
                        CompanyLogoObj.Flag = "A";
                        NewCompanyLogoBs.Insert(CompanyLogoObj);
                        return RedirectToAction("UploadCompanyLogo");
                    }
                    else
                    {
                        CompanyLogoObj.Flag = "C";
                        NewCompanyLogoBs.Update(CompanyLogoObj);
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
                    if (strExtensionType == file.Extension)
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
        public JsonResult VerifyUsername(string id)
        {
            var result = userBs.VerifyUsername(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VerifyCompanyEmail(string email)
        {
            var result = companyDetailBs.VerifyCompanyEmail(email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Security/Registration/Edit/5
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

        // GET: Security/Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Security/Registration/Delete/5
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
        [HttpGet]
        public ActionResult AdminReg()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminReg(FormCollection collection)
        {
            return View();
        }
    }
}
