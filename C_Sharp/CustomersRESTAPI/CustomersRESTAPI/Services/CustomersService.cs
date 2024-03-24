using Newtonsoft.Json;
using CustomersRESTAPI.Interfaces;
using System.Collections.Generic;
using CustomersRESTAPI.Content;
using System.Linq;

namespace CustomersRESTAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private ICustomersProcessor _customersProcessor;

        public CustomersService(ICustomersProcessor customersProcessor)
        {
            _customersProcessor = customersProcessor;
        }
        private ICustomerResponse SetupResponse(ICustomerResponse response)
        {
            response.Success = true;
            response.Errors = new List<string>();
            response.Customers= new List<ICustomer>();
            return response;
        }

        public ICustomerResponse Get()
        {
            var response = new CustomersResponse();
            SetupResponse(response);
            return _customersProcessor.Get(response);
        }

        public ICustomerResponse Get(int id)
        {
            //Return a customer with the specified ID
            var response = new CustomersResponse();
            SetupResponse(response);
            return _customersProcessor.Get(response, id);
        }

        public ICustomerResponse Post(ICustomer customer)
        {
            //Add a new customer record here
            var response = new CustomersResponse();
            SetupResponse(response);

            if (customer != null)
            {
                return _customersProcessor.Post(response, customer);
            }
            else
            {
                response.Success = false;
                response.Errors.Add("Invalid null value");
                return response;
            }
        }

        public ICustomerResponse Put(ICustomer customer)
        {
            //Update a customer record here
            var response = new CustomersResponse();
            SetupResponse(response);

            if (customer != null)
            {
                return _customersProcessor.Put(response, customer);
            }
            else
            {
                response.Success = false;
                response.Errors.Add("Invalid null value");
                return response;
            }
        }

        public ICustomerResponse Delete(int id)
        {
            //Delete the Customer with this ID
            var response = new CustomersResponse();
            SetupResponse(response);
            return _customersProcessor.Delete(response, id);
        }
    }
}
