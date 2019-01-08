using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    //public Camera main;

    //public float shakeAmount = 0;

    //void Awake()
    //{
    //    if (main == null)
    //        main = Camera.main;
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Shake(0.04f, 0.07f);
    //    }
    //}

    //public void Shake(float amt, float length)
    //{
    //    shakeAmount = amt;
    //    InvokeRepeating("BeginShake", 0, 0.01f);
    //    Invoke("StopShake", length);
    //}

    //void BeginShake()
    //{
    //    if(shakeAmount > 0)
    //    {
    //        Vector3 camPos = main.transform.position;

    //        float OffsetX = Random.value * shakeAmount * 2 - shakeAmount;
    //        float OffsetY = Random.value * shakeAmount * 2 - shakeAmount;
    //        camPos.x += OffsetX;
    //        camPos.y += OffsetY;

    //        main.transform.position = camPos;

    //    }
    //}

    //void StopShake()
    //{
    //    CancelInvoke("BeginShake");
    //    main.transform.localPosition = Vector3.zero;
    //}
}
