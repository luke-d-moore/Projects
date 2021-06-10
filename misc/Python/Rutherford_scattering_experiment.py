import math
t=0.001

class ParticlePosition:
    
    def rvalue(self, x,y):
        r = math.sqrt(x**2.0 +y**2.0)
        return r
    
    def velocityx(self, x, vel_x, r):
        m = 1.0
        F = 1.0/(r*r)
        F_x = F*(x/r)
        acc_x = F_x/m
        vel_x = vel_x + acc_x* t
        return vel_x
    
    def velocityy(self, y, vel_y, r):
        m = 1.0
        F = 1.0/(r*r)
        F_y = F*(y/r)
        acc_y = F_y/m
        vel_y = vel_y + acc_y* t
        return vel_y
    
    def Position_x(self, x, vel_x):
        
        x = x + vel_x * t
        return x
    def Position_y(self, y, vel_y):

        y = y + vel_y * t
        return y
        
        
Alpha = ParticlePosition()
y = -10.0
i = 0
r = 0.0
vel_x = 0.0
x=float(input("input a value for x offset: "))
vel_y = float(input("input a value for the velocity in the y direction ")) 
r_start = math.sqrt(x**2.0+y**2.0)
r = r_start
f = open('results.txt', 'w')
print ("x_coord is : ", x, "   y_coord is : ", y, "   r is :", r)
while r<= r_start and i <= 100000:
    vel_x = Alpha.velocityx(x,vel_x, r)
    vel_y = Alpha.velocityy(y, vel_y, r)
    x = Alpha.Position_x(x,vel_x)
    y = Alpha.Position_y(y,vel_y)
    r = Alpha.rvalue(x,y)
    f.write(str(x))
    f.write("   ")
    f.write(str(y))
    f.write("\n")
    i+=1

f.close()
print (i)
print ("remember to copy the results file to the python coding directory for gnuplot to plot the graph")
