﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {

    public Text SpawnedEnemies;
    int enemiesLeft = 0;

    // Use this for initialization
    void Start () {
        enemiesLeft = 10;
        

    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        SpawnedEnemies.text = "Infected Left: " + enemiesLeft;
        	
	}
}
