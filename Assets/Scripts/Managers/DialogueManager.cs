using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//brackeys tutorial :)
public class DialogueManager : MonoBehaviour
{
    public Animator anim;
    public Text txtName;
    public Text txtDialogue;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dia)
    {
        anim.SetBool("IsOpen", true);

        txtName.text = dia.name;

        sentences.Clear();

        foreach (string sentence in dia.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        txtDialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            txtDialogue.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
    }
}
