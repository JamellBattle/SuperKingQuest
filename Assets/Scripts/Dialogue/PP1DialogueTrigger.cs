using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP1DialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<PP1DialogueManager>().StartDialogue(dialogue);
    }
}
