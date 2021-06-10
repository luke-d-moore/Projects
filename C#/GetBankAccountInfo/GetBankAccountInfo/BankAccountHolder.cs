using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetBankAccountInfo.Interfaces;

namespace GetBankAccountInfo
{
    public class BankAccountHolder : IBankAccountHolder
    {
        private string _AccountHolderName;
        private string _AccountHolderAddress;
        private DateTime _AccountHolderDateOfBirth;
        public string GetAccountHolderName()
        {
            return _AccountHolderName;
        }

        public string GetAddress()
        {
            return _AccountHolderAddress;
        }

        public string GetDateOfBirth()
        {
            return _AccountHolderDateOfBirth.ToString("dd/MM/yyyy");
        }
        public BankAccountHolder(string accountHolderName, string accountHolderAddress, DateTime accountHolderDateOfBirth)
        {
            _AccountHolderName = accountHolderName;
            _AccountHolderAddress = accountHolderAddress;
            _AccountHolderDateOfBirth = accountHolderDateOfBirth;
        }
    }
}
