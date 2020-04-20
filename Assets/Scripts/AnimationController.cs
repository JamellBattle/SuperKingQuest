using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator Fade;
    //Animators for First character(s) that appears
    public GameObject firstChar;
    public Animator firstCharAnim;
    public GameObject firstChar2;
    public Animator firstChar2Anim;

    //Animators for each character
    public GameObject King;
    public Animator KingAnim;
    public GameObject Coco;
    public Animator CocoAnim;
    public GameObject Sveri;
    public Animator SveriAnim;
    public GameObject Paul;
    public Animator PaulAnim;
    public GameObject Khan;
    public Animator KhanAnim;

    //Animators for Miscellaneous things
    public GameObject ObjectOfInterest;
    public Animator OOIAnim;
    public GameObject Flash;
    public Animator FlashAnim;
    public GameObject Enemy;
    public Animator EnemyAnim;
    public GameObject Wipe;
    public Animator WipeAnim;
    public GameObject Sky;
    public Animator SkyAnim;
    public DialogueTrigger dialogueTrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        if (firstChar)
        {
            //this gets the animator for the character designated as the first character to appear in the scene
            firstCharAnim = firstChar.GetComponent<Animator>();
        }

        if (firstChar2)
        {
            //this gets the animator for the character designated as the first character to appear in the scene
            firstChar2Anim = firstChar2.GetComponent<Animator>();
        }


        //These if statements are checking if these objects/characters will even be in the scene.
        //If they were given a gameObject value, then get the animator from it, if not, then don't.
        //By doing this, I can script in variables for objects that won't always be present in the scene
        //and the script will not complain if they aren't set to anything.


        //Checking for characters
        if (King) {
            KingAnim = King.GetComponent<Animator>();
        }

        if (Coco)
        {
            CocoAnim = Coco.GetComponent<Animator>();
        }

        if (Enemy)
        {
            EnemyAnim = Enemy.GetComponent<Animator>();
        }

        if (Sveri)
        {
            SveriAnim = Sveri.GetComponent<Animator>();
        }

        if (Paul)
        {
            PaulAnim = Paul.GetComponent<Animator>();
        }

        if (Khan)
        {
            KhanAnim = Khan.GetComponent<Animator>();
        }


        //Checking for Miscellaneous things
        if (ObjectOfInterest) {
            OOIAnim = ObjectOfInterest.GetComponent<Animator>();
        }

        if (Flash) {
            FlashAnim = Flash.GetComponent<Animator>();
            
        }

        if (Wipe)
        {
            WipeAnim = Wipe.GetComponent<Animator>();

        }

        if (Sky)
        {
            SkyAnim = Sky.GetComponent<Animator>();
            SkyAnim.speed = 0.1f;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public IEnumerator FirstFade(float wait)
    {
        if (firstChar)
        {
            if (firstChar.name == "King")
            {
                ShowKing();
                
            }
            else if (firstChar.name == "Coco")
            {
                ShowCoco();
            }

            if (firstChar2)
            {
                if (firstChar2.name == "Coco")
                {
                    ShowCoco();
                }
                else if (firstChar2.name == "Paul")
                {
                    ShowPaul();
                }
            }
            yield return new WaitForSeconds(wait);
        }
        

       
        
        BeginDialogue();
    }

    public void BeginDialogue()
    {
        dialogueTrigger.TriggerDialogue();
    }


    //All functions to show/hide characters/objects

    //King
    public void ShowKing()
    {
        KingAnim.SetBool("Present", true);
    }

    public void HideKing()
    {
        KingAnim.SetBool("Present", false);       
    }

    //Coco
    public void ShowCoco()
    {
        CocoAnim.SetBool("Present", true);
    }

    public void HideCoco()
    {
        CocoAnim.SetBool("Present", false);
    }

    //Sveri
    public void ShowSveri()
    {
        SveriAnim.SetBool("Present", true);
    }

    public void HideSveri()
    {
        SveriAnim.SetBool("Present", false);
    }

    //Paul
    public void ShowPaul()
    {
        PaulAnim.SetBool("Present", true);
    }

    public void HidePaul()
    {
        PaulAnim.SetBool("Present", false);
    }

    //Khan
    public void ShowKhan()
    {
        KhanAnim.SetBool("Present", true);
    }

    public void HideKhan()
    {
        KhanAnim.SetBool("Present", false);
    }

    //Functions for a enemy (who doesn't have any unique animation)
    public void ShowEnemy()
    {
        EnemyAnim.SetBool("Present", true);

    }

    public void HideEnemy()
    {
        EnemyAnim.SetBool("Present", false);

    }

    //Functions for any object of interest
    public void ShowObject()
    {
        OOIAnim.SetBool("Present", true);

    }

    public void HideObject()
    {
        OOIAnim.SetBool("Present", false);

    }

    //functions for the flashback

    public void FlashStart()
    {
        FlashAnim.SetBool("Flashbacking", true);
    }

    public void FlashEnd()
    {
        FlashAnim.SetBool("Flashbacking", false);
    }

    //Wipe transition
    public void WipeStart()
    {
        WipeAnim.SetBool("Wiping", true);
    }

    public void WipeEnd()
    {
        WipeAnim.SetBool("Wiping", false);
    }

    //Fade to the sky
    public void SkyFade()
    {
        SkyAnim.SetBool("Present", true);
    }



}
