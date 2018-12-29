using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemySpawnedEvent : UnityEvent<Transform> { }

public class Enemy : MonoBehaviour {

    public delegate void UpdateZHealth(int newHealth);
    public static event UpdateZHealth OnUpdateZHealth;

    public EnemySpawnedEvent onSpawn;

    // Use this for initialization
    private void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
	}

    public void SendZHealthData(int health)
    {
        if(OnUpdateZHealth != null)
        {
            OnUpdateZHealth(health);
        }
    }

} // EnemySpawnedEvent
