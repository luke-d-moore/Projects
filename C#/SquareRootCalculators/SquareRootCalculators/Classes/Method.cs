using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRootCalculators.Classes
{
    public class Method
    {
        public decimal precision = new decimal (0.00001);
        public void Display(int i, decimal number)
        {
            Console.WriteLine($"Result : {number}, iteration : {i}");
        }

        public bool EndIteration(decimal diff)
        {
            return Math.Abs(diff) < precision;
        }
    }
}
