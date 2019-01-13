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

    public AudioSource audioSource;
    public AudioClip InfectedSpawn;

    public List<Transform> drop = new List<Transform>(); 

    // Use this for initialization
    private void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);

        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().clip = InfectedSpawn;
            GetComponent<AudioSource>().Play();
        }
	}

    public void SendZHealthData(int health)
    {
        enemyHealthBar.value = health;
    }

    private void OnDestroy()
    {
        if(GetComponent<Enemy>().drop != null)
        Instantiate(drop[Random.Range(0, drop.Count - 1)], transform.position, Quaternion.identity);
    }

} // EnemySpawnedEvent
