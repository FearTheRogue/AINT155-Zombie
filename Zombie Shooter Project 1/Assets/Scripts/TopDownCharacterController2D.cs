using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public Animator walkAnim;

    public float speed = 5.0f;
    new Rigidbody2D rigidbody2D;



	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        walkAnim.SetBool("isWalking_02", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;

        if (rigidbody2D.velocity == Vector2.zero)
        {
            walkAnim.SetBool("isWalking_02", false);
        }
        else
        {
            walkAnim.SetBool("isWalking_02", true);
        }
	}
} // TopDownCharacterController2D
