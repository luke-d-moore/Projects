//**************************************************\\
//**************************************************\\
//*************THIS CODE WAS WRITTEN BY*************\\
//********************LUKE MOORE********************\\
//**************************************************\\
//***FINDS THE VOLUME OF A PYRAMID FROM USER INPUT***\\
//***************************************************\\
//***************************************************\\

#include<stdio.h>
#include<stdlib.h>
#include<math.h>
int main()
{
    int k, N;
    double V, Actual, B, L, H, perc;

    k=0;

    printf("input a value for N, N must be an integer!!! \n");
    printf("(the larger N is the more accurate the answer will be) \n");
    printf("Choose a value of N which satisfies this: 1,000,000 <= N <= 100,000,000 \n");
    printf("Do not put any commas in the number you type \n");
    printf("N = ");
    scanf("%d", &N);
    printf("\n");

    printf("input a value for the height  = ");
    scanf("%lf", &H);
    printf("\n");

    printf("input a value for the length of the square base  = ");
    scanf("%lf", &L);
    printf("\n");

    B = L * L;

    Actual = B * H/3;


    for(k=0; k<=N; k++)
    {
        V+= (L*k/N) * (L*k/N) * H/N;
    }

    printf("Volume of the pyramid is : %14.6lf \n", V);

    printf("Actual volume is: %14.6lf \n", Actual);

    perc = (V-Actual)/V *100;

    printf("percentage difference is: %14.6lf percent", perc);

    return 0;
}
