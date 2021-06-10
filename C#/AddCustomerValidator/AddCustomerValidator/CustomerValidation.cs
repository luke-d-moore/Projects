using System;
using AddCustomerValidator.Interfaces;

namespace AddCustomerValidator
{
    public class CustomerValidation : ICustomerValidator
    {
        const int minAge = 21;
        public bool Validate(string firname, string surname, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < minAge)
            {
                return false;
            }

            return true;
        }
    }
}
