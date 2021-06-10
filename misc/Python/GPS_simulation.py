##############################################################
##############################################################
#THIS CODE WAS WRITTEN BY LUKE MOORE TO SIMULATE A GPS SYSTEM#
##############################################################
##############################################################
import math
import random
import time


print('##########################################################################')
print('####################   GPS SYSTEM SIMULATION    ##########################')
print('##############################  BY  ######################################')
print('#########################  LUKE   MOORE  #################################')
print('##########################################################################')
print("\n")
print(">>> System Initializing ... \n")
time.sleep(2)
class Satellite:
    def Positionx(self, Theta_sat, r_sat):
        return r_sat*math.cos(Theta_sat)
    def Positiony(self, Theta_sat, r_sat):
        return r_sat*math.sin(Theta_sat)
    def Positionz(self, Phi_sat, r_sat):
        return r_sat*math.sin(Phi_sat)
class Generate:
    def Posx(self):
        randx1 = random.randrange(0, 89, 1)
        randx2 = random.randrange(0,99,1)
        randx2 = float(randx2/100.0)
        randx = float(randx1)+randx2
        return randx
    def Posz(self):
        randz1 = random.randrange(0, 89, 1)
        randz2 = random.randrange(0,99,1)
        randz2 = float(randz2/100.0)
        randz = float(randz1)+randz2
        return randz
class search:
    REarth = 6378000
    def posx(self, Theta):
        return REarth*math.cos(Theta)
    def posy(self, Theta):
        return REarth*math.sin(Theta)
    def posz(self, Phi):
        return REarth*math.sin(Phi)

r_sat = 42241727.49 #Geostationary satellite
Theta_sat = 45.0
Phi_sat = 45.0
SatPos = Satellite()
x_sat = SatPos.Positionx(Theta_sat, r_sat)
y_sat = SatPos.Positiony(Theta_sat, r_sat)
z_sat = SatPos.Positionz(Phi_sat, r_sat)
Gen=Generate()
Search = search()
randx = Gen.Posx()
randz = Gen.Posz()
print (">>> Randomly Generated Latitude and Longitude were: ", '(',randz, ",", randx,')\n')
time.sleep(2)
print(">>> Please wait ...\n")
time.sleep(2)
REarth=6378000
newrandx = REarth* math.cos(randx*math.pi/180.0)
newrandy = REarth* math.sin(randx*math.pi/180.0)
newrandz = REarth* math.sin(randz*math.pi/180.0)
dist = math.sqrt(pow((x_sat-newrandx),2.0)+pow((y_sat-newrandy),2.0)+  pow((z_sat-newrandz),2.0))
time = dist/299792458.0
calctime = 0.0
x =0.0
y=0.0
z=0.0
#sets the time zone of the Earth based system
if randx<=15.00:
    Theta = 0.00
    maxTheta=15.00
elif randx>15.00 and randx<=30.00:
    Theta = 15.00
    maxTheta = 30.00
elif randx>30.00 and randx<=45.00:
    Theta = 30.00
    maxTheta = 45.00
elif randx>45.00 and randx<=60.00:
    Theta = 45.00
    maxTheta = 60.00
elif randx>60.00 and randx<=75.00:
    Theta = 60.00
    maxTheta = 75.00
elif randx>75.00 and randx<=90.00:
    Theta = 75.00
    maxTheta = 90.00
loopc = 0
n=0
#loops over the portion of the Earth relevant to your time zone to find you
while(Theta<=maxTheta):
    if n==0:
        print(">>> Scanning the Earth to calculate your position ...\n")
        print(">>> The Earth is big. Please allow a few seconds ...\n")
        n+=1
    
    if loopc==1:
        break
    Phi = 0.0
    x=Search.posx(Theta*math.pi/180.0)
    y=Search.posy(Theta*math.pi/180.0)
    while(Phi<=90.0):
        z=Search.posz(Phi*math.pi/180.0)
        dist = math.sqrt(pow((x_sat-x),2.0)+pow((y_sat-y),2.0)+  pow((z_sat-z),2.0))
        calctime = dist/299792458.0
        if calctime>0.99999999999*time and calctime<1.00000000001*time:
            print(">>> Found you", "( ", round(Phi, 2)," , ", round(Theta, 2), ")\n")
            loopc=1
            break
        
        Phi+=0.01
            
    Theta+=0.01
input(">>> Please Press Enter to exit")
