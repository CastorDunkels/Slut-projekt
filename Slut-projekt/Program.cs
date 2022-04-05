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



const int PLAYERSPAWNX = 100;
const int PLAYERSPAWNY = 400;
const int PLAYERWIDTH = 100;
const int PLAYERHEIGHT = 50;
float enemyX = 800;
float enemyY = 400;
float enemyWidth = 100;
float enemyHeight = 50;

Rectangle playerRect = new Rectangle(PLAYERSPAWNX, PLAYERSPAWNY, PLAYERHEIGHT, PLAYERWIDTH);
Rectangle enemyRect = new Rectangle(enemyX, enemyY, enemyHeight, enemyWidth);

Raylib.InitWindow(1000, 900, "Game");
Raylib.SetTargetFPS(60);


while(Raylib.WindowShouldClose() == false){

Raylib.BeginDrawing();
Raylib.ClearBackground(Color.SKYBLUE);
Raylib.DrawRectangleRec(playerRect, Color.GREEN);
Raylib.DrawRectangleRec(enemyRect, Color.DARKPURPLE);

Raylib.EndDrawing();
}