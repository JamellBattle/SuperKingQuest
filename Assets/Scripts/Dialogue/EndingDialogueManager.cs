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
