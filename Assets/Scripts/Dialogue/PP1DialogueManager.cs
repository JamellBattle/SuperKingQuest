using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP1DialogueManager : DialogueManager
{


    public Sprite strangerTextSprite;
    public Animator windAnim;
    public AudioSource windSFX;
    public AudioSource footsteps;
    bool kingLeft = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        windAnim.SetTrigger("FadeIn");
        

    }

    public override void Update()
    {
        base.Update();
    }

    public override void StartDialogue(Dialogue dialogue)
    {
        textAnim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        windAnim.SetTrigger("FadeOut");
        base.StartDialogue(dialogue);
        
    }

    public override void DisplayNextSentence()
    {
        base.DisplayNextSentence();

        if (sentences.Count == 7)
        {
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;
        }


        if (sentences.Count == 0)
        {
            
            textbox.sprite = strangerTextSprite;
            mainText = dialogueText;
            nameText.text = "???";
            thoughtAnim.SetBool("Thinking", false);
            StartCoroutine(KingLeaving(3f));
            clickingAllowed = false;
            
        }
    }

   
    public override IEnumerator TypeSentence(string sentence)
    {
        return base.TypeSentence(sentence);

        
    }

    public override void EndDialogue()
    {
        base.EndDialogue();

    }


    //Additional Coroutines exclusive to this Dialogue manager
    public IEnumerator KingLeaving(float wait)
    {
        if (kingLeft == false)
        {
            footsteps.Play();
        }
        
        controller.KingAnim.speed = 0.1f;
        controller.HideKing();
        yield return new WaitForSeconds(wait);
        kingLeft = true;
        StartCoroutine(StrangerAppears(0.5f));

    }

    public IEnumerator StrangerAppears(float wait)
    {
        controller.ShowCoco();
        yield return new WaitForSeconds(wait);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    
}
