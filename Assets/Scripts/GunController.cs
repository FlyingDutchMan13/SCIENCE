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


    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
