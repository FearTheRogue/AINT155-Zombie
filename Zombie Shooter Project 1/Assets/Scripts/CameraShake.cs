using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public void DoShake()
    {
        // Sets the shake amount for both x and y axis, and by how long for
        iTween.ShakePosition(gameObject, iTween.Hash("x", 0.1f, "y", 0.1f, "time", 0.5f));
    }

}
