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

    public float transitionTime = 1f;

    void Start() {
        controller = (AnimationController)FindObjectOfType(typeof(AnimationController));
        StartCoroutine(firstFade(2f));
    }

    IEnumerator firstFade(float time) {

        Debug.Log("FirstFade Activated");

        if (firstCharacter) {
            Debug.Log("FirstFade now waiting");
            yield return new WaitForSeconds(time);
            Debug.Log("FirstFade done waiting");


            controller.StartCoroutine(controller.FirstFade(0.5f));
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
        transition.SetTrigger("Start");

        if (musicAnim) {
            musicAnim.SetTrigger("FadeOut");
        }
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);

    }

    
}
