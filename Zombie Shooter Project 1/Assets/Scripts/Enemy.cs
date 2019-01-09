using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class EnemySpawnedEvent : UnityEvent<Transform> { }

public class Enemy : MonoBehaviour {

    public Slider enemyHealthBar;

    public EnemySpawnedEvent onSpawn;

    // Use this for initialization
    private void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
	}

    public void SendZHealthData(int health)
    {
        enemyHealthBar.value = health;
    }

} // EnemySpawnedEvent
