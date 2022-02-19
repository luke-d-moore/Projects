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

        public LukeMethod(decimal Num, decimal actual)
        {
            this.Num = Num;
            x_B = Num;
            x_L = 0;
            prevXLValue = x_L;
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
            while (i<=getMaxIterations() && x_L<x_B)
            {
                i++;

                FindNextValue(Num, x_L, x_B);

                //Console.WriteLine($"x_L is {x_L}, x_B is {x_B}");

                Display(i, x_L, actual);

                if(EndIteration(x_L - prevXLValue))
                    break;
            }

            return x_L;
        }

        private void FindNextValue(decimal Num, decimal x_L, decimal x_B)
        {
            SetX_L(x_L);

            var F = FindF(Num, x_L * x_L, x_B * x_B);
            x_B = AdjustX_B(F, x_L, x_B);
            SetX_B(x_B);

            F = FindF(Num, x_L * x_L, x_B * x_B);
            var x_0 = FindX_0(x_L, x_B, F);

            if (x_0 * x_0 > Num)
            {
                SetX_B(x_0);
            }
            else
            {
                SetX_L(x_0);
            }

        }

        private void SetX_B(decimal value)
        {
            this.x_B = value;
        }
        private void SetX_L(decimal value)
        {
            this.prevXLValue = this.x_L;
            this.x_L = value;
        }

        private decimal FindF(decimal Num, decimal y_L, decimal y_B)
        {

            return (Num - y_L) / (y_B - y_L);
        }
        private decimal FindX_0(decimal x_L, decimal x_B, decimal F)
        {
            var x_0 = (x_B - x_L) * F + x_L;
            return x_0;
        }

        private decimal AdjustX_B(decimal F, decimal x_L, decimal x_B)
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
                return newXB;
            }
            else
            {
                return FineAdjustX_B(F, x_L, x_B);
            }
        }

        private decimal FineAdjustX_B(decimal F, decimal x_L, decimal x_B)
        {
            decimal factor = 0M;
            if (F < 0.5M)
            {
                factor = 0.5M;
            }
            return x_B - (x_B - x_L) * factor;
        }

    }
}
