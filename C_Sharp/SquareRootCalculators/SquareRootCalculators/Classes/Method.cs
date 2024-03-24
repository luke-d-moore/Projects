using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRootCalculators.Classes
{
    public class Method
    {
        public decimal precision = new decimal (0.00001);
        public int maxIterations = 20;
        public void Display(int i, decimal number, decimal actual)
        {
            Console.WriteLine($"Result : {number}, iteration : {i}, Accuracy Within : {(Math.Abs(actual-number)/actual) * 100} %");
        }

        public bool EndIteration(decimal diff)
        {
            return Math.Abs(diff) < precision;
        }
    }
}
