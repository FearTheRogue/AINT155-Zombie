using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {

    public int moveSpeed = 230; 

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
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
}
