using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P3DialogueManager : DialogueManager
{

    public Sprite CocoBox;
    public Sprite KingBox;
    public Sprite NPCBox;
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
    public Sprite KSmile;
    SpriteRenderer SveriSprite;
    public Sprite SMad;
    public Sprite SSmile;
    public Sprite SSad;
    public Sprite SHappy;
    SpriteRenderer CamileSprite;
    public Sprite CaYell;
    public Sprite CaSad;
    public Sprite CaMad;
    public Sprite CaHappy;
    public Animator panicAnim;
    public AudioSource runningSFX;
    public AudioSource worryBGM;
    public Animator worryAnim;
    public AudioSource goodBGM;
    public Animator goodAnim;
    GameObject King;
    GameObject Coco;
    GameObject Sveri;
    GameObject Camile;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        King = controller.King;
        Coco = controller.Coco;
        Sveri = controller.Sveri;
        Camile = controller.Camile;
        KingSprite = King.GetComponent<SpriteRenderer>();
        CocoSprite = Coco.GetComponent<SpriteRenderer>();
        SveriSprite = Sveri.GetComponent<SpriteRenderer>();
        CamileSprite = Camile.GetComponent<SpriteRenderer>();

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

        if (sentences.Count == 36)
        {
            SetBox(EnemyBox);
        }

        if (sentences.Count == 35)
        {
            clickingAllowed = false;
            StartCoroutine(EnemiesRetreat());
        }

        if (sentences.Count == 34)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 33)
        {
            clickingAllowed = false;
            StartCoroutine(SveriAppears());
        }

        if (sentences.Count == 32)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 31)
        {
            changeEmotion(SveriSprite, SSmile);
            SetName("Sveri");
            SetBox(NPCBox);
        }

        if (sentences.Count == 30)
        {
            changeEmotion(SveriSprite, SHappy);
            changeEmotion(KingSprite, KSurprise);
        }

        if (sentences.Count == 29)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 28)
        {
            
            SetName("???");
            SetBox(NPCBox);
        }

        if (sentences.Count == 27)
        {
            clickingAllowed = false;
            StartCoroutine(CamileAppears());
        }

        if (sentences.Count == 26)
        {
            worryBGM.Play();
            SetName("Camile");           
        }

        if (sentences.Count == 25)
        {
            changeEmotion(SveriSprite, SMad);
            SetName("Sveri");
        }

        if (sentences.Count == 24)
        {
            clickingAllowed = false;
            StartCoroutine(CamileToCoco());
        }

        if (sentences.Count == 23)
        {

            SetName("Sveri");
            SetBox(NPCBox);
        }

        if (sentences.Count == 22)
        {
            
            clickingAllowed = false;
            changeEmotion(CamileSprite, CaMad);
            StartCoroutine(CocoToCamile());
        }

        if (sentences.Count == 21)
        {

            SetName("Camile");
        }

        if (sentences.Count == 20)
        {

            SetName("Sveri");
            changeEmotion(SveriSprite, SMad);
        }

        if (sentences.Count == 19)
        {
            clickingAllowed = false;
            mainText = thoughtText;
            StartCoroutine(CamileToKing());
            
        }

        if (sentences.Count == 18)
        {        
            mainText = dialogueText;
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);

        }

        if (sentences.Count == 17)
        {
            changeEmotion(SveriSprite, SSad);
        }

        if (sentences.Count == 16)
        {
            worryAnim.speed = 2f;
            worryAnim.SetTrigger("FadeOut");
            SetName("King");
            SetBox(KingBox);
            changeEmotion(KingSprite, KMad);

        }

        if (sentences.Count == 15)
        {
            SetName("Sveri");
            SetBox(NPCBox);
            changeEmotion(KingSprite, KMad);

        }

        if (sentences.Count == 14)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 13)
        {

            clickingAllowed = false;
            StartCoroutine(SadFace());

        }

        if (sentences.Count == 12)
        {
            clickingAllowed = false;
            StartCoroutine(AnnoyKing());

        }

        if (sentences.Count == 10)
        {

            clickingAllowed = false;
            StartCoroutine(SadFace());

        }

        if (sentences.Count == 9)
        {
            clickingAllowed = false;
            StartCoroutine(AnnoyKing());

        }

        if (sentences.Count == 8)
        {

            clickingAllowed = false;
            StartCoroutine(SadFace());

        }

        if (sentences.Count == 7)
        {
            clickingAllowed = false;
            StartCoroutine(AnnoyKing());

        }

        if (sentences.Count == 6)
        {

            clickingAllowed = false;
            StartCoroutine(SadFace());

        }

        if (sentences.Count == 5)
        {

            SetName("Camile");
            SetBox(NPCBox);

        }

        if (sentences.Count == 4)
        {

            SetName("Sveri");
            SetBox(NPCBox);

        }

        if (sentences.Count == 3)
        {
            clickingAllowed = false;
            StartCoroutine(AnnoyKing());

        }

        if (sentences.Count == 2)
        {
            SetName("Coco");
            SetBox(CocoBox);

        }

        if (sentences.Count == 1)
        {
            changeEmotion(KingSprite, KSmile);
            SetName("King");
            SetBox(KingBox);

        }

        if (sentences.Count == 0)
        {
            changeEmotion(CocoSprite, CSmug);
            SetName("Coco");
            SetBox(CocoBox);

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
    public IEnumerator EnemiesRetreat()
    {
        panicAnim.speed = 2f;
        panicAnim.SetTrigger("FadeOut");
        runningSFX.Play();
        textAnim.SetBool("IsOpen", false);
        controller.HideEnemy();
        yield return new WaitForSeconds(2f);
        SetName("Coco");
        SetBox(CocoBox);
        controller.ShowCoco();
        changeEmotion(CocoSprite, CSmile);
        yield return new WaitForSeconds(0.5f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator SveriAppears()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        Vector3 newpos2 = new Vector3(-2.83f, -0.47f, 0.04f);
        Coco.transform.position = newpos2;
        controller.ShowCoco();
        controller.ShowSveri();
        SetBox(NPCBox);
        SetName("Sveri");
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator CamileAppears()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        changeEmotion(CamileSprite, CaMad);
        controller.ShowCamile();
        changeEmotion(SveriSprite, SSad);
        yield return new WaitForSeconds(1f);        
        SetName("Sveri");       
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator CamileToCoco()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCamile();
        yield return new WaitForSeconds(1f);
        Vector3 newpos = new Vector3(-4.43f, -0.47f, 0.04f);
        Coco.transform.position = newpos;
        changeEmotion(CocoSprite, CReg);
        controller.ShowCoco();
        yield return new WaitForSeconds(1f);
        SetName("Coco");
        SetBox(CocoBox);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator CamileToKing()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCamile();
        yield return new WaitForSeconds(1f);
        changeEmotion(KingSprite, KShock);
        controller.ShowKing();
        yield return new WaitForSeconds(1f);
        thoughtAnim.SetBool("Thinking", true);
        clickingAllowed = true;

    }

    public IEnumerator CocoToCamile()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        controller.ShowCamile();
        yield return new WaitForSeconds(1f);
        SetName("Sveri");
        changeEmotion(SveriSprite, SSad);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }


    public IEnumerator SadFace()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideSveri();
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        if (sentences.Count == 13)
        {
            Vector3 newpos = new Vector3(0, -0.47f, 0.04f);
            Coco.transform.position = newpos;
            changeEmotion(CocoSprite, CSad);
            controller.ShowCoco();
            yield return new WaitForSeconds(1f);
            SetName("Coco");
            SetBox(CocoBox);

        } else if (sentences.Count == 10)
        {
            changeEmotion(KingSprite, KShock);
            controller.ShowCoco();
            changeEmotion(CamileSprite, CaSad);
            controller.ShowCamile();
            yield return new WaitForSeconds(1f);
            SetName("Coco & Camile");
            SetBox(NPCBox);
        } else if (sentences.Count == 8)
        {
            changeEmotion(KingSprite, KAngry);
            controller.ShowCoco();
            controller.ShowCamile();
            controller.ShowSveri();
            yield return new WaitForSeconds(1f);
            SetName("Everyone");
            SetBox(NPCBox);
        } else if (sentences.Count == 6)
        {
            goodBGM.Play();
            changeEmotion(CocoSprite, CSmile);
            changeEmotion(CamileSprite, CaHappy);
            changeEmotion(SveriSprite, SHappy);
            controller.ShowCoco();
            controller.ShowCamile();
            controller.ShowSveri();
            SetName("Coco");
            SetBox(CocoBox);
        }
        
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator AnnoyKing()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideCamile();
        controller.HideSveri();
        yield return new WaitForSeconds(1f);
        if (sentences.Count == 3)
        {
            Vector3 newpos = new Vector3(-4.85f, -0.47f, 0);
            King.transform.position = newpos;
            changeEmotion(KingSprite, KMad);
            controller.ShowKing();
            Vector3 newpos2 = new Vector3(4.32f, -0.47f, 0);
            Coco.transform.position = newpos2;
            changeEmotion(CocoSprite, CReg);
            controller.ShowCoco();
            yield return new WaitForSeconds(1f);

        } else
        {
            Vector3 newpos = new Vector3(0, -0.47f, 0);
            King.transform.position = newpos;
            controller.ShowKing();
            yield return new WaitForSeconds(1f);
        }
        
        SetName("King");
        SetBox(KingBox);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

}
