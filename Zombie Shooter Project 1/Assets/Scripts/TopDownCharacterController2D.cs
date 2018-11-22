using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    //private Animator walkAnim;

    public float speed = 5.0f;
    new Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
      //  walkAnim = GetComponent<Animator>();
      //  walkAnim.SetBool("isWalking", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

       // Update();

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;

	}

    //private void Update()
    //{
    //    walkAnim.SetBool("isWalking", true);
   // }

} // TopDownCharacterController2D
