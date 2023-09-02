using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Ammo+++");
            FindObjectOfType<Ammo>().IncreaseAmmoAmount(ammoType,ammoAmount);
            gameObject.SetActive(false);
        }
    }
}
