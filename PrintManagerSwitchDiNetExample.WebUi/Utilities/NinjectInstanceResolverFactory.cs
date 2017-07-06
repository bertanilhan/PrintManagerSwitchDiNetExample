using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Ninject;
using Ninject.Modules;
using PrintManagerSwitchDiNetExample.Business.Concrete;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers;

namespace PrintManagerSwitchDiNetExample.WebUi.Utilities
{
    public class NinjectInstanceResolverFactory
    {
        private readonly IKernel _kernel;
        private readonly INinjectModule[] _veriableModules;

        public NinjectInstanceResolverFactory(INinjectModule[] veriableModules, INinjectModule[] constantModules)
        {
            _veriableModules = veriableModules;
            _kernel = new StandardKernel(constantModules);
        }

        public IController GetInstance(Type controllerType, string query)
        {
            INinjectModule module;
            //Değişken modüller çakışmaması için ilk önce siliniyor.
            //Gelen parametrelere göre yeni modüller yükleniyor.
            CleanModules(); //Aspect Olabilir.

            //Eğer query ile eşleşen yok ise base class'dan bilgiyi alarak sistemin hata vermesi engellenmiştir.
            switch (query)
            {
                case "Xerox":
                    {
                        module = _veriableModules.SingleOrDefault(x => x.Name == typeof(XeroxBusinessModule).FullName);
                        _kernel.Load(module);

                        return (IController)_kernel.Get(controllerType);
                    }
                case "KonicaMinolta":
                    {
                        module = _veriableModules.SingleOrDefault(x => x.Name == typeof(KonicaMinoltaBusinessModule).FullName);
                        _kernel.Load(module);

                        return (IController)_kernel.Get(controllerType);
                    }

                default:
                    module = _veriableModules.SingleOrDefault(x => x.Name == typeof(BaseBusinessModule).FullName);
                    _kernel.Load(module);

                    return (IController)_kernel.Get(controllerType);
            }
        }

        private void CleanModules()
        {
            foreach (var module in _veriableModules)
            {
                // Eğer değişken modüller var ise silinirler.
                if (_kernel.HasModule(module.Name))
                {
                    _kernel.Unload(module.Name);
                }
            }
        }
    }
}