namespace CustomersRESTAPI.Interfaces
{
    public interface ICustomersService
    {
        public ICustomerResponse Get();
        public ICustomerResponse Get(int id);
        public ICustomerResponse Post(ICustomer customer);
        public ICustomerResponse Put(ICustomer customer);
        public ICustomerResponse Delete(int id);
    }
}
