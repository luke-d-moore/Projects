//*****************************************************\\
//*****************************************************\\
//*********THIS CODE WAS WRITTEN BY LUKE MOORE*********\\
//*****************************************************\\
//*****************************************************\\

#include <stdio.h>
#include <math.h>
#include <stdint.h>
double Quadsolve(double, double, double);
//defines a function called Quadsolve of the double type with 3 double values being used in it
int main()
{
    double A, B, C;
//defines 3 double variables
    printf("This program solves a Quadratic equation of the form Ax^2 + Bx + C = 0 \n");
//explains what a quadratic is
    printf("Input a value for A \n");
//prompts for a value of A
    scanf("%lf", &A);
//reads a value of A
    printf("Input a value for B \n");
//prompts for a value of B
    scanf("%lf", &B);
//reads a value of B
    printf("Input a value for C \n");
//prompts ofr a value of C
    scanf("%lf", &C);
//reads a value of C
    printf("The values of A, B and C are: %14.8lf, %14.8lf, %14.8lf \n", A, B, C);
//tells the user what the values read in as A B and C were
    Quadsolve( A, B, C);
//calls the function to operate on the variables A, B and C

}
double Quadsolve(double A, double B,double C)
//the function is being written from here
{
    double x1, x2, Bracket, y, l, k, m;
    //variables are being defined in the function
    /*the quadratic formula will be broken up into smaller parts each variable will be a
    different part which will all come together to make the final formula*/

    Bracket = B*B - 4.0*A*C;
    //bracket being calculated

    if (Bracket>=0)
        //bracket is being checked to make sure its not performing square root of a negative number
    {
        //printf("Bracket is equal to %lf \n", Bracket);

        y=sqrt(Bracket);

        if(Bracket==0)
        {
            printf("The (B^2-4*A*C) term is equal to zero, both solutions are equal \n");
            //tells the user that the sqrt was zero so they know why the 2 solutions were the same
        }

        //printf("sqrt bracket is %lf \n", y);

        l= -B +y;

        k = -B-y;

        //printf ("l and k are %lf and %lf \n", l, k);

        m = 2.0 *A;

        //printf("m = %lf \n", m);

        x1 = l/m;
        //calculates solution 1

        x2 = k/m;
        //calculates solution 2

        printf("The first solution is %14.8lf \n", x1);
        //writes solution 1 to the screen

        printf("The second solution is %14.8lf \n", x2);
        //writes solution 2 to the screen
    }
    else
        {
            printf("The solutions of this Quadratic equation are imaginary, the operation will be cancelled \n");
            //writes a message if the values of A B and C given were such that the solutions are imaginary numbers SQRT of negative numbers
        }
        return 0;
}
