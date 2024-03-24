using System;
using NUnit.Framework;
using AddCustomerValidator;
using Moq;
using AddCustomerValidator.Interfaces;

namespace AddCustomerValidatorTests
{
    public class CustomerCreditCheckerTests
    {
        [Test]
        public void CalculateCredit_NoLimit_ReturnsTrue()
        {
            Mock<ICustomerCreditCalculator> mock = new Mock<ICustomerCreditCalculator>();
            var customer = new Customer();
            customer.HasCreditLimit = false;
            customer.CreditLimit = 0;
            mock.Setup(o => o.CalculateCredit(customer)).Returns(customer);
            var customerCreditCalculator = new CustomerCreditChecker(mock.Object);

            var result = customerCreditCalculator.CustomerHasCredit(customer);

            Assert.That(result == true);
        }

        [Test]
        public void CalculateCredit_ImportantClientHasLimit_ReturnsTrue()
        {
            Mock<ICustomerCreditCalculator> mock = new Mock<ICustomerCreditCalculator>();
            var customer = new Customer();
            customer.HasCreditLimit = true;
            customer.CreditLimit = 501;
            mock.Setup(o => o.CalculateCredit(customer)).Returns(customer);
            var customerCreditCalculator = new CustomerCreditChecker(mock.Object);

            var result = customerCreditCalculator.CustomerHasCredit(customer);

            Assert.That(result == true);
        }

        [Test]
        public void CalculateCredit_ClientHasLimit_ReturnsTrue()
        {
            Mock<ICustomerCreditCalculator> mock = new Mock<ICustomerCreditCalculator>();
            var customer = new Customer();
            customer.HasCreditLimit = true;
            customer.CreditLimit = 501;
            mock.Setup(o => o.CalculateCredit(customer)).Returns(customer);
            var customerCreditCalculator = new CustomerCreditChecker(mock.Object);

            var result = customerCreditCalculator.CustomerHasCredit(customer);

            Assert.That(result == true);
        }

        [Test]
        public void CalculateCredit_ImportantClientHasLowLimit_ReturnsFalse()
        {
            Mock<ICustomerCreditCalculator> mock = new Mock<ICustomerCreditCalculator>();
            var customer = new Customer();
            customer.HasCreditLimit = true;
            customer.CreditLimit = 250;
            mock.Setup(o => o.CalculateCredit(customer)).Returns(customer);
            var customerCreditCalculator = new CustomerCreditChecker(mock.Object);

            var result = customerCreditCalculator.CustomerHasCredit(customer);

            Assert.That(result == false);
        }

        [Test]
        public void CalculateCredit_ClientHasLowLimit_ReturnsFalse()
        {
            Mock<ICustomerCreditCalculator> mock = new Mock<ICustomerCreditCalculator>();
            var customer = new Customer();
            customer.HasCreditLimit = true;
            customer.CreditLimit = 250;
            mock.Setup(o => o.CalculateCredit(customer)).Returns(customer);
            var customerCreditCalculator = new CustomerCreditChecker(mock.Object);

            var result = customerCreditCalculator.CustomerHasCredit(customer);

            Assert.That(result == false);
        }
    }
}
