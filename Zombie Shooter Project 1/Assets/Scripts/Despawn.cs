using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {

    public float time;
        
    void Start()
    {
        // Destroys the game object after the time has been set
        Destroy(gameObject, time);
    }
}
