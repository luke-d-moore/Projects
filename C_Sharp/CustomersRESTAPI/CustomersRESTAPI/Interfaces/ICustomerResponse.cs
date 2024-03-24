using System.Collections.Generic;
namespace CustomersRESTAPI.Interfaces
{
    public interface ICustomerResponse
    {
        public bool Success { get; set; }

        public List<string> Errors { get; set; }

        public List<ICustomer> Customers { get; set; }
    }
}
