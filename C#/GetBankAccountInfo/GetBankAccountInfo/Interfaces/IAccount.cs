using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBankAccountInfo.Interfaces
{
    public interface IAccount
    {
		public long GetAccountNumber();
		public string GetSortCode();
		public decimal GetBalance();
	}
}
