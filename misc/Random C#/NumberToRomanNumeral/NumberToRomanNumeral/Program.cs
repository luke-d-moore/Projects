using System;
using System.Text;

namespace NumberToRomanNumeral
{
    class Program
    {
        static void Main(string[] args)
        {
			const int maxNumber = 5000;
			string numberToBeConvertedString = "4358";
			int numberToBeConverted=0;
			string romanNumeral = "";
			NumberProcessor numberProcessor = new NumberProcessor(maxNumber);
			bool errorOccurred = false;

			try
			{
				numberToBeConverted = Int32.Parse(numberToBeConvertedString);
				if (numberProcessor.Validate(numberToBeConverted))
				{
					romanNumeral = numberProcessor.Process(numberToBeConverted.ToString());
				}
				else
				{
					errorOccurred = true;
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid Input");
				errorOccurred = true;
			}
			if (!errorOccurred)
			{
				numberProcessor.DisplayRomanNumeral(numberToBeConverted.ToString(), romanNumeral);
			}
			Console.ReadLine();
		}
    }
}