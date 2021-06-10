import math

def Quadraticsolveplus(a,b,c):
    return ((-b + math.sqrt(b*b - 4*a*c))/2.0*a)
def Quadraticsolveminus(a,b,c):
    return ((-b - math.sqrt(b*b - 4*a*c))/2.0*a)

a=float(input("input a value for a: "))
b= float(input("input a value for b:"))
c = float(input("input a value for c: "))
x1 = Quadraticsolveplus(a,b, c)
x2 = Quadraticsolveminus(a,b, c)

print ("x1 is: ", x1)
print ("x2 is: ", x2)
input("Please press Enter to exit")
