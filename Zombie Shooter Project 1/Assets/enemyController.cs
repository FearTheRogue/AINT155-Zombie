using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {

    public Text SpawnedEnemies;
    public Text SpawnedBoss;
    public int enemiesLeft = 0;
    public int bossEnemiesLeft = 0;

    // Use this for initialization
    void Start () {
        enemiesLeft = 10;
        bossEnemiesLeft = 10;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        GameObject[] bossEnemies = GameObject.FindGameObjectsWithTag("BossEnemy");
        bossEnemiesLeft = bossEnemies.Length;

        SpawnedEnemies.text = "Infected Left: " + enemiesLeft;
        SpawnedBoss.text = "Tough Infected Left: " + bossEnemiesLeft;
	}
}
