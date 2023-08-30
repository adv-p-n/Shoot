using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitVFX;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        MuzzleFlashFX();
        ProcessRaycast();

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
            if (enemyHealth) { enemyHealth.ReduceHealth(damage); }
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
