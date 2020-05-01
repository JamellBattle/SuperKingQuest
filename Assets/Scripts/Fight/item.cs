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

    /* Adding New Items:
     * 
     * 
     * 
     * Format: 
     * if (itemName == "<Name of Item>")
     * {
     *     return "<Effect Type> <Effect Number or STATUS Type>";
     * }
     * 
     * 
     * 
     * Effect Types: HP, SP, and STATUS
     * STATUS Types: OK, Burn, Poison, Curse, and Silence
     */

    public string itemEffect()
    {

        if (itemName == "Quetzy's Snack Pack")
        {
            return "HP 10";
        }
        if (itemName == "Quetzy's Meal Pack")
        {
            return "HP 20";
        }
        if (itemName == "SUS Fragment")
        {
            return "SP 5";
        }
        if (itemName == "Ooma Antidote")
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
