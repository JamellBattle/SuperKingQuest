using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceWriter : MonoBehaviour
{
    public DialogueManager dm;
    public string sentence;

    private void Update()
    {
        sentence = dm.sentence;
    }
    public void StartWritingSentence()
    {
        
        dm.StopAllCoroutines();
        dm.StartCoroutine(dm.TypeSentence(sentence));
    }

   
}
