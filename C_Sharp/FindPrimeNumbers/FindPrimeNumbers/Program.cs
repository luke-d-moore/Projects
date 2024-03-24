using FindPrimeNumbers.Classes;

namespace FindPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 1000;
            var initialListGenerator = new InitialListGenerator(maxNumber);
            var multipleRemover = new MultipleRemover();
            var PrimeNumberGenerator = new PrimeGenerator(initialListGenerator, multipleRemover);
            var DisplayPrimeNumbers = new DisplayPrimeNumbers(PrimeNumberGenerator);
            DisplayPrimeNumbers.Display();

        }
    }
}
