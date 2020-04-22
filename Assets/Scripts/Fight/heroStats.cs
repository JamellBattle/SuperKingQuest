using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroStats : MonoBehaviour
{
    public string heroName;
    public Sprite Appearance;
    public Sprite DefendingAppearance;
    public Sprite AttackingAppearance;
    public Sprite HurtingAppearance;
    int str = 5;
    int spl = 15;
    int health;
    public int maxHealth;
    int special;
    public int maxSpecial;
    int burnEffect = 1;
    int poisonEffect = 1;
    string status = "OK";
    public string move1Name;
    public int move1Damage;
    public string move2Name;
    public int move2Damage;
    public string move3Name;
    public int move3Damage;
    public string move4Name;
    public int move4Damage;
    public string special1Name;
    public int special1Damage;
    public int special1Cost;
    public string special2Name;
    public int special2Damage;
    public int special2Cost;
    public string special3Name;
    public int special3Damage;
    public int special3Cost;
    public string special4Name;
    public int special4Damage;
    public int special4Cost;
    public string item1Name;
    public string item2Name;
    public string item3Name;
    public string item4Name;
    public string item5Name;
    public string item6Name;
    public string item7Name;
    public string item8Name;
    public Text Name;
    public Text Health;
    public Text Special;
    public Text Status;
    public move move1;
    public move move2;
    public move move3;
    public move move4;
    public item item1;
    public item item2;
    public item item3;
    public item item4;
    public item item5;
    public item item6;
    public item item7;
    public item item8;
    public special special1;
    public special special2;
    public special special3;
    public special special4;
    move[] moves;
    item[] items;
    special[] specials;

    public void Start()
    {
        health = maxHealth;
        special = maxSpecial;
        Name.text = heroName;
        Health.text = "HP: " + health + "/" + maxHealth;
        Special.text = "SP: " + special + "/" + maxSpecial;
        Status.text = status;
        move1.moveName = move1Name;
        move1.damage = move1Damage;
        move2.moveName = move2Name;
        move2.damage = move2Damage;
        move3.moveName = move3Name;
        move3.damage = move3Damage;
        move4.moveName = move4Name;
        move4.damage = move4Damage;
        item1.itemName = item1Name;
        item2.itemName = item2Name;
        item3.itemName = item3Name;
        item4.itemName = item4Name;
        item5.itemName = item5Name;
        item6.itemName = item6Name;
        item7.itemName = item7Name;
        item8.itemName = item8Name;
        special1.specialName = special1Name;
        special1.damage = special1Damage;
        special1.cost = special1Cost;
        special2.specialName = special2Name;
        special2.damage = special2Damage;
        special2.cost = special2Cost;
        special3.specialName = special3Name;
        special3.damage = special3Damage;
        special3.cost = special3Cost;
        special4.specialName = special4Name;
        special4.damage = special4Damage;
        special4.cost = special4Cost;
        moves = new move[4];
        moves[0] = move1;
        moves[1] = move2;
        moves[2] = move3;
        moves[3] = move4;
        items = new item[8];
        items[0] = item1;
        items[1] = item2;
        items[2] = item3;
        items[3] = item4;
        items[4] = item5;
        items[5] = item6;
        items[6] = item7;
        items[7] = item8;
        specials = new special[4];
        specials[0] = special1;
        specials[1] = special2;
        specials[2] = special3;
        specials[3] = special4;
    }

    public void move(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + speed, 0.71f, 0);
        transform.position = movePosition;
    }

    public void attMove(float speed)
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
        Health.text = "HP: " + health + "/" + maxHealth;
        Status.text = status;
    }
    public void item(string item)
    {
        int x = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (item == items[i].itemName)
            {
                x = i;
                if (items[i].itemEffect() != "")
                {
                    if (items[i].itemEffect().Substring(0, items[i].itemEffect().IndexOf(' ')) == "HP")
                    {
                        health = health + int.Parse(items[i].itemEffect().Substring(items[i].itemEffect().IndexOf(' ') + 1));
                    }
                    if (items[i].itemEffect().Substring(0, items[i].itemEffect().IndexOf(' ')) == "SP")
                    {
                        special = special + int.Parse(items[i].itemEffect().Substring(items[i].itemEffect().IndexOf(' ') + 1));
                    }
                    if (items[i].itemEffect().Substring(0, items[i].itemEffect().IndexOf(' ')) == "STATUS")
                    {
                        status = items[i].itemEffect().Substring(items[i].itemEffect().IndexOf(' ') + 1);
                    }
                }
            }
        }
        for (int i = x; i < items.Length - 1; i++)
        {
            items[i].setItem(items[i + 1].getItem());
        }




        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (special > maxSpecial)
        {
            special = maxSpecial;
        }
        Health.text = "HP: " + health + "/" + maxHealth;
        Special.text = "SP: " + special + "/" + maxSpecial;
        Status.text = status;
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
    public void defend(int defence)
    {
        if (defence == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = DefendingAppearance;
        }
        if (defence == 0)
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
    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getHealth()
    {
        return health;
    }

    public int getMaxSpecial()
    {
        return maxSpecial;
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
        for (int i = 0; i < moves.Length; i++)
        {
            if (move == moves[i].moveName)
            {
                return moves[i].damage / burnEffect;
            }
        }
        return str;
    }
    public int getSPL(string special)
    {
        if (status == "Poison")
        {
            poisonEffect = 2;
        }
        else
        {
            poisonEffect = 1;
        }
        for (int i = 0; i < specials.Length; i++)
        {
            if (special == specials[i].specialName)
            {
                return specials[i].damage / poisonEffect;
            }
        }
        return spl;
    }

    public string getStatus()
    {
        return status;
    }

    public move getMove(int index)
    {
        return moves[index];
    }

    public item getItem(int index)
    {
        return items[index];
    }

    public special getSpecial(int index)
    {
        return specials[index];
    }

    public bool checkSpecial(int specialIndex)
    {
        if (special >= specials[specialIndex].cost)
        {
            return true;
        }
        return false;
    }

    public void setSP(int specialIndex)
    {
        special -= specials[specialIndex].cost;
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

    public float getX()
    {
        return this.transform.position.x;
    }

    public void setX(float x)
    {
        Vector3 movePosition = new Vector3(x, 0.71f, 0);
        transform.position = movePosition;
    }
}
