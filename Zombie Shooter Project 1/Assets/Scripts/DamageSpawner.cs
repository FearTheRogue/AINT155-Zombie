using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawner : MonoBehaviour
{
    public Transform prefabToSpawn;

    // Use this for initialization
    public void Spawn()
    {
        float size = Random.Range(0.6f, 0.9f);
        prefabToSpawn.localScale = new Vector3 (size, size, 0);
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
    }
}
