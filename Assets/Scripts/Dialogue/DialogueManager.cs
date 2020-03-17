using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Text mainText;
    public Text thoughtText;
    public SpriteRenderer textbox;
    public Animator textAnim;
    public Animator thoughtAnim;
    public AnimationController controller;
    public LevelLoader loadlevel;
    public string nextScene;

    // Start is called before the first frame update
    public virtual void Start()
    {
        sentences = new Queue<string>();
        mainText = dialogueText;
        controller = (AnimationController)FindObjectOfType(typeof(AnimationController));
        loadlevel = (LevelLoader)FindObjectOfType(typeof(LevelLoader));
    }

    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public virtual void StartDialogue(Dialogue dialogue)
    {
        textAnim.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public virtual void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); 
        StartCoroutine(TypeSentence(sentence));
    }

    public virtual IEnumerator TypeSentence(string sentence)
    {
        mainText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            mainText.text += letter;
            yield return 1f;
        }
    }

    public virtual void EndDialogue()
    {

        textAnim.SetBool("IsOpen", false);
        loadlevel.LoadNextLevel(nextScene);

    }

    
}
