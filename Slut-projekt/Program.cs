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
//double textTime = 0;
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
float enemyHeals = 0;
float radius = 18;


Rectangle playerRect = new Rectangle(playerX, playerY, PLAYERWIDTH, PLAYERHEIGHT);
Rectangle enemyRect = new Rectangle(enemyX, enemyY, ENEMYWIDTH, ENEMYHEIGHT);

bool playerOptions = false;
bool enemyOptions = false;

bool circleRadius(float x1, float y1, float x2, float y2, float radius){ //en metod för att kolla om något är innanför en cirkels radius 
    float deltaX = x1 - x2;
    float deltaY = y1 - y2;
    float d2 = deltaX * deltaX + deltaY * deltaY;
    if(d2 <= radius * radius){
        return true;
    }
    else {
        return false;
    }
}


bool playerPress() //en metod som kollar om man trycker på vänstra mus knappen och om det är innanför spelarens rektangel  
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
bool enemyPress() //samma som förra metoden men för fiendens rektangel
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
bool heal(){ //en metod som kollar om musen är inom en av cirklarnas radius och om man klickar på vänstra musknappen
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    if (playerOptions == true){

        if (Raylib.IsMouseButtonPressed(0) && circleRadius(mouseX, mouseY, playerHealX, playerHealY, radius))
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
bool weakAttack(){ //samma som förra
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    if (enemyOptions == true){

        if (Raylib.IsMouseButtonPressed(0) && circleRadius(mouseX, mouseY, enemyOption2X, enemyOption2Y, radius))
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
bool mediumAttack(){ //samma som förra men att det finns en chans att missa
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    if (enemyOptions == true){

        if (Raylib.IsMouseButtonPressed(0) && circleRadius(mouseX, mouseY, enemyOptionX, enemyOptionY, radius))
        {
            Random hitRate = new Random();
            int medAttackHitRate = hitRate.Next(1, 11);
            if(medAttackHitRate >= 8){
                Raylib.DrawText("Miss",(int)enemyX - 60, (int)enemyY, 30, Color.RED);
            }
            else{
            enemyHealth -= 50;
            Raylib.DrawText("-" + 50, (int)enemyX - 60, (int)enemyY, 30, Color.BLUE);

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
bool strongAttack(){ //samma som förra men med en ännu större chans att missa
    float mouseX = Raylib.GetMouseX();
    float mouseY = Raylib.GetMouseY();
    if (enemyOptions == true){

        if (Raylib.IsMouseButtonPressed(0) && circleRadius(mouseX, mouseY, enemyOption3X, enemyOption3Y, radius))
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
void enemyHeal(){ //en metod som gör så att när fiendens hp blir 200 eller mindre så går det tillbaka till 1000 bara en gång
    if(enemyHealth <= 200 && enemyHeals == 0){
        enemyHealth += 1000;
        enemyHeals += 1;
    }
}
void enemyAttack() //en metod som gör så fienden attackerar då timern är slut och då den har 80% chans att skada 
{

    Random hitRate = new Random();
    int enemyHitRate = hitRate.Next(1, 11);
    Random rnd = new Random();
    int dmgTaken = rnd.Next(10, 31);
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

void timer() //en metod som är en timer som räknar upp och startar om då den nått 30
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
    Raylib.DrawText(":" + playerHealth, (int)playerHealthX, (int)playerHealthY, 30, Color.BLACK); //ritar ut healthbars
    Raylib.DrawText(":" + enemyHealth, (int)enemyHealthX, (int)enemyHealthY, 30, Color.BLACK);
    Raylib.DrawText("Time: " + ((int)Raylib.GetTime() - (int)roundTime), 450, 600, 30, Color.BLACK);
    Raylib.DrawRectangle((int)playerHealthBarOutlineX, (int)playerHealthBarOutlineY, 100, 20, Color.BLACK);
    Raylib.DrawRectangle((int)playerHealthBarX, (int)playerHealthBarY, 96, 18, Color.WHITE);
    Raylib.DrawRectangle((int)playerHealthBarX, (int)playerHealthBarY, (int)playerHealth * 96 / 100, 18, Color.RED);
    Raylib.DrawRectangle((int)enemyHealthBarOutlineX, (int)enemyHealthBarOutlineY, 100, 20, Color.BLACK);
    Raylib.DrawRectangle((int)enemyHealthBarX, (int)enemyHealthBarY, 96, 18, Color.BLACK);
    Raylib.DrawRectangle((int)enemyHealthBarX, (int)enemyHealthBarY, (int)enemyHealth * 96 / 1000, 18, Color.RED);

    if (playerOptions == true) //ritar ut cirkeln som används för att heala
    {
        Raylib.DrawText("funnyhaha", 100, 100, 50, Color.BROWN);
        Raylib.DrawCircle((int)playerHealX, (int)playerHealY, radius, Color.BLUE);
    }

    if (enemyOptions == true) //samma som förra men för attack cirklarna
    {
        Raylib.DrawText("Jeffy", 600, 100, 50, Color.BROWN);
        Raylib.DrawCircle((int)enemyOptionX, (int)enemyOptionY, radius, Color.BLUE);
        Raylib.DrawCircle((int)enemyOption2X, (int)enemyOption2Y, radius, Color.BLUE);
        Raylib.DrawCircle((int)enemyOption3X, (int)enemyOption3Y, radius, Color.BLUE);
    }

    if (playerHealth <= 0) //gör så att hp inte går ner under 0
    {
        playerHealth = 0;


    }
    if (playerHealth >= 101){ //gör så att hp inte går över 100
        playerHealth = 100;
    }
    if (enemyHealth <=0){ //gör så att hp inte går under 0
        enemyHealth = 0;
    }
    if (enemyHealth >= 1001){ //gör så att hp inte går över 1000
        enemyHealth = 1000;
    }

    Raylib.EndDrawing();
}