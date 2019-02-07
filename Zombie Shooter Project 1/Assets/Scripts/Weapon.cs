using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Weapon : MonoBehaviour {

    // send the delegate and event for the ammo count and a bool reloading
    public delegate void UpdateSendAmmo(int theAmmoCount);
    public static event UpdateSendAmmo OnSendAmmo;
    public delegate void UpdateSendReloading(bool isReloading);
    public static event UpdateSendReloading OnSendReload;

    public GameObject bulletPrefab;
    public Transform[] bulletSpawn;
    public float fireTime = 0.5f;
    public Transform MuzzleFlashPrefab;

    public Sprite sprite;
    public Sprite gunImage;

   // public Animator MiniGunAnim;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;

    // sets the audio clips 
    public AudioClip fireSound;
    public AudioClip reloadSound;

    private bool isFiring = false;
    private bool isReloading = false;
    public bool isPausedUI = false;

    public void Start()
    {
        // sets the current ammo to the max ammo 
        currentAmmo = maxAmmo;

       // if (GetComponent<Animator>() != null)
         //  MiniGunAnim = GetComponent<Animator>();
        //MiniGunAnim.SetBool("isFiring", false);
    }

    private void OnEnable()
    {
        isReloading = false;
        pauseMenu.OnSendPauseBool += UpdatePauseBool;
    }

    private void OnDisable()
    {
        pauseMenu.OnSendPauseBool -= UpdatePauseBool;
    }

    private void UpdatePauseBool(bool isPaused)
    {
        isPausedUI = isPaused;
    }

    public void OnAmmoCount()
    {
        if (OnSendAmmo != null)
        {
            // send the current ammo 
            OnSendAmmo(currentAmmo);
        }
    }

    public void OnReloading(bool reloading)
    {
        if(OnSendReload != null)
        {
            // send whether the gun is reloading
            OnSendReload(isReloading);
        }
    }

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        if (isPausedUI)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
        }
        else
        {

        isFiring = true;
        // current ammo is taken away 
        currentAmmo--;

        for (int i = 0; i < bulletSpawn.Length; i++)
        {
            Instantiate(bulletPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation);
            // adds a muzzleflash to each bullet spawn
            Transform MuzzleFlash = Instantiate(MuzzleFlashPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation) as Transform;
            MuzzleFlash.parent = bulletSpawn[i];
            // randomizes each muzzleflash slightly
            float size = Random.Range(0.6f, 0.9f);
            MuzzleFlash.localScale = new Vector3(size, size, 0);
            // gives the muzzleflash z rotation and adds 90
            MuzzleFlash.eulerAngles = new Vector3(MuzzleFlash.eulerAngles.x, MuzzleFlash.eulerAngles.y, MuzzleFlash.eulerAngles.z + 90);
            // destroys the muzzel flash after the given time
            Destroy(MuzzleFlash.gameObject, 0.04f);
        }
            // sends a message to shake the camera 
            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("DoShake");

        if (GetComponent<AudioSource>() != null)
        {
            // plays the firing sound
            GetComponent<AudioSource>().clip = fireSound;
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
        }
    }

    // Update is called once per frame
    public void Update () {
        print(isPausedUI + " From Weapon Script");

        OnReloading(isReloading);
        // if the player presses R it force reloades 
        forceReload();
        
        // if is the gun is already reloading, return it
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            // if the ammo is = to 0 start reloading
            StartCoroutine(Reload());
            return;
        }

        // get the mouse button for firing
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                // calls the fire method
                Fire();
                //MiniGunAnim.SetBool("isMiniGunFiring", true);
            }
        }
        // sends the updated ammo count
        OnAmmoCount();
    }

    private void forceReload()
    {
        // stops the player from reloading if the current ammo is full
        if (currentAmmo == maxAmmo)
        {
            return;
        }
        else
        { 
            // sets the reloading key
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        //reloading.enabled = true;

        if (GetComponent<AudioSource>() != null)
        {
            // plays the reloading clip
            GetComponent<AudioSource>().clip = reloadSound;
            GetComponent<AudioSource>().Play();
            //Debug.Log("Reloading Sound from IEnumarator");
        }

        yield return new WaitForSeconds(reloadTime);
         
        // sets the current ammo back to max
        currentAmmo = maxAmmo;

        isReloading = false;
        //reloading.enabled = false;
    }


} // Weapon
