using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonEffect : MonoBehaviour {

    public AudioSource btnFX;
    public AudioClip buttonClick, buttonHover;

    public void Hover()
    {
        btnFX.PlayOneShot(buttonHover);
    }

    public void Click()
    {
        btnFX.PlayOneShot(buttonClick);
    }

}
