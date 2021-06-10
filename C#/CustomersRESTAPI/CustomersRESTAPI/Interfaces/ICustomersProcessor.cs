using System.Collections.Generic;
namespace CustomersRESTAPI.Interfaces
{
    public interface ICustomersProcessor
    {
        public ICustomerResponse Get(ICustomerResponse response);
        public ICustomerResponse Get(ICustomerResponse response, int id);
        public ICustomerResponse Post(ICustomerResponse response, ICustomer customer);
        public ICustomerResponse Put(ICustomerResponse response, ICustomer customer);
        public ICustomerResponse Delete(ICustomerResponse response, int id);
    }
}
