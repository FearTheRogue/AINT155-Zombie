using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //public int playerLife;

        // Starts the game

    public void StartGame()
    {
        SceneFader.instance.LoadLevel("Zombie Shooter Level 1");
        //SceneManager.LoadScene("Zombie Shooter Level 1");
        //PlayerPrefs.SetInt("playerCurrentLife", playerLife);
    }

    // starts level 2
    public void StartLevel2()
    {
        SceneFader.instance.LoadLevel("Zombie Shooter Level 2");
        //SceneManager.LoadScene("Zombie Shooter Level 1");
        //PlayerPrefs.SetInt("playerCurrentLife", playerLife);
    }

    // goes to the win scene
    public void WinGame()
    {
        SceneFader.instance.LoadLevel("Game Win");
    }

    // goes to the game over scene
    public void EndGame()
    {
        //SceneManager.LoadScene("Game Over");
        SceneFader.instance.LoadLevel("Game Over");
    }

    //returns to main menu
    public void BackToMainMenu()
    {
        //SceneManager.LoadScene("Main Menu");
        SceneFader.instance.LoadLevel("Main Menu");
    }

    // restarts the level
    public void RestartGame()
    {
        //SceneManager.LoadScene("Zombie Shooter Level 1");
        SceneFader.instance.LoadLevel("Zombie Shooter Level 1");
    }

    // goes to the tutorial level
    public void tutorialLevel()
    {
        //SceneManager.LoadScene("Test Tutorial Level (Dialogue Change)");
        SceneFader.instance.LoadLevel("Test Tutorial Level (Dialogue Change)");
    }
    
    // not used
    public void tutorialComp()
    {
        //SceneManager.LoadScene("Zombie Shoot Level 1");
        SceneFader.instance.LoadLevel("Zombie Shoot Level 1");
    }

    // closes the application
    public void ExitGame()
    {
        Application.Quit();
    }

}
