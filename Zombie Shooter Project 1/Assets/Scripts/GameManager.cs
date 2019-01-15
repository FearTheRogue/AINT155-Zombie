using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //public int playerLife;

    public void StartGame()
    {
        SceneFader.instance.LoadLevel("Zombie Shooter Level 1");
        //SceneManager.LoadScene("Zombie Shooter Level 1");
        //PlayerPrefs.SetInt("playerCurrentLife", playerLife);
    }

    public void StartLevel2()
    {
        SceneFader.instance.LoadLevel("Zombie Shooter Level 2");
        //SceneManager.LoadScene("Zombie Shooter Level 1");
        //PlayerPrefs.SetInt("playerCurrentLife", playerLife);
    }

    public void WinGame()
    {
        SceneFader.instance.LoadLevel("Game Win");
    }

    public void EndGame()
    {
        //SceneManager.LoadScene("Game Over");
        SceneFader.instance.LoadLevel("Game Over");
    }

    public void BackToMainMenu()
    {
        //SceneManager.LoadScene("Main Menu");
        SceneFader.instance.LoadLevel("Main Menu");
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("Zombie Shooter Level 1");
        SceneFader.instance.LoadLevel("Zombie Shooter Level 1");
    }

    public void tutorialLevel()
    {
        //SceneManager.LoadScene("Test Tutorial Level (Dialogue Change)");
        SceneFader.instance.LoadLevel("Test Tutorial Level (Dialogue Change)");
    }
    
    public void tutorialComp()
    {
        //SceneManager.LoadScene("Zombie Shoot Level 1");
        SceneFader.instance.LoadLevel("Zombie Shoot Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
