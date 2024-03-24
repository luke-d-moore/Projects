using System.IO;
using System;

namespace EncryptDecryptApp
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Welcome, Would you like to Encrypt or Decrypt a Message");
			Console.WriteLine("Enter 1 for Encryption, 2 for Decryption and Any other key to end the session");
			string UserCommand = Console.ReadLine();
			string directorypath = Directory.GetCurrentDirectory();

			IrrationalNumberGenerator irrationalNumberGenerator = new IrrationalNumberGenerator();
			NumberListHelper numberListHelper = new NumberListHelper(irrationalNumberGenerator);
			AllowedCharactersHelper allowedCharactersHelper = new AllowedCharactersHelper();

			switch (UserCommand)
			{
				case "1":
					Console.WriteLine("Input Encryption Number: ");
					string encryptionNumberString = Console.ReadLine();

					Console.WriteLine("Please input the name of the file you would like to encrypt");
					string textFileToEncrypt = Console.ReadLine();

					if (File.Exists(directorypath + "\\" + textFileToEncrypt))
					{
						string stringToEncrypt = File.ReadAllText(directorypath + "\\" + textFileToEncrypt);

						double encryptionNumber = Convert.ToDouble(encryptionNumberString);

						Encrypter encrypter = new Encrypter(stringToEncrypt, encryptionNumber, allowedCharactersHelper, numberListHelper);
						string encryptedString = encrypter.Encrypt();
						File.WriteAllText(directorypath + "\\" + textFileToEncrypt, encryptedString);
					}
					else
					{
						Console.WriteLine("File could not be found");
					}
					break;

				case "2":
					Console.WriteLine("Input Decryption Number: ");
					string decryptionNumberString = Console.ReadLine();

					Console.WriteLine("Please input the name of the file you would like to decrypt");
					string textFileToDecrypt = Console.ReadLine();
					if (File.Exists(directorypath + "\\" + textFileToDecrypt))
					{
						string stringToDecrypt = File.ReadAllText(directorypath + "\\" + textFileToDecrypt);

						double decryptionNumber = Convert.ToDouble(decryptionNumberString);
						Decrypter decrypter = new Decrypter(stringToDecrypt, decryptionNumber, allowedCharactersHelper, numberListHelper);
						string decryptedString = decrypter.Decrypt();
						File.WriteAllText(directorypath + "\\" + textFileToDecrypt, decryptedString);
					}
					else
					{
						Console.WriteLine("File could not be found");
					}
					break;
				default:
					break;
			}

			Console.WriteLine("Thank you the Session will now be terminated, press Enter to Exit");

			Console.ReadLine();
        }
    }
}