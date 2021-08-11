using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ODataApp2.Controllers
{
    public class StaticController : ODataController
    {
        [HttpGet]
        [ODataRoute("GetTaxRateByCategory(Category={categoryId})")]
        public IHttpActionResult GetTaxRateByCategory([FromODataUri] int categoryId)
        {
            double rate = 0.0;
            switch (categoryId)
            {
                case 1:
                    rate = 0.18;
                    break;
                default:
                    break;
            }

            return Ok(rate);
        }
    }
}