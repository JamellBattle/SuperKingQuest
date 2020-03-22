using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP2DialogueTrigger : DialogueTrigger
{
    public override void TriggerDialogue()
    {
        FindObjectOfType<PP2DialogueManager>().StartDialogue(dialogue);
    }
}
