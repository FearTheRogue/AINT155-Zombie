using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Creates a text calles DialogueText 
    public Text DialogueText;
    // Creates a string array 
    public string[] sentences;
    // Creates an int 
    private int index;
    // Creates a float for the speed of the text 
    public float typingSpeed;
    
    // Creates player idle movement and set to 0
    private float idlePlayerMovement = 0;

    // Gets a reference from TopDownCharacterController2D
    public TopDownCharacterController2D playerMovement;
    public ParticleSystem gateFX;
    public GameObject dialogueBox;

    public GameObject continuebutton, skipbutton;
    public GameObject pistolPickup;
    public GameObject Infected;
    public GameObject gate, box, box2;
    public GameObject healthBar, zHealthBar;
    public GameObject pickUp;
    //public Animation FadeIn;

        // Sets the skipbutton, continuebutton and dialogouebox to false and waites 2 seconds to run the StartConvo Method 
    public void Awake()
    {
        if(skipbutton != null)
        skipbutton.SetActive(false);
        continuebutton.SetActive(false);
        dialogueBox.SetActive(false);
        Invoke("StartConvo", 2);
        //Time.timeScale = 1f;
    }

    void StartConvo()
    {
        //FadeIn.enabled = true;
        // Sets the continue button to false
        continuebutton.SetActive(false);
        // if there is a skip button attached, set it to true 
        if (skipbutton != null)
            skipbutton.SetActive(true);
        // Sets the dialoguebox to true
        dialogueBox.SetActive(true);
        // Starts the typing of each sentence 
        StartCoroutine(Type());

        // retrieves the players movement and places it into the variable
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownCharacterController2D>();
    }

    void Update()
    {
        // If dialogue text is = to sentences 
        if (DialogueText.text == sentences[index])
        {   
            // sets the continue button to true
            continuebutton.SetActive(true);
        }

        //Time.timeScale = 1f;
         
        // Calls the Spawn() method
        Spawns();
        
        //SkipButton();
        //IdleRigidbody2D.velocity = Vector2.zero;

        //playerMovement = GameObject.Find("player").GetComponent<TopDownCharacterController2D>();

    }

    IEnumerator Type()
    {
        // the the couroutine is called, the movement speed of the player is set to 0
        playerMovement.speed = idlePlayerMovement;

        // dialoguebox is emptied
        DialogueText.text = "";
        // each character in sentences has an index, and it typing one by one at the speed of typingSpeed
        foreach (char letter in sentences[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        // sets the continue to false and the skip button to true  
        continuebutton.SetActive(false);
        skipbutton.SetActive(true);
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
            continuebutton.SetActive(false);
        }
    }

    public void SkipButton()
    {
        // if skip button is pressed, it sets the continue button to false 
        continuebutton.SetActive(false);
        // if the index = to any of these numbers and the skip button is pressed, it sets the index number
        if (index == 0 || index == 1 || index == 2 || index == 3 || index == 4 || index == 5 || index == 6 || index == 7)
        {
            index = 8;
            continuebutton.SetActive(false);
        } else if (index == 9 || index == 10 || index == 11 || index == 12)
        {
            index = 13;
            continuebutton.SetActive(false);
        } else if (index == 19 || index == 20 || index == 21) 
        {
            index = 22;
            continuebutton.SetActive(false);
        }
            // starts the corouting again
        StartCoroutine(Type());
    }

    public void Spawns()
    {
        // if any of the indexs = to these numbers, it will spawn 
        if(index == 8)
        {
            playerMovement.speed = 5f;
            skipbutton.SetActive(false);
        }
        if (index == 9)
        {
            playerMovement.speed = 5f;

            //Time.timeScale = 1f;
            pistolPickup.SetActive(true);
            continuebutton.SetActive(false);
            skipbutton.SetActive(false);
        }
        else if (index == 13)
        {
            Infected.SetActive(true);
            continuebutton.SetActive(true);
            skipbutton.SetActive(false);
        }
        else if(index == 14)
        {
            skipbutton.SetActive(false); 
        }
        else if (index == 15)
        {
            playerMovement.speed = 5f;
            box.SetActive(false);
            skipbutton.SetActive(false);
            zHealthBar.SetActive(true);
            continuebutton.SetActive(false);
        }
        else if (index == 16)
        {
            skipbutton.SetActive(false);
        }
        else if(index == 17)
        {
            //Time.timeScale = 1f;
            healthBar.SetActive(true);
            skipbutton.SetActive(false);
            //continuebutton.SetActive(false);
        }
        else if (index == 18)
        {
            playerMovement.speed = 5f;

            //Time.timeScale = 1f;
            skipbutton.SetActive(false);
            pickUp.SetActive(true);
            continuebutton.SetActive(false);
        }
        else if(index == 22)
        {
            box2.SetActive(false);
            gateFX.Play();
            continuebutton.SetActive(false);
            skipbutton.SetActive(false);
        }
        else if(index == 23)
        {
            skipbutton.SetActive(false);
        }
        else if (index == 24)
        {
            playerMovement.speed = 5f;
            dialogueBox.SetActive(false);
            skipbutton.SetActive(false);
            continuebutton.SetActive(false);
        }
    }
}
