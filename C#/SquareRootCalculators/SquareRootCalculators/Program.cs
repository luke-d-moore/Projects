using System;
using SquareRootCalculators.Classes;
using SquareRootCalculators.Interfaces;

namespace SquareRootCalculators
{
    class Program
    {
        static void Main(string[] args)
        {
			IMethod method = new NewtonsMethod();
			decimal original = 137;

			decimal guess = original;

			decimal ans;

			int i = 0;

			while (true)
			{
				i++;

				ans = method.Iterate(original, guess);

				method.Display(i, ans);

				if (method.EndIteration(ans-guess))
					break;

				guess = ans;
			}
		}
    }
}
