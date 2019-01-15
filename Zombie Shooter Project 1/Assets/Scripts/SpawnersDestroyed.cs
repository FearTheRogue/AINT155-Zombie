using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersDestroyed : MonoBehaviour {

    public delegate void SendDestroyed(int theSpawner, int maxSpawn);
    public static event SendDestroyed OnSendDestroyed;

    public int spawner = 1;
    public int max = 5;

    public void OnDestroyed()
    {
        if(OnSendDestroyed != null)
        {
            OnSendDestroyed(spawner, max);
        }
    }



}
