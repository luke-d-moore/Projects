using System;
using System.Collections.Generic;
using System.Text;
using EncryptDecryptApp.Interfaces;

namespace EncryptDecryptApp
{
    public class Decrypter : EncryptionBase, IDecrypter
    {
		public Decrypter(string stringToProcess, double encryptionNumber,
							IAllowedCharactersGenerator allowedCharactersGenerator,
							INumberListGenerator numberListGenerator)
		{
			_stringToProcess = stringToProcess;
			_encryptionNumber = encryptionNumber;
			_allowedCharactersGenerator = allowedCharactersGenerator;
			_numberListGenerator = numberListGenerator;

		}

		public string Decrypt()
        {
			char[] charsToProcess;
			charsToProcess = _stringToProcess.ToCharArray();
			List<int> offsetNumbersList = _numberListGenerator.getNumberList(_stringToProcess.Length, _encryptionNumber);
			string allowedCharacters = _allowedCharactersGenerator.getAllowedCharacters();
			string resultString = "";
			int i = 0;
			int index;
			foreach (char characterToProcess in charsToProcess)
			{
				index = allowedCharacters.IndexOfAny(characterToProcess.ToString().ToCharArray());

					index -= Convert.ToInt16(offsetNumbersList[i]);
					while (index < 0)
					{
						index += allowedCharacters.Length;
					}

				resultString += allowedCharacters.Substring(index, 1);

				if (offsetNumbersList.Count == i + 1)
				{
					i = 0;
				}
				else
				{
					i++;
				}
			}
			return resultString;
		}
    }
}
