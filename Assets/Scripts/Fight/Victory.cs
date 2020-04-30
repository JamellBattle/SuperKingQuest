using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Text buttonText;
    public void move(float speed, float y)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + (speed * Time.deltaTime), y, 0);
        transform.position = movePosition;
    }
    public float getX()
    {
        return this.transform.position.x;
    }

    public void setX(float newX, float y)
    {
        Vector3 movePosition = new Vector3(newX, y, 0);
        transform.position = movePosition;
    }

    public void setOpacity(float x)
    {
        Image image = this.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = x;
        image.color = tempColor;
        buttonText.color = tempColor;
    }
}