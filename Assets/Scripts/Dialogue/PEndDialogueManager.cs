using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEndDialogueManager : DialogueManager
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
    public GameObject BigCoco;
    public Animator BigCocoAnim;
    GameObject King;
    GameObject Coco;
    public GameObject Trees;
    public GameObject morningWoods;
    public GameObject noonWoods;
    public Animator birdAnim;
    public AudioSource birdSFX;
    public Animator spookAnim;
    public AudioSource spookSFX;
    public AudioSource cocoBGM;
    public Animator cocoBGMAnim;
    public AudioSource cocoBGM2;


    // Start is called before the first frame update
    public override void Start()
    {
        
        base.Start();
        King = controller.King;
        Coco = controller.Coco;
        StartCoroutine(BirdsFade());


    }

    public override void Update()
    {
        base.Update();
    }

    public override void StartDialogue(Dialogue dialogue)
    {
        thoughtAnim.SetBool("Thinking", true);
        mainText = thoughtText;
        base.StartDialogue(dialogue);
    }

    public override void DisplayNextSentence()
    {
        base.DisplayNextSentence();

        if (sentences.Count == 38)
        {
            clickingAllowed = false;
            mainText = dialogueText;
            thoughtAnim.SetBool("Thinking", false);
            StartCoroutine(BigCocoAppears());
        }

        if (sentences.Count == 37)
        {
            clickingAllowed = false;
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(TransitionToCamp());
        }

        if (sentences.Count == 36)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 35)
        {
            SetName("Coco");
            SetBox(CocoBox);
            changeEmotion(CocoSprite, CSad);
        }

        if (sentences.Count == 34)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 33)
        {
            SetName("Coco");
            SetBox(CocoBox);
            changeEmotion(CocoSprite, CSmile);
        }

        if (sentences.Count == 32)
        {
            SetName("King");
            SetBox(KingBox);
            changeEmotion(KingSprite, KMad);
        }

        if (sentences.Count == 31)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
        }

        if (sentences.Count == 27)
        {
            mainText = dialogueText;
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
        }

        if (sentences.Count == 26)
        {
            SetName("Coco");
            SetBox(CocoBox);
            changeEmotion(CocoSprite, CReg);
        }

        if (sentences.Count == 25)
        {
            clickingAllowed = false;
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(TransitionToWoods());
        }

        if (sentences.Count == 19)
        {
            
            changeEmotion(KingSprite, KMad);
            mainText = dialogueText;
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
            
        }

        if (sentences.Count == 18)
        {
            SetName("???");
            SetBox(NPCBox);

        }

        if (sentences.Count == 17)
        {
            clickingAllowed = false;
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(CocoReturns());
                       
        }

        if (sentences.Count == 15)
        {            
            SetName("Coco");
            SetBox(CocoBox);            
        }

        if (sentences.Count == 14)
        {
            SetName("King");
            SetBox(KingBox);           
        }

        if (sentences.Count == 13)
        {
            SetName("Coco");
            SetBox(CocoBox);

        }

        if (sentences.Count == 12)
        {
            mainText = thoughtText;
            thoughtAnim.SetBool("Thinking", true);
            textAnim.SetBool("IsOpen", false);
        }

        if (sentences.Count == 9)
        {
            mainText = dialogueText;
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
        }

        if (sentences.Count == 8)
        {
            SetName("King");
            SetBox(KingBox);
            changeEmotion(KingSprite, KReg);
        }

        if (sentences.Count == 7)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 6)
        {
            mainText = thoughtText;
            thoughtAnim.SetBool("Thinking", true);
            textAnim.SetBool("IsOpen", false);
        }

        if (sentences.Count == 3)
        {
            mainText = dialogueText;
            SetName("King");
            SetBox(KingBox);
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
        }

        if (sentences.Count == 2)
        {
            SetName("Coco");
            SetBox(CocoBox);
            changeEmotion(CocoSprite, CSmug);
        }

        if (sentences.Count == 1)
        {
            SetName("King");
            SetBox(KingBox);
            changeEmotion(KingSprite, KMad);
        }

        if (sentences.Count == 0)
        {
            SetName("Coco");
            SetBox(CocoBox);
            changeEmotion(CocoSprite, CSmile);
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
    public IEnumerator BirdsFade()
    {
        yield return new WaitForSeconds(1f);
        birdAnim.SetTrigger("FadeOut");
    }
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

    public IEnumerator BigCocoAppears()
    {
        
        yield return new WaitForSeconds(1f);
        spookSFX.Play();
        spookAnim.speed = 1.5f;
        spookAnim.SetTrigger("FadeOut");
        BigCocoAnim.speed = 0.2f;
        BigCocoAnim.SetBool("Present", true);
        yield return new WaitForSeconds(1.5f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator TransitionToCamp()
    {
        controller.WipeStart();
        yield return new WaitForSeconds(1f);
        BigCoco.gameObject.SetActive(false);       
        changeEmotion(CocoSprite, CSmile);
        changeEmotion(KingSprite, KShock);
        Vector3 newpos = new Vector3(-4.18f, -0.47f, 0);
        King.transform.position = newpos;
        Vector3 newpos2 = new Vector3(4.18f, -0.47f, 0);
        Coco.transform.position = newpos2;
        Trees.gameObject.SetActive(false);
        SetBox(CocoBox);
        SetName("Coco");
        yield return null;
        controller.WipeEnd();
        yield return new WaitForSeconds(1f);
        controller.ShowCoco();
        controller.ShowKing();
        yield return new WaitForSeconds(1f);
        cocoBGM.Play();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;


    }

    public IEnumerator TransitionToWoods()
    {
        cocoBGMAnim.speed = 2.5f;
        cocoBGMAnim.SetTrigger("FadeOut");
        controller.WipeStart();
        yield return new WaitForSeconds(1f);
        controller.HideKing();
        controller.HideCoco();
        changeEmotion(CocoSprite, CSmile);
        changeEmotion(KingSprite, KReg);
        Vector3 newpos = new Vector3(0, -0.47f, 0);
        King.transform.position = newpos;
        Vector3 newpos2 = new Vector3(4.18f, -0.47f, 0);
        Coco.transform.position = newpos2;
        morningWoods.gameObject.SetActive(false);
        SetBox(KingBox);
        SetName("King");
        yield return null;
        controller.WipeEnd();
        yield return new WaitForSeconds(1f);
        controller.ShowKing();
        yield return new WaitForSeconds(1f);
        thoughtAnim.SetBool("Thinking", true);
        clickingAllowed = true;


    }

    public IEnumerator CocoReturns()
    {
        controller.HideKing();
        changeEmotion(CocoSprite, CReg);
        yield return new WaitForSeconds(1f);
        Vector3 newpos = new Vector3(-4.18f, -0.47f, 0);
        King.transform.position = newpos;
        SetName("King");
        SetBox(KingBox);
        controller.ShowKing();
        controller.ShowCoco();
        changeEmotion(KingSprite, KShock);
        yield return new WaitForSeconds(1f);
        cocoBGM2.Play();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }



}
