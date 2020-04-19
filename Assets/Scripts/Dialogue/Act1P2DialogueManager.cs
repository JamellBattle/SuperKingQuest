using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P2DialogueManager : DialogueManager
{

    public Sprite CocoBox;
    public Sprite KingBox;
    public Sprite NPCBox;
    SpriteRenderer CocoSprite;
    //Animator CocoAnim;
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
    //Animator SveriAnim;
    SpriteRenderer SveriSprite;
    public Sprite SMad;
    public Sprite SAngry;
    //Animator PaulAnim;
    SpriteRenderer PaulSprite;
    public Sprite PReg;
    public Sprite PHappy;
    public Sprite PMad;
    public Sprite PSad;
    //Animator KhanAnim;
    SpriteRenderer KhanSprite;
    public Sprite KhReg;
    public Sprite KhPout;
    public Sprite KhMad;
    public Sprite KhSad;
    GameObject King;
    GameObject Coco;
    GameObject Sveri;
    GameObject Paul;
    GameObject Khan;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        King = controller.King;
        Coco = controller.Coco;
        Sveri = controller.Sveri;
        Paul = controller.Paul;
        Khan = controller.Khan;
        KingSprite = King.GetComponent<SpriteRenderer>();
        CocoSprite = Coco.GetComponent<SpriteRenderer>();
        SveriSprite = Sveri.GetComponent<SpriteRenderer>();
        PaulSprite = Paul.GetComponent<SpriteRenderer>();
        KhanSprite = Khan.GetComponent<SpriteRenderer>();
        SetBox(NPCBox);



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

        if (sentences.Count == 38)
        {
            SetBox(CocoBox);
            SetName("Coco");
        }

        if (sentences.Count == 37)
        {
            clickingAllowed = false;
            StartCoroutine(KhanAppears());
        }

        if (sentences.Count == 35)
        {
            changeEmotion(KhanSprite, KhPout);
        }

        if (sentences.Count == 34)
        {
            changeEmotion(PaulSprite, PHappy);
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
    public IEnumerator KhanAppears()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        changeEmotion(KhanSprite, KhSad);
        yield return new WaitForSeconds(1f);
        controller.ShowKhan();
        SetBox(NPCBox);
        SetName("???");
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
