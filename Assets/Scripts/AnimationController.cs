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
    public DialogueTrigger dialoguetrigger;
    //public Animator Stranger;

    // Start is called before the first frame update
    void Start()
    {
        firstCharAnim = firstChar.GetComponent<Animator>();

        if (King) {
            KingAnim = King.GetComponent<Animator>();
        }

        if (Coco)
        {
            CocoAnim = Coco.GetComponent<Animator>();
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

    public IEnumerator LastFade(float wait)
    {
        //HideKing();
        yield return new WaitForSeconds(wait);
    }

    public void BeginDialogue()
    {
        dialoguetrigger.TriggerDialogue();
    }

    //All functions to show.hide characters
    public void ShowKing()
    {
        KingAnim.SetBool("Present", true);

    }

    public void HideKing()
    {
        KingAnim.SetBool("Present", false);
        
    }

    public void ShowCoco()
    {
        CocoAnim.SetBool("Present", true);

    }

    public void HideCoco()
    {
        CocoAnim.SetBool("Present", false);

    }

    

}
