using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class move : MonoBehaviour
{
    public string moveName = "";
    public int damage = 0;
    public int cost = 0;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayCost;

    void Start()
    {
        displayName.text = moveName;
        displayCost.text = "(" + cost.ToString() + " HP)";
    }

    void Update()
    {
        displayName.text = moveName;
        displayCost.text = "(" + cost.ToString() + " HP)";
    }
}
