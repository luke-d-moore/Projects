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

			decimal actual = new decimal(Math.Sqrt(decimal.ToDouble(original)));

			IMethod lukeMethod = new LukeMethod(original, actual);

			decimal ans;

			int i = 0;

			while (i<= method.getMaxIterations())
			{
				i++;

				ans = method.Iterate(original, guess);

				method.Display(i, ans, actual);

				if (method.EndIteration(ans-guess))
					break;

				guess = ans;
			}

			lukeMethod.Iterate(original,original);

			Console.WriteLine($"Actual value is {actual}");
		}
    }
}
