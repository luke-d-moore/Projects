using System;
using WithdrawAndTransferFunds.Domain.Interfaces;

namespace WithdrawAndTransferFunds.DataAccess
{
    public interface IAccountRepository
    {
        IAccount GetAccountById(Guid accountId);

        void Update(IAccount account);
    }
}
