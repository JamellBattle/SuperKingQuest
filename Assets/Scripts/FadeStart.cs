using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeStart : MonoBehaviour
{
    AnimationController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = (AnimationController)FindObjectOfType(typeof(AnimationController));
    }

    // Update is called once per frame
    public void FadeIn()
    {
        if (controller)
        {
            if (SceneManager.GetActiveScene().name == "ProloguePt1")
            {
                controller.StartCoroutine(controller.FadeKing(0.5f));
            }
        }
    }
}
