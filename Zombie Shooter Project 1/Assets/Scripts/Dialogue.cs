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

    public GameObject continuebutton;
    public GameObject pistolPickup;
    public GameObject Infected;
    public GameObject gate;
    public GameObject healthBar;
    public GameObject pickUp;



    void Start()
    {
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
        else if (index == 15)
        {
            playerMovement.speed = 5f;

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
            playerMovement.speed = 5f;

            Time.timeScale = 1f;
            pickUp.SetActive(true);
            continuebutton.SetActive(false);
        }
    }
}
