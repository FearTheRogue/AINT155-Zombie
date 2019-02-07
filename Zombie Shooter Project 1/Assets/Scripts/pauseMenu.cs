using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class pauseMenu : MonoBehaviour {

    public delegate void UpdateSendPauseBool(bool isPaused);
    public static event UpdateSendPauseBool OnSendPauseBool;

    public GameObject ui;

    bool GamePaused;

    GameUI gameUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }

        OnPauseBool(GamePaused);
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            GamePaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            GamePaused = false;
        }
        //print(ui.activeSelf);
        //print(GamePaused);
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene("Main Menu");
    }

    public void OnPauseBool(bool Paused)
    {
        if (OnSendPauseBool != null)
        {
            OnSendPauseBool(GamePaused);
        }
    }
}
