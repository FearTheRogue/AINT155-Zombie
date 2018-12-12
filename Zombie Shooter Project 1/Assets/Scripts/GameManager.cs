using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //public GameObject tutorialcomp;

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
        SceneManager.LoadScene("Tutorial Level");
    }
    
    public void tutorialComp()
    {
        //tutorialcomp = transform.GetComponents<Collider2D>();
        SceneManager.LoadScene("Zombie Shoot Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
