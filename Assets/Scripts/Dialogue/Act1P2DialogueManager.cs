using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P2DialogueManager : DialogueManager
{

    public Sprite CocoBox;
    public Sprite KingBox;
    public Sprite NPCBox;
    public Sprite EnemyBox;
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
    SpriteRenderer SveriSprite;
    public Sprite SMad;
    public Sprite SAngry;
    SpriteRenderer PaulSprite;
    public Sprite PReg;
    public Sprite PHappy;
    public Sprite PMad;
    public Sprite PSad;
    SpriteRenderer KhanSprite;
    public Sprite KhReg;
    public Sprite KhPout;
    public Sprite KhMad;
    public Sprite KhSad;
    public Sprite KhHappy;
    public AudioSource oomaBGM;
    public Animator oomaAnim;
    public AudioSource hornSFX;
    public Animator hornAnim;
    public AudioSource panicBGM;
    public AudioSource runningSFX;
    public AudioSource clashSFX;
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

        if (sentences.Count == 36)
        {
            changeEmotion(PaulSprite, PSad);
        }

        if (sentences.Count == 35)
        {
            changeEmotion(KhanSprite, KhPout);
        }

        if (sentences.Count == 34)
        {
            changeEmotion(PaulSprite, PHappy);
        }

        if (sentences.Count == 33)
        {
            dialogueText.fontSize = 36;
            SetBox(KingBox);
            SetName("King");            
        }

        if (sentences.Count == 32)
        {
            clickingAllowed = false;
            dialogueText.fontSize = 24;
            StartCoroutine(KingsHere());
        }

        if (sentences.Count == 31)
        {
            SetBox(KingBox);
            SetName("King");
        }

        if (sentences.Count == 30)
        {
            SetBox(CocoBox);
            SetName("Coco");
        }

        if (sentences.Count == 29)
        {
            clickingAllowed = false;
            mainText = thoughtText;
            changeEmotion(KhanSprite, KhReg);
            changeEmotion(PaulSprite, PReg);
            StartCoroutine(MeetTheBros());
        }

        if (sentences.Count == 27)
        {
            clickingAllowed = false;
            mainText = dialogueText;
            changeEmotion(KingSprite, KMad);
            StartCoroutine(Introduction());
        }

        if (sentences.Count == 26)
        {
            clickingAllowed = false;
            
            StartCoroutine(MeetTheBros());
        }

        if (sentences.Count == 25)
        {
            changeEmotion(KhanSprite, KhHappy);
            SetName("Khan");
        }

        if (sentences.Count == 24)
        {
            clickingAllowed = false;
            changeEmotion(KingSprite, KMad);
            StartCoroutine(BrosToKing());
        }

        if (sentences.Count == 23)
        {
            SetBox(CocoBox);
            SetName("Coco");
        }

        if (sentences.Count == 22)
        {
            SetBox(KingBox);
            changeEmotion(KingSprite, KReg);
            SetName("King");
        }

        if (sentences.Count == 21)
        {
            clickingAllowed = false;
            changeEmotion(KhanSprite, KhHappy);
            changeEmotion(PaulSprite, PReg);
            StartCoroutine(KingToBros());
        }

        if (sentences.Count == 20)
        {
            clickingAllowed = false;
            mainText = thoughtText;
            changeEmotion(KingSprite, KReg);
            StartCoroutine(BrosToKing());
        }

        if(sentences.Count == 19)
        {
            oomaAnim.speed = 3f;
            oomaAnim.SetTrigger("FadeOut");
        }

        if (sentences.Count == 18)
        {
            clickingAllowed = false;
            mainText = dialogueText;
            StartCoroutine(AlarmSounds());
        }

        if (sentences.Count == 17)
        {
            clickingAllowed = false;
            hornAnim.speed = 2f;
            hornAnim.SetTrigger("FadeOut");
            StartCoroutine(SveriAppears());
        }

        if (sentences.Count == 16)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
        }

        if (sentences.Count == 14)
        {
            mainText = dialogueText;
            changeEmotion(SveriSprite, SMad);
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
        }

        if (sentences.Count == 13)
        {
            clickingAllowed = false;
            StartCoroutine(SveriToBros());
        }

        if (sentences.Count == 12)
        {
            clickingAllowed = false;
            StartCoroutine(ByeBros());
        }

        if (sentences.Count == 11)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 10)
        {
            clickingAllowed = false;
            StartCoroutine(PaulLeaves());
        }

        if (sentences.Count == 9)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 8)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 7)
        {
            changeEmotion(KingSprite, KShock);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 6)
        {
            clickingAllowed = false;
            StartCoroutine(UnderAttack());
        }

        if (sentences.Count == 5)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 4)
        {
            Vector3 newpos2 = new Vector3(-2.83f, -0.47f, 0.04f);
            Coco.transform.position = newpos2;
            controller.ShowCoco();
            SetName("Coco");
            SetBox(KingBox);
        }

        if (sentences.Count == 3)
        {
            changeEmotion(KingSprite, KMad);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 2)
        {
            
            SetName("Gorgon Grunts");
            SetBox(EnemyBox);
        }

        if (sentences.Count == 1)
        {           
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 0)
        {
            changeEmotion(KingSprite, KAngry);
            
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

    public IEnumerator KingsHere()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HidePaul();
        controller.HideKhan();
        changeEmotion(KingSprite, KMad);
        Vector3 newpos = new Vector3(4.32f, -0.47f, 0.04f);
        Coco.transform.position = newpos;
        yield return new WaitForSeconds(1f);
        SetBox(CocoBox);
        SetName("Coco");
        controller.ShowKing();
        yield return new WaitForSeconds(1f);
        controller.ShowCoco();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;


    }

    public IEnumerator MeetTheBros()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        controller.ShowKhan();
        controller.ShowPaul();
        yield return new WaitForSeconds(1f);
        if (sentences.Count == 29)
        {
            yield return new WaitForSeconds(1f);
            thoughtAnim.SetBool("Thinking", true);
        }
        else if (sentences.Count == 26)
        {
            changeEmotion(PaulSprite, PHappy);
            SetName("Paul");
            SetBox(NPCBox);
            textAnim.SetBool("IsOpen", true);
        }


        clickingAllowed = true;
    }

    public IEnumerator Introduction()
    {
        thoughtAnim.SetBool("Thinking", false);
        controller.HidePaul();
        controller.HideKhan();
        yield return new WaitForSeconds(1f);
        controller.ShowCoco();
        controller.ShowKing();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator BrosToKing()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HidePaul();
        controller.HideKhan();
        yield return new WaitForSeconds(1f);
        SetBox(KingBox);
        SetName("King");
        controller.ShowCoco();
        controller.ShowKing();
        if (sentences.Count == 20)
        {
            thoughtAnim.SetBool("Thinking", true);
        }
        else
        {
            textAnim.SetBool("IsOpen", true);
        }
        
        clickingAllowed = true;
    }

    public IEnumerator KingToBros()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        SetBox(NPCBox);
        SetName("Khan");
        controller.ShowPaul();
        controller.ShowKhan();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator AlarmSounds()
    {
        thoughtAnim.SetBool("Thinking", false);
        hornSFX.Play();
        yield return new WaitForSeconds(3f);
        changeEmotion(KingSprite, KShock);
        changeEmotion(CocoSprite, CMad);
        SetBox(KingBox);
        SetName("King");
        yield return new WaitForSeconds(1f);
        panicBGM.Play();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator SveriAppears()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        changeEmotion(SveriSprite, SAngry);
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

    public IEnumerator SveriToBros()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideSveri();
        controller.HideKing();
        changeEmotion(PaulSprite, PMad);
        changeEmotion(KhanSprite, KhMad);
        yield return new WaitForSeconds(1f);
        controller.ShowKhan();
        controller.ShowPaul();
        SetName("Paul & Khan");
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator ByeBros()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideKhan();
        controller.HidePaul();
        changeEmotion(KingSprite, KMad);
        yield return new WaitForSeconds(1f);
        controller.ShowKing();
        controller.ShowCoco();
        changeEmotion(PaulSprite, PSad);
        yield return new WaitForSeconds(1f);
        controller.ShowPaul();
        SetName("Paul");
        yield return new WaitForSeconds(0.5f);       
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator PaulLeaves()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HidePaul();
        runningSFX.Play();
        yield return new WaitForSeconds(2f);
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        Vector3 newpos = new Vector3(4.32f, -0.47f, 0.04f);
        Coco.transform.position = newpos;
        controller.ShowCoco();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;


    }

    public IEnumerator UnderAttack()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideKing();
        controller.HideCoco();
        controller.FlashAnim.speed = 1.5f;
        controller.FlashStart();
        clashSFX.Play();
        yield return new WaitForSeconds(0.5f);
        controller.FlashEnd();
        yield return new WaitForSeconds(1f);
        controller.ShowEnemy();
        controller.ShowKing();
        SetBox(EnemyBox);
        SetName("???");
        yield return new WaitForSeconds(1.5f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

}
