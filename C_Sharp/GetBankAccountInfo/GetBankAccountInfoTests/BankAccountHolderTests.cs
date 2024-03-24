using NUnit.Framework;
using GetBankAccountInfo;
using System;

namespace GetBankAccountInfoTests
{
    public class BankAccountHolderTests
    {
        private BankAccountHolder _BankAccountHolder;

        [OneTimeSetUp]
        public void Setup()
        {
            _BankAccountHolder = new BankAccountHolder("TestName", "TestAddress", new DateTime(1990, 1, 1));
        }
        [Test]
        public void BankAccountHolder_CorrectAccountHolderName_ReturnsTrue()
        {
            Assert.That(_BankAccountHolder.GetAccountHolderName() == "TestName");
        }
        [Test]
        public void Account_CorrectAddress_ReturnsTrue()
        {
            Assert.That(_BankAccountHolder.GetAddress() == "TestAddress");
        }
        [Test]
        public void Account_CorrectDateOfBirth_ReturnsTrue()
        {
            Assert.That(_BankAccountHolder.GetDateOfBirth() == "01/01/1990");
        }
    }
}
