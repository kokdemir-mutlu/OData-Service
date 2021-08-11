using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataApp2.Controllers
{
    public class StocksController : ODataController
    {
        Model1 db = new Model1();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Stock> Get()
        {
            return db.stocks;
        }

    }
}