using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBankAccountInfo
{
	class Program
	{
		static void Main(string[] args)
		{
			string accountHolderName;
			string address;
			DateTime dateOfBirth;
			long accountNumber;
			string sortCode;
			decimal balance;
			//really there would be a database call here to get this info but getting the info from the user 
			//is an artificial way to test the program works
			Console.WriteLine("Please Enter Accont Holder Name");
			accountHolderName = Console.ReadLine();
			Console.WriteLine("Please Enter Address");
			address = Console.ReadLine();
			Console.WriteLine("Please Enter Date Of Birth as (YYYY-MM-DD) Only");
			dateOfBirth = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
			Console.WriteLine("Please Enter Accont Number");
			accountNumber = long.Parse(Console.ReadLine());
			Console.WriteLine("Please Enter Sort Code");
			sortCode = Console.ReadLine();
			Console.WriteLine("Please Enter Account Balance");
			balance = decimal.Parse(Console.ReadLine());
			Console.WriteLine("--------------------");
			Console.WriteLine("--------------------");
			Console.WriteLine("--------------------");
			//So really there may be the local variables to be set from values in the database and then passed into the constructor below 
			//but the program would be realy quite small a lot of the lines are coming from the user interaction which wouldn't be there
			BankAccountHolder bankAccountHolder = new BankAccountHolder(accountHolderName, address, dateOfBirth);
			Account account = new Account(accountNumber, sortCode, balance);
			DisplayAccountDetails displayAccountDetails = new DisplayAccountDetails(account, bankAccountHolder);
			displayAccountDetails.DisplayAccountInfo();
			Console.ReadKey();
		}
	}
}
