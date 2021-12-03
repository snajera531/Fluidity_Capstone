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
    public Vector3 smallFont = new Vector3(0.5f, 0.5f, 1);
    public Vector3 mediumFont = new Vector3(0.6f, 0.6f, 1);
    public Vector3 largeFont = new Vector3(0.7f, 0.7f, 1);

    public DialogueTrigger trigger;
    public float typingSpeed = 0.5f;

    private Vector3 currentFontSize;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        currentFontSize = mediumFont;
    }

    public void ChangeFontSize(Vector3 fontSize)
    {
        currentFontSize = fontSize;
        txtName.transform.localScale = fontSize;
        txtDialogue.transform.localScale = fontSize;
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
            AudioManager.Instance.Play("Dialogue_Type");
            txtDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
    }
}
