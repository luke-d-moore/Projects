using NUnit.Framework;
using AddCustomerValidator;
using System;
using Moq;

namespace AddCustomerValidatorTests
{
    public class CustomerCreditCalculatorTests
    {
        private Customer _Customer;
        private Mock<ICustomerCreditService> _Mock;

        [OneTimeSetUp]
        public void Setup()
        {
            _Mock = new Mock<ICustomerCreditService>();
            _Customer = new Customer();
            _Customer.Firstname = "Test";
            _Customer.Surname = "Test";
            _Customer.DateOfBirth = new DateTime(1990, 1, 1);
            var company = new Company();
            _Customer.Company = company;
            _Mock.Setup(o => o.GetCreditLimit(_Customer.Firstname, _Customer.Surname, _Customer.DateOfBirth)).Returns(5);
        }
        [Test]
        public void Validate_NoLimit_ReturnsTrue()
        {
            _Customer.Company.Name = "VeryImportantClient";
            var customerCreditCalculator = new CustomerCreditCalculator(_Mock.Object);

            var result = customerCreditCalculator.CalculateCredit(_Customer);

            Assert.That(result.HasCreditLimit == false);
        }

        [Test]
        public void Validate_ImportantClientHasLimit_ReturnsTrue()
        {
            _Customer.Company.Name = "ImportantClient";
            var customerCreditCalculator = new CustomerCreditCalculator(_Mock.Object);

            var result = customerCreditCalculator.CalculateCredit(_Customer);

            Assert.That(result.HasCreditLimit == true && _Customer.CreditLimit == 10);
        }

        [Test]
        public void Validate_ClientHasLimit_ReturnsTrue()
        {
            _Customer.Company.Name = "Client";
            var customerCreditCalculator = new CustomerCreditCalculator(_Mock.Object);

            var result = customerCreditCalculator.CalculateCredit(_Customer);

            Assert.That(result.HasCreditLimit == true && _Customer.CreditLimit == 5);
        }
    }
}
