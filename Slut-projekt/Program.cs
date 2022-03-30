using System.Collections.Generic;
using System;
using Raylib_cs;

//sonny likt spel ska jag kanske göra
//göra så man kan klicka på fienderna och sig själv
//göra runda då man kan attackera och så fienderna kan attackera
//göra en timer som gör så att om man inte attackerar i den tiden så skippas din runda så fienderna attackerar
//göra att fienderna attackerar bara då spelarens tur har gått
//göra så man kan välja mellan flera attacker som gör olika saker

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