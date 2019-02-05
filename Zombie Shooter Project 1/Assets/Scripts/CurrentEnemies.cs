using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEnemies : MonoBehaviour {

    // script isnt currently doing anything

        // creates an int for how many enemies there are spawned in the level
    public int Enemies;

    private void OnEnable()
    {
        print(transform.childCount);
        // gets the OnSendEnemyNum for Spawner script and adds an enemy into the currentNum
        Spawner.OnSendEnemyNum += UpdateEnemyNum;
        //HealthSystem.OnSendEnemyNum += UpdateEnemy;
    }

    public void OnDisable()
    {
        Spawner.OnSendEnemyNum -= UpdateEnemyNum;
        //HealthSystem.OnSendEnemyNum -= UpdateEnemy;
    }

    private void UpdateEnemyNum(int currentNum)
    {
        // Makes the currentNum = to the Enemies
        Enemies = currentNum;

    }
} // CurrentEnemies
