using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyStats : MonoBehaviour
{
    int str = 10;
    int health = 60;
    string attackStatus = "Burn";
    int statusChance = 5;
    public Text Health;
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
    public int getSTR()
    {
        return str;
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

    public string getAttackStatus()
    {
        return attackStatus;
    }
    public int getStatusChance()
    {
        return statusChance;
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
