using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersDestroyed : MonoBehaviour {

    // sets up a delegate and an event for sending the spawners data 
    public delegate void SendDestroyed(int theSpawner, int maxSpawn);
    public static event SendDestroyed OnSendDestroyed;

    // sets the max and spawner value
    public int spawner = 1;
    public int max = 4;

    public void OnDestroyed()
    {
        if(OnSendDestroyed != null)
        {
            // sends the ints of spawner and max
            OnSendDestroyed(spawner, max);
        }
    }



}
