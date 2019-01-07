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

    //public Transform GunImage;

    public Animator scoreAnim;

    public int playerScore = 0, ammoCount = 0;
    public int killCounter = 1;

    public bool Reloading = false;

    private void Start()
    {
        Time.timeScale = 1f;

       // GunImage = transform.parent.GetComponent<Weapon>().gunImage;

       // GunImage.GetComponent<Image>();

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
        ammoCount = ammo;
        ammoText.text = ammoCount.ToString();

        if (ammoCount > 5)
        {
            ammoText.color = Color.white;
        }
        else
        {
            ammoText.color = Color.red;
        }
    }

    private void UpdateReloading(bool reloading)
    {
        ReloadingText.text = "RELOADING...";

        //reloading = true;

        if (reloading == true)
        {
            //Reloading = true;
            //Debug.Log(reloading);
            ReloadingText.enabled = true;
        }
        else
        {
            //Reloading = false;
            ReloadingText.enabled = false;
        }
       // Debug.Log(reloading);
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