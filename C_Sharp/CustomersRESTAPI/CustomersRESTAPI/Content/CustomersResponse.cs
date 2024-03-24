using CustomersRESTAPI.Interfaces;
using System.Collections.Generic;
namespace CustomersRESTAPI.Content
{
    public class CustomersResponse :ICustomerResponse
    {
        private bool _Success;
        private List<string> _Errors;
        private List<ICustomer> _Customers;
        public bool Success
        {
            get
            {
                return _Success;
            }

            set
            {
                _Success = value;
            }
        }
        public List<string> Errors
        {
            get
            {
                return _Errors;
            }

            set
            {
                _Errors = value;
            }
        }
        public List<ICustomer> Customers
        {
            get
            {
                return _Customers;
            }

            set
            {
                _Customers = value;
            }
        }
    }
}
