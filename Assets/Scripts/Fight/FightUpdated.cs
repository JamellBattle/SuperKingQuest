using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightUpdated : MonoBehaviour
{
    int turn = 1;
    float timer = 0;
    float maxTime = 2.9f;
    int timerOn = 0;
    bool fightOver = false;
    int heroDamage = 0;
    int enemyDamage = 0;
    int heroStatDamage = 0;
    int enemyStatDamage = 0;
    int statTimeIncrease = 0;
    int enemyStatAfflict = 0;
    int enemyStatAfflict2 = 0;
    string move = "";
    string enemyMove = "";
    string item = "";
    int itemIndex = 0;
    string currAction = "";
    string startBox = "";
    string endBox = "";
    string display = "";
    float attMove = 0.01f;
    float damMove = 0.23f;
    float initialPlayerSpot = 0;
    float initialEnemySpot = 0;
    float a = 0;
    int b = 0;
    float c = 0;
    int d = 0;
    public AudioSource Hit;
    public AudioSource Move;
    public AudioSource Menu;
    public heroStats hero;
    public enemyStats enemy;
    public ChooseAction chooseAction;
    public ChooseMove chooseMove;
    public ChooseItem chooseItem;
    public ChooseSpecial chooseSpecial;
    public MoveDisplay moveDisplay;
    public CameraMove mainCamera;
    void Start()
    {
        initialPlayerSpot = hero.getX();
        initialEnemySpot = enemy.getX();
    }


    void Update()
    {
        cameraShakeX();
        cameraShakeY();
        if (timerOn == 1)
        {
            //Debug.Log(timer);
            timer += Time.deltaTime;
        }

        //Fight!
        if (timerOn == 1 && fightOver == false)
        {
            //Setup
            if (timer < 0.1)
            {
                heroDamage = 1;
                enemyDamage = 1;
                heroStatDamage = 0;
                enemyStatDamage = 0;
                enemyStatAfflict = 1;
                enemyStatAfflict2 = 0;
                statTimeIncrease = 1;
            }

            //Player move display box goes down
            if (moveDisplay.getY() > 4.25 && currAction != "" && timer < 0.7 && currAction != "defend")
            {
                moveDisplay.move(-0.075f);
                moveDisplay.setDisplay(display);
            }

            //Player move display box goes up
            if (moveDisplay.getY() < 6.34 && timer >= 0.7 && timer < 1 && currAction != "defend")
            {
                moveDisplay.move(0.075f);
            }

            //Enemy move display box goes down
            if (moveDisplay.getY() > 4.25 && currAction != "" && timer >= 2 && timer < 2.7)
            {
                moveDisplay.move(-0.075f);
                moveDisplay.setDisplay(display);
            }

            //Enemy move display box goes up
            if (moveDisplay.getY() < 6.34 && timer > 2.7)
            {
                moveDisplay.move(0.075f);
            }

            //Moves box goes down
            if (chooseMove.getY() > -5.69 && currAction == "fight")
            {
                chooseMove.move(-0.075f);
            }
            //Items box goes down
            if (chooseItem.getY() > -5.69 && currAction == "item")
            {
                chooseItem.move(-0.075f);
            }
            //Defend box goes down
            if (chooseAction.getY() > -5.69 && timer <= 2.6 && currAction == "defend")
            {
                chooseAction.move(-0.075f);
            }
            //Special box goes down
            if (chooseSpecial.getY() > -5.69 && currAction == "special")
            {
                chooseSpecial.move(-0.075f);
            }
            //Action box comes up at the end of both turns
            if (chooseAction.getY() < -2.537844 && timer > maxTime - 0.4f)
            {
                chooseAction.move(0.075f);
            }
            playerTurn(currAction); //Player's Turn
            
            //attMove = 0.01f;
            //damMove = 0.23f;
            enemyTurn(currAction); //Enemy's Turn
            //attMove = 0.01f;
            //damMove = 0.23f;

            //Both Turns Over
            if (timer >= maxTime)
            {
                Debug.Log("Timer Off");
                hero.defend(0);
                attMove = 0.01f;
                damMove = 0.23f;
                hero.setX(initialPlayerSpot);
                enemy.setX(initialEnemySpot);
                timer = 0;
                timerOn = 0;
                maxTime = 2.9f;
                currAction = "";
            }
        }

        //Switch from Actions to Moves
        if (startBox == "action" && endBox == "move")
        {
            if (chooseAction.getY() > -6.63)
            {
                chooseAction.move(-0.075f); //Actions box moves down
            }
            if (chooseMove.getY() < -2.32 && timer > 0.3)
            {
                chooseMove.move(0.075f); //Moves box moves up
            }
        }
        //Switch from Moves to Actions
        if (startBox == "move" && endBox == "action")
        {
            if (chooseMove.getY() > -6.63)
            {
                chooseMove.move(-0.075f); //Moves box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > 0.3)
            {
                chooseAction.move(0.075f); //Actions box moves up
            }
        }
        //Switch from Actions to Items
        if (startBox == "action" && endBox == "item")
        {
            if (chooseAction.getY() > -6.63)
            {
                chooseAction.move(-0.075f); //Actions box moves down
            }
            if (chooseItem.getY() < -2.33 && timer > 0.3)
            {
                chooseItem.move(0.075f); //Items box moves up
            }
        }
        //Switch from Items to Actions
        if (startBox == "item" && endBox == "action")
        {
            if (chooseItem.getY() > -6.63)
            {
                chooseItem.move(-0.075f); //Items box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > 0.3)
            {
                chooseAction.move(0.075f); //Actions box moves up
            }
        }
        //Switch from Actions to Specials
        if (startBox == "action" && endBox == "special")
        {
            if (chooseAction.getY() > -6.63)
            {
                chooseAction.move(-0.075f); //Actions box moves down
            }
            if (chooseSpecial.getY() < -2.33 && timer > 0.3)
            {
                chooseSpecial.move(0.075f); //Specials box moves up
            }
        }
        //Switch from Specials to Actions
        if (startBox == "special" && endBox == "action")
        {
            if (chooseSpecial.getY() > -6.63)
            {
                chooseSpecial.move(-0.075f); //Specials box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > 0.3)
            {
                chooseAction.move(0.075f); //Actions box moves up
            }
        }
        if (startBox != "" && endBox != "" && timer >= 0.7)
        {
            Debug.Log("Timer Off");
            timer = 0;
            timerOn = 0;
            startBox = "";
            endBox = "";
        }

        //Death
        if (hero.dead())
        {
            hero.kill();
            fightOver = true;
        }
        if (enemy.dead())
        {
            enemy.kill();
            fightOver = true;
        }
    }

    public void playerTurn(string action)
    {
        if (action == "fight" || action == "special")
        {
            //Player Deal Damage
            if (timer < 0.15 && attMove < 0.23f)
            {
                Move.Play();
                display = move;
                hero.move(attMove);
                attMove += 0.01f;
             //   Debug.Log("PlayerTurn attMove right: " + attMove);
            }
            if (timer >= 0.15 && timer < 0.3 && attMove > 0 && hero.getX() > initialPlayerSpot)
            {
                hero.move(-attMove);
                attMove -= 0.01f;
              //  Debug.Log("PlayerTurn attMove left: " + attMove);
            }
            //Enemy Take Damage

            if (timer >= 0.6 && timer < 0.63) //Screen shake
            {
                Hit.Play();
                a = 1.0f;
                b = 0;
            }
            if (timer > 0.6 && timer < 0.75 && damMove > 0)
            {
                enemy.move(damMove);
                damMove -= 0.01f;
               // Debug.Log("PlayerTurn damMove right: " + damMove);
            }
            if (timer >= 0.75 && timer < 0.9 && damMove < 0.22f && enemy.getX() > initialEnemySpot)
            {
                enemy.move(-damMove);
                damMove += 0.01f;
                //Debug.Log("PlayerTurn damMove left: " + damMove);
            }
        }
        if (action == "fight")
        {
            //Enemy takes regular damage
            if (timer >= 0.75 && timer < 0.9)
            {
                if (enemyDamage == 1)
                {
                    enemy.TakeDamage(hero.getSTR(move));
                    enemyDamage = 0;
                }
            }
        }
        if (action == "item")
        {
            //Player Item
            if (timer < 0.15)
            {
                display = item;
            }
            if (timer > 0.6 && timer < 0.75)
            {
                if (enemyDamage == 1)
                {
                    Debug.Log("WHAAT");
                    hero.item(item);
                    if (hero.getStatus() == "OK")
                    {
                        maxTime = 2.9f;
                    }
                    enemyDamage = 0;
                }
            }
        }
        if (action == "defend")
        {
            //Player Defend
            if (timer > 0.6 && timer < 0.75)
            {
                if (enemyDamage == 1)
                {
                    hero.defend(1);
                    enemyDamage = 0;
                }
            }
        }
        if (action == "special")
        {
            //Enemy takes special damage
            if (timer >= 0.75 && timer < 0.9)
            {
                if (enemyDamage == 1)
                {
                    enemy.TakeDamage(hero.getSPL(move));
                    enemyDamage = 0;
                }
            }
        }

        //Status
        if (hero.getStatus() != "OK" && hero.getStatus() != "Curse" && hero.getStatus() != "Silence" && statTimeIncrease == 1)
        {
            maxTime = 4.9f;
            heroStatDamage = 1;
            statTimeIncrease = 0;
        }
        if (timer >= 3.75 && hero.getStatus() == "Burn" && heroStatDamage == 1)
        {
            Hit.Play();
            c = 0.7f;
            d = 0;
            hero.TakeDamage(hero.getMaxHealth() / 16);
            heroStatDamage = 0;
        }
        if (timer >= 3.75 && hero.getStatus() == "Poison" && heroStatDamage == 1)
        {
            hero.TakeDamage(hero.getMaxHealth() / 16);
            heroStatDamage = 0;
        }
    }

    public void enemyTurn(string action)
    {
        //Enemy Deal Damage
        if (timer > 2.09 && timer < 2.1)
        {
            enemyMove = enemy.getRandomMove();
            display = enemyMove;
            Move.Play();
        }
        if (timer > 2 && timer < 2.15 && attMove < 0.23)
        {
            enemy.move(-attMove);
            attMove += 0.01f;
        }
        if (timer >= 2.15 && timer < 2.3 && attMove > 0 && enemy.getX() < initialEnemySpot)
        {
            enemy.move(attMove);
            attMove -= 0.01f;
        }
        if (action != "defend")
        {
            //Player Take Damage
            enemyStatusAfflict(enemy.getAttackStatus(enemyMove), enemy.getAttackStatusChance(enemyMove), heroDamage); //Random Status Affliction
            if (timer >= 2.6 && timer < 2.63) //Screen shake
            {
                Hit.Play();
                a = 1.0f;
                b = 0;
            }
            if (timer > 2.6 && timer < 2.75 && damMove > 0)
            {
                hero.move(-damMove);
                damMove -= 0.01f;
            }
            if (timer >= 2.75 && timer < 2.9 && damMove < 0.23f && hero.getX() < initialPlayerSpot)
            {
                hero.move(damMove);
                damMove += 0.01f;
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR(enemyMove));
                    heroDamage = 0;
                }
            }
        }
        else
        {
            //Player Take Damage
            if (timer >= 2.6 && timer < 2.63) //Screen shake
            {
                Hit.Play();
                a = 0.5f;
                b = 0;
            }
            if (timer > 2.6 && timer < 2.75)
            {
                hero.move(-damMove);
                damMove -= 0.01f;
            }
            if (timer >= 2.75 && timer < 2.9 && hero.getX() < initialPlayerSpot)
            {
                hero.move(damMove);
                damMove += 0.01f;
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR(enemyMove) / 2);
                    heroDamage = 0;
                }
            }
        }
    }

    public void fight(int moveIndex)
    {
        Menu.Play();
        if (timer <= 0 && hero.getStatus() != "Curse" && hero.getMove(moveIndex).moveName != "")
        {
            move = hero.getMove(moveIndex).moveName;
            timerOn = 1;
            currAction = "fight";
        }
    }

    public void useItem(int newItemIndex)
    {
        Menu.Play();
        if (timer <= 0 && hero.getItem(newItemIndex).itemName != "")
        {
            itemIndex = newItemIndex;
            item = hero.getItem(newItemIndex).itemName;
            timerOn = 1;
            currAction = "item";
        }
    }

    public void defend()
    {
        Menu.Play();
        if (timer <= 0)
        {
            timerOn = 1;
            currAction = "defend";
        }
    }

    public void special(int specialIndex)
    {
        Menu.Play();
        if (timer <= 0 && hero.getStatus() != "Silence" && hero.checkSpecial(specialIndex) && hero.getSpecial(specialIndex).specialName != "")
        {
            hero.setSP(specialIndex);
            move = hero.getSpecial(specialIndex).specialName;
            timerOn = 1;
            currAction = "special";
        }
    }

    public void switchBox(string newBox)
    {
        Menu.Play();
        if (timer <= 0)
        {
            timerOn = 1;
            startBox = newBox.Substring(0, newBox.IndexOf(" "));
            endBox = newBox.Substring(newBox.IndexOf(" ") + 1);
        }
    }

    public void cameraShakeX()
    {

        if (mainCamera.getX() < c && d == 0 && c > 0)
        {
            mainCamera.moveX(0.3f);
        }
        if (mainCamera.getX() >= c && d == 0 && c > 0)
        {
            c -= 0.1f;
            c *= -1;
            d = 1;
        }
        if (mainCamera.getX() > c && d == 1 && c < 0)
        {
            mainCamera.moveX(-0.3f);
        }
        if (mainCamera.getX() <= c && d == 1 && c < 0)
        {
            c += 0.1f;
            c *= -1;
            d = 0;
        }
        if (c < 0.1 && c > -0.1 && a < 0.1 && a > -0.1)
        {
            c = 0;
            mainCamera.setX(0);
        }
    }

    public void cameraShakeY()
    {
        
            if (mainCamera.getY() < a && b == 0 && a > 0)
            {
                mainCamera.moveY(0.3f);
            }
            if (mainCamera.getY() >= a && b == 0 && a > 0)
            {
                a -= 0.1f;
                a *= -1;
                b = 1;
            }
            if (mainCamera.getY() > a && b == 1 && a < 0)
            {
                mainCamera.moveY(-0.3f);
            }
            if (mainCamera.getY() <= a && b == 1 && a < 0)
            {
                a += 0.1f;
                a *= -1;
                b = 0;
            }
            if (a < 0.1 && a > -0.1 && c < 0.1 && c > -0.1)
            {
            a = 0;
            mainCamera.setY(0);
            }
    }

    public void enemyStatusAfflict(string status, int chance, int heroDamage2)
    {
        if (timer > 2.6 && timer < 2.75 && status != "")
        {
            if (enemyStatAfflict == 1)
            {
                if (Random.Range(0, 1) == 0)
                {
                    maxTime = 4.9f;
                    enemyStatAfflict2 = 1;
                }
                enemyStatAfflict = 0;
            }
        }
        if (timer >= 2.75 && timer < 2.9 && status != "")
        {
            if (heroDamage2 == 1)
            {
                if (enemyStatAfflict2 == 1)
                {
                    hero.setStatus(status);
                    enemyStatAfflict2 = 0;
                }
                heroDamage2 = 0;
            }
        }
    }
}
