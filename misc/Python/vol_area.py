import math

def volsphere(r):
    
    return ((4.0/3.0)*math.pi*pow(r,3.0))
def areasphere(r):
    return (4.0*math.pi*pow(r,2.0))
def cylvol(r,h):
    return (math.pi*pow(r,2.0)*h)
def areacyl(r,h):
    return (math.pi*pow(r,2.0)+h*2.0*math.pi*r)


r = float(input("input a value for r: "))
h = float(input("input a value for h: "))
volumeSphere = volsphere(r)
print ("volume of sphere is: ", volumeSphere)
areaSphere = areasphere(r)
print ("area of sphere is: ", areaSphere)
volumecylinder = cylvol(r, h)
print ("volume of cylinder is: ", volumecylinder)
areacylinder = areacyl(r,h)
print ("area of cylinder is: ", areacylinder)
print ("pi is: ", math.pi)
input("Please Press Enter to exit")
