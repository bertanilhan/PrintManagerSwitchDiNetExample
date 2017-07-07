using System;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
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
            //Eğer query ile eşleşen yok ise base class'dan bilgiyi alarak sistemin hata vermesi engellenmiştir.
            switch (query)
            {
                case "Xerox":
                    {
                        return GetInstanceHelper(controllerType, typeof(XeroxBusinessModule));
                    }
                case "KonicaMinolta":
                    {
                        return GetInstanceHelper(controllerType, typeof(KonicaMinoltaBusinessModule));
                    }

                default:
                    return GetInstanceHelper(controllerType, typeof(BaseBusinessModule));
            }
        }

        private IController GetInstanceHelper(Type controllerType, Type injectModule)
        {
            //Değişken modüller çakışmaması için ilk önce siliniyor.
            //Gelen parametrelere göre yeni modüller yükleniyor.
            CleanModules(); //Aspect Olabilir.

            //Modüller dizizinden istenilen modül alınıyor.
            var module = _veriableModules.SingleOrDefault(x => x.Name == injectModule.FullName);

            //IKernel'a mdül yüklenir.
            _kernel.Load(module);

            //Instance alınır.
            var instance = (IController)_kernel.Get(controllerType);
            return instance;
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