using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour {

    public delegate void UpdateSendAmmo(int theAmmoCount);
    public static event UpdateSendAmmo OnSendAmmo;
    public delegate void UpdateSendReloading(bool isReloading);
    public static event UpdateSendReloading OnSendReload;

    public GameObject bulletPrefab;
    public Transform[] bulletSpawn;
    public float fireTime = 0.5f;
    public Transform MuzzleFlashPrefab;

    public Sprite sprite;
    //public Sprite gunImage;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;

    private bool isFiring = false;
    private bool isReloading = false;

    //public float camShakeAmount = 0.1f;
    //CameraShake camShake;

    //public Text reloading;

    void Start()
    {
        //camShake.GetComponent<CameraShake>();
        //if(camShake == null)
        //{
        //    Debug.LogError("ERROR");
        //}

        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        //reloading.enabled = false;
    }

    public void OnAmmoCount()
    {
        if (OnSendAmmo != null)
        {
            OnSendAmmo(currentAmmo);
        }
    }

    public void OnReloading(bool reloading)
    {
        if(OnSendReload != null)
        {
            OnSendReload(isReloading);
        }
    }

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;

        currentAmmo--;

        for (int i = 0; i < bulletSpawn.Length; i++)
        {
            Instantiate(bulletPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation);
            Transform MuzzleFlash = Instantiate(MuzzleFlashPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation) as Transform;
            MuzzleFlash.parent = bulletSpawn[i];
            float size = Random.Range(0.6f, 0.9f);
            MuzzleFlash.localScale = new Vector3(size, size, 0);
            Destroy(MuzzleFlash.gameObject, 0.04f);
        }
        //camShake.Shake(camShakeAmount, 0.2f);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    void Effect()
    {
        
    }
    
	// Update is called once per frame
	private void Update () {


        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }

        OnAmmoCount();
        OnReloading(isReloading);

    }

    IEnumerator Reload()
    {
        isReloading = true;

        //reloading.enabled = true;

        Debug.Log("Reloading..");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
        //reloading.enabled = false;
    }


} // Weapon
