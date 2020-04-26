using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public Text turn;
    int turnNum = 1;

    public void nextTurn()
    {
        turnNum++;
        turn.text = turnNum.ToString();
    }
}
