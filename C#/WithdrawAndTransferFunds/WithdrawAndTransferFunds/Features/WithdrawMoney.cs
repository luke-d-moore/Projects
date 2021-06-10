using WithdrawAndTransferFunds.DataAccess;
using WithdrawAndTransferFunds.Domain.Services;
using System;
using WithdrawAndTransferFunds;

namespace WithdrawAndTransferFunds.Features
{
    public class WithdrawMoney
    {
        private IAccountRepository _accountRepository;
        private INotificationService _notificationService;

        public WithdrawMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            _accountRepository = accountRepository;
            _notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {
            var account = _accountRepository.GetAccountById(fromAccountId);

            account.WithdrawValidate(amount, Account.eActionType.withdraw);

            var balanceAfterWithdrawal = account.Balance - amount;

            account.Withdraw(amount);
            account.NotifyAccountHolders(_notificationService, balanceAfterWithdrawal, Account.eActionType.withdraw);

            _accountRepository.Update(account);
        }
    }
}
