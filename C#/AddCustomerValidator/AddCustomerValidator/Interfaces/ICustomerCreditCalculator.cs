namespace AddCustomerValidator.Interfaces
{
    public interface ICustomerCreditCalculator
    {
        Customer CalculateCredit(Customer customer);
    }
}
