using NUnit.Framework;
using WithdrawAndTransferFunds;
using System;

namespace WithdrawAndTransferFundsTests
{
    public class AccountTests
    {

        [Test]
        public void WithdrawValidate_SufficientFunds_ReturnsTrue()
        {
            var account = new Account();
            account.Balance = 10;

            var result = account.WithdrawValidate(5, Account.eActionType.withdraw);

            Assert.IsTrue(result);
        }

        [Test]
        public void WithdrawValidate_InsufficientFunds_ThrowsException()
        {
            var account = new Account();

            Assert.Throws<InvalidOperationException>(() => account.WithdrawValidate(5, Account.eActionType.withdraw));
        }

        [Test]
        public void TransferValidate_SufficientFunds_ReturnsTrue()
        {
            var account = new Account();
            account.Balance = 10;

            var result = account.TransferValidate(5);

            Assert.IsTrue(result);
        }

        [Test]
        public void TransferValidate_InsufficientFunds_ThrowsException()
        {
            var account = new Account();

            Assert.Throws<InvalidOperationException>(() => account.TransferValidate(4005));
        }

        [Test]
        public void Withdraw_CorrectBalance_ReturnsTrue()
        {
            var account = new Account();
            account.Balance = 10;

            account.Withdraw(5);

            Assert.That(account.Balance == 5 && account.Withdrawn == 5);
        }

        [Test]
        public void Transfer_CorrectBalance_ReturnsTrue()
        {
            var account = new Account();
            account.Balance = 10;

            account.Transfer(5);

            Assert.IsTrue(account.Balance == 15 && account.PaidIn == 5);
        }
    }
}