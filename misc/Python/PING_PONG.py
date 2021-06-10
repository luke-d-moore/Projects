#############################################
#############################################
#####THIS CODE WAS WRITTEN BY LUKE MOORE#####
#############################################
#############################################
import os
import math
import time

#NEED TO IMPLEMENT THE USER INPUT FOR PLAYER1 PADDLE TO FINISH THE GAME OFF


def ballx(xball, vx):
    t=1
    xball = xball +vx* t
    return xball

def bally(yball, vy):
    t=1
    yball = yball +vy* t
    return yball

def grid(x,y, xball, yball, xpaddle, ypaddle, xcomp, ycomp):
    x=1
    y=1
    while y>=1 and y<=21:
        x=1
        line = "   "
        if y==1 or y==21:
            while x<=40:
                line = line+"X"
                x+=1
        else:
            while x==1 or x==40:
                if y>=8 and y<=14:
                    line = line+" "
                    x+=1
                else:
                    line = line+"X"
                    x+=1

            while x>1 and x<40:
                
                if x==xpaddle and y ==ypaddle+1:
                    line = line + "|"
                    x+=1
                if x==xpaddle and y ==ypaddle:
                    line = line + "|"
                    x+=1
                if x==xpaddle and y ==ypaddle-1:
                    line = line + "|"
                    x+=1
                    
                if x==xcomp and y ==ycomp+1:
                    line = line + "|"
                    x+=1
                if x==xcomp and y ==ycomp:
                    line = line + "|"
                    x+=1
                if x==xcomp and y ==ycomp-1:
                    line = line + "|"
                    x+=1

                if x==xball and y == yball:
                    line = line + "o"
                    x+=1
                else:
                    line = line + " "
                    x+=1
                    if x==40:
                        if y>=8 and y<=14:
                            line = line +" "
                        else:
                            line = line +"X"
        print(line)
        y+=1
    return Gridprint


GAMEOVER = False
Gridprint = 0
x=1
y=1
vx = 1
vy=1
vpaddle = 1
vcomp =1
xball = 20
yball = 11
xpaddle = 4
ypaddle = 11
xcomp = 37
ycomp = 11
score = "  "
Player1 =0
Computer=0
t=1
print ("   ELECTRONIC PING PONG GAME BY LUKE MOORE")
Gridprint = grid(x,y, xball, yball, xpaddle, ypaddle, xcomp, ycomp)
print("   SCORES ARE:","Player1 : ",Player1,"  Computer: ",Computer)
winningpoint=int(input("   How many points for the win? 1, 3, 7\n"))
if winningpoint == 1:
    winningpoint = 1
elif winningpoint == 3:
    winningpoint = 3
elif winningpoint == 7:
    winningpoint = 7
else:
    print("   invalid input")
    GAMEOVER=True
n=0
while GAMEOVER != True:
    while score!=True:
        oldyball = yball
        xball = ballx(xball,vx)
        yball = bally(yball,vy)
        directionball=yball-oldyball
        if ycomp>=7:
            if ycomp==15:
                vcomp=vcomp*-1
                ycomp=ycomp-vcomp*t
            elif ycomp==7:
                vcomp=vcomp*-1
                ycomp=ycomp-vcomp*t
            else:
                ycomp = ycomp-vcomp*t
        if ypaddle>=7:
            if ypaddle==15:
                vpaddle=vpaddle*-1
                ypaddle=ypaddle+vpaddle*t
            elif ypaddle==7:
                vpaddle=vpaddle*-1
                ypaddle=ypaddle+vpaddle*t
            else:
                ypaddle = ypaddle+vpaddle*t

        if xball ==39 and yball <8:
            vx = vx*-1
        if xball ==39 and yball >14:
            vx = vx*-1
        if xball ==40 and yball <8:
            xball =39
            vx=vx*-1
        if xball ==40 and yball >14:
            xball=39
            vx=vx*-1
        if xball ==2 and yball <8:
            vx = vx*-1
        if xball ==2 and yball >14:
            vx = vx*-1
        if xball ==1 and yball <8:
            xball =2
            vx=vx*-1
        if xball ==1 and yball >14:
            xball=2
            vx=vx*-1
        if yball == 20 or yball ==2:
            vy = vy*-1
        if xball==xpaddle+1 and yball==ypaddle:
            vx=vx*-1
        if xball==xpaddle+1 and yball==ypaddle+1:
            vx=vx*-1
        if xball==xpaddle+1 and yball==ypaddle-1:
            vx=vx*-1
        if xball==xcomp-1 and yball==ycomp:
            vx=vx*-1
        if xball==xcomp-1 and yball==ycomp+1:
            vx=vx*-1
        if xball==xcomp-1 and yball==ycomp-1:
            vx=vx*-1
        if xball==xpaddle and yball==ypaddle:
            vy=vy*-1
        if xball==xpaddle and yball==ypaddle+1:
            vy=vy*-1
        if xball==xpaddle and yball==ypaddle-1:
            vy=vy*-1
        if xball==xcomp and yball==ycomp:
            vy=vy*-1
        if xball==xcomp and yball==ycomp+1:
            vy=vy*-1
        if xball==xcomp and yball==ycomp-1:
            vy=vy*-1

##        key=input("w for up and s for down")
##        ypaddle = paddle(ypaddle)
##        if key=='w':
##            ypaddle+=1
##            ypaddle = paddle(ypaddle)
##        elif key =='s':
##            ypaddle-=1
##            ypaddle = paddle(ypaddle)
##        else:
##            ypaddle=ypaddle
##            ypaddle = paddle(ypaddle)
        
        time.sleep(0.15)
        os.system('cls')
        
        if xball==1 and yball>=8 and yball <=14:
            score = True
            Computer+=1
        if xball == 40 and yball>=8 and yball <= 14:
            score = True
            Player1+=1
            

        print ("   ELECTRONIC PING PONG GAME BY LUKE MOORE")
        Gridprint = grid(x,y, xball, yball, xpaddle, ypaddle, xcomp, ycomp)
        print("   SCORES ARE:","Player1 : ",Player1,"  Computer: ",Computer)
        print("   Number of points to win the game = ", winningpoint)
        if Computer==winningpoint:
                print("   YOU LOST THE GAME, BETTER LUCK NEXT TIME")
                GAMEOVER=True
        if Player1==winningpoint:
                print("   YOU WON THE GAME!!!!")
                GAMEOVER=True
    if score ==True and Player1!=winningpoint and Computer!=winningpoint:
        score = False
        xball = 20
        yball = 11
        vx = vx*-1
        vy = vy*-1
        print ("   Next Round will now begin")
        time.sleep(2)

        
print("   GAMEOVER")
input("   Please press enter to exit")



