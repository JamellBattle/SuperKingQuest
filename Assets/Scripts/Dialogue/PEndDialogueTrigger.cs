using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEndDialogueTrigger : DialogueTrigger
{
    
    public override void TriggerDialogue()
    {
        FindObjectOfType<PEndDialogueManager>().StartDialogue(dialogue);
    }
}
