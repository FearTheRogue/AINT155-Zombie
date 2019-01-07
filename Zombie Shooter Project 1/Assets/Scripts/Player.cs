using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null) 
        {
            OnUpdateHealth(health);
        }
    }

} // Player
