using NUnit.Framework;
using GetBankAccountInfo;

namespace GetBankAccountInfoTests
{
    public class AccountTests
    {
        private Account _Account;
        [OneTimeSetUp]
        public void Setup()
        {
            _Account = new Account(1, "01-01-01", 55);
        }
        [Test]
        public void Account_CorrectAccountNumber_ReturnsTrue()
        {
            Assert.That(_Account.GetAccountNumber() == 1);
        }
        [Test]
        public void Account_CorrectSortCode_ReturnsTrue()
        {
            Assert.That(_Account.GetSortCode() == "01-01-01");
        }
        [Test]
        public void Account_CorrectBalance_ReturnsTrue()
        {
            Assert.That(_Account.GetBalance() == 55);
        }
    }
}