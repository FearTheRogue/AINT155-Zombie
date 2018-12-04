using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText, healthText, deathText;
    
    //public Button pause; //Needs to be Implemented

    public Animator scoreAnim;

    public int playerScore = 0;
    public int killCounter = 1;

    private void Start()
    {

    }

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
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
        deathText.text = "x " + killCounter++.ToString();
    }
} // GameUI