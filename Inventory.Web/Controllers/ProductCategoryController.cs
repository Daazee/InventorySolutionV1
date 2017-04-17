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
    [RoutePrefix("api/ProductCategory")]
    public class ProductCategoryController : ApiController
    {
        // GET api/<controller>
        private string message;
        ProductCategoryBs productCategoryBs = new ProductCategoryBs();
       
        [HttpPost]
        [Route("AddProductCategory")]
        //public string PostProductCategory(ProductCategory ProductCategoryObj)
        //{
        //    ProductCategoryObj.CreatedBy = "admin";
        //    ProductCategoryObj.KeyDate = DateTime.Today;
        //    ProductCategoryObj.Flag = "A";
        //    productCategoryBs.Insert(ProductCategoryObj);
        //    message = "Product category save successfully";
        //    return message;
        //}

        public IHttpActionResult PostProductCategory(ProductCategory ProductCategoryObj)
        {
            if(string.IsNullOrEmpty( ProductCategoryObj.ProductCategoryName))
            {
                return BadRequest("Product category name must be supplied");
            }
            ProductCategoryObj.CreatedBy = "admin";
            ProductCategoryObj.KeyDate = DateTime.Today;
            ProductCategoryObj.Flag = "A";
            productCategoryBs.Insert(ProductCategoryObj);
            message = "Product category save successfully";       
            return Ok(message);
        }


        [HttpGet]
        [Route("GetProductCategories")]
        public IHttpActionResult GetProductCategories()
        {
            return Ok(productCategoryBs.ListAll());
        }

        [HttpGet]
        [Route("GetProductCategoryByName")]
        public IHttpActionResult GetProductCategoryByName(string name)
        {
            return Ok(productCategoryBs.GetProductCategoryByName(name));
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