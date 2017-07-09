using System.Collections.Specialized;
using PrintManagerSwitchDiNetExample.Business.Abstract;
using PrintManagerSwitchDiNetExample.Business.Concrete.PrintManagers;

namespace PrintManagerSwitchDiNetExample.Business.DependencyResolvers.Resolvers
{
    public class NinjectPrintManagerResolver : NinjectResolverBase
    {
        private readonly NameValueCollection _queries;
        public NinjectPrintManagerResolver(NameValueCollection queries) : base(queries)
        {
            _queries = queries;
        }
        public override void Load()
        {
            //Gelen query'e göre bind edilir.
            switch (_queries["Device"])
            {
                case "Xerox":
                    {
                        Bind<IPrintService>().To<XeroxPrintManager>().InSingletonScope();
                        break;
                    }
                case "KonicaMinolta":
                    {
                        Bind<IPrintService>().To<KonicaMinoltaPrintManager>().InSingletonScope();
                        break;
                    }

                default:
                    {
                        Bind<IPrintService>().To<PrintManagerBase>().InSingletonScope();
                        break;
                        //Eğer query ile eşleşen yok ise base class'dan bilgiyi alarak sistemin hata vermesi engellenmiştir.
                    }

            }

        }
    }
}
