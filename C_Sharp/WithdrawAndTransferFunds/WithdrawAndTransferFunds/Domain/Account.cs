using System;
using WithdrawAndTransferFunds.Domain.Interfaces;
using WithdrawAndTransferFunds.Domain.Services;

namespace WithdrawAndTransferFunds
{
    public class Account :IAccount
    {
        public const decimal PayInLimit = 4000m;

        public enum eActionType
        {
            withdraw,
            transfer
        }

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }

        public decimal Withdrawn { get; set; }

        public decimal PaidIn { get; set; }

        public void NotifyAccountHolders(INotificationService notificationService, decimal amount, eActionType NotificationType)
        {
            if (amount < 500m && NotificationType == eActionType.withdraw)
            {
                notificationService.NotifyFundsLow(User.Email);
            }

            if ((Account.PayInLimit - amount < 500m) && NotificationType == eActionType.transfer)
            {
                notificationService.NotifyApproachingPayInLimit(User.Email);
            }
        }

        public void Transfer(decimal amount)
        {
            Balance += amount;
            PaidIn += amount;
        }

        public bool TransferValidate(decimal amount)
        {
            var result = true;
            var paidIn = PaidIn + amount;
            if (paidIn > PayInLimit)
            {
                result = false;
                throw new InvalidOperationException("Account pay in limit reached");
            }
            return result;
        }

        public void Withdraw(decimal amount)
        {
            Withdrawn += amount;
            Balance -= amount;
        }

        public bool WithdrawValidate(decimal amount, eActionType withdrawalType)
        {
            var result = true;
            var balanceAfterWithdrawal = Balance - amount;
            if (balanceAfterWithdrawal < 0m)
            {
                result = false;
                throw new InvalidOperationException($"Insufficient funds to make {withdrawalType}");
            }
            return result;
        }
    }
}
