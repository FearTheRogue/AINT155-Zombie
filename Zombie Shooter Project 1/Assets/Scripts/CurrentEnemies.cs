using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEnemies : MonoBehaviour {

    public int EnemiesActive;
    public Transform[] Spawners;

    Spawner spawnerScript;

    public Text CurrentEnemiesText;


    void Start()
    {
        Spawners = spawnerScript.GetComponentsInChildren<Transform>();
    }


    void Update()
    {
        foreach (Transform enemy in Spawners)
        {
            CurrentEnemiesText.text = enemy.ToString();
        }
    }

} // CurrentEnemies
