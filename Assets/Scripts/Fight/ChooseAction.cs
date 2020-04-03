using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAction : MonoBehaviour
{

    void Start()
    {
    }
    void Update()
    {
    }

    public void move(float speed)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(0.1160625f, transform.position.y + speed, 174.1797f);
        transform.position = movePosition;
    }
    public float getY()
    {
        return this.transform.position.y;
    }
}
