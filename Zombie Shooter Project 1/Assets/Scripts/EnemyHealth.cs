using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Slider enemyHealthBar;

    private void OnEnable()
    {
        Enemy.OnUpdateZHealth += UpdateZHealthBar; 
    }

    private void OnDisable()
    {
        Enemy.OnUpdateZHealth -= UpdateZHealthBar;
    }

    private void UpdateZHealthBar(int health)
    {
        enemyHealthBar.value = health;
    }

}
