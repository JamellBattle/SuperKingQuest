using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator Fade;
    public GameObject firstChar;
    public Animator firstCharAnim;
    public GameObject King;
    public Animator KingAnim;
    public GameObject Coco;
    public Animator CocoAnim;
    public GameObject ObjectOfInterest;
    public Animator OOIAnim;
    public GameObject Flashback;
    public Animator FBAnim;
    public GameObject Enemy;
    public Animator EnemyAnim;
    public DialogueTrigger dialoguetrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        //this gets the animator for the character designated as the first character to appear in the scene
        firstCharAnim = firstChar.GetComponent<Animator>();

        //These if statements are checking if these objects/characters will even be in the scene.
        //If they were given a gameObject value, then get the animator from it, if not, then don't.
        //By doing this, I can script in variables for objects that won't always be present in the scene
        //and the script will not complain if they aren't set to anything.

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

        if (ObjectOfInterest) {
            OOIAnim = ObjectOfInterest.GetComponent<Animator>();
        }

        if (Flashback) {
            FBAnim = Flashback.GetComponent<Animator>();
            
        }



    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public IEnumerator FirstFade(float wait)
    {
        if (firstChar.name == "King")
        {
            ShowKing();
            yield return new WaitForSeconds(wait);
        }
        
        BeginDialogue();
    }

    public void BeginDialogue()
    {
        dialoguetrigger.TriggerDialogue();
    }


    //All functions to show/hide characters/objects

    //Functions for King
    public void ShowKing()
    {
        KingAnim.SetBool("Present", true);

    }

    public void HideKing()
    {
        KingAnim.SetBool("Present", false);
        
    }

    //Functions for Coco
    public void ShowCoco()
    {
        CocoAnim.SetBool("Present", true);

    }

    public void HideCoco()
    {
        CocoAnim.SetBool("Present", false);

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
        FBAnim.SetBool("Flashbacking", true);
    }

    public void FlashEnd()
    {
        FBAnim.SetBool("Flashbacking", false);
    }





}
