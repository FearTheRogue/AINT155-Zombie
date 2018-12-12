
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour {

    public UnityEvent onTriggerEnter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter.Invoke();
    }
}
