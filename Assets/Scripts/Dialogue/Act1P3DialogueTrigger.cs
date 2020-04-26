using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P3DialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<Act1P3DialogueManager>().StartDialogue(dialogue);
    }
}
