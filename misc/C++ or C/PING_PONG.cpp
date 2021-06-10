//-------------------------------------------------------------------------------------\\
//-------------------------------------------------------------------------------------\\
//---------------THIS PROGRAM WAS WRITTEN BY LUKE MOORE--------------------------------\\
//-------------------------------------------------------------------------------------\\
//-------------------------------------------------------------------------------------\\

#include<iostream>
#include<math.h>
#include<windows.h>
#include<conio.h>
using namespace std;
bool gameOver;
bool score;
int x,y, comp, Player;
int const xpaddle = 3;
int ypaddle;
int const xcomp=37;
int ycomp;
int xball;
int yball;
int vpaddle;
int vcomp;
int vx;
int vy;
int const t = 1;
int winningpoint;
enum eDirecton {STOP, UP, DOWN};
eDirecton dir;
void Setup()
{
    gameOver = false;
    score = false;
    dir = UP;
    ypaddle = 11;
    ycomp=11;
    xball = 20;
    yball = 11;
    vpaddle = 1;
    vcomp = 1;
    vx = 1;
    vy = 1;
    Player = 0;
    comp = 0;
}
void Draw(int xpaddle, int ypaddle, int xcomp, int ycomp, int xball, int yball)
{
    system("cls");
int x=1;
int y=1;
cout << "   ELECTRONIC PING PONG GAME BY LUKE MOORE"<< endl;
    while (y>=1 & y<=21)
    {
        x=1;
        string line = "   ";
        if (y==1 | y==21)
        {
            while (x<=40)
            {
                line = line+"X";
                x+=1;
            }
        }
        else
        {
            while (x==1 | x==40)
            {
                if (y>=8 & y<=14)
                {
                    line = line+" ";
                    x+=1;
                }
                else
                {
                    line = line+"X";
                    x+=1;
                }
            }
        }
            while (x>1 & x<40)
            {
                if (x==xpaddle & y ==ypaddle+1)
                {
                    line = line + "|";
                    x+=1;
                }
                if (x==xpaddle & y ==ypaddle)
                {
                    line = line + "|";
                    x+=1;
                }
                if (x==xpaddle & y ==ypaddle-1)
                {
                    line = line + "|";
                    x+=1;
                }

                if (x==xcomp & y ==ycomp+1)
                {
                    line = line + "|";
                    x+=1;
                }
                if (x==xcomp & y ==ycomp)
                {
                    line = line + "|";
                    x+=1;
                }
                if (x==xcomp & y ==ycomp-1)
                {
                    line = line + "|";
                    x+=1;
                }

                if (x==xball & y == yball)
                {
                    line = line + "o";
                    x+=1;
                }
                else
                {
                    line = line + " ";
                    x+=1;
                    if (x==40)
                    {
                        if (y>=8 & y<=14)
                            {
                                line = line +" ";
                            }
                        else
                        {
                            line = line +"X";
                        }
                    }
                }
            }
        cout<<line <<endl;
        y+=1;
    }
    cout << "   The Current scores are  Player : "<< Player<< "  Computer : "<< comp<< endl;
    cout << "   The number of points for the win is : " << winningpoint << endl;
    cout << "   Press w to move paddle up and s to move paddle down"<< endl;
    cout << "   Please Press p to Quit the game" << endl;
}

void Input()
{
    if (_kbhit())
    {
        switch (_getch())
        {
        case 'w':
            dir = UP;
            break;
        case 's':
            dir = DOWN;
            break;
        case 'p':
            dir = STOP;
            break;
        }
    }

}
void key()
{
    switch (dir)
    {
    case UP:
        ypaddle-=1;
        break;
    case DOWN:
        ypaddle+=1;
        break;
    case STOP:
        score = true;
        gameOver=true;
        break;
    default:
        break;
    }
}

