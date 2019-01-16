using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour {

    public Slider healthBar;
    //public int health;
	
	public void SliderHealth(int health)
    {
        // sets the sliders value to health
        healthBar.value = health;
    }
}
