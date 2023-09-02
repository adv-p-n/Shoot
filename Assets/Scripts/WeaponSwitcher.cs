using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex = 0;
    int previousWeaponIndex = 0;
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

    void Update()
    {
        ProcessKeyboardInput();
        ProcessScrollWheelInput();
        if(previousWeaponIndex!=currentWeaponIndex)
        {
            SetWeaponActive();
            previousWeaponIndex = currentWeaponIndex;
        }
        
    }

     void ProcessScrollWheelInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(currentWeaponIndex==0)
            {
                currentWeaponIndex = transform.childCount -1;
            }
            else
            {
                currentWeaponIndex--;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeaponIndex >= transform.childCount-1)
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex++;
            }
        }
    }

    void ProcessKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIndex = 2;
        }
    }
}
