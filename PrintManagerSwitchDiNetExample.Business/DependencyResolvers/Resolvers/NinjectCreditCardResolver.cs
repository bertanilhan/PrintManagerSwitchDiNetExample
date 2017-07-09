using PrintManagerSwitchDiNetExample.Business.Abstract;
using PrintManagerSwitchDiNetExample.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintManagerSwitchDiNetExample.Business.Concrete.CreditCardManagers;

namespace PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Resolvers
{
    public class NinjectCreditCardResolver : NinjectResolverBase
    {
        private readonly NameValueCollection _queries;
        public NinjectCreditCardResolver(NameValueCollection queries) : base(queries)
        {
            _queries = queries;
        }

        public override void Load()
        {
            //Gelen query'e göre bind edilir.
            switch (_queries["CreditCard"])
            {
                case "Isbank":
                    {
                        Bind<ICreditCardService>().To<IsbankCreditCardManager>().InSingletonScope();
                        break;
                    }
                case "Garanti":
                    {
                        Bind<ICreditCardService>().To<GarantiCreditCardManager>().InSingletonScope();
                        break;
                    }
                default:
                    Bind<ICreditCardService>().To<BaseCreditCardManager>().InSingletonScope();
                    //Eğer query ile eşleşen yok ise base class'dan bilgiyi alarak sistemin hata vermesi engellenmiştir.

                    break;
            }
        }
    }
}
