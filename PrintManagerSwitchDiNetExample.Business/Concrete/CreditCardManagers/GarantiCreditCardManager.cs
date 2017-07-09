namespace PrintManagerSwitchDiNetExample.Business.Concrete.CreditCardManagers
{
    public class GarantiCreditCardManager:BaseCreditCardManager
    {
        public override string Pay()
        {
            return "Pay with Garanti credit card";
        }
    }
}