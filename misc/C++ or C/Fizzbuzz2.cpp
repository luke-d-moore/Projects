//**************************************************\\
//**************************************************\\
//********THIS CODE WAS WRITTEN BY LUKE MOORE*******\\
//**************************************************\\
//**************************************************\\

#include<iostream>

using namespace std;

int main()
{
    int i=1;

    while(i<32)
    {

    if ((i%3==0)&&(i%5==0))
    {
        cout << "Fizzbuzz" << endl;
    }
    else if (i%3 ==0)
    {
        cout << "Fizz" << endl;
    }
    else if (i%5==0)
    {
        cout << "Buzz" << endl;
    }
    else
    {
        cout << i << endl;
    }
    i++;
    }
    return 0;
}
