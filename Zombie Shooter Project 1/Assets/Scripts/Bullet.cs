using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Sets the initial bullet speed
    public float moveSpeed = 100.0f;
    // Sets how much damage the bullet will do
    public int damage = 1;

	// Use this for initialization
	private void Start () {
        // Gets the rigidbody from the bullet GameObject and adds force to move it
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sends a message to healthSystem script, to say how much damage to be taken off, it collided
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        // then destroys itself
        Die();
    }

    private void OnBecameInvisible()
    {
        // if the bullet goes outside of the bounds of the screen, it will destroy itself
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
} //Bullet
