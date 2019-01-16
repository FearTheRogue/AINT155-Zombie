using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonEffect : MonoBehaviour {

    // Creates an audio source and audio clips 
    public AudioSource btnFX;
    public AudioClip buttonClick, buttonHover;

    public void Hover()
    {
        // plays the clip if mouse hovers over the button 
        btnFX.PlayOneShot(buttonHover);
    }

    public void Click()
    {
        // plays the clip if mouse hovers over the button
        btnFX.PlayOneShot(buttonClick);
    }

}
