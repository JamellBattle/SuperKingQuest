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
    public Sprite KAngry;
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

        if (sentences.Count == 89)
        {
            KingSprite.sprite = KShock;
        }

        if (sentences.Count == 88)
        {
            KingSprite.sprite = KMad;
        }

        if (sentences.Count == 86)
        {
            KingSprite.sprite = KAngry;
        }


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