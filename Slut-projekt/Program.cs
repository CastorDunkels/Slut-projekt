using System.Collections.ObjectModel;
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

//information about the game. 
//You have to either press yours or the enemys rectangle and choose an action to do. 
//You are the rectangle on the left side of the screen. 
//When you have chosen an action the enemy will try to dmg you. 
//You will have 30 seconds per round to choose action and if you dont choose an action in time you will be attacked. 

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
float playerHealX = playerX + PLAYERWIDTH / 2;
float playerHealY = playerY - 20;
float enemyOptionX = enemyX + ENEMYWIDTH / 2;
float enemyOptionY = enemyY - 20;
float enemyOption2X = enemyOptionX - ENEMYWIDTH + 5;
float enemyOption2Y = enemyOptionY + 40;
float enemyOption3X = enemyOptionX + ENEMYWIDTH - 5;
float enemyOption3Y = enemyOptionY + 40;
float playerHealthX = playerX;
float playerHealthY = playerY + 100;
float playerHealthBarOutlineX = playerX;
float playerHealthBarOutlineY = playerY + 150;
float playerHealthBarX = playerHealthBarOutlineX + 2;
float playerHealthBarY = playerHealthBarOutlineY + 1;
float enemyHealthX = enemyX;
float enemyHealthY = enemyY + 100;
float enemyHealthBarOutlineX = enemyX;
float enemyHealthBarOutlineY = enemyY + 150;
float enemyHealthBarX = enemyHealthBarOutlineX + 2;
float enemyHealthBarY = enemyHealthBarOutlineY + 1;


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
bool heal(){
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    float healX = 0;
    float healY= 0;
    float healX2 = healX + 100;
    float healY2= healY + 100;
    if (playerOptions == true){

        if (Raylib.IsMouseButtonPressed(0) &&
            healX <= mouseX &&
            healX2 >= mouseX &&
            healY <= mouseY &&
            healY2 >= mouseY)
        {
            playerHealth += 50;
            roundTime -= 30;
            return true;
        }
        else{
            return false;
        }
    }
    else{
        return false;
    }
}
bool weakAttack(){
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    float weakAttackX = enemyX;
    float weakAttackY = 0;
    float weakAttackX2 = weakAttackX + 100;
    float weakAttackY2= weakAttackY + 100;
    if (enemyOptions == true){

        if (Raylib.IsMouseButtonPressed(0) &&
            weakAttackX <= mouseX &&
            weakAttackX2 >= mouseX &&
            weakAttackY <= mouseY &&
            weakAttackY2 >= mouseY)
        {
            enemyHealth -= 20;
            roundTime -= 30;
            return true;
        }
        else{
            return false;
        }
    }
    else{
        return false;
    }
}
bool mediumAttack(){
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    float medAttackX = enemyX;
    float medAttackY = enemyY + 100;
    float medAttackX2 = medAttackX + 100;
    float medAttackY2= medAttackY + 100;
    if (enemyOptions == true){

        if (Raylib.IsMouseButtonPressed(0) &&
            medAttackX <= mouseX &&
            medAttackX2 >= mouseX &&
            medAttackY <= mouseY &&
            medAttackY2 >= mouseY)
        {
            Random hitRate = new Random();
            int medAttackHitRate = hitRate.Next(1, 11);
            if(medAttackHitRate >= 8){
                Raylib.DrawText("Miss",(int)enemyX - 60, (int)enemyY, 30, Color.RED);
            }
            else{
            enemyHealth -= 100;
            Raylib.DrawText("-" + 100, (int)enemyX - 60, (int)enemyY, 30, Color.BLUE);

            }
            roundTime -= 30;
            return true;
        }
        else{
            return false;
        }
    }
    else{
        return false;
    }
}
bool strongAttack(){
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    float strongAttackX = enemyX + 100;
    float strongAttackY = enemyY + 100;
    float strongAttackX2 = strongAttackX + 100;
    float strongAttackY2= strongAttackY + 100;
    if (enemyOptions == true){

        if (Raylib.IsMouseButtonPressed(0) &&
            strongAttackX <= mouseX &&
            strongAttackX2 >= mouseX &&
            strongAttackY <= mouseY &&
            strongAttackY2 >= mouseY)
        {
            Random hitRate = new Random();
            int strongAttackHitRate = hitRate.Next(1, 101);
            if(strongAttackHitRate >= 2){
                Raylib.DrawText("Miss",(int)enemyX - 60, (int)enemyY, 30, Color.RED);
            }
            else{
            enemyHealth -= 1000;
            Raylib.DrawText("-" + 1000, (int)enemyX - 60, (int)enemyY, 30, Color.BLUE);

            }
            roundTime -= 30;
            return true;
        }
        else{
            return false;
        }
    }
    else{
        return false;
    }
}
void enemyHeal(){
    float heals = 0;
    if(enemyHealth <= 200 && heals == 0){
        enemyHealth += 1000;
        heals += 1;
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
    if (Raylib.GetTime() - roundTime > 30)
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
    heal();
    weakAttack();
    mediumAttack();
    strongAttack();
    enemyHeal();
    Raylib.DrawRectangleRec(playerRect, Color.GREEN);
    Raylib.DrawRectangleRec(enemyRect, Color.DARKPURPLE);
    Raylib.DrawText(":" + playerHealth, (int)playerHealthX, (int)playerHealthY, 30, Color.BLACK);
    Raylib.DrawText(":" + enemyHealth, (int)enemyHealthX, (int)enemyHealthY, 30, Color.BLACK);
    Raylib.DrawText("Time: " + ((int)Raylib.GetTime() - (int)roundTime), 450, 600, 30, Color.BLACK);
    Raylib.DrawRectangle((int)playerHealthBarOutlineX, (int)playerHealthBarOutlineY, 100, 20, Color.BLACK);
    Raylib.DrawRectangle((int)playerHealthBarX, (int)playerHealthBarY, 96, 18, Color.WHITE);
    Raylib.DrawRectangle((int)playerHealthBarX, (int)playerHealthBarY, (int)playerHealth * 96 / 100, 18, Color.RED);
    Raylib.DrawRectangle((int)enemyHealthBarOutlineX, (int)enemyHealthBarOutlineY, 100, 20, Color.BLACK);
    Raylib.DrawRectangle((int)enemyHealthBarX, (int)enemyHealthBarY, 96, 18, Color.BLACK);
    Raylib.DrawRectangle((int)enemyHealthBarX, (int)enemyHealthBarY, (int)enemyHealth * 96 / 1000, 18, Color.RED);

    if (playerOptions == true)
    {
        Raylib.DrawText("funnyhaha", 100, 100, 50, Color.BROWN);
        Raylib.DrawCircle((int)playerHealX, (int)playerHealY, 18, Color.BLUE);
    }

    if (enemyOptions == true)
    {
        Raylib.DrawText("Jeffy", 600, 100, 50, Color.BROWN);
        Raylib.DrawCircle((int)enemyOptionX, (int)enemyOptionY, 18, Color.BLUE);
        Raylib.DrawCircle((int)enemyOption2X, (int)enemyOption2Y, 18, Color.BLUE);
        Raylib.DrawCircle((int)enemyOption3X, (int)enemyOption3Y, 18, Color.BLUE);
    }

    if (playerHealth <= 0)
    {
        playerHealth = 0;


    }
    if (playerHealth >= 101){
        playerHealth = 100;
    }
    if (enemyHealth <=0){
        enemyHealth = 0;
    }
    if (enemyHealth >= 1001){
        enemyHealth = 1000;
    }

    Raylib.EndDrawing();
}