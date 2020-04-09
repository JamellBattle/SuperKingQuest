using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP3DialogueTrigger : DialogueTrigger
{
    public override void TriggerDialogue()
    {
        FindObjectOfType<PP3DialogueManager>().StartDialogue(dialogue);
    }
}
