using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Ocean.Server.DataCore;
using Ocean.Server.Models;
using Orm.Son.Core;

namespace Ocean.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            CreateTable();
        }


        private static void CreateTable()
        {
            using (var os = new OsConn())
            {
                os.CreateTable<OceanFile>();
            }
        }
    }
}
