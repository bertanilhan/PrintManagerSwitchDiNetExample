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

            //Eğer modüllerin otomatik olarak gelmesini istersek modülleri "IVariableModule" ve "IConstantModule" ile işaretlemek gerekir
            //Reflection kodu Middleware içine yazılmalıdır.

            //var moduleTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => typeof(IVeriableModule).IsAssignableFrom(p) && !p.IsInterface);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectInstanceResolverFactory(veriableModules,constantModule)));

            //----------Middleware----------
        }
    }
}
