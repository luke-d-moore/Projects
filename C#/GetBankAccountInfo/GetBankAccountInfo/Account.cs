using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetBankAccountInfo.Interfaces;

namespace GetBankAccountInfo
{
    public class Account : IAccount
    {
        private long _accountNumber;
        private string _sortCode;
        private Decimal _balance;

        public long GetAccountNumber()
        {
            return _accountNumber;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public string GetSortCode()
        {
            return _sortCode;
        }

        public Account(long accountNumber, string sortCode, Decimal balance)
        {
            _accountNumber = accountNumber;
            _sortCode = sortCode;
            _balance = balance;
        }
    }
}
