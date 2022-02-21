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

			var watch = new System.Diagnostics.Stopwatch();

			watch.Start();

			decimal actual = new decimal(Math.Sqrt(decimal.ToDouble(original)));

			watch.Stop();

			Console.WriteLine($"Actual value is {actual}");

			Console.WriteLine($"Execution Time for Actual Method: {watch.ElapsedMilliseconds} ms");

			IMethod lukeMethod = new LukeMethod(original, actual);

			watch.Restart();

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

			watch.Stop();

			Console.WriteLine($"Execution Time for Newton Method: {watch.ElapsedMilliseconds} ms");

			lukeMethod.Iterate(original,original);
		}
    }
}
