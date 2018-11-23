using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText, healthText;
    public Button pause;

    private Animator scoreAnim;


    public int playerScore = 0;

    private void Start()
    {
        scoreAnim = GetComponent<Animator>();
        //scoreAnim.SetBool("isScoreOn", false);
        scoreAnim.enabled = false;
        //print(scoreAnim.enabled = false);
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
        
        print(scoreAnim.enabled = true);
        //scoreAnim.enabled = true;
    }
} // GameUI