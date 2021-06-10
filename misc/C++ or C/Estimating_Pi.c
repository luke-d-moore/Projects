//-------------------------------------------------------------------------------------\\
//-------------------------------------------------------------------------------------\\
//-------------- THIS PROGRAM ESTIMATES THE VALUE OF Pi--------------------------------\\
//---------------THIS PROGRAM WAS WRITTEN BY LUKE MOORE--------------------------------\\
//-------------------------------------------------------------------------------------\\
//-------------------------------------------------------------------------------------\\

#include <stdio.h>
#include <math.h>
#include <stdint.h>

int main()
{

    int i, n, j, k;
    double Total, difference, pi;

    printf("how many iterations should be performed? \n");
    printf("(must be an integer and multiple of 10, I recommend 1,000,000)    ");

    scanf("%d", &n);

    printf(" \n\n n = %d \n", n);

    pi = 3.14159265;

    for(j=1; j<=n; j=j*10)
    {
        if(j>n)
        {
            printf("the number of iterations is too small or negative or not an");
            printf("integer the program will be stopped and will not run \n\n");
            return 0;
        }

        Total = 0.00;
    k=0;

    for(i=1; i<=(1+2*j); i=i+2)
    {
        Total += (4.0/(double)i) * (double)pow(-1.0, k);

        //printf("pow = %lf \n", (double)pow(-1, k));
        //printf("Total = %lf, i = %d \n", Total, i);
    k++;
    }

    difference = ((Total - pi)/pi) * 100;

    printf("\n n = %d, Total = %2.8lf, Actual value of pi = 3.14159265, perc_diff = %2.8lf percent\n\n", j, Total, difference);

}
return 0;
}
