using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class move : MonoBehaviour
{
    public string moveName = "";
    public int damage = 0;
    public TextMeshProUGUI displayName;

    void Start()
    {
        displayName.text = moveName;
    }
}
