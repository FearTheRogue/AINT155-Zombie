using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentEnemies : MonoBehaviour {

    public int Enemies;

    private void OnEnable()
    {
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
        Enemies = currentNum;

    }
}
