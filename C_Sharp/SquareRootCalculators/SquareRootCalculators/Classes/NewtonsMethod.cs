using System;
using System.Collections.Generic;
using System.Text;
using SquareRootCalculators.Interfaces;

namespace SquareRootCalculators.Classes
{
    public class NewtonsMethod : Method, IMethod
    {
        public int getMaxIterations()
        {
            return maxIterations;
        }

        public decimal Iterate(decimal number, decimal guess)
        {
            decimal ans = (guess + (number / guess))/2;

            return ans;
        }
    }
}
