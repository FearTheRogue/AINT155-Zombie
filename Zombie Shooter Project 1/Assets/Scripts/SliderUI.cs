using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour {

    public Slider healthBar;
    //public int health;
	
	public void SliderHealth(int health)
    {
        healthBar.value = health;
    }
}
