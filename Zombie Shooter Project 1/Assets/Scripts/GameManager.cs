using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Zombie Shooter Level 1");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Zombie Shooter Level 1");
    }

    public void tutorialLevel()
    {
        SceneManager.LoadScene("Test Tutorial Level (Dialogue Change)");
    }
    
    public void tutorialComp()
    {
        SceneManager.LoadScene("Zombie Shoot Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
