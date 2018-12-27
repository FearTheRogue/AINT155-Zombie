using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public Text DialogueText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    //public Transform playerMovement;
    public GameObject continuebutton;
    public GameObject pistolPickup;
    public GameObject Infected;
    public GameObject gate;
    public GameObject healthBar;
    public GameObject pickUp;
    

    void Start()
    {
        StartCoroutine(Type());
        //playerMovement = GetComponent<Transform>();
        
    }

    void Update()
    {
        
        if (DialogueText.text == sentences[index])
        {
            continuebutton.SetActive(true);
        }

        Time.timeScale = 0f;
        Spawns();
    }

    IEnumerator Type()
    {
        DialogueText.text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        //playerMovement.position = new Vector3(0,0);
            
        continuebutton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            DialogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            DialogueText.text = "";
            continuebutton.SetActive(false);
        }
    }

    public void Spawns()
    {
        if (index == 9)
        {
            Time.timeScale = 1f;
            pistolPickup.SetActive(true);
            continuebutton.SetActive(false);
        }
        else if (index == 15)
        {
            Time.timeScale = 1f;
            Infected.SetActive(true);
            continuebutton.SetActive(false);
        }
        else if(index == 17)
        {
            Time.timeScale = 1f;
            healthBar.SetActive(true);
            //continuebutton.SetActive(false);
        }
        else if (index == 18)
        {
            Time.timeScale = 1f;
            pickUp.SetActive(true);
            continuebutton.SetActive(false);
        }
    }
}
