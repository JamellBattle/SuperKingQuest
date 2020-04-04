using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP3DialogueManager : DialogueManager
{

    
    public Sprite CocoBox;
    public Sprite KingBox;
    public SpriteRenderer CocoSprite;
    public Animator CocoAnim;
    public Sprite CSmile;
    public Sprite CReg;
    public Sprite CSad;
    public Sprite CMad;
    public SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KAngry;
    public Sprite KMad;
    public Sprite KShock;
    GameObject King;
    GameObject Coco;
    
    


    public override void Start()
    {
        base.Start();
        King = controller.King;
        Coco = controller.Coco;
        
        

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

        if (sentences.Count == 85)
        {
            clickingAllowed = false;
            StartCoroutine(Smack());
        }

        if (sentences.Count == 84)
        {
            clickingAllowed = false;
            StartCoroutine(CocoReveal());
        }

        if (sentences.Count == 83)
        {
            clickingAllowed = false;
            StartCoroutine(CocotoKing());
        }

        if (sentences.Count == 82)
        {
            clickingAllowed = false;
            StartCoroutine(KingtoCoco());
        }

        if (sentences.Count == 81)
        {
            clickingAllowed = false;
            StartCoroutine(CocotoKing());
        }

        if (sentences.Count == 80)
        {
            clickingAllowed = false;
            CocoSprite.sprite = CReg;
            StartCoroutine(KingtoCoco());
        }

        if (sentences.Count == 79)
        {
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;
            
        }

        if (sentences.Count == 74)
        {
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            mainText = dialogueText;

        }

        if (sentences.Count == 73)
        {
            
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;
        }

        if (sentences.Count == 70)
        {
            
            clickingAllowed = false;
            StartCoroutine(CocotoKing());

            thoughtAnim.SetBool("Thinking", false);
           
            
        }

        if (sentences.Count == 69)
        {

            clickingAllowed = false;
            StartCoroutine(KingtoCoco());
            
        }

        if (sentences.Count == 68)
        {

            clickingAllowed = false;
            KingSprite.sprite = KMad;
            StartCoroutine(CocotoKing());

        }

        if (sentences.Count == 67)
        {

            clickingAllowed = false;
            CocoSprite.sprite = CSmile;
            StartCoroutine(KingtoCoco());

        }


        if (sentences.Count == 66)
        {

            clickingAllowed = false;
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(TransitionToCampfire());

        }

        if (sentences.Count == 65)
        {

            SetName("King");
            textbox.sprite = KingBox;

        }

        if (sentences.Count == 64)
        {

            SetName("???");
            textbox.sprite = CocoBox;

        }

        if (sentences.Count == 63)
        {
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;


        }

        if (sentences.Count == 57)
        {
            SetBox(CocoBox);
            SetName("???");
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            mainText = dialogueText;


        }

        if (sentences.Count == 56)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KShock;
            mainText = dialogueText;


        }

        if (sentences.Count == 55)
        {
            SetBox(CocoBox);
            SetName("???");
            CocoSprite.sprite = CSmile;
    
        }

        if (sentences.Count == 54)
        {
            
            CocoSprite.sprite = CReg;

        }

        if (sentences.Count == 53)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KMad;

        }

        if (sentences.Count == 52)
        {
            SetBox(CocoBox);
            SetName("???");
            CocoSprite.sprite = CMad;

        }

        if (sentences.Count == 51)
        {
            SetBox(KingBox);
            SetName("King");
            

        }

        if (sentences.Count == 50)
        {
            SetBox(CocoBox);
            SetName("???");
            

        }

        if (sentences.Count == 49)
        {
            SetBox(KingBox);
            SetName("King");


        }

        if (sentences.Count == 48)
        {
            SetBox(CocoBox);
            SetName("???");


        }

        if (sentences.Count == 47)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KShock;

        }

        if (sentences.Count == 46)
        {
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;


        }

        if (sentences.Count == 42)
        { 
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            mainText = dialogueText;
            KingSprite.sprite = KMad;


        }

        if (sentences.Count == 41)
        {
            SetBox(CocoBox);
            SetName("Coco");
            CocoSprite.sprite = CReg;


        }

        if (sentences.Count == 40)
        {
            SetBox(KingBox);
            SetName("King");


        }

        if (sentences.Count == 39)
        {
            
            SetBox(CocoBox);
            SetName("Coco");


        }

        if (sentences.Count == 37)
        {
            KingSprite.sprite = KReg;
            SetBox(KingBox);
            SetName("King");


        }

        if (sentences.Count == 35)
        {
            CocoSprite.sprite = CSad;
            SetBox(CocoBox);
            SetName("Coco");


        }

        if (sentences.Count == 34)
        {
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;


        }

        if (sentences.Count == 31)
        {
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            mainText = dialogueText;
            CocoSprite.sprite = CReg;


        }

        if (sentences.Count == 30)
        {
            SetBox(KingBox);
            SetName("King");


        }

        if (sentences.Count == 29)
        {
            SetBox(CocoBox);
            SetName("Coco");


        }

        if (sentences.Count == 28)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KShock;


        }

        if (sentences.Count == 27)
        {
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            mainText = thoughtText;


        }

        if (sentences.Count == 22)
        {
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            mainText = dialogueText;
            KingSprite.sprite = KMad;


        }

        if (sentences.Count == 21)
        {
            SetBox(CocoBox);
            SetName("Coco");
            CocoSprite.sprite = CSad;


        }

        if (sentences.Count == 20)
        {
            SetBox(KingBox);
            SetName("King");


        }

        if (sentences.Count == 19)
        {
            SetBox(CocoBox);
            SetName("Coco");


        }

        if (sentences.Count == 18)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KShock;

        }

        if (sentences.Count == 17)
        {
            SetBox(CocoBox);
            SetName("Coco");


        }

        if (sentences.Count == 16)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KAngry;

        }

        if (sentences.Count == 15)
        {
            SetBox(CocoBox);
            SetName("Coco");
            CocoSprite.sprite = CSmile;

        }

        if (sentences.Count == 14)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KMad;

        }

        if (sentences.Count == 13)
        {
            SetBox(CocoBox);
            SetName("Coco");
            CocoSprite.sprite = CReg;

        }

        if (sentences.Count == 12)
        {
            SetBox(KingBox);
            SetName("King");
            

        }

        if (sentences.Count == 11)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KShock;

        }

        if (sentences.Count == 10)
        {
            SetBox(CocoBox);
            SetName("Coco");
            

        }

        if (sentences.Count == 9)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
            


        }

        if (sentences.Count == 8)
        {
            mainText = dialogueText;
            SetBox(KingBox);
            SetName("King");
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            


        }

        if (sentences.Count == 7)
        {
            SetBox(CocoBox);
            SetName("Coco");


        }

        if (sentences.Count == 6)
        {
            SetBox(KingBox);
            SetName("King");
            KingSprite.sprite = KReg;

        }

        if (sentences.Count == 5)
        {
            clickingAllowed = false;
            textAnim.SetBool("IsOpen", false);
            mainText = thoughtText;
            StartCoroutine(SkyTransition());
            

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

    //Additonal Coroutines Exclusive to this Dialogue Manager
    public IEnumerator KingtoCoco()
    {
        if (mainText == thoughtText)
        {
            mainText = dialogueText;
        }

        textAnim.SetBool("IsOpen", false);
        controller.HideKing();
        yield return new WaitForSeconds(0.5f);
        controller.ShowCoco();
        textbox.sprite = CocoBox;
        if (sentences.Count > 40)
        {
            SetName("???");
        }
        else
        {
            SetName("Coco");
        }
        
        yield return new WaitForSeconds(0.2f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator CocotoKing()
    {
        if (mainText == thoughtText)
        {
            mainText = dialogueText;
        }
        
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        yield return new WaitForSeconds(0.5f);
        controller.ShowKing();
        textbox.sprite = KingBox;
        SetName("King");
        yield return new WaitForSeconds(0.2f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator Smack()
    {

        textAnim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(1f);
        KingSprite.sprite = KShock;
        yield return new WaitForSeconds(0.5f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator CocoReveal()
    {

        textAnim.SetBool("IsOpen", false);
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        CocoAnim.SetBool("Present", true);
        yield return new WaitForSeconds(1f);
        textbox.sprite = CocoBox;
        SetName("???");
        controller.CocoAnim.speed = 0.1f;
        controller.CocoAnim.SetBool("Present", true);
        yield return new WaitForSeconds(3f);
        controller.CocoAnim.speed = 1f;
        CocoAnim.SetBool("Present", false);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator TransitionToCampfire()
    {
        controller.WipeStart();
        yield return new WaitForSeconds(1f);
        controller.HideCoco();
        CocoSprite.sprite = CReg;
        Vector3 newpos = new Vector3(-4.18f, -0.47f, 0);
        King.transform.position = newpos;
        Vector3 newpos2 = new Vector3(4.18f, -0.47f, 0);
        Coco.transform.position = newpos2;
        yield return null;
        controller.WipeEnd();
        yield return new WaitForSeconds(1f);
        controller.ShowCoco();
        controller.ShowKing();
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;


    }

    public IEnumerator SkyTransition()
    {
        controller.HideKing();
        controller.HideCoco();
        controller.SkyFade();
        yield return new WaitForSeconds(3f);
        thoughtAnim.SetBool("Thinking", true);
        clickingAllowed = true;

    }



}