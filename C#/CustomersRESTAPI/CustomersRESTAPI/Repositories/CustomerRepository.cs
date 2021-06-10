using System.Collections.Generic;
using System.Linq;
using CustomersRESTAPI.Interfaces;

namespace CustomersRESTAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<ICustomer> _customers = new List<ICustomer> 
        { new Customer() { Name = "Test1", CustomerID = 1, DateOfBirth = "10/10/2010" },
            new Customer() { Name = "Test2", CustomerID = 2, DateOfBirth = "20/03/2020" },
            new Customer() { Name = "Test3", CustomerID = 3, DateOfBirth = "10/08/2000" },
            new Customer() { Name = "Test4", CustomerID = 4, DateOfBirth = "10/07/1990" },
            new Customer() { Name = "Test5", CustomerID = 5, DateOfBirth = "10/05/1980" },
          new Customer() { Name = "Test6", CustomerID = 6, DateOfBirth = "20/02/1970" } };
        public IEnumerable<ICustomer> GetAll()
        {
            return _customers;
        }

        public ICustomer GetByID(int ID)
        {
            return _customers.FirstOrDefault(o => o.CustomerID == ID);
        }

        public bool Update(ICustomer Customer)
        {
            var customerToUpdate = _customers.Where(o => o.CustomerID == Customer.CustomerID).FirstOrDefault();
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = Customer.Name;
                customerToUpdate.DateOfBirth = Customer.DateOfBirth;
            }
            return customerToUpdate != null;
        }

        public bool Delete(int ID)
        {
            var count = _customers.Count();
            var customerToDelete = _customers.Where(o => o.CustomerID == ID).FirstOrDefault();
            if (customerToDelete != null)
            {
                _customers.Remove(customerToDelete);
            }

            return _customers.Count() < count;
        }

        public bool Add(ICustomer Customer)
        {
            var count = _customers.Count();
            if (Customer != null)
            {
                var customers = new List<ICustomer>();
                customers.AddRange(_customers);
                customers.Add(Customer);
                _customers=customers;
            }

            return _customers.Count() > count;
        }
    }
}
