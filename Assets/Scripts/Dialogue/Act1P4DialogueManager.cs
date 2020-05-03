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
    public Sprite CAngry;
    SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KAngry;
    public Sprite KMad;
    public Sprite KShock;
    public Sprite KSurprise;
    public Animator woodsAnim;
    public AudioSource woodsSFX;
    public AudioSource hitSFX;
    public AudioSource blackBGM;
    public AudioSource cloakSFX;
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
        StartCoroutine(WoodsQuiet());

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

        if (sentences.Count == 46)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 45)
        {
            changeEmotion(KingSprite, KSurprise);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 44)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 43)
        {
            
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 42)
        {
            SetName("Coco");
            SetBox(CocoBox);
        }

        if (sentences.Count == 41)
        {
            changeEmotion(KingSprite, KMad);
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 40)
        {
            mainText = thoughtText;
            clickingAllowed = false;
            StartCoroutine(MovingCloser());
        }

        if (sentences.Count == 37)
        {
            mainText = dialogueText;
            SetName("Coco");
            SetBox(CocoBox);
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
            controller.ShowCoco();
            controller.ShowKing();
            
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
        }

        if (sentences.Count == 34)
        {
            mainText = thoughtText;
            clickingAllowed = false;
            StartCoroutine(SneakTime());
        }

        if (sentences.Count == 31)
        {
            blackBGM.Play();
            mainText = dialogueText;
            SetName("???");
            SetBox(EnemyBox);
            controller.HideOswald();
            thoughtAnim.SetBool("Thinking", false);
            textAnim.SetBool("IsOpen", true);
        }

        if (sentences.Count == 30)
        {
            clickingAllowed = false;
            StartCoroutine(Detected());
        }

        if (sentences.Count == 29)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
        }

        if (sentences.Count == 26)
        {
            mainText = dialogueText;
            changeEmotion(KingSprite, KMad);
            textAnim.SetBool("IsOpen", true);
            thoughtAnim.SetBool("Thinking", false);
        }

        if (sentences.Count == 25)
        {
            clickingAllowed = false;
            StartCoroutine(KingToBlack());
        }

        if (sentences.Count == 24)
        {
            clickingAllowed = false;
            StartCoroutine(BlackToKing());
        }

        if (sentences.Count == 23)
        {
            clickingAllowed = false;
            StartCoroutine(KingToBlack());
        }

        if (sentences.Count == 22)
        {
            clickingAllowed = false;
            StartCoroutine(Memories());
        }

        if (sentences.Count == 20)
        {
            clickingAllowed = false;
            StartCoroutine(BlackCloak());
        }

        if (sentences.Count == 19)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 18)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
        }

        if (sentences.Count == 13)
        {
            changeEmotion(KingSprite, KShock);
        }

        if (sentences.Count == 12)
        {
            clickingAllowed = false;
            mainText = dialogueText;
            StartCoroutine(BlackAttacks());
        }

        if (sentences.Count == 11)
        {
            SetName("King");
            SetBox(KingBox);
        }

        if (sentences.Count == 10)
        {
            clickingAllowed = false;
            StartCoroutine(KingToBlack());
        }

        if (sentences.Count == 9)
        {
            mainText = thoughtText;
            textAnim.SetBool("IsOpen", false);
            thoughtAnim.SetBool("Thinking", true);
        }

        if (sentences.Count == 5)
        {
            mainText = dialogueText;
            clickingAllowed = false;
            StartCoroutine(BlackToKing());
        }

        if (sentences.Count == 4)
        {
            clickingAllowed = false;
            StartCoroutine(KingToBlack());
        }

        if (sentences.Count == 3)
        {
            clickingAllowed = false;
            StartCoroutine(BlackToKing());
        }

        if (sentences.Count == 2)
        {
            clickingAllowed = false;
            StartCoroutine(KingToBlack());
        }


        if (sentences.Count == 1)
        {
            clickingAllowed = false;
            StartCoroutine(BlackToKing());
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

    public IEnumerator WoodsQuiet()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("sound should be fading now");
        woodsAnim.SetTrigger("FadeOut");
    }

    public IEnumerator SneakTime()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideCoco();
        controller.HideKing();
        yield return new WaitForSeconds(2f);
        controller.ShowEnemy();
        controller.ShowOswald();
        yield return new WaitForSeconds(2f);
        thoughtAnim.SetBool("Thinking", true);
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

    public IEnumerator Detected()
    {
        textAnim.SetBool("IsOpen", false);
        controller.HideEnemy();
        yield return new WaitForSeconds(1f);
        SetName("King");
        SetBox(KingBox);
        changeEmotion(KingSprite, KShock);
        changeEmotion(CocoSprite, CMad);
        controller.ShowKing();
        controller.ShowCoco();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator KingToBlack()
    {
        controller.EnemyAnim.speed = 1f;
        textAnim.SetBool("IsOpen", false);
        controller.HideKing();
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        if (sentences.Count == 10)
        {
            cloakSFX.Play();
            controller.EnemyAnim.speed = 0.3f;
            SetName("???");
            SetBox(EnemyBox);
            controller.ShowEnemy();
            yield return new WaitForSeconds(1f);
        }
        SetName("???");
        SetBox(EnemyBox);
        controller.ShowEnemy();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator BlackToKing()
    {
        controller.EnemyAnim.speed = 1f;
        textAnim.SetBool("IsOpen", false);
        thoughtAnim.SetBool("Thinking", false);
        controller.HideEnemy();
        yield return new WaitForSeconds(1f);
        SetName("King");
        SetBox(KingBox);
        controller.ShowKing();
        controller.ShowCoco();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }


    public IEnumerator Memories()
    {
        textAnim.SetBool("IsOpen", false);        
        controller.HideEnemy();
        yield return new WaitForSeconds(1f);
        Vector3 newpos = new Vector3(0, -0.47f, 0.04f);
        Coco.transform.position = newpos;
        controller.ShowCoco();
        yield return new WaitForSeconds(2f);
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        controller.ShowEnemy();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator BlackCloak()
    {
        textAnim.SetBool("IsOpen", false);
        controller.EnemyAnim.speed = 0.3f;
        cloakSFX.Play();
        controller.HideEnemy();
        yield return new WaitForSeconds(2f);
        Vector3 newpos = new Vector3(4.32f, -0.47f, 0.04f);
        Coco.transform.position = newpos;
        changeEmotion(CocoSprite, CAngry);
        SetName("Coco");
        SetBox(CocoBox);
        controller.ShowKing();
        controller.ShowCoco();
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator BlackAttacks()
    {
        thoughtAnim.SetBool("Thinking", false);
        hitSFX.Play();
        controller.FlashAnim.speed = 1.5f;
        controller.FlashStart();
        controller.HideKing();
        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        controller.FlashEnd();
        yield return new WaitForSeconds(2f);
        Vector3 newpos = new Vector3(0, -0.47f, 0f);
        King.transform.position = newpos;
        Vector3 newpos2 = new Vector3(-1.94f, -0.47f, 0.04f);
        Coco.transform.position = newpos2;
        controller.ShowKing();
        changeEmotion(KingSprite, KMad);
        yield return new WaitForSeconds(1f);
        controller.ShowCoco();
        changeEmotion(CocoSprite, CSad);
        SetName("Coco");
        SetBox(CocoBox);
        yield return new WaitForSeconds(1.5f);
        controller.EnemyAnim.speed = 1f;
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }


}
