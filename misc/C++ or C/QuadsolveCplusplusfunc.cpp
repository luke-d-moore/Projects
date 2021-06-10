//**************************************************\\
//**************************************************\\
//*************THIS CODE WAS WRITTEN BY*************\\
//********************LUKE MOORE********************\\
//**************************************************\\
//****SOLVES A QUADRATIC EQUATION FROM USER INPUT****\\
//***************************************************\\
//***************************************************\\

#include<iostream>
#include<iomanip>
#include<math.h>
using namespace std;

double Quadsolveplus(double a, double b, double c)
{
    double d, y;


    d = (b*b)-4.0*a*c;

    if (d>= 0)
    {
        return y = (-b +sqrt(d))/(2.0*a);

    }
    else
        {
        cout << "The solutions of the Quadratic equation are imaginary, Cannot perform square root of negative number \n";
        cout << "The operation will be cancelled \n";
        }
}
double Quadsolveminus(double a, double b, double c)
{
    double d, z;


    d = (b*b)-4.0*a*c;

    if (d>= 0)
    {
        return z = (-b -sqrt(d))/(2.0*a);
    }
    else
        {

        }
}

int main()
{
    double a, b, c, x1, x2;
    cout << "This program solves a quadratic equation of the form ax^2+bx+c=0 \n";
    cout << "Enter a\n";
    cin >> a;
    cout << "Enter b \n";
    cin >> b;
    cout << "Enter c \n";
    cin >> c;
    cout << "The Quadratic equation you have asked to solve is :  " << a <<" x^2 + " << b << " x + " << c << " = 0 \n";
    x1 = Quadsolveplus(a, b, c);
    x2 = Quadsolveminus(a,b,c);
    cout << "\nThe First solution is : " << x1 << endl;
    cout << "\nThe Second solution is : " << x2 << endl;
    std::cout << std::setprecision(10) << "x1 =  " << x1 << "\n";
    std::cout << std::setprecision(10) << "x2 =  " << x2 << "\n";
    return 0;
}
