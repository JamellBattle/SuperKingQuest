using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyStats : MonoBehaviour
{
    int str = 10;
    int health;
    public string enemyName;
    public Sprite Appearance;
    public Sprite AttackingAppearance;
    public Sprite HurtingAppearance;
    public int maxHealth;
    public string move1Name;
    public int move1Damage;
    public string move1Status;
    public int move1StatusChance;
    public string move2Name;
    public int move2Damage;
    public string move2Status;
    public int move2StatusChance;
    public string move3Name;
    public int move3Damage;
    public string move3Status;
    public int move3StatusChance;
    public string move4Name;
    public int move4Damage;
    public string move4Status;
    public int move4StatusChance;
    public enemymove move1;
    public enemymove move2;
    public enemymove move3;
    public enemymove move4;
    enemymove[] moves;
    public Text Name;
    public Text Health;

    public void Start()
    {
        move1.moveName = move1Name;
        move1.damage = move1Damage;
        move1.status = move1Status;
        move1.statuschance = move1StatusChance;
        move2.moveName = move2Name;
        move2.damage = move2Damage;
        move2.status = move2Status;
        move2.statuschance = move2StatusChance;
        move3.moveName = move3Name;
        move3.damage = move3Damage;
        move3.status = move3Status;
        move3.statuschance = move3StatusChance;
        move4.moveName = move4Name;
        move4.damage = move4Damage;
        move4.status = move4Status;
        move4.statuschance = move4StatusChance;
        moves = new enemymove[4];
        moves[0] = move1;
        moves[1] = move2;
        moves[2] = move3;
        moves[3] = move4;
        Name.text = enemyName;
        health = maxHealth;
        this.GetComponent<SpriteRenderer>().sprite = Appearance;
        Health.text = "HP: " + health + "/" + maxHealth;
    }
    public void move(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + speed, 1.07f, 0);
        transform.position = movePosition;
    }

    public void damMove(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + speed, 1.07f, 0);
        transform.position = movePosition;
    }
    public void TakeDamage(int dam)
    {
        health = health - dam;
        if (health < 0)
        {
            health = 0;
        }
        Health.text = "HP: " + health + "/" + maxHealth;
    }
    public void attack(int attack)
    {
        if (attack == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = AttackingAppearance;
        }
        if (attack == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Appearance;
        }
    }
    public void hurt(int hurting)
    {
        if (hurting == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = HurtingAppearance;
        }
        if (hurting == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Appearance;
        }
    }
    public int getSTR(string move)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            if (move == moves[i].moveName)
            {
                return moves[i].damage;
            }
        }
        return str;
    }

    public string getAttackStatus(string move)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            if (move == moves[i].moveName)
            {
                return moves[i].status;
            }
        }
        return "";
    }

    public int getAttackStatusChance(string move)
    {
        for (int i = 0; i < moves.Length; i++)
        {
            if (move == moves[i].moveName)
            {
                return moves[i].statuschance;
            }
        }
        return 0;
    }

    public string getRandomMove()
    {
        int x = Random.Range(0, 4);
        while (x != 5)
        {
            if (moves[x].moveName != "")
            {
                return moves[x].moveName;
            }
            else
            {
                x = Random.Range(0, 4);
            }
        }
        return "";
    }
    public int getHealth()
    {
        return health;
    }
    
    public bool dead()
    {
        if (health == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void kill()
    {
        Vector3 movePosition = new Vector3(-1000f, 1.07f, 0);
        transform.position = movePosition;
    }

    public float getX()
    {
        return this.transform.position.x;
    }

    public void setX(float x)
    {
        Vector3 movePosition = new Vector3(x, 1.07f, 0);
        transform.position = movePosition;
    }

    public void setOpacity(float x)
    {
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = x;
        this.GetComponent<SpriteRenderer>().color = tmp;
    }
}
