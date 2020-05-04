using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P5DialogueManager : DialogueManager
{

    public Sprite CocoBox;
    public Sprite KingBox;
    public Sprite EnemyBox;
    public Sprite OswaldBox;
    SpriteRenderer CocoSprite;
    public Sprite CSmile;
    public Sprite CReg;
    public Sprite CSad;
    public Sprite CMad;
    public Sprite CSmug;
    public Sprite CAngry;
    SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KAngry;
    public Sprite KMad;
    public Sprite KShock;
    public Sprite KSurprise;
    SpriteRenderer OswaldSprite;
    public Sprite OHappy;
    public Sprite OReg;
    public Sprite OSmile;
    public AudioSource cloakSFX;
    public Animator enemyBgmAnim;
    public AudioSource metalSFX;
    public AudioSource victoryBGM;
    GameObject King;
    GameObject Coco;
    GameObject Oswald;
    bool dialogueOver = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        King = controller.King;
        Coco = controller.Coco;
        Oswald = controller.Oswald;
        KingSprite = King.GetComponent<SpriteRenderer>();
        CocoSprite = Coco.GetComponent<SpriteRenderer>();
        OswaldSprite = Oswald.GetComponent<SpriteRenderer>();

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

        if (sentences.Count == 28)
        {
            clickingAllowed = false;
            StartCoroutine(KingToBlack());
        }

        if (sentences.Count == 27)
        {
            clickingAllowed = false;
            StartCoroutine(BlackToKing());
        }

        if (sentences.Count == 26)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 25)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 24)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 23)
        {
            changeEmotion(KingSprite, KSurprise);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 22)
        {
            changeEmotion(CocoSprite, CReg);
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 21)
        {
            clickingAllowed = false;
            StartCoroutine(OswaldFreed());
        }

        if (sentences.Count == 20)
        {
            clickingAllowed = false;
            StartCoroutine(OswaldAppears());
        }


        if (sentences.Count == 18)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);

        }

        if (sentences.Count == 15)
        {
            clickingAllowed = false;
            mainText = dialogueText;
            thoughtAnim.SetBool("Thinking", false);
            StartCoroutine(MeetOswald());
          
        }

        if (sentences.Count == 14)
        {
            changeEmotion(OswaldSprite, OSmile);
            SetName("Oswald");
            SetBox(OswaldBox);
        }

        if (sentences.Count == 13)
        {
            clickingAllowed = false;
            StartCoroutine(CocoToKing());

        }

        if (sentences.Count == 12)
        {
            clickingAllowed = false;
            StartCoroutine(WoodsWalk());

        }

        if (sentences.Count == 11)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 10)
        {
            SetName("Oswald");
            SetBox(OswaldBox);
        }

        if (sentences.Count == 9)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 8)
        {
            changeEmotion(OswaldSprite, OSmile);
            SetName("Oswald");
            SetBox(OswaldBox);
        }

        if (sentences.Count == 7)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 6)
        {
            changeEmotion(OswaldSprite, OHappy);
            SetName("Oswald");
            SetBox(OswaldBox);
        }

        if (sentences.Count == 5)
        {
            changeEmotion(OswaldSprite, OReg);

        }

        if (sentences.Count == 4)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);

        }

        if (sentences.Count == 3)
        {
            mainText = dialogueText;
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
            changeEmotion(CocoSprite, CReg);
            SetName("Coco");
            SetBox(CocoBox);

        }

        if (sentences.Count == 2)
        {
            changeEmotion(OswaldSprite, OSmile);
            SetName("Oswald");
            SetBox(OswaldBox);
        }

        if (sentences.Count == 1)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 0 && dialogueOver == false)
        {
            clickingAllowed = false;
            StartCoroutine(CocoToKing());

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
    public IEnumerator OswaldAppears()
    {
        textAnim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(1f);
        controller.OswaldAnim.speed = 0.2f;
        controller.ShowOswald();
        SetName("Oswald");
        yield return new WaitForSeconds(3f);
        victoryBGM.Play();
        controller.OswaldAnim.speed = 1f;
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator OswaldFreed()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideKing();
        metalSFX.Play();
        yield return new WaitForSeconds(2.5f);
        SetName("???");
        SetBox(OswaldBox);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator KingToBlack()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideKing();
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        SetName("???");
        SetBox(EnemyBox);
        controller.ShowEnemy();
        yield return new WaitForSeconds(1.5f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator BlackToKing()
    {
        controller.EnemyAnim.speed = 0.3f;
        cloakSFX.Play();
        textAnim.SetBool("IsOpen", false);
        thoughtAnim.SetBool("Thinking", false);
        controller.HideEnemy();
        yield return new WaitForSeconds(2f);
        enemyBgmAnim.speed = 2f;
        enemyBgmAnim.SetTrigger("FadeOut");
        Vector3 newpos = new Vector3(-4.18f, -0.47f, 0f);
        King.transform.position = newpos;
        changeEmotion(CocoSprite, CSad);
        SetName("King");
        SetBox(KingBox);
        controller.ShowKing();
        controller.ShowCoco();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator MeetOswald()
    {
        textAnim.SetBool("IsOpen", false);
        thoughtAnim.SetBool("Thinking", false);
        controller.HideOswald();
        yield return new WaitForSeconds(1f);
        SetName("Coco");
        SetBox(CocoBox);
        Vector3 newpos = new Vector3(-4.18f, -0.47f, 0.04f);
        Coco.transform.position = newpos;
        Vector3 newpos2 = new Vector3(4.18f, -0.47f, 0.05f);
        Oswald.transform.position = newpos2;
        controller.ShowCoco();
        controller.ShowOswald();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator CocoToKing()
    {
        textAnim.SetBool("IsOpen", false);
        thoughtAnim.SetBool("Thinking", false);
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        changeEmotion(KingSprite, KReg);
        SetName("King");
        SetBox(KingBox);
        controller.ShowKing();
        textAnim.SetBool("IsOpen", true);
        if(sentences.Count == 0)
        {
            dialogueOver = true;
        }
        clickingAllowed = true;
    }

    public IEnumerator WoodsWalk()
    {
        textAnim.SetBool("IsOpen", false);
        controller.WipeStart();
        yield return new WaitForSeconds(1f);
        controller.HideKing();
        controller.HideOswald();
        yield return null;
        controller.WipeEnd();                
        yield return new WaitForSeconds(1f);
        changeEmotion(CocoSprite, CSmile);
        changeEmotion(OswaldSprite, OHappy);
        controller.ShowCoco();
        controller.ShowOswald();
        yield return new WaitForSeconds(1f);
        SetName("Oswald");
        SetBox(OswaldBox);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    
}
