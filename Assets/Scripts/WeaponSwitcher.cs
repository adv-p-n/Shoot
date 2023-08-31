using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex = 0;
    void Start()
    {
        SetWeaponActive();
    }

     void SetWeaponActive()
    {
        int weaponIndex=0;
        foreach(Transform child in transform)
        {
            if(weaponIndex == currentWeaponIndex)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
