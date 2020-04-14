using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveX(float speedx)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(transform.position.x + speedx, 0, -10);
        transform.position = movePosition;
    }

    public void moveY(float speedy)
    {
        //Debug.Log("COCK");
        Vector3 movePosition = new Vector3(0, transform.position.y + speedy, -10);
        transform.position = movePosition;
    }

    public float getX()
    {
        return this.transform.position.x;
    }

    public void setX(float x)
    {
        Vector3 movePosition = new Vector3(x, 0, -10);
        transform.position = movePosition;
    }

    public float getY()
    {
        return this.transform.position.y;
    }

    public void setY(float y)
    {
        Vector3 movePosition = new Vector3(0, y, -10);
        transform.position = movePosition;
    }
}
