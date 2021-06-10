//**************************************************\\
//**************************************************\\
//*************THIS CODE WAS WRITTEN BY*************\\
//********************LUKE MOORE********************\\
//**************************************************\\
//****SOLVES A QUADRATIC EQUATION FROM USER INPUT****\\
//***************************************************\\
//***************************************************\\

#include<iostream>
#include<math.h>
using namespace std;

int main()
{
    double a, b, c, d, x1, x2;
    cout << "This program solves a quadratic equation of the form ax^2+bx+c=0 \n";
    cout << "Enter a\n";
    cin >> a;
    cout << "Enter b \n";
    cin >> b;
    cout << "Enter c \n";
    cin >> c;
    cout << "The Quadratic equation you have asked to solve is :  " << a <<" x^2 + " << b << " x + " << c << " = 0 \n";
    d = (b*b)-4*a*c;
    if (d>= 0)
    {
        x1 = (-b +sqrt(d))/(2*a);
        x2 = (-b -sqrt(d))/(2*a);
        cout << "The First solution is : " << x1;
        cout << "\nThe Second solution is : " << x2;
    }
    else
        {
        cout << "The solutions of the Quadratic equation are imaginary, Cannot perform square root of negative number \n";
        cout << "The operation will be cancelled \n";
        }
    return 0;
}
