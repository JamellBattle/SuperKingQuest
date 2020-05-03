using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    LevelLoader loadlevel;
    public GameObject mainPage;
    public GameObject creditsPage;
    // Start is called before the first frame update
    void Start()
    {
        loadlevel = (LevelLoader)FindObjectOfType(typeof(LevelLoader));
    }

    
    public void StartGame()
    {
        if (loadlevel)
        {
            loadlevel.LoadNextLevel("ProloguePt1");
        }
    }

    public void ShowCredits()
    {
        creditsPage.SetActive(true);
        mainPage.SetActive(false);
    }

    public void ShowMain()
    {
        mainPage.SetActive(true);
        creditsPage.SetActive(false);
        
    }


}
