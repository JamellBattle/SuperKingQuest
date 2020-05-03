using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<EndingDialogueManager>().StartDialogue(dialogue);
    }
}
