using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    //private Animator gunAnim;

    //private void Start()
    //{
    //    if (gunAnim != null)
    //    gunAnim = GetComponent<WeaponManager>().GunAnim;
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (gunAnim != null)
    //            gunAnim.SetBool("isMiniGunFiring", true);
    //    }
    //    else
    //    {
    //        if (gunAnim != null)
    //            gunAnim.SetBool("isMiniGunFiring", false);
    //    }
    //}
   
    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null) 
        {
            //OnUpdateHealth(PlayerPrefs.GetInt("playerCurrentLife", health));
            
            OnUpdateHealth(health);
        }
    }

} // Player
