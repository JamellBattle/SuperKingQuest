using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroStats : MonoBehaviour
{
    int str = 5;
    int spl = 15;
    int health = 30;
    int special = 10;
    int burnEffect = 1;
    int poisonEffect = 1;
    string status = "OK";
    public Text Health;
    public Text Special;
    public Text Status;
    public Sprite mainSprite;
    public Sprite defendSprite;

    public void Start()
    {
        Status.text = status;
    }

    public void move(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + speed, 0.71f, 0);
        transform.position = movePosition;
    }
    public void TakeDamage(int dam)
    {
        health = health - dam;
        if (health < 0)
        {
            health = 0;
        }
        Health.text = "HP: " + health + "/30";
        Status.text = status;
    }
    public void item(string item)
    {
        if (item == "Soda")
        {
            health = health + 10;
        }
        if (item == "Large Soda")
        {
            health = health + 20;
        }
        if (item == "Honey Jar")
        {
            special = special + 5;
        }
        if (item == "Medicine")
        {
            status = "OK";
        }
        if (item == "Revival Herb")
        {
            health = health + 30;
        }

        if (health > 30)
        {
            health = 30;
        }
        if (special > 10)
        {
            special = 10;
        }
        Health.text = "HP: " + health + "/30";
        Special.text = "SP: " + special + "/10";
        Status.text = status;
    }
    public void defend(int defence)
    {
        if (defence == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = defendSprite;
        }
        if (defence == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = mainSprite;
        }
    }
    public int getMaxHealth()
    {
        return 30;
    }
    public int getSTR()
    {
        return str;
    }
    public int getSPL()
    {
        return spl;
    }
    public int getSTR(string move)
    {
        if (status == "Burn")
        {
            burnEffect = 2;
        }
        else
        {
            burnEffect = 1;
        }

        if (move == "punch")
        {
            return 7 / burnEffect;
        }

        if (move == "jump")
        {
            return 11 / burnEffect;
        }

        if (move == "hammer")
        {
            return 16 / burnEffect;
        }

        if (move == "bfg")
        {
            return 9999 / burnEffect;
        }
        return str;
    }
    public int getSPL(string move)
    {
        if (status == "Poison")
        {
            poisonEffect = 2;
        }
        else
        {
            poisonEffect = 1;
        }

        if (move == "fireball")
        {
            return 21 / poisonEffect;
        }

        if (move == "superjump")
        {
            return 36 / poisonEffect;
        }
        return spl;
    }

    public string getStatus()
    {
        return status;
    }

    public bool checkSpecial(string move)
    {
        if (move == "fireball" && special >= 2)
        {
            return true;
        }
        if (move == "superjump" && special >= 5)
        {
            return true;
        }
        return false;
    }

    public void setSP(string move)
    {
        if (move == "fireball")
        {
            special -= 2;
        }
        if (move == "superjump")
        {
            special -= 5;
        }
        Special.text = "SP: " + special + "/10";
    }

    public void setStatus(string newStatus)
    {
        status = newStatus;
        Status.text = status;
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
        Vector3 movePosition = new Vector3(-1000f, 0.71f, 0);
        transform.position = movePosition;
    }
}
