using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P1DialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<Act1P1DialogueManager>().StartDialogue(dialogue);
    }
}
