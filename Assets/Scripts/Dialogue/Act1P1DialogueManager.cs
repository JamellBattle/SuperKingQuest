using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P1DialogueManager : DialogueManager
{

    public Sprite CocoBox;
    public Sprite KingBox;
    public Sprite NPCBox;
    public SpriteRenderer CocoSprite;
    public Animator CocoAnim;
    public Sprite CSmile;
    public Sprite CReg;
    public Sprite CSad;
    public Sprite CMad;
    public Sprite CSmug;
    public SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KAngry;
    public Sprite KMad;
    public Sprite KShock;
    public Sprite KSurprise;
    public GameObject Sveri;
    public Animator SveriAnim;
    public SpriteRenderer SveriSprite;
    public Sprite SHappy;
    public Sprite SSmile;
    GameObject King;
    GameObject Coco;

    // Start is called before the first frame update
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
        textAnim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        base.StartDialogue(dialogue);
    }

    public override void DisplayNextSentence()
    {
        base.DisplayNextSentence();

        if (sentences.Count == 34)
        {
            SetBox(CocoBox);
            SetName("Coco");
        }

        if (sentences.Count == 33)
        {
            SetBox(KingBox);
            SetName("King");
        }

        if (sentences.Count == 32)
        {
            SetBox(CocoBox);
            SetName("Coco");
        }

        if (sentences.Count == 31)
        {
            SetBox(KingBox);
            SetName("King");
            changeEmotion(KingSprite, KShock);
            
        }

        if (sentences.Count == 30)
        {
            
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
        }

        if (sentences.Count == 27)
        {
            clickingAllowed = false;
            mainText = dialogueText;
            thoughtAnim.SetBool("Thinking", false);
            StartCoroutine(SveriAppears());
            
        }

        if (sentences.Count == 26)
        {
            SetBox(KingBox);
            SetName("King");
            changeEmotion(KingSprite, KMad);

        }

        if (sentences.Count == 25)
        {
            SetBox(CocoBox);
            SetName("Coco");
            changeEmotion(CocoSprite, CSmile);

        }

        if (sentences.Count == 24)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);

        }

        if (sentences.Count == 21)
        {
            mainText = dialogueText;
            SetName("???");
            SetBox(NPCBox);
            changeEmotion(SveriSprite, SSmile);
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);

        }

        if (sentences.Count == 20)
        {
            SetName("Coco");
            SetBox(CocoBox);

        }

        if (sentences.Count == 19)
        {
            SetName("???");
            SetBox(NPCBox);

        }

        if (sentences.Count == 18)
        {
            SetName("King");
            SetBox(KingBox);

        }

        if (sentences.Count == 17)
        {
            SetName("Coco");
            SetBox(CocoBox);

        }

        if (sentences.Count == 16)
        {

            clickingAllowed = false;
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(TransitionToTour());
        }

        if (sentences.Count == 14)
        {
            mainText = dialogueText;
            SetName("???");
            SetBox(NPCBox);
            changeEmotion(SveriSprite, SHappy);
            controller.ShowKing();
            controller.ShowSveri();
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);

        }

        if (sentences.Count == 13)
        {
            SetName("King");
            SetBox(KingBox);

        }

        if (sentences.Count == 12)
        {
            mainText = thoughtText;
            controller.HideKing();
            controller.HideSveri();
            thoughtAnim.SetBool("Thinking", true);
            textAnim.SetBool("IsOpen", false);

        }

        if (sentences.Count == 9)
        {
            mainText = dialogueText;
            SetName("???");
            SetBox(NPCBox);
            changeEmotion(SveriSprite, SHappy);
            controller.ShowKing();
            controller.ShowSveri();
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);

        }

        if (sentences.Count == 8)
        {
            SetName("King");
            SetBox(KingBox);

        }

        if (sentences.Count == 7)
        {
            changeEmotion(SveriSprite, SSmile);
            SetName("Sveri");
            SetBox(NPCBox);

        }

        if (sentences.Count == 6)
        {
            clickingAllowed = false;
            StartCoroutine(ByeSveri());

        }

        if (sentences.Count == 5)
        {           

            changeEmotion(KingSprite, KShock);
            
        }

        if (sentences.Count == 4)
        {
            mainText = thoughtText;
            thoughtAnim.SetBool("Thinking", true);
            textAnim.SetBool("IsOpen", false);

        }

        if (sentences.Count == 1)
        {
            mainText = dialogueText;
            SetName("King");
            SetBox(KingBox);
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
        }

        if (sentences.Count == 0)
        {           
            changeEmotion(KingSprite, KMad);           
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


    //Additional Coroutines exclusive to this Dialogue manager
    public IEnumerator SveriAppears()
    {

        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        changeEmotion(CocoSprite, CSad);
        Vector3 newpos2 = new Vector3(-2.83f, -0.47f, 0.04f);
        Coco.transform.position = newpos2;
        controller.ShowCoco();
        controller.ShowSveri();
        SetBox(NPCBox);
        SetName("???");
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator TransitionToTour()
    {
        controller.WipeStart();
        yield return new WaitForSeconds(1f);
        controller.HideKing();
        controller.HideCoco();
        controller.HideSveri();
        yield return null;
        controller.WipeEnd();                
        yield return new WaitForSeconds(2f);
        thoughtAnim.SetBool("Thinking", true);
        clickingAllowed = true;
    }

    public IEnumerator ByeSveri()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideSveri();
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        Vector3 newpos = new Vector3(0.21f, -0.47f, 0);
        King.transform.position = newpos;
        controller.ShowKing();
        SetName("King");
        SetBox(KingBox);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }
    
}
