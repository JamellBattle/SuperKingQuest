using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P2DialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<Act1P2DialogueManager>().StartDialogue(dialogue);
    }
}
