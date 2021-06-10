using System;
using AddCustomerValidator.Interfaces;

namespace AddCustomerValidator
{
    public class CustomerService
    {
        private ICustomerValidator _customerValidator;
        private ICompanyRepo _companyRepo;
        private ICustomerCreditChecker _customerCreditChecker;

        public CustomerService(ICompanyRepo companyRepo, 
                                ICustomerValidator customerValidator,
                                ICustomerCreditChecker customerCreditChecker) 
        {
            _companyRepo = companyRepo;
            _customerValidator = customerValidator;
            _customerCreditChecker = customerCreditChecker;
        }

        public bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            var result = _customerValidator.Validate(firname, surname, email, dateOfBirth);

            if (result)
            {
                var company = _companyRepo.GetById(companyId);

                var customer = new Customer
                {
                    Company = company,
                    DateOfBirth = dateOfBirth,
                    EmailAddress = email,
                    Firstname = firname,
                    Surname = surname
                };

                result = _customerCreditChecker.CustomerHasCredit(customer);

                if (result)
                {
                    CustomerDataAccess.AddCustomer(customer);
                }
            }

            return result;
        }
    }
}
