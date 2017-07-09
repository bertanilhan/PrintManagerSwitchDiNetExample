using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Resolvers
{
    public abstract class NinjectResolverBase:NinjectModule,IResolver
    {
        private NameValueCollection _queries;
        protected NinjectResolverBase(NameValueCollection queries)
        {
            _queries = queries;
        }
    }
}
