using MvcCRUDWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcCRUDWithLogin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           // Database.SetInitializer<DBModel>(new DropCreateDatabaseIfModelChanges<DBModel>());
        }
       
    }
}
