using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDisplay : MonoBehaviour
{
    public Text Display;

    public void move(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(0, transform.position.y + speed, 90f);
        transform.position = movePosition;
    }

    public void setDisplay(string display)
    {
        Display.text = display;
    }
    public float getY()
    {
        return this.transform.position.y;
    }
}
