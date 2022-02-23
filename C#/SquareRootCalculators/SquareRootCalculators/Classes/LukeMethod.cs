using System;
using System.Collections.Generic;
using System.Text;
using SquareRootCalculators.Interfaces;

namespace SquareRootCalculators.Classes
{
    public class LukeMethod : Method, IMethod
    {

        //Explanation of the method
        //Start with a value Num, which is the number to be square rooted
        //start with 2 points on the curve of y=x^2
        //one which is definitely below the square root and one which is higher
        //xL is the lower X value, yL is lower y value = xL*xL
        //xB is the Bigger X value, yB is Bigger y value = xB*xB
        //start off with xL =0 and xB = Number to be square rooted
        //x0 is the new estimate of the square root
        //then apply the formula
        //x0 = (xB-xL)*((Num-yL)/(yB-yL)) + xL
        //this formula works by first assuming linearity between the points (xL,yL) and (xB,yB)
        //then it takes the big value and weights to 100 and lower value weighted to 0 and 
        //works out a fraction number F, representing where the number which is being square rooted lies
        //then it applies this fraction F to the x values to estimate a new value for x0
        //if x0*x0 < Num then x0 is less than the square root and x0 is the new xL
        //if x0*x0 > Num then x0 is greater than the square root and x0 is the new xB 
        //then repeat and it rapidly converges to the value of the square root in most cases faster than Newtons Method
        //There is an adjustment which is being done based on the fraction F mentioned before
        //to help narrow the range between xB and xL the value of the fraction is taken into account to 
        //adjust the value of xB during each iteration to trim the number range which we know the 
        //square root is definitely not in this allows more rapid convergence

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

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

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

            watch.Stop();

            Console.WriteLine($"Execution Time for Luke Method: {watch.ElapsedMilliseconds} ms");

            return x_L;
        }

        private void FindNextValue(decimal Num, decimal x_L, decimal x_B)
        {
            x_B = AdjustX_B(x_L, x_B);
            SetX_B(x_B);

            var F = FindF(Num, x_L * x_L, x_B * x_B);

            var x_0 = FindX_0(x_L, x_B, F);

            SetX_L(x_0);

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

        private decimal AdjustX_B(decimal x_L, decimal x_B)
        {
            decimal factor = 0M;

            decimal newXB = x_B;

            decimal returnValueNewX_B = x_B;

            while(newXB * newXB > Num)
            {
                returnValueNewX_B = newXB;

                factor += 0.05M;

                newXB = x_B - (x_B - x_L) * factor;
            }

            return returnValueNewX_B;
        }
    }
}
