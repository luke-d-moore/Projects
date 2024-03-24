using Newtonsoft.Json;
using CustomersRESTAPI.Interfaces;
using System.Collections.Generic;

namespace CustomersRESTAPI.Processors
{
    public class CustomerProcessor : ICustomersProcessor
    {
        private ICustomerRepository _customerRepository;

        public CustomerProcessor(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
    }

        private ICustomerResponse GetResponse(ICustomerResponse response, bool success, List<string> errors, IEnumerable<ICustomer> customers)
        {
            response.Success = success;
            response.Errors.AddRange(errors);
            response.Customers.AddRange(customers);
            return response;
        }

        public ICustomerResponse Get(ICustomerResponse response)
        {
            return GetResponse(response, true, new List<string>(), _customerRepository.GetAll());
        }

        public ICustomerResponse Get(ICustomerResponse response, int id)
        {
            //Return a customer with the specified ID
            var customer = _customerRepository.GetByID(id);
            var customers = new List<ICustomer>();
            var errors = new List<string>();
            bool success;
            if (customer != null)
            {
                success = true;
                customers.Add(customer);
            }
            else
            {
                success = false;
                errors.Add($"No Customer with ID: {id} was found");
            }

            return GetResponse(response, success, errors, customers);
        }

        public ICustomerResponse Post(ICustomerResponse response, ICustomer customer)
        {
            //Add a new customer record here
            bool success;
            var errors = new List<string>();
            if (_customerRepository.GetByID(customer.CustomerID) != null)
            {
                success = false;
                errors.Add($"Cannot Add Customer with ID : {customer.CustomerID} as this ID already exists");
            }
            else
            {
                success = _customerRepository.Add(customer);
            }

            if (!success)
            {
                errors.Add("Failed to Add Customer");
            }

            return GetResponse(response, success, errors, _customerRepository.GetAll());
        }

        public ICustomerResponse Put(ICustomerResponse response, ICustomer customer)
        {
            //Update a customer record here
            bool success;
            var errors = new List<string>();

            if (_customerRepository.GetByID(customer.CustomerID) == null)
            {
                success = false;
                errors.Add($"Could not Update as a Customer with the ID: {customer.CustomerID} does not exist");
            }
            else
            {
                success = _customerRepository.Update(customer);
            }

            return GetResponse(response, success, errors, _customerRepository.GetAll());
        }

        public ICustomerResponse Delete(ICustomerResponse response, int id)
        {
            //Delete the Customer with this ID
            bool success;
            var errors = new List<string>();

            success = _customerRepository.Delete(id);

            if (!success)
            {
                errors.Add($"Could not Delete as a Customer with the ID: {id} does not exist");
            }

            return GetResponse(response, success, errors, _customerRepository.GetAll());
        }
    }
}
