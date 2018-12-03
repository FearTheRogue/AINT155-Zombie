using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText, healthText, deathText;
    
    //public Button pause;

    public Animator scoreAnim;

    public int playerScore = 0;
    public int killCounter = 1;

    private void Start()
    {
        //scoreAnim = GetComponent<Animator>();
        //scoreAnim.SetBool("isScoreOn", false);
        //print(scoreAnim.enabled = false);
    }

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        Enemy.OnSendKill += UpdateCounter;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        Enemy.OnSendKill -= UpdateCounter;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {   
        playerScore += theScore;
        scoreText.text = "SCORE: " + playerScore.ToString();
        scoreAnim.SetTrigger("ScoreTrigger");
    }

    private void UpdateCounter(int theCounter)
    {
        killCounter += theCounter;
        deathText.text = "x " + killCounter.ToString();
    }
} // GameUI