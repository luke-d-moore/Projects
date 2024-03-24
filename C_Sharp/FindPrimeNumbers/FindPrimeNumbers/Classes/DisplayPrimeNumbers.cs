using System;
using System.Collections.Generic;
using FindPrimeNumbers.Interfaces;

namespace FindPrimeNumbers.Classes
{
    public class DisplayPrimeNumbers : IDisplayPrimeNumbers
    {
        private IPrimeGenerator _primeGenerator;
        public DisplayPrimeNumbers(IPrimeGenerator primeGenerator)
        {
            _primeGenerator = primeGenerator;
        }
        public void Display()
        {
            foreach (int i in _primeGenerator.GetPrimeNumbers())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(_primeGenerator.GetPrimeNumbers().Count + " Prime Numbers were Found");
        }
    }
}
