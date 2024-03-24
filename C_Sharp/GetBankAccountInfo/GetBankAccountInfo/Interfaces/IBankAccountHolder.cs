using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBankAccountInfo.Interfaces
{
	public interface IBankAccountHolder
	{
		public string GetAccountHolderName();
		public string GetAddress();
		public string GetDateOfBirth();
	}
}
