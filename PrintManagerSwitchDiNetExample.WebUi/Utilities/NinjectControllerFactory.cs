using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Modules;

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
            //Querystring ile gönderilen parametre "query" parametresine eşitleniyor.
            var query = requestContext.HttpContext.Request.QueryString["Device"];

            return controllerType == null
                ? null
                :_resolverFactory.GetInstance(controllerType,query);
        }
    }
}