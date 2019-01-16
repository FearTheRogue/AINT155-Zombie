using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawner : MonoBehaviour
{
    public Transform prefabToSpawn;

    // Use this for initialization
    public void Spawn()
    {
        // Sets a random size between 0.6f and 0.9f
        float size = Random.Range(0.6f, 0.9f);
        // Creates a new Vector 3 and puts it into the prefabs local scale
        prefabToSpawn.localScale = new Vector3 (size, size, 0);
        // Instantiates the prefab
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
    }
}
