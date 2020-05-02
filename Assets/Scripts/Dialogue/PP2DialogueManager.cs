using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP2DialogueManager : DialogueManager
{

    public Sprite EnemyBox;
    public Sprite QuetzyBox;
    public Sprite KingBox;
    public GameObject Grasspath;
    public GameObject Quetzy;
    public SpriteRenderer QuetzySprite;
    public Sprite QHappy;
    public Sprite QReg;
    public Sprite QSad;
    public SpriteRenderer KingSprite;
    public Sprite KReg;
    public Sprite KMad;
    public Sprite KShock;
    GameObject King;
    Vector3 currpos;
    public Animator fireAnim;
    public AudioSource fireSFX;
    public AudioSource bushSFX;
    public AudioSource FBStart;
    public AudioSource FBEnd;
    public AudioSource RelaxedBGM;


    public override void Start()
    {
        base.Start();
        King = controller.King;
        currpos = King.transform.position;
        fireAnim.SetTrigger("FadeIn");
        StartCoroutine(FireFades());

    }

    public override void Update()
    {
        base.Update();
    }

    public override void StartDialogue(Dialogue dialogue)
    {
        textAnim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        RelaxedBGM.Play();
        base.StartDialogue(dialogue);
        
    }

    public override void DisplayNextSentence()
    {
        base.DisplayNextSentence();

        if (sentences.Count == 37)
        {
            textAnim.SetBool("IsOpen", false);
            mainText = thoughtText;
            StartCoroutine(ShowSus());
            clickingAllowed = false;
            
        }

        if (sentences.Count == 31)
        {
            thoughtAnim.SetBool("Thinking", false);
            mainText = dialogueText;
            StartCoroutine(HideSus());
            clickingAllowed = false;

        }

        if (sentences.Count == 30)
        {
            textAnim.SetBool("IsOpen", false);
            FBStart.Play();
            StartCoroutine(FlashbackStart());
            clickingAllowed = false;

        }

        if (sentences.Count == 29)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;
            KingSprite.sprite = KShock;

        }

        if (sentences.Count == 28)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            

        }

        if (sentences.Count == 27)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;
            KingSprite.sprite = KReg;

        }

        if (sentences.Count == 26)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;


        }

        if (sentences.Count == 25)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;
            KingSprite.sprite = KMad;


        }

        if (sentences.Count == 24)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            QuetzySprite.sprite = QHappy;

        }

        if (sentences.Count == 23)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;
            

        }

        if (sentences.Count == 22)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            QuetzySprite.sprite = QReg;


        }

        if (sentences.Count == 21)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;


        }

        if (sentences.Count == 20)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            QuetzySprite.sprite = QHappy;


        }

        if (sentences.Count == 18)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;


        }

        if (sentences.Count == 17)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;


        }

        if (sentences.Count == 17)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;


        }

        if (sentences.Count == 16)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;


        }

        if (sentences.Count == 15)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            QuetzySprite.sprite = QReg;


        }

        if (sentences.Count == 14)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;


        }

        if (sentences.Count == 13)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            QuetzySprite.sprite = QSad;

        }

        if (sentences.Count == 12)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;
            KingSprite.sprite = KShock;


        }

        if (sentences.Count == 11)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            QuetzySprite.sprite = QHappy;


        }

        if (sentences.Count == 10)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;


        }

        if (sentences.Count == 9)
        {
            nameText.text = "Quetzy";
            textbox.sprite = QuetzyBox;
            

        }

        if (sentences.Count == 8)
        {
            nameText.text = "King";
            textbox.sprite = KingBox;
            KingSprite.sprite = KMad;


        }

        if (sentences.Count == 7)
        {
            textAnim.SetBool("IsOpen", false);
            FBEnd.Play();
            StartCoroutine(FlashbackEnd());
            clickingAllowed = false;


        }

        if (sentences.Count == 5)
        {
            RelaxedBGM.Stop();
            bushSFX.Play();
            KingSprite.sprite = KShock;


        }

        if (sentences.Count == 4)
        {
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(KingtoBear());
            clickingAllowed = false;


        }

        if (sentences.Count == 3)
        {
            KingSprite.sprite = KMad;
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(BeartoKing());
            clickingAllowed = false;


        }

        if (sentences.Count == 2)
        {
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(KingtoBear());
            clickingAllowed = false;


        }

        if (sentences.Count == 1)
        {
            textAnim.SetBool("IsOpen", false);
            StartCoroutine(BeartoKing());
            clickingAllowed = false;


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

    public IEnumerator FireFades()
    {
        yield return new WaitForSeconds(1f);
        fireAnim.SetTrigger("FadeOut");
    }

    //Additonal Coroutines Exclusive to this Dialogue Manager
    public IEnumerator ShowSus()
    {
        
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        controller.ShowObject();
        yield return new WaitForSeconds(2f);
        thoughtAnim.SetBool("Thinking", true);
        clickingAllowed = true;



    }

    public IEnumerator HideSus()
    {
        
        controller.HideObject();
        yield return new WaitForSeconds(2f);
        controller.ShowKing();
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;



    }

    public IEnumerator FlashbackStart()
    {
        
        controller.FlashStart();
        yield return new WaitForSeconds(1f);
        Grasspath.gameObject.SetActive(true); 
        Quetzy.gameObject.SetActive(true);
        Vector3 newpos = new Vector3(4.18f, -0.47f, 0);
        King.transform.position = newpos;
        textbox.sprite = QuetzyBox;
        nameText.text = "Quetzy";
        yield return null;
        controller.FlashEnd();
        yield return new WaitForSeconds(2f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
        

    }

    public IEnumerator FlashbackEnd()
    {
        controller.FlashStart();
        yield return new WaitForSeconds(1f);
        Grasspath.gameObject.SetActive(false);
        Quetzy.gameObject.SetActive(false);
        King.transform.position = currpos;
        textbox.sprite = KingBox;
        nameText.text = "King";
        yield return null;
        controller.FlashEnd();
        yield return new WaitForSeconds(2f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;
    }

    public IEnumerator KingtoBear()
    {
        controller.HideKing();
        yield return new WaitForSeconds(1f);
        controller.ShowEnemy();
        textbox.sprite = EnemyBox;
        nameText.text = "Wild Bear";
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }

    public IEnumerator BeartoKing()
    {
        controller.HideEnemy();
        yield return new WaitForSeconds(1f);
        controller.ShowKing();
        textbox.sprite = KingBox;
        nameText.text = "King";
        yield return new WaitForSeconds(1f);
        textAnim.SetBool("IsOpen", true);
        clickingAllowed = true;

    }


}