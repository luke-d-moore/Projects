using AddCustomerValidator.Interfaces;

namespace AddCustomerValidator
{
    public class CustomerCreditChecker : ICustomerCreditChecker
    {
        const int minCreditLimit = 500;
        private ICustomerCreditCalculator _customerCreditCalculator;
        public CustomerCreditChecker(ICustomerCreditCalculator customerCreditCalculator)
        {
            _customerCreditCalculator = customerCreditCalculator;
        }
        public bool CustomerHasCredit(Customer customer)
        {
            bool result = true;

            customer = _customerCreditCalculator.CalculateCredit(customer);

            if (customer.HasCreditLimit && customer.CreditLimit < minCreditLimit)
            {
                result = false;
            }
            return result;
        }
    }
}
