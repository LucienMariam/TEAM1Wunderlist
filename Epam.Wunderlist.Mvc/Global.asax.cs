﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskManager.Authentification;

namespace TaskManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); //I AM THE 2nd
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {         
            SetContextUser();            
        }

        private void SetContextUser()
        {
            var principalService = DependencyResolver.Current.GetService<IPrincipalService>();

            Thread.CurrentPrincipal = principalService.GetCurrent();
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = Thread.CurrentPrincipal;
            }
        }
    }

}
