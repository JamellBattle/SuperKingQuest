﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class special : MonoBehaviour
{
    public string specialName = "";
    public int damage = 0;
    public int cost = 0;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayCost;

    void Start()
    {
        displayName.text = specialName;
        displayCost.text = "(" + cost.ToString() + " SP)";
    }

    void Update()
    {
        displayName.text = specialName;
        displayCost.text = "(" + cost.ToString() + " SP)";
    }
}