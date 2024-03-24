using System;

namespace AddCustomerValidator.Interfaces
{
    public interface ICustomerValidator
    {
        bool Validate(string firname, string surname, string email, DateTime dateOfBirth);
    }
}
