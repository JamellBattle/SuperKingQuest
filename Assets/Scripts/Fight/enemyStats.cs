using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyStats : MonoBehaviour
{
    int str = 10;
    int health;
    public int maxHealth;
    public Text Health;

    public void Start()
    {
        health = maxHealth;
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
        Health.text = "HP: " + health + "/60";
    }
    public int getSTR(string move)
    {
        if (move == "Smash")
        {
            return 10;
        }
        if (move == "Vortex")
        {
            return 7;
        }
        return str;
    }

    public string getAttackStatus(string move)
    {
        if (move == "Vortex")
        {
            return "Burn";
        }
        return "";
    }

    public int getAttackStatusChance(string move)
    {
        if (move == "Vortex")
        {
            return 3;
        }
        return 0;
    }

    public string getRandomMove()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            return "Smash";
        }
        if (x == 1)
        {
            return "Vortex";
        }
        return "";
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
}
