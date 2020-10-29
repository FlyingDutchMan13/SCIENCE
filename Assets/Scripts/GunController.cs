using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;

    public float timeBetweenShots;
    private float shotCounter;

    public bool isFiring;

    public BulletController bullet;

    public int maxAmmoInGun;
    private int currentAmmoInGun;
    public int startingSpareAmmo;
    private int currentSpareAmmo;

    public float timeToReload;
    private float reloadCounter;

    public UICounter ammoInGunCounter;
    public UICounter spareAmmoCounter;

    private bool reloading;

    private void Start()
    {
        currentAmmoInGun = maxAmmoInGun;
        currentSpareAmmo = startingSpareAmmo;
        reloadCounter = timeToReload;
        ammoInGunCounter.UpdateText(currentAmmoInGun, "Ammo in gun");
        spareAmmoCounter.UpdateText(currentSpareAmmo, "Spare ammo");
    }


    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0 && !reloading)
            {
                if(currentAmmoInGun > 0)
                {
                    FireShot();
                } 
                else
                {
                    if(currentSpareAmmo > 0)
                    {
                        reloading = true;
                    }
                }
            }
        }
        if (reloading)
        {
            reloadCounter -= Time.deltaTime;
            if(reloadCounter <= 0)
            {
                ReloadGun();
            }
        }
        else
        {
            if(shotCounter > 0)
            {
                shotCounter -= Time.deltaTime;
            }
        }
    }

    private void FireShot()
    {
        shotCounter = timeBetweenShots;
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        currentAmmoInGun--;
        ammoInGunCounter.UpdateText(currentAmmoInGun, "Ammo in gun");
    }

    private void ReloadGun()
    {
        reloading = false;
        reloadCounter = timeToReload;
        int ammoToReload = maxAmmoInGun - currentAmmoInGun;
        if(ammoToReload <= currentSpareAmmo)
        {
            currentSpareAmmo -= ammoToReload;
            currentAmmoInGun += ammoToReload;
        }
        else
        {
            currentAmmoInGun += currentSpareAmmo;
            currentSpareAmmo = 0;
        }
        ammoInGunCounter.UpdateText(currentAmmoInGun, "Ammo in gun");
        spareAmmoCounter.UpdateText(currentSpareAmmo, "Spare ammo");
    }

    public void StartReload()
    {
        if (currentAmmoInGun < maxAmmoInGun)
            reloading = true;
    }
}
