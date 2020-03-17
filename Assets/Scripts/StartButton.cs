using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    LevelLoader loadlevel;
    // Start is called before the first frame update
    void Start()
    {
        loadlevel = (LevelLoader)FindObjectOfType(typeof(LevelLoader));
    }

    
    public void StartGame()
    {
        if (loadlevel)
        {
            loadlevel.LoadNextLevel();
        }
    }

    
}
