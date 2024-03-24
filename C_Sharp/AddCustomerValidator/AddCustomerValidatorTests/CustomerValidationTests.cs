using NUnit.Framework;
using AddCustomerValidator;
using System;

namespace AddCustomerValidatorTests
{
    public class CustomerValidationTests
    {
        [Test]
        public void Validate_ValidCustomerInfo_ReturnsTrue()
        {
            var customerValidation = new CustomerValidation();

            string firname = "Test";
            string surname = "Test";
            string email = "Test@test.com";
            DateTime dateOfBirth = new DateTime(1990,11,11);

            var result = customerValidation.Validate(firname, surname, email, dateOfBirth);

            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_InValidFirstName_ReturnsFalse()
        {
            var customerValidation = new CustomerValidation();

            string firname = "";
            string surname = "Test";
            string email = "Test@test.com";
            DateTime dateOfBirth = new DateTime(1990, 11, 11);

            var result = customerValidation.Validate(firname, surname, email, dateOfBirth);

            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_InValidSurName_ReturnsFalse()
        {
            var customerValidation = new CustomerValidation();

            string firname = "Test";
            string surname = "";
            string email = "Test@test.com";
            DateTime dateOfBirth = new DateTime(1990, 11, 11);

            var result = customerValidation.Validate(firname, surname, email, dateOfBirth);

            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_InValidEmail_ReturnsFalse()
        {
            var customerValidation = new CustomerValidation();

            string firname = "Test";
            string surname = "Test";
            string email = "Testtestcom";
            DateTime dateOfBirth = new DateTime(1990, 11, 11);

            var result = customerValidation.Validate(firname, surname, email, dateOfBirth);

            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_InValidDateOfBirth_ReturnsFalse()
        {
            var customerValidation = new CustomerValidation();

            string firname = "Test";
            string surname = "Test";
            string email = "Test@test.com";
            DateTime dateOfBirth = new DateTime(2010, 11, 11);

            var result = customerValidation.Validate(firname, surname, email, dateOfBirth);

            Assert.IsFalse(result);
        }
    }
}