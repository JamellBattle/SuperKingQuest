using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public Animator firstCharacter;
    public Animator musicAnim;
    AnimationController controller;
    public float charAppearTime;

    public float transitionTime = 1f;

    void Start() {
        //if (musicAnim)
        //{
        //    musicAnim.SetTrigger("FadeIn");
        //}
        controller = (AnimationController)FindObjectOfType(typeof(AnimationController));
        StartCoroutine(firstFade(charAppearTime));
    }

    IEnumerator firstFade(float time) {

        if (controller)
        {
            Debug.Log("FirstFade Activated");

            if (firstCharacter)
            {
                Debug.Log("FirstFade now waiting");
                yield return new WaitForSeconds(time);
                Debug.Log("FirstFade done waiting");

            }
            else
            {
                yield return new WaitForSeconds(time);
            }

            controller.StartCoroutine(controller.FirstFade(1f));
        }

    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadNextLevel(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(string levelName)
    {
        if (SceneManager.GetActiveScene().name == "Act1Pt5" || SceneManager.GetActiveScene().name == "Ending")
        {
            transition.speed = 0.5f;
        }
        transition.SetTrigger("Start");

        if (musicAnim) {
            musicAnim.SetTrigger("FadeOut");
        }
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);

    }

    
}
