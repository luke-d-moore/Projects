//**************************************************\\
//**************************************************\\
//*************THIS CODE WAS WRITTEN BY*************\\
//********************LUKE MOORE********************\\
//**************************************************\\
//***********THE FAMOUS FIZZBUZZ PROGRAM************\\
//***************************************************\\
//***************************************************\\

#include <iostream>
#include <string>
#include <math.h>
using namespace std;

int main()
{
    int number, stopnumber;

    number = 1;
    cout << "Enter stopnumber : ( must be an integer)   ";
    cin >> stopnumber;

    for (number=1; number <= stopnumber ; number= number + 1)
            {
                cout << "\n" << number;
                if (number % 3 == 0)
                {
                    cout << "  Fizz";
                    if(number % 5 ==0)
                        {
                            cout << "Buzz";
                        }
                        else{}
                }
                else if(number % 5 == 0)
                {
                    cout << "  Buzz";

                }
                else {}
            }

    return 0;
}
