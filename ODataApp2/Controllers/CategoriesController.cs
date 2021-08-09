using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataApp2.Controllers
{
    public class CategoriesController : ODataController
    {
        Model1 db = new Model1();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Category> Get()
        {
            return db.categories;
        }

        [EnableQuery]
        public SingleResult<Category> Get([FromODataUri] int key)
        {
            IQueryable<Category> result = db.categories.Where(c => c.category_id == key);
            return SingleResult.Create(result);
        }

        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.categories.Where(c => c.category_id.Equals(key)).SelectMany(c => c.products);
        }
    }
}