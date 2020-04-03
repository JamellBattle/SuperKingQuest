using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAction2: MonoBehaviour
{

    public ChooseAction c;
    public void Start()
    {
        c = gameObject.GetComponent<ChooseAction>();
    }
    void Update()
    {
    }

    public void fight()
    {
        Debug.Log("why");
        //Instantiate(Fight);
        //c.fight();
    }

    public void defend()
    {

    }

    public void item()
    {

    }

    public void run()
    {

    }

}
