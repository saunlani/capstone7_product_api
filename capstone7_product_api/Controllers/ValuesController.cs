using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using capstone7_product_api.Models;

namespace capstone7_product_api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("{api}/Product")]
        public List<ProductShort> Product()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();
            List <ProductShort>IDAndNames = Products.Select(t => new ProductShort { ProductID = t.ProductID, ProductName = t.ProductName }).ToList();
            return IDAndNames; 
        }

        [HttpGet]
        [Route("{api}/Product")]
        public Product Product(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();

            Product Result = (from m in db.Products
                           where m.ProductID == id
                           select m).Single();
            return Result;

            //List<ProductShort> IDAndNames = Products.Select(t => new ProductShort { ProductID = t.ProductID, ProductName = t.ProductName }).ToList();
            //return IDAndNames;
        }

        //return Json(db.Products.Select(t => new { Id = t.ProductID, Name = t.ProductName }).ToList());
        //if (id == null)
        //{
        //}
        //else
        //{

        //    List<Product> NWProducts = db.Products.ToList();
        //    //NWProducts.Select(t => new { Id = t.ProductID, Name = t.ProductName });
        //    return NWProducts;

        //
    }
}