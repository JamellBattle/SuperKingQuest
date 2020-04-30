using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightUpdated : MonoBehaviour
{
    float entranceTimer = 0;
    float victoryTimer = 0;
    float darkTimer = 0;
    float timer = 0;
    float maxTime = 2.9f;
    int timerOn = 0;
    bool fightOver = false;
    bool moveActionBox = false;
    int heroDamage = 0;
    int enemyDamage = 0;
    int heroStatDamage = 0;
    int statTimeIncrease = 0;
    int enemyStatAfflict = 0;
    int enemyStatAfflict2 = 0;
    float enemyOpacity = 1;
    float darkenOpacity = 0;
    float effectOpacity = 0;
    float retryOpacity = 0;
    string move = "";
    string enemyMove = "";
    string item = "";
    int itemIndex = 0;
    string currAction = "";
    string startBox = "";
    string endBox = "";
    string display = "";
    float attMove = 0.01f;
    float damMove = 16.23f;
    float initialPlayerSpot = 0;
    float initialEnemySpot = 0;
    float initialEnemyVictorySpot = 0;
    float initialDefeatedVictorySpot = 0;
    float initialGameOverGameSpot = 0;
    float initialGameOverOverSpot = 0;
    float initialRetrySpot = 0;
    float heroEntrance = 30.0f;
    float enemyEntrance = 30.0f;
    float EnemyVictoryEntrance = 40.5f;
    float DefeatedVictoryEntrance = 40.5f;
    bool heroArrived = false;
    bool enemyArrived = false;
    bool startupComplete = false;
    bool rewindTime = false;
    float rewindTimer = 0;
    float a = 0;
    int b = 0;
    float c = 0;
    int d = 0;
    public AudioSource Music;
    public AudioSource VictoryMusic;
    public AudioSource DefeatMusic;
    public AudioSource PlayerDeath;
    public AudioSource EnemyDeath;
    public AudioSource Block;
    public AudioSource Menu;
    public AudioSource MenuNull;
    public AudioSource Move;
    public AudioSource Item;
    public AudioSource Hit;
    public heroStats hero;
    public enemyStats enemy;
    public ChooseAction chooseAction;
    public ChooseMove chooseMove;
    public ChooseItem chooseItem;
    public ChooseSpecial chooseSpecial;
    public MoveDisplay moveDisplay;
    public CameraMove mainCamera;
    public OpeningCurtain openingCurtain;
    public OpeningCurtain screenDarken;
    public Victory EnemyVictory;
    public Victory DefeatedVictory;
    public Victory GameOverGame;
    public Victory GameOverOver;
    public Victory Retry;
    public Turn turn;
    public NextScene nextScene;
    void Start()
    {
        Music.Play();
        initialPlayerSpot = hero.getX();
        initialEnemySpot = enemy.getX();
        hero.setX(initialPlayerSpot - 8);
        enemy.setX(initialEnemySpot + 8);
        openingCurtain.setOpacity(1);
        initialEnemyVictorySpot = EnemyVictory.getX();
        initialDefeatedVictorySpot = DefeatedVictory.getX();
        initialGameOverGameSpot = GameOverGame.getX();
        initialGameOverOverSpot = GameOverOver.getX();
        initialRetrySpot = Retry.getX();
        EnemyVictory.setX(initialEnemyVictorySpot - 10, 1.9f);
        DefeatedVictory.setX(initialDefeatedVictorySpot + 10, 0.31f);
        GameOverGame.setX(initialGameOverGameSpot - 10, 1.9f);
        GameOverOver.setX(initialGameOverOverSpot + 10, 0.31f);
        Retry.setX(initialRetrySpot + 10, -1);
    }


    void Update()
    {
        cameraShakeX();
        cameraShakeY();
        opening();
        
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
                enemyStatAfflict = 1;
                enemyStatAfflict2 = 0;
                statTimeIncrease = 1;
            }

            //Player move display box goes down
            if (moveDisplay.getY() > 4.25 && currAction != "" && timer < 0.7 && currAction != "defend")
            {
                moveDisplay.move(-16.075f);
                moveDisplay.setDisplay(display);
            }

            //Player move display box goes up
            if (moveDisplay.getY() < 6.34 && timer >= 0.7 && timer < 1 && currAction != "defend")
            {
                moveDisplay.move(16.075f);
            }

            //Enemy move display box goes down
            if (moveDisplay.getY() > 4.25 && currAction != "" && timer >= 2 && timer < 2.7)
            {
                moveDisplay.move(-16.075f);
                moveDisplay.setDisplay(display);
            }

            //Enemy move display box goes up
            if (moveDisplay.getY() < 6.34 && timer > 2.7)
            {
                moveDisplay.move(16.075f);
            }

            //Moves box goes down
            if (chooseMove.getY() > -5.69 && currAction == "fight")
            {
                chooseMove.move(-16.075f);
            }
            //Items box goes down
            if (chooseItem.getY() > -5.69 && currAction == "item")
            {
                chooseItem.move(-16.075f);
            }
            //Defend box goes down
            if (chooseAction.getY() > -5.69 && timer <= 2.6 && currAction == "defend")
            {
                chooseAction.move(-16.075f);
            }
            //Special box goes down
            if (chooseSpecial.getY() > -5.69 && currAction == "special")
            {
                chooseSpecial.move(-16.075f);
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
                //Debug.Log("Timer Off");
                hero.defend(0);
                hero.hurt(0);
                attMove = 0.01f;
                damMove = 16.23f;
                hero.setX(initialPlayerSpot);
                enemy.setX(initialEnemySpot);
                turn.nextTurn();
                moveActionBox = true;
                timer = 0;
                timerOn = 0;
                maxTime = 2.9f;
                currAction = "";
            }
        }


        //Action box comes up at the end of both turns
        if (chooseAction.getY() < -2.537844 && moveActionBox == true)
        {
            chooseAction.move(16.075f);
        }
        if (chooseAction.getY() >= -2.537844 && moveActionBox == true)
        {
            chooseAction.setY(-2.537844f);
            moveActionBox = false;
        }

        //Switch from Actions to Moves
        if (startBox == "action" && endBox == "move")
        {
            if (chooseAction.getY() > -6.63)
            {
                chooseAction.move(-16.075f); //Actions box moves down
            }
            if (chooseMove.getY() < -2.32 && timer > 0.3)
            {
                chooseMove.move(16.075f); //Moves box moves up
            }
        }
        //Switch from Moves to Actions
        if (startBox == "move" && endBox == "action")
        {
            if (chooseMove.getY() > -6.63)
            {
                chooseMove.move(-16.075f); //Moves box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > 0.3)
            {
                chooseAction.move(16.075f); //Actions box moves up
            }
        }
        //Switch from Actions to Items
        if (startBox == "action" && endBox == "item")
        {
            if (chooseAction.getY() > -6.63)
            {
                chooseAction.move(-16.075f); //Actions box moves down
            }
            if (chooseItem.getY() < -2.33 && timer > 0.3)
            {
                chooseItem.move(16.075f); //Items box moves up
            }
        }
        //Switch from Items to Actions
        if (startBox == "item" && endBox == "action")
        {
            if (chooseItem.getY() > -6.63)
            {
                chooseItem.move(-16.075f); //Items box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > 0.3)
            {
                chooseAction.move(16.075f); //Actions box moves up
            }
        }
        //Switch from Actions to Specials
        if (startBox == "action" && endBox == "special")
        {
            if (chooseAction.getY() > -6.63)
            {
                chooseAction.move(-16.075f); //Actions box moves down
            }
            if (chooseSpecial.getY() < -2.33 && timer > 0.3)
            {
                chooseSpecial.move(16.075f); //Specials box moves up
            }
        }
        //Switch from Specials to Actions
        if (startBox == "special" && endBox == "action")
        {
            if (chooseSpecial.getY() > -6.63)
            {
                chooseSpecial.move(-16.075f); //Specials box moves down
            }
            if (chooseAction.getY() < -2.537844 && timer > 0.3)
            {
                chooseAction.move(16.075f); //Actions box moves up
            }
        }
        if (startBox != "" && endBox != "" && timer >= 0.85)
        {
            //Debug.Log("Timer Off");
            timer = 0;
            timerOn = 0;
            startBox = "";
            endBox = "";
        }

        //Death
        if (hero.dead())
        {
            fightOver = true;
            hero.hurt(1);
            chooseAction.setY(-6.84f);
            moveDisplay.setY(6.34f);
            if (hero.getX() > initialPlayerSpot - 8)
            {
                hero.move(-16.075f);
            }
            defeat();
        }
        if (enemy.dead())
        {
            fightOver = true;
            enemy.hurt(1);
            chooseAction.setY(-6.84f);
            moveDisplay.setY(6.34f);
            if (enemyOpacity > 0)
            {
                enemy.setOpacity(enemyOpacity);
                enemyOpacity -= 0.015f;
            }
            victory();
            if (enemy.getX() > initialEnemySpot + 8)
            {
                enemy.move(16.075f);
            }
        }

        if (rewindTime)
        {
            rewindTimer += Time.deltaTime;
            
            if (openingCurtain.getY() > -12.36)
            {
                openingCurtain.move(-24.15f);
            }
            if (DefeatMusic.volume != 0 && rewindTimer > 1.5f)
            {
                DefeatMusic.volume -= 0.005f;
            }
        }
        if (rewindTimer > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void playerTurn(string action)
    {
        if (action == "fight" || action == "special")
        {
            //Player Deal Damage
            if (timer < 0.15 && attMove < 16.23f)
            {
                Move.Play();
                display = move;
                hero.move(attMove);
                attMove += 0.25f;
            }
            if (timer >= 0.15 && timer < 0.3 && attMove > 0 && hero.getX() > initialPlayerSpot)
            {
                hero.attack(1);
                hero.move(-attMove);
                attMove -= 0.25f;
            }
            //Enemy Take Damage

            if (timer >= 0.6 && timer < 0.63) //Screen shake
            {
                hero.attack(0);
                enemy.hurt(1);
                Hit.Play();
                a = 1.0f;
                b = 0;
            }
            if (timer > 0.6 && timer < 0.75 && damMove > 0)
            {
                enemy.move(damMove);
                damMove -= 0.25f;
            }
            if (timer >= 0.75 && timer < 1 && enemy.getX() > initialEnemySpot)
            {
                enemy.move(-damMove);
                damMove += 0.25f;
                if (enemy.getX() < initialEnemySpot)
                {
                    enemy.setX(initialEnemySpot);
                }
            }
            if (timer >= 0.75 && timer < 0.9)
            {
                enemy.hurt(0);
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
                    if (enemy.getHealth() == 0)
                    {
                        EnemyDeath.Play();
                    }
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
                    Item.Play();
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
                    Block.Play();
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
                    if (enemy.getHealth() == 0)
                    {
                        EnemyDeath.Play();
                    }
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
            hero.hurt(1);
            c = 0.7f;
            d = 0;
            hero.TakeDamage(hero.getMaxHealth() / 16);
            if (hero.getHealth() == 0)
            {
                PlayerDeath.Play();
            }
            heroStatDamage = 0;
        }
        if (timer >= 3.75 && hero.getStatus() == "Poison" && heroStatDamage == 1)
        {
            Hit.Play();
            hero.hurt(1);
            c = 0.7f;
            d = 0;
            hero.TakeDamage(hero.getMaxHealth() / 16);
            if (hero.getHealth() == 0)
            {
                PlayerDeath.Play();
            }
            heroStatDamage = 0;
        }
        if (timer >= 3.75 && timer < 4 && hero.getStatus() == "Burn")
        {
            hero.setFire(effectOpacity);
            effectOpacity += 0.05f;
        }
        if (timer >= 4 && timer < 4.25 && hero.getStatus() == "Burn")
        {
            hero.setFire(effectOpacity);
            effectOpacity -= 0.05f;
        }
        if (timer >= 3.75 && timer < 4 && hero.getStatus() == "Poison")
        {
            hero.setPoison(effectOpacity);
            effectOpacity += 0.05f;
        }
        if (timer >= 4 && timer < 4.25 && hero.getStatus() == "Poison")
        {
            hero.setPoison(effectOpacity);
            effectOpacity -= 0.05f;
        }


        if (timer > 4 && timer < 4.2)
        {
            hero.hurt(0);
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
        if (timer > 2 && timer < 2.15 && attMove < 16.23)
        {
            enemy.attack(1);
            enemy.move(-attMove);
            attMove += 0.25f;
        }
        if (timer >= 2.15 && timer < 2.3 && attMove > 0 && enemy.getX() < initialEnemySpot)
        {
            enemy.move(attMove);
            attMove -= 0.25f;
            if (enemy.getX() > initialEnemySpot)
            {
                enemy.setX(initialEnemySpot);
            }
        }
        if (action != "defend")
        {
            //Player Take Damage
            enemyStatusAfflict(enemy.getAttackStatus(enemyMove), enemy.getAttackStatusChance(enemyMove), heroDamage); //Random Status Affliction
            if (timer >= 2.6 && timer < 2.63) //Screen shake
            {
                enemy.attack(0);
                hero.hurt(1);
                Hit.Play();
                a = 1.0f;
                b = 0;
            }
            if (timer > 2.6 && timer < 2.75 && damMove > 0)
            {
                hero.move(-damMove);
                damMove -= 0.25f;
            }
            if (timer >= 2.75 && timer < 3 && hero.getX() < initialPlayerSpot)
            {
                hero.move(damMove);
                damMove += 0.25f;
                if (hero.getX() > initialPlayerSpot)
                {
                    hero.setX(initialPlayerSpot);
                }
            }
            if (timer >= 2.75 && timer < 2.9)
            {
                hero.hurt(0);
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR(enemyMove));
                    if (hero.getHealth() == 0)
                    {
                        PlayerDeath.Play();
                    }
                    heroDamage = 0;
                }
            }
        }
        else
        {
            //Player Take Damage
            if (timer >= 2.6 && timer < 2.63) //Screen shake
            {
                enemy.attack(0);
                Hit.Play();
                a = 0.5f;
                b = 0;
            }
            if (timer > 2.6 && timer < 2.75)
            {
                hero.move(-damMove);
                damMove -= 0.25f;
            }
            if (timer >= 2.75 && timer < 3 && hero.getX() < initialPlayerSpot)
            {
                hero.move(damMove);
                damMove += 0.25f;
                if (hero.getX() > initialPlayerSpot)
                {
                    hero.setX(initialPlayerSpot);
                }
            }
            if (timer >= 2.75 && timer < 2.9)
            {
                if (heroDamage == 1)
                {
                    hero.TakeDamage(enemy.getSTR(enemyMove) / 2);
                    if (hero.getHealth() == 0)
                    {
                        PlayerDeath.Play();
                    }
                    heroDamage = 0;
                }
            }
        }
    }

    public void fight(int moveIndex)
    {
        if (timer <= 0 && hero.getStatus() != "Curse" && hero.checkMove(moveIndex) && hero.getMove(moveIndex).moveName != "")
        {
            Menu.Play();
            move = hero.getMove(moveIndex).moveName;
            timerOn = 1;
            currAction = "fight";
        }
        else
        {
            MenuNull.Play();
        }
    }

    public void useItem(int newItemIndex)
    {
        if (timer <= 0 && hero.getItem(newItemIndex).itemName != "")
        {
            Menu.Play();
            itemIndex = newItemIndex;
            item = hero.getItem(newItemIndex).itemName;
            timerOn = 1;
            currAction = "item";
        }
        else
        {
            MenuNull.Play();
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
        if (timer <= 0 && hero.getStatus() != "Silence" && hero.checkSpecial(specialIndex) && hero.getSpecial(specialIndex).specialName != "")
        {
            Menu.Play();
            hero.setSP(specialIndex);
            move = hero.getSpecial(specialIndex).specialName;
            timerOn = 1;
            currAction = "special";
        }
        else
        {
            MenuNull.Play();
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
            mainCamera.moveX(48.3f);
        }
        if (mainCamera.getX() >= c && d == 0 && c > 0)
        {
            c -= 0.1f;
            c *= -1;
            d = 1;
        }
        if (mainCamera.getX() > c && d == 1 && c < 0)
        {
            mainCamera.moveX(-48.3f);
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
                mainCamera.moveY(48.3f);
            }
            if (mainCamera.getY() >= a && b == 0 && a > 0)
            {
                a -= 0.1f;
                a *= -1;
                b = 1;
            }
            if (mainCamera.getY() > a && b == 1 && a < 0)
            {
                mainCamera.moveY(-48.3f);
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
                if (Random.Range(0, chance) == 0)
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

    public void opening()
    {
        if (startupComplete == false)
        {
            entranceTimer += Time.deltaTime;
            //Debug.Log(entranceTimer);
        }
        if (entranceTimer >= 0.50)
        {
            if (hero.getX() < initialPlayerSpot && heroArrived == false && enemyArrived == true && startupComplete == false)
            {
                hero.move(heroEntrance);
                heroEntrance -= 0.25f;
            }
            if (hero.getX() >= initialPlayerSpot)
            {
                heroArrived = true;
            }

            if (enemy.getX() > initialEnemySpot && enemyArrived == false && startupComplete == false)
            {
                enemy.move(-enemyEntrance);
                enemyEntrance -= 0.25f;
            }
            if (enemy.getX() <= initialEnemySpot)
            {
                enemyArrived = true;
            }
            if (chooseAction.getY() < -2.537844 && enemyArrived == true && heroArrived == true && startupComplete == false)
            {
                chooseAction.move(16.075f);
            }
            if (chooseAction.getY() >= -2.537844 && startupComplete == false)
            {
                startupComplete = true;
            }
        }

        if (openingCurtain.getY() < 25 && startupComplete == false)
        {
            openingCurtain.move(24.3f);
            // Debug.Log(openingCurtain.getY());
        }
    }

    public void darkenScreen()
    {
        darkTimer++;
        if (darkTimer < 50)
        {
            darkenOpacity += 0.01f;
            screenDarken.setOpacity(darkenOpacity);
        }
    }

    public void victory()
    {
        bool EnemyVictoryDone = false;
        bool done = false;
        if (done == false)
        {
            victoryTimer += Time.deltaTime;
            //Debug.Log(victoryTimer);
        }
        if (victoryTimer > 1.8 && victoryTimer < 2.8)
        {
            darkenScreen();
        }
        if (victoryTimer > 1.80 && victoryTimer < 1.83)
        {
            Music.Stop();
            VictoryMusic.Play();
        }
        if (EnemyVictory.getX() < initialEnemyVictorySpot && victoryTimer > 2.60 && done == false)
        {
            EnemyVictory.move(EnemyVictoryEntrance, 1.9f);
            EnemyVictoryEntrance -= 0.25f;
        }
        if (EnemyVictory.getX() >= initialEnemyVictorySpot)
        {
            EnemyVictoryDone = true;
        }
        if (DefeatedVictory.getX() > initialDefeatedVictorySpot && EnemyVictoryDone == true && victoryTimer > 3.60 && done == false)
        {
            DefeatedVictory.move(-DefeatedVictoryEntrance, 0.31f);
            DefeatedVictoryEntrance -= 0.25f;
        }
        if (DefeatedVictory.getX() <= initialDefeatedVictorySpot)
        {
            done = true;
        }
        if (openingCurtain.getY() > -12.36 && victoryTimer > 7.00)
        {
            openingCurtain.move(-24.3f);
        }
        if (victoryTimer > 7.50 && VictoryMusic.volume != 0)
        {
            VictoryMusic.volume -= 0.01f;
        }
        if (victoryTimer >= 10.00)
        {
            SceneManager.LoadScene(nextScene.nextScene);
        }
    }

    public void defeat()
    {
        bool GameoverGameDone = false;
        bool done = false;
        if (done == false)
        {
            victoryTimer += Time.deltaTime;
        }
        if (victoryTimer > 1.8 && victoryTimer < 2.8)
        {
            darkenScreen();
        }
        if (victoryTimer > 1.80 && victoryTimer < 1.83)
        {
            Music.Stop();
            DefeatMusic.Play();
        }
        if (GameOverGame.getX() < initialGameOverOverSpot && victoryTimer > 2.60 && done == false)
        {
            GameOverGame.move(EnemyVictoryEntrance, 1.9f);
            EnemyVictoryEntrance -= 0.25f;
        }
        if (GameOverGame.getX() >= initialGameOverGameSpot)
        {
            GameoverGameDone = true;
        }
        if (GameOverOver.getX() > initialGameOverOverSpot && GameoverGameDone == true && victoryTimer > 3.60 && done == false)
        {
            GameOverOver.move(-DefeatedVictoryEntrance, 0.31f);
            DefeatedVictoryEntrance -= 0.25f;
        }
        if (GameOverOver.getX() <= initialGameOverOverSpot)
        {
            Retry.setX(initialRetrySpot, -1);
            done = true;
        }
        if (retryOpacity < 1 && done == true && victoryTimer > 5.00)
        {
            Retry.setOpacity(retryOpacity);
            retryOpacity += 0.015f;
        }
    }

    public void reset()
    {
        rewindTime = true;
    }
}
