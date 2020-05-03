using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialogueManager : DialogueManager
{


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
        

    }

    public override void Update()
    {
        base.Update();
    }

    public override void StartDialogue(Dialogue dialogue)
    {
        thoughtAnim.SetBool("Thinking", true);
        mainText = thoughtText;
        base.StartDialogue(dialogue);
        
    }

    public override void DisplayNextSentence()
    {
        base.DisplayNextSentence();

        if (sentences.Count == 5)
        {
            controller.ShowEnemy();
        }

        if (sentences.Count == 4)
        {
            controller.HideEnemy();
            controller.ShowEnemy2();
        }

        if (sentences.Count == 3)
        {
            controller.ShowCoco();
            controller.ShowEnemy3();
        }

        if (sentences.Count == 2)
        {
            controller.HideCoco();
            controller.HideEnemy3();
            controller.HideEnemy2();
        }

        if (sentences.Count == 0)
        {
            controller.ShowSpecial();
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



    
}
