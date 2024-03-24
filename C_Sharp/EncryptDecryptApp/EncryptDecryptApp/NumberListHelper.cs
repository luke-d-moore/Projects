using System;
using System.Collections.Generic;
using System.Text;
using EncryptDecryptApp.Interfaces;
using System.Linq;

namespace EncryptDecryptApp
{
    public class NumberListHelper : INumberListGenerator
    {
		private double _root = Math.PI;
		private IIrrationalNumberGenerator _irrationalNumberGenerator;
		public NumberListHelper(IIrrationalNumberGenerator irrationalNumberGenerator)
        {
			_irrationalNumberGenerator = irrationalNumberGenerator;
        }

        public char[] getCleanNumberString(string numberString)
        {
			List<char> cleanNumberList = new List<char>();
			foreach (char numberCharacter in numberString.ToCharArray())
			{
				if (numberCharacter != Convert.ToChar("."))
				{
					cleanNumberList.Add(numberCharacter);
				}
			}
			return cleanNumberList.ToArray();
		}

        public List<int> getNumberList(int length, double encryptionNumber)
        {
			List<int> offsetNumberslist = new List<int>();
			int charNumber = 0;
			string numberString = string.Empty;
			while (offsetNumberslist.Count <= length)
			{
				if (charNumber >= 1)
				{
					_root += offsetNumberslist[offsetNumberslist.Count - 1] / 100;
				}
				numberString = _irrationalNumberGenerator.getIrrationalNumber(encryptionNumber, _root).ToString();
				char[] cleanNumberChars = getCleanNumberString(numberString);
				int i = 0;
				while (i <= 13 && i < cleanNumberChars.Length - 1)
				{
					string offsetNumber = cleanNumberChars[i].ToString();
					offsetNumber += cleanNumberChars[i + 1].ToString();
					int offsetNumberInteger = Convert.ToInt32(offsetNumber);
					offsetNumberInteger += offsetNumberslist.Where(o => o == offsetNumberInteger).Count();
					offsetNumberslist.Add(offsetNumberInteger);
					i++;
				}
				charNumber++;
			}

			return offsetNumberslist;
		}
	}
}
