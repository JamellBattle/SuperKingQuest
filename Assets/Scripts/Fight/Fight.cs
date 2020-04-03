using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    int turn = 1;
    float timer = 0;
    float maxTime = 2.9f;
    int timerOn = 0;
    int fightMode = 0;
    int itemMode = 0;
    int defendMode = 0;
    int moveMode = 0;
    int moveToActionMode = 0;
    int itemToActionMode = 0;
    int itemMoveMode = 0;
    bool fightOver = false;
    int heroDamage = 0;
    int enemyDamage = 0;
    int heroStatDamage = 0;
    int enemyStatDamage = 0;
    int statTimeIncrease = 0;
    int enemyStatAfflict = 0;
    int enemyStatAfflict2 = 0;
    string move = "";
    string item = "";
    int itemIndex = 0;
    itemButton[] itemButt;
    public heroStats hero;
    public enemyStats enemy;
    public ChooseAction chooseAction;
    public ChooseMove chooseMove;
    public ChooseItem chooseItem;
    public itemButton itemButton0;
    public itemButton itemButton1;
    public itemButton itemButton2;
    public itemButton itemButton3;
    public itemButton itemButton4;
    public itemButton itemButton5;
    public itemButton itemButton6;
    public itemButton itemButton7;
    void Start()
    {
        itemButt = new itemButton[8];
        itemButt[0] = itemButton0;
        itemButt[1] = itemButton1;
        itemButt[2] = itemButton2;
        itemButt[3] = itemButton3;
        itemButt[4] = itemButton4;
        itemButt[5] = itemButton5;
        itemButt[6] = itemButton6;
        itemButt[7] = itemButton7;
    }

    
    void Update()
    {
        if (timerOn == 1)
        {
            //Debug.Log(timer);
            timer += Time.deltaTime;
        }

        //Fight
        if (fightMode == 1 && fightOver == false)
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

            //MoveBox
            /*
            if (timer <= 0.3)
            {
                chooseMove.move(-0.075f); //Move box moves down
            }

            if (timer > 2.6 && timer < 2.9)
            {
                chooseAction.move(0.075f); //Action box moves up
            }
            */
            if (chooseMove.getY() > -5.69)
            {
                chooseMove.move(-0.075f); //Move box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > maxTime - 0.3f)
            {
                chooseAction.move(0.075f); //Action box moves up
            }

            //Player's Turn
            //Player Deal Damage
            if (timer < 0.15)
            {
                hero.move(0.05f);
            }
            if (timer >= 0.15 && timer < 0.3)
            {
                hero.move(-0.05f);
            }

            //Enemy Take Damage
            if (timer > 0.6 && timer < 0.75)
            {
                enemy.move(0.05f);
            }
            if (timer >= 0.75 && timer < 0.9)
            {
                enemy.move(-0.05f);
                if (enemyDamage == 1)
                {
                    enemy.TakeDamage(hero.getSTR(move));
                    enemyDamage = 0;
                }
            }

            //Enemy's Turn
            //Enemy Deal Damage
            if (timer > 2 && timer < 2.15)
            {
                enemy.move(-0.05f);
            }
            if (timer >= 2.15 && timer < 2.3)
            {
                enemy.move(0.05f);
            }

            //Player Take Damage
            if (timer > 2.6 && timer < 2.75)
            {
                hero.move(-0.05f);
                if (enemyStatAfflict == 1)
                {
                    if (Random.Range(0, 10) == 0)
                    {
                        maxTime = 4.9f;
                        enemyStatAfflict2 = 1;
                    }
                    enemyStatAfflict = 0;
                }
                
            }
            if (timer >= 2.75 && timer < 2.9)
            {
                hero.move(0.05f);
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR());
                    if (enemyStatAfflict2 == 1)
                    {
                        hero.setStatus("Burn");
                        enemyStatAfflict2 = 0;
                    }
                    heroDamage = 0;
                }
            }

            //Status Effects
            if (hero.getStatus() != "OK" && hero.getStatus() != "Curse" && hero.getStatus() != "Silenced" && statTimeIncrease == 1)
            {
                maxTime = 4.9f;
                heroStatDamage = 1;
                statTimeIncrease = 0;
            }
            if (timer >= 3.75 && hero.getStatus() == "Burn" && heroStatDamage == 1)
            {
                hero.TakeDamage(hero.getMaxHealth() / 16);
                heroStatDamage = 0;
            }
            if (timer >= 3.75 && hero.getStatus() == "Poison" && heroStatDamage == 1)
            {
                hero.TakeDamage(hero.getMaxHealth() / 16);
                heroStatDamage = 0;
            }

            //Both Turns Over
            if (timer >= maxTime)
            {
                Debug.Log("Timer Off");
                timer = 0;
                timerOn = 0;
                maxTime = 2.9f;
                fightMode = 0;
            }
        }


        //Item
        if (timerOn == 1 && itemMode == 1 && fightOver == false)
        {
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

            if (chooseItem.getY() > -5.69)
            {
                chooseItem.move(-0.075f); //Item box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > maxTime - 0.3f)
            {
                chooseAction.move(0.075f); //Action box moves up
            }

            //Player's Turn
            //Player Item
            if (timer > 0.6 && timer < 0.75)
            {
                if (enemyDamage == 1)
                {
                    hero.item(item);
                    if (hero.getStatus() == "OK")
                    {
                        maxTime = 2.9f;
                    }
                    for (int i = itemIndex; i < itemButt.Length - 1; i++)
                    {
                        itemButt[i].setItem(itemButt[i + 1].getItem());
                    }
                    enemyDamage = 0;
                }
            }

            //Enemy's Turn
            //Enemy Deal Damage
            if (timer > 2 && timer < 2.15)
            {
                enemy.move(-0.05f);
            }
            if (timer >= 2.15 && timer < 2.3)
            {
                enemy.move(0.05f);
            }

            //Player Take Damage
            if (timer > 2.6 && timer < 2.75)
            {
                hero.move(-0.05f);
                if (enemyStatAfflict == 1)
                {
                    if (Random.Range(0, 10) == 0)
                    {
                        maxTime = 4.9f;
                        enemyStatAfflict2 = 1;
                    }
                    enemyStatAfflict = 0;
                }
            }
            if (timer >= 2.75 && timer < 2.9)
            {
                hero.move(0.05f);
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR());
                    if (enemyStatAfflict2 == 1)
                    {
                        hero.setStatus("Burn");
                        enemyStatAfflict2 = 0;
                    }
                    heroDamage = 0;
                }
            }

            //Status Effects
            if (hero.getStatus() != "OK" && hero.getStatus() != "Curse" && hero.getStatus() != "Silenced" && statTimeIncrease == 1)
            {
                maxTime = 4.9f;
                heroStatDamage = 1;
                statTimeIncrease = 0;
            }
            if (timer >= 3.75 && hero.getStatus() == "Burn" && heroStatDamage == 1)
            {
                hero.TakeDamage(hero.getMaxHealth() / 16);
                heroStatDamage = 0;
            }
            if (timer >= 3.75 && hero.getStatus() == "Poison" && heroStatDamage == 1)
            {
                hero.TakeDamage(hero.getMaxHealth() / 16);
                heroStatDamage = 0;
            }

            //Both Turns Over
            if (timer >= maxTime)
            {
                Debug.Log("Timer Off");
                timer = 0;
                timerOn = 0;
                maxTime = 2.9f;
                itemMode = 0;
            }
        }

        //Defend
        if (timerOn == 1 && defendMode == 1 && fightOver == false)
        {
            if (timer < 0.1)
            {
                heroDamage = 1;
                enemyDamage = 1;
                heroStatDamage = 0;
                enemyStatDamage = 0;
                enemyStatAfflict = 1;
                enemyStatAfflict2 = 0;
                statTimeIncrease = 1;
                maxTime = 3.5f;
            }
            
            if (chooseAction.getY() > -5.69 && timer <= 2.6)
            {
                chooseAction.move(-0.075f); //Action box moves down
            }
            
            if (chooseAction.getY() < -2.537844 && timer > maxTime - 0.3f)
            {
                chooseAction.move(0.075f); //Action box moves up
            }

            Debug.Log(chooseAction.getY());

            //Player's Turn
            //Player Defend
            if (timer > 0.6 && timer < 0.75)
            {
                if (enemyDamage == 1)
                {
                    hero.defend(1);
                    enemyDamage = 0;
                }
            }

            //Enemy's Turn
            //Enemy Deal Damage
            if (timer > 2 && timer < 2.15)
            {
                enemy.move(-0.05f);
            }
            if (timer >= 2.15 && timer < 2.3)
            {
                enemy.move(0.05f);
            }

            //Player Take Damage
            if (timer > 2.6 && timer < 2.75)
            {
                hero.move(-0.05f);
            }
            if (timer >= 2.75 && timer < 2.9)
            {
                hero.move(0.05f);
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR()/2);
                    heroDamage = 0;
                }
            }

            //Status Effects
            if (hero.getStatus() != "OK" && hero.getStatus() != "Curse" && hero.getStatus() != "Silenced" && statTimeIncrease == 1)
            {
                maxTime = 4.9f;
                heroStatDamage = 1;
                statTimeIncrease = 0;
            }
            if (timer >= 3.75 && hero.getStatus() == "Burn" && heroStatDamage == 1)
            {
                hero.TakeDamage(hero.getMaxHealth() / 16);
                heroStatDamage = 0;
            }
            if (timer >= 3.75 && hero.getStatus() == "Poison" && heroStatDamage == 1)
            {
                hero.TakeDamage(hero.getMaxHealth() / 16);
                heroStatDamage = 0;
            }

            //Both Turns Over
            if (timer >= maxTime)
            {
                Debug.Log("Timer Off");
                hero.defend(0);
                timer = 0;
                timerOn = 0;
                maxTime = 2.9f;
                defendMode = 0;
            }
        }

        //Switch to Move
        if (timerOn == 1 && moveMode == 1 && fightOver == false)
        { /*
            if (timer <= 0.3)
            {
                chooseAction.move(-0.075f); //Action box moves down
            }
            if (timer > 0.4 && timer < 0.7)
            {
                chooseMove.move(0.075f); //Move box moves up
            }
            */

            if (chooseAction.getY() > -5.69)
            {
                chooseAction.move(-0.075f); //Action box moves down
            }
            if (chooseMove.getY() < -2.32 && timer > 0.3)
            {
                chooseMove.move(0.075f); //Move box moves up
            }

            if (timer >= 0.7)
            {
                Debug.Log("Timer Off");
                timer = 0;
                timerOn = 0;
                moveMode = 0;
            }
        }

        //Switch to Item
        if (timerOn == 1 && itemMoveMode == 1 && fightOver == false)
        {
            if (chooseAction.getY() > -5.69)
            {
                chooseAction.move(-0.075f); //Action box moves down
            }
            if (chooseItem.getY() < -2.32 && timer > 0.3)
            {
                chooseItem.move(0.075f); //Item box moves up
            }

            if (timer >= 0.7)
            {
                Debug.Log("Timer Off");
                timer = 0;
                timerOn = 0;
                itemMoveMode = 0;
            }
        }

        //Switch from Move back to Action
        if (timerOn == 1 && moveToActionMode == 1 && fightOver == false)
        {
            if (chooseMove.getY() > -5.69)
            {
                chooseMove.move(-0.075f); //Action box moves down
            }
            if (chooseAction.getY() < -2.32 && timer > 0.3)
            {
                chooseAction.move(0.075f); //Move box moves up
            }

            if (timer >= 0.7)
            {
                Debug.Log("Timer Off");
                timer = 0;
                timerOn = 0;
                moveToActionMode = 0;
            }
        }

        //Switch from Item back to Action
        if (timerOn == 1 && itemToActionMode == 1 && fightOver == false)
        {
            if (chooseItem.getY() > -5.69)
            {
                chooseItem.move(-0.075f); //Action box moves down
            }
            if (chooseAction.getY() < -2.32 && timer > 0.3)
            {
                chooseAction.move(0.075f); //Move box moves up
            }

            if (timer >= 0.7)
            {
                Debug.Log("Timer Off");
                timer = 0;
                timerOn = 0;
                itemToActionMode = 0;
            }
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

    public void fight()
    {
        if (timer <= 0)
        {
            timerOn = 1;
            fightMode = 1;
        }
    }

    public void fight(string newMove)
    {
        if (timer <= 0 && hero.getStatus() != "Curse")
        {
            move = newMove;
            timerOn = 1;
            fightMode = 1;
        }
    }

    public void useItem(int newItemIndex)
    {
        if (timer <= 0 && itemButt[newItemIndex].getItem() != "")
        {
            itemIndex = newItemIndex;
            item = itemButt[itemIndex].getItem();
            timerOn = 1;
            itemMode = 1;
        }
    }

    /*
    public void itemIndex(int newItemButtonIndex)
    {
        itemButtonIndex = newItemButtonIndex;
    }
    */

    public void defend()
    {
        if (timer <= 0)
        {
            timerOn = 1;
            defendMode = 1;
        }
    }

    public void switchToMove()
    {
        if (timer <= 0)
        {
            timerOn = 1;
            moveMode = 1;
        }
    }

    public void switchToItem()
    {
        if (timer <= 0)
        {
            timerOn = 1;
            itemMoveMode = 1;
        }
    }
    public void switchMoveToAction()
    {
        if (timer <= 0)
        {
            timerOn = 1;
            moveToActionMode = 1;
        }
    }

    public void switchItemToAction()
    {
        if (timer <= 0)
        {
            timerOn = 1;
            itemToActionMode = 1;
        }
    }
}
