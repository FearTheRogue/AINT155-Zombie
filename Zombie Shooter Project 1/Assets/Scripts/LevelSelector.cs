using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader_01 fader;

    public Button[] levelButtons;

    public Sprite lockedLevel;
    public Sprite LevelNum;

    void Start()
    {
        LevelNum = GetComponent<Sprite>();

        int levelReached = PlayerPrefs.GetInt("levelReached", 1); // 1 = tutorial level

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
                //LevelNum = lockedLevel;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }

}
