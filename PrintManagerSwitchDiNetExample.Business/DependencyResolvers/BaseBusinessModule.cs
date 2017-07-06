using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using PrintManagerSwitchDiNetExample.Business.Abstract;
using PrintManagerSwitchDiNetExample.Business.Concrete;

namespace PrintManagerSwitchDiNetExample.Business.DependencyResolvers
{
    public class BaseBusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IPrintService>().To<PrintManagerBase>().InSingletonScope();
        }
    }
}
