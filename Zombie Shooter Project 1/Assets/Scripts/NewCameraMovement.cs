using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraMovement : MonoBehaviour {

    public Transform lookAt;

    // Sets the bounds for x and y
    public float boundX = 1.2f;
    public float boundY = 1.2f;
    public float speed = 0.15f;

    private Vector3 smoothing;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float dx = lookAt.position.x - transform.position.x;
        if (dx > boundX || dx < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = dx - boundX;
            }
            else
            {
                delta.x = dx + boundX;
            }
        }
        float dy = lookAt.position.y - transform.position.y;
        if (dy > boundY || dy < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = dy - boundY;
            }
            else
            {
                delta.y = dy + boundY;
            }
        }

        smoothing = transform.position + delta;
        transform.position = Vector3.Lerp(transform.position, smoothing, speed);
    }
}
