using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public void move(float speed, float y)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + speed, y, 0);
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
}