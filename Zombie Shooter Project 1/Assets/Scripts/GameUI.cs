using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    public Slider healthBar;
    public Text scoreText, healthText, deathText, ammoText, ReloadingText;
    public Animator scoreAnim;

    public int playerScore = 0, ammoCount = 0;
    public int killCounter = 1;

    public bool Reloading = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        Weapon.OnSendAmmo += UpdateAmmoCount;
        Weapon.OnSendReload += UpdateReloading;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        Weapon.OnSendAmmo -= UpdateAmmoCount;
        Weapon.OnSendReload -= UpdateReloading;

        PlayerPrefs.SetInt("Score", playerScore);
    }

    private void UpdateAmmoCount(int ammo)
    {
        if (ammoText == null) return;

        ammoCount = ammo;
        ammoText.text = ammoCount.ToString();

        if (ammoCount > 5)
        {
            ammoText.color = Color.white;
        }
        else
        {
            ReloadingText.enabled = true;
            ReloadingText.text = "Press R to reload";
            ammoText.color = Color.red;
        }
    }

    private void UpdateReloading(bool reloading)
    {
        if (ReloadingText == null) return;

        //ReloadingText.text = "RELOADING";

        Reloading = reloading;

        if (reloading)
        {
            ReloadingText.text = "RELOADING";
            ReloadingText.enabled = true;
        }
        else
        {
            ReloadingText.enabled = false;
        }
        //Debug.Log(ReloadingText.text);
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    //private void UpdateZHealthBar(int zHealth)
    //{
    //    zHealthBar.value = zHealth;
    //}

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