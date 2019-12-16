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

        [HttpGet]
        [Route("GetProductCategoryById")]
        public IHttpActionResult GetProductCategoryById(int id)
        {
            return Ok(productCategoryBs.GetById(id));
        }

        [HttpPost]
        [Route("AddProductCategory")]
        public IHttpActionResult PostProductCategory(ProductCategory ProductCategoryObj)
        {
            if (string.IsNullOrEmpty(ProductCategoryObj.ProductCategoryName))
            {
                return BadRequest("Product category name must be supplied");
            }
            ProductCategoryObj.ModifiedBy = ProductCategoryObj.CreatedBy = "admin";
            ProductCategoryObj.ModifiedOn = ProductCategoryObj.CreatedOn = DateTime.Today;
            ProductCategoryObj.Flag = ProductCategoryObj.Flag;
            var category = productCategoryBs.GetProductCategoryByName(ProductCategoryObj.ProductCategoryName);
            if (category != null)
                return Ok("Product category already exist");
            productCategoryBs.Insert(ProductCategoryObj);
            message = "Product category save successfully";
            return Ok(message);
        }

        [HttpPatch]
        [Route("UpdateProductCategory")]
        public IHttpActionResult PatchProductCategory(ProductCategory ProductCategoryObj)
        {
            if (string.IsNullOrEmpty(ProductCategoryObj.ProductCategoryName))
            {
                return BadRequest("Product category name must be supplied");
            }
            ProductCategoryObj.ModifiedBy = "admin";
            ProductCategoryObj.ModifiedOn = DateTime.Today;
            ProductCategoryObj.Flag = ProductCategoryObj.Flag;
            productCategoryBs.Update(ProductCategoryObj);
            message = "Product category updated successfully";
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