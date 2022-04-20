using System.Collections.Generic;
using System;
using Raylib_cs;

//sonny likt spel 

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


Rectangle playerRect = new Rectangle(playerX, playerY, PLAYERWIDTH, PLAYERHEIGHT);
Rectangle enemyRect = new Rectangle(enemyX, enemyY, ENEMYWIDTH, ENEMYHEIGHT);

bool playerPress()
{
    float playerX2 = playerX + PLAYERWIDTH;
    float playerY2 = playerY + PLAYERHEIGHT;
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    Raylib.DrawText(":" + playerX, 400, 100, 30, Color.BLACK);
    Raylib.DrawText(":" + mouseX, 400, 600, 30, Color.BLACK);
    Raylib.DrawText(":" + playerY, 100, 100, 30, Color.BLACK);
    Raylib.DrawText(":" + mouseY, 100, 600, 30, Color.BLACK);
    if (Raylib.IsMouseButtonDown(0) &&
        playerX <= mouseX &&
        playerX2 >= mouseX &&
        playerY <= mouseY &&
        playerY2 >= mouseY)
    {
        Raylib.DrawText("funnyhaha", 100, 100, 100, Color.BROWN);
        return true;
    }
    else
    {
        return false;
    }

}


while (Raylib.WindowShouldClose() == false)
{


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);
    playerPress();
    Raylib.DrawRectangleRec(playerRect, Color.GREEN);
    Raylib.DrawRectangleRec(enemyRect, Color.DARKPURPLE);

    Raylib.EndDrawing();
}