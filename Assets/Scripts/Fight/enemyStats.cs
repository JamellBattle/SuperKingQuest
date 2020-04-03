using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyStats : MonoBehaviour
{
    int str = 10;
    int health = 60;
    public Text Health;
    public void move(float speed)
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

    public void kill()
    {
        Vector3 movePosition = new Vector3(-1000f, 0.71f, 0);
        transform.position = movePosition;
    }
}
