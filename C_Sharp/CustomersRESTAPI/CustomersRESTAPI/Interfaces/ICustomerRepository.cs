using System.Collections.Generic;

namespace CustomersRESTAPI.Interfaces
{
    public interface ICustomerRepository
    {
        public IEnumerable<ICustomer> GetAll();

        public ICustomer GetByID(int ID);

        public bool Update(ICustomer Customer);

        public bool Delete(int ID);

        public bool Add(ICustomer Customer);
    }
}
