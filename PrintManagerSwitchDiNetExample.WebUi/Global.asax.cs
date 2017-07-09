using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Modules;
using PrintManagerSwitchDiNetExample.Business.Abstract;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Modules;
using PrintManagerSwitchDiNetExample.WebUi.Utilities;

namespace PrintManagerSwitchDiNetExample.WebUi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //----------Middleware----------

            //Eğer modüllerin otomatik olarak gelmesini istersek modülleri reflection ile çözülebilir.
            //Reflection kodu Middleware içine yazılmalıdır.

            //var moduleTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => typeof(IVeriableModule).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectInstanceResolverFactory(new BusinessModule())));

            //----------Middleware----------
        }
    }
}