int main()
{
    Setup();
    cout << "   How many points for the win? 1, 3 or  7" << endl;
    cin >> winningpoint;


    if (winningpoint==1)
    {
        winningpoint = 1;
    }
    else if(winningpoint == 3)
    {
        winningpoint = 3;
    }
    else if(winningpoint == 7)
    {
        winningpoint = 7;
    }
    else
        {
            cout << "Invalid Input" << endl;
            gameOver = true;
        }
    int choice;
    choice = 0;
    cout << " Set difficulty of the game : 1 or 2" << endl;
    cout << "Difficulty 1 : Normal" << endl;
    cout << "Difficulty 2 : UNBEATABLE (LITERALLY!!!!)" << endl;
    cin >> choice;

    if (choice ==1)
    {
        choice = 1;
        vcomp = -2;

    }
    else if (choice ==2)
    {
        choice = 2;
    }
    else
    {
        choice = 0;
        gameOver = true;
    }





    while (gameOver!=true)
    {
        while (score!=true)
        {
            xball = xball +vx*t;
            yball = yball +vy*t;

        if (yball > 21 | yball < 1 | xball >40 | xball < 1)
        {
            cout << "SOMETHING WENT WRONG SORRY ABOUT THAT YOU WIN THIS ROUND" << endl;
            gameOver = true;
            score = true;
            break;
        }

        if (choice==1)
        {
        if (ycomp>=5)
        {
            if (ycomp==17)
            {
                vcomp=vcomp*-1;
                ycomp=ycomp-vcomp*t;
            }
            else if (ycomp==5)
            {
                vcomp=vcomp*-1;
                ycomp=ycomp-vcomp*t;
            }
            else
            {
                ycomp = ycomp-vcomp*t;
            }
        }
        }

        else if (choice==2)
        {
            if (yball <=3)
            {
                ycomp = yball +1;
            }
            else if (yball >=19)
            {
                ycomp = yball -1;
            }
            else
            {
                ycomp = yball;
            }
        }


        if (xball ==39 & yball <8)
        {
            vx = vx*-1;
        }
        if (xball ==39 & yball >14)
        {
            vx = vx*-1;
        }
        if (xball ==40 & yball <8)
        {
            xball =39;
            vx=vx*-1;
        }
        if (xball ==40 & yball >14)
        {
            xball=39;
            vx=vx*-1;
        }
        if (xball ==2 & yball <8)
        {
            vx = vx*-1;
        }
        if (xball ==2 & yball >14)
        {
            vx = vx*-1;
        }
        if (xball ==1 & yball <8)
        {
            xball =2;
            vx=vx*-1;
        }
        if (xball ==1 & yball >14)
        {
            xball=2;
            vx=vx*-1;
        }
        if (yball == 20 or yball ==2)
        {
            vy = vy*-1;
        }
        if (xball==xpaddle+1 & yball==ypaddle)
        {
            vx=vx*-1;
        }
        if (xball==xpaddle+1 & yball==ypaddle+1)
        {
            vx=vx*-1;
        }
        if (xball==xpaddle+1 & yball==ypaddle-1)
        {
            vx=vx*-1;
        }
        if (xball==xcomp-1 & yball==ycomp)
        {
            vx=vx*-1;
        }
        if (xball==xcomp-1 & yball==ycomp+1)
        {
            vx=vx*-1;
        }
        if (xball==xcomp-1 & yball==ycomp-1)
        {
            vx=vx*-1;
        }
        if (xball==xpaddle & yball==ypaddle)
        {
            vy=vy*-1;
        }
        if (xball==xpaddle & yball==ypaddle+1)
        {
            vy=vy*-1;
        }
        if (xball==xpaddle & yball==ypaddle-1)
        {
            vy=vy*-1;
        }
        if (xball==xcomp & yball==ycomp)
        {
            vy=vy*-1;
        }
        if (xball==xcomp & yball==ycomp+1)
        {
            vy=vy*-1;
        }
        if (xball==xcomp & yball==ycomp-1)
        {
            vy=vy*-1;
        }

        if (xball==1 & yball>=8 & yball <=14)
        {
            score = true;
            comp+=1;
        }
        if (xball == 40 & yball>=8 & yball <= 14)
        {
            score = true;
            Player+=1;
        }





            Draw(xpaddle, ypaddle, xcomp, ycomp, xball, yball);
            Input();
            key();
            Sleep(80);




            if (comp==winningpoint)
{
                cout << "   YOU LOST THE GAME, BETTER LUCK NEXT TIME" << endl;
                gameOver=true;
}
        if (Player==winningpoint)
        {
                cout << "   YOU WON THE GAME!!!!" << endl;
                gameOver=true;
        }
    if (score ==true & Player!=winningpoint & comp!=winningpoint &gameOver!=true)
    {
        score = false;
        xball = 20;
        yball = 11;
        ycomp = 11;
        ypaddle = 11;
        vx = vx*-1;
        vy = vy*-1;
        cout << "   Next Round will now begin" << endl;
        cout << "   Press any key when you're ready" << endl;
        getch();
    }

        }
    }
    cout << "   GAMEOVER" << endl;
    cout << "Press any key" << endl;
    getch();

    return 0;
}
