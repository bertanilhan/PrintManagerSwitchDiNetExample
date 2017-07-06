using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Modules;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers;
using PrintManagerSwitchDiNetExample.WebUi.Utilities;

namespace PrintManagerSwitchDiNetExample.WebUi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Sabit olan modüller bu alana dizilecektir.
            var constantModule = new INinjectModule[]
            {
                new BusinessModule()
            };

            //Değişken olan modüller bu alana Dizelecektir.
            // 
            var veriableModules = new INinjectModule[]
            {
                new KonicaMinoltaBusinessModule(), 
                new XeroxBusinessModule(),
                new BaseBusinessModule()
            };
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectInstanceResolverFactory(veriableModules,constantModule)));
        }
    }
}
