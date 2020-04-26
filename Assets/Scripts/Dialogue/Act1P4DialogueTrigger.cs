using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P4DialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<Act1P4DialogueManager>().StartDialogue(dialogue);
    }
}
