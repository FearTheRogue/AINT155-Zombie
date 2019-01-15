using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour
{

    public Text DialogueText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject dialogueBox;

    //public GameObject continuebutton, skipbutton;


    public void Awake()
    {
        //if (skipbutton != null)
        //    skipbutton.SetActive(false);
        //continuebutton.SetActive(false);
        dialogueBox.SetActive(false);
        //Invoke("StartConvo", 2);
    }

    public void StartConvo()
    {
       // continuebutton.SetActive(false);
       // if (skipbutton != null)
        //    skipbutton.SetActive(true);
        dialogueBox.SetActive(true);
        StartCoroutine(Type());
    }

    void Update()
    {

     //   if (DialogueText.text == sentences[index])
      //  {   
          //  continuebutton.SetActive(true);
     //   }

        Time.timeScale = 1f;


    }

    IEnumerator Type()
    {
        DialogueText.text = "";
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
        dialogueBox.SetActive(false);
    }

    //public void SkipButton()
    //{
    //    if (index == 0 || index == 1 || index == 2 || index == 3 || index == 4 || index == 5 || index == 6 || index == 7)
    //    {
    //        index = 8;
    //    } else if (index == 9 || index == 10 || index == 11 || index == 12)
    //    {
    //        index = 13;
    //    }
    //        // Finish this!!!
    //    StartCoroutine(Type());
    //}
}
