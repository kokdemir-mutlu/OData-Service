using Microsoft.AspNet.OData;
using ODataApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ODataApp2.Controllers
{
    public class ProductsController : ODataController
    {
        Model1 db = new Model1();

        private bool ProductExists(int key)
        {
            return db.products.Any(p => p.product_id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.products;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = db.products.Where(p => p.product_id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public SingleResult<Category> GetCategories([FromODataUri] int key)
        {
            var result = db.products.Where(p => p.product_id == key).Select(p => p.categories);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.products.Add(product);
            await db.SaveChangesAsync();
            return Created(product);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.products.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Rate([FromODataUri] int key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int rating = (int)parameters["Rating"];
            db.ProductRatings.Add(new ProductRating
            {
                product_id = key,
                rating = rating
                
            });

            try
            {
                await db.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                Debug.WriteLine(e.ToString());
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public IHttpActionResult MostExpensive()
        {
            var product = db.products.Max(p => p.list_price);
            return Ok(product);
        }

    }
}