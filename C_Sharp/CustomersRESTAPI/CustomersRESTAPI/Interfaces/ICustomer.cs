namespace CustomersRESTAPI.Interfaces
{
    public interface ICustomer
    {
        public string Name { get; set; }

        public int CustomerID { get; set; }

        public string DateOfBirth { get; set; }
    }
}
