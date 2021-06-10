//********************************************************************\\
//********************************************************************\\
//**************THIS CODE WAS WRITTEN BY LUKE MOORE*******************\\
//********************************************************************\\
//********************************************************************\\
//*****THIS CODE SIMULATES A ROCKET FLYING FROM EARTH TO THE MOON*****\\
//********************************************************************\\
//********************************************************************\\

#include <iostream>
#include <math.h>
#include <fstream>
#include <iomanip>

using namespace std;

const double t = 0.5;
const double G = 6.673e-11;
const double EarthMass = 5.9736e24;
const double MoonMass = 7.347e22;
const double Earthradius = 6.378e6;
const double Moonradius = 1.738e6;
const double EarthMoondist=3.844e8;
const double PI = 3.14159265;
const double theta_constant = 1.5178407e-4;

class Moon
{
    public:
//define function to calculate the x coordinate of moon
double MoonPos_x(double Theta) // need to take in velocity in x direction and velocity in x direction
{
        double Moonx = EarthMoondist * sin(Theta*PI/180.0);
        return Moonx; // returns x coordinate
}
//define function to calculate the y coordinate of moon
double MoonPos_y(double Theta)// need to take in velocity in x direction and velocity in x direction
{
        double Moony = EarthMoondist*cos(Theta*PI/180.0);
       return Moony; // returns the y coordinate
}
};

class Rocket
{
    public:

        double rvalue(double x, double y) //need to take in the values of the x and y coordinate for this function
{
    return sqrt((x*x)+(y*y)); // returns the answer by using pythagoras's theorem
}
double rmoon(double x, double y, double Moonx, double Moony)
{
    return sqrt((x-Moonx)*(x-Moonx)+(y-Moony)*(y-Moony));
}
//define function to calculate the velocity of rocket in x direction
double velocityx(double r, double x, double vel_x, double massrocket, double rmoon, double Moonx)
// need to take in value of r for use in value of gravitational force,
//x coordinate and the previous velocity in x direction
{
    double F_x, F, acc_x, Fmoon, Fmoon_x; // define variables for use in equations
        F = G*massrocket*EarthMass/(r*r); // defines the gravitational force
        Fmoon = G*massrocket*MoonMass/(rmoon*rmoon);
        Fmoon_x = -Fmoon *((x-Moonx)/rmoon);
        F_x = -F*(x/r) + Fmoon_x; // resolves the x component of the gravitational force, F*cos(theta), cos(theta) = adjacent/hyp = x/r
        acc_x = F_x/massrocket; // F = m * a, newtons equation to determine the acceleration of the particle
        vel_x = vel_x + acc_x* t; // standard constant acceleration equation to determine the final velocity from
        //current velocity and time over which acceleration acts for
    return vel_x; // returns velocity in x direction
}
//define function to calculate the velocity of rocket in y direction
double velocityy(double r, double y, double vel_y, double massrocket, double rmoon, double Moony)
// need to take in value of r for use in value of gravitational force,
//y coordinate and the previous velocity in y direction
{
    double F_y, F,acc_y, Fmoon, Fmoon_y;// define variables for use in equations

        F = G*EarthMass*massrocket/(r*r);// defines the gravitational force
        Fmoon = G*massrocket*MoonMass/(rmoon*rmoon);
        Fmoon_y = -Fmoon *((y-Moony)/rmoon);
        F_y = -F*(y/r) + Fmoon_y;// resolves the x component of the gravitational force, F*cos(theta), cos(theta) = adjacent/hyp = x/r
        acc_y = F_y/massrocket;// F = m * a, newtons equation to determine the acceleration of the rocket
        vel_y = vel_y + acc_y* t;// standard constant acceleration equation to determine the final velocity from
        //current velocity and time over which acceleration acts for
    return vel_y; // returns velocity in y direction
}
//define function to calculate the x coordinate of rocket
double x_coord(double x, double vel_x) // need to take in velocity in x direction and velocity in x direction
{
        x = x + vel_x * t; // calculates the new x coordinate from old coordinate and velocity acting for particular time
    return x; // returns x coordinate
}
//define function to calculate the y coordinate of rocket
double y_coord(double y, double vel_y)// need to take in velocity in x direction and velocity in x direction
{
        y = y + vel_y * t;// calculates the new y coordinate from old coordinate and velocity acting for particular time
    return y; // returns the y coordinate
}
};

