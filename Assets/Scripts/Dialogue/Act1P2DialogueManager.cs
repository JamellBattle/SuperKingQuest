using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act1P2DialogueManager : DialogueManager
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
    public Sprite KSurprise;
    public GameObject Sveri;
    public Animator SveriAnim;
    public SpriteRenderer SveriSprite;
    GameObject King;
    GameObject Coco;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        King = controller.King;
        Coco = controller.Coco;

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
    public IEnumerator SveriAppears()
    {

        controller.HideCoco();
        yield return new WaitForSeconds(1f);
        changeEmotion(CocoSprite, CSad);
        Vector3 newpos2 = new Vector3(-2.83f, -0.47f, 0.04f);
        Coco.transform.position = newpos2;
        controller.ShowCoco();
        controller.ShowSveri();
        SetBox(NPCBox);
        SetName("???");
        yield return new WaitForSeconds(1f);
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
