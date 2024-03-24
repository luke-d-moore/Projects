using Moq;
using NUnit.Framework;
using CustomersRESTAPI;
using CustomersRESTAPI.Content;
using CustomersRESTAPI.Interfaces;
using System.Linq;
using System.Collections.Generic;
using CustomersRESTAPI.Services;
using Newtonsoft.Json;

namespace CustomersRESTAPITests
{
    public class CustomerServiceTests
    {

        private Mock<ICustomersProcessor> _MockProcessor;
        private ICustomerResponse _Response;
        private CustomersService _Service;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _MockProcessor = new Mock<ICustomersProcessor>();
            _Service = new CustomersService(_MockProcessor.Object);
        }

        [SetUp]
        public void Setup()
        {
            _Response = new CustomersResponse();
            _Response.Errors = new List<string>();
            _Response.Customers = new List<ICustomer>();
            _Response.Success = true;
        }

        [Test]
        public void Post_ValidRequest_ReturnsTrue()
        {
            var customer = new Customer();
            customer.Name = "Test7";
            customer.CustomerID = 7;
            customer.DateOfBirth = "17/07/2007";
            _MockProcessor.Setup(o => o.Post(It.IsAny<ICustomerResponse>(), It.IsAny<ICustomer>())).Returns(_Response);

            _Response = _Service.Post(customer);

            Assert.That(_Response.Success && !_Response.Errors.Any() && !_Response.Customers.Any());
        }

        [Test]
        public void Post_NullRequest_ReturnsFalse()
        {
            var customer = new Customer();
            customer = null;

            _Response = _Service.Post(customer);

            Assert.That(!_Response.Success && _Response.Errors.Any() && !_Response.Customers.Any());
        }

        [Test]
        public void Put_ValidRequest_ReturnsTrue()
        {
            var customer = new Customer();
            customer.Name = "Test7";
            customer.CustomerID = 3;
            customer.DateOfBirth = "17/07/2007";
            _MockProcessor.Setup(o => o.Put(It.IsAny<ICustomerResponse>(), It.IsAny<ICustomer>())).Returns(_Response);

            _Response = _Service.Put(customer);

            Assert.That(_Response.Success && !_Response.Errors.Any() && !_Response.Customers.Any());
        }

        [Test]
        public void Put_NullRequest_ReturnsFalse()
        {
            var customer = new Customer();
            customer = null;

            _Response = _Service.Put(customer);

            Assert.That(!_Response.Success && _Response.Errors.Any() && !_Response.Customers.Any());
        }

    }
}