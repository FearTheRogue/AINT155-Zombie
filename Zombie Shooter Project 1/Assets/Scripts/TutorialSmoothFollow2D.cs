using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float smoothing = 5.0f;
    public Camera main;
	
	// Update is called once per frame
	void FixedUpdate () {


        if (main.transform.position.x == -2)
        {
            main.transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            Vector3 newPos = new Vector3(target.position.x, transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.001f));
        }
    }

} // SmoothFollow2D
