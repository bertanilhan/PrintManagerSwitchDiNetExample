using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.Business.Concrete
{
    
     public class XeroxPrintManager:PrintManagerBase,IPrintService
    {
        public override string Print()
        {
            return "Print from Xerox device";
        }
    }
}
