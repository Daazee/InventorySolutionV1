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
    [RoutePrefix("api/Settings")]
    public class SettingsController : ApiController
    {
        // GET api/<controller>
        private string message;
        ProductCategoryBs productCategoryBs = new ProductCategoryBs();
       
        [HttpPost]
        [Route("AddProductCategory")]
        public string AddProductCategory(ProductCategory ProductCategoryObj)
        {
            ProductCategoryObj.CreatedBy = "admin";
            ProductCategoryObj.KeyDate = DateTime.Today;
            ProductCategoryObj.Flag = "A";
            productCategoryBs.Insert(ProductCategoryObj);
            message = "Product category save successfully";
            return message;
        }

        [HttpGet]
        [Route("Test")]
        public IHttpActionResult Test()
        {
            
            return Ok();
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}