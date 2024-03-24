using Moq;
using NUnit.Framework;
using CustomersRESTAPI;
using CustomersRESTAPI.Content;
using CustomersRESTAPI.Interfaces;
using CustomersRESTAPI.Processors;
using System.Linq;
using System.Collections.Generic;

namespace CustomersRESTAPITests
{
    public class CustomerProcessorTests
    {

        private Mock<ICustomerRepository> _MockRepo;
        private ICustomer _Customer;
        private ICustomerResponse _Response;
        private CustomerProcessor _Processor;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _MockRepo = new Mock<ICustomerRepository>();
            _Customer = new Customer();
            _Response = new CustomersResponse();
            _Processor = new CustomerProcessor(_MockRepo.Object);
        }

        [SetUp]
        public void Setup()
        {
            _Customer = new Customer();
            _Response = new CustomersResponse();
            _Response.Errors = new List<string>();
            _Response.Customers = new List<ICustomer>();
        }

        [Test]
        public void Get_ValidID_ReturnsTrue()
        {
            _MockRepo.Setup(o => o.GetByID(1)).Returns(_Customer);

            _Response = _Processor.Get(_Response, 1);

            Assert.That(_Response.Success && !_Response.Errors.Any() && _Response.Customers.Any());
        }

        [Test]
        public void Get_InValidID_ReturnsFalse()
        {
            _Customer = null;
            _MockRepo.Setup(o => o.GetByID(-1)).Returns(_Customer);

            _Response = _Processor.Get(_Response , -1);

            Assert.That(!_Response.Success && _Response.Errors.Any() && !_Response.Customers.Any());
        }

        [Test]
        public void Delete_ValidID_ReturnsTrue()
        {
            _MockRepo.Setup(o => o.Delete(1)).Returns(true);

            _Response = _Processor.Delete(_Response, 1);

            Assert.That(_Response.Success && !_Response.Errors.Any() && !_Response.Customers.Any());
        }

        [Test]
        public void Delete_InValidID_ReturnsFalse()
        {
            _MockRepo.Setup(o => o.Delete(-1)).Returns(false);

            _Response = _Processor.Delete(_Response, -1);

            Assert.That(!_Response.Success && _Response.Errors.Any() && !_Response.Customers.Any());
        }

        [Test]
        public void Post_ValidID_ReturnsTrue()
        {
            _Customer.Name = "Test7";
            _Customer.CustomerID = 7;
            _Customer.DateOfBirth = "17/07/2007";
            _MockRepo.Setup(o => o.Add(It.IsAny<ICustomer>())).Returns(true);

            _Response = _Processor.Post(_Response, _Customer);

            Assert.That(_Response.Success && !_Response.Errors.Any());
        }

        [Test]
        public void Post_DuplicateID_ReturnsFalse()
        {
            _Customer.Name = "Test2";
            _Customer.CustomerID = 2;
            _Customer.DateOfBirth = "17/07/2007";

            _Response = _Processor.Post(_Response, _Customer);

            Assert.That(!_Response.Success && _Response.Errors.Any());
        }

        [Test]
        public void Post_FailedAdd_ReturnsFalse()
        {
            _Customer.Name = "Test7";
            _Customer.CustomerID = 7;
            _Customer.DateOfBirth = "17/07/2007";
            _MockRepo.Setup(o => o.Add(It.IsAny<ICustomer>())).Returns(false);

            _Response = _Processor.Post(_Response, _Customer);

            Assert.That(!_Response.Success && _Response.Errors.Any());
        }

        [Test]
        public void Put_ValidID_ReturnsTrue()
        {
            _Customer.Name = "Test1";
            _Customer.CustomerID = 1;
            _Customer.DateOfBirth = "17/07/2007";
            _MockRepo.Setup(o => o.Update(It.IsAny<ICustomer>())).Returns(true);

            _Response = _Processor.Put(_Response, _Customer);

            Assert.That(_Response.Success && !_Response.Errors.Any());
        }

        [Test]
        public void Put_NewID_ReturnsFalse()
        {
            _Customer.Name = "Test22";
            _Customer.CustomerID = 22;
            _Customer.DateOfBirth = "17/07/2007";

            _Response = _Processor.Put(_Response, _Customer);

            Assert.That(!_Response.Success && _Response.Errors.Any());
        }

        [Test]
        public void Put_FailedUpdate_ReturnsFalse()
        {
            _Customer.Name = "Test1";
            _Customer.CustomerID = -1;
            _Customer.DateOfBirth = "17/07/2007";
            _MockRepo.Setup(o => o.Update(It.IsAny<ICustomer>())).Returns(false);

            _Response = _Processor.Put(_Response, _Customer);

            Assert.That(!_Response.Success && _Response.Errors.Any());
        }

    }
}