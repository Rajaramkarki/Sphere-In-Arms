using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    //[SerializeField] private Transform muzzle;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;//here, the action of shootInput from "PlayerShoot.cs" is being incremented by calling the Shoot() method in "Gun.cs"
        PlayerShoot.reloadInput += StartReload; //subscribing the "reload" event to the call, similar to "shooting".
    }

    public void StartReload()
    {
        if (!gunData.reloading && gunData.currentAmmo != gunData.magSize)
        {
            //reloading...
            StartCoroutine(Reload());
            //coroutine - spreads tasks across several frames
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        //a subroutine made from IEnumerator to make a player wait a few moment and "refill" the mag.
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
        Debug.Log("Reloading Complete");
    }

    private bool CanShoot()
    {
        //checking if we are able to shoot: i.e. if we are not reloading and the time between bullets fired is viable:
        if(!gunData.reloading && (timeSinceLastShot > 1f / (gunData.fireRate / 60f)))
        {
            return true;
        }
        return false;
  
    }

    public void Shoot()
    {
        if(gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {

                    Debug.Log(hitInfo.transform.name);
                    Target damageable = hitInfo.transform.GetComponent<Target>();
                    
                    
                    //Using the particle system "muzzleFlash" to indicate shooting.
                    muzzleFlash.Play();

                    //and damaging the object with the amount of damage as specified in the gunData.

                    //damageable?.TakeDamage(gunData.damage);

                    if (damageable != null)
                    {
                        damageable.TakeDamage(gunData.damage);
                    }
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                //OnGunShot();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        //Debug.DrawRay(muzzle.position, muzzle.forward);
    }

    //a function to add post gunfire elements(not currently utilized, served as a vessel..)
    //private void OnGunShot()
    //{
    //    throw new NotImplementedException();
    //}
}
