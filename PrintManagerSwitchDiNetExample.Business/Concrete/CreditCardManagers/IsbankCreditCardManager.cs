namespace PrintManagerSwitchDiNetExample.Business.Concrete.CreditCardManagers
{
    public class IsbankCreditCardManager:BaseCreditCardManager
    {
        public override string Pay()
        {
            return "Pay with Isbank credit card";
        }
    }
}