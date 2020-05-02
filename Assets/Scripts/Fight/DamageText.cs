using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public Text HeroDMG;
    public Text EnemyDMG;
    float posY;

    void Start()
    {
        posY = this.GetComponent<RectTransform>().anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void dmgText(string who, string dmg)
    {
        if (who == "hero")
        {
            HeroDMG.text = "-" + dmg;
        }
        if (who == "enemy")
        {
            EnemyDMG.text = "-" + dmg;
            Color tmp = HeroDMG.GetComponent<Text>().color;
            tmp.r = 1;
            tmp.b = 1;
            EnemyDMG.GetComponent<Text>().color = tmp;
        }
        if (who == "item")
        {
            if (dmg == "OK")
            {
                EnemyDMG.text = dmg;
            }
            else
            {
                EnemyDMG.text = "+" + dmg;
            }
            Color tmp = HeroDMG.GetComponent<Text>().color;
            tmp.r = 0;
            tmp.b = 0;
            EnemyDMG.GetComponent<Text>().color = tmp;
        }
        if (who == "burn")
        {
            EnemyDMG.text = "-" + dmg;
            Color tmp = HeroDMG.GetComponent<Text>().color;
            tmp.r = 1;
            tmp.b = 0;
            tmp.g = 0;
            EnemyDMG.GetComponent<Text>().color = tmp;
        }
        if (who == "poison")
        {
            EnemyDMG.text = "-" + dmg;
            Color tmp = HeroDMG.GetComponent<Text>().color;
            tmp.r = 1;
            tmp.b = 1;
            tmp.g = 0;
            EnemyDMG.GetComponent<Text>().color = tmp;
        }
    }

    public void move(string who, float speed)
    {
        //Debug.Log("COCK");
        //float posX = GetComponent<RectTransform>().anchoredPosition.x;
        //float posY = GetComponent<RectTransform>().anchoredPosition.y;
        if (who == "hero")
        {
            Vector3 movePosition = new Vector3(0, speed * Time.deltaTime, 0);
            HeroDMG.transform.Translate(movePosition);
        }
        if (who == "enemy" || who == "item" || who == "burn" || who == "poison")
        {
            Vector3 movePosition = new Vector3(0, speed * Time.deltaTime, 0);
            EnemyDMG.transform.Translate(movePosition);
        }
    }

    public void setOpacity(string who, float x)
    {
        if (who == "hero")
        {
            Color tmp = HeroDMG.GetComponent<Text>().color;
            tmp.a = x;
            HeroDMG.GetComponent<Text>().color = tmp;
        }
        if (who == "enemy" || who == "item" || who == "burn" || who == "poison")
        {
            Color tmp = EnemyDMG.GetComponent<Text>().color;
            tmp.a = x;
            EnemyDMG.GetComponent<Text>().color = tmp;
        }
    }

    public float getY(string who)
    {
        
        if (who == "hero")
        {
            return HeroDMG.transform.position.y;
        }
        if (who == "enemy" || who == "item" || who == "burn" || who == "poison")
        {
            return EnemyDMG.transform.position.y;
        }
        return 0;
    }

    public float getX()
    {
        return HeroDMG.transform.position.x;
    }

    public void setY(string who, float newY, float x)
    {
        if (who == "hero")
        {
            Vector3 movePosition = new Vector3(x, newY, 0);
            HeroDMG.transform.position = movePosition;
        }
        if (who == "enemy" || who == "item" || who == "burn" || who == "poison")
        {
            Vector3 movePosition = new Vector3(x, newY, 0);
            EnemyDMG.transform.position = movePosition;
        }
    }

}
