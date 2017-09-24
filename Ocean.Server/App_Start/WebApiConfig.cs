using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ocean.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{action}/{id}",
                defaults: new { controller = "Ocean", action = "Test", id = RouteParameter.Optional }
            );


        }
    }
}
