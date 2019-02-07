using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    public Slider healthBar;

    [Header("Text Attributes")]
    public Text scoreText;
    public Text healthText;
    public Text deathText;
    public Text ammoText;
    public Text ReloadingText;
    public Text healthRemainingText;
    public Text spawnersDestroyedText;

    [Header("Animation Attributes")]
    public Animator scoreAnim;
    public Animator LevelTextAnim;

    public GameManager gameManager;

    //public Sprite fireRate, Damage, Invinciblity, Stamina;

    [Header("Int Attributes")]
    public int playerScore = 0;
    public int ammoCount = 0;
    public int spawnCount = 0;
    public int maxSpawners = 0;
    public int killCounter = 0;
    
    public bool Reloading = false;


    public float pickuDisplayTimer = 15;
    public Sprite[] pickupImages;

    public Image pickupImage;

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

        if(LevelTextAnim != null)
        LevelTextAnim.SetTrigger("LevelTextTrigger");

        if(pickupImage != null)
        pickupImage.enabled = false;
    }

    private void OnEnable()
    {
        // Retrieves the information 
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
        Weapon.OnSendAmmo += UpdateAmmoCount;
        Weapon.OnSendReload += UpdateReloading;
        SpawnersDestroyed.OnSendDestroyed += UpdateSpawnDestroy;
        Pickup.OnPickupCollected += OnPickupCollected;
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
    private void UpdateSpawnDestroy(int spawn)
    {
        spawnCount += spawn;
        // maxSpawners = maxSpawn;

        enemyController enemies = new enemyController();
        int spawnedInfected = enemies.enemiesLeft;
        enemyController bossEnemies = new enemyController();
        int spawnedBossInfected = bossEnemies.bossEnemiesLeft;

        if(spawnedInfected == 0 && spawnCount == maxSpawners && spawnedBossInfected == 0)
        {
            gameManager.WinGame();
        }

        //if(spawnCount == maxSpawners)
        //{
        //    gameManager.WinGame();
        //    //Invoke("winGame", 2);
        //}
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

    public void QuitGame()
    {
        // sets the timescale to 1 and loads the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void OnPickupCollected(PickupType type)
    {
        
        switch (type)
        {
            case PickupType.Damage:
                pickupImage.sprite = pickupImages[0];
                break;
            case PickupType.Invincible:
                pickupImage.sprite = pickupImages[1];
                break;
            case PickupType.AttackSpeed:
                pickupImage.sprite = pickupImages[2];
                break;
            case PickupType.MoveSpeed:
                pickupImage.sprite = pickupImages[3];
                break;
            default:
                break;
        }
        pickupImage.enabled = true;

        Invoke("TurnOffPickupDisplay", pickuDisplayTimer);
    }

    void TurnOffPickupDisplay()
    {
        pickupImage.enabled = false;
    }

} // GameUI