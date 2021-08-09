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
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            ODataModelBuilder builder = new ODataConventionModelBuilder();

            config.Filter().OrderBy().Expand().Select().Count().MaxTop(null);
            
            builder.EntitySet<Product>("products");
            builder.EntitySet<Category>("categories");
            builder.EntitySet<Stock>("stocks");
            builder.EntitySet<Brand>("brands");
            
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
