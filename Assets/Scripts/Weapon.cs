using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] float shootDelay = 0.2f;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoDisplayText;

    bool canShoot = true;
    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

     void DisplayAmmo()
    {
        ammoDisplayText.text = ($"Ammo :{ammoSlot.GetAmmoAmount(ammoType)}");
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            MuzzleFlashFX();
            ProcessRaycast();
            ammoSlot.ReduceAmmoAmount(ammoType);
        }
        yield return new WaitForSecondsRealtime(shootDelay);
        canShoot = true;
    }

    void MuzzleFlashFX()
    {
        muzzleFlashVFX.Play();
    }

     void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitVFX(hit);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth) 
            {
                enemyHealth.ReduceHealth(damage);
            }
        }
        else
        {
            return;
        }
    }

     void CreateHitVFX(RaycastHit hit)
    {
        GameObject impact =  Instantiate(hitVFX,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact,0.1f);
    }
}
