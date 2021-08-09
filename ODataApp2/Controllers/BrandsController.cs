using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataApp2.Controllers
{
    public class BrandsController : ODataController
    {
        Model1 db = new Model1();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
        [EnableQuery]
        public IQueryable<Brand> Get()
        {
            return db.brands;
        }

        [EnableQuery]
        public SingleResult<Brand> Get([FromODataUri] int key)
        {
            var result = db.brands.Where(b => b.brand_id == key);
            return SingleResult.Create(result);
        }
    }
}