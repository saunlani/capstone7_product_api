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
            List <ProductShort>IDAndNames = Products.Select(p => new ProductShort { ProductID = p.ProductID, ProductName = p.ProductName }).ToList();
            return IDAndNames; 
        }

        [HttpGet]
        [Route("{api}/Product")]
        public Product Product(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();
            Product Result = null;
            try
            {
                Result = (from m in db.Products
                          where m.ProductID == id
                          select m).Single();
            }
            catch
            {
                Exception e;
            }
            return Result;
        }

        [HttpGet]
        [Route("{api}/Category")]
        public List<Product> Category(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();
            List<Product> CatIDList = (from p in db.Products
                                       where p.CategoryID == id
                                       select p).ToList();
            return CatIDList;
        }

        [HttpGet]
        [Route("{api}/Category")]
        public List<Product> Category()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();
            return Products;
        }

        [Route("{api}/Supplier")]
        public List<Product> Supplier(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();
            List<Product> SupplierIDList = (from p in db.Products
                                       where p.SupplierID == id
                                       select p).ToList();
            return SupplierIDList;
        }

        [HttpGet]
        [Route("{api}/Supplier")]
        public List<Product> Supplier()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            List<Product> Products = db.Products.ToList();
            return Products;
        }
        //NORTHWNDEntities db = new NORTHWNDEntities();
        //List<Product> Products = db.Products.ToList();
        //Product Result = null;
        //try
        //{
        //    Result = (from m in db.Products
        //              where m.CategoryID == id
        //              select m).Single();

        //}
        //catch
        //{
        //    Exception e;
        //}
        //return Result;

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

        //List<ProductShort> IDAndNames = Products.Select(t => new ProductShort { ProductID = t.ProductID, ProductName = t.ProductName }).ToList();
        //return IDAndNames;
    }
}