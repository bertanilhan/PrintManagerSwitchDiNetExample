using PrintManagerSwitchDiNetExample.Business.Abstract;

namespace PrintManagerSwitchDiNetExample.Business.Concrete.CreditCardManagers
{
    public class BaseCreditCardManager:ICreditCardService
    {
        public virtual string Pay()
        {
            return "Pay with base credit card manager";
        }
    }
}