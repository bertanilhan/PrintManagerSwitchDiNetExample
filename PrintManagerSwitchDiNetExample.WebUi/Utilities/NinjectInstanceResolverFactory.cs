using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers;
using PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Resolvers;

namespace PrintManagerSwitchDiNetExample.WebUi.Utilities
{
    public class NinjectInstanceResolverFactory
    {
        private readonly IKernel _kernel;
        private readonly IEnumerable<Type> _resolverTypes;

        public NinjectInstanceResolverFactory(INinjectModule[] constantModules)
        {
            _kernel = new StandardKernel(constantModules);
        }
        public NinjectInstanceResolverFactory(INinjectModule constantModule, IEnumerable<Type> resolverTypes)
        {
            _kernel = new StandardKernel(constantModule);
            _resolverTypes = resolverTypes;
        }

        public IController GetInstance(Type controllerType, NameValueCollection queries)
        {
            //Her tip için 
            foreach (var resolverType in _resolverTypes)
            {
                //Her query farklı olduğu için gelen modülde farklı olacaktır.
                var moduleInstance = (INinjectModule) Activator.CreateInstance(resolverType, queries);

                //Gelen modülün Kernel'da olup olmadığı kontrol edilir.
                if (_kernel.HasModule(moduleInstance.Name) /*&& Modül değişmiş ise*/)
                {

                    //Eğer Kernel'da var ise modül silinir. Çünkü içeriği farklı.
                    //Problem: Eğer query demişmediği halde modülleri silip tekrar yüklüyor. Eğer modül değişmemişse silmesin.
                    //Çözüm önerisi queryleri karşılaştıran bir proxy sınıf ile çözülebilir.
                    _kernel.Unload(moduleInstance.Name);
                }

                //Değişen modülleri tekrar yükle.
                _kernel.Load(moduleInstance);
            }

            //Kontroller tipine göre çözümlemeleri döndür.
            var currentTypeInstance = (IController)_kernel.Get(controllerType);
            return currentTypeInstance;
        }


    }
}