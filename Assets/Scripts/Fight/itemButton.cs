using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemButton : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public string item = "";
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public string getItem()
    {
        return item;
    }

    public void setItem(string newItem)
    {
        item = newItem;
        itemText.text = item;
    }
}
