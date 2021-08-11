using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ODataApp2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            config.Filter().OrderBy().Expand().Select().Count().MaxTop(null);

            builder.Namespace = "ODataApp2";
            builder.EntitySet<Product>("products");
            builder.EntitySet<Category>("categories");
            builder.EntitySet<Stock>("stocks");
            builder.EntitySet<Brand>("brands");

            builder.EntityType<Product>()
                .Action("Rate")
                .Parameter<int>("Rating");

            builder.EntityType<Product>().Collection
                .Function("MostExpensive")
                .Returns<double>();

            builder.Function("GetTaxRateByCategory")
                .Returns<double>()
                .Parameter<int>("Category");
            
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
