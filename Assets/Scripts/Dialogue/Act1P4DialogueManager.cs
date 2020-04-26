using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P4DialogueManager : DialogueManager
{

    public Sprite CocoBox;
    public Sprite KingBox;
    public Sprite EnemyBox;
    SpriteRenderer CocoSprite;
    public Sprite CSmile;
    public Sprite CReg;
    public Sprite CSad;
    public Sprite CMad;
    public Sprite CSmug;
    SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KAngry;
    public Sprite KMad;
    public Sprite KShock;
    public Sprite KSurprise;
    GameObject King;
    GameObject Coco;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        King = controller.King;
        Coco = controller.Coco;
        KingSprite = King.GetComponent<SpriteRenderer>();
        CocoSprite = Coco.GetComponent<SpriteRenderer>();

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

        if (sentences.Count == 45)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 44)
        {
            changeEmotion(KingSprite, KSurprise);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 43)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 42)
        {
            
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 41)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 40)
        {
            changeEmotion(KingSprite, KMad);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 39)
        {
            mainText = thoughtText;
            clickingAllowed = false;
            StartCoroutine(MovingCloser());
        }

        if (sentences.Count == 36)
        {
            mainText = dialogueText;
            SetName("Coco");
            SetBox(CocoBox);
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
            controller.ShowCoco();
            controller.ShowKing();
            
        }

        if (sentences.Count == 35)
        {
            
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 34)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 33)
        {
            mainText = thoughtText;
            clickingAllowed = false;
            StartCoroutine(SneakTime());
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
    public IEnumerator SneakTime()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        changeEmotion(CocoSprite, CSad);
        controller.ShowCoco();
        controller.ShowSveri();
        
        SetName("???");
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator MovingCloser()
    {
        textAnim.SetBool("IsOpen", false);
        controller.WipeStart();
        yield return new WaitForSeconds(1f);
        controller.HideKing();
        controller.HideCoco();
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
