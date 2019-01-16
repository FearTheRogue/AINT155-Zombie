using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour
{
    // Creates a text calles DialogueText 
    public Text DialogueText;
    // Creates a string array 
    public string[] sentences;
    // Creates an int 
    private int index;
    // Creates a float for the speed of the text 
    public float typingSpeed;

    public GameObject dialogueBox;

    //public GameObject continuebutton, skipbutton;


    public void Awake()
    {

        dialogueBox.SetActive(false);
    }

    // Sets the dialoguebox to true
    public void StartConvo()
    {
        dialogueBox.SetActive(true);
        // Starts the typing of each sentence 
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        // dialoguebox is emptied
        DialogueText.text = "";
        // each character in sentences has an index, and it typing one by one at the speed of typingSpeed
        foreach (char letter in sentences[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        Invoke("NextSentence", 3);
        if (index == 2)
        {
            Invoke("TextBox", 2);
        }
    }

    public void NextSentence()
    {
        // continuebutton.SetActive(false);
        //  if(skipbutton != null)
        //  skipbutton.SetActive(true);

        //if the sentence has finished typing it starts the next sentence for the Coroutine
        if (index < sentences.Length - 1)
        {
            index++;
            DialogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            DialogueText.text = "";
       //     continuebutton.SetActive(false);
        }
    }

    void TextBox()
    {
        // sets the dialogue button to false
        dialogueBox.SetActive(false);
    }
}
