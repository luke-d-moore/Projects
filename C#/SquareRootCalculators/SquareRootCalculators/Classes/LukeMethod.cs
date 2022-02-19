using System;
using System.Collections.Generic;
using System.Text;
using SquareRootCalculators.Interfaces;

namespace SquareRootCalculators.Classes
{
    public class LukeMethod : Method, IMethod
    {
        private decimal Num;
        private decimal x_B;
        private decimal x_L;
        private decimal prevXLValue;
        private decimal actual;

        private decimal y_L
        {
            get
            {
                return x_L * x_L;
            }
            set
            {

            }
        }
        private decimal y_B
        {
            get
            {
                return x_B * x_B;
            }
            set
            {

            }
        }

        public LukeMethod(decimal Num, decimal guess, decimal actual)
        {
            this.Num = Num;
            x_B = guess;
            if(x_B*x_B < Num)
            {
                x_B = Num / 2;
            }
            x_L = 0;
            this.actual = actual;
        }

        public int getMaxIterations()
        {
            return maxIterations;
        }

        public decimal Iterate(decimal number, decimal guess)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("========Luke Method Here==========");
            Console.WriteLine("==================================");

            int i = 0;
            while (i<=getMaxIterations())
            {
                i++;
                FindNextValue(i);

                Display(i, x_L, actual);

                if(EndIteration(x_L - prevXLValue))
                    break;

            }

            return x_L;
        }

        private decimal FindF(decimal Num, decimal y_L, decimal y_B)
        {

            return (Num - y_L) / (y_B - y_L);
        }

        private void AdjustX_B(decimal F)
        {
            decimal factor = 0M;

            if (F < 0.10M)
            {
                factor = 0.9M;
            }
            else if (F < 0.20M)
            {
                factor = 0.8M;
            }
            else if (F < 0.30M)
            {
                factor = 0.7M;
            }
            else if (F < 0.40M)
            {
                factor = 0.6M;
            }
            else if (F < 0.50M)
            {
                factor = 0.5M;
            }
            else if (F < 0.60M)
            {
                factor = 0.4M;
            }
            else if (F < 0.70M)
            {
                factor = 0.3M;
            }
            else if (F < 0.80M)
            {
                factor = 0.2M;
            }
            else if (F < 0.90M)
            {
                factor = 0.1M;
            }
            else
            {
                factor = 0M;
            }

            var newXB = x_B - (x_B - x_L) * factor;

            if (newXB * newXB > Num)
            {
                x_B = newXB;
            }
            else
            {
                FineAdjustX_B(F);
            }
        }

        private void FineAdjustX_B(decimal F)
        {
            decimal factor = 0M;
            if (F < 0.5M)
            {
                factor = 0.5M;
            }
            x_B = x_B - (x_B - x_L) * factor;

        }

        private void FindNextValue(int i)
        {
            prevXLValue = x_L;

            var F = FindF(Num, y_L, y_B);
            AdjustX_B(F);

            F = FindF(Num, y_L, y_B);

            var x_0 = (x_B - x_L) * F + x_L;

            var sq_X_0 = x_0 * x_0;

            if (sq_X_0 > Num)
            {
                x_B = x_0;
            }
            else
            {
                x_L = x_0;
            }

        }

    }
}
