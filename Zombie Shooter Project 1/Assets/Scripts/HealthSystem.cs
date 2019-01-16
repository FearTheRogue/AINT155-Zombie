using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour {

    public int health = 10;
    public UnityEvent onDie;
    public OnDamagedEvent OnDamaged;
    //public int currentHealth;

    //void Start()
    //{
    //    currentHealth = health;
    //}

    public void TakeDamage(int damage)
    {
        
    //    print(currentHealth);

    //if(currentHealth >= health)
    //    {
    //        health = 50;
    //    }

        health -= damage;


        OnDamaged.Invoke(health);

    

        //print(health);

        if (health < 1)
        {
            onDie.Invoke();
            //SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
        }
    }
} // HealthSystem
