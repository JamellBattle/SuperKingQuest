using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P5DialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<Act1P5DialogueManager>().StartDialogue(dialogue);
    }
}
