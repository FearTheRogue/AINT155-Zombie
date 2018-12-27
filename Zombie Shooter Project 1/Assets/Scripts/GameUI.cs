using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    public Slider healthBar;
    public Text scoreText, healthText, deathText;
    
    //public Button pause; //Needs to be Implemented

    public Animator scoreAnim;

    public int playerScore = 0;
    public int killCounter = 1;

    private void Start()
    {
        Time.timeScale = 1f;
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
        PlayerPrefs.SetInt("Score", playerScore);
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

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

} // GameUI