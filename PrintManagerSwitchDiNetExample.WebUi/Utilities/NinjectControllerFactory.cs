using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrintManagerSwitchDiNetExample.WebUi.Utilities
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private readonly NinjectInstanceResolverFactory _resolverFactory;

        public NinjectControllerFactory(NinjectInstanceResolverFactory resolverFactory)
        {
            _resolverFactory = resolverFactory;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //Querystring'ler resolver factory'e gönderiliyor.
            //Bu alan headers olacak veya ihtiyaca göre farklı bir parametre olabilir.
            var queries = requestContext.HttpContext.Request.QueryString;

            return controllerType == null
                ? null
                :_resolverFactory.GetInstance(controllerType,queries);
        }
    }
}