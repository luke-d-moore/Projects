using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToRomanNumeral
{
	class NumberProcessor
	{
		private int _maxNumber;
		
		public NumberProcessor(int maxNumber) {
			_maxNumber = maxNumber;
		}
		public bool Validate(int numberToBeConverted)
		{
			if (numberToBeConverted >= _maxNumber)
			{
				Console.WriteLine($"Number Must not be greater than or equal to {_maxNumber}");
				return false;
			}
			return true;
		}
		public string Process(string numberToBeConvertedToRomanNumeral)
		{
			string romanNumeral = "";

			switch (numberToBeConvertedToRomanNumeral)
			{
				case "1":
					return "I";
				case "5":
					return "V";
				case "10":
					return "X";
				case "50":
					return "L";
				case "100":
					return "C";
				case "500":
					return "D";
				case "1000":
					return "M";
			}
			int lengthOfNumber = numberToBeConvertedToRomanNumeral.Length;
			Char[] individualNumbers = numberToBeConvertedToRomanNumeral.ToCharArray();
			//the case for a length 1 string should work but the later ones 
			//we will need to split the string and only sned through the relevant character to the function 
			switch (lengthOfNumber)
			{
				case 1:
					romanNumeral += UpTo10(individualNumbers[0].ToString());
					break;
				case 2:
					romanNumeral += UpTo100(individualNumbers[0].ToString());
					romanNumeral += UpTo10(individualNumbers[1].ToString());
					break;
				case 3:
					romanNumeral += UpTo1000(individualNumbers[0].ToString());
					romanNumeral += UpTo100(individualNumbers[1].ToString());
					romanNumeral += UpTo10(individualNumbers[2].ToString());
					break;
				case 4:
					romanNumeral += Above1000(individualNumbers[0].ToString());
					romanNumeral += UpTo1000(individualNumbers[1].ToString());
					romanNumeral += UpTo100(individualNumbers[2].ToString());
					romanNumeral += UpTo10(individualNumbers[3].ToString());
					break;
			}

			return romanNumeral;
		}
		public string UpTo10(string under10)
		{
			switch (under10)
			{
				case "1":
					return "I";
				case "2":
					return "II";
				case "3":
					return "III";
				case "4":
					return "IV";
				case "5":
					return "V";
				case "6":
					return "VI";
				case "7":
					return "VII";
				case "8":
					return "VIII";
				case "9":
					return "IX";
				default:
					return "";
			}
		}
		public string UpTo100(string upTo100)
		{
			//this function only contains filler to be updated with the correct values later
			switch (upTo100)
			{
				case "1":
					return "X";
				case "2":
					return "XX";
				case "3":
					return "XXX";
				case "4":
					return "XL";
				case "5":
					return "L";
				case "6":
					return "LX";
				case "7":
					return "LXX";
				case "8":
					return "LXXX";
				case "9":
					return "XC";
				default:
					return "";
			}
		}
		public string UpTo1000(string upto1000)
		{
			//this function only contains filler to be updated with the correct values later
			switch (upto1000)
			{
				case "1":
					return "C";
				case "2":
					return "CC";
				case "3":
					return "CCC";
				case "4":
					return "CD";
				case "5":
					return "D";
				case "6":
					return "DC";
				case "7":
					return "DCC";
				case "8":
					return "DCCC";
				case "9":
					return "CM";
				default:
					return "";
			}
		}
		public string Above1000(string Above1000)
		{
			//this function only contains filler to be updated with the correct values later
			switch (Above1000)
			{
				case "1":
					return "M";
				case "2":
					return "MM";
				case "3":
					return "MMM";
				case "4":
					return "MMMM";
				default:
					return "";
			}
		}
		public void DisplayRomanNumeral(string numberToBeConvertedString, string romanNumeral)
		{
			if (romanNumeral == "")
			{
				romanNumeral = "N/A";
			}
			Console.WriteLine($"Number {numberToBeConvertedString} has been converted to {romanNumeral}");
		}
    }
}
