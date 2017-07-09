using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.Business.Concrete.PrintManagers
{
    
     public class XeroxPrintManager:PrintManagerBase,IPrintService
    {
        public override string Print()
        {
            return "Print from Xerox device";
        }
    }
}
