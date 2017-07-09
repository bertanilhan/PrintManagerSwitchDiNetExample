using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.Business.Concrete.PrintManagers
{
    public class PrintManagerBase:IPrintService
    {
        public virtual string Print()
        {
            return "Print from base manager";
        }
    }
}
