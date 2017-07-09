using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.Business.Concrete.PrintManagers
{
    public class KonicaMinoltaPrintManager:PrintManagerBase,IPrintService
    {
        public override string Print()
        {
            return "Print from Konica Minolta device";
        }
    }
}
