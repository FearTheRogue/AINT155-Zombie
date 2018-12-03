using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemySpawnedEvent : UnityEvent<Transform> { }

public class Enemy : MonoBehaviour {

    public EnemySpawnedEvent onSpawn;
    public delegate void SendKill(int theCounter);
    public static event SendKill OnSendKill;

    // Use this for initialization
    private void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);
	}

} // EnemySpawnedEvent
