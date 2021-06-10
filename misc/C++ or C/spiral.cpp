//*************************************************************************************************\\
//**************************************************************************************************\\
//*****************************THIS CODE WAS WRITTEN BY LUKE MOORE**********************************\\
//******This code models a spiral by prompting the user for initial velocity of the particle********\\
//**************************************************************************************************\\
//***************************************************************************************************\\

#include <iostream> //libraries
#include <iomanip>
#include <math.h>
#include <fstream>
using namespace std;
const double t = 0.0001; //sets the time interval over which calculations are made as a constant and sets the value
//define function to calculate the radial distance between the particle and the origin
const double reductionfactor = 0.999999; //the factor which expresses energy lost per iteration below a certain value of r
double rvalue(double x, double y) //need to take in the values of the x and y coordinate for this function
{
    return sqrt((x*x)+(y*y)); // returns the answer by using pythagoras's theorem
}
//define function to calculate the velocity of particle in x direction
double velocityx(double r, double x, double vel_x)
// need to take in value of r for use in value of electrostatic force,
//x coordinate and the previous velocity in x direction
{
    double k = 1.0, F_x, F, m = 1.0, acc_x; // define variables for use in equations
        F = k/(r*r); // defines the electrostatic force
        F_x = -F*(x/r); // resolves the x component of the electrostatic force, F*cos(theta), cos(theta) = adjacent/hyp = x/r
        acc_x = F_x/m; // F = m * a, newtons equation to determine the acceleration of the particle
        vel_x = vel_x + acc_x* t; // standard constant acceleration equation to determine the final velocity from
        //current velocity and time over which acceleration acts for
    return vel_x; // returns velocity in x direction
}
//define function to calculate the velocity of particle in y direction
double velocityy(double r, double y, double vel_y)
// need to take in value of r for use in value of electrostatic force,
//y coordinate and the previous velocity in y direction
{
    double k = 1.0, F_y, F, m = 1.0, acc_y;// define variables for use in equations
        F = k/(r*r);// defines the electrostatic force
        F_y = -F*(y/r);// resolves the x component of the electrostatic force, F*cos(theta), cos(theta) = adjacent/hyp = x/r
        acc_y = F_y/m;// F = m * a, newtons equation to determine the acceleration of the particle
        vel_y = vel_y + acc_y* t;// standard constant acceleration equation to determine the final velocity from
        //current velocity and time over which acceleration acts for
    return vel_y; // returns velocity in y direction
}
//define function to calculate the x coordinate of particle
double x_coord(double x, double vel_x) // need to take in velocity in x direction and velocity in x direction
{
        x = x + vel_x * t; // calculates the new x coordinate from old coordinate and velocity acting for particular time
    return x; // returns x coordinate
}
//define function to calculate the y coordinate of particle
double y_coord(double y, double vel_y)// need to take in velocity in x direction and velocity in x direction
{
        y = y + vel_y * t;// calculates the new y coordinate from old coordinate and velocity acting for particular time
    return y; // returns the y coordinate
}
int main () // define main function

{
     double y, x, vel_x, vel_y, r; //defines double variables x and y coordinates x and y velocities
     //and r radial distance value
     int iteration=0;

        y = 1.00000000; //initial values of variables
        x = 0.000000000;
        vel_x = 0.0;
        vel_y = 0.0;
        r = 0.0;


        cout << "A value of 1 creates a perfect circular path, v<1 spiral to origin, v > 1 moves away from origin\n";
        cout << "Enter a value for the initial velocity in x direction: (must be between 0 and 1)   \n";
        cout << "However I recommend 0.4 <= vel <= 0.97 for a good spiral  ";
        //prompt user for initial velocity straight across, vel_x
        cin >> vel_x; // reads in value from user

        ofstream myfile;
        myfile.open ("spiral.txt"); //opens file and creates it if not already in existence

        do //do loop to carry out same calculations over and over until end loop condition met
        {
            myfile << std::setprecision(10) << x << "                "; // sets precision of x value to 10 sig figs
            myfile << std::setprecision(10) << y << "\n"; // sets precision of y value to 10 sig figs

            r = rvalue(x,y); // call rvalue function to calculate r from x and y values
            vel_x = velocityx(r,x, vel_x); // calls velocityx function to calculate x velocity
            vel_y = velocityy(r,y, vel_y); // calls velocityy function to calculate y velocity
            x = x_coord(x, vel_x); // calls x coordinate function to calculate x coordinate
            y = y_coord(y, vel_y); // calls y coordinate function to calculate y coordinate
            if (r<=0.90)
            {
                vel_x = reductionfactor*vel_x;
                vel_y = reductionfactor*vel_y;
            }
            iteration = iteration + 1;
            if (iteration>=200000)
            {
                myfile.close();
                cout << "Maximum number of iterations complete before reaching origin \n\n";
                cout << "Cut off point is r = : " << 0.025 << "\n";

                std::cout << std::setprecision(10) << "r =  " << r << "\n"; //sets precision of r value to 10 sig figs and prints
                // the value of r when r becomes greater than start value of r
                return 1;
            }
        } while (r >= 0.025); //runs do loop until radial distance between origin and
        //particle is greater than initial radial distance

        cout << "Cut off point is r = : " << 0.025 << "\n";

        std::cout << std::setprecision(10) << "r =  " << r << "\n"; //sets precision of r value to 10 sig figs and prints
        // the value of r when r becomes greater than start value of r

            myfile.close(); // closes the file

return 0; // returns value of zero to user when program complete
}

