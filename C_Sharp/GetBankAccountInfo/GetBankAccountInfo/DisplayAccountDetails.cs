using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetBankAccountInfo.Interfaces;

namespace GetBankAccountInfo
{
    public class DisplayAccountDetails : IDisplayAccountInfo
    {
		private IAccount _account;
		private IBankAccountHolder _bankAccountHolder;

		public DisplayAccountDetails(IAccount account, IBankAccountHolder bankAccountHolder)
		{
			_account = account;
			_bankAccountHolder = bankAccountHolder;
		}
		public void DisplayAccountInfo()
        {
				Console.WriteLine("Account Holder Name : {0}", _bankAccountHolder.GetAccountHolderName());
				Console.WriteLine("Address : {0}", _bankAccountHolder.GetAddress());
				Console.WriteLine("Date of Birth : {0}", _bankAccountHolder.GetDateOfBirth());
				Console.WriteLine("Account Number : {0}", _account.GetAccountNumber());
				Console.WriteLine("Account Sort Code : {0}", _account.GetSortCode());
				Console.WriteLine("Account Balance : £ {0}", _account.GetBalance());
		}
    }
}
