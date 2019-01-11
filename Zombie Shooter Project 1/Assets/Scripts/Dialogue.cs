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

    private float idlePlayerMovement = 0;

    public TopDownCharacterController2D playerMovement;
    public ParticleSystem gateFX;
    public GameObject dialogueBox;

    public GameObject continuebutton;
    public GameObject pistolPickup;
    public GameObject Infected;
    public GameObject gate;
    public GameObject healthBar, zHealthBar;
    public GameObject pickUp;
    //public Animation FadeIn;

    public void Awake()
    {
        continuebutton.SetActive(false);
        dialogueBox.SetActive(false);
        Invoke("StartConvo", 2);
    }

    void StartConvo()
    {
        //FadeIn.enabled = true;
        continuebutton.SetActive(false);
        dialogueBox.SetActive(true);
        StartCoroutine(Type());
        //playerMovement = GameObject.Find("Player").GetComponent<TopDownCharacterController2D>();
        //playerMovement = GetComponent<TopDownCharacterController2D>();
        //playerMovement = GameObject.Find("player").GetComponent<TopDownCharacterController2D>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownCharacterController2D>();


    }

    void Update()
    {

        if (DialogueText.text == sentences[index])
        {   
            continuebutton.SetActive(true);
        }

        Time.timeScale = 1f; 
        Spawns();
        //SkipButton();
        //IdleRigidbody2D.velocity = Vector2.zero;

        //playerMovement = GameObject.Find("player").GetComponent<TopDownCharacterController2D>();

    }

    IEnumerator Type()
    {
        playerMovement.speed = idlePlayerMovement;

        DialogueText.text = "";
        foreach (char letter in sentences[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
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

    public void SkipButton()
    {
        if (index == 0 || index == 1 || index == 2 || index == 3 || index == 4 || index == 5 || index == 6 || index == 7)
        {
            index = 8;
        } else if (index == 9 || index == 10 || index == 11 || index == 12)
        {
            index = 13;
        }
            // Finish this!!!
        StartCoroutine(Type());
    }

    public void Spawns()
    {

        if(index == 8)
        {
            playerMovement.speed = 5f;
        }
        if (index == 9)
        {
            playerMovement.speed = 5f;

            Time.timeScale = 1f;
            pistolPickup.SetActive(true);
            continuebutton.SetActive(false);
        }
        else if (index == 13)
        {
            Infected.SetActive(true);
            continuebutton.SetActive(true);
        }
        else if (index == 15)
        {
            playerMovement.speed = 5f;
            zHealthBar.SetActive(true);
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
            playerMovement.speed = 5f;

            Time.timeScale = 1f;
            pickUp.SetActive(true);
            continuebutton.SetActive(false);
        }
        else if(index == 22)
        {
            gateFX.Play();
            continuebutton.SetActive(false);
        }
        else if (index == 24)
        {
            playerMovement.speed = 5f;
            dialogueBox.SetActive(false);
            continuebutton.SetActive(false);
        }
    }
}
