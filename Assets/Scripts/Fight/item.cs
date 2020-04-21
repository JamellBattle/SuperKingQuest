using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public string itemName = "";
    void Start()
    {
        itemText.text = itemName;
    }

    void Update()
    {
        itemText.text = itemName;
    }
    public string getItem()
    {
        return itemName;
    }

    public string itemEffect()
    {
        if (itemName == "Soda")
        {
            return "HP 10";
        }
        if (itemName == "Large Soda")
        {
            return "HP 20";
        }
        if (itemName == "Honey Jar")
        {
            return "SP 5";
        }
        if (itemName == "Medicine")
        {
            return "STATUS OK";
        }
        return "";
    }

    public void setItem(string newItem)
    {
        itemName = newItem;
        itemText.text = itemName;
    }
}
