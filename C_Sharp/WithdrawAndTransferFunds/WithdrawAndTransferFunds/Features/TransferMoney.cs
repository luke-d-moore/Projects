using WithdrawAndTransferFunds.DataAccess;
using WithdrawAndTransferFunds.Domain.Services;
using System;

namespace WithdrawAndTransferFunds.Features
{
    public class TransferMoney
    {
        private IAccountRepository _accountRepository;
        private INotificationService _notificationService;

        public TransferMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            _accountRepository = accountRepository;
            _notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            var from = _accountRepository.GetAccountById(fromAccountId);
            var to = _accountRepository.GetAccountById(toAccountId);

            from.WithdrawValidate(amount, Account.eActionType.transfer);
            to.TransferValidate(amount);

            var fromBalance = from.Balance - amount;
            var paidIn = to.PaidIn + amount;

            from.Withdraw(amount);
            from.NotifyAccountHolders(_notificationService, fromBalance, Account.eActionType.withdraw);

            to.Transfer(amount);
            to.NotifyAccountHolders(_notificationService, paidIn, Account.eActionType.transfer);

            _accountRepository.Update(from);
            _accountRepository.Update(to);
        }
    }
}
