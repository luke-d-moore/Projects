namespace AddCustomerValidator
{
    public interface ICustomerCreditService
    {
        int GetCreditLimit(string firstname, string surname, System.DateTime dateOfBirth);
    }
}
