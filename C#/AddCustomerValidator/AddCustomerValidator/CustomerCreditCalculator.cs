using AddCustomerValidator.Interfaces;

namespace AddCustomerValidator
{
    public class CustomerCreditCalculator : ICustomerCreditCalculator
    {
        private readonly ICustomerCreditService _customerCreditService;

        public CustomerCreditCalculator(
            ICustomerCreditService customerCreditService)
        {
            _customerCreditService = customerCreditService;
        }
        public Customer CalculateCredit(Customer customer)
        {
            int creditLimit=0;
            switch (customer.Company.Name)
            {
                case "VeryImportantClient":
                    customer.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                    customer.HasCreditLimit = true;
                    creditLimit = GetCustomerCreditLimit(customer);
                    creditLimit = creditLimit * 2;
                    break;
                default:
                    customer.HasCreditLimit = true;
                    creditLimit = GetCustomerCreditLimit(customer);
                    break;
            }

            customer.CreditLimit = creditLimit;

            return customer;
        }
        private int GetCustomerCreditLimit(Customer customer)
        {
            return _customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
        }
    }
}
