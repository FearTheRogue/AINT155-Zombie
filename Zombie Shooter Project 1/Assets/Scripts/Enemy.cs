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

    public Transform target;
    public float range = 15f;

    // Creates audio clip of the infected spawning
    public AudioSource audioSource;
    public AudioClip InfectedSpawn;

    // Use this for initialization
    private void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        onSpawn.Invoke(player.transform);

        InvokeRepeating("UpdateTarget", 0f, 0.5f);


        // checks to see if it has a audio source 
        if(GetComponent<AudioSource>() != null)
        {
            // if it does, play the clip 
            GetComponent<AudioSource>().clip = InfectedSpawn;
            GetComponent<AudioSource>().Play();
        }
	}

    //void UpdateTarget()
    //{
    //    GameObject player = GameObject.FindWithTag("Player");
    //    onSpawn.Invoke(player.transform);

    //    float distanceToPlayer = Vector3.Distance(transform.position, player.transform, transform.rotation);

    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void SendZHealthData(int health)
    {
        // sets the health bar value to the current zombies health 
        enemyHealthBar.value = health;
    }
} // EnemySpawnedEvent
