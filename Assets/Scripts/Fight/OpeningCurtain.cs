using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCurtain : MonoBehaviour
{
    public void move(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(0, transform.position.y + (speed * Time.deltaTime), 0);
        transform.position = movePosition;
    }
    public float getY()
    {
        return this.transform.position.y;
    }
    public void setOpacity(float x)
    {
        Color tmp = this.GetComponent<SpriteRenderer>().color;
        tmp.a = x;
        this.GetComponent<SpriteRenderer>().color = tmp;
    }
}
