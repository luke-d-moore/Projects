using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRootCalculators.Interfaces
{
    public interface IMethod
    {
        public void Display(int i, decimal number);
        public bool EndIteration(decimal diff);
        decimal Iterate(decimal number, decimal guess);
    }
}
