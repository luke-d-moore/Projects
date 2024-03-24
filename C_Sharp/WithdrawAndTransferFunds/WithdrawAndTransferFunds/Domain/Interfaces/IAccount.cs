using System;
using WithdrawAndTransferFunds.Domain.Services;
using WithdrawAndTransferFunds.Domain;

namespace WithdrawAndTransferFunds.Domain.Interfaces
{
    public interface IAccount
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public decimal Balance { get; set; }
        public decimal Withdrawn { get; set; }
        public decimal PaidIn { get; set; }
        public bool WithdrawValidate(decimal amount, Account.eActionType withdrawalType);
        public bool TransferValidate(decimal amount);
        public void Withdraw(decimal amount);
        public void Transfer(decimal amount);
        public void NotifyAccountHolders(INotificationService notificationService, decimal amount, Account.eActionType NotificationType);
    }
}
