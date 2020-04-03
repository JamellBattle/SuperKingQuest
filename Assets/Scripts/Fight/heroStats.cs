using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroStats : MonoBehaviour
{
    int str = 5;
    int health = 30;
    int special = 10;
    int burnEffect = 1;
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
        Health.text = "HP: " + health + "/30";
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
    public int getSTR()
    {
        return str;
    }

    public int getMaxHealth()
    {
        return 30;
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

    public string getStatus()
    {
        return status;
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
