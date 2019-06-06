using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {

    public int moveSpeed = 230;
    public int damage = 10;

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sends a message to healthSystem script, to say how much damage to be taken off, it collided
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);

        Debug.Log("This is being called..");



        // then destroys itself
        Die();
    }

    private void OnBecameInvisible()
    {
        // if the bullet goes outside of the bounds of the screen, it will destroy itself
        Die();
        Debug.Log("Bullet Went off the screen!");
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
