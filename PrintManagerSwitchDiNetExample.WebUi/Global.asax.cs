using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Modules;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Resolvers;
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

            //Reflection kodu Middleware içine yazılmalıdır.

            //Bu sınıf sadece bir kere çalıştığı için performans açısından reflection'ları bu sınıfta yapılmalıdır.
            //IResolver tipini implemente eden tüm gerçek sınıflar alınıyor.
            var resolverTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IResolver).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            ////NinjectModule tipini implemente eden tüm gerçek sınıflar alınıyor.
            ////Eğer modüllerin otomatik olarak yüklenmesini istersek bu reflection kodundan yararlanabiliriz.
            //var moduleTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => typeof(NinjectModule).IsAssignableFrom(p) && !typeof(NinjectResolverBase).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);


            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new NinjectInstanceResolverFactory(new BusinessModule(),resolverTypes)));

            //----------Middleware----------
        }
    }
}
