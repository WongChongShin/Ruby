using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueText.fontSize = 20;
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        

        Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            //sentence.fontSize = 20;
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

       string sentence = sentences.Dequeue();
       dialogueText.text = sentence;
       //sentence.fontSize = 20;
       Debug.Log(sentence);
    }

    void EndDialogue()
    {     
        Debug.Log("End of conversation.");

    }
}
