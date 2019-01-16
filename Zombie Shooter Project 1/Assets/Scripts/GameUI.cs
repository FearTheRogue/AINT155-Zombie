using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    public Slider healthBar;
    public Text scoreText, healthText, deathText, ammoText, ReloadingText, healthRemainingText, spawnersDestroyedText;
    public Animator scoreAnim;

    //public Sprite fireRate, Damage, Invinciblity, Stamina;

    public AudioSource bg_sound;

    public int playerScore = 0, ammoCount = 0, spawnCount = 0, maxSpawners = 0;
    public int killCounter = 0;

    public bool Reloading = false;

    // updates the spawns destroyed text 
    public void Update()
    {
        if(spawnersDestroyedText != null)
        spawnersDestroyedText.text = "SPAWNERS DESTROYED: " + spawnCount + " / " + maxSpawners;
        
    }

    private void Start()
    {
        // sets the time scale to 1
        Time.timeScale = 1f;
        // plays the background music 
       bg_sound.Play(); 
        
    }

    private void OnEnable()
    {
        // Retrieves the information 
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        Weapon.OnSendAmmo += UpdateAmmoCount;
        Weapon.OnSendReload += UpdateReloading;
        SpawnersDestroyed.OnSendDestroyed += UpdateSpawnDestroy;
    }

    private void OnDisable()
    {
        // Retrieves the information
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
        Weapon.OnSendAmmo -= UpdateAmmoCount;
        Weapon.OnSendReload -= UpdateReloading;
        SpawnersDestroyed.OnSendDestroyed -= UpdateSpawnDestroy;

        // sets the players score 
        PlayerPrefs.SetInt("Score", playerScore);
        //PlayerPrefs.SetInt("KillCounter", killCounter);
    }

    private void UpdateAmmoCount(int ammo)
    {
        if (ammoText == null) return;

        ammoCount = ammo;
        // puts the ammo count into the ammo text
        ammoText.text = ammoCount.ToString();

        // if the ammo is less than 5 then text turns red if its above 5 its white 
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

    // if the destroyed spawners = to the max spawnwers, invoke win scene 
    private void UpdateSpawnDestroy(int spawn, int maxSpawn)
    {
        spawnCount += spawn;
        Debug.Log(spawnCount);
        maxSpawners = maxSpawn;


        if(spawnCount == maxSpawners)
        {
            Invoke("winGame", 2);
        }
    }

    // goes to win scene
    private void winGame()
    {
        GetComponent<GameManager>().WinGame();
    }

    private void UpdateReloading(bool reloading)
    {
        if (ReloadingText == null) return;

        //ReloadingText.text = "RELOADING";

        Reloading = reloading;
        // if currently reloading is true, write "RELOADING" in the text 
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


    // sets the players health 
    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
        //PlayerPrefs.GetInt("playerCurrentLife", health);

        // writes the players current health in text 
        if (healthRemainingText != null)
        healthRemainingText.text = healthBar.value + " / 50";
    }

    // retrieves the score and writes it into the text box and plays an animation
    private void UpdateScore(int theScore)
    {   
        playerScore += theScore;
        scoreText.text = "SCORE: " + playerScore.ToString();
        scoreAnim.SetTrigger("ScoreTrigger");
        // counts the kills by one when the method is called
        deathText.text = "x " + killCounter++.ToString();
    }

    public void PauseGame()
    {
        // sets the timescale to 0, to stop the game and sets the pause panel active
        Time.timeScale =  0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        // sets the timescale back to 1 and deactives the pause panel
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        // sets the timescale to 1 and loads the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

} // GameUI