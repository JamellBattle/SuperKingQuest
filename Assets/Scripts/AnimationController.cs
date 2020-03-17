using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator Fade;
    public Animator King;
    public DialogueTrigger dialoguetrigger;
    //public Animator Stranger;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FadeKing(1f));

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public IEnumerator FadeKing(float wait)
    {

        ShowKing();
        yield return new WaitForSeconds(wait);
        BeginDialogue();
    }

    public void ShowKing()
    {
        King.SetBool("KingPresent", true);
    }

    public void BeginDialogue()
    {
        dialoguetrigger.TriggerDialogue();
    }

}
