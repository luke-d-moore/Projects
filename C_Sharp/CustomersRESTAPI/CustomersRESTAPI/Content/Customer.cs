using CustomersRESTAPI.Interfaces;
namespace CustomersRESTAPI
{
    public class Customer : ICustomer
    {
        public string Name { get; set; }

        public int CustomerID { get; set; }

        public string DateOfBirth { get; set; }
    }
}
