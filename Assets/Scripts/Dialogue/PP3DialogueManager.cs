using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP3DialogueManager : DialogueManager
{

    
    public Sprite CocoBox;
    public Sprite KingBox;
    public GameObject Coco;
    public SpriteRenderer CocoSprite;
    public Sprite CHappy;
    public Sprite CReg;
    public Sprite CSad;
    public SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KMad;
    public Sprite KShock;
    
    


    public override void Start()
    {
        base.Start();
        
        

    }

    public override void Update()
    {
        base.Update();
    }

    public override void StartDialogue(Dialogue dialogue)
    {
        base.StartDialogue(dialogue);
    }

    public override void DisplayNextSentence()
    {
        base.DisplayNextSentence();

        


    }

    public override IEnumerator TypeSentence(string sentence)
    {
        return base.TypeSentence(sentence);


    }

    public override void EndDialogue()
    {
        base.EndDialogue();

    }


   


}