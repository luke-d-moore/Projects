namespace AddCustomerValidator.Interfaces
{
    public interface ICustomerCreditChecker
    {
        bool CustomerHasCredit(Customer customer);
    }
}