int main()
{


        int i = 0, n = 0, k = 0, imax = 0;
        double Moonx = 0.0, Moony = 3.844e8;
        double x=0.0, y=Earthradius, vel_x = 0.0, vel_y = 0.0, rmoon = 0.0, r = 0.0, massrocket = 0.0, Angle_adjust = 0.0, Theta = 0.0;



        cout << "enter mass of the rocket" << endl<< endl;
        cin >> massrocket;
        imax = 550000;

        cout << endl << "11120 vel_y and 19.2462 - 20.1621 degree angle adjustment hits the moon"<< endl << endl;
        cout << "20.1645 - 20.9 slingshots around the moon and comes backwards " << endl << endl;
        cout << "enter velocity of rocket in y direction" << endl << endl;
        cout << "must be greater than escape velocity of earth 11055 metres/ second" << endl << endl;
        cin >> vel_y;
        std::cout.precision(16);
        cout << "Once the rocket reaches 300,000 metres above Earth's surface thrusters will be activated to " << endl << endl;
        cout << "adjust the angle the rocket will be flying at, what would you like this angle to be? " << endl << endl;
        cout << "(relative to vertical taken as zero degrees)" << endl << endl;
        cin >> Angle_adjust;
        std::cout << endl << "Angle Adjustment is : " << Angle_adjust << endl << endl;
        //gnuplot> plot 'moon.txt' using 1:2 title "Moon" w lines, 'moon.txt' using 3:4 title "Rocket" w lines

        Moon TheMoon;
        Rocket MyRocket;
        ofstream myfile;
        myfile.open ("Moon.txt");

        while (i<imax)
        {
            myfile << Moonx << "             " << Moony << "         "  << x << "             " << y << endl;
            //cout << Moonx << "             " << Moony << "       " << x << "             " << y << endl;
            //myfile << i << "        " << (((moonearthdist-EarthMoondist)/EarthMoondist)*100) << endl;


            if ( (r >= (Earthradius+300000))&& n < 1)
            {
                //std::cout << "vel_y is " << vel_y << "      r = " << r << endl;
                vel_x = vel_y* sin(Angle_adjust*PI/180.0);
                vel_y = sqrt((vel_y*vel_y)-(vel_x*vel_x));
                //std::cout << "vel_y is " << vel_y << "      r = " << r << endl;
                //std::cout << "vel_x is " << vel_x << endl;
                n++;
            }
            r = MyRocket.rvalue(x, y);
            //cout << r << endl;
            rmoon = MyRocket.rmoon(x, y, Moonx, Moony);
            //cout << rmoon << endl ;
            vel_x = MyRocket.velocityx(r, x, vel_x, massrocket, rmoon, Moonx);
            //cout << vel_x << endl;
            //cout << "Function being called" << endl;
            vel_y = MyRocket.velocityy(r, y, vel_y, massrocket, rmoon, Moony);
            //cout << vel_y << endl;
            x = MyRocket.x_coord(x, vel_x);
            //cout << x << endl;
            y = MyRocket.y_coord(y, vel_y);
            //cout << y << endl;

            Moonx = TheMoon.MoonPos_x(Theta);
            Moony = TheMoon.MoonPos_y(Theta);
            Theta = Theta + theta_constant*t;

            if ( r < Earthradius)
            {
                cout << "Crash landing back on Earth " << endl << endl;
                //std::cout << "The velocity of your rocket was : " << sqrt((vel_x*vel_x)+(vel_y*vel_y)) << " metres per second "<< endl;
                break;
            }
            if ( rmoon < Moonradius)
            {
                cout << "You've hit the moon" << endl << endl;
                std::cout << "The Time it took the rocket to get to the Moon was :   " << ((i*t)/(24.0*3600.0)) << "  days "<< endl<< endl;
                //std::cout << "The velocity of your rocket was : " << sqrt((vel_x*vel_x)+(vel_y*vel_y)) << " metres per second "<< endl;
                //std::cout << "x = " << x << "    y = " << y;
                break;
            }
            if (r >= 1.05*EarthMoondist)
            {
                cout << "overshot the moon " << endl << endl;
                //std::cout << "The velocity of your rocket was : " << sqrt((vel_x*vel_x)+(vel_y*vel_y)) << " metres per second "<< endl;
                break;
            }

            if (i == (imax-1))
            {
                cout << endl << "max iterations complete" << endl << endl;
                break;
            }
            i++;
        }
        std::cout << "The velocity of your rocket was : " << sqrt((vel_x*vel_x)+(vel_y*vel_y)) << " metres per second "<< endl<< endl;
        myfile.close();

    return 0;
}
