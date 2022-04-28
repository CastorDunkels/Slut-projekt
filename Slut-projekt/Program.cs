using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System;
using Raylib_cs;

//sonny/swords and sandals likt spel 

//fråga om man vill möta svår eller enkel fiende
//timer som långsamt går ut 
//kolla om musen är inom spelarens eller fiendens x och y kordinater
//kolla om man trycker på vänster musknapp
//om man trycker vänster musknapp på fiende eller spelare visa flera alternativ
//kolla vilket alternativ man väljer och gör effekten för den man valde
//när effekten har utspelats går timern till 0 oavsett hur mycket tid man hade.
//fienden skadar dig när timer är slut och timer startar igen

Raylib.InitWindow(1000, 900, "Game");
Raylib.SetTargetFPS(60);

const int PLAYERWIDTH = 50;
const int PLAYERHEIGHT = 100;
const int ENEMYWIDTH = 50;
const int ENEMYHEIGHT = 100;
float playerX = 100;
float playerY = 400;
float enemyX = 800;
float enemyY = 400;
double roundTime = 0;
float playerHealth = 100;
float enemyHealth = 1000;


Rectangle playerRect = new Rectangle(playerX, playerY, PLAYERWIDTH, PLAYERHEIGHT);
Rectangle enemyRect = new Rectangle(enemyX, enemyY, ENEMYWIDTH, ENEMYHEIGHT);

bool playerOptions = false;
bool enemyOptions = false;


bool playerPress()
{
    float playerX2 = playerX + PLAYERWIDTH;
    float playerY2 = playerY + PLAYERHEIGHT;
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    if (Raylib.IsMouseButtonPressed(0) &&
        playerX <= mouseX &&
        playerX2 >= mouseX &&
        playerY <= mouseY &&
        playerY2 >= mouseY)
    {
        playerOptions = !playerOptions;
        return true;
    }
    else
    {
        return false;
    }

}
bool enemyPress()
{
    float enemyX2 = enemyX + ENEMYWIDTH;
    float enemyY2 = enemyY + ENEMYHEIGHT;
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    if (Raylib.IsMouseButtonPressed(0) &&
        enemyX <= mouseX &&
        enemyX2 >= mouseX &&
        enemyY <= mouseY &&
        enemyY2 >= mouseY)
    {
        enemyOptions = !enemyOptions;
        return true;
    }
    else
    {
        return false;
    }

}
void enemyAttack()
{

    Random hitRate = new Random();
    int enemyHitRate = hitRate.Next(1, 11);//enemy has a 80% chance to deal dmg 
    Random rnd = new Random();
    int dmgTaken = rnd.Next(30, 51);
    if (enemyHitRate >= 9)
    {
        Raylib.DrawText("Miss", (int)playerX + 60, (int)playerY, 30, Color.BLUE);
    }
    else
    {
        playerHealth -= dmgTaken;
        Raylib.DrawText("-" + dmgTaken, (int)playerX + 60, (int)playerY, 30, Color.RED);
    }

}

void timer()
{
    if (Raylib.GetTime() - roundTime > 5)
    {
        enemyAttack();
        roundTime = Raylib.GetTime();
        enemyOptions = false;
        playerOptions = false;
    }
}


while (Raylib.WindowShouldClose() == false)
{


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);
    timer();
    playerPress();
    enemyPress();
    Raylib.DrawRectangleRec(playerRect, Color.GREEN);
    Raylib.DrawRectangleRec(enemyRect, Color.DARKPURPLE);
    Raylib.DrawText(":" + playerHealth, (int)playerX, (int)playerY + 100, 30, Color.BLACK);
    Raylib.DrawText("Time: " + ((int)Raylib.GetTime() - (int)roundTime), 450, 600, 30, Color.BLACK);
    Raylib.DrawRectangle((int)playerX - 1, (int)playerY + 149, 102, 22, Color.BLACK);
    Raylib.DrawRectangle((int)playerX, (int)playerY + 150, 100, 20, Color.WHITE);
    Raylib.DrawRectangle((int)playerX + 2, (int)playerY + 151, (int)playerHealth * 96 / 100, 18, Color.RED);
    Raylib.DrawRectangle((int)enemyX, (int)enemyY + 150, 100, 20, Color.BLACK);
    Raylib.DrawRectangle((int)enemyX + 2, (int)enemyY + 151, (int)enemyHealth * 96 / 1000, 18, Color.RED);

    if (playerOptions == true)
    {
        Raylib.DrawText("funnyhaha", 100, 100, 50, Color.BROWN);
    }
    if (enemyOptions == true)
    {
        Raylib.DrawText("Jeffy", 600, 100, 50, Color.BROWN);
        Raylib.DrawCircle((int)enemyX + 25, (int)enemyY - 23, 23, Color.BLUE);

    }

    if (playerHealth <= 0)
    {
        playerHealth = 0;


    }

    Raylib.EndDrawing();
}