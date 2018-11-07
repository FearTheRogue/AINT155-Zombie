using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator gunAnim;

	// Use this for initialization
	private void Start () {
        gunAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }
	}
} // Player
